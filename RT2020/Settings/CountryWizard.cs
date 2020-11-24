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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class CountryWizard : Form
    {
        public CountryWizard()
        {
            InitializeComponent();
            SetToolBar();
            BindCountryList();
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

            if (CountryId == System.Guid.Empty)
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
                            BindCountryList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindCountryList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Country Code
        private void SetCtrlEditable()
        {
            txtCountryCode.BackColor = (this.CountryId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCountryCode.ReadOnly = (this.CountryId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCountryCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindCountryList()
        {
            this.lvCountryList.ListViewItemSorter = new ListViewItemSorter(lvCountryList);
            this.lvCountryList.Items.Clear();

            int iCount = 1;
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Country.OrderBy(x => x.CountryName).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var oItem = this.lvCountryList.Items.Add(item.CountryId.ToString());
                    oItem.SubItems.Add(iCount.ToString());
                    oItem.SubItems.Add(item.CountryCode);
                    oItem.SubItems.Add(item.CountryName);
                    oItem.SubItems.Add(item.CountryName_Chs);
                    oItem.SubItems.Add(item.CountryName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "CountryCode = '" + txtCountryCode.Text.Trim() + "'";
            CountryCollection countryList = Country.LoadCollection(sql);
            if (countryList.Count > 0)
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
            if (txtCountryCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCountryCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtCountryCode, string.Empty);

                Country oCountry = Country.Load(this.CountryId);
                if (oCountry == null)
                {
                    oCountry = new Country();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtCountryCode, string.Format(Resources.Common.DuplicatedCode, "Country Code"));
                        return false;
                    }
                    else
                    {
                        oCountry.CountryCode = txtCountryCode.Text;
                        errorProvider.SetError(txtCountryCode, string.Empty);
                    }
                }
                oCountry.CountryName = txtCountryName.Text;
                oCountry.CountryName_Chs = txtCountryNameChs.Text;
                oCountry.CountryName_Cht = txtCountryNameCht.Text;

                oCountry.Save();
                return true;
            }
        }

        private void Clear()
        {
            txtCountryCode.Text = string.Empty;
            txtCountryName.Text = string.Empty;
            txtCountryNameChs.Text = string.Empty;
            txtCountryNameCht.Text = string.Empty;

            this.CountryId = System.Guid.Empty;
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid CountryId
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
            Country oCountry = Country.Load(this.CountryId);
            if (oCountry != null)
            {
                try
                {
                    oCountry.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvCountryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCountryList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvCountryList.SelectedItem.Text))
                {
                    Country oCountry = Country.Load(new System.Guid(lvCountryList.SelectedItem.Text));
                    if (oCountry != null)
                    {
                        txtCountryCode.Text = oCountry.CountryCode;
                        txtCountryName.Text = oCountry.CountryName;
                        txtCountryNameChs.Text = oCountry.CountryName_Chs;
                        txtCountryNameCht.Text = oCountry.CountryName_Cht;

                        this.CountryId = oCountry.CountryId;

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

                BindCountryList();
                Clear();
                SetCtrlEditable();
            }
        }

        private void lnkAddProvince_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProvinceWizard wizProvince = new ProvinceWizard();
            wizProvince.ShowDialog();
        }

        private void lnkAddCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CityWizard wizCity = new CityWizard();
            wizCity.ShowDialog();
        }
    }
}