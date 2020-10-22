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

namespace RT2020.Member
{
    public partial class MemberGroupWizard : Form
    {
        public MemberGroupWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentGroupList();
            BindMemberGroupList();
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

            if (MemberGroupId == System.Guid.Empty)
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
                        if (Save())
                        {
                            Clear();
                            BindMemberGroupList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindMemberGroupList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region MemberGroup Code
        private void SetCtrlEditable()
        {
            txtMemberGroupCode.BackColor = (this.MemberGroupId == System.Guid.Empty) ? SystemInfo.ControlBackColor.RequiredBox : SystemInfo.ControlBackColor.DisabledBox;
            txtMemberGroupCode.ReadOnly = (this.MemberGroupId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtMemberGroupCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentGroupList()
        {
            cboParentGroup.DataSource = null;
            cboParentGroup.Items.Clear();

            string sql = "GroupId NOT IN ('" + this.MemberGroupId.ToString() + "')";
            string[] orderBy = new string[] { "GroupCode" };
            MemberGroupCollection oMemberGroupList = MemberGroup.LoadCollection(sql, orderBy, true);
            oMemberGroupList.Add(new MemberGroup(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentGroup.DataSource = oMemberGroupList;
            cboParentGroup.DisplayMember = "GroupCode";
            cboParentGroup.ValueMember = "GroupId";

            cboParentGroup.SelectedIndex = cboParentGroup.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindMemberGroupList()
        {
            this.lvMemberGroupList.ListViewItemSorter = new ListViewItemSorter(lvMemberGroupList);
            this.lvMemberGroupList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT GroupId,  ROW_NUMBER() OVER (ORDER BY GroupCode) AS rownum, ");
            sql.Append(" GroupCode, GroupName, GroupName_Chs, GroupName_Cht ");
            sql.Append(" FROM MemberGroup ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvMemberGroupList.Items.Add(reader.GetGuid(0).ToString()); // MemberGroupId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // MemberGroupCode
                    objItem.SubItems.Add(reader.GetString(3)); // MemberGroup Name
                    objItem.SubItems.Add(reader.GetString(4)); // MemberGroup Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // MemberGroup Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "GroupCode = '" + txtMemberGroupCode.Text.Trim() + "'";
            MemberGroupCollection grouplist = MemberGroup.LoadCollection(sql);
            if (grouplist.Count > 0)
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
            if (txtMemberGroupCode.Text.Length == 0)
            {
                errorProvider.SetError(txtMemberGroupCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtMemberGroupCode, string.Empty);

                MemberGroup oMemberGroup = MemberGroup.Load(this.MemberGroupId);
                if (oMemberGroup == null)
                {
                    oMemberGroup = new MemberGroup();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtMemberGroupCode, string.Format(Resources.Common.DuplicatedCode, "Member Group Code"));
                        return false;
                    }
                    else
                    {
                        errorProvider.SetError(txtMemberGroupCode, string.Empty);
                        oMemberGroup.GroupCode = txtMemberGroupCode.Text;
                    }
                }
                oMemberGroup.GroupName = txtMemberGroupName.Text;
                oMemberGroup.GroupName_Chs = txtMemberGroupNameChs.Text;
                oMemberGroup.GroupName_Cht = txtMemberGroupNameCht.Text;
                oMemberGroup.ParentGroup = (cboParentGroup.SelectedValue == null)? System.Guid.Empty:new System.Guid(cboParentGroup.SelectedValue.ToString());

                oMemberGroup.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            MemberGroupWizard wizGroup = new MemberGroupWizard();
            wizGroup.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid MemberGroupId
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

        #region Delete
        private void Delete()
        {
            MemberGroup oMemberGroup = MemberGroup.Load(this.MemberGroupId);
            if (oMemberGroup != null)
            {
                try
                {
                    oMemberGroup.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }
        #endregion

        private void lvMemberGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMemberGroupList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvMemberGroupList.SelectedItem.Text))
                {
                    MemberGroup oMemberGroup = MemberGroup.Load(new System.Guid(lvMemberGroupList.SelectedItem.Text));
                    if (oMemberGroup != null)
                    {
                        this.MemberGroupId = oMemberGroup.GroupId;

                        FillParentGroupList();

                        txtMemberGroupCode.Text = oMemberGroup.GroupCode;
                        txtMemberGroupName.Text = oMemberGroup.GroupName;
                        txtMemberGroupNameChs.Text = oMemberGroup.GroupName_Chs;
                        txtMemberGroupNameCht.Text = oMemberGroup.GroupName_Cht;
                        cboParentGroup.SelectedValue = oMemberGroup.ParentGroup;

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

                BindMemberGroupList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}