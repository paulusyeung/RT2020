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
using RT2020.Helper;

#endregion

namespace RT2020.Settings
{
    public partial class CountryWizard : Form
    {
        public CountryWizard()
        {
            InitializeComponent();
        }

        private void CountryWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            BindCountryList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colCountryCode.Text = WestwindHelper.GetWord("country.code", "Model");
            colCountryName.Text = WestwindHelper.GetWord("country.name", "Model");
            colCountryNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colCountryNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblCountryCode.Text = WestwindHelper.GetWordWithColon("country.code", "Model");
            lblCountryName.Text = WestwindHelper.GetWordWithColon("country.name", "Model");
            lblCountryNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblCountryNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lnkAddProvince.Text = WestwindHelper.GetWord("province", "Model");
            lnkAddCity.Text = WestwindHelper.GetWord("city", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colCountryCode.TextAlign = HorizontalAlignment.Left;
            colCountryCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCountryName.TextAlign = HorizontalAlignment.Left;
            colCountryName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCountryNameAlt1.TextAlign = HorizontalAlignment.Left;
            colCountryNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCountryNameAlt2.TextAlign = HorizontalAlignment.Left;
            colCountryNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblCountryNameAlt2.Visible = txtCountryNameAlt2.Visible = false;
                    colCountryNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblCountryNameAlt1.Visible = lblCountryNameAlt2.Visible = txtCountryNameAlt1.Visible = txtCountryNameAlt2.Visible = false;
                    colCountryNameAlt1.Visible = colCountryNameAlt2.Visible = false;
                    break;
            }
        }

        #endregion

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
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
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
                        if (IsValid())
                        {
                            Save();
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

        private bool IsValid()
        {
            bool result = false;

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtCountryCode, string.Empty);
            if (txtCountryCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCountryCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            errorProvider.SetError(txtCountryCode, string.Empty);
            if (this.CountryId == System.Guid.Empty && ModelEx.ProvinceEx.IsProvinceCodeInUse(txtCountryCode.Text.Trim()))
            {
                errorProvider.SetError(txtCountryCode, "Country Code in use");
                return false;
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var country = ctx.Country.Find(this.CountryId);

                if (country == null)
                {
                    country = new EF6.Country();
                    country.CountryId = new Guid();

                    ctx.Country.Add(country);
                    country.CountryCode = txtCountryCode.Text;
                }
                country.CountryName = txtCountryName.Text;
                country.CountryName_Chs = txtCountryNameAlt1.Text;
                country.CountryName_Cht = txtCountryNameAlt2.Text;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            txtCountryCode.Text = string.Empty;
            txtCountryName.Text = string.Empty;
            txtCountryNameAlt1.Text = string.Empty;
            txtCountryNameAlt2.Text = string.Empty;

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
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var country = ctx.Country.Find(this.CountryId);
                    if (country != null)
                    {
                        ctx.Country.Remove(country);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvCountryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCountryList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvCountryList.SelectedItem.Text, out id))
                {
                    this.CountryId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var country = ctx.Country.Find(this.CountryId);
                        if (country != null)
                        {
                            txtCountryCode.Text = country.CountryCode;
                            txtCountryName.Text = country.CountryName;
                            txtCountryNameAlt1.Text = country.CountryName_Chs;
                            txtCountryNameAlt2.Text = country.CountryName_Cht;

                            SetCtrlEditable();
                            SetToolBar();
                        }
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