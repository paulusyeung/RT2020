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
using RT2020.DAL;
using System.Linq;
using System.Data.Entity;

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
        private Guid GetClassId(string classCode)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "ClassCode = '" + classCode + "'";
            MemberClass oClass = MemberClass.LoadWhere(sql);
            if (oClass != null)
            {
                result = oClass.ClassId;
            }

            return result;
        }

        private Guid GetGroupId(string groupCode)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "GroupCode = '" + groupCode + "'";
            MemberGroup oGroup = MemberGroup.LoadWhere(sql);
            if (oGroup != null)
            {
                result = oGroup.GroupId;
            }

            return result;
        }

        private Guid GetSalutationId(string saluteCode)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "SalutationCode = '" + saluteCode + "'";
            Salutation oSalutation = Salutation.LoadWhere(sql);
            if (oSalutation != null)
            {
                result = oSalutation.SalutationId;
            }

            return result;
        }

        private Guid GetJobTitleId(string titleCode)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "JobTitleCode = '" + titleCode + "'";
            JobTitle oJobTitle = JobTitle.LoadWhere(sql);
            if (oJobTitle != null)
            {
                result = oJobTitle.JobTitleId;
            }

            return result;
        }

        private Guid GetSmartTagId(string priority)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "Priority = '" + priority + "'";
            SmartTag4Member oTag = SmartTag4Member.LoadWhere(sql);
            if (oTag != null)
            {
                result = oTag.TagId;
            }

            return result;
        }

        private Guid GetPhoneTagId(string priority)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "Priority = '" + priority + "'";
            RT2020.DAL.PhoneTag oTag = RT2020.DAL.PhoneTag.LoadWhere(sql);
            if (oTag != null)
            {
                result = oTag.PhoneTagId;
            }

            return result;
        }

        private Guid GetCountryId(string countryName)
        {
            System.Guid result = System.Guid.Empty;
            string sql = "CountryName = '" + countryName + "'";
            Country oCountry = Country.LoadWhere(sql);
            if (oCountry != null)
            {
                result = oCountry.CountryId;
            }

            return result;
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

            MemberAddressTypeCollection oTypeList = MemberAddressType.LoadCollection();
            if (oTypeList.Count > 0)
            {
                result = oTypeList[0].AddressTypeId;
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
            string sql = "MemberNumber = '" + member.VIPNO + "'";
            RT2020.DAL.Member oMember = RT2020.DAL.Member.LoadWhere(sql);
            if (oMember == null)
            {
                oMember = new RT2020.DAL.Member();

                oMember.MemberNumber = member.VIPNO;

                oMember.CreatedBy = Common.Config.CurrentUserId;
                oMember.CreatedOn = DateTime.Now;
            }

            oMember.WorkplaceId = System.Guid.Empty;
            oMember.ClassId = GetClassId(member.PHONEBOOK);
            oMember.GroupId = GetGroupId(member.GROUP);
            oMember.MemberInitial = member.NNAME;
            oMember.SalutationId = GetSalutationId(member.SALUTE);
            oMember.FirstName = member.FNAME;
            oMember.LastName = member.LNAME;
            oMember.FullName = member.LNAME + ", " + member.FNAME;
            oMember.FullName_Chs = member.CNAME;
            oMember.FullName_Cht = member.CNAME;
            oMember.JobTitleId = GetJobTitleId(member.TITLE);
            oMember.AssignedTo = System.Guid.Empty;
            oMember.Remarks = member.REMARKS;
            oMember.NormalDiscount = member.NRDISC;
            oMember.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));

            oMember.ModifiedBy = Common.Config.CurrentUserId;
            oMember.ModifiedOn = DateTime.Now;
            oMember.Save();

            SaveSmartTag(oMember.MemberId, member);
            SaveAddress(oMember.MemberId, member);
            SaveVipData(oMember.MemberId, member);
        }

        private void SaveSmartTag(Guid memberId, MemberTemplate member)
        {
            System.Guid tagId = System.Guid.Empty;
            string sql = "MemberId = '" + memberId.ToString() + "' AND TagId = '{0}'";

            // Grade
            tagId = GetSmartTagId("1");
            MemberSmartTag oGradeTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oGradeTag == null)
            {
                oGradeTag = new MemberSmartTag();
                oGradeTag.MemberId = memberId;
                oGradeTag.TagId = tagId;
            }
            oGradeTag.SmartTagValue = member.GRADE;
            oGradeTag.Save();

            // Sex
            tagId = GetSmartTagId("2");
            MemberSmartTag oSexTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oSexTag == null)
            {
                oSexTag = new MemberSmartTag();
                oSexTag.MemberId = memberId;
                oSexTag.TagId = tagId;
            }
            oSexTag.SmartTagValue = member.SEX;
            oSexTag.Save();

            // Race
            tagId = GetSmartTagId("3");
            MemberSmartTag oRaceTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oRaceTag == null)
            {
                oRaceTag = new MemberSmartTag();
                oRaceTag.MemberId = memberId;
                oRaceTag.TagId = tagId;
            }
            oRaceTag.SmartTagValue = member.RACE;
            oRaceTag.Save();

            // AgeGroup
            tagId = GetSmartTagId("4");
            MemberSmartTag oAgeGroupTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oAgeGroupTag == null)
            {
                oAgeGroupTag = new MemberSmartTag();
                oAgeGroupTag.MemberId = memberId;
                oAgeGroupTag.TagId = tagId;
            }
            oAgeGroupTag.SmartTagValue = member.AGE_GROUP;
            oAgeGroupTag.Save();

            // CodeCardNumber
            tagId = GetSmartTagId("5");
            MemberSmartTag oCodeCardNumberTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oCodeCardNumberTag == null)
            {
                oCodeCardNumberTag = new MemberSmartTag();
                oCodeCardNumberTag.MemberId = memberId;
                oCodeCardNumberTag.TagId = tagId;
            }
            oCodeCardNumberTag.SmartTagValue = member.CODENUM;
            oCodeCardNumberTag.Save();

            // LoyaltyNumber
            tagId = GetSmartTagId("6");
            MemberSmartTag oLoyaltyNumberTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oLoyaltyNumberTag == null)
            {
                oLoyaltyNumberTag = new MemberSmartTag();
                oLoyaltyNumberTag.MemberId = memberId;
                oLoyaltyNumberTag.TagId = tagId;
            }
            oLoyaltyNumberTag.SmartTagValue = member.LOYALTYNUM;
            oLoyaltyNumberTag.Save();

            // Profile
            tagId = GetSmartTagId("7");
            MemberSmartTag oProfileTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oProfileTag == null)
            {
                oProfileTag = new MemberSmartTag();
                oProfileTag.MemberId = memberId;
                oProfileTag.TagId = tagId;
            }
            oProfileTag.SmartTagValue = member.PROFILE;
            oProfileTag.Save();

            // DateOfBirth
            tagId = GetSmartTagId("8");
            MemberSmartTag oDateOfBirthTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oDateOfBirthTag == null)
            {
                oDateOfBirthTag = new MemberSmartTag();
                oDateOfBirthTag.MemberId = memberId;
                oDateOfBirthTag.TagId = tagId;
            }
            oDateOfBirthTag.SmartTagValue = RT2020.SystemInfo.Settings.DateTimeToString(member.DATE_BIRTH, false);
            oDateOfBirthTag.Save();

            // DateOfRegister
            tagId = GetSmartTagId("9");
            MemberSmartTag oDateOfRegisterTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oDateOfRegisterTag == null)
            {
                oDateOfRegisterTag = new MemberSmartTag();
                oDateOfRegisterTag.MemberId = memberId;
                oDateOfRegisterTag.TagId = tagId;
            }
            oDateOfRegisterTag.SmartTagValue = RT2020.SystemInfo.Settings.DateTimeToString(member.DATE_REGIS, false);
            oDateOfRegisterTag.Save();

            // HKID
            tagId = GetSmartTagId("10");
            MemberSmartTag oHKIDTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oHKIDTag == null)
            {
                oHKIDTag = new MemberSmartTag();
                oHKIDTag.MemberId = memberId;
                oHKIDTag.TagId = tagId;
            }
            oHKIDTag.SmartTagValue = member.ID_NO;
            oHKIDTag.Save();

            // Nationality
            tagId = GetSmartTagId("11");
            MemberSmartTag oNationalityTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oNationalityTag == null)
            {
                oNationalityTag = new MemberSmartTag();
                oNationalityTag.MemberId = memberId;
                oNationalityTag.TagId = tagId;
            }
            oNationalityTag.SmartTagValue = member.NATION;
            oNationalityTag.Save();

            // Email
            tagId = GetSmartTagId("12");
            MemberSmartTag oEmailTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oEmailTag == null)
            {
                oEmailTag = new MemberSmartTag();
                oEmailTag.MemberId = memberId;
                oEmailTag.TagId = tagId;
            }
            oEmailTag.SmartTagValue = member.EMAIL;
            oEmailTag.Save();

            // Company
            tagId = GetSmartTagId("13");
            MemberSmartTag oCompanyTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oCompanyTag == null)
            {
                oCompanyTag = new MemberSmartTag();
                oCompanyTag.MemberId = memberId;
                oCompanyTag.TagId = tagId;
            }
            oCompanyTag.SmartTagValue = member.COMPNAME;
            oCompanyTag.Save();

            // CompanyName_Ch
            tagId = GetSmartTagId("14");
            MemberSmartTag oCompanyName_ChTag = MemberSmartTag.LoadWhere(string.Format(sql, tagId));
            if (oCompanyName_ChTag == null)
            {
                oCompanyName_ChTag = new MemberSmartTag();
                oCompanyName_ChTag.MemberId = memberId;
                oCompanyName_ChTag.TagId = tagId;
            }
            oCompanyName_ChTag.SmartTagValue = member.COMPNAMEC;
            oCompanyName_ChTag.Save();
        }

        private void SaveAddress(Guid memberId, MemberTemplate member)
        {
            string sql = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + GetAddressTypeId().ToString() + "'";
            MemberAddress oAddress = MemberAddress.LoadWhere(sql);
            if (oAddress == null)
            {
                oAddress = new MemberAddress();
                oAddress.MemberId = memberId;
                oAddress.AddressTypeId = GetAddressTypeId();
            }
            oAddress.Address = member.ADDRESS4;
            oAddress.PostalCode = string.Empty;
            oAddress.CountryId = GetCountryId(member.ADDRESS1);
            oAddress.ProvinceId = ModelEx.ProvinceEx.GetProvinceIdByName(member.ADDRESS2);
            oAddress.CityId = GetCityId(member.ADDRESS3);
            oAddress.District = string.Empty;
            oAddress.Mailing = true;
            oAddress.PhoneTag1 = GetPhoneTagId("1");
            oAddress.PhoneTag1Value = member.TELW;
            oAddress.PhoneTag2 = GetPhoneTagId("2");
            oAddress.PhoneTag2Value = member.TELH;
            oAddress.PhoneTag3 = GetPhoneTagId("3");
            oAddress.PhoneTag3Value = member.FAX;
            oAddress.PhoneTag4 = GetPhoneTagId("4");
            oAddress.PhoneTag4Value = member.TELOTHER;

            oAddress.Save();
        }

        private void SaveVipData(Guid memberId, MemberTemplate member)
        {
            string sql = "MemberId = '" + memberId.ToString() + "'";
            MemberVipData oVip = MemberVipData.LoadWhere(sql);
            if (oVip == null)
            {
                oVip = new MemberVipData();

                oVip.MemberId = memberId;
                oVip.VipNumber = member.VIPNO;
            }
            oVip.FORMER_PPNO = member.FORMER_PPNO;
            oVip.CARD_ACTIVE = (string.IsNullOrEmpty(member.CARD_ACTIVE)) ? false : Convert.ToBoolean(member.CARD_ACTIVE);
            oVip.CARD_RECEIVE = (string.IsNullOrEmpty(member.CARD_RECEIVE)) ? false : Convert.ToBoolean(member.CARD_RECEIVE);
            oVip.CARD_NAME = member.CARD_NAME;
            oVip.CARD_EXPIRE = member.CARD_EXPIRE;
            oVip.CARD_ISSUE = member.CARD_ISSUE;

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

            oVip.Save();
        }
        #endregion
    }
}