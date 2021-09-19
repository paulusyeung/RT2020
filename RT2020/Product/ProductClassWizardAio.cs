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
    public partial class ProductClassWizardAio : Form
    {
        #region Properties
        private Guid _ClassId = Guid.Empty;
        public Guid ProductClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
        }

        private ProductHelper.Classes _ClassType = ProductHelper.Classes.None;
        public ProductHelper.Classes ProductClassType
        {
            get { return _ClassType; }
            set { _ClassType = value; }
        }
        #endregion

        public ProductClassWizardAio()
        {
            InitializeComponent();
        }

        private void ProductClassWizardAio_Load(object sender, EventArgs e)
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
            switch (_ClassType)
            {
                case ProductHelper.Classes.Class1:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class1", "Product"));
                    break;
                case ProductHelper.Classes.Class2:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class2", "Product"));
                    break;
                case ProductHelper.Classes.Class3:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class3", "Product"));
                    break;
                case ProductHelper.Classes.Class4:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class4", "Product"));
                    break;
                case ProductHelper.Classes.Class5:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class5", "Product"));
                    break;
                case ProductHelper.Classes.Class6:
                    this.Text = string.Format("{0} ({1})", WestwindHelper.GetWord("class.setup", "Product"), WestwindHelper.GetWord("class.class6", "Product"));
                    break;
            }
            #endregion

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colClassCode.Text = WestwindHelper.GetWord("class.code", "Product");
            colInitial.Text = WestwindHelper.GetWord("class.initial", "Product");
            colClassName.Text = WestwindHelper.GetWord("class.name", "Product");
            colClassNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colClassNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblClassCode.Text = WestwindHelper.GetWordWithColon("class.code", "Product");
            lblClassName.Text = WestwindHelper.GetWordWithColon("class.name", "Product");
            lblClassNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblClassNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblInitial.Text = WestwindHelper.GetWordWithColon("class.initial", "Product");
        }

        private void SetAttributes()
        {
            lvTagList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colClassCode.TextAlign = HorizontalAlignment.Left;
            colClassCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colInitial.TextAlign = HorizontalAlignment.Left;
            colInitial.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassName.TextAlign = HorizontalAlignment.Left;
            colClassName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassNameAlt1.TextAlign = HorizontalAlignment.Left;
            colClassNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassNameAlt2.TextAlign = HorizontalAlignment.Left;
            colClassNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblClassNameAlt2.Visible = txtClassNameAlt2.Visible = false;
                    colClassNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblClassNameAlt1.Visible = lblClassNameAlt2.Visible = txtClassNameAlt2.Visible = false;
                    colClassNameAlt1.Visible = colClassNameAlt2.Visible = false;
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

            if (_ClassId == Guid.Empty)
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
            txtClassCode.BackColor = (_ClassId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtClassCode.ReadOnly = (_ClassId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtClassCode, string.Empty);
            errorProvider.SetError(txtInitial, string.Empty);
        }

        private void Clear()
        {
            txtClassCode.Text = txtClassName.Text = txtClassNameAlt1.Text = txtClassNameAlt2.Text = txtInitial.Text = string.Empty;

            _ClassId = Guid.Empty;
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
                switch (_ClassType)
                {
                    case ProductHelper.Classes.Class1:
                        #region ProductClass1
                        var class1 = ctx.ProductClass1.Where(x => x.Retired == false).OrderBy(x => x.Class1Code).AsNoTracking().ToList();

                        foreach (var item in class1)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class1Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class1Code);
                            objItem.SubItems.Add(item.Class1Initial);
                            objItem.SubItems.Add(item.Class1Name);
                            objItem.SubItems.Add(item.Class1Name_Chs);
                            objItem.SubItems.Add(item.Class1Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class2:
                        #region ProductClass2
                        var class2 = ctx.ProductClass2.Where(x => x.Retired == false).OrderBy(x => x.Class2Code).AsNoTracking().ToList();

                        foreach (var item in class2)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class2Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class2Code);
                            objItem.SubItems.Add(item.Class2Initial);
                            objItem.SubItems.Add(item.Class2Name);
                            objItem.SubItems.Add(item.Class2Name_Chs);
                            objItem.SubItems.Add(item.Class2Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class3:
                        #region ProductClass3
                        var class3 = ctx.ProductClass3.Where(x => x.Retired == false).OrderBy(x => x.Class3Code).AsNoTracking().ToList();

                        foreach (var item in class3)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class3Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class3Code);
                            objItem.SubItems.Add(item.Class3Initial);
                            objItem.SubItems.Add(item.Class3Name);
                            objItem.SubItems.Add(item.Class3Name_Chs);
                            objItem.SubItems.Add(item.Class3Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class4:
                        #region ProductClass4
                        var class4 = ctx.ProductClass4.Where(x => x.Retired == false).OrderBy(x => x.Class4Code).AsNoTracking().ToList();

                        foreach (var item in class4)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class4Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class4Code);
                            objItem.SubItems.Add(item.Class4Initial);
                            objItem.SubItems.Add(item.Class4Name);
                            objItem.SubItems.Add(item.Class4Name_Chs);
                            objItem.SubItems.Add(item.Class4Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class5:
                        #region ProductClass5
                        var class5 = ctx.ProductClass5.Where(x => x.Retired == false).OrderBy(x => x.Class5Code).AsNoTracking().ToList();

                        foreach (var item in class5)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class5Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class5Code);
                            objItem.SubItems.Add(item.Class5Initial);
                            objItem.SubItems.Add(item.Class5Name);
                            objItem.SubItems.Add(item.Class5Name_Chs);
                            objItem.SubItems.Add(item.Class5Name_Cht);

                            iCount++;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class6:
                        #region ProductClass6
                        var class6 = ctx.ProductClass6.Where(x => x.Retired == false).OrderBy(x => x.Class6Code).AsNoTracking().ToList();

                        foreach (var item in class6)
                        {
                            ListViewItem objItem = this.lvTagList.Items.Add(item.Class6Id.ToString());
                            objItem.SubItems.Add(iCount.ToString()); // Line Number
                            objItem.SubItems.Add(item.Class6Code);
                            objItem.SubItems.Add(item.Class6Initial);
                            objItem.SubItems.Add(item.Class6Name);
                            objItem.SubItems.Add(item.Class6Name_Chs);
                            objItem.SubItems.Add(item.Class6Name_Cht);

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
            errorProvider.SetError(txtClassCode, string.Empty);

            #region Class Code 唔可以吉
            if (txtClassCode.Text.Length == 0)
            {
                errorProvider.SetError(txtClassCode, "Cannot be blank!");
                errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                result = false;
            }
            #endregion

            #region 新增，要 check Tag Code 係咪 in use
            if (_ClassId == Guid.Empty)
            {
                switch (_ClassType)
                {
                    case ProductHelper.Classes.Class1:
                        #region ProductClass1
                        if (ProductClass1Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
                    case ProductHelper.Classes.Class2:
                        #region ProductClass2
                        if (ProductClass2Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class3:
                        #region ProductClass3
                        if (ProductClass3Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
                    case ProductHelper.Classes.Class4:
                        #region ProductClass4
                        if (ProductClass4Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
                    case ProductHelper.Classes.Class5:
                        #region ProductClass5
                        if (ProductClass5Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
                            result = false;
                        }
                        break;
                        #endregion
                    case ProductHelper.Classes.Class6:
                        #region ProductClass6
                        if (ProductClass6Ex.IsClassCodeInUse(txtClassCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtClassCode, "Class Code in use");
                            errorProvider.SetIconAlignment(txtClassCode, ErrorIconAlignment.TopLeft);
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
                switch (_ClassType)
                {
                    case ProductHelper.Classes.Class1:
                        #region ProductClass1
                        var class1 = ctx.ProductClass1.Find(_ClassId);

                        if (class1 == null)
                        {
                            class1 = new EF6.ProductClass1();
                            class1.Class1Id = Guid.NewGuid();
                            class1.Class1Code = txtClassCode.Text;
                            class1.CreatedOn = DateTime.Now;
                            class1.CreatedBy = ConfigHelper.CurrentUserId;
                            class1.Retired = false;

                            ctx.ProductClass1.Add(class1);
                        }
                        class1.Class1Name = txtClassName.Text;
                        class1.Class1Name_Chs = txtClassNameAlt1.Text;
                        class1.Class1Name_Cht = txtClassNameAlt2.Text;
                        class1.Class1Initial = txtInitial.Text;
                        class1.ModifiedOn = DateTime.Now;
                        class1.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                        #endregion
                    case ProductHelper.Classes.Class2:
                        #region ProductClass2
                        var class2 = ctx.ProductClass2.Find(_ClassId);

                        if (class2 == null)
                        {
                            class2 = new EF6.ProductClass2();
                            class2.Class2Id = Guid.NewGuid();
                            class2.Class2Code = txtClassCode.Text;
                            class2.CreatedOn = DateTime.Now;
                            class2.CreatedBy = ConfigHelper.CurrentUserId;
                            class2.Retired = false;

                            ctx.ProductClass2.Add(class2);
                        }
                        class2.Class2Name = txtClassName.Text;
                        class2.Class2Name_Chs = txtClassNameAlt1.Text;
                        class2.Class2Name_Cht = txtClassNameAlt2.Text;
                        class2.Class2Initial = txtInitial.Text;
                        class2.ModifiedOn = DateTime.Now;
                        class2.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                    case ProductHelper.Classes.Class3:
                        #region ProductClass3
                        var class3 = ctx.ProductClass3.Find(_ClassId);

                        if (class3 == null)
                        {
                            class3 = new EF6.ProductClass3();
                            class3.Class3Id = Guid.NewGuid();
                            class3.Class3Code = txtClassCode.Text;
                            class3.CreatedOn = DateTime.Now;
                            class3.CreatedBy = ConfigHelper.CurrentUserId;
                            class3.Retired = false;

                            ctx.ProductClass3.Add(class3);
                        }
                        class3.Class3Name = txtClassName.Text;
                        class3.Class3Name_Chs = txtClassNameAlt1.Text;
                        class3.Class3Name_Cht = txtClassNameAlt2.Text;
                        class3.Class3Initial = txtInitial.Text;
                        class3.ModifiedOn = DateTime.Now;
                        class3.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                    case ProductHelper.Classes.Class4:
                        #region ProductClass4
                        var class4 = ctx.ProductClass4.Find(_ClassId);

                        if (class4 == null)
                        {
                            class4 = new EF6.ProductClass4();
                            class4.Class4Id = Guid.NewGuid();
                            class4.Class4Code = txtClassCode.Text;
                            class4.CreatedOn = DateTime.Now;
                            class4.CreatedBy = ConfigHelper.CurrentUserId;
                            class4.Retired = false;

                            ctx.ProductClass4.Add(class4);
                        }
                        class4.Class4Name = txtClassName.Text;
                        class4.Class4Name_Chs = txtClassNameAlt1.Text;
                        class4.Class4Name_Cht = txtClassNameAlt2.Text;
                        class4.Class4Initial = txtInitial.Text;
                        class4.ModifiedOn = DateTime.Now;
                        class4.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                    case ProductHelper.Classes.Class5:
                        #region ProductClass5
                        var class5 = ctx.ProductClass5.Find(_ClassId);

                        if (class5 == null)
                        {
                            class5 = new EF6.ProductClass5();
                            class5.Class5Id = Guid.NewGuid();
                            class5.Class5Code = txtClassCode.Text;
                            class5.CreatedOn = DateTime.Now;
                            class5.CreatedBy = ConfigHelper.CurrentUserId;
                            class5.Retired = false;

                            ctx.ProductClass5.Add(class5);
                        }
                        class5.Class5Name = txtClassName.Text;
                        class5.Class5Name_Chs = txtClassNameAlt1.Text;
                        class5.Class5Name_Cht = txtClassNameAlt2.Text;
                        class5.Class5Initial = txtInitial.Text;
                        class5.ModifiedOn = DateTime.Now;
                        class5.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        result = true;
                        break;
                    #endregion
                    case ProductHelper.Classes.Class6:
                        #region ProductClass6
                        var class6 = ctx.ProductClass6.Find(_ClassId);

                        if (class6 == null)
                        {
                            class6 = new EF6.ProductClass6();
                            class6.Class6Id = Guid.NewGuid();
                            class6.Class6Code = txtClassCode.Text;
                            class6.CreatedOn = DateTime.Now;
                            class6.CreatedBy = ConfigHelper.CurrentUserId;
                            class6.Retired = false;

                            ctx.ProductClass6.Add(class6);
                        }
                        class6.Class6Name = txtClassName.Text;
                        class6.Class6Name_Chs = txtClassNameAlt1.Text;
                        class6.Class6Name_Cht = txtClassNameAlt2.Text;
                        class6.Class6Initial = txtInitial.Text;
                        class6.ModifiedOn = DateTime.Now;
                        class6.ModifiedBy = ConfigHelper.CurrentUserId;

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
            switch (_ClassType)
            {
                case ProductHelper.Classes.Class1:
                    result = ProductClass1Ex.Delete(_ClassId);
                    break;
                case ProductHelper.Classes.Class2:
                    result = ProductClass2Ex.Delete(_ClassId);
                    break;
                case ProductHelper.Classes.Class3:
                    result = ProductClass3Ex.Delete(_ClassId);
                    break;
                case ProductHelper.Classes.Class4:
                    result = ProductClass4Ex.Delete(_ClassId);
                    break;
                case ProductHelper.Classes.Class5:
                    result = ProductClass5Ex.Delete(_ClassId);
                    break;
                case ProductHelper.Classes.Class6:
                    result = ProductClass6Ex.Delete(_ClassId);
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
                    _ClassId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        switch (_ClassType)
                        {
                            case ProductHelper.Classes.Class1:
                                #region ProductClass1
                                var class1 = ctx.ProductClass1.Find(id);
                                if (class1 != null)
                                {
                                    txtClassCode.Text = class1.Class1Code;
                                    txtClassName.Text = class1.Class1Name;
                                    txtClassNameAlt1.Text = class1.Class1Name_Chs;
                                    txtClassNameAlt2.Text = class1.Class1Name_Cht;
                                    txtInitial.Text = class1.Class1Initial;
                                }
                                break;
                                #endregion
                            case ProductHelper.Classes.Class2:
                                #region ProductClass2
                                var class2 = ctx.ProductClass2.Find(id);
                                if (class2 != null)
                                {
                                    txtClassCode.Text = class2.Class2Code;
                                    txtClassName.Text = class2.Class2Name;
                                    txtClassNameAlt1.Text = class2.Class2Name_Chs;
                                    txtClassNameAlt2.Text = class2.Class2Name_Cht;
                                    txtInitial.Text = class2.Class2Initial;
                                }
                                break;
                            #endregion
                            case ProductHelper.Classes.Class3:
                                #region ProductClass3
                                var class3 = ctx.ProductClass3.Find(id);
                                if (class3 != null)
                                {
                                    txtClassCode.Text = class3.Class3Code;
                                    txtClassName.Text = class3.Class3Name;
                                    txtClassNameAlt1.Text = class3.Class3Name_Chs;
                                    txtClassNameAlt2.Text = class3.Class3Name_Cht;
                                    txtInitial.Text = class3.Class3Initial;
                                }
                                break;
                            #endregion
                            case ProductHelper.Classes.Class4:
                                #region ProductClass4
                                var class4 = ctx.ProductClass4.Find(id);
                                if (class4 != null)
                                {
                                    txtClassCode.Text = class4.Class4Code;
                                    txtClassName.Text = class4.Class4Name;
                                    txtClassNameAlt1.Text = class4.Class4Name_Chs;
                                    txtClassNameAlt2.Text = class4.Class4Name_Cht;
                                    txtInitial.Text = class4.Class4Initial;
                                }
                                break;
                            #endregion
                            case ProductHelper.Classes.Class5:
                                #region ProductClass5
                                var class5 = ctx.ProductClass5.Find(id);
                                if (class5 != null)
                                {
                                    txtClassCode.Text = class5.Class5Code;
                                    txtClassName.Text = class5.Class5Name;
                                    txtClassNameAlt1.Text = class5.Class5Name_Chs;
                                    txtClassNameAlt2.Text = class5.Class5Name_Cht;
                                    txtInitial.Text = class5.Class5Initial;
                                }
                                break;
                            #endregion
                            case ProductHelper.Classes.Class6:
                                #region ProductClass6
                                var class6 = ctx.ProductClass6.Find(id);
                                if (class6 != null)
                                {
                                    txtClassCode.Text = class6.Class6Code;
                                    txtClassName.Text = class6.Class6Name;
                                    txtClassNameAlt1.Text = class6.Class6Name_Chs;
                                    txtClassNameAlt2.Text = class6.Class6Name_Cht;
                                    txtInitial.Text = class6.Class6Initial;
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