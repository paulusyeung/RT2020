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
using System.Data.Entity;
using RT2020.Helper;

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
                        if (IsValid())
                        {
                            Save();
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
            string sql = "GroupId NOT IN ('" + this.StaffGroupId.ToString() + "')";
            string[] orderBy = new string[] { "GradeCode" };
            ModelEx.StaffGroupEx.LoadCombo(ref cboParentGrade, "GroupCode", false, false, "", sql, orderBy);
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

        private bool IsValid()
        {
            bool result = true;

            #region DeptCode 唔可以吉
            errorProvider.SetError(txtStaffGroupCode, string.Empty);
            if (txtStaffGroupCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStaffGroupCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CityCode 係咪 in use
            errorProvider.SetError(txtStaffGroupCode, string.Empty);
            if (ModelEx.StaffDeptEx.IsDeptCodeInUse(txtStaffGroupCode.Text.Trim()))
            {
                errorProvider.SetError(txtStaffGroupCode, "Grade Code in use");
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
                var sg = ctx.StaffGroup.Find(this.StaffGroupId);

                if (sg == null)
                {
                    sg = new EF6.StaffGroup();
                    sg.GroupId = new Guid();
                    sg.GradeCode = txtStaffGroupCode.Text;

                    ctx.StaffGroup.Add(sg);
                }
                sg.GradeName = txtStaffGroupName.Text;
                sg.GradeName_Chs = txtStaffGroupNameChs.Text;
                sg.GradeName_Cht = txtStaffGroupNameCht.Text;
                sg.ParentGrade = ((Guid)cboParentGrade.SelectedValue == Guid.Empty) ? Guid.Empty : (Guid)cboParentGrade.SelectedValue;

                sg.CanRead = chkCanRead.Checked;
                sg.CanWrite = chkCanWrite.Checked;
                sg.CanDelete = chkCanDelete.Checked;
                sg.CanPost = chkCanPost.Checked;

                ctx.SaveChanges();
                result = true;
            }

            return result;
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
            if (!ModelEx.StaffGroupEx.Delete(this.StaffGroupId))
            {
                MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
            }
        }

        private void lvStaffGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffGroupList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvStaffGroupList.SelectedItem.Text, out id))
                {
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var sg = ctx.StaffGroup.Where(x => x.GroupId == id).AsNoTracking().FirstOrDefault();
                        if (sg != null)
                        {
                            this.StaffGroupId = sg.GroupId;

                            FillParentGradeList();

                            txtStaffGroupCode.Text = sg.GradeCode;
                            txtStaffGroupName.Text = sg.GradeName;
                            txtStaffGroupNameChs.Text = sg.GradeName_Chs;
                            txtStaffGroupNameCht.Text = sg.GradeName_Cht;
                            cboParentGrade.SelectedValue = sg.ParentGrade;

                            chkCanRead.Checked = sg.CanRead.Value;
                            chkCanWrite.Checked = sg.CanWrite.Value;
                            chkCanDelete.Checked = sg.CanDelete.Value;
                            chkCanPost.Checked = sg.CanPost.Value;

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

                BindStaffGroupList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}