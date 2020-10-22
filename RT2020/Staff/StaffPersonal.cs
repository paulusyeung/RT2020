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
#endregion

namespace RT2020.Staff
{
    public partial class StaffPersonal : UserControl
    {
        public StaffPersonal()
        {
            InitializeComponent();
            InitialSmartTags();
            FillComo();
            txtSalary.Text = "0.00";
        }

        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            SmartTag4StaffCollection smartTagList = SmartTag4Staff.LoadCollection(orderBy, true);

            SmartTag oTag = new SmartTag(this.gbPersonal);
            oTag.StaffSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        #region Properties
        private Guid staffId = System.Guid.Empty;
        public Guid StaffId
        {
            get
            {
                return staffId;
            }
            set
            {
                staffId = value;
            }
        }
        #endregion

        #region FillComo
        private void FillComo()
        {
            FillCountry();
        }

        private void FillCountry()
        {
            cmbCountry.DataSource = null;
            cmbCountry.Items.Clear();

            DAL.Country.LoadCombo(ref cmbCountry, "CountryName", false, true, String.Empty, String.Empty);
            cmbCountry.SelectedIndex = 0;

            cmbProvince.DataSource = null;
            cmbProvince.Items.Clear();
            cmbCity.DataSource = null;
            cmbCity.Items.Clear();
        }

        private void FillProvince(System.Guid CountryId)
        {
            cmbProvince.DataSource = null;
            cmbProvince.Items.Clear();

            string sql = " CountryId = '" + CountryId.ToString() + "'";
            DAL.Province.LoadCombo(ref cmbProvince, "ProvinceName", false, true, String.Empty, sql);
            cmbProvince.SelectedIndex = 0;

            cmbCity.DataSource = null;
            cmbCity.Items.Clear();
        }

        private void FillCity(System.Guid ProvinceId)
        {
            cmbCity.DataSource = null;
            cmbCity.Items.Clear();

            string sql = " ProvinceId = '" + ProvinceId.ToString() + "'";
            DAL.City.LoadCombo(ref cmbCity, "CityName", false, true, String.Empty, sql);
            cmbCity.SelectedIndex = 0;
        }
        #endregion

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedValue != null)
            {
                if (Common.Utility.IsGUID(cmbCountry.SelectedValue.ToString()))
                {
                    FillProvince(new System.Guid(cmbCountry.SelectedValue.ToString()));
                }
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvince.SelectedValue != null)
            {
                if (Common.Utility.IsGUID(cmbProvince.SelectedValue.ToString()))
                {
                    FillCity(new System.Guid(cmbProvince.SelectedValue.ToString()));
                }
            }
        }

        private void btnFindHKID_Click(object sender, EventArgs e)
        {
            FindHKID findHKID = new FindHKID();
            findHKID.Closed += new EventHandler(findHKID_Closed);
            findHKID.ShowDialog(); 
        }

        void findHKID_Closed(object sender, EventArgs e)
        {
            FindHKID findHKID = sender as FindHKID;
            if (findHKID.IsCompleted)
            {
                txtSmartTag1.Text = findHKID.HKID;
            }
        }
    }
}