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
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProductAppendixWizard : Form
    {
        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private ProductHelper.Appendix _AppendixMode = ProductHelper.Appendix.None;
        public ProductHelper.Appendix AppendixMode
        {
            get { return _AppendixMode; }
            set { _AppendixMode = value; }
        }

        private Guid _AppendixId = Guid.Empty;
        public Guid AppendixId
        {
            get { return _AppendixId; }
            set { _AppendixId = value; }
        }
        #endregion

        public ProductAppendixWizard()
        {
            InitializeComponent();
        }

        private void ProductAppendixWizard_Load(object sender, EventArgs e)
        {
            SetCtrlEditable();
            SetToolBar();
            FillParentAppendixList();
            SetCaptions();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadAppendixData();
                    break;
            }
        }

        #region SetCaptions SetCtrlEditable ClearForm
        private void SetCaptions()
        {
            #region 配置彈出的 Windows 的 Title 名稱
            switch (AppendixMode)
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

            lblCode.Text = WestwindHelper.GetWordWithColon("appendix.code", "Product");
            lblInitial.Text = WestwindHelper.GetWordWithColon("appendix.initial", "Product");
            lblName.Text = WestwindHelper.GetWordWithColon("appendix.name", "Product");
            lblNameChs.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameCht.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblParentAppendix.Text = WestwindHelper.GetWordWithColon("appendix.parent", "Product");
            lblLastUpdate.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
        }

        private void SetCtrlEditable()
        {
            txtCode.BackColor = (this.AppendixId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCode.ReadOnly = (this.AppendixId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCode, string.Empty);
        }

        private void ClearForm()
        {
            txtCode.Text = txtInitial.Text = txtName.Text = txtNameChs.Text = txtNameCht.Text = txtLastUpdatedBy.Text = txtLastUpdatedOn.Text = txtCreatedOn.Text = string.Empty;
            _AppendixId = Guid.Empty;
            _EditMode = EnumHelper.EditMode.Add;

            SetCtrlEditable();
            FillParentAppendixList();
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

            if (AppendixId == System.Guid.Empty)
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
                            ClearForm();
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
        private void FillParentAppendixList()
        {
            string sql;
            string[] orderBy;

            switch (_AppendixMode)
            {
                case ProductHelper.Appendix.Appendix1:
                    sql = "Appendix1Id NOT IN ('" + _AppendixId.ToString() + "')";
                    orderBy = new string[] { "Appendix1Code" };
                    ModelEx.ProductAppendix1Ex.LoadCombo(ref cboParentAppendix, "Appendix1Code", true, true, "", sql, orderBy);
                    break;
                case ProductHelper.Appendix.Appendix2:
                    sql = "Appendix1Id NOT IN ('" + this.AppendixId.ToString() + "')";
                    orderBy = new string[] { "Appendix1Code" };
                    ModelEx.ProductAppendix1Ex.LoadCombo(ref cboParentAppendix, "Appendix1Code", true, true, "", sql, orderBy);
                    break;
                case ProductHelper.Appendix.Appendix3:
                    sql = "Appendix3Id NOT IN ('" + this.AppendixId.ToString() + "')";
                    orderBy = new string[] { "Appendix3Code" };
                    ModelEx.ProductAppendix3Ex.LoadCombo(ref cboParentAppendix, "Appendix3Code", true, true, "", sql, orderBy);
                    break;
            }

            cboParentAppendix.SelectedIndex = cboParentAppendix.Items.Count - 1;
        }
        /**
        private ProductAppendix1Collection GetA1List()
        {
            string sql = "Appendix1Id NOT IN ('" + this.AppendixId.ToString() + "')";
            string[] orderBy = new string[] { "Appendix1Code" };
            ProductAppendix1Collection oProductAppendixList = ProductAppendix1.LoadCollection(sql, orderBy, true);
            oProductAppendixList.Add(new ProductAppendix1());

            return oProductAppendixList;
        }

        private ProductAppendix2Collection GetA2List()
        {
            string sql = "Appendix2Id NOT IN ('" + this.AppendixId.ToString() + "')";
            string[] orderBy = new string[] { "Appendix2Code" };
            ProductAppendix2Collection oProductAppendixList = ProductAppendix2.LoadCollection(sql, orderBy, true);
            oProductAppendixList.Add(new ProductAppendix2());

            return oProductAppendixList;
        }

        private ProductAppendix3Collection GetA3List()
        {
            string sql = "Appendix3Id NOT IN ('" + this.AppendixId.ToString() + "')";
            string[] orderBy = new string[] { "Appendix3Code" };
            ProductAppendix3Collection oProductAppendixList = ProductAppendix3.LoadCollection(sql, orderBy, true);
            oProductAppendixList.Add(new ProductAppendix3());

            return oProductAppendixList;
        }
        */
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Appendix Code 唔可以吉
            errorProvider.SetError(txtCode, string.Empty);
            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Appendix Code 係咪 in use
            errorProvider.SetError(txtCode, string.Empty);
            var isAppendixCodeInUse = _AppendixMode == ProductHelper.Appendix.Appendix1 ?
                true : _AppendixMode == ProductHelper.Appendix.Appendix2 ?
                true : _AppendixMode == ProductHelper.Appendix.Appendix3 ?
                true : false;
            if (this.AppendixId == Guid.Empty && isAppendixCodeInUse)
            {
                errorProvider.SetError(txtCode, "Appendix Code in use");
                return false;
            }
            #endregion

            return result;
        }

        private void Save()
        {
            switch (_AppendixMode)
            {
                case ProductHelper.Appendix.Appendix1:
                    SaveAppendix1();
                    break;
                case ProductHelper.Appendix.Appendix2:
                    SaveAppendix2();
                    break;
                case ProductHelper.Appendix.Appendix3:
                    SaveAppendix3();
                    break;
            }
            SystemInfoHelper.Settings.RefreshMainList<AppendixList>();
        }

        private bool SaveAppendix1()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                EF6.ProductAppendix1 item = null;
                switch (_EditMode)
                {
                    case EnumHelper.EditMode.Add:
                        item = new EF6.ProductAppendix1();
                        item.Appendix1Id = Guid.NewGuid();
                        item.Appendix1Code = txtCode.Text;
                        item.CreatedBy = ConfigHelper.CurrentUserId;
                        item.CreatedOn = DateTime.Now;

                        ctx.ProductAppendix1.Add(item);
                        break;
                    case EnumHelper.EditMode.Edit:
                        item = ctx.ProductAppendix1.Find(_AppendixId);
                        break;
                }
                item.Appendix1Initial = txtInitial.Text;
                item.Appendix1Name = txtName.Text;
                item.Appendix1Name_Chs = txtNameChs.Text;
                item.Appendix1Name_Cht = txtNameCht.Text;
                if ((Guid)cboParentAppendix.SelectedValue != Guid.Empty) item.ParentAppendix = (Guid)cboParentAppendix.SelectedValue;

                item.ModifiedBy = ConfigHelper.CurrentUserId;
                item.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();

                _AppendixId = item.Appendix1Id;

                result = true;
            }

            return result;
        }

        private bool SaveAppendix2()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                EF6.ProductAppendix2 item = null;
                switch (_EditMode)
                {
                    case EnumHelper.EditMode.Add:
                        item = new EF6.ProductAppendix2();
                        item.Appendix2Id = Guid.NewGuid();
                        item.Appendix2Code = txtCode.Text;
                        item.CreatedBy = ConfigHelper.CurrentUserId;
                        item.CreatedOn = DateTime.Now;

                        ctx.ProductAppendix2.Add(item);
                        break;
                    case EnumHelper.EditMode.Edit:
                        item = ctx.ProductAppendix2.Find(_AppendixId);
                        break;
                }
                item.Appendix2Initial = txtInitial.Text;
                item.Appendix2Name = txtName.Text;
                item.Appendix2Name_Chs = txtNameChs.Text;
                item.Appendix2Name_Cht = txtNameCht.Text;
                if ((Guid)cboParentAppendix.SelectedValue != Guid.Empty) item.ParentAppendix = (Guid)cboParentAppendix.SelectedValue;

                item.ModifiedBy = ConfigHelper.CurrentUserId;
                item.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();

                _AppendixId = item.Appendix2Id;

                result = true;
            }

            return result;
        }

        private bool SaveAppendix3()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                EF6.ProductAppendix3 item = null;
                switch (_EditMode)
                {
                    case EnumHelper.EditMode.Add:
                        item = new EF6.ProductAppendix3();
                        item.Appendix3Id = Guid.NewGuid();
                        item.Appendix3Code = txtCode.Text;
                        item.CreatedBy = ConfigHelper.CurrentUserId;
                        item.CreatedOn = DateTime.Now;

                        ctx.ProductAppendix3.Add(item);
                        break;
                    case EnumHelper.EditMode.Edit:
                        item = ctx.ProductAppendix3.Find(_AppendixId);
                        break;
                }
                item.Appendix3Initial = txtInitial.Text;
                item.Appendix3Name = txtName.Text;
                item.Appendix3Name_Chs = txtNameChs.Text;
                item.Appendix3Name_Cht = txtNameCht.Text;
                if ((Guid)cboParentAppendix.SelectedValue != Guid.Empty) item.ParentAppendix = (Guid)cboParentAppendix.SelectedValue;

                item.ModifiedBy = ConfigHelper.CurrentUserId;
                item.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();

                _AppendixId = item.Appendix3Id;

                result = true;
            }

            return result;
        }

        #endregion

        #region Load Appendix Data

        private void LoadAppendixData()
        {
            switch (_AppendixMode)
            {
                case ProductHelper.Appendix.Appendix1:
                    LoadAppendix1();
                    break;
                case ProductHelper.Appendix.Appendix2:
                    LoadAppendix2();
                    break;
                case ProductHelper.Appendix.Appendix3:
                    LoadAppendix3();
                    break;
            }
        }

        private void LoadAppendix1()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix1.Where(x => x.Appendix1Id == _AppendixId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    FillParentAppendixList();

                    txtCode.Text = item.Appendix1Code;
                    txtInitial.Text = item.Appendix1Initial;
                    txtName.Text = item.Appendix1Name;
                    txtNameChs.Text = item.Appendix1Name_Chs;
                    txtNameCht.Text = item.Appendix1Name_Cht;
                    cboParentAppendix.SelectedValue = item.ParentAppendix.HasValue ? item.ParentAppendix : Guid.Empty;

                    txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(item.ModifiedOn, false);
                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(item.CreatedOn, false);
                    txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(item.ModifiedBy);

                    SetCtrlEditable();
                }
            }
        }

        private void LoadAppendix2()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix2.Where(x => x.Appendix2Id == _AppendixId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    FillParentAppendixList();

                    txtCode.Text = item.Appendix2Code;
                    txtInitial.Text = item.Appendix2Initial;
                    txtName.Text = item.Appendix2Name;
                    txtNameChs.Text = item.Appendix2Name_Chs;
                    txtNameCht.Text = item.Appendix2Name_Cht;
                    cboParentAppendix.SelectedValue = item.ParentAppendix.HasValue ? item.ParentAppendix : Guid.Empty;

                    txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(item.ModifiedOn, false);
                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(item.CreatedOn, false);
                    txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(item.ModifiedBy);

                    SetCtrlEditable();
                }
            }
        }

        private void LoadAppendix3()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.ProductAppendix3.Where(x => x.Appendix3Id == _AppendixId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    FillParentAppendixList();

                    txtCode.Text = item.Appendix3Code;
                    txtInitial.Text = item.Appendix3Initial;
                    txtName.Text = item.Appendix3Name;
                    txtNameChs.Text = item.Appendix3Name_Chs;
                    txtNameCht.Text = item.Appendix3Name_Cht;
                    cboParentAppendix.SelectedValue = item.ParentAppendix.HasValue ? item.ParentAppendix : Guid.Empty;

                    txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(item.ModifiedOn, false);
                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(item.CreatedOn, false);
                    txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(item.ModifiedBy);

                    SetCtrlEditable();
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
                    switch (_AppendixMode)
                    {
                        case ProductHelper.Appendix.Appendix1:
                            #region delete Appendix1
                            var item1 = ctx.ProductAppendix1.Find(_AppendixId);
                            if (item1 != null)
                            {
                                ctx.ProductAppendix1.Remove(item1);
                                ctx.SaveChanges();
                            }
                            break;
                            #endregion
                        case ProductHelper.Appendix.Appendix2:
                            #region delete Appendix2
                            var item2 = ctx.ProductAppendix2.Find(_AppendixId);
                            if (item2 != null)
                            {
                                ctx.ProductAppendix2.Remove(item2);
                                ctx.SaveChanges();
                            }
                            break;
                            #endregion
                        case ProductHelper.Appendix.Appendix3:
                            #region delete Appendix3
                            var item3 = ctx.ProductAppendix3.Find(_AppendixId);
                            if (item3 != null)
                            {
                                ctx.ProductAppendix3.Remove(item3);
                                ctx.SaveChanges();
                            }
                            break;
                            #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
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