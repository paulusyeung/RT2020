#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using RT2020.Controls;
using FileHelpers;

using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Member.Import
{
    public partial class ImportMember : Form
    {
        string mstrDirectory = string.Empty;
        MemberTemplate[] res = null;

        public ImportMember()
        {
            InitializeComponent();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("Upload"), "Member");
            InitialColumnNameList();
        }

        #region Initial Column Name list
        private void InitialColumnNameList()
        {
            string[] fieldList = new string[] 
            {
                "VIP #",
                "Group",
                "Salute",
                "Last Name",
                "First Name",
                "Nick Name",
                "Address 1",
                "Address 2",
                "Address 3",
                "Address 4",
                "Phone(W)",
                "Phone(H)",
                "Phone(P)",
                "Fax",
                "E-Mail",
                "Sex",
                "Race",
                "Remark(s)",
                "Normal Disc%",
                "Grade",
                "ID #",
                "D.O.B.",
                "Date Register",
                "D.L. Flag",
                "Age",
                "Remark 1",
                "Remark 2",
                "Remark 3",
                "Nation",
                "Memo",
                "Photo",
                "Date Commence",
                "Date Migrate",
                "Card Issue",
                "Card Expire",
                "Card Name",
                "Receive",
                "Active",
                "PP #",
                "Allowed Credit$",
                "Terms",
                "Payment Disc%",
                "Nature",
                "Cust #",
                "Branch",
                "Promotion Disc%",
                "Date Create",
                "Last Update",
                "Last User",
                "Amount Purchased",
                "Amount Paid",
                "Amount Returned",
                "Amount Discounted",
                "Line Of Operation",
                "Code Card#",
                "Loyalty#",
                "Age Group",
                "Profile",
                "Mall#1",
                "Mall#2",
                "Mall#3",
                "Brand#1",
                "Brand#2",
                "Brand#3",
                "Magazine#1",
                "Magazine#2",
                "Magazine#3",
                "Card#1",
                "Card#2",
                "Card#3",
                "Name(Chin)",
                "Title",
                "Company",
                "Company(Chin)",
                "Address (Chin) 1",
                "Address (Chin) 2",
                "Address (Chin) 3",
                "Address (Chin) 4",
                "Phone(Other)",
                "Phonebook",
                "Staff Quota",
                "Add on Discount"
            };

            for (int i = 1; i <= fieldList.Length; i++)
            {
                ListViewItem listItem = lvColumnNameList.Items.Add(i.ToString().PadLeft(2, '0'));
                listItem.SubItems.Add(fieldList[i - 1]);

            }
        }
        #endregion

        #region Events
        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Import Record(s)?", "Import Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(ImportMessageHandler));
        }

        private void ImportMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                int result = Import();
                if (result > 0)
                {
                    MessageBox.Show("Import " + result.ToString() + " Record(s) successfully", "Import Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Import " + result.ToString() + " Record(s) successfully", "Import Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(MemberTemplate));

            res = engine.ReadFile(Path.Combine(mstrDirectory, txtFileName.Text)) as MemberTemplate[];

            foreach (MemberTemplate member in res)
            {
                ListViewItem oItem = lvImportedList.Items.Add(member.VIPNO);
                oItem.SubItems.Add(member.GROUP);
                oItem.SubItems.Add(member.SALUTE);
                oItem.SubItems.Add(member.LNAME);
                oItem.SubItems.Add(member.FNAME);
                oItem.SubItems.Add(member.NNAME);
                oItem.SubItems.Add(member.ADDRESS1);
                oItem.SubItems.Add(member.ADDRESS2);
                oItem.SubItems.Add(member.ADDRESS3);
                oItem.SubItems.Add(member.ADDRESS4);
                oItem.SubItems.Add(member.TELW);
                oItem.SubItems.Add(member.TELH);
                oItem.SubItems.Add(member.TELP);
                oItem.SubItems.Add(member.FAX);
                oItem.SubItems.Add(member.EMAIL);
                oItem.SubItems.Add(member.SEX);
                oItem.SubItems.Add(member.RACE);
                oItem.SubItems.Add(member.REMARKS);
                oItem.SubItems.Add(member.NRDISC.ToString());
                oItem.SubItems.Add(member.GRADE);
            }

            lblTxCount.Text = res.Length.ToString();
        }
        #endregion

        #region Import

        #region IDs
        private Guid GetSmartTagId(string priority)
        {
            return ModelEx.SmartTag4MemberEx.GetIdByPriority(int.Parse(priority));
        }

        private Guid GetCityId(string cityName)
        {
            var result = Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var city = ctx.City.Where(x => x.CityName == cityName).AsNoTracking().FirstOrDefault();
                if (city != null) result = city.CityId;
            }

            return result;
        }

        private Guid GetAddressTypeId()
        {
            System.Guid result = System.Guid.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                var oTypeList = ctx.MemberAddressType.AsNoTracking().ToList();
                if (oTypeList.Count > 0)
                {
                    result = oTypeList[0].AddressTypeId;
                }
            }

            return result;
        }
        #endregion

        private int Import()
        {
            int iCount = 0;
            foreach (MemberTemplate member in res)
            {
                Save(member);
                iCount++;
            }
            return iCount;
        }

        private void Save(MemberTemplate member)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        #region save member core data
                        var oMember = ctx.Member.Where(x => x.MemberNumber == member.VIPNO).FirstOrDefault();
                        if (oMember == null)
                        {
                            oMember = new EF6.Member();
                            oMember.MemberId = Guid.NewGuid();
                            oMember.MemberNumber = member.VIPNO;

                            oMember.CreatedBy = ConfigHelper.CurrentUserId;
                            oMember.CreatedOn = DateTime.Now;

                            ctx.Member.Add(oMember);
                        }

                        oMember.WorkplaceId = System.Guid.Empty;
                        oMember.ClassId = ModelEx.MemberClassEx.GetIdByCode(member.PHONEBOOK);
                        oMember.GroupId = ModelEx.MemberGroupEx.GetIdByCode(member.GROUP);
                        oMember.MemberInitial = member.NNAME;
                        oMember.SalutationId = ModelEx.SalutationEx.GetIdByCode(member.SALUTE);
                        oMember.FirstName = member.FNAME;
                        oMember.LastName = member.LNAME;
                        oMember.FullName = member.LNAME + ", " + member.FNAME;
                        oMember.FullName_Chs = member.CNAME;
                        oMember.FullName_Cht = member.CNAME;
                        oMember.JobTitleId = ModelEx.JobTitleEx.GetJobTitleIdByName(member.TITLE);
                        oMember.AssignedTo = System.Guid.Empty;
                        oMember.Remarks = member.REMARKS;
                        oMember.NormalDiscount = member.NRDISC;
                        oMember.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                        oMember.ModifiedBy = ConfigHelper.CurrentUserId;
                        oMember.ModifiedOn = DateTime.Now;
                        ctx.SaveChanges();
                        #endregion

                        var memberId = oMember.MemberId;
                        #region SaveSmartTag(oMember.MemberId, member);

                        var tagId = Guid.Empty;
                        string sql = "MemberId = '" + memberId.ToString() + "' AND TagId = '{0}'";

                        #region Grade
                        tagId = GetSmartTagId("1");
                        var oGradeTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oGradeTag == null)
                        {
                            oGradeTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oGradeTag.MemberId = memberId;
                            oGradeTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oGradeTag.SmartTagValue = member.GRADE;
                        #endregion

                        #region Sex
                        tagId = GetSmartTagId("2");
                        var oSexTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oSexTag == null)
                        {
                            oSexTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oSexTag.MemberId = memberId;
                            oSexTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oSexTag.SmartTagValue = member.SEX;
                        #endregion

                        #region Race
                        tagId = GetSmartTagId("3");
                        var oRaceTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oRaceTag == null)
                        {
                            oRaceTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oRaceTag.MemberId = memberId;
                            oRaceTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oRaceTag.SmartTagValue = member.RACE;
                        #endregion

                        #region AgeGroup
                        tagId = GetSmartTagId("4");
                        var oAgeGroupTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oAgeGroupTag == null)
                        {
                            oAgeGroupTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oAgeGroupTag.MemberId = memberId;
                            oAgeGroupTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oAgeGroupTag.SmartTagValue = member.AGE_GROUP;
                        #endregion

                        #region CodeCardNumber
                        tagId = GetSmartTagId("5");
                        var oCodeCardNumberTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oCodeCardNumberTag == null)
                        {
                            oCodeCardNumberTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oCodeCardNumberTag.MemberId = memberId;
                            oCodeCardNumberTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oCodeCardNumberTag.SmartTagValue = member.CODENUM;
                        #endregion

                        #region LoyaltyNumber
                        tagId = GetSmartTagId("6");
                        var oLoyaltyNumberTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oLoyaltyNumberTag == null)
                        {
                            oLoyaltyNumberTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oLoyaltyNumberTag.MemberId = memberId;
                            oLoyaltyNumberTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oLoyaltyNumberTag.SmartTagValue = member.LOYALTYNUM;
                        #endregion

                        #region Profile
                        tagId = GetSmartTagId("7");
                        var oProfileTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oProfileTag == null)
                        {
                            oProfileTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oProfileTag.MemberId = memberId;
                            oProfileTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oProfileTag.SmartTagValue = member.PROFILE;
                        #endregion

                        #region DateOfBirth
                        tagId = GetSmartTagId("8");
                        var oDateOfBirthTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oDateOfBirthTag == null)
                        {
                            oDateOfBirthTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oDateOfBirthTag.MemberId = memberId;
                            oDateOfBirthTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oDateOfBirthTag.SmartTagValue = RT2020.SystemInfo.Settings.DateTimeToString(member.DATE_BIRTH, false);
                        #endregion

                        #region DateOfRegister
                        tagId = GetSmartTagId("9");
                        var oDateOfRegisterTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oDateOfRegisterTag == null)
                        {
                            oDateOfRegisterTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oDateOfRegisterTag.MemberId = memberId;
                            oDateOfRegisterTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oDateOfRegisterTag.SmartTagValue = RT2020.SystemInfo.Settings.DateTimeToString(member.DATE_REGIS, false);
                        #endregion

                        #region HKID
                        tagId = GetSmartTagId("10");
                        var oHKIDTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oHKIDTag == null)
                        {
                            oHKIDTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oHKIDTag.MemberId = memberId;
                            oHKIDTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oHKIDTag.SmartTagValue = member.ID_NO;
                        #endregion

                        #region Nationality
                        tagId = GetSmartTagId("11");
                        var oNationalityTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oNationalityTag == null)
                        {
                            oNationalityTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oNationalityTag.MemberId = memberId;
                            oNationalityTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oNationalityTag.SmartTagValue = member.NATION;
                        #endregion

                        #region Email
                        tagId = GetSmartTagId("12");
                        var oEmailTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oEmailTag == null)
                        {
                            oEmailTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oEmailTag.MemberId = memberId;
                            oEmailTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oEmailTag.SmartTagValue = member.EMAIL;
                        #endregion

                        #region Company
                        tagId = GetSmartTagId("13");
                        var oCompanyTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oCompanyTag == null)
                        {
                            oCompanyTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oCompanyTag.MemberId = memberId;
                            oCompanyTag.TagId = tagId;

                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oCompanyTag.SmartTagValue = member.COMPNAME;
                        #endregion

                        #region CompanyName_Ch
                        tagId = GetSmartTagId("14");
                        var oCompanyName_ChTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == tagId).FirstOrDefault();
                        if (oCompanyName_ChTag == null)
                        {
                            oCompanyName_ChTag = new EF6.MemberSmartTag();
                            oGradeTag.SmartTagId = Guid.NewGuid();
                            oCompanyName_ChTag.MemberId = memberId;
                            oCompanyName_ChTag.TagId = tagId;
                            
                            ctx.MemberSmartTag.Add(oGradeTag);
                        }
                        oCompanyName_ChTag.SmartTagValue = member.COMPNAMEC;
                        #endregion

                        ctx.SaveChanges();

                        #endregion

                        #region SaveAddress(oMember.MemberId, member);
                        //string sql = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + GetAddressTypeId().ToString() + "'";
                        var addressTypeId = GetAddressTypeId();
                        var oAddress = ctx.MemberAddress.Where(x => x.MemberId == memberId && x.AddressTypeId == addressTypeId).FirstOrDefault();
                        if (oAddress == null)
                        {
                            oAddress = new EF6.MemberAddress();
                            oAddress.AddressId = Guid.NewGuid();
                            oAddress.MemberId = memberId;
                            oAddress.AddressTypeId = GetAddressTypeId();

                            ctx.MemberAddress.Add(oAddress);
                        }
                        oAddress.Address = member.ADDRESS4;
                        oAddress.PostalCode = string.Empty;
                        oAddress.CountryId = ModelEx.CountryEx.GetCountryIdByName(member.ADDRESS1);
                        oAddress.ProvinceId = ModelEx.ProvinceEx.GetProvinceIdByName(member.ADDRESS2);
                        oAddress.CityId = GetCityId(member.ADDRESS3);
                        oAddress.District = string.Empty;
                        oAddress.Mailing = true;
                        oAddress.PhoneTag1 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(1);
                        oAddress.PhoneTag1Value = member.TELW;
                        oAddress.PhoneTag2 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(2);
                        oAddress.PhoneTag2Value = member.TELH;
                        oAddress.PhoneTag3 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(3);
                        oAddress.PhoneTag3Value = member.FAX;
                        oAddress.PhoneTag4 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(4);
                        oAddress.PhoneTag4Value = member.TELOTHER;

                        ctx.SaveChanges();
                        #endregion

                        #region SaveVipData(oMember.MemberId, member);
                        //string sql = "MemberId = '" + memberId.ToString() + "'";
                        var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).FirstOrDefault();
                        if (oVip == null)
                        {
                            oVip = new EF6.MemberVipData();
                            oVip.MemberVipId = Guid.NewGuid();
                            oVip.MemberId = memberId;
                            oVip.VipNumber = member.VIPNO;

                            ctx.MemberVipData.Add(oVip);
                        }
                        oVip.FORMER_PPNO = member.FORMER_PPNO;
                        oVip.CARD_ACTIVE = (string.IsNullOrEmpty(member.CARD_ACTIVE)) ? false : Convert.ToBoolean(member.CARD_ACTIVE);
                        oVip.CARD_RECEIVE = (string.IsNullOrEmpty(member.CARD_RECEIVE)) ? false : Convert.ToBoolean(member.CARD_RECEIVE);
                        oVip.CARD_NAME = member.CARD_NAME;
                        oVip.CARD_EXPIRE = member.CARD_EXPIRE;
                        oVip.CARD_ISSUE = member.CARD_ISSUE;

                        /**
                        oVip.SetMetadata("CardInfo_CommencementDate", member.DATE_COMM.ToString("yyyy-MM-dd HH:mm:ss"));
                        oVip.SetMetadata("CardInfo_MigrationDate", member.DATE_MIGRATE.ToString("yyyy-MM-dd HH:mm:ss"));

                        // Others Info
                        oVip.SetMetadata("OthersInfo_CreditLimit", member.ACREDIT.ToString());
                        oVip.SetMetadata("OthersInfo_CreditTerms", member.TERMS);
                        oVip.SetMetadata("OthersInfo_PaymentDiscount", member.PYDISC.ToString());
                        oVip.SetMetadata("OthersInfo_CustomerInfo_1", member.CUSTNUM);
                        oVip.SetMetadata("OthersInfo_CustomerInfo_2", member.BRANCH);
                        oVip.SetMetadata("OthersInfo_PromotionDiscount", member.PRO_DISC.ToString());
                        oVip.SetMetadata("OthersInfo_AddOnDiscount", member.BADDONDISC);
                        oVip.SetMetadata("OthersInfo_StaffQuota", member.STAFF_QUOTA.ToString());
                        oVip.SetMetadata("OthersInfo_Remarks1", member.R1);
                        oVip.SetMetadata("OthersInfo_Remarks2", member.R2);
                        oVip.SetMetadata("OthersInfo_Remarks3", member.R3);
                        oVip.SetMetadata("OthersInfo_Nature", member.NATURE);

                        oVip.SetMetadata("OthersInfo_Age", member.AGE);
                        oVip.SetMetadata("OthersInfo_DL_Flag", member.DLFLAG);
                        oVip.SetMetadata("OthersInfo_LOOCode", member.LOOID);
                        oVip.SetMetadata("OthersInfo_AmountPurchased", member.ATDAMTPUR.ToString());
                        oVip.SetMetadata("OthersInfo_AmountPaied", member.ATDAMTPAY.ToString());
                        oVip.SetMetadata("OthersInfo_AmountReturned", member.ATDAMTRET.ToString());
                        oVip.SetMetadata("OthersInfo_AmountDiscounted", member.ATDAMTDIS.ToString());
                        oVip.SetMetadata("OthersInfo_Memo", member.MEMO);

                        // Marketing Info
                        oVip.SetMetadata("MarketingInfo_MostVisitedMalls_1", member.MALL1);
                        oVip.SetMetadata("MarketingInfo_MostVisitedMalls_2", member.MALL2);
                        oVip.SetMetadata("MarketingInfo_MostVisitedMalls_3", member.MALL3);

                        oVip.SetMetadata("MarketingInfo_MostBoughtBrands_1", member.BRAND1);
                        oVip.SetMetadata("MarketingInfo_MostBoughtBrands_2", member.BRAND2);
                        oVip.SetMetadata("MarketingInfo_MostBoughtBrands_3", member.BRAND3);

                        oVip.SetMetadata("MarketingInfo_MostReadMagazine_1", member.MAGAZINE1);
                        oVip.SetMetadata("MarketingInfo_MostReadMagazine_2", member.MAGAZINE2);
                        oVip.SetMetadata("MarketingInfo_MostReadMagazine_3", member.MAGAZINE3);

                        oVip.SetMetadata("MarketingInfo_MostUsedCreditCards_1", member.CARD1);
                        oVip.SetMetadata("MarketingInfo_MostUsedCreditCards_2", member.CARD2);
                        oVip.SetMetadata("MarketingInfo_MostUsedCreditCards_3", member.CARD3);

                        // Photo
                        oVip.SetMetadata("MiscInfo_Photo", member.PHOTO);

                        // Contact
                        oVip.SetMetadata("Address_Phone_Pager", member.TELP);
                        oVip.SetMetadata("Address_Chinese_1", member.ADDRESS1C);
                        oVip.SetMetadata("Address_Chinese_2", member.ADDRESS2C);
                        oVip.SetMetadata("Address_Chinese_3", member.ADDRESS3C);
                        oVip.SetMetadata("Address_Chinese_4", member.ADDRESS4C);
                        */

                        ctx.SaveChanges();
                        #endregion

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        #endregion
    }
}