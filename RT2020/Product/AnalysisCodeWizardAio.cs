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
    public partial class AnalysisCodeWizardAio : Form
    {
        #region Properties
        private Guid _CodeId = Guid.Empty;
        public Guid AnalysisCodeId
        {
            get { return _CodeId; }
            set { _CodeId = value; }
        }
        #endregion

        public AnalysisCodeWizardAio()
        {
            InitializeComponent();
        }

        private void AnalysisCodeWizardAio_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            FillParentCodeList();

            SetToolBar();
            BindList();
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

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colCode.Text = WestwindHelper.GetWord("posAnalysisCode.code", "Model");
            colType.Text = WestwindHelper.GetWord("posAnalysisCode.type", "Model");
            colInitial.Text = WestwindHelper.GetWord("posAnalysisCode.initial", "Model");
            colName.Text = WestwindHelper.GetWord("posAnalysisCode.name", "Model");
            colNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
        }

        private void SetAttributes()
        {
            lvList.Dock = DockStyle.Fill;

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
                    lblNameAlt1.Visible = lblNameAlt2.Visible = txtNameAlt1.Visible = txtNameAlt2.Visible = false;
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

            if (_CodeId == Guid.Empty)
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
                        ClearForm();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            ClearForm();
                            BindList();
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

        #region SetCtrlEditable ClearError Clear
        private void SetCtrlEditable()
        {
            txtCode.BackColor = (_CodeId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCode.ReadOnly = (_CodeId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCode, string.Empty);
            errorProvider.SetError(txtInitial, string.Empty);
        }

        private void ClearForm()
        {
            txtCode.Text = txtType.Text = txtInitial.Text = txtName.Text = txtNameAlt1.Text = txtNameAlt2.Text = txtInitial.Text = string.Empty;

            _CodeId = Guid.Empty;
            SetCtrlEditable();
            FillParentCodeList();
        }
        #endregion

        #region Fill Combo List
        private void FillParentCodeList()
        {
            string sql = "ParentCode IS NULL OR ParentCode = '" + Guid.Empty.ToString() + "'";
            string[] orderBy = new string[] { "AnalysisCode" };

            PosAnalysisCodeEx.LoadCombo(ref cboParentAnalysisCode, "AnalysisCode", false, true, "", sql, orderBy);
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

        #region Binding
        private void BindList()
        {
            this.lvList.ListViewItemSorter = new Sorter();
            this.lvList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PosAnalysisCode.Where(x => x.Retired == false).OrderBy(x => x.AnalysisCode).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvList.Items.Add(item.AnalysisCode);
                    objItem.SubItems.Add(item.AnalysisCodeId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.AnalysisType);
                    objItem.SubItems.Add(item.CodeInitial);
                    objItem.SubItems.Add(item.CodeName);
                    objItem.SubItems.Add(item.CodeName_Chs);
                    objItem.SubItems.Add(item.CodeName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtCode, string.Empty);

            #region Analysis Code 唔可以吉
            if (txtCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCode, "Cannot be blank!");
                errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                result = false;
            }
            #endregion

            #region 新增，要 check Analysis Code 係咪 in use
            if (_CodeId == Guid.Empty)
            {
                if (PosAnalysisCodeEx.IsAnalysisCodeInUse(txtCode.Text.Trim()))
                {
                    errorProvider.SetError(txtCode, "Analysis Code in use");
                    errorProvider.SetIconAlignment(txtCode, ErrorIconAlignment.TopLeft);
                    result = false;
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
                var item = ctx.PosAnalysisCode.Find(this.AnalysisCodeId);
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

                this.AnalysisCodeId = item.AnalysisCodeId;
                Helper.DesktopHelper.RefreshMainList<AnalysisCodeList>();

                result = true;
            }

            return result;
        }
        #endregion

        private void Delete()
        {
            bool result = false;

            result = PosAnalysisCodeEx.Delete(_CodeId);
            MessageBox.Show(result ? "Record Removed" : "Can't Delete Record...", "Delete Result");
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvList.SelectedItem != null)
            {
                var item = PosAnalysisCodeEx.GetByCode(lvList.SelectedItem.Text);

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
                SetToolBar();
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindList();
                ClearForm();
                SetCtrlEditable();
            }
        }
    }
}