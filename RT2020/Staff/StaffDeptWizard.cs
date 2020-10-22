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
    public partial class StaffDeptWizard : Form
    {
        public StaffDeptWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentDeptList();
            BindStaffDeptList();
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

            if (StaffDeptId == System.Guid.Empty)
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
                            BindStaffDeptList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindStaffDeptList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region StaffDept Code
        private void SetCtrlEditable()
        {
            txtStaffDeptCode.BackColor = (this.StaffDeptId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtStaffDeptCode.ReadOnly = (this.StaffDeptId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtStaffDeptCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentDeptList()
        {
            cboParentDept.DataSource = null;
            cboParentDept.Items.Clear();

            string sql = "DeptId NOT IN ('" + this.StaffDeptId.ToString() + "')";
            string[] orderBy = new string[] { "DeptCode" };
            StaffDeptCollection oStaffDeptList = StaffDept.LoadCollection(sql, orderBy, true);
            oStaffDeptList.Add(new StaffDept());
            cboParentDept.DataSource = oStaffDeptList;
            cboParentDept.DisplayMember = "DeptCode";
            cboParentDept.ValueMember = "DeptId";

            cboParentDept.SelectedIndex = cboParentDept.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindStaffDeptList()
        {
            this.lvStaffDeptList.ListViewItemSorter = new ListViewItemSorter(lvStaffDeptList);
            this.lvStaffDeptList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT DeptId,  ROW_NUMBER() OVER (ORDER BY DeptCode) AS rownum, ");
            sql.Append(" DeptCode, DeptName, DeptName_Chs, DeptName_Cht ");
            sql.Append(" FROM StaffDept ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvStaffDeptList.Items.Add(reader.GetGuid(0).ToString()); // StaffDeptId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // StaffDeptCode
                    objItem.SubItems.Add(reader.GetString(3)); // StaffDept Name
                    objItem.SubItems.Add(reader.GetString(4)); // StaffDept Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // StaffDept Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "DeptCode = '" + txtStaffDeptCode.Text.Trim() + "'";
            StaffDeptCollection deptList = StaffDept.LoadCollection(sql);
            if (deptList.Count > 0)
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
            if (txtStaffDeptCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStaffDeptCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtStaffDeptCode, string.Empty);

                StaffDept oStaffDept = StaffDept.Load(this.StaffDeptId);
                if (oStaffDept == null)
                {
                    oStaffDept = new StaffDept();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtStaffDeptCode, string.Format(Resources.Common.DuplicatedCode, "Department Code"));
                        return false;
                    }
                    else
                    {
                        errorProvider.SetError(txtStaffDeptCode, string.Empty);
                        oStaffDept.DeptCode = txtStaffDeptCode.Text;
                    }
                }
                oStaffDept.DeptName = txtStaffDeptName.Text;
                oStaffDept.DeptName_Chs = txtStaffDeptNameChs.Text;
                oStaffDept.DeptName_Cht = txtStaffDeptNameCht.Text;
                oStaffDept.ParentDept = (cboParentDept.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentDept.SelectedValue.ToString());

                oStaffDept.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            StaffDeptWizard wizDept = new StaffDeptWizard();
            wizDept.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid StaffDeptId
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
            StaffDept oStaffDept = StaffDept.Load(this.StaffDeptId);
            if (oStaffDept != null)
            {
                try
                {
                    oStaffDept.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvStaffDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffDeptList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvStaffDeptList.SelectedItem.Text))
                {
                    StaffDept oStaffDept = StaffDept.Load(new System.Guid(lvStaffDeptList.SelectedItem.Text));
                    if (oStaffDept != null)
                    {
                        this.StaffDeptId = oStaffDept.DeptId;

                        FillParentDeptList();

                        txtStaffDeptCode.Text = oStaffDept.DeptCode;
                        txtStaffDeptName.Text = oStaffDept.DeptName;
                        txtStaffDeptNameChs.Text = oStaffDept.DeptName_Chs;
                        txtStaffDeptNameCht.Text = oStaffDept.DeptName_Cht;
                        cboParentDept.SelectedValue = oStaffDept.ParentDept;

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

                BindStaffDeptList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}