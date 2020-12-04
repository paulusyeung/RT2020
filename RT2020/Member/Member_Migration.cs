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
            string query = "RECORD_SOURCE = 'IMPORT'";
            MemberApply4TempVipCollection objTempVip = MemberApply4TempVip.LoadCollection(query);
            if (objTempVip.Count == 0)
            {
                MessageBox.Show("No record found.", "Warning!");
            }

            btnProcess.Enabled = (objTempVip.Count != 0);
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
            RT2020.DAL.MemberCollection objMemberList = RT2020.DAL.Member.LoadCollection();
            for (int i = 0; i < objMemberList.Count; i++)
            {
                RT2020.DAL.Member objMember = objMemberList[i];

                objMember.Status = (int)Common.Enums.Status.Deleted;
                objMember.Retired = true;
                objMember.RetiredBy = Common.Config.CurrentUserId;
                objMember.RetiredOn = DateTime.Now;

                objMember.Save();
            }
        }

        /// <summary>
        /// Processes the migration.
        /// </summary>
        private void ProcessMigration(bool canDelete)
        {
            string query = "RECORD_SOURCE = 'IMPORT'";
            MemberApply4TempVipCollection objTempVipList = MemberApply4TempVip.LoadCollection(query);
            for (int i = 0; i < objTempVipList.Count; i++)
            {
                MemberApply4TempVip objTempVip = objTempVipList[i];

                System.Guid memberId = this.UpdateMemberMainInfo(objTempVip, canDelete);
                if (memberId != System.Guid.Empty)
                {
                    this.UpdateMemberAddressInfo(memberId, objTempVip);
                    this.UpdateMemberSmartTagValues(memberId, objTempVip);
                    this.UpdateVipData(memberId, objTempVip);
                }

                // Delete temp record
                objTempVip.Delete();
            }
        }

        #region Member Info

        /// <summary>
        /// Updates the member main info.
        /// </summary>
        /// <param name="objTempVip">The temp vip object.</param>
        /// <param name="canDelete">if set to <c>true</c> [can delete].</param>
        /// <returns>member id</returns>
        private Guid UpdateMemberMainInfo(MemberApply4TempVip objTempVip, bool canDelete)
        {
            bool isNew = false;
            System.Guid memberId = System.Guid.Empty;
            string query = "MemberNumber = '" + objTempVip.VIPNO.Trim() + "'";
            RT2020.DAL.Member objMember = RT2020.DAL.Member.LoadWhere(query);
            if (objMember == null)
            {
                isNew = true;

                objMember = new RT2020.DAL.Member();
                objMember.MemberId = System.Guid.NewGuid();
                objMember.MemberNumber = objTempVip.VIPNO;

                objMember.CreatedBy = Common.Config.CurrentUserId;
                objMember.CreatedOn = DateTime.Now;
                objMember.Retired = false;
                objMember.RetiredBy = System.Guid.Empty;
                objMember.RetiredOn = new DateTime(1900, 1, 1);
            }

            // Check the temp vip DLFLAG
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

            // Option 2. Migrate Temporary VIP to Permanent VIP With Delete
            if (canDelete)
            {
                objMember.Status = (int)Common.Enums.Status.Deleted;
            }

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

            objMember.Save();

            memberId = objMember.MemberId;

            return memberId;
        }

        #region Misc Methods

        /// <summary>
        /// Gets the class id.
        /// </summary>
        /// <param name="classCode">The class code.</param>
        /// <returns></returns>
        private Guid GetClassId(string classCode)
        {
            string query = "ClassCode = '" + classCode + "'";
            MemberClassCollection objClassList = MemberClass.LoadCollection(query);
            if (objClassList.Count == 0)
            {
                MemberClass objClass = new MemberClass();
                objClass.ClassId = System.Guid.NewGuid();
                objClass.ClassCode = classCode;
                objClass.ClassName = classCode;
                objClass.ClassName_Chs = classCode;
                objClass.ClassName_Cht = classCode;

                objClass.Save();

                return objClass.ClassId;
            }
            else
            {
                return objClassList[0].ClassId;
            }
        }

        /// <summary>
        /// Gets the group id.
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns></returns>
        private Guid GetGroupId(string groupCode)
        {
            string query = "GroupCode = '" + groupCode + "'";
            MemberGroupCollection objGroupList = MemberGroup.LoadCollection(query);
            if (objGroupList.Count == 0)
            {
                MemberGroup objGroup = new MemberGroup();
                objGroup.GroupId = System.Guid.NewGuid();
                objGroup.GroupCode = groupCode;
                objGroup.GroupName = groupCode;
                objGroup.GroupName_Chs = groupCode;
                objGroup.GroupName_Cht = groupCode;

                objGroup.Save();

                return objGroup.GroupId;
            }
            else
            {
                return objGroupList[0].GroupId;
            }
        }

        /// <summary>
        /// Gets the salute id.
        /// </summary>
        /// <param name="saluteCode">The salute code.</param>
        /// <returns></returns>
        private Guid GetSaluteId(string saluteCode)
        {
            string query = "SalutationCode = '" + saluteCode + "'";
            SalutationCollection objSalutationList = Salutation.LoadCollection(query);
            if (objSalutationList.Count == 0)
            {
                Salutation objSalutation = new Salutation();
                objSalutation.SalutationId = System.Guid.NewGuid();
                objSalutation.SalutationCode = saluteCode;
                objSalutation.SalutationName = saluteCode;
                objSalutation.SalutationName_Chs = saluteCode;
                objSalutation.SalutationName_Cht = saluteCode;

                objSalutation.Save();

                return objSalutation.SalutationId;
            }
            else
            {
                return objSalutationList[0].SalutationId;
            }
        }

        /// <summary>
        /// Gets the address type id.
        /// </summary>
        /// <param name="addressType">Type of the address.</param>
        /// <returns></returns>
        private Guid GetAddressTypeId(string addressType)
        {
            string query = "AddressTypeCode = '" + addressType + "'";
            MemberAddressType oType = MemberAddressType.LoadWhere(query);
            if (oType != null)
            {
                return oType.AddressTypeId;
            }
            else
            {
                return System.Guid.Empty;
            }
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
        private void UpdateMemberAddressInfo(Guid memberId, MemberApply4TempVip objTempVip)
        {
            // English Address
            System.Guid enAddressTypeId = GetAddressTypeId("ADDR_EN");
            string enAddress = objTempVip.ADDRESS1C + Environment.NewLine + objTempVip.ADDRESS2C + Environment.NewLine + objTempVip.ADDRESS3C + Environment.NewLine + objTempVip.ADDRESS4C;
            this.UpdateMemberAddressInfo(memberId, enAddress, objTempVip.TELW, objTempVip.TELH, objTempVip.FAX, objTempVip.TELOTHER, objTempVip.TELP, enAddressTypeId);

            // Chinese Address
            System.Guid chAddressTypeId = GetAddressTypeId("ADDR_CN");
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
            string query = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + addressType.ToString() + "'";
            MemberAddress objAddress = MemberAddress.LoadWhere(query);
            if (objAddress == null)
            {
                objAddress = new MemberAddress();
                objAddress.AddressId = System.Guid.NewGuid();
                objAddress.AddressTypeId = addressType;
                objAddress.MemberId = memberId;
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

            objAddress.Save();
        }

        /// <summary>
        /// Updates the member smart tag values.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateMemberSmartTagValues(Guid memberId, MemberApply4TempVip objTempVip)
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
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("DOB", 8), objTempVip.DATE_BIRTH.ToString("yyyy-MM-dd"));

            // 9.DOR
            this.UpdateMemberSmartTagValues(memberId, GetSmartTagId("DOR", 9), objTempVip.DATE_REGIS.ToString("yyyy-MM-dd"));

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
            string query = "MemberId = '" + memberId.ToString() + "' AND TagId = '" + tagId.ToString() + "'";
            MemberSmartTag oTag = MemberSmartTag.LoadWhere(query);
            if (oTag == null)
            {
                oTag = new MemberSmartTag();
                oTag.SmartTagId = System.Guid.NewGuid();
                oTag.MemberId = memberId;
                oTag.TagId = tagId;
            }

            oTag.SmartTagValue = tagValue;
            oTag.Save();
        }

        /// <summary>
        /// Updates the vip data.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateVipData(Guid memberId, MemberApply4TempVip objTempVip)
        {
            string query = "MemberId = '" + memberId.ToString() + "'";
            MemberVipData oVip = MemberVipData.LoadWhere(query);
            if (oVip == null)
            {
                oVip = new MemberVipData();
                oVip.MemberVipId = System.Guid.NewGuid();
                oVip.MemberId = memberId;
                oVip.VipNumber = objTempVip.VIPNO;
            }

            oVip.CARD_ISSUE = objTempVip.CARD_ISSUE;
            oVip.CARD_EXPIRE = objTempVip.CARD_EXPIRE;
            oVip.CARD_NAME = objTempVip.CARD_NAME;
            oVip.CARD_RECEIVE = objTempVip.CARD_RECEIVE;
            oVip.CARD_ACTIVE = objTempVip.CARD_ACTIVE;
            oVip.FORMER_PPNO = objTempVip.FORMER_PPNO;
            oVip.MigrationDate = objTempVip.DATE_MIGRATE;
            oVip.CommencementDate = objTempVip.DATE_COMM;
            oVip.CreditLimit = objTempVip.ACREDIT;
            oVip.CreditTerms = objTempVip.TERMS;
            oVip.PaymentDiscount = (decimal)objTempVip.PYDISC;
            oVip.AddOnDiscount = objTempVip.BADDONDISC == "Y" ? true : false;
            oVip.StaffQuota = objTempVip.STAFF_QUOTA;
            oVip.Save();

            this.UpdateLoo(oVip.MemberVipId, objTempVip);
            this.UpdateSupplement(oVip.MemberVipId, objTempVip);
        }

        /// <summary>
        /// Updates the vip loo.
        /// </summary>
        /// <param name="memberId">The member vip id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateLoo(Guid memberVipId, MemberApply4TempVip objTempVip)
        {
            string query = "MemberVipId = '" + memberVipId.ToString() + "'";
            MemberVipLineOfOperation oVipLoo = MemberVipLineOfOperation.LoadWhere(query);
            if (oVipLoo == null)
            {
                oVipLoo = new MemberVipLineOfOperation();
                oVipLoo.VipLooId = System.Guid.NewGuid();
                oVipLoo.MemberVipId = memberVipId;
                oVipLoo.LineOfOperationId = ModelEx.LineOfOperationEx.GetLineOfOperationIdByName(objTempVip.LOOID);
            }
            oVipLoo.NormalDiscount = (decimal)objTempVip.NRDISC;
            oVipLoo.PromotionDiscount = (decimal)objTempVip.PRO_DISC;
            oVipLoo.Save();
        }

        /// <summary>
        /// Updates the supplement.
        /// </summary>
        /// <param name="memberVipId">The member vip id.</param>
        /// <param name="objTempVip">The temp vip object.</param>
        private void UpdateSupplement(Guid memberVipId, MemberApply4TempVip objTempVip)
        {
            string query = "MemberVipId = '" + memberVipId.ToString() + "'";
            MemberVipSupplement oSupplement = MemberVipSupplement.LoadWhere(query);
            if (oSupplement == null)
            {
                oSupplement = new MemberVipSupplement();
                oSupplement.VipSupplementId = System.Guid.NewGuid();
                oSupplement.MemberVipId = memberVipId;
                oSupplement.CustomerNumber = objTempVip.CUSTNUM;
                oSupplement.BRANCH = objTempVip.BRANCH;
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
            oSupplement.Save();
        }

        #endregion

        #endregion
    }
}