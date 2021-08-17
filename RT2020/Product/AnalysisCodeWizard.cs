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

using Westwind.Globalization;
using RT2020.Helper;
using System.Linq;

#endregion

namespace RT2020.Product
{
    public partial class AnalysisCodeWizard : Form
    {
        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _CodeId = System.Guid.Empty;
        public Guid AnalysisCodeId
        {
            get { return _CodeId; }
            set { _CodeId = value; }
        }
        #endregion

        public AnalysisCodeWizard()
        {
            InitializeComponent();
        }

        private void AnalysisCodeWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            VerifyFixedAnalysisCode();
            FillParentCodeList();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadAnalysisCode();
                    break;
            }
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("posAnalysisCode.setup", "Model");

            lblCode.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.code", "Model");
            lblName.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.name", "Model");
            lblNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblInitial.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.initial", "Model");
            lblType.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.type", "Model");
            lblParentAnalysisCode.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.parent", "Model");

            lblMandatory.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.mandatory", "Model");
            lblDownloadToPOS.Text = WestwindHelper.GetWordWithColon("posAnalysisCode.downloadToPos", "Model");
        }

        private void SetAttributes()
        {
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblNameAlt2.Visible = txtNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblNameAlt1.Visible = lblNameAlt2.Visible = txtNameAlt1.Visible = txtNameAlt2.Visible = false;
                    break;
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
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (AnalysisCodeId == System.Guid.Empty)
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
                        if (Verify())
                        {
                            Save();
                            LoadAnalysisCode();
                            ClearForm();
                        }
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

        private void ClearForm()
        {
            txtCode.Text = txtType.Text = txtInitial.Text = txtName.Text = txtNameAlt1.Text = txtNameAlt2.Text = string.Empty;
            chkMandatory.Checked = chkDownloadToPoS.Checked = false;

            _EditMode = EnumHelper.EditMode.Add;
            _CodeId = Guid.Empty;

            SetCtrlEditable();
            FillParentCodeList();
        }
        #endregion

        #region Fill Combo List
        private void FillParentCodeList()
        {
            string sql = "ParentCode IS NULL OR ParentCode = '" + System.Guid.Empty.ToString() + "'";
            string[] orderBy = new string[] { "AnalysisCode" };

            ModelEx.PosAnalysisCodeEx.LoadCombo(ref cboParentAnalysisCode, "AnalysisCode", false, true, "", sql, orderBy);
        }

        private void VerifyFixedAnalysisCode()
        {
            int fixedCount = 10;
            string fixedAnalysisCode = string.Empty;

            using (var ctx = new EF6.RT2020Entities())
            {
                for (int i = 1; i <= fixedCount; i++)
                {
                    fixedAnalysisCode = i.ToString().PadLeft(2, '0');

                    //string sql = "AnalysisCode = '" + fixedAnalysisCode + "'";
                    var oACode = ctx.PosAnalysisCode.Where(x => x.AnalysisCode == fixedAnalysisCode).FirstOrDefault();
                    if (oACode == null)
                    {
                        oACode = new EF6.PosAnalysisCode();
                        oACode.AnalysisCodeId = Guid.NewGuid();
                        oACode.AnalysisCode = fixedAnalysisCode;
                        oACode.AnalysisType = fixedAnalysisCode;
                        oACode.CodeInitial = fixedAnalysisCode;
                        oACode.CodeName = fixedAnalysisCode;
                        oACode.CodeName_Chs = fixedAnalysisCode;
                        oACode.CodeName_Cht = fixedAnalysisCode;
                        oACode.Mandatory = true;
                        oACode.DownloadToPOS = false;
                        oACode.CreatedBy = ConfigHelper.CurrentUserId;
                        oACode.CreatedOn = DateTime.Now;
                        oACode.ModifiedBy = ConfigHelper.CurrentUserId;
                        oACode.ModifiedOn = DateTime.Now;

                        ctx.PosAnalysisCode.Add(oACode);
                    }
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

            //string sql = "AnalysisCode = '" + txtCode.Text + "'";
            //PosAnalysisCode oAnalysisCode = PosAnalysisCode.LoadWhere(sql);
            if (ModelEx.PosAnalysisCodeEx.IsAnalysisCodeInUse(txtCode.Text))
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
            using (var ctx = new EF6.RT2020Entities())
            { 
                var item = ctx.PosAnalysisCode.Find(_CodeId);
                if (item == null)
                {
                    item = new EF6.PosAnalysisCode();

                    item.AnalysisCodeId = Guid.NewGuid();
                    item.AnalysisCode = txtCode.Text;

                    item.CreatedBy = ConfigHelper.CurrentUserId;
                    item.CreatedOn = DateTime.Now;

                    ctx.PosAnalysisCode.Add(item);
                    _CodeId = item.AnalysisCodeId;
                }
                item.AnalysisType = txtType.Text;
                item.CodeInitial = txtInitial.Text;
                item.CodeName = txtName.Text;
                item.CodeName_Chs = txtNameAlt1.Text;
                item.CodeName_Cht = txtNameAlt2.Text;
                if ((Guid)cboParentAnalysisCode.SelectedValue != Guid.Empty) item.ParentCode = (Guid)cboParentAnalysisCode.SelectedValue;
                item.DownloadToPOS = chkDownloadToPoS.Checked;
                item.Mandatory = chkMandatory.Checked;

                item.ModifiedBy = ConfigHelper.CurrentUserId;
                item.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();

                // log activity (New Record)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Create, item.ToString());

                SystemInfoHelper.Settings.RefreshMainList<AnalysisCodeList>();
            }
        }
        #endregion

        #region Load
        private void LoadAnalysisCode()
        {
            var item = ModelEx.PosAnalysisCodeEx.Get(this.AnalysisCodeId);
            if (item != null)
            {
                txtCode.Text = item.AnalysisCode;
                txtType.Text = item.AnalysisType;
                txtInitial.Text = item.CodeInitial;
                txtName.Text = item.CodeName;
                txtNameAlt1.Text = item.CodeName_Chs;
                txtNameAlt2.Text = item.CodeName_Cht;
                cboParentAnalysisCode.SelectedValue = item.ParentCode.HasValue ? item.ParentCode : Guid.Empty;
                chkDownloadToPoS.Checked = item.DownloadToPOS;
                chkMandatory.Checked = item.Mandatory;
                
                //! HACK: 點解頂級唔俾降級/唔俾 delete？
                if (!item.ParentCode.HasValue)
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
            using (var ctx = new EF6.RT2020Entities())
            {
                var oAnalysisCode = ctx.PosAnalysisCode.Find(this.AnalysisCodeId);
                if (oAnalysisCode != null)
                {
                    try
                    {
                        ctx.PosAnalysisCode.Remove(oAnalysisCode);
                        ctx.SaveChanges();
                        // log activity
                        RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oAnalysisCode.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                    }
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