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
using RT2020.Helper;

#endregion

namespace RT2020.Settings
{
    public partial class CityWizard : Form
    {
        public CityWizard()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            FillProvinceName();
            BindCityList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            colLN.Text = WestwindHelper.GetWord("tools.listview.line", "Tools");

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

        private bool IsValid()
        {
            bool result = false;

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

                BindCityList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}