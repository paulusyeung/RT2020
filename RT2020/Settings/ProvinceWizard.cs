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
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class ProvinceWizard : Form
    {
        private Guid _Filter_CountryId = Guid.Empty;

        public ProvinceWizard()
        {
            InitializeComponent();
        }

        private void ProvinceWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetListViewAns();
            SetFormToolBar();

            FillCountryName();
            BindProvinceList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colCountry.Text = WestwindHelper.GetWord("country", "Model");
            colProvinceCode.Text = WestwindHelper.GetWord("province.code", "Model");
            colProvinceName.Text = WestwindHelper.GetWord("province.name", "Model");
            colProvinceNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colProvinceNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblProvinceCode.Text = WestwindHelper.GetWordWithColon("province.code", "Model");
            lblProvinceName.Text = WestwindHelper.GetWordWithColon("province.name", "Model");
            lblProvinceNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblProvinceNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblCountry.Text = WestwindHelper.GetWordWithColon("country", "Model");
        }

        private void SetAttributes()
        {
            int toolbarHeight = 18;

            tbrListView.Height = tbWizardAction.Height = toolbarHeight;
            lvProvinceList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colCountry.TextAlign = HorizontalAlignment.Left;
            colCountry.ContentAlign = ExtendedHorizontalAlignment.Center;
            colProvinceCode.TextAlign = HorizontalAlignment.Left;
            colProvinceCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colProvinceName.TextAlign = HorizontalAlignment.Left;
            colProvinceName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colProvinceNameAlt1.TextAlign = HorizontalAlignment.Left;
            colProvinceNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colProvinceNameAlt2.TextAlign = HorizontalAlignment.Left;
            colProvinceNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblProvinceNameAlt2.Visible = txtProvinceNameAlt2.Visible = false;
                    colProvinceNameAlt2.Visible = false;
                    // push parent dept. up
                    lblCountry.Location = new Point(lblCountry.Location.X, lblProvinceNameAlt2.Location.Y);
                    cboCountry.Location = new Point(cboCountry.Location.X, txtProvinceNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblProvinceNameAlt1.Visible = lblProvinceNameAlt2.Visible = txtProvinceNameAlt1.Visible = txtProvinceNameAlt2.Visible = false;
                    colProvinceNameAlt1.Visible = colProvinceNameAlt2.Visible = false;
                    // push parent dept up
                    lblCountry.Location = new Point(lblCountry.Location.X, lblProvinceNameAlt1.Location.Y);
                    cboCountry.Location = new Point(cboCountry.Location.X, txtProvinceNameAlt1.Location.Y);
                    break;
            }
        }

        #endregion

        #region ToolBar
        private void SetListViewAns()
        {
            tbrListView.MenuHandle = false;
            tbrListView.DragHandle = false;
            tbrListView.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            #region cmdFilter_Country 下拉選單

            ContextMenu ddlFilter_Country = new ContextMenu();

            using (var ctx = new EF6.RT2020Entities())
            {
                #region 加第一隻，係 default = All
                ddlFilter_Country.MenuItems.Add
                    (
                        new MenuItem()
                        {
                            Checked = true,
                            Index = 0,
                            Tag = Guid.Empty,
                            Text = WestwindHelper.GetWord("glossary.all", "General")
                        }
                    );
                #endregion

                #region 加：有 Province 嘅 Countries
                var list = ctx.Province.Select(x => x.CountryId).Distinct().ToList();
                var listEx = ctx.Country.Where(x => list.Contains(x.CountryId)).OrderBy(x => x.CountryName).ToList();

                foreach (var item in listEx)
                {
                    ddlFilter_Country.MenuItems.Add(
                        new MenuItem()
                        {
                            Checked = false,
                            Tag = item.CountryId,
                            Text = LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt1 ?
                                item.CountryName_Chs : LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt2 ?
                                item.CountryName_Cht :
                                item.CountryName
                        }
                    );
                }
                #endregion
            }

            ToolBarButton cmdFilter_Country = new ToolBarButton("Filter", WestwindHelper.GetWord("listview.filter", "Tools"));
            cmdFilter_Country.Style = ToolBarButtonStyle.DropDownButton;
            cmdFilter_Country.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-filter.png"));
            cmdFilter_Country.DropDownMenu = ddlFilter_Country;

            cmdFilter_Country.MenuClick += new MenuEventHandler(cmdFilter_Country_MenuClick);
            #endregion

            tbrListView.Buttons.Add(cmdFilter_Country);
        }

        private void cmdFilter_Country_MenuClick(object sender, MenuItemEventArgs e)
        {
            if (e.MenuItem.Tag != null)
            {
                #region reset Check marks
                var but = (ToolBarButton)sender;
                foreach (MenuItem item in but.DropDownMenu.MenuItems)
                {
                    item.Checked = false;
                }
                #endregion

                var countryName = e.MenuItem.Text;
                var countryId = (Guid)e.MenuItem.Tag;

                e.MenuItem.Checked = true;
                _Filter_CountryId = countryId;

                // filter the list according to the filter selcted
                BindProvinceList();
            }
        }

        private void SetFormToolBar()
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
                        if (IsValid())
                        {
                            Save();
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
            using (var ctx = new EF6.RT2020Entities())
            {
                List<EF6.Province> list = new List<EF6.Province>();
                list = _Filter_CountryId == Guid.Empty ?
                    ctx.Province.OrderBy(x => x.Country.CountryName).ThenBy(x => x.ProvinceName).AsNoTracking().ToList() :
                    ctx.Province.Where(x => x.CountryId == _Filter_CountryId).OrderBy(x => x.Country.CountryName).ThenBy(x => x.ProvinceName).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    ListViewItem oItem = this.lvProvinceList.Items.Add(item.ProvinceId.ToString());
                    oItem.SubItems.Add(iCount.ToString());
                    oItem.SubItems.Add(
                        LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt1 ?
                        item.Country.CountryName_Chs : LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt2 ?
                        item.Country.CountryName_Cht :
                        item.Country.CountryName);
                    oItem.SubItems.Add(item.ProvinceCode);
                    oItem.SubItems.Add(item.ProvinceName);
                    oItem.SubItems.Add(item.ProvinceName_Chs);
                    oItem.SubItems.Add(item.ProvinceName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Country Name
        private void FillCountryName()
        {
            ModelEx.CountryEx.LoadCombo(ref cboCountry, "CountryName", true);
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = false;

            #region ProvinceCode 唔可以吉
            errorProvider.SetError(txtProvinceCode, string.Empty);
            if (txtProvinceCode.Text.Length == 0)
            {
                errorProvider.SetError(txtProvinceCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check ProvinceCode 係咪 in use
            errorProvider.SetError(txtProvinceCode, string.Empty);
            if (this.ProvinceId == System.Guid.Empty && ModelEx.ProvinceEx.IsProvinceCodeInUse(txtProvinceCode.Text.Trim()))
            {
                errorProvider.SetError(txtProvinceCode, "Province Code in use");
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
                var province = ctx.Province.Find(this.ProvinceId);

                if (province == null)
                {
                    province = new EF6.Province();
                    province.ProvinceId = new Guid();

                    ctx.Province.Add(province);
                    province.ProvinceCode = txtProvinceCode.Text;
                }
                province.ProvinceName = txtProvinceName.Text;
                province.ProvinceName_Chs = txtProvinceNameAlt1.Text;
                province.ProvinceName_Cht = txtProvinceNameAlt2.Text;
                province.ProvinceId = new Guid(cboCountry.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var province = ctx.Province.Find(this.ProvinceId);
                    if (province != null)
                    {
                        ctx.Province.Remove(province);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvProvinceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProvinceList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvProvinceList.SelectedItem.Text))
                {
                    var id = Guid.NewGuid();
                    if (Guid.TryParse(lvProvinceList.SelectedItem.Text, out id))
                    {
                        this.ProvinceId = id;
                        using (var ctx = new EF6.RT2020Entities())
                        {
                            var province = ctx.Province.Find(this.ProvinceId);
                            if (province != null)
                            {
                                txtProvinceCode.Text = province.ProvinceCode;
                                txtProvinceName.Text = province.ProvinceName;
                                txtProvinceNameAlt1.Text = province.ProvinceName_Chs;
                                txtProvinceNameAlt2.Text = province.ProvinceName_Cht;
                                cboCountry.SelectedValue = province.CountryId;

                                SetCtrlEditable();
                                SetFormToolBar();
                            }
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

                BindProvinceList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}