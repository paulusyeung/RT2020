#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Member
{
    public partial class PromoteMember : Form
    {
        bool _NoTempMember = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="PromoteMember"/> class.
        /// </summary>
        public PromoteMember()
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

            SetCaptions();
            SetAttributes();
        }

        #region SetCaptions SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("member.promoteTempMembers", "MenuStrip");

            radOption1.Text = WestwindHelper.GetWord("member.promoteTempMembers", "Prompt");
            radOption2.Text = WestwindHelper.GetWord("member.promoteTempMembersWithDelete", "Prompt");
            radPurgeAllRecords.Text = WestwindHelper.GetWord("member.purgeAllMemberRecords", "Prompt");
            gbxOptions.Text = WestwindHelper.GetWord("glossary.options", "General");
            btnProcess.Text = WestwindHelper.GetWord("glossary.process", "General");
            btnExit.Text = WestwindHelper.GetWord("glossary.cancel", "General");
        }

        private void SetAttributes()
        {
            // 2021.01.16 paulus: 句子不完整，似乎漏咗啲字，暫時隱藏
            lblOption1.Visible = lblOption2.Visible = false;
        }
        #endregion

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

        /** 2021.01.29 paulus: purge member records 似乎係 hiden option，點解要咁樣安排呢？暫時取消
        /// <summary>
        /// Handles the KeyDown event of the mainPane control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void mainPane_KeyDown(object objSender, KeyEventArgs e)
        {
            bool buttonPressed = false;

            buttonPressed = e.Control && e.Shift && (e.KeyCode == Keys.A);

            radPurgeAllRecords.Visible = buttonPressed;
            radPurgeAllRecords.Enabled = buttonPressed;
        }
        */
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
                    MessageBox.Show(
                        WestwindHelper.GetWord("member.noTempMember", "Prompt"),
                        WestwindHelper.GetWord("dialog.information", "General"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                btnProcess.Enabled = (counts != 0);
                _NoTempMember = (counts == 0);
            }
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        private void Process()
        {
            if (radOption1.Checked)
            {
                this.ProcessMigration(false);
            }
            else if (radOption2.Checked)
            {
                MessageBox.Show(
                    WestwindHelper.GetWord("member.warning.partialPurged", "Prompt"),
                    WestwindHelper.GetWord("dialog.confirmation", "General"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    new EventHandler(ProcessWithDeletionEventHandler));
            }
            else if (radPurgeAllRecords.Checked)
            {
                //this.ProcessMigration(false);
                //this.PurgeVipRecords();
                // 2021.01.26 paulus: 問多句先 purge
                MessageBox.Show(
                    WestwindHelper.GetWord("member.warning.allPurged", "Prompt"),
                    WestwindHelper.GetWord("dialog.confirmation", "General"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    new EventHandler(ProcessPurgeEventHandler));
            }
        }

        /// <summary>
        /// Processes the event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ProcessWithDeletionEventHandler(object sender, EventArgs e)
        {
            var popup = (Form)sender;
            if (popup != null)
            {
                if (popup.DialogResult == DialogResult.Yes)
                {
                    ProcessMigration(true);
                }
            }
        }

        private void ProcessPurgeEventHandler(object sender, EventArgs e)
        {
            var popup = (Form)sender;
            if (popup != null)
            {
                if (popup.DialogResult == DialogResult.Yes)
                {
                    ProcessMigration(false);    // 使唔使升完級，再 purge？
                    PurgeVipRecords();
                }
            }
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
                    objMember.Status = (int)EnumHelper.Status.Deleted;
                    objMember.Retired = true;
                    objMember.RetiredBy = ConfigHelper.CurrentUserId;
                    objMember.RetiredOn = DateTime.Now;
                }
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// canDelete = true,  升級後刪除 Temp Record
        /// canDelete = false, 升級後保留 Temp Record
        /// </summary>
        /// <param name="canDelete"></param>
        private void ProcessMigration(bool canDelete)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.MemberApply4TempVip.Where(x => x.RECORD_SOURCE == "IMPORT").ToList();

                foreach (var item in list)
                {
                    var memberId = SaveMemberCoreData(item, canDelete);

                    if (memberId != Guid.Empty)
                    {
                        SaveMemberAddresses(memberId, item);
                        SaveMemberSmartTags(memberId, item);
                        SaveMemberVip(memberId, item);
                    }

                    // Delete temp record
                    ctx.MemberApply4TempVip.Remove(item);
                }

                ctx.SaveChanges();
            }
        }

        #region Member Info

        private Guid SaveMemberCoreData(EF6.MemberApply4TempVip objTempVip, bool canDelete)
        {
            Guid result = Guid.Empty, memberId = Guid.Empty;
            bool isNew = false;

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

                    objMember.CreatedBy = ConfigHelper.CurrentUserId;
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
                            objMember.Status = (int)EnumHelper.Status.Active;
                            break;
                        case "M":
                            objMember.Status = (int)EnumHelper.Status.Modified;
                            break;
                        case "D":
                            objMember.Status = (int)EnumHelper.Status.Deleted;
                            break;
                        case "I":
                            objMember.Status = (int)EnumHelper.Status.Inactive;
                            break;
                    }
                }
                else
                {
                    objMember.Status = ctx.Entry(objMember).State == EntityState.Added ?
                        (int)EnumHelper.Status.Active : (int)EnumHelper.Status.Modified;
                }
                #endregion

                #region Option 2. Migrate Temporary VIP to Permanent VIP With Delete
                if (canDelete)
                {
                    objMember.Status = (int)EnumHelper.Status.Deleted;
                }
                #endregion

                #region update Member core data
                objMember.WorkplaceId = Guid.Empty;
                objMember.ClassId = MemberHelper.GetClassId(objTempVip.PHONEBOOK); //Class
                objMember.GroupId = MemberHelper.GetGroupId(objTempVip.GROUP);
                objMember.MemberInitial = objTempVip.NNAME; // Nick Name
                objMember.SalutationId = MemberHelper.GetSaluteId(objTempVip.SALUTE);
                objMember.FirstName = objTempVip.FNAME; // First Name
                objMember.LastName = objTempVip.LNAME; // Last Name
                objMember.FullName = objTempVip.FNAME + "," + objTempVip.LNAME; // Full Name
                objMember.FullName_Chs = objTempVip.CNAME; // Chinese Name (S)
                objMember.FullName_Cht = objTempVip.CNAME; // Chinese Name (T)
                objMember.JobTitleId = JobTitleEx.GetJobTitleIdByName(objTempVip.TITLE);
                objMember.AssignedTo = Guid.Empty;
                objMember.Remarks = objTempVip.REMARKS;
                objMember.NormalDiscount = (decimal)objTempVip.NRDISC;
                objMember.DownloadToPOS = true;
                objMember.ModifiedBy = ConfigHelper.CurrentUserId;
                objMember.ModifiedOn = DateTime.Now;

                if (objMember.Status == (int)EnumHelper.Status.Deleted || objMember.Status == (int)EnumHelper.Status.Inactive)
                {
                    objMember.Retired = false;
                    objMember.RetiredBy = Guid.Empty;
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
        /// Gets the smart tag id.
        /// </summary>
        /// <param name="tagCode">The tag code.</param>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        private Guid GetSmartTagId(string tagCode, int priority)
        {
            return SmartTag4MemberEx.GetIdByTagCodeAndPriority(tagCode, priority);
        }

        #endregion

        #region SaveMemberAddresses
        private void SaveMemberAddresses(Guid memberId, EF6.MemberApply4TempVip objTempVip)
        {
            // English Address
            var enAddressTypeId = MemberAddressTypeEx.GetIdByCode("ADDR_EN");
            string enAddress = objTempVip.ADDRESS1 + Environment.NewLine + objTempVip.ADDRESS2 + Environment.NewLine + objTempVip.ADDRESS3 + Environment.NewLine + objTempVip.ADDRESS4; 
            SaveMemberAddress(memberId, enAddress, objTempVip.TELW, objTempVip.TELH, objTempVip.FAX, objTempVip.TELOTHER, objTempVip.TELP, enAddressTypeId);

            // Chinese Address
            var chAddressTypeId = MemberAddressTypeEx.GetIdByCode("ADDR_CN");
            string chAddress = objTempVip.ADDRESS1C + Environment.NewLine + objTempVip.ADDRESS2C + Environment.NewLine + objTempVip.ADDRESS3C + Environment.NewLine + objTempVip.ADDRESS4C;
            SaveMemberAddress(memberId, chAddress, objTempVip.TELW, objTempVip.TELH, objTempVip.FAX, objTempVip.TELOTHER, objTempVip.TELP, chAddressTypeId);
        }

        private void SaveMemberAddress(Guid memberId, string address, string workPhone, string homePhone, string fax, string otherPhone, string pager, Guid addressType)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string query = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + addressType.ToString() + "'";
                var objAddress = ctx.MemberAddress.Where(x => x.MemberId == memberId && x.AddressTypeId == addressType).FirstOrDefault();
                if (objAddress == null)
                {
                    objAddress = new EF6.MemberAddress();
                    objAddress.AddressId = Guid.NewGuid();
                    objAddress.AddressTypeId = addressType;
                    objAddress.MemberId = memberId;

                    ctx.MemberAddress.Add(objAddress);
                }

                objAddress.Address = address;
                objAddress.PostalCode = string.Empty;
                objAddress.CountryId = Guid.Empty;
                objAddress.ProvinceId = Guid.Empty;
                objAddress.CityId = Guid.Empty;
                objAddress.District = string.Empty;
                objAddress.Mailing = false;
                objAddress.PhoneTag1 = PhoneTagEx.GetPhoneTagIdByPriority(1);
                objAddress.PhoneTag1Value = workPhone;
                objAddress.PhoneTag2 = PhoneTagEx.GetPhoneTagIdByPriority(2);
                objAddress.PhoneTag2Value = homePhone;
                objAddress.PhoneTag3 = PhoneTagEx.GetPhoneTagIdByPriority(3);
                objAddress.PhoneTag3Value = fax;
                objAddress.PhoneTag4 = PhoneTagEx.GetPhoneTagIdByPriority(4);
                objAddress.PhoneTag4Value = otherPhone;
                objAddress.PhoneTag5 = PhoneTagEx.GetPhoneTagIdByPriority(5);
                objAddress.PhoneTag5Value = pager;

                ctx.SaveChanges();
            }
        }
        #endregion

        #region SaveMemberSmartTags
        private void SaveMemberSmartTags(Guid memberId, EF6.MemberApply4TempVip objTempVip)
        {
            // 1.Grade
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Grade", 1), objTempVip.GRADE);

            // 2.Sex
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Sex", 2), objTempVip.SEX);

            // 3.Race
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Race", 3), objTempVip.RACE);

            // 4.Age Group
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Age Group", 4), objTempVip.AGE_GROUP);

            // 5.CodeNumber
            this.SaveMemberSmartTag(memberId, GetSmartTagId("CodeNumber", 5), objTempVip.CODENUM);

            // 6.LoyaltyNum
            this.SaveMemberSmartTag(memberId, GetSmartTagId("LoyaltyNum", 6), objTempVip.LOYALTYNUM);

            // 7.Profile
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Profile", 7), objTempVip.PROFILE);

            // 8.DOB
            this.SaveMemberSmartTag(memberId, GetSmartTagId("DOB", 8), objTempVip.DATE_BIRTH.Value.ToString("yyyy-MM-dd"));

            // 9.DOR
            this.SaveMemberSmartTag(memberId, GetSmartTagId("DOR", 9), objTempVip.DATE_REGIS.Value.ToString("yyyy-MM-dd"));

            // 10.HKID
            this.SaveMemberSmartTag(memberId, GetSmartTagId("HKID", 10), objTempVip.ID_NO);

            // 11.Nationalit
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Nationalit", 11), objTempVip.NATION);

            // 12.Email
            this.SaveMemberSmartTag(memberId, GetSmartTagId("Email", 12), objTempVip.EMAIL);

            // 13.ComName EN
            this.SaveMemberSmartTag(memberId, GetSmartTagId("ComName EN", 13), objTempVip.COMPNAME);

            // 14.ComName CN
            this.SaveMemberSmartTag(memberId, GetSmartTagId("ComName CN", 14), objTempVip.COMPNAMEC);
        }

        private void SaveMemberSmartTag(Guid memberId, Guid tagId, string tagValue)
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
        #endregion

        private void SaveMemberVip(Guid memberId, EF6.MemberApply4TempVip objTempVip)
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
                    oVipLoo.LineOfOperationId = LineOfOperationEx.GetLineOfOperationIdByName(objTempVip.LOOID);

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

        private void options_CheckedChanged(object sender, EventArgs e)
        {
            var option = (RadioButton)sender;
            switch (option.Tag.ToString())
            {
                case "option1":
                case "option2":
                    btnProcess.Enabled = !_NoTempMember;
                    break;
                case "option3":
                    btnProcess.Enabled = true;
                    break;
            }
        }
    }
}