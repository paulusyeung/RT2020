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
    public partial class ProductAppendixWizardAio : Form
    {
        #region Properties
        private Guid _AppendixId = Guid.Empty;
        public Guid ProductAppendixId
        {
            get { return _AppendixId; }
            set { _AppendixId = value; }
        }

        private ProductHelper.Appendix _AppendixType = ProductHelper.Appendix.None;
        public ProductHelper.Appendix ProductAppendixType
        {
            get { return _AppendixType; }
            set { _AppendixType = value; }
        }
        #endregion

        public ProductAppendixWizardAio()
        {
            InitializeComponent();
        }

        private void ProductAppendixWizardAio_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            BindTagList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            #region this.Text
            switch (_AppendixType)
            {
                case ProductHelper.Appendix.Appendix1:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("appendix.setup", "Product"), WestwindHelper.GetWord("appendix.appendix1", "Product"));
                    break;
                case ProductHelper.Appendix.Appendix2:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("appendix.setup", "Product"), WestwindHelper.GetWord("appendix.appendix2", "Product"));
                    break;
                case ProductHelper.Appendix.Appendix3:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("appendix.setup", "Product"), WestwindHelper.GetWord("appendix.appendix3", "Product"));
                    break;
            }
            #endregion

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colCode.Text = WestwindHelper.GetWord("appendix.code", "Product");
            colInitial.Text = WestwindHelper.GetWord("appendix.initial", "Product");
            colName.Text = WestwindHelper.GetWord("appendix.name", "Product");
            colNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblCode.Text = WestwindHelper.GetWordWithColon("appendix.code", "Product");
            lblName.Text = WestwindHelper.GetWordWithColon("appendix.name", "Product");
            lblNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblInitial.Text = WestwindHelper.GetWordWithColon("appendix.initial", "Product");
        }

        private void SetAttributes()
        {
            lvTagList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colCode.TextAlign = HorizontalAlignment.Left;
            colCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colInitial.TextAlign = HorizontalAlignment.Left;
            colInitial.ContentAlign = ExtendedHorizontalAlignment.Center;
            colName.TextAlign = HorizontalAlignment.Left;
            colName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNameAlt1.TextAlign = HorizontalAlignment.Left;
            colNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colNameAlt2.TextAlign = HorizontalAlignment.Left;
            colNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblNameAlt2.Visible = txtNameAlt2.Visible = false;
                    colNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblNameAlt1.Visible = lblNameAlt2.Visible = txtNameAlt2.Visible = false;
                    colNameAlt1.Visible = colNameAlt2.Visible = false;
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

            if (_AppendixId == Guid.Empty)
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
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindTagList();
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

        #region SetCtrlEditable ClearError Clear
        private void SetCtrlEditable()
        {
            txtCode.BackColor = (_AppendixId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCode.ReadOnly = (_AppendixId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCode, string.Empty);
            errorProvider.SetError(txtInitial, string.Empty);
        }

        private void Clear()
        {
            txtCode.Text = txtName.Text = txtNameAlt1.Text = txtNameAlt2.Text = txtInitial.Text = string.Empty;

            _AppendixId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindTagList()
        {
            this.lvTagList.ListViewItemSorter = new Sorter();
            this.lvTagList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                switch (_AppendixType)
                {
                    case ProductHelper.Appendix.Appendix1:
                        #region ProductAppendix1
                        var Appendix1 = ctx.ProductAppendix1.Where(x => x.Retired == false).OrderBy(x => x.Appendix1Code).AsNoTracking().ToList();

                        foreach (var item in Appendix1)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Appendix1Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix1Code);
                            objItem.SubItems.Add(item.Appendix1Initial);
                            objItem.SubItems.Add(item.Appendix1Name);
                            objItem.SubItems.Add(item.Appendix1Name_Chs);
                            objItem.SubItems.Add(item.Appendix1Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix2:
                        #region ProductAppendix2
                        var Appendix2 = ctx.ProductAppendix2.Where(x => x.Retired == false).OrderBy(x => x.Appendix2Code).AsNoTracking().ToList();

                        foreach (var item in Appendix2)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Appendix2Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix2Code);
                            objItem.SubItems.Add(item.Appendix2Initial);
                            objItem.SubItems.Add(item.Appendix2Name);
                            objItem.SubItems.Add(item.Appendix2Name_Chs);
                            objItem.SubItems.Add(item.Appendix2Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix3:
                        #region ProductAppendix3
                        var Appendix3 = ctx.ProductAppendix3.Where(x => x.Retired == false).OrderBy(x => x.Appendix3Code).AsNoTracking().ToList();

                        foreach (var item in Appendix3)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Appendix3Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Appendix3Code);
                            objItem.SubItems.Add(item.Appendix3Initial);
                            objItem.SubItems.Add(item.Appendix3Name);
                            objItem.SubItems.Add(item.Appendix3Name_Chs);
                            objItem.SubItems.Add(item.Appendix3Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtCode, string.Empty);

            #region Class Code 唔可以吉
            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
                errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                result = false;
            }
            #endregion

            #region 新增，要 check Tag Code 係咪 in use
            if (_AppendixId == Guid.Empty)
            {
                switch (_AppendixType)
                {
                    case ProductHelper.Appendix.Appendix1:
                        #region ProductAppendix1
                        if (ProductAppendix1Ex.IsAppendixCodeInUse(txtCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
                    case ProductHelper.Appendix.Appendix2:
                        #region ProductAppendix2
                        if (ProductAppendix2Ex.IsAppendixCodeInUse(txtCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix3:
                        #region ProductAppendix3
                        if (ProductAppendix3Ex.IsAppendixCodeInUse(txtCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
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
                switch (_AppendixType)
                {
                    case ProductHelper.Appendix.Appendix1:
                        #region ProductAppendix1
                        var Appendix1 = ctx.ProductAppendix1.Find(_AppendixId);

                        if (Appendix1 == null)
                        {
                            Appendix1 = new EF6.ProductAppendix1();
                            Appendix1.Appendix1Id = Guid.NewGuid();
                            Appendix1.Appendix1Code = txtCode.Text;
                            Appendix1.CreatedOn = DateTime.Now;
                            Appendix1.CreatedBy = ConfigHelper.CurrentUserId;
                            Appendix1.Retired = false;

                            ctx.ProductAppendix1.Add(Appendix1);
                        }
                        Appendix1.Appendix1Name = txtName.Text;
                        Appendix1.Appendix1Name_Chs = txtNameAlt1.Text;
                        Appendix1.Appendix1Name_Cht = txtNameAlt2.Text;
                        Appendix1.Appendix1Initial = txtInitial.Text;
                        Appendix1.ModifiedOn = DateTime.Now;
                        Appendix1.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                        #endregion
                    case ProductHelper.Appendix.Appendix2:
                        #region ProductAppendix2
                        var Appendix2 = ctx.ProductAppendix2.Find(_AppendixId);

                        if (Appendix2 == null)
                        {
                            Appendix2 = new EF6.ProductAppendix2();
                            Appendix2.Appendix2Id = Guid.NewGuid();
                            Appendix2.Appendix2Code = txtCode.Text;
                            Appendix2.CreatedOn = DateTime.Now;
                            Appendix2.CreatedBy = ConfigHelper.CurrentUserId;
                            Appendix2.Retired = false;

                            ctx.ProductAppendix2.Add(Appendix2);
                        }
                        Appendix2.Appendix2Name = txtName.Text;
                        Appendix2.Appendix2Name_Chs = txtNameAlt1.Text;
                        Appendix2.Appendix2Name_Cht = txtNameAlt2.Text;
                        Appendix2.Appendix2Initial = txtInitial.Text;
                        Appendix2.ModifiedOn = DateTime.Now;
                        Appendix2.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                    case ProductHelper.Appendix.Appendix3:
                        #region ProductAppendix3
                        var Appendix3 = ctx.ProductAppendix3.Find(_AppendixId);

                        if (Appendix3 == null)
                        {
                            Appendix3 = new EF6.ProductAppendix3();
                            Appendix3.Appendix3Id = Guid.NewGuid();
                            Appendix3.Appendix3Code = txtCode.Text;
                            Appendix3.CreatedOn = DateTime.Now;
                            Appendix3.CreatedBy = ConfigHelper.CurrentUserId;
                            Appendix3.Retired = false;

                            ctx.ProductAppendix3.Add(Appendix3);
                        }
                        Appendix3.Appendix3Name = txtName.Text;
                        Appendix3.Appendix3Name_Chs = txtNameAlt1.Text;
                        Appendix3.Appendix3Name_Cht = txtNameAlt2.Text;
                        Appendix3.Appendix3Initial = txtInitial.Text;
                        Appendix3.ModifiedOn = DateTime.Now;
                        Appendix3.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                }
            }

            return result;
        }
        #endregion

        private void Delete()
        {
            bool result = false;
            switch (_AppendixType)
            {
                case ProductHelper.Appendix.Appendix1:
                    result = ProductAppendix1Ex.Delete(_AppendixId);
                    break;
                case ProductHelper.Appendix.Appendix2:
                    result = ProductAppendix2Ex.Delete(_AppendixId);
                    break;
                case ProductHelper.Appendix.Appendix3:
                    result = ProductAppendix3Ex.Delete(_AppendixId);
                    break;
            }
            MessageBox.Show(result ? "Record Removed" : "Can't Delete Record...", "Delete Result");
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTagList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvTagList.SelectedItem.Text, out id))
                {
                    _AppendixId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        switch (_AppendixType)
                        {
                            case ProductHelper.Appendix.Appendix1:
                                #region ProductAppendix1
                                var Appendix1 = ctx.ProductAppendix1.Find(id);
                                if (Appendix1 != null)
                                {
                                    txtCode.Text = Appendix1.Appendix1Code;
                                    txtName.Text = Appendix1.Appendix1Name;
                                    txtNameAlt1.Text = Appendix1.Appendix1Name_Chs;
                                    txtNameAlt2.Text = Appendix1.Appendix1Name_Cht;
                                    txtInitial.Text = Appendix1.Appendix1Initial;
                                }
                                break;
                                #endregion
                            case ProductHelper.Appendix.Appendix2:
                                #region ProductAppendix2
                                var Appendix2 = ctx.ProductAppendix2.Find(id);
                                if (Appendix2 != null)
                                {
                                    txtCode.Text = Appendix2.Appendix2Code;
                                    txtName.Text = Appendix2.Appendix2Name;
                                    txtNameAlt1.Text = Appendix2.Appendix2Name_Chs;
                                    txtNameAlt2.Text = Appendix2.Appendix2Name_Cht;
                                    txtInitial.Text = Appendix2.Appendix2Initial;
                                }
                                break;
                            #endregion
                            case ProductHelper.Appendix.Appendix3:
                                #region ProductAppendix3
                                var Appendix3 = ctx.ProductAppendix3.Find(id);
                                if (Appendix3 != null)
                                {
                                    txtCode.Text = Appendix3.Appendix3Code;
                                    txtName.Text = Appendix3.Appendix3Name;
                                    txtNameAlt1.Text = Appendix3.Appendix3Name_Chs;
                                    txtNameAlt2.Text = Appendix3.Appendix3Name_Cht;
                                    txtInitial.Text = Appendix3.Appendix3Initial;
                                }
                                break;
                            #endregion
                        }
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

                BindTagList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}