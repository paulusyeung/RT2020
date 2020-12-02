#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using Gizmox.WebGUI.Common.Resources;
using System.Collections;

#endregion

namespace RT2020.Product
{
    public partial class ProductAppendixWizard : Form
    {
        public ProductAppendixWizard(Type appendixName)
        {
            InitializeComponent();
            InitAppendix(appendixName);
            SetCtrlEditable();
            SetToolBar();
            FillParentAppendixList();
            SetCaptions();
        }

        public ProductAppendixWizard(Guid appendixId)
        {
            InitializeComponent();
            this.AppendixId = appendixId;
            SetCtrlEditable();
            SetToolBar();
            FillParentAppendixList();
            LoadAppendix();
            SetCaptions();
        }

        #region Initialize Appendix
        private void InitAppendix(Type appendixName)
        {
            object objAppendix = Activator.CreateInstance(appendixName);

            if (objAppendix.GetType().Equals(typeof(ProductAppendix1)))
            {
                Appendix1 = objAppendix as ProductAppendix1;
            }

            if (objAppendix.GetType().Equals(typeof(ProductAppendix2)))
            {
                Appendix2 = objAppendix as ProductAppendix2;
            }

            if (objAppendix.GetType().Equals(typeof(ProductAppendix3)))
            {
                Appendix3 = objAppendix as ProductAppendix3;
            }
        }
        #endregion

        #region Properties
        private Guid appendixId = System.Guid.Empty;
        public Guid AppendixId
        {
            get
            {
                return appendixId;
            }
            set
            {
                appendixId = value;
            }
        }

        private ProductAppendix1 appendix1 = null;
        public ProductAppendix1 Appendix1
        {
            get
            {
                return appendix1;
            }
            set
            {
                appendix1 = value;
            }
        }

        private ProductAppendix2 appendix2 = null;
        public ProductAppendix2 Appendix2
        {
            get
            {
                return appendix2;
            }
            set
            {
                appendix2 = value;
            }
        }

        private ProductAppendix3 appendix3 = null;
        public ProductAppendix3 Appendix3
        {
            get
            {
                return appendix3;
            }
            set
            {
                appendix3 = value;
            }
        }
        #endregion

        #region ToolBar
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

        private void SetCaptions()
        {
            if (this.Appendix1 != null)
            {
                this.Text += " [" + RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix1") + "] ";
            }

            if (this.Appendix2 != null)
            {
                this.Text += " [" + RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix2") + "] ";
            }

