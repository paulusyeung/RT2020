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

#endregion

namespace RT2020.Settings
{
    public partial class SmartTag4StaffWizard : Form
    {
        public SmartTag4StaffWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            BindTagList();
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

            if (TagId == System.Guid.Empty)
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
                            BindTagList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindTagList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SmartTag4Staff Code
        private void SetCtrlEditable()
        {
            txtTagCode.BackColor = (this.TagId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtTagCode.ReadOnly = (this.TagId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtTagCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }
        #endregion

        #region Binding
        private void BindTagList()
        {
            this.lvTagList.ListViewItemSorter = new ListViewItemSorter(lvTagList);
            this.lvTagList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT TagId,  ROW_NUMBER() OVER (ORDER BY TagCode) AS rownum, ");
            sql.Append(" TagCode, TagName, TagName_Chs, TagName_Cht ");
            sql.Append(" FROM SmartTag4Staff ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvTagList.Items.Add(reader.GetGuid(0).ToString()); // TagId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // TagCode
                    objItem.SubItems.Add(reader.GetString(3)); // SmartTag4Staff Name
                    objItem.SubItems.Add(reader.GetString(4)); // SmartTag4Staff Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // SmartTag4Staff Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Tag Code 唔可以吉
            errorProvider.SetError(txtTagCode, string.Empty);
            if (txtTagCode.Text.Length == 0)
            {
                errorProvider.SetError(txtTagCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Tag Code 係咪 in use
            errorProvider.SetError(txtTagCode, string.Empty);
            if (this.TagId == Guid.Empty && ModelEx.SmartTag4StaffEx.IsTagCodeInUse(txtTagCode.Text.Trim()))
            {
                errorProvider.SetError(txtTagCode, "Tag Code in use");
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
                var item = ctx.SmartTag4Staff.Find(this.TagId);

                if (item == null)
                {
                    item = new EF6.SmartTag4Staff();
                    item.TagId = Guid.NewGuid();
                    item.TagCode = txtTagCode.Text;

                    ctx.SmartTag4Staff.Add(item);
                }
                item.TagName = txtTagName.Text;
                item.TagName_Chs = txtTagNameChs.Text;
                item.TagName_Cht = txtTagNameCht.Text;
                item.Priority = Convert.ToInt32(txtPriority.Text);

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            SmartTag4StaffWizard wizStaffTag = new SmartTag4StaffWizard();
            wizStaffTag.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid TagId
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

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.SmartTag4Staff.Find(this.TagId);
                    if (item != null)
                    {
                        ctx.SmartTag4Staff.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTagList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvTagList.SelectedItem.Text, out id))
                {
                    this.TagId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var oTag = ctx.SmartTag4Staff.Find(id);
                        if (oTag != null)
                        {
                            txtTagCode.Text = oTag.TagCode;
                            txtTagName.Text = oTag.TagName;
                            txtTagNameChs.Text = oTag.TagName_Chs;
                            txtTagNameCht.Text = oTag.TagName_Cht;
                            txtPriority.Text = oTag.Priority.ToString();

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
                Delete();

                BindTagList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}