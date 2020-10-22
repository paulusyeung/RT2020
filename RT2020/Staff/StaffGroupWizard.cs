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

namespace RT2020.Staff
{
    public partial class StaffGroupWizard : Form
    {
        public StaffGroupWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentGradeList();
            BindStaffGroupList();
            SetCtrlEditable();
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

            if (StaffGroupId == System.Guid.Empty)
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
                        if (Save())
                        {
                            Clear();
                            BindStaffGroupList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindStaffGroupList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region StaffGroup Code
        private void SetCtrlEditable()
        {
            txtStaffGroupCode.BackColor = (this.StaffGroupId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtStaffGroupCode.ReadOnly = (this.StaffGroupId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtStaffGroupCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentGradeList()
        {
            cboParentGrade.DataSource = null;
            cboParentGrade.Items.Clear();

            string sql = "GroupId NOT IN ('" + this.StaffGroupId.ToString() + "')";
            string[] orderBy = new string[] { "GradeCode" };
            StaffGroupCollection oStaffGroupList = StaffGroup.LoadCollection(sql, orderBy, true);
            oStaffGroupList.Add(new StaffGroup());
            cboParentGrade.DataSource = oStaffGroupList;
            cboParentGrade.DisplayMember = "GradeCode";
            cboParentGrade.ValueMember = "GroupId";

            cboParentGrade.SelectedIndex = cboParentGrade.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindStaffGroupList()
        {
            this.lvStaffGroupList.ListViewItemSorter = new ListViewItemSorter(lvStaffGroupList);
            this.lvStaffGroupList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT GroupId,  ROW_NUMBER() OVER (ORDER BY GradeCode) AS rownum, ");
            sql.Append(" GradeCode, GradeName, GradeName_Chs, GradeName_Cht ");
            sql.Append(" FROM StaffGroup ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvStaffGroupList.Items.Add(reader.GetGuid(0).ToString()); // StaffGroupId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // StaffGroupCode
                    objItem.SubItems.Add(reader.GetString(3)); // StaffGroup Name
                    objItem.SubItems.Add(reader.GetString(4)); // StaffGroup Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // StaffGroup Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "GradeCode = '" + txtStaffGroupCode.Text.Trim() + "'";
            StaffGroupCollection groupList = StaffGroup.LoadCollection(sql);
            if (groupList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Save()
        {
            if (txtStaffGroupCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStaffGroupCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtStaffGroupCode, string.Empty);

                StaffGroup oStaffGroup = StaffGroup.Load(this.StaffGroupId);
                if (oStaffGroup == null)
                {
                    oStaffGroup = new StaffGroup();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtStaffGroupCode, string.Format(Resources.Common.DuplicatedCode, "Group Code"));
                        return false;
                    }
                    else
                    {
                        oStaffGroup.GradeCode = txtStaffGroupCode.Text;
                        errorProvider.SetError(txtStaffGroupCode, string.Empty);
                    }
                }
                oStaffGroup.GradeName = txtStaffGroupName.Text;
                oStaffGroup.GradeName_Chs = txtStaffGroupNameChs.Text;
                oStaffGroup.GradeName_Cht = txtStaffGroupNameCht.Text;
                oStaffGroup.ParentGrade = (cboParentGrade.SelectedValue == null)? System.Guid.Empty:new System.Guid(cboParentGrade.SelectedValue.ToString());

                oStaffGroup.CanRead = chkCanRead.Checked;
                oStaffGroup.CanWrite = chkCanWrite.Checked;
                oStaffGroup.CanDelete = chkCanDelete.Checked;
                oStaffGroup.CanPost = chkCanPost.Checked;

                oStaffGroup.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            StaffGroupWizard wizGroup = new StaffGroupWizard();
            wizGroup.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid StaffGroupId
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
            StaffGroup oStaffGroup = StaffGroup.Load(this.StaffGroupId);
            if (oStaffGroup != null)
            {
                try
                {
                    oStaffGroup.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvStaffGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffGroupList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvStaffGroupList.SelectedItem.Text))
                {
                    StaffGroup oStaffGroup = StaffGroup.Load(new System.Guid(lvStaffGroupList.SelectedItem.Text));
                    if (oStaffGroup != null)
                    {
                        this.StaffGroupId = oStaffGroup.GroupId;

                        FillParentGradeList();

                        txtStaffGroupCode.Text = oStaffGroup.GradeCode;
                        txtStaffGroupName.Text = oStaffGroup.GradeName;
                        txtStaffGroupNameChs.Text = oStaffGroup.GradeName_Chs;
                        txtStaffGroupNameCht.Text = oStaffGroup.GradeName_Cht;
                        cboParentGrade.SelectedValue = oStaffGroup.ParentGrade;

                        chkCanRead.Checked = oStaffGroup.CanRead;
                        chkCanWrite.Checked = oStaffGroup.CanWrite;
                        chkCanDelete.Checked = oStaffGroup.CanDelete;
                        chkCanPost.Checked = oStaffGroup.CanPost;

                        SetCtrlEditable();
                        SetToolBar();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindStaffGroupList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}