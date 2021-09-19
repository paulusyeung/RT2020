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
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Product
{
    public partial class ProductNatureWizard : Form
    {
        #region Properties
        private Guid _NatureId = System.Guid.Empty;
        public Guid ProductNatureId
        {
            get { return _NatureId; }
            set { _NatureId = value; }
        }
        #endregion

        public ProductNatureWizard()
        {
            InitializeComponent();
        }

        private void ProductNatureWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentNatureList();
            BindProductNatureList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("nature.setup", "Product");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colNatureCode.Text = WestwindHelper.GetWord("nature.code", "Product");
            colParent.Text = WestwindHelper.GetWord("nature.parent", "Product");
            colNatureName.Text = WestwindHelper.GetWord("nature.name", "Product");
            colNatureNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colNatureNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblNatureCode.Text = WestwindHelper.GetWordWithColon("nature.code", "Product");
            lblNatureName.Text = WestwindHelper.GetWordWithColon("nature.name", "Product");
            lblNatureNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNatureNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentNature.Text = WestwindHelper.GetWord("nature.parent", "Product");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colNatureCode.TextAlign = HorizontalAlignment.Left;
            colNatureCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colParent.TextAlign = HorizontalAlignment.Left;
            colParent.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureName.TextAlign = HorizontalAlignment.Left;
            colNatureName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureNameAlt1.TextAlign = HorizontalAlignment.Left;
            colNatureNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNatureNameAlt2.TextAlign = HorizontalAlignment.Left;
            colNatureNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblNatureNameAlt2.Visible = txtNatureNameAlt2.Visible = false;
                    colNatureNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblNatureNameAlt1.Visible = lblNatureNameAlt2.Visible = txtNatureNameAlt1.Visible = txtNatureNameAlt2.Visible = false;
                    colNatureNameAlt1.Visible = colNatureNameAlt2.Visible = false;
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

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

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

            if (_NatureId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
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
                            BindProductNatureList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindProductNatureList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region ProductNature Code
        private void SetCtrlEditable()
        {
            txtNatureCode.BackColor = (_NatureId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtNatureCode.ReadOnly = (_NatureId != System.Guid.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentNatureList()
        {
            var textFields = new string[] { "NatureCode", "NatureName" };
            var pattern = "{0} - {1}";
            string sql = "NatureId NOT IN ('" + _NatureId.ToString() + "')";
            string[] orderBy = new string[] { "NatureCode" };

            ProductNatureEx.LoadCombo(ref cboParentNature, textFields, pattern, true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindProductNatureList()
        {
            this.lvProductNatureList.ListViewItemSorter = new ListViewItemSorter(lvProductNatureList);
            this.lvProductNatureList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductNature.OrderBy(x => x.NatureCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var parent = ctx.ProductNature.Find(item.ParentNature);
                    var parentName = parent == null ? "" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                        parent.NatureName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                        parent.NatureName_Chs :
                        parent.NatureName;

                    var objItem = this.lvProductNatureList.Items.Add(item.NatureId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.NatureCode);
                    objItem.SubItems.Add(parentName);
                    objItem.SubItems.Add(item.NatureName);
                    objItem.SubItems.Add(item.NatureName_Chs);
                    objItem.SubItems.Add(item.NatureName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool IsValid()
        {
            bool result = true;

            #region Nature Code 唔可以吉
            errorProvider.SetError(txtNatureCode, string.Empty);
            if (txtNatureCode.Text.Length == 0)
            {
                errorProvider.SetError(txtNatureCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Nature Code 係咪 in use
            errorProvider.SetError(txtNatureCode, string.Empty);
            if (_NatureId == System.Guid.Empty && ProductNatureEx.IsNatureCodeInUse(txtNatureCode.Text.Trim()))
            {
                errorProvider.SetError(txtNatureCode, "Nature Code in use");
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
                var item = ctx.ProductNature.Find(_NatureId);

                if (item == null)
                {
                    item = new EF6.ProductNature();
                    item.NatureId = Guid.NewGuid();
                    item.NatureCode = txtNatureCode.Text;

                    ctx.ProductNature.Add(item);
                }
                item.NatureName = txtNatureName.Text;
                item.NatureName_Chs = txtNatureNameAlt1.Text;
                item.NatureName_Cht = txtNatureNameAlt2.Text;
                if ((Guid)cboParentNature.SelectedValue != Guid.Empty) item.ParentNature = (Guid)cboParentNature.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result; ;
        }

        private void Clear()
        {
            txtNatureCode.Text = txtNatureName.Text = txtNatureNameAlt1.Text = txtNatureNameAlt2.Text = string.Empty;

            _NatureId = Guid.Empty;
            
            FillParentNatureList();
            SetCtrlEditable();
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.ProductNature.Find(_NatureId);
                    if (item != null)
                    {
                        ctx.ProductNature.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }
        #endregion

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();
                Clear();
            }
        }

        private void lvProductNatureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductNatureList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvProductNatureList.SelectedItem.Text, out id))
                {
                    _NatureId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.ProductNature.Find(_NatureId);
                        if (item != null)
                        {
                            FillParentNatureList();

                            txtNatureCode.Text = item.NatureCode;
                            txtNatureName.Text = item.NatureName;
                            txtNatureNameAlt1.Text = item.NatureName_Chs;
                            txtNatureNameAlt2.Text = item.NatureName_Cht;
                            cboParentNature.SelectedValue = item.ParentNature.HasValue ? item.ParentNature : Guid.Empty;

                            SetCtrlEditable();
                        }
                    }
                }
            }
        }
    }
}