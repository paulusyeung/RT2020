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
using RT2020.Helper;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class JobTitleWizard : Form
    {
        #region Properties
        private Guid _JobTitleId = System.Guid.Empty;
        public Guid JobTitleId
        {
            get { return _JobTitleId; }
            set { _JobTitleId = value; }
        }
        #endregion

        public JobTitleWizard()
        {
            InitializeComponent();
        }

        private void JobTitleWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            BindJobTitleList();
            SetCtrlEditable();
            FillParentJobTitleList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("jobTitle.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colJobTitleCode.Text = WestwindHelper.GetWord("jobTitle.code", "Model");
            colJobTitleName.Text = WestwindHelper.GetWord("jobTitle.name", "Model");
            colJobTitleNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colJobTitleNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblJobTitleCode.Text = WestwindHelper.GetWordWithColon("jobTitle.code", "Model");
            lblJobTitleName.Text = WestwindHelper.GetWordWithColon("jobTitle.name", "Model");
            lblJobTitleNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblJobTitleNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentJobTitle.Text = WestwindHelper.GetWordWithColon("jobTitle.parent", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colJobTitleCode.TextAlign = HorizontalAlignment.Left;
            colJobTitleCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colJobTitleName.TextAlign = HorizontalAlignment.Left;
            colJobTitleName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colJobTitleNameAlt1.TextAlign = HorizontalAlignment.Left;
            colJobTitleNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colJobTitleNameAlt2.TextAlign = HorizontalAlignment.Left;
            colJobTitleNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblJobTitleNameAlt2.Visible = txtJobTitleNameAlt2.Visible = false;
                    colJobTitleNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblJobTitleNameAlt1.Visible = lblJobTitleNameAlt2.Visible = txtJobTitleNameAlt1.Visible = txtJobTitleNameAlt2.Visible = false;
                    colJobTitleNameAlt1.Visible = colJobTitleNameAlt2.Visible = false;
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

            if (_JobTitleId == System.Guid.Empty)
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
                            BindJobTitleList();
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

        #region JobTitle Code
        private void SetCtrlEditable()
        {
            txtJobTitleCode.BackColor = (_JobTitleId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtJobTitleCode.ReadOnly = (_JobTitleId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtJobTitleCode, string.Empty);
        }

        private void Clear()
        {
            txtJobTitleCode.Text = txtJobTitleName.Text = txtJobTitleNameAlt1.Text = txtJobTitleNameAlt2.Text = string.Empty;
            cboParentJobTitle.SelectedIndex = 0;

            _JobTitleId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentJobTitleList()
        {
            string sql = "JobTitleId NOT IN ('" + _JobTitleId.ToString() + "')";
            ModelEx.JobTitleEx.LoadCombo(ref cboParentJobTitle, "JobTitleCode", true, true, "", sql);
        }
        #endregion

        #region Binding
        private void BindJobTitleList()
        {
            this.lvJobTitleList.ListViewItemSorter = new ListViewItemSorter(lvJobTitleList);
            this.lvJobTitleList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.JobTitle.OrderBy(x => x.JobTitleCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvJobTitleList.Items.Add(item.JobTitleId.ToString());
                    objItem.SubItems.Add(iCount.ToString());
                    objItem.SubItems.Add(item.JobTitleCode);
                    objItem.SubItems.Add(item.JobTitleName);
                    objItem.SubItems.Add(item.JobTitleName_Chs);
                    objItem.SubItems.Add(item.JobTitleName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtJobTitleCode, string.Empty);
            errorProvider.SetError(txtJobTitleCode, string.Empty);

            #region Job Title Code 唔可以吉
            if (txtJobTitleCode.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtJobTitleCode, "Cannot be blank!");
                result = false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            if (_JobTitleId == Guid.Empty)
            {
                if (ModelEx.JobTitleEx.IsJobTitleCodeInUse(txtJobTitleCode.Text.Trim()))
                {
                    errorProvider.SetError(txtJobTitleCode, "Job Title Code in use");
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
                var jt = ctx.JobTitle.Find(_JobTitleId);

                if (jt == null)
                {
                    jt = new EF6.JobTitle();
                    jt.JobTitleId = new Guid();

                    ctx.JobTitle.Add(jt);
                    jt.JobTitleCode = txtJobTitleCode.Text;
                }
                jt.JobTitleName = txtJobTitleName.Text;
                jt.JobTitleName_Chs = txtJobTitleNameAlt1.Text;
                jt.JobTitleName_Cht = txtJobTitleNameAlt2.Text;
                if ((Guid)cboParentJobTitle.SelectedValue != Guid.Empty) jt.ParentJobTitle = (Guid)cboParentJobTitle.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private bool Delete()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var jt = ctx.JobTitle.Find(_JobTitleId);
                    if (jt != null)
                    {
                        ctx.JobTitle.Remove(jt);
                        ctx.SaveChanges();

                        result = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }

            return result;
        }

        private void lvJobTitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvJobTitleList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvJobTitleList.SelectedItem.Text, out id))
                {
                    _JobTitleId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var jt = ctx.JobTitle.Find(_JobTitleId);
                        if (jt != null)
                        {
                            FillParentJobTitleList();

                            txtJobTitleCode.Text = jt.JobTitleCode;
                            txtJobTitleName.Text = jt.JobTitleName;
                            txtJobTitleNameAlt1.Text = jt.JobTitleName_Chs;
                            txtJobTitleNameAlt2.Text = jt.JobTitleName_Cht;

                            cboParentJobTitle.SelectedValue = jt.ParentJobTitle.HasValue ? jt.ParentJobTitle.Value : Guid.Empty;

                            SetCtrlEditable();
                            SetToolBar();
                        }
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
                    BindJobTitleList();
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