#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace RT2020.Settings
{
    public partial class CityWizard : Form
    {
        public CityWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            FillProvinceName();
            BindCityList();
        }

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", "Refresh");
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (CityId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "new":
                        Clear();
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (Save())
                        {
                            Clear();
                            BindCityList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindCityList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region City Code
        private void SetCtrlEditable()
        {
            txtCityCode.BackColor = (this.CityId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCityCode.ReadOnly = (this.CityId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCityCode, string.Empty);
        }
        #endregion

        #region Province Name
        private void FillProvinceName()
        {
            cboProvince.DataSource = null;
            cboProvince.Items.Clear();

            string[] orderBy = new string[] { "ProvinceName" };
            ProvinceCollection oProvinceList = Province.LoadCollection(orderBy, true);
            cboProvince.DataSource = oProvinceList;
            cboProvince.DisplayMember = "ProvinceName";
            cboProvince.ValueMember = "ProvinceId";
        }
        #endregion

        #region Binding
        private void BindCityList()
        {
            this.lvCityList.ListViewItemSorter = new ListViewItemSorter(lvCityList);
            this.lvCityList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CityId,  ROW_NUMBER() OVER (ORDER BY CityCode) AS rownum, ");
            sql.Append(" CityCode, CityName, CityName_Chs, CityName_Cht ");
            sql.Append(" FROM City ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvCityList.Items.Add(reader.GetGuid(0).ToString()); // CityId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // CityCode
                    objItem.SubItems.Add(reader.GetString(3)); // City Name
                    objItem.SubItems.Add(reader.GetString(4)); // City Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // City Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "CityCode = '" + txtCityCode.Text.Trim() + "'";
            CityCollection cityList = City.LoadCollection(sql);
            if (cityList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Save()
        {
            if (txtCityCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCityCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtCityCode, string.Empty);

                City oCity = City.Load(this.CityId);
                if (oCity == null)
                {
                    oCity = new City();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtCityCode, string.Format(Resources.Common.DuplicatedCode, "City Code"));
                        return false;
                    }
                    else
                    {
                        oCity.CityCode = txtCityCode.Text;
                        errorProvider.SetError(txtCityCode, string.Empty);
                    }
                }
                oCity.CityName = txtCityName.Text;
                oCity.CityName_Chs = txtCityNameChs.Text;
                oCity.CityName_Cht = txtCityNameCht.Text;
                oCity.ProvinceId = new Guid(cboProvince.SelectedValue.ToString());

                oCity.Save();
                return true;
            }
        }

        private void Clear()
        {
            txtCityCode.Text = string.Empty;
            txtCityName.Text = string.Empty;
            txtCityNameChs.Text = string.Empty;
            txtCityNameCht.Text = string.Empty;

            this.CityId = System.Guid.Empty;
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid CityId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }
        #endregion

        private void Delete()
        {
            City oCity = City.Load(this.CityId);
            if (oCity != null)
            {
                try
                {
                    oCity.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvCityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCityList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvCityList.SelectedItem.Text))
                {
                    City oCity = City.Load(new System.Guid(lvCityList.SelectedItem.Text));
                    if (oCity != null)
                    {
                        txtCityCode.Text = oCity.CityCode;
                        txtCityName.Text = oCity.CityName;
                        txtCityNameChs.Text = oCity.CityName_Chs;
                        txtCityNameCht.Text = oCity.CityName_Cht;
                        cboProvince.SelectedValue = oCity.ProvinceId;

                        this.CityId = oCity.CityId;

                        SetCtrlEditable();
                        SetToolBar();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindCityList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}