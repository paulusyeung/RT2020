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
using RT2020.Controls;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_AddressInfo : UserControl
    {
        public MemberWizard_AddressInfo()
        {
            InitializeComponent();
            InitialPhoneTag();
            FillComboList();
        }

        private void InitialPhoneTag()
        {
            RT2020.Controls.PhoneTag oTag = new RT2020.Controls.PhoneTag(this);
            oTag.SetPhoneTag();
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }
        #endregion

        #region Fill Combo list
        private void FillComboList()
        {
            FillAddressList();
            FillCountryList();
            FillProvinceList(System.Guid.Empty);
            FillCityList(System.Guid.Empty);
        }

        private void FillAddressList()
        {
            //cboAddressType.DataSource = null;
            //cboAddressType.Items.Clear();

            string[] orderBy = new string[] { "AddressTypeName" };
            ModelEx.MemberAddressTypeEx.LoadCombo(ref cboAddressType, "AddressTypeName", true, false, "", "", orderBy);
            /**
            MemberAddressTypeCollection countryList = MemberAddressType.LoadCollection(orderBy, true);

            cboAddressType.DataSource = countryList;
            cboAddressType.DisplayMember = "AddressTypeName";
            cboAddressType.ValueMember = "AddressTypeId";
            */
        }

        private void FillCountryList()
        {
            ModelEx.CountryEx.LoadCombo(ref cboCountry, "CountryName", true);
        }

        private void FillProvinceList(System.Guid CountryId)
        {
            ModelEx.ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", false, true, "", String.Format("CountryId = '{0}'", CountryId.ToString()));
        }

        private void FillCityList(System.Guid ProvinceId)
        {
            ModelEx.CityEx.LoadCombo(ref cboCity, "CityName", false, true, "", String.Format("ProvinceId = '{0}'", ProvinceId.ToString()));
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
                    cboCountry.SelectedValue = oAddress.CountryId;
                    cboProvince.SelectedValue = oAddress.ProvinceId;
                    cboCity.SelectedValue = oAddress.CityId;
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
                    result = ModelEx.MemberVipDataEx.GetAttribute(oVip.MetadataXml, "Address", "Phone", "Pager", addressTypeId.ToString("N"));
                }
            }

            return result;
        }

        private void cboAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAddressType.SelectedValue != null)
            {
            if (Common.Utility.IsGUID(cboAddressType.SelectedValue.ToString()))
            {
                LoadAddress(new Guid(cboAddressType.SelectedValue.ToString()));
            }
            }
        }

        private void cboCountry_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboCountry.SelectedValue != null)
            {
                if (Common.Utility.IsGUID(cboCountry.SelectedValue.ToString()))
                {
                    FillProvinceList(new System.Guid(cboCountry.SelectedValue.ToString()));
                }
            }
        }

        private void cboProvince_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            if (cboProvince.SelectedValue != null)
            {
                if (Common.Utility.IsGUID(cboProvince.SelectedValue.ToString()))
                {
                    FillCityList(new System.Guid(cboProvince.SelectedValue.ToString()));
                }
            }
        }
    }
}