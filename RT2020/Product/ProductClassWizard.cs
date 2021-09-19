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
using System.Collections;
using RT2020.Controls;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Product
{
    public partial class ProductClassWizard : Form
    {
        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ClassId = Guid.Empty;
        public Guid ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
        }

        private ProductHelper.Classes _ClassMode = ProductHelper.Classes.None;
        public ProductHelper.Classes ClassMode
        {
            get { return _ClassMode; }
            set { _ClassMode = value; }
        }
        #endregion

        #region Properties
        //private Guid classId = System.Guid.Empty;
        //public Guid ClassId
        //{
        //    get
        //    {
        //        return classId;
        //    }
        //    set
        //    {
        //        classId = value;
        //    }
        //}
        /*
        private EF6.ProductClass1 class1 = null;
        public EF6.ProductClass1 Class1
        {
            get
            {
                return class1;
            }
            set
            {
                class1 = value;
            }
        }

        private EF6.ProductClass2 class2 = null;
        public EF6.ProductClass2 Class2
        {
            get
            {
                return class2;
            }
            set
            {
                class2 = value;
            }
        }

        private EF6.ProductClass3 class3 = null;
        public EF6.ProductClass3 Class3
        {
            get
            {
                return class3;
            }
            set
            {
                class3 = value;
            }
        }

        private EF6.ProductClass4 class4 = null;
        public EF6.ProductClass4 Class4
        {
            get
            {
                return class4;
            }
            set
            {
                class4 = value;
            }
        }

        private EF6.ProductClass5 class5 = null;
        public EF6.ProductClass5 Class5
        {
            get
            {
                return class5;
            }
            set
            {
                class5 = value;
            }
        }

        private EF6.ProductClass6 class6 = null;
        public EF6.ProductClass6 Class6
        {
            get
            {
                return class6;
            }
            set
            {
                class6 = value;
            }
        }
        */
        #endregion

        public ProductClassWizard()
        {
            InitializeComponent();
        }

        private void ProductClassWizard_Load(object sender, EventArgs e)
        {
            SetCtrlEditable();
            SetToolBar();
            FillParentClassList();
            SetCaptions();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadClass();
                    break;
            }
        }

        #region Initialize Class
        /**
        private void InitClass(Type className)
        {
            object objClass = Activator.CreateInstance(className);

            if (objClass.GetType().Equals(typeof(EF6.ProductClass1)))
            {
                Class1 = objClass as EF6.ProductClass1;
            }

            if (objClass.GetType().Equals(typeof(EF6.ProductClass2)))
            {
                Class2 = objClass as EF6.ProductClass2;
            }

            if (objClass.GetType().Equals(typeof(EF6.ProductClass3)))
            {
                Class3 = objClass as EF6.ProductClass3;
            }

            if (objClass.GetType().Equals(typeof(EF6.ProductClass4)))
            {
                Class4 = objClass as EF6.ProductClass4;
            }

            if (objClass.GetType().Equals(typeof(EF6.ProductClass5)))
            {
                Class5 = objClass as EF6.ProductClass5;
            }

            if (objClass.GetType().Equals(typeof(EF6.ProductClass6)))
            {
                Class6 = objClass as EF6.ProductClass6;
            }
        }
        */
        #endregion

        #region SetCaptions
        private void SetCaptions()
        {
            #region 配置彈出的 Windows 的 Title 名稱
            switch (ClassMode)
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

            lblCode.Text = WestwindHelper.GetWordWithColon("class.code", "Product");
            lblInitial.Text = WestwindHelper.GetWordWithColon("class.initial", "Product");
            lblName.Text = WestwindHelper.GetWordWithColon("class.name", "Product");
            lblNameChs.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameCht.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblAltClass.Text = WestwindHelper.GetWordWithColon("class.alternate", "Product");
            lblParentClass.Text = WestwindHelper.GetWordWithColon("class.parent", "Product");
            lblLastUpdate.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
        }

        private void SetCtrlEditable()
        {
            txtCode.BackColor = (this.ClassId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCode.ReadOnly = (this.ClassId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCode, string.Empty);
        }

        private void ClearForm()
        {
            /**
            Type type = null;

            if (this.Class1 != null)
            {
                type = Class1.GetType();
            }

            if (this.Class2 != null)
            {
                type = Class2.GetType();
            }

            if (this.Class3 != null)
            {
                type = Class3.GetType();
            }

            if (this.Class4 != null)
            {
                type = Class4.GetType();
            }

            if (this.Class5 != null)
            {
                type = Class5.GetType();
            }

            if (this.Class6 != null)
            {
                type = Class6.GetType();
            }
            */
            txtCode.Text = txtInitial.Text = txtName.Text = txtNameChs.Text = txtNameCht.Text = txtLastUpdatedBy.Text = txtLastUpdatedOn.Text = txtCreatedOn.Text = string.Empty;
            _ClassId = Guid.Empty;
            _EditMode = EnumHelper.EditMode.Add;

            SetCtrlEditable();
            FillParentClassList();
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

            if (ClassId == System.Guid.Empty)
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
                        ClearForm();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            LoadClass();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        ClearForm();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Fill Combo List
        private void FillParentClassList()
        {
            string sql;
            string[] orderBy;

            switch (_ClassMode)
            {
                case ProductHelper.Classes.Class1:
                    #region fill Class1 combo
                    sql = "Class1Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class1Code" };

                    ProductClass1Ex.LoadCombo(ref cboParentClass, "Class1Code", false, true, "", sql, orderBy);
                    ProductClass1Ex.LoadCombo(ref cboAltClass, "Class1Code", false, true, "", sql, orderBy);
                    break;
                #endregion
                case ProductHelper.Classes.Class2:
                    #region fill Class2 combo
                    sql = "Class2Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class2Code" };

                    ProductClass2Ex.LoadCombo(ref cboParentClass, "Class2Code", false, true, "", sql, orderBy);
                    ProductClass2Ex.LoadCombo(ref cboAltClass, "Class2Code", false, true, "", sql, orderBy);
                    break;
                #endregion
                case ProductHelper.Classes.Class3:
                    #region fill Class3 combo
                    sql = "Class3Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class3Code" };

                    ProductClass3Ex.LoadCombo(ref cboParentClass, "Class3Code", false, true, "", sql, orderBy);
                    ProductClass3Ex.LoadCombo(ref cboAltClass, "Class3Code", false, true, "", sql, orderBy);
                    break;
                #endregion
                case ProductHelper.Classes.Class4:
                    #region fill Class4 combo
                    sql = "Class4Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class4Code" };

                    ProductClass4Ex.LoadCombo(ref cboParentClass, "Class4Code", false, true, "", sql, orderBy);
                    ProductClass4Ex.LoadCombo(ref cboAltClass, "Class4Code", false, true, "", sql, orderBy);
                    break;
                #endregion
                case ProductHelper.Classes.Class5:
                    #region fill Class5 combo
                    sql = "Class5Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class5Code" };

                    ProductClass5Ex.LoadCombo(ref cboParentClass, "Class5Code", false, true, "", sql, orderBy);
                    ProductClass5Ex.LoadCombo(ref cboAltClass, "Class5Code", false, true, "", sql, orderBy);
                    break;
                #endregion
                case ProductHelper.Classes.Class6:
                    #region fill Class6 combo
                    sql = "Class6Id NOT IN ('" + _ClassId.ToString() + "')";
                    orderBy = new string[] { "Class6Code" };

                    ProductClass6Ex.LoadCombo(ref cboParentClass, "Class6Code", false, true, "", sql, orderBy);
                    ProductClass6Ex.LoadCombo(ref cboAltClass, "Class6Code", false, true, "", sql, orderBy);
                    break;
                    #endregion
            }
        }
        #endregion

        #region Save
        private bool IsValid()
        {
            bool result = true;

            #region Class Code 唔可以吉
            errorProvider.SetError(txtCode, string.Empty);
            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Class Code 係咪 in use
            errorProvider.SetError(txtCode, string.Empty);
            var isClassCodeInUse = _ClassMode == ProductHelper.Classes.Class1 ?
                ProductClass1Ex.IsClassCodeInUse(txtCode.Text.Trim()) : _ClassMode == ProductHelper.Classes.Class2 ?
                ProductClass2Ex.IsClassCodeInUse(txtCode.Text.Trim()) : _ClassMode == ProductHelper.Classes.Class3 ?
                ProductClass3Ex.IsClassCodeInUse(txtCode.Text.Trim()) : _ClassMode == ProductHelper.Classes.Class4 ?
                ProductClass4Ex.IsClassCodeInUse(txtCode.Text.Trim()) : _ClassMode == ProductHelper.Classes.Class5 ?
                ProductClass5Ex.IsClassCodeInUse(txtCode.Text.Trim()) : _ClassMode == ProductHelper.Classes.Class6 ?
                ProductClass6Ex.IsClassCodeInUse(txtCode.Text.Trim()) : false;
            if (_ClassId == Guid.Empty && isClassCodeInUse)
            {
                errorProvider.SetError(txtCode, "Class Code in use");
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
                switch (_ClassMode)
                {
                    case ProductHelper.Classes.Class1:
                        #region Class1
                        EF6.ProductClass1 class1;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class1 = new EF6.ProductClass1();
                            class1.Class1Id = Guid.NewGuid();
                            class1.Class1Code = txtCode.Text;
                            class1.CreatedBy = ConfigHelper.CurrentUserId;
                            class1.CreatedOn = DateTime.Now;
                            class1.Retired = false;

                            ctx.ProductClass1.Add(class1);
                        }
                        else
                        {
                            class1 = ctx.ProductClass1.Find(_ClassId);
                        }
                        class1.Class1Initial = txtInitial.Text;
                        class1.Class1Name = txtName.Text;
                        class1.Class1Name_Chs = txtNameChs.Text;
                        class1.Class1Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class1.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class1.AlternateClass = (Guid)cboAltClass.SelectedValue;

                        class1.ModifiedBy = ConfigHelper.CurrentUserId;
                        class1.ModifiedOn = DateTime.Now;

                        break;
                    #endregion
                    case ProductHelper.Classes.Class2:
                        #region Class2
                        EF6.ProductClass2 class2;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class2 = new EF6.ProductClass2();
                            class2.Class2Id = Guid.NewGuid();
                            class2.Class2Code = txtCode.Text;
                            class2.CreatedBy = ConfigHelper.CurrentUserId;
                            class2.CreatedOn = DateTime.Now;
                            class2.Retired = false;

                            ctx.ProductClass2.Add(class2);
                        }
                        else
                        {
                            class2 = ctx.ProductClass2.Find(_ClassId);
                        }
                        class2.Class2Initial = txtInitial.Text;
                        class2.Class2Name = txtName.Text;
                        class2.Class2Name_Chs = txtNameChs.Text;
                        class2.Class2Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class2.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class2.AlternateClass = (Guid)cboAltClass.SelectedValue;

                        class2.ModifiedBy = ConfigHelper.CurrentUserId;
                        class2.ModifiedOn = DateTime.Now;

                        break;
                    #endregion
                    case ProductHelper.Classes.Class3:
                        #region Class3
                        EF6.ProductClass3 class3;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class3 = new EF6.ProductClass3();
                            class3.Class3Id = Guid.NewGuid();
                            class3.Class3Code = txtCode.Text;
                            class3.CreatedBy = ConfigHelper.CurrentUserId;
                            class3.CreatedOn = DateTime.Now;
                            class3.Retired = false;

                            ctx.ProductClass3.Add(class3);
                        }
                        else
                        {
                            class3 = ctx.ProductClass3.Find(_ClassId);
                        }
                        class3.Class3Initial = txtInitial.Text;
                        class3.Class3Name = txtName.Text;
                        class3.Class3Name_Chs = txtNameChs.Text;
                        class3.Class3Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class3.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class3.AlternatedClass = (Guid)cboAltClass.SelectedValue;

                        class3.ModifiedBy = ConfigHelper.CurrentUserId;
                        class3.ModifiedOn = DateTime.Now;

                        break;
                    #endregion
                    case ProductHelper.Classes.Class4:
                        #region Class4
                        EF6.ProductClass4 class4;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class4 = new EF6.ProductClass4();
                            class4.Class4Id = Guid.NewGuid();
                            class4.Class4Code = txtCode.Text;
                            class4.CreatedBy = ConfigHelper.CurrentUserId;
                            class4.CreatedOn = DateTime.Now;
                            class4.Retired = false;

                            ctx.ProductClass4.Add(class4);
                        }
                        else
                        {
                            class4 = ctx.ProductClass4.Find(_ClassId);
                        }
                        class4.Class4Initial = txtInitial.Text;
                        class4.Class4Name = txtName.Text;
                        class4.Class4Name_Chs = txtNameChs.Text;
                        class4.Class4Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class4.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class4.AlternateClass = (Guid)cboAltClass.SelectedValue;

                        class4.ModifiedBy = ConfigHelper.CurrentUserId;
                        class4.ModifiedOn = DateTime.Now;

                        break;
                    #endregion
                    case ProductHelper.Classes.Class5:
                        #region Class5
                        EF6.ProductClass5 class5;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class5 = new EF6.ProductClass5();
                            class5.Class5Id = Guid.NewGuid();
                            class5.Class5Code = txtCode.Text;
                            class5.CreatedBy = ConfigHelper.CurrentUserId;
                            class5.CreatedOn = DateTime.Now;
                            class5.Retired = false;

                            ctx.ProductClass5.Add(class5);
                        }
                        else
                        {
                            class5 = ctx.ProductClass5.Find(_ClassId);
                        }
                        class5.Class5Initial = txtInitial.Text;
                        class5.Class5Name = txtName.Text;
                        class5.Class5Name_Chs = txtNameChs.Text;
                        class5.Class5Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class5.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class5.AlternateClass = (Guid)cboAltClass.SelectedValue;

                        class5.ModifiedBy = ConfigHelper.CurrentUserId;
                        class5.ModifiedOn = DateTime.Now;

                        break;
                    #endregion
                    case ProductHelper.Classes.Class6:
                        #region Class6
                        EF6.ProductClass6 class6;
                        if (_EditMode == EnumHelper.EditMode.Add)
                        {
                            class6 = new EF6.ProductClass6();
                            class6.Class6Id = Guid.NewGuid();
                            class6.Class6Code = txtCode.Text;
                            class6.CreatedBy = ConfigHelper.CurrentUserId;
                            class6.CreatedOn = DateTime.Now;
                            class6.Retired = false;

                            ctx.ProductClass6.Add(class6);
                        }
                        else
                        {
                            class6 = ctx.ProductClass6.Find(_ClassId);
                        }
                        class6.Class6Initial = txtInitial.Text;
                        class6.Class6Name = txtName.Text;
                        class6.Class6Name_Chs = txtNameChs.Text;
                        class6.Class6Name_Cht = txtNameCht.Text;
                        if ((Guid)cboParentClass.SelectedValue != Guid.Empty) class6.ParentClass = (Guid)cboParentClass.SelectedValue;
                        if ((Guid)cboAltClass.SelectedValue != Guid.Empty) class6.AlternateClass = (Guid)cboAltClass.SelectedValue;

                        class6.ModifiedBy = ConfigHelper.CurrentUserId;
                        class6.ModifiedOn = DateTime.Now;

                        break;
                        #endregion
                }
                ctx.SaveChanges();

                Helper.DesktopHelper.RefreshMainList<ClassList>();
                result = true;
            }

            return result; ;
        }
        #endregion

        #region Load

        private void LoadClass()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                switch (_ClassMode)
                {
                    case ProductHelper.Classes.Class1:
                        #region LoadClass1();
                        var class1 = ctx.ProductClass1.Find(_ClassId);
                        if (class1 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class1.Class1Code;
                            txtInitial.Text = class1.Class1Initial;
                            txtName.Text = class1.Class1Name;
                            txtNameChs.Text = class1.Class1Name_Chs;
                            txtNameCht.Text = class1.Class1Name_Cht;
                            cboParentClass.SelectedValue = class1.ParentClass.HasValue ? class1.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class1.AlternateClass.HasValue ? class1.AlternateClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class1.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class1.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class1.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class2:
                        #region LoadClass2();
                        var class2 = ctx.ProductClass2.Find(_ClassId);
                        if (class2 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class2.Class2Code;
                            txtInitial.Text = class2.Class2Initial;
                            txtName.Text = class2.Class2Name;
                            txtNameChs.Text = class2.Class2Name_Chs;
                            txtNameCht.Text = class2.Class2Name_Cht;
                            cboParentClass.SelectedValue = class2.ParentClass.HasValue ? class2.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class2.AlternateClass.HasValue ? class2.AlternateClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class2.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class2.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class2.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class3:
                        #region LoadClass3();
                        var class3 = ctx.ProductClass3.Find(_ClassId);
                        if (class3 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class3.Class3Code;
                            txtInitial.Text = class3.Class3Initial;
                            txtName.Text = class3.Class3Name;
                            txtNameChs.Text = class3.Class3Name_Chs;
                            txtNameCht.Text = class3.Class3Name_Cht;
                            cboParentClass.SelectedValue = class3.ParentClass.HasValue ? class3.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class3.AlternatedClass.HasValue ? class3.AlternatedClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class3.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class3.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class3.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class4:
                        #region LoadClass4();
                        var class4 = ctx.ProductClass4.Find(_ClassId);
                        if (class4 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class4.Class4Code;
                            txtInitial.Text = class4.Class4Initial;
                            txtName.Text = class4.Class4Name;
                            txtNameChs.Text = class4.Class4Name_Chs;
                            txtNameCht.Text = class4.Class4Name_Cht;
                            cboParentClass.SelectedValue = class4.ParentClass.HasValue ? class4.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class4.AlternateClass.HasValue ? class4.AlternateClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class4.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class4.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class4.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class5:
                        #region LoadClass5();
                        var class5 = ctx.ProductClass5.Find(_ClassId);
                        if (class5 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class5.Class5Code;
                            txtInitial.Text = class5.Class5Initial;
                            txtName.Text = class5.Class5Name;
                            txtNameChs.Text = class5.Class5Name_Chs;
                            txtNameCht.Text = class5.Class5Name_Cht;
                            cboParentClass.SelectedValue = class5.ParentClass.HasValue ? class5.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class5.AlternateClass.HasValue ? class5.AlternateClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class5.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class5.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class5.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                    #endregion
                    case ProductHelper.Classes.Class6:
                        #region LoadClass6();
                        var class6 = ctx.ProductClass6.Find(_ClassId);
                        if (class6 != null)
                        {
                            FillParentClassList();

                            txtCode.Text = class6.Class6Code;
                            txtInitial.Text = class6.Class6Initial;
                            txtName.Text = class6.Class6Name;
                            txtNameChs.Text = class6.Class6Name_Chs;
                            txtNameCht.Text = class6.Class6Name_Cht;
                            cboParentClass.SelectedValue = class6.ParentClass.HasValue ? class6.ParentClass : Guid.Empty;
                            cboAltClass.SelectedValue = class6.AlternateClass.HasValue ? class6.AlternateClass : Guid.Empty;

                            txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(class6.ModifiedOn, false);
                            txtCreatedOn.Text = DateTimeHelper.DateTimeToString(class6.CreatedOn, false);
                            txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(class6.ModifiedBy);

                            SetCtrlEditable();
                        }
                        break;
                        #endregion
                }
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    switch (_ClassMode)
                    {
                        case ProductHelper.Classes.Class1:
                            #region class1
                            var class1 = ctx.ProductClass1.Find(_ClassId);
                            if (class1 != null)
                            {
                                ctx.ProductClass1.Remove(class1);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class1.ToString());
                            }
                            break;
                        #endregion
                        case ProductHelper.Classes.Class2:
                            #region class2
                            var class2 = ctx.ProductClass2.Find(_ClassId);
                            if (class2 != null)
                            {
                                ctx.ProductClass2.Remove(class2);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class2.ToString());
                            }
                            break;
                        #endregion
                        case ProductHelper.Classes.Class3:
                            #region class3
                            var class3 = ctx.ProductClass3.Find(_ClassId);
                            if (class3 != null)
                            {
                                ctx.ProductClass3.Remove(class3);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class3.ToString());
                            }
                            break;
                        #endregion
                        case ProductHelper.Classes.Class4:
                            #region class4
                            var class4 = ctx.ProductClass4.Find(_ClassId);
                            if (class4 != null)
                            {
                                ctx.ProductClass4.Remove(class4);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class4.ToString());
                            }
                            break;
                        #endregion
                        case ProductHelper.Classes.Class5:
                            #region class5
                            var class5 = ctx.ProductClass5.Find(_ClassId);
                            if (class5 != null)
                            {
                                ctx.ProductClass5.Remove(class5);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class5.ToString());
                            }
                            break;
                        #endregion
                        case ProductHelper.Classes.Class6:
                            #region class6
                            var class6 = ctx.ProductClass6.Find(_ClassId);
                            if (class6 != null)
                            {
                                ctx.ProductClass6.Remove(class6);
                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, class6.ToString());
                            }
                            break;
                            #endregion
                    }
                    ctx.SaveChanges();
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

                this.Close();
            }
        }
    }
}