            if (this.Appendix3 != null)
            {
                this.Text += " [" + RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix3") + "] ";
            }
        }

        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", "Refresh");
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (AppendixId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
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
                        this.Update();
                        break;
                    case "save":
                        Save();
                        LoadAppendix();
                        this.Update();
                        break;
                    case "refresh":
                        this.Update();
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
            cboParentAppendix.DataSource = null;

            cboParentAppendix.Items.Clear();

            if (Appendix1 != null)
            {
                cboParentAppendix.DataSource = GetA1List();
                cboParentAppendix.DisplayMember = "Appendix1Code";
                cboParentAppendix.ValueMember = "Appendix1Id";
            }
            else if (Appendix2 != null)
            {
                cboParentAppendix.DataSource = GetA2List();
                cboParentAppendix.DisplayMember = "Appendix2Code";
                cboParentAppendix.ValueMember = "Appendix2Id";
            }
            else if (Appendix3 != null)
            {
                cboParentAppendix.DataSource = GetA3List();
                cboParentAppendix.DisplayMember = "Appendix3Code";
                cboParentAppendix.ValueMember = "Appendix3Id";
            }

            cboParentAppendix.SelectedIndex = cboParentAppendix.Items.Count - 1;
        }

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
        #endregion

        #region Save

        private void Save()
        {
            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtCode, string.Empty);

                SaveAppendix1();
                SaveAppendix2();
                SaveAppendix3();

                if (this.AppendixId != System.Guid.Empty)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultAppendixList>();
                }
            }
        }

        private bool SaveAppendix1()
        {
            if (this.Appendix1 != null)
            {
                if (this.AppendixId != System.Guid.Empty)
                {
                    this.Appendix1 = ProductAppendix1.Load(this.AppendixId);
                }
                else
                {
                    string sql = "Appendix1Code = '" + txtCode.Text + "'";
                    ProductAppendix1Collection oA1 = ProductAppendix1.LoadCollection(sql);
                    if (oA1.Count > 0)
                    {
                        errorProvider.SetError(txtCode, string.Format(Resources.Common.DuplicatedCode, RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix1")));
                        return false;
                    }
                    else
                    {
                        this.Appendix1.Appendix1Code = txtCode.Text;
                        this.Appendix1.CreatedBy = Common.Config.CurrentUserId;
                        this.Appendix1.CreatedOn = DateTime.Now;
                        errorProvider.SetError(txtCode, string.Empty);
                    }
                }

                this.appendix1.Appendix1Initial = txtInitial.Text;
                this.Appendix1.Appendix1Name = txtName.Text;
                this.Appendix1.Appendix1Name_Chs = txtNameChs.Text;
                this.Appendix1.Appendix1Name_Cht = txtNameCht.Text;
                this.Appendix1.ParentAppendix = (cboParentAppendix.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentAppendix.SelectedValue.ToString());

                this.Appendix1.ModifiedBy = Common.Config.CurrentUserId;
                this.Appendix1.ModifiedOn = DateTime.Now;
                this.Appendix1.Save();

                this.AppendixId = this.Appendix1.Appendix1Id;

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SaveAppendix2()
        {
            if (this.Appendix2 != null)
            {
                if (this.AppendixId != System.Guid.Empty)
                {
                    this.Appendix2 = ProductAppendix2.Load(this.AppendixId);
                }
                else
                {
                    string sql = "Appendix2Code = '" + txtCode.Text + "'";
                    ProductAppendix2Collection oA2 = ProductAppendix2.LoadCollection(sql);
                    if (oA2.Count > 0)
                    {
                        errorProvider.SetError(txtCode, string.Format(Resources.Common.DuplicatedCode, RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix2")));
                        return false;
                    }
                    else
                    {
                        this.Appendix2.Appendix2Code = txtCode.Text;
                        this.Appendix2.CreatedBy = Common.Config.CurrentUserId;
                        this.Appendix2.CreatedOn = DateTime.Now;
                        errorProvider.SetError(txtCode, string.Empty);
                    }
                }

                this.appendix2.Appendix2Initial = txtInitial.Text;
                this.Appendix2.Appendix2Name = txtName.Text;
                this.Appendix2.Appendix2Name_Chs = txtNameChs.Text;
                this.Appendix2.Appendix2Name_Cht = txtNameCht.Text;
                this.Appendix2.ParentAppendix = (cboParentAppendix.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentAppendix.SelectedValue.ToString());

                this.Appendix2.ModifiedBy = Common.Config.CurrentUserId;
                this.Appendix2.ModifiedOn = DateTime.Now;
                this.Appendix2.Save();

                this.AppendixId = this.Appendix2.Appendix2Id;

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SaveAppendix3()
        {
            if (this.Appendix3 != null)
            {
                if (this.AppendixId != System.Guid.Empty)
                {
                    this.Appendix3 = ProductAppendix3.Load(this.AppendixId);
                }
                else
                {
                    string sql = "Appendix3Code = '" + txtCode.Text + "'";
                    ProductAppendix3Collection oA3 = ProductAppendix3.LoadCollection(sql);
                    if (oA3.Count > 0)
                    {
                        errorProvider.SetError(txtCode, string.Format(Resources.Common.DuplicatedCode, RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix3")));
                        return false;
                    }
                    else
                    {
                        this.Appendix3.Appendix3Code = txtCode.Text;
                        this.Appendix3.CreatedBy = Common.Config.CurrentUserId;
                        this.Appendix3.CreatedOn = DateTime.Now;
                        errorProvider.SetError(txtCode, string.Empty);
                    }
                }

                this.appendix3.Appendix3Initial = txtInitial.Text;
                this.Appendix3.Appendix3Name = txtName.Text;
                this.Appendix3.Appendix3Name_Chs = txtNameChs.Text;
                this.Appendix3.Appendix3Name_Cht = txtNameCht.Text;
                this.Appendix3.ParentAppendix = (cboParentAppendix.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentAppendix.SelectedValue.ToString());

                this.Appendix3.ModifiedBy = Common.Config.CurrentUserId;
                this.Appendix3.ModifiedOn = DateTime.Now;
                this.Appendix3.Save();

                this.AppendixId = this.Appendix3.Appendix3Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Clear()
        {
            this.Close();
            Type type = null;

            if (this.Appendix1 != null)
            {
                type = Appendix1.GetType();
            }

            if (this.Appendix2 != null)
            {
                type = Appendix2.GetType();
            }

            if (this.Appendix3 != null)
            {
                type = Appendix3.GetType();
            }

            ProductAppendixWizard wizAppendix = new ProductAppendixWizard(type);
            wizAppendix.ShowDialog();
        }

        #endregion

        #region Load

        private void LoadAppendix()
        {
            LoadAppendix1();
            LoadAppendix2();
            LoadAppendix3();
        }

        private void LoadAppendix1()
        {
            this.Appendix1 = ProductAppendix1.Load(this.AppendixId);
            if (this.Appendix1 != null)
            {
                this.AppendixId = this.Appendix1.Appendix1Id;

                FillParentAppendixList();

                txtCode.Text = this.Appendix1.Appendix1Code;
                txtInitial.Text = this.Appendix1.Appendix1Initial;
                txtName.Text = this.Appendix1.Appendix1Name;
                txtNameChs.Text = this.Appendix1.Appendix1Name_Chs;
                txtNameCht.Text = this.Appendix1.Appendix1Name_Cht;
                cboParentAppendix.SelectedValue = this.Appendix1.ParentAppendix;

                txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix1.ModifiedOn, false);
                txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix1.CreatedOn, false);
                txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(this.Appendix1.ModifiedBy);

                SetCtrlEditable();
            }
        }

        private void LoadAppendix2()
        {
            this.Appendix2 = ProductAppendix2.Load(this.AppendixId);
            if (this.Appendix2 != null)
            {
                this.AppendixId = this.Appendix2.Appendix2Id;

                FillParentAppendixList();

                txtCode.Text = this.Appendix2.Appendix2Code;
                txtInitial.Text = this.Appendix2.Appendix2Initial;
                txtName.Text = this.Appendix2.Appendix2Name;
                txtNameChs.Text = this.Appendix2.Appendix2Name_Chs;
                txtNameCht.Text = this.Appendix2.Appendix2Name_Cht;
                cboParentAppendix.SelectedValue = this.Appendix2.ParentAppendix;

                txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix2.ModifiedOn, false);
                txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix2.CreatedOn, false);
                txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(this.Appendix2.ModifiedBy);

                SetCtrlEditable();
            }
        }

        private void LoadAppendix3()
        {
            this.Appendix3 = ProductAppendix3.Load(this.AppendixId);
            if (this.Appendix3 != null)
            {
                this.AppendixId = this.Appendix3.Appendix3Id;

                FillParentAppendixList();

                txtCode.Text = this.Appendix3.Appendix3Code;
                txtInitial.Text = this.Appendix3.Appendix3Initial;
                txtName.Text = this.Appendix3.Appendix3Name;
                txtNameChs.Text = this.Appendix3.Appendix3Name_Chs;
                txtNameCht.Text = this.Appendix3.Appendix3Name_Cht;
                cboParentAppendix.SelectedValue = this.Appendix3.ParentAppendix;

                txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix3.ModifiedOn, false);
                txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(this.Appendix3.CreatedOn, false);
                txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(this.Appendix3.ModifiedBy);

                SetCtrlEditable();
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            try
            {
                if (this.Appendix1 != null)
                {
                    this.Appendix1.Delete();
                }

                if (this.Appendix2 != null)
                {
                    this.Appendix2.Delete();
                }

                if (this.Appendix3 != null)
                {
                    this.Appendix3.Delete();
                }
            }
            catch
            {
                MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
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