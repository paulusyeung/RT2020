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
    public partial class ProvinceWizard : Form
    {
        public ProvinceWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillCountryName();
            BindProvinceList();
            SetCtrlEditable();
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

            if (ProvinceId == System.Guid.Empty)
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
                            BindProvinceList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindProvinceList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Province Code
        private void SetCtrlEditable()
        {
            txtProvinceCode.BackColor = (this.ProvinceId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtProvinceCode.ReadOnly = (this.ProvinceId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtProvinceCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindProvinceList()
        {
            this.lvProvinceList.ListViewItemSorter = new ListViewItemSorter(lvProvinceList);
            this.lvProvinceList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProvinceId,  ROW_NUMBER() OVER (ORDER BY ProvinceCode) AS rownum, ");
            sql.Append(" ProvinceCode, ProvinceName, ProvinceName_Chs, ProvinceName_Cht ");
            sql.Append(" FROM Province ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvProvinceList.Items.Add(reader.GetGuid(0).ToString()); // ProvinceId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // ProvinceCode
                    objItem.SubItems.Add(reader.GetString(3)); // Province Name
                    objItem.SubItems.Add(reader.GetString(4)); // Province Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // Province Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Country Name
        private void FillCountryName()
        {
            cboCountry.DataSource = null;
            cboCountry.Items.Clear();

            string[] orderBy = new string[] { "CountryName" };
            CountryCollection oCountryList = Country.LoadCollection(orderBy, true);
            cboCountry.DataSource = oCountryList;
            cboCountry.DisplayMember = "CountryName";
            cboCountry.ValueMember = "CountryId";
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "ProvinceCode = '" + txtProvinceCode.Text.Trim() + "'";
            ProvinceCollection provinceList = Province.LoadCollection(sql);
            if (provinceList.Count > 0)
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
            if (txtProvinceCode.Text.Length == 0)
            {
                errorProvider.SetError(txtProvinceCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtProvinceCode, string.Empty);

                Province oProvince = Province.Load(this.ProvinceId);
                if (oProvince == null)
                {
                    oProvince = new Province();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtProvinceCode, string.Format(Resources.Common.DuplicatedCode, "Province Code"));
                        return false;
                    }
                    else
                    {
                        oProvince.ProvinceCode = txtProvinceCode.Text;
                        errorProvider.SetError(txtProvinceCode, string.Empty);
                    }
                }
                oProvince.ProvinceName = txtProvinceName.Text;
                oProvince.ProvinceName_Chs = txtProvinceNameChs.Text;
                oProvince.ProvinceName_Cht = txtProvinceNameCht.Text;
                oProvince.CountryId = new Guid(cboCountry.SelectedValue.ToString());

                oProvince.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            ProvinceWizard wizProvince = new ProvinceWizard();
            wizProvince.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid ProvinceId
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
            Province oProvince = Province.Load(this.ProvinceId);
            if (oProvince != null)
            {
                try
                {
                    oProvince.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvProvinceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProvinceList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvProvinceList.SelectedItem.Text))
                {
                    Province oProvince = Province.Load(new System.Guid(lvProvinceList.SelectedItem.Text));
                    if (oProvince != null)
                    {
                        txtProvinceCode.Text = oProvince.ProvinceCode;
                        txtProvinceName.Text = oProvince.ProvinceName;
                        txtProvinceNameChs.Text = oProvince.ProvinceName_Chs;
                        txtProvinceNameCht.Text = oProvince.ProvinceName_Cht;
                        cboCountry.SelectedValue = oProvince.CountryId;

                        this.ProvinceId = oProvince.ProvinceId;

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

                BindProvinceList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}