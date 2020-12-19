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

using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using RT2020.Helper;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class CityWizard : Form
    {
        private Guid _Filter_CountryId = Guid.Empty;
        private Guid _Filter_ProvinceId = Guid.Empty;

        public CityWizard()
        {
            InitializeComponent();
        }

        private void CityWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetListViewAns();

            SetCtrlEditable();
            SetFormToolBar();
            SetComboBox();
            BindCityList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("city.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colCityCode.Text = WestwindHelper.GetWord("city.code", "Model");
            colCityName.Text = WestwindHelper.GetWord("city.name", "Model");
            colCityNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colCityNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblCityCode.Text = WestwindHelper.GetWordWithColon("city.code", "Model");
            lblCityName.Text = WestwindHelper.GetWordWithColon("city.name", "Model");
            lblCityNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblCityNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblProvince.Text = WestwindHelper.GetWordWithColon("province", "Model");
        }

        private void SetAttributes()
        {
            lvCityList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentDept.TextAlign = HorizontalAlignment.Left;
            //colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCityCode.TextAlign = HorizontalAlignment.Left;
            colCityCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCityName.TextAlign = HorizontalAlignment.Left;
            colCityName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCityNameAlt1.TextAlign = HorizontalAlignment.Left;
            colCityNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCityNameAlt2.TextAlign = HorizontalAlignment.Left;
            colCityNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblCityNameAlt2.Visible = txtCityNameAlt2.Visible = false;
                    colCityNameAlt2.Visible = false;
                    // push parent dept. up
                    lblProvince.Location = new Point(lblProvince.Location.X, lblCityNameAlt1.Location.Y);
                    cboProvince.Location = new Point(cboProvince.Location.X, txtCityNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblCityNameAlt1.Visible = lblCityNameAlt2.Visible = txtCityNameAlt2.Visible = false;
                    colCityNameAlt1.Visible = colCityNameAlt2.Visible = false;
                    // push parent dept up
                    lblProvince.Location = new Point(lblProvince.Location.X, lblCityNameAlt1.Location.Y);
                    cboProvince.Location = new Point(cboProvince.Location.X, txtCityNameAlt1.Location.Y);
                    break;
            }
        }

        #endregion

        #region ToolBar
        private void SetListViewAns()
        {
            ansListView.MenuHandle = false;
            ansListView.DragHandle = false;
            ansListView.TextAlign = ToolBarTextAlign.Right;

            SetListViewAns_CountryFilter();
            //SetListViewAns_ProvinceFilter();
        }

        private void SetListViewAns_CountryFilter()
        {
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

            ToolBarButton cmdFilter_Country = new ToolBarButton("Country", WestwindHelper.GetWord("country", "Model"));
            cmdFilter_Country.Style = ToolBarButtonStyle.DropDownButton;
            cmdFilter_Country.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-filter.png"));
            cmdFilter_Country.DropDownMenu = ddlFilter_Country;

            cmdFilter_Country.MenuClick += new MenuEventHandler(cmdFilter_Country_MenuClick);
            #endregion

            ansListView.Buttons.Add(cmdFilter_Country);
            ansListView.Buttons.Add(sep);
        }

        private void SetListViewAns_ProvinceFilter()
        {
            ResetProvinceFilter();

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            #region cmdFilter_Province 下拉選單

            ContextMenu ddlFilter_Province = new ContextMenu();

            using (var ctx = new EF6.RT2020Entities())
            {
                #region 加第一隻，係 default = All
                ddlFilter_Province.MenuItems.Add
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
                //var list = ctx.Province.Select(x => x.CountryId).Distinct().ToList();
                //var listEx = ctx.Country.Where(x => list.Contains(x.CountryId)).OrderBy(x => x.CountryName).ToList();
                var list = ctx.Province.Where(x => x.CountryId == _Filter_CountryId).OrderBy(x => x.ProvinceName).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    ddlFilter_Province.MenuItems.Add(
                        new MenuItem()
                        {
                            Checked = false,
                            Tag = item.ProvinceId,
                            Text = LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt1 ?
                                item.ProvinceName_Chs : LanguageHelper.CurrentLanguageMode == LanguageHelper.LanguageMode.Alt2 ?
                                item.ProvinceName_Cht :
                                item.ProvinceName
                        }
                    );
                }
                #endregion
            }

            ToolBarButton cmdFilter_Province = new ToolBarButton("Province", WestwindHelper.GetWord("province", "Model"));
            cmdFilter_Province.Style = ToolBarButtonStyle.DropDownButton;
            cmdFilter_Province.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-filter.png"));
            cmdFilter_Province.DropDownMenu = ddlFilter_Province;

            cmdFilter_Province.MenuClick += new MenuEventHandler(cmdFilter_Province_MenuClick);
            #endregion

            ansListView.Buttons.Add(cmdFilter_Province);
        }

        private void ResetProvinceFilter()
        {
            if (ansListView.Buttons.Count > 1)
                ansListView.Buttons.Remove(ansListView.Buttons[ansListView.Buttons.Count - 1]);
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
                SetListViewAns_ProvinceFilter();
                BindCityList();
                SetComboBox();
            }
        }

        private void cmdFilter_Province_MenuClick(object sender, MenuItemEventArgs e)
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

                var provinceName = e.MenuItem.Text;
                var provinceId = (Guid)e.MenuItem.Tag;

                e.MenuItem.Checked = true;
                _Filter_ProvinceId = provinceId;

                // filter the list according to the filter selcted
                BindCityList();
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
                        if (IsValid())
                        {
                            Save();
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

        #region Set: cboProvince
        private void SetComboBox()
        {
            var sql = (_Filter_CountryId != Guid.Empty) ?
                String.Format("CountryId = '{0}'", _Filter_CountryId.ToString()) :
                "";
            ModelEx.ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", true, true, "", sql);

        }
        #endregion

        #region Binding
        private void BindCityList()
        {
            this.lvCityList.ListViewItemSorter = new ListViewItemSorter(lvCityList);
            this.lvCityList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = new List<EF6.City>();

                #region Priority: Province > Country > All
                if (_Filter_ProvinceId != Guid.Empty)
                {
                    list = ctx.City
                        .Where(x => x.ProvinceId == _Filter_ProvinceId)
                        .OrderBy(x => x.Province.ProvinceName).ThenBy(x => x.CityName).AsNoTracking().ToList();
                }
                else
                {
                    if (_Filter_CountryId != Guid.Empty)
                    {
                        list = ctx.City
                            .Where(x => x.Province.CountryId == _Filter_CountryId)
                            .OrderBy(x => x.Province.ProvinceName).ThenBy(x => x.CityName).AsNoTracking().ToList();
                    }
                    else
                    {
                        list = ctx.City.OrderBy(x => x.Province.ProvinceName).ThenBy(x => x.CityName).AsNoTracking().ToList();
                    }
                }
                #endregion

                foreach (var item in list)
                {
                    var oItem = this.lvCityList.Items.Add(item.CityId.ToString());
                    oItem.SubItems.Add(iCount.ToString());
                    oItem.SubItems.Add(item.CityCode);
                    oItem.SubItems.Add(item.CityName);
                    oItem.SubItems.Add(item.CityName_Chs);
                    oItem.SubItems.Add(item.CityName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region CityCode 唔可以吉
            errorProvider.SetError(txtCityCode, string.Empty);
            if (txtCityCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCityCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CityCode 係咪 in use
            errorProvider.SetError(txtCityCode, string.Empty);
            if (this.CityId == System.Guid.Empty && ModelEx.CityEx.IsCityCodeInUse(txtCityCode.Text.Trim()))
            {
                errorProvider.SetError(txtCityCode, "City Code in use");
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
                var city = ctx.City.Find(this.CityId);

                if (city == null)
                {
                    city = new EF6.City();
                    city.CityId = new Guid();

                    ctx.City.Add(city);
                    city.CityCode = txtCityCode.Text;
                }
                city.CityName = txtCityName.Text;
                city.CityName_Chs = txtCityNameAlt1.Text;
                city.CityName_Cht = txtCityNameAlt2.Text;
                city.ProvinceId = new Guid(cboProvince.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result; ;
        }

        private void Clear()
        {
            txtCityCode.Text = string.Empty;
            txtCityName.Text = string.Empty;
            txtCityNameAlt1.Text = string.Empty;
            txtCityNameAlt2.Text = string.Empty;

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
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var city = ctx.City.Find(this.CityId);
                    if (city != null)
                    {
                        ctx.City.Remove(city);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvCityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCityList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvCityList.SelectedItem.Text, out id))
                {
                    this.CityId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var city = ctx.City.Find(this.CityId);
                        if (city != null)
                        {
                            txtCityCode.Text = city.CityCode;
                            txtCityName.Text = city.CityName;
                            txtCityNameAlt1.Text = city.CityName_Chs;
                            txtCityNameAlt2.Text = city.CityName_Cht;
                            cboProvince.SelectedValue = city.ProvinceId;

                            SetCtrlEditable();
                            SetFormToolBar();
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

                BindCityList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}