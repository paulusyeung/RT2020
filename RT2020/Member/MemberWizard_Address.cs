#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Controls;
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Address : UserControl
    {
        private bool _FormLoaded = false;

        #region publice Properties
        private Guid _MemberId = Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_Address()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();

            SetPhoneTag();
            FillComboList();

            _FormLoaded = true;
        }

        #region SetCaptions, SetAttributes & SetPhoneTag
        private void SetCaptions()
        {
            lblAddressType.Text = WestwindHelper.GetWordWithColon("memberAddressType", "Model");
            lblAddress.Text = WestwindHelper.GetWordWithColon("memberAddress", "Model");
            lblDistrict.Text = WestwindHelper.GetWordWithColon("memberAddress.district", "Model");
            lblPostalCode.Text = WestwindHelper.GetWordWithColon("memberAddress.postalCode", "Model");

            lblCountry.Text = WestwindHelper.GetWordWithColon("country", "Model");
            lblProvince.Text = WestwindHelper.GetWordWithColon("province", "Model");
            lblCity.Text = WestwindHelper.GetWordWithColon("city", "Model");

            lblPhoneNumbers.Text = WestwindHelper.GetWordWithColon("memberAddress.phoneNumber", "Model");

            lblPhoneTag1.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblPhoneTag2.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblPhoneTag3.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblPhoneTag4.Text = WestwindHelper.GetWordWithColon("memberClass", "Model");
            lblPhoneTag5.Text = WestwindHelper.GetWordWithColon("memberClass", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable address type label
            lblAddressType.AutoSize = true;                     // 減少 whitespace，有字嘅位置先可以 click
            lblAddressType.Cursor = Cursors.Hand;               // cursor over 顯示 hand cursor
            lblAddressType.Click += (s, e) =>                   // 彈出 wizard
            {
                var dialog = new MemberAddressTypeWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillAddressType();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable country label
            lblCountry.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCountry.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCountry.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.CountryWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCountryList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable province label
            lblProvince.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblProvince.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblProvince.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.ProvinceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillProvinceList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable city label
            //lblCity.AutoSize = true;                            // 減少 whitespace，有字嘅位置先可以 click
            lblCity.Cursor = Cursors.Hand;                      // cursor over 顯示 hand cursor
            lblCity.Click += (s, e) =>                          // 彈出 wizard
            {
                var dialog = new Settings.CityWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillCityList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phone label
            lblPhoneNumbers.AutoSize = true;                    // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneNumbers.Cursor = Cursors.Hand;              // cursor over 顯示 hand cursor
            lblPhoneNumbers.Click += (s, e) =>                  // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTag();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetPhoneTag()
        {
            var oTag = new PhoneTagHelper(this, "MBR");
            oTag.SetPhoneTag();
        }
        #endregion

        #region Fill Combo list
        private void FillComboList()
        {
            FillAddressType();
            FillCountryList();
            FillProvinceList(Guid.Empty);
            FillCityList(Guid.Empty);
        }

        private void FillAddressType()
        {
            string[] orderBy = new string[] { "AddressTypeName" };
            MemberAddressTypeEx.LoadCombo(ref cboAddressType, "AddressTypeName", true, false, "", "", orderBy);
        }

        private void FillCountryList()
        {
            var fields = new string[] { "CountryCode", "CountryName" };
            var pattern = "{0} - {1}";
            var orderby = new string[] { "CountryCode" };
            CountryEx.LoadCombo(ref cboCountry, fields, pattern, true, true, "", "", orderby);
        }

        private void FillProvinceList(Guid countryId)
        {
            var sql = string.Format("CountryId = '{0}'", countryId.ToString());

            ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", true, true, "", sql);
        }

        private void FillCityList(Guid provinceId)
        {
            var sql = String.Format("ProvinceId = '{0}'", provinceId.ToString());

            CityEx.LoadCombo(ref cboCity, "CityName", true, true, "", sql);
        }
        #endregion

        private void LoadAddress(Guid addressTypeId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "MemberId = '" + this.MemberId.ToString() + "' AND AddressTypeId = '" + addressTypeId.ToString() + "'";
                var oAddress = ctx.MemberAddress.Where(x => x.MemberId == this.MemberId && x.AddressTypeId == addressTypeId).AsNoTracking().FirstOrDefault();
                if (oAddress != null)
                {
                    txtAddress.Text = oAddress.Address;
                    txtPostalCode.Text = oAddress.PostalCode;
                    cboCountry.SelectedValue = oAddress.CountryId.HasValue ? oAddress.CountryId : Guid.Empty;
                    cboProvince.SelectedValue = oAddress.ProvinceId.HasValue ? oAddress.ProvinceId : Guid.Empty;
                    cboCity.SelectedValue = oAddress.CityId.HasValue ? oAddress.CityId : Guid.Empty;
                    txtDistrict.Text = oAddress.District;

                    txtPhoneTag1.Text = oAddress.PhoneTag1Value;
                    txtPhoneTag2.Text = oAddress.PhoneTag2Value;
                    txtPhoneTag3.Text = oAddress.PhoneTag3Value;
                    txtPhoneTag4.Text = oAddress.PhoneTag4Value;
                    txtPhoneTag5.Text = LoadPaperNumberFromVIPData(addressTypeId);
                }
            }
        }

        private string LoadPaperNumberFromVIPData(Guid addressTypeId)
        {
            string result = string.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                //string key = "Address_Phone_Pager_" + addressTypeId.ToString("N");
                //string sql = "MemberId = '" + this.MemberId.ToString() + "'";

                var oVip = ctx.MemberVipData.Where(x => x.MemberId == this.MemberId).FirstOrDefault();

                if (oVip != null)
                {
                    result = MemberVipDataEx.GetAttribute(oVip.MetadataXml, "Address", "Phone", "Pager", addressTypeId.ToString("N"));
                }
            }

            return result;
        }

        private void cboAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAddressType.SelectedValue != null && _FormLoaded)
            {
                //if (Common.Utility.IsGUID(cboAddressType.SelectedValue.ToString()))
                //{
                //    LoadAddress(new Guid(cboAddressType.SelectedValue.ToString()));
                //}
                LoadAddress((Guid)cboAddressType.SelectedValue);
            }
        }

        private void cboCountry_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboCountry.SelectedValue != null && _FormLoaded)
            {
                FillProvinceList((Guid)cboCountry.SelectedValue);
            }
        }

        private void cboProvince_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboProvince.SelectedValue != null && _FormLoaded)
            {
                FillCityList((Guid)cboProvince.SelectedValue);
            }
        }
    }
}