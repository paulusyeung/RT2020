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
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

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
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT JobTitleId,  ROW_NUMBER() OVER (ORDER BY JobTitleCode) AS rownum, ");
            sql.Append(" JobTitleCode, JobTitleName, JobTitleName_Chs, JobTitleName_Cht ");
            sql.Append(" FROM JobTitle ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvJobTitleList.Items.Add(reader.GetGuid(0).ToString()); // JobTitleId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // JobTitleCode
                    objItem.SubItems.Add(reader.GetString(3)); // JobTitle Name
                    objItem.SubItems.Add(reader.GetString(4)); // JobTitle Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // JobTitle Name Cht

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