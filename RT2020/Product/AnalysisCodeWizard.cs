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
using Westwind.Globalization;
using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class AnalysisCodeWizard : Form
    {
        public AnalysisCodeWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            VerifyFixedAnalysisCode();
            FillParentCodeList();
        }

        public AnalysisCodeWizard(Guid analysisCodeId)
        {
            InitializeComponent();
            this.AnalysisCodeId = analysisCodeId;
            SetCtrlEditable();
            SetToolBar();
            VerifyFixedAnalysisCode();
            FillParentCodeList();
            LoadAnalysisCode();
        }

        #region Properties
        private Guid analysisCodeId = System.Guid.Empty;
        public Guid AnalysisCodeId
        {
            get
            {
                return analysisCodeId;
            }
            set
            {
                analysisCodeId = value;
            }
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            var locale = CookieHelper.CurrentLocaleId;

            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", DbRes.T("edit.new", "General", locale));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", DbRes.T("edit.save", "General", locale));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", DbRes.T("edit.delete", "General", locale));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (AnalysisCodeId == System.Guid.Empty)
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
                        break;
                    case "save":
                        Save();
                        LoadAnalysisCode();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region AnalysisCode Code
        private void SetCtrlEditable()
        {
            txtCode.BackColor = (this.AnalysisCodeId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCode.ReadOnly = (this.AnalysisCodeId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentCodeList()
        {
            cboParentAnalysisCode.Items.Clear();

            string sql = "ParentCode IS NULL OR ParentCode = '" + System.Guid.Empty.ToString() + "'";
            string[] orderBy = new string[] { "AnalysisCode" };
            PosAnalysisCodeCollection oAnalysisCodeList = PosAnalysisCode.LoadCollection(sql, orderBy, true);
            cboParentAnalysisCode.DataSource = oAnalysisCodeList;
            cboParentAnalysisCode.DisplayMember = "AnalysisCode";
            cboParentAnalysisCode.ValueMember = "AnalysisCodeId";
        }

        private void VerifyFixedAnalysisCode()
        {
            int fixedCount = 10;
            string fixedAnalysisCode = string.Empty;

            for (int i = 1; i <= fixedCount; i++)
            {
                fixedAnalysisCode = i.ToString().PadLeft(2, '0');

                string sql = "AnalysisCode = '" + fixedAnalysisCode + "'";
                PosAnalysisCode oACode = PosAnalysisCode.LoadWhere(sql);
                if (oACode == null)
                {
                    oACode = new PosAnalysisCode();
                    oACode.AnalysisCode = fixedAnalysisCode;
                    oACode.AnalysisType = fixedAnalysisCode;
                    oACode.CodeInitial = fixedAnalysisCode;
                    oACode.CodeName = fixedAnalysisCode;
                    oACode.CodeName_Chs = fixedAnalysisCode;
                    oACode.CodeName_Cht = fixedAnalysisCode;
                    oACode.Mandatory = true;
                    oACode.DownloadToPOS = false;
                    oACode.CreatedBy = Common.Config.CurrentUserId;
                    oACode.CreatedOn = DateTime.Now;
                    oACode.ModifiedBy = Common.Config.CurrentUserId;
                    oACode.ModifiedOn = DateTime.Now;
                    oACode.Save();
                }
            }
        }
        #endregion

        #region Save
        private bool Verify()
        {
            bool result = true;

            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
                result = false;
            }
            else
            {
                errorProvider.SetError(txtCode, string.Empty);
            }

            string sql = "AnalysisCode = '" + txtCode.Text + "'";
            PosAnalysisCode oAnalysisCode = PosAnalysisCode.LoadWhere(sql);
            if (oAnalysisCode != null && this.AnalysisCodeId == System.Guid.Empty)
            {
                result = false;
                errorProvider.SetError(txtCode, "Duplicated Analysis Code!");
            }
            else
            {
                errorProvider.SetError(txtCode, string.Empty);
            }

            return result;
        }

        private void Save()
        {
            if (Verify())
            {
                PosAnalysisCode oAnalysisCode = PosAnalysisCode.Load(this.AnalysisCodeId);
                if (oAnalysisCode == null)
                {
                    oAnalysisCode = new PosAnalysisCode();
                    oAnalysisCode.AnalysisCode = txtCode.Text;

                    oAnalysisCode.CreatedBy = Common.Config.CurrentUserId;
                    oAnalysisCode.CreatedOn = DateTime.Now;
                }
                oAnalysisCode.AnalysisType = txtType.Text;
                oAnalysisCode.CodeInitial = txtInitial.Text;
                oAnalysisCode.CodeName = txtName.Text;
                oAnalysisCode.CodeName_Chs = txtNameChs.Text;
                oAnalysisCode.CodeName_Cht = txtNameCht.Text;
                oAnalysisCode.ParentCode = (cboParentAnalysisCode.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentAnalysisCode.SelectedValue.ToString());
                oAnalysisCode.DownloadToPOS = chkDownloadToPoS.Checked;
                oAnalysisCode.Mandatory = chkMandatory.Checked;

                oAnalysisCode.ModifiedBy = Common.Config.CurrentUserId;
                oAnalysisCode.ModifiedOn = DateTime.Now;

                oAnalysisCode.Save();

                // log activity (New Record)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Create, oAnalysisCode.ToString());

                this.AnalysisCodeId = oAnalysisCode.AnalysisCodeId;
                RT2020.SystemInfo.Settings.RefreshMainList<DefaultAnalysisCodeList>();
            }
        }

        private void Clear()
        {
            this.Close();

            AnalysisCodeWizard wizAnalysisCode = new AnalysisCodeWizard();
            wizAnalysisCode.ShowDialog();
        }
        #endregion

        #region Load
        private void LoadAnalysisCode()
        {
            PosAnalysisCode oAnalysisCode = PosAnalysisCode.Load(this.AnalysisCodeId);
            if (oAnalysisCode != null)
            {
                txtCode.Text = oAnalysisCode.AnalysisCode;
                txtType.Text = oAnalysisCode.AnalysisType;
                txtInitial.Text = oAnalysisCode.CodeInitial;
                txtName.Text = oAnalysisCode.CodeName;
                txtNameChs.Text = oAnalysisCode.CodeName_Chs;
                txtNameCht.Text = oAnalysisCode.CodeName_Cht;
                cboParentAnalysisCode.SelectedValue = oAnalysisCode.ParentCode;
                chkDownloadToPoS.Checked = oAnalysisCode.DownloadToPOS;
                chkMandatory.Checked = oAnalysisCode.Mandatory;

                if (oAnalysisCode.ParentCode == System.Guid.Empty)
                {
                    cboParentAnalysisCode.Enabled = false;
                    this.tbWizardAction.Buttons[3].Enabled = false;
                }
            }

            SetCtrlEditable();
        }
        #endregion

        #region Delete
        private void Delete()
        {
            PosAnalysisCode oAnalysisCode = PosAnalysisCode.Load(this.AnalysisCodeId);
            if (oAnalysisCode != null)
            {
                try
                {
                    oAnalysisCode.Delete();
                    // log activity
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oAnalysisCode.ToString());
                }
                catch
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