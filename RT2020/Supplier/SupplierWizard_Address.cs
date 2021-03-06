#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Controls;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_Address : UserControl
    {
        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _SupplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get { return _SupplierId; }
            set { _SupplierId = value; }
        }
        #endregion

        public SupplierWizard_Address()
        {
            InitializeComponent();
        }

        private void SupplierWizard_Address_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetPhoneTags();

            FillComboList();
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblAddressType.Text = WestwindHelper.GetWordWithColon("supplierAddressType", "Model");

            lblAddress.Text = WestwindHelper.GetWordWithColon("supplier.address", "Model");
            lblPostalCode.Text = WestwindHelper.GetWordWithColon("supplier.address.postalCode", "Model");
            lblCountry.Text = WestwindHelper.GetWordWithColon("country", "Model");
            lblProvince.Text = WestwindHelper.GetWordWithColon("province", "Model");
            lblCity.Text = WestwindHelper.GetWordWithColon("city", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable address type label
            //lblAddressType.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblAddressType.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblAddressType.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SupplierAddressTypeWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillAddressList();
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

            #region 設定 clickable smart tag 9 label
            lblPhoneTag1.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag1.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag1.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 6 label
            lblPhoneTag3.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag3.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag3.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 3 label
            //lblPhoneTag3.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag2.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag2.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 4 label
            //lblPhoneTag4.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag4.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag4.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetPhoneTags()
        {
            var oTag = new PhoneTagHelper(this, "SUP");
            oTag.SetPhoneTag();
        }
        #endregion

        #region Fill Combo list
        private void FillComboList()
        {
            FillAddressList();
            FillCountryList();
            //2014.01.04 paulus: 屬於 cascade combobox 既然係吉嘅就無謂 fill，浪費時間
            //FillProvinceList(System.Guid.Empty);
            //FillCityList(System.Guid.Empty);
        }

        private void FillAddressList()
        {
            var orderBy = new string[] { "Priority" };
            ModelEx.SupplierAddressTypeEx.LoadCombo(ref cboAddressType, "AddressTypeName", true, false, "", "", orderBy);
        }

        private void FillCountryList()
        {
            var fields = new string[] { "CountryCode", "CountryName" };
            var pattern = "{0} - {1}";
            var orderby = new string[] { "CountryCode" };
            ModelEx.CountryEx.LoadCombo(ref cboCountry, fields, pattern, true, true, "", "", orderby);
        }

        private void FillProvinceList(Guid countryId)
        {
            var sql = string.Format("CountryId = '{0}'", countryId.ToString());

            ModelEx.ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", true, true, "", sql);
        }

        private void FillCityList(Guid provinceId)
        {
            var sql = String.Format("ProvinceId = '{0}'", provinceId.ToString());

            ModelEx.CityEx.LoadCombo(ref cboCity, "CityName", true, true, "", sql);
        }
        #endregion

        #region LoadAddressData
        public void LoadAddressData()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    if (_SupplierId != Guid.Empty)
                    {
                        LoadAddress();
                    }
                    break;
            }
        }

        private void LoadAddress()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == _SupplierId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    txtAddress.Text = item.Address;
                    txtPostalCode.Text = item.PostalCode;
                    cboAddressType.SelectedValue = item.AddressTypeId;
                    cboCountry.SelectedValue = item.CountryId.HasValue ? item.CountryId : Guid.Empty;
                    cboProvince.SelectedValue = item.ProvinceId.HasValue ? item.ProvinceId : Guid.Empty;
                    cboCity.SelectedValue = item.CityId.HasValue ? item.CityId : Guid.Empty;
                    txtPhoneTag1.Text = item.PhoneTag1Value;
                    txtPhoneTag2.Text = item.PhoneTag2Value;
                    txtPhoneTag3.Text = item.PhoneTag3Value;
                    txtPhoneTag4.Text = item.PhoneTag4Value;
                }
            }
        }

        private void LoadAddress(Guid addressTypeId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == _SupplierId && x.AddressTypeId == addressTypeId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    txtAddress.Text = item.Address;
                    txtPostalCode.Text = item.PostalCode;
                    cboAddressType.SelectedValue = item.AddressTypeId;
                    cboCountry.SelectedValue = item.CountryId.HasValue ? item.CountryId : Guid.Empty;
                    cboProvince.SelectedValue = item.ProvinceId.HasValue ? item.ProvinceId : Guid.Empty;
                    cboCity.SelectedValue = item.CityId.HasValue ? item.CityId : Guid.Empty;
                    txtPhoneTag1.Text = item.PhoneTag1Value;
                    txtPhoneTag2.Text = item.PhoneTag2Value;
                    txtPhoneTag3.Text = item.PhoneTag3Value;
                    txtPhoneTag4.Text = item.PhoneTag4Value;
                }
            }
        }

        public bool SaveAddressData()
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var typeId = (Guid)cboAddressType.SelectedValue;
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == this.SupplierId && x.AddressTypeId == typeId).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.SupplierAddress();
                    item.AddressId = Guid.NewGuid();
                    item.SupplierId = _SupplierId;
                    item.AddressTypeId = (Guid)cboAddressType.SelectedValue;

                    ctx.SupplierAddress.Add(item);
                }
                item.Address = txtAddress.Text;
                item.PostalCode = txtPostalCode.Text;
                if ((Guid)cboCountry.SelectedValue != Guid.Empty) item.CountryId = (Guid)cboCountry.SelectedValue;
                if ((Guid)cboProvince.SelectedValue != Guid.Empty) item.ProvinceId = (Guid)cboProvince.SelectedValue;
                if ((Guid)cboCity.SelectedValue != Guid.Empty) item.CityId = (Guid)cboCity.SelectedValue;
                item.PhoneTag1Value = txtPhoneTag1.Text.Trim();
                item.PhoneTag2Value = txtPhoneTag2.Text.Trim();
                item.PhoneTag3Value = txtPhoneTag3.Text.Trim();
                item.PhoneTag4Value = txtPhoneTag4.Text.Trim();

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private void cboCountry_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboCountry.SelectedValue != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(cboCountry.SelectedValue.ToString(), out id))
                {
                    FillProvinceList(id);
                }
            }
        }

        private void cboProvince_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboProvince.SelectedValue != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(cboProvince.SelectedValue.ToString(), out id))
                {
                    FillCityList(id);
                }
            }
        }

        private void cboAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAddressType.SelectedValue != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(cboAddressType.SelectedValue.ToString(), out id))
                {
                    LoadAddress(id);
                }
            }
        }
    }
}