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
    public partial class SupplierWizard_Personal : UserControl
    {
        public SupplierWizard_Personal()
        {
            InitializeComponent();
            InitialSmartTags();
            FillComboList();
        }

        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };

            var smartTagList = ModelEx.SmartTag4SupplierEx.GetListOrderBy(orderBy, true);

            SmartTagHelper oTag = new SmartTagHelper(this);
            oTag.SupplierSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        #region Properties
        private Guid supplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
            }
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
            ModelEx.SupplierAddressTypeEx.LoadCombo(ref cboAddressType, "AddressTypeName", false);
        }

        private void FillCountryList()
        {
            ModelEx.CountryEx.LoadCombo(ref cboCountry, "CountryName", true);
        }

        private void FillProvinceList(System.Guid CountryId)
        {
            cboProvince.DataSource = null;
            cboProvince.Items.Clear();

            string sql = " CountryId = '" + CountryId.ToString() + "'";
            ModelEx.ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", false, true, string.Empty, sql);
            cboProvince.SelectedIndex = 0;

            cboCity.DataSource = null;
            cboCity.Items.Clear();
        }

        private void FillCityList(System.Guid ProvinceId)
        {
            cboCity.DataSource = null;
            cboCity.Items.Clear();

            string sql = " ProvinceId = '" + ProvinceId.ToString() + "'";
            // 2020.11.15 paulus: 用 EF6 代替
            //City.LoadCombo(ref cboCity, "CityName", false, true, String.Empty, sql);
            ModelEx.CityEx.LoadCombo(ref cboCity, "CityName", false, true, string.Empty, sql);
            cboCity.SelectedIndex = 0;
        }
        #endregion

        private void LoadAddress(Guid addressTypeId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == this.SupplierId && x.AddressTypeId == addressTypeId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    txtAddress.Text = item.Address;
                    txtPostalCode.Text = item.PostalCode;
                    cboCountry.SelectedValue = item.CountryId;
                    cboProvince.SelectedValue = item.ProvinceId;
                    cboCity.SelectedValue = item.CityId;
                }
            }
        }

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