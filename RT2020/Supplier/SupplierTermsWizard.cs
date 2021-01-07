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
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierTermsWizard : Form
    {
        #region Properties
        private Guid _TermsId = System.Guid.Empty;
        public Guid SupplierTermsId
        {
            get { return _TermsId; }
            set { _TermsId = value; }
        }
        #endregion

        public SupplierTermsWizard()
        {
            InitializeComponent();
        }

        private void SupplierTermsWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentTermsList();
            BindSupplierTermsList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("supplierAddressType.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colTermsCode.Text = WestwindHelper.GetWord("supplierAddressType.code", "Model");
            colParent.Text = WestwindHelper.GetWord("supplierAddressType.priority", "Model");
            colTermsName.Text = WestwindHelper.GetWord("supplierAddressType.name", "Model");
            colTermsNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colTermsNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblTermsCode.Text = WestwindHelper.GetWordWithColon("supplierAddressType.code", "Model");
            lblTermsName.Text = WestwindHelper.GetWordWithColon("supplierAddressType.name", "Model");
            lblTermsNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblTermsNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentTerms.Text = WestwindHelper.GetWordWithColon("supplierAddressType.priority", "Model");
        }

        private void SetAttributes()
        {
            lvTermsList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colTermsCode.TextAlign = HorizontalAlignment.Left;
            colTermsCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colParent.TextAlign = HorizontalAlignment.Center;
            colParent.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTermsName.TextAlign = HorizontalAlignment.Left;
            colTermsName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTermsNameAlt1.TextAlign = HorizontalAlignment.Left;
            colTermsNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTermsNameAlt2.TextAlign = HorizontalAlignment.Left;
            colTermsNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblTermsNameAlt2.Visible = txtTermsNameAlt2.Visible = false;
                    colTermsNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentTerms.Location = new Point(lblParentTerms.Location.X, lblTermsNameAlt2.Location.Y);
                    cboParentTerms.Location = new Point(cboParentTerms.Location.X, txtTermsNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblTermsNameAlt1.Visible = lblTermsNameAlt2.Visible = txtTermsNameAlt2.Visible = false;
                    colTermsNameAlt1.Visible = colTermsNameAlt2.Visible = false;
                    // push parent dept up
                    lblParentTerms.Location = new Point(lblParentTerms.Location.X, lblTermsNameAlt1.Location.Y);
                    cboParentTerms.Location = new Point(cboParentTerms.Location.X, txtTermsNameAlt1.Location.Y);
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

            if (_TermsId == Guid.Empty)
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
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindSupplierTermsList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        Clear();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SupplierTerms Code
        private void SetCtrlEditable()
        {
            txtTermsCode.BackColor = (_TermsId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtTermsCode.ReadOnly = (_TermsId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtTermsCode, string.Empty);
        }

        private void Clear()
        {
            txtTermsCode.Text = txtTermsName.Text = txtTermsNameAlt1.Text = txtTermsNameAlt2.Text = string.Empty;
            cboParentTerms.SelectedIndex = 0;

            _TermsId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentTermsList()
        {
            string sql = "TermsId NOT IN ('" + _TermsId.ToString() + "')";
            string[] orderBy = new string[] { "TermsCode" };
            ModelEx.SupplierTermsEx.LoadCombo(ref cboParentTerms, "TermsCode", true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindSupplierTermsList()
        {
            this.lvTermsList.ListViewItemSorter = new ListViewItemSorter(lvTermsList);
            this.lvTermsList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.SupplierTerms.OrderBy(x => x.TermsCode).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    var parent = ctx.SupplierTerms.Find(item.ParentTerms);
                    var parentName = parent == null ?
                        "" : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage2.Key ?
                        parent.TermsName_Cht : CookieHelper.CurrentLocaleId == LanguageHelper.AlternateLanguage1.Key ?
                        parent.TermsName_Chs :
                        parent.TermsName;
                    ListViewItem objItem = this.lvTermsList.Items.Add(item.TermsId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.TermsCode);
                    objItem.SubItems.Add(parentName);
                    objItem.SubItems.Add(item.TermsName);
                    objItem.SubItems.Add(item.TermsName_Chs);
                    objItem.SubItems.Add(item.TermsName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Terms Code 唔可以吉
            errorProvider.SetError(txtTermsCode, string.Empty);
            if (txtTermsCode.Text.Length == 0)
            {
                errorProvider.SetError(txtTermsCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Terms Code 係咪 in use
            errorProvider.SetError(txtTermsCode, string.Empty);
            if (_TermsId == Guid.Empty)
            {
                if (ModelEx.SupplierTermsEx.IsTermsCodeInUse(txtTermsCode.Text.Trim()))
                {
                    errorProvider.SetError(txtTermsCode, "Terms Code in use");
                    errorProvider.SetIconAlignment(txtTermsCode, ErrorIconAlignment.TopLeft);
                    return false;
                }
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierTerms.Find(_TermsId);

                if (item == null)
                {
                    item = new EF6.SupplierTerms();
                    item.TermsId = new Guid();
                    item.TermsCode = txtTermsCode.Text;

                    ctx.SupplierTerms.Add(item);
                    _TermsId = item.TermsId;
                }
                item.TermsName = txtTermsName.Text;
                item.TermsName_Chs = txtTermsNameAlt1.Text;
                item.TermsName_Cht = txtTermsNameAlt2.Text;
                if ((Guid)cboParentTerms.SelectedValue != Guid.Empty) item.ParentTerms = (Guid)cboParentTerms.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private bool Delete()
        {
            bool result = true;

            result = ModelEx.SupplierTermsEx.Delete(_TermsId);

            if (!result)
            {
                MessageBox.Show("Cannot delete...the record might be in use!", "Delete Warning");
            }

            return result;
        }

        private void lvSupplierTermsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTermsList.SelectedItem != null)
            {
                Guid id = Guid.Empty;

                if (Guid.TryParse(lvTermsList.SelectedItem.Text, out id))
                {
                    var oSupplierTerms = ModelEx.SupplierTermsEx.Get(id);
                    if (oSupplierTerms != null)
                    {
                        _TermsId = oSupplierTerms.TermsId;

                        FillParentTermsList();

                        txtTermsCode.Text = oSupplierTerms.TermsCode;
                        txtTermsName.Text = oSupplierTerms.TermsName;
                        txtTermsNameAlt1.Text = oSupplierTerms.TermsName_Chs;
                        txtTermsNameAlt2.Text = oSupplierTerms.TermsName_Cht;
                        cboParentTerms.SelectedValue = oSupplierTerms.ParentTerms.HasValue ? oSupplierTerms.ParentTerms : Guid.Empty;

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
                if (Delete())
                {
                    BindSupplierTermsList();
                    Clear();
                    SetCtrlEditable();
                }
                else
                {
                    MessageBox.Show("The item is being used! Cannot be deleted!", "Delete Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}