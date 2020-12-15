#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Linq;

#endregion

namespace RT2020.Member
{
    public partial class Member_Migration : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Member_Migration"/> class.
        /// </summary>
        public Member_Migration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CheckTempRecords();
        }

        #region Events

        /// <summary>
        /// click the Buttons.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnprocess":
                            this.Process();
                            break;
                        case "btnexit":
                            this.Close();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the mainPane control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void mainPane_KeyDown(object objSender, KeyEventArgs e)
        {
            bool buttonPressed = false;

            buttonPressed = e.Control && e.Shift && (e.KeyCode == Keys.A);

            rbtnOverwriteAllRecords.Visible = buttonPressed;
            rbtnOverwriteAllRecords.Enabled = buttonPressed;
        }

        #endregion

        #region Process

        /// <summary>
        /// Checks the temp records.
        /// </summary>
        private void CheckTempRecords()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string query = "RECORD_SOURCE = 'IMPORT'";
                var counts = ctx.MemberApply4TempVip.Where(x => x.RECORD_SOURCE == "IMPORT").Count();
                if (counts == 0)
                {
                    MessageBox.Show("No record found.", "Warning!");
                }

                btnProcess.Enabled = (counts != 0);
            }
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        private void Process()
        {
            if (rbtnOption1.Checked)
            {
                this.ProcessMigration(false);
            }
            else if (rbtnOption2.Checked)
            {
                MessageBox.Show("WARNING!!! All Normal VIP records which does not exist in Temp VIP Table will be PURGED.", "Confirm Proceed?", MessageBoxButtons.YesNo, new EventHandler(ProcessWithDeletionEventHandler));
            }
            else if (rbtnOverwriteAllRecords.Checked)
            {
                this.ProcessMigration(false);
                this.PurgeVipRecords();
            }
        }

        /// <summary>
        /// Processes the event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ProcessWithDeletionEventHandler(object sender, EventArgs e)
        {
            this.ProcessMigration(true);
        }

        /// <summary>
        /// Purges the vip records.
        /// </summary>
        private void PurgeVipRecords()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var objMemberList = ctx.Member.OrderBy(x => x.MemberNumber);
                foreach (var objMember in objMemberList)
                {
                    objMember.Status = (int)Common.Enums.Status.Deleted;
                    objMember.Retired = true;
                    objMember.RetiredBy = Common.Config.CurrentUserId;
                    objMember.RetiredOn = DateTime.Now;
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Processes the migration.
        /// </summary>
        private void ProcessMigration(bool canDelete)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string query = "RECORD_SOURCE = 'IMPORT'";
                var objTempVipList = ctx.MemberApply4TempVip.Where(x => x.RECORD_SOURCE == "IMPORT").ToList();
                for (int i = 0; i < objTempVipList.Count; i++)
                {
                    var objTempVip = objTempVipList[i];

                    System.Guid memberId = this.UpdateMemberMainInfo(objTempVip, canDelete);
                    if (memberId != System.Guid.Empty)
                    {
                        this.UpdateMemberAddressInfo(memberId, objTempVip);
                        this.UpdateMemberSmartTagValues(memberId, objTempVip);
                        this.UpdateVipData(memberId, objTempVip);
                    }

                    // Delete temp record
                    ctx.MemberApply4TempVip.Remove(objTempVip);
                }
                ctx.SaveChanges();
            }
        }

        #region Member Info

        /// <summary>
        /// Updates the member main info.
        /// </summary>
        /// <param name="objTempVip">The temp vip object.</param>
        /// <param name="canDelete">if set to <c>true</c> [can delete].</param>
        /// <returns>member id</returns>
        private Guid UpdateMemberMainInfo(EF6.MemberApply4TempVip objTempVip, bool canDelete)
        {
            Guid result = Guid.Empty;
            bool isNew = false;
            System.Guid memberId = System.Guid.Empty;
            //string query = "MemberNumber = '" + objTempVip.VIPNO.Trim() + "'";
            var memberNumber = objTempVip.VIPNO.Trim();

            using (var ctx = new EF6.RT2020Entities())
            {
                var objMember = ctx.Member.Where(x => x.MemberNumber == memberNumber).FirstOrDefault();
                if (objMember == null)
                {
                    #region add new Member
                    isNew = true;

                    objMember = new EF6.Member();
                    objMember.MemberId = Guid.NewGuid();
                    objMember.MemberNumber = objTempVip.VIPNO;

                    objMember.CreatedBy = Common.Config.CurrentUserId;
                    objMember.CreatedOn = DateTime.Now;
                    objMember.Retired = false;
                    objMember.RetiredBy = Guid.Empty;
                    objMember.RetiredOn = new DateTime(1900, 1, 1);

                    ctx.Member.Add(objMember);
                    #endregion
                }

                #region Check the temp vip DLFLAG
                if (objTempVip.DLFLAG.Trim().Length > 0)
                {
                    switch (objTempVip.DLFLAG.Trim().ToUpper())
                    {
                        case "A":
                        case "":
                        default:
                            objMember.Status = (int)Common.Enums.Status.Active;
                            break;
                        case "M":
                            objMember.Status = (int)Common.Enums.Status.Modified;
                            break;
                        case "D":
                            objMember.Status = (int)Common.Enums.Status.Deleted;
                            break;
                        case "I":
                            objMember.Status = (int)Common.Enums.Status.Inactive;
                            break;
                    }
                }
                else
                {
                    if (isNew)
                    {
                        objMember.Status = (int)Common.Enums.Status.Active;
                    }
                    else
                    {
                        objMember.Status = (int)Common.Enums.Status.Modified;
                    }
                }
                #endregion

                #region Option 2. Migrate Temporary VIP to Permanent VIP With Delete
                if (canDelete)
                {
                    objMember.Status = (int)Common.Enums.Status.Deleted;
                }
                #endregion

                #region update Member core data
                objMember.WorkplaceId = System.Guid.Empty;
                objMember.ClassId = GetClassId(objTempVip.PHONEBOOK); //Class
                objMember.GroupId = GetGroupId(objTempVip.GROUP);
                objMember.MemberInitial = objTempVip.NNAME; // Nick Name
                objMember.SalutationId = GetSaluteId(objTempVip.SALUTE);
                objMember.FirstName = objTempVip.FNAME; // First Name
                objMember.LastName = objTempVip.LNAME; // Last Name
                objMember.FullName = objTempVip.FNAME + "," + objTempVip.LNAME; // Full Name
                objMember.FullName_Chs = objTempVip.CNAME; // Chinese Name (S)
                objMember.FullName_Cht = objTempVip.CNAME; // Chinese Name (T)
                objMember.JobTitleId = ModelEx.JobTitleEx.GetJobTitleIdByName(objTempVip.TITLE);
                objMember.AssignedTo = System.Guid.Empty;
                objMember.Remarks = objTempVip.REMARKS;
                objMember.NormalDiscount = (decimal)objTempVip.NRDISC;
                objMember.DownloadToPOS = true;
                objMember.ModifiedBy = Common.Config.CurrentUserId;
                objMember.ModifiedOn = DateTime.Now;

                if (objMember.Status == (int)Common.Enums.Status.Deleted || objMember.Status == (int)Common.Enums.Status.Inactive)
                {
                    objMember.Retired = false;
                    objMember.RetiredBy = System.Guid.Empty;
                    objMember.RetiredOn = new DateTime(1900, 1, 1);
                }
                #endregion

                ctx.SaveChanges();

                result = memberId = objMember.MemberId;
            }

            return result;
        }

        #region Misc Methods

        /// <summary>
        /// Gets the class id.
        /// </summary>
        /// <param name="classCode">The class code.</param>
        /// <returns></returns>
        private Guid GetClassId(string classCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "ClassCode = '" + classCode + "'";
                var item = ctx.MemberClass.Where(x => x.ClassCode == classCode).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.MemberClass();
                    item.ClassId = System.Guid.NewGuid();
                    item.ClassCode = classCode;
                    item.ClassName = classCode;
                    item.ClassName_Chs = classCode;
                    item.ClassName_Cht = classCode;

                    ctx.MemberClass.Add(item);
                    ctx.SaveChanges();
                }
                return item.ClassId;
            }

            return result;
        }

        /// <summary>
        /// Gets the group id.
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns></returns>
        private Guid GetGroupId(string groupCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "GroupCode = '" + groupCode + "'";
                var item = ctx.MemberGroup.Where(x => x.GroupCode == groupCode).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.MemberGroup();
                    item.GroupId = Guid.NewGuid();
                    item.GroupCode = groupCode;
                    item.GroupName = groupCode;
                    item.GroupName_Chs = groupCode;
                    item.GroupName_Cht = groupCode;

                    ctx.MemberGroup.Add(item);
                    ctx.SaveChanges();
                }
                result = item.GroupId;
            }

            return result;
        }

        /// <summary>
        /// Gets the salute id.
        /// </summary>
        /// <param name="saluteCode">The salute code.</param>
        /// <returns></returns>
        private Guid GetSaluteId(string saluteCode)
        {
            Guid result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var objSalutationList = ctx.Salutation.Where(x => x.SalutationCode == saluteCode).FirstOrDefault();
                if (objSalutationList == null)
                {
                    var item = new EF6.Salutation();

                    item.SalutationId = Guid.NewGuid();
                    item.SalutationCode = saluteCode;
                    item.SalutationName = saluteCode;
                    item.SalutationName_Chs = saluteCode;
                    item.SalutationName_Cht = saluteCode;

                    ctx.Salutation.Add(item);
                    ctx.SaveChanges();

                    result = item.SalutationId;
                }
                else
                {
                    result = objSalutationList.SalutationId;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the smart tag id.
        /// </summary>
        /// <param name="tagCode">The tag code.</param>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        private Guid GetSmartTagId(string tagCode, int priority)
        {
            return ModelEx.SmartTag4MemberEx.GetIdByTagCodeAndPriority(tagCode, priority);
        }

        #endregion

        /// <summary>
        /// Updates the member address info.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateMemberAddressInfo(Guid memberId, EF6.MemberApply4TempVip objTempVip)
        {
            // English Address
            System.Guid enAddressTypeId = ModelEx.MemberAddressTypeEx.GetIdByCode("ADDR_EN");
            string enAddress = objTempVip.ADDRESS1C + Environment.NewLine + objTempVip.ADDRESS2C + Environment.NewLine + objTempVip.ADDRESS3C + Environment.NewLine + objTempVip.ADDRESS4C;
            this.UpdateMemberAddressInfo(memberId, enAddress, objTempVip.TELW, objTempVip.TELH, objTempVip.FAX, objTempVip.TELOTHER, objTempVip.TELP, enAddressTypeId);

            // Chinese Address
            System.Guid chAddressTypeId = ModelEx.MemberAddressTypeEx.GetIdByCode("ADDR_CN");
            string chAddress = objTempVip.ADDRESS1 + Environment.NewLine + objTempVip.ADDRESS2 + Environment.NewLine + objTempVip.ADDRESS3 + Environment.NewLine + objTempVip.ADDRESS4;
            this.UpdateMemberAddressInfo(memberId, chAddress, objTempVip.TELW, objTempVip.TELH, objTempVip.FAX, objTempVip.TELOTHER, objTempVip.TELP, chAddressTypeId);
        }

        /// <summary>
        /// Updates the member address info.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="address">The address.</param>
        /// <param name="addressType">Type of the address.</param>
        private void UpdateMemberAddressInfo(Guid memberId, string address, string workPhone, string homePhone, string fax, string otherPhone, string pager, Guid addressType)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + addressType.ToString() + "'";
                var objAddress = ctx.MemberAddress.Where(x => x.MemberId == memberId && x.AddressTypeId == addressType).FirstOrDefault();
                if (objAddress == null)
                {
                    objAddress = new EF6.MemberAddress();
                    objAddress.AddressId = System.Guid.NewGuid();
                    objAddress.AddressTypeId = addressType;
                    objAddress.MemberId = memberId;

                    ctx.MemberAddress.Add(objAddress);
                }

                objAddress.Address = address;
                objAddress.PostalCode = string.Empty;
                objAddress.CountryId = System.Guid.Empty;
                objAddress.ProvinceId = System.Guid.Empty;
                objAddress.CityId = System.Guid.Empty;
                objAddress.District = string.Empty;
                objAddress.Mailing = false;
                objAddress.PhoneTag1 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(1);
                objAddress.PhoneTag1Value = workPhone;
                objAddress.PhoneTag2 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(2);
                objAddress.PhoneTag2Value = homePhone;
                objAddress.PhoneTag3 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(3);
                objAddress.PhoneTag3Value = fax;
                objAddress.PhoneTag4 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(4);
                objAddress.PhoneTag4Value = otherPhone;
                objAddress.PhoneTag5 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(5);
                objAddress.PhoneTag5Value = pager;

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the member smart tag values.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateMemberSmartTagValues(Guid memberId, EF6.MemberApply4TempVip objTempVip)
        {
            // 1.Grade
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Grade", 1), objTempVip.GRADE);

            // 2.Sex
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Sex", 2), objTempVip.SEX);

            // 3.Race
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Race", 3), objTempVip.RACE);

            // 4.Age Group
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Age Group", 4), objTempVip.AGE_GROUP);

            // 5.CodeNumber
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("CodeNumber", 5), objTempVip.CODENUM);

            // 6.LoyaltyNum
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("LoyaltyNum", 6), objTempVip.LOYALTYNUM);

            // 7.Profile
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Profile", 7), objTempVip.PROFILE);

            // 8.DOB
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("DOB", 8), objTempVip.DATE_BIRTH.Value.ToString("yyyy-MM-dd"));

            // 9.DOR
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("DOR", 9), objTempVip.DATE_REGIS.Value.ToString("yyyy-MM-dd"));

            // 10.HKID
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("HKID", 10), objTempVip.ID_NO);

            // 11.Nationalit
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Nationalit", 11), objTempVip.NATION);

            // 12.Email
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("Email", 12), objTempVip.EMAIL);

            // 13.ComName EN
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("ComName EN", 13), objTempVip.COMPNAME);

            // 14.ComName CN
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("ComName CN", 14), objTempVip.COMPNAMEC);
        }

        /// <summary>
        /// Updates the member smart tag values.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="tagId">The tag id.</param>
        /// <param name="tagValue">The tag value.</param>
        private void UpdateMemberSmartTagValues(Guid memberId, Guid tagId, string tagValue)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "MemberId = '" + memberId.ToString() + "' AND TagId = '" + tagId.ToString() + "'";
                var oTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                if (oTag == null)
                {
                    oTag = new EF6.MemberSmartTag();
                    oTag.SmartTagId = Guid.NewGuid();
                    oTag.SmartTagId = System.Guid.NewGuid();
                    oTag.MemberId = memberId;
                    oTag.TagId = tagId;

                    ctx.MemberSmartTag.Add(oTag);
                }

                oTag.SmartTagValue = tagValue;
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the vip data.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateVipData(Guid memberId, EF6.MemberApply4TempVip objTempVip)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "MemberId = '" + memberId.ToString() + "'";
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).FirstOrDefault();
                if (oVip == null)
                {
                    oVip = new EF6.MemberVipData();
                    oVip.MemberVipId = Guid.NewGuid();
                    oVip.MemberId = memberId;
                    oVip.VipNumber = objTempVip.VIPNO;

                    ctx.MemberVipData.Add(oVip);
                }

                oVip.CARD_ISSUE = objTempVip.CARD_ISSUE;
                oVip.CARD_EXPIRE = objTempVip.CARD_EXPIRE;
                oVip.CARD_NAME = objTempVip.CARD_NAME;
                oVip.CARD_RECEIVE = objTempVip.CARD_RECEIVE.Value;
                oVip.CARD_ACTIVE = objTempVip.CARD_ACTIVE.Value;
                oVip.FORMER_PPNO = objTempVip.FORMER_PPNO;
                oVip.MigrationDate = objTempVip.DATE_MIGRATE;
                oVip.CommencementDate = objTempVip.DATE_COMM;
                oVip.CreditLimit = objTempVip.ACREDIT;
                oVip.CreditTerms = objTempVip.TERMS;
                oVip.PaymentDiscount = (decimal)objTempVip.PYDISC;
                oVip.AddOnDiscount = objTempVip.BADDONDISC == "Y" ? true : false;
                oVip.StaffQuota = objTempVip.STAFF_QUOTA;
                ctx.SaveChanges();

                var memberVipId = oVip.MemberVipId;
                #region this.UpdateLoo(oVip.MemberVipId, objTempVip);
                var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == memberVipId).FirstOrDefault();
                if (oVipLoo == null)
                {
                    oVipLoo = new EF6.MemberVipLineOfOperation();
                    oVipLoo.VipLooId = Guid.NewGuid();
                    oVipLoo.VipLooId = System.Guid.NewGuid();
                    oVipLoo.MemberVipId = memberVipId;
                    oVipLoo.LineOfOperationId = ModelEx.LineOfOperationEx.GetLineOfOperationIdByName(objTempVip.LOOID);

                    ctx.MemberVipLineOfOperation.Add(oVipLoo);
                }
                oVipLoo.NormalDiscount = (decimal)objTempVip.NRDISC;
                oVipLoo.PromotionDiscount = (decimal)objTempVip.PRO_DISC;
                ctx.SaveChanges();
                #endregion

                #region this.UpdateSupplement(oVip.MemberVipId, objTempVip);
                var oSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == memberVipId).FirstOrDefault();
                if (oSupplement == null)
                {
                    oSupplement = new EF6.MemberVipSupplement();
                    oSupplement.VipSupplementId = Guid.NewGuid();
                    oSupplement.VipSupplementId = System.Guid.NewGuid();
                    oSupplement.MemberVipId = memberVipId;
                    oSupplement.CustomerNumber = objTempVip.CUSTNUM;
                    oSupplement.BRANCH = objTempVip.BRANCH;

                    ctx.MemberVipSupplement.Add(oSupplement);
                }

                oSupplement.Remarks1 = objTempVip.R1;
                oSupplement.Remarks2 = objTempVip.R2;
                oSupplement.Remarks3 = objTempVip.R3;
                oSupplement.Nature = objTempVip.NATURE;
                oSupplement.Memo = objTempVip.MEMO;
                oSupplement.Photo = objTempVip.PHOTO;
                oSupplement.MostVisitedMalls1 = objTempVip.MALL1;
                oSupplement.MostVisitedMalls2 = objTempVip.MALL2;
                oSupplement.MostVisitedMalls3 = objTempVip.MALL3;
                oSupplement.MostBoughtBrands1 = objTempVip.BRAND1;
                oSupplement.MostBoughtBrands2 = objTempVip.BRAND2;
                oSupplement.MostBoughtBrands3 = objTempVip.BRAND3;
                oSupplement.MostReadMagazine1 = objTempVip.MAGAZINE1;
                oSupplement.MostReadMagazine2 = objTempVip.MAGAZINE2;
                oSupplement.MostReadMagazine3 = objTempVip.MAGAZINE3;
                oSupplement.MostUsedCreditCards1 = objTempVip.CARD1;
                oSupplement.MostUsedCreditCards2 = objTempVip.CARD2;
                oSupplement.MostUsedCreditCards3 = objTempVip.CARD3;
                ctx.SaveChanges();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}