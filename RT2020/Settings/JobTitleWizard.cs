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
        public JobTitleWizard()
        {
            InitializeComponent();
            SetToolBar();
            BindJobTitleList();
            SetCtrlEditable();
            FillParentJobTitleList();
        }

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

            if (JobTitleId == System.Guid.Empty)
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
                        SetCtrlEditable();
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
                        BindJobTitleList();
                        this.Update();
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
            txtJobTitleCode.BackColor = (this.JobTitleId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtJobTitleCode.ReadOnly = (this.JobTitleId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtJobTitleCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentJobTitleList()
        {
            string sql = "JobTitleId NOT IN ('" + this.JobTitleId.ToString() + "')";
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
            bool result = false;

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtJobTitleCode, string.Empty);
            if (txtJobTitleCode.Text.Length == 0)
            {
                errorProvider.SetError(txtJobTitleCode, "Cannot be blank!");
                result = false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            errorProvider.SetError(txtJobTitleCode, string.Empty);
            if (this.JobTitleId == System.Guid.Empty && ModelEx.JobTitleEx.IsJobTitleCodeInUse(txtJobTitleCode.Text.Trim()))
            {
                errorProvider.SetError(txtJobTitleCode, "Job Title Code in use");
                result = false;
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var jt = ctx.JobTitle.Find(this.JobTitleId);

                if (jt == null)
                {
                    jt = new EF6.JobTitle();
                    jt.JobTitleId = new Guid();

                    ctx.JobTitle.Add(jt);
                    jt.JobTitleCode = txtJobTitleCode.Text;
                }
                jt.JobTitleName = txtJobTitleName.Text;
                jt.JobTitleName_Chs = txtJobTitleNameChs.Text;
                jt.JobTitleName_Cht = txtJobTitleNameCht.Text;
                jt.ParentJobTitle = (cboParentJobTitle.SelectedValue == null) ? Guid.Empty : new Guid(cboParentJobTitle.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            JobTitleWizard wizJobTitle = new JobTitleWizard();
            wizJobTitle.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid JobTitleId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }
        #endregion

        private bool Delete()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var jt = ctx.JobTitle.Find(this.JobTitleId);
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
                    this.JobTitleId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var jt = ctx.JobTitle.Find(this.JobTitleId);
                        if (jt != null)
                        {
                            FillParentJobTitleList();

                            txtJobTitleCode.Text = jt.JobTitleCode;
                            txtJobTitleName.Text = jt.JobTitleName;
                            txtJobTitleNameChs.Text = jt.JobTitleName_Chs;
                            txtJobTitleNameCht.Text = jt.JobTitleName_Cht;

                            cboParentJobTitle.SelectedValue = jt.ParentJobTitle;

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