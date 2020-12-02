#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using RT2020.Controls;   
#endregion

namespace RT2020.Staff
{
    public partial class StaffGeneral : UserControl
    {
        public StaffGeneral()
        {
            InitializeComponent();
            InitialSmartTags();
            FillComo();
            cboSmartTag8.SelectedIndex = 0;
        }

        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            SmartTag4StaffCollection smartTagList = SmartTag4Staff.LoadCollection(orderBy, true);

            SmartTag oTag = new SmartTag(this.gbGeneral);
            oTag.StaffSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        #region Properties
        private Guid staffId = System.Guid.Empty;
        public Guid StaffId
        {
            get
            {
                return staffId;
            }
            set
            {
                staffId = value;
            }
        }
        #endregion

        #region FillComo
        private void FillComo()
        {
            FillGroup();
            FillDept();
            FillPosition();
            FillSex();
            FillAssistants();
        }
        #endregion

        #region FillGroup
        private void FillGroup()
        {
            cmbStaffGrade.Items.Clear();
            ModelEx.StaffGroupEx.LoadCombo(ref cmbStaffGrade, "GradeCode", false, false, String.Empty, String.Empty);
            cmbStaffGrade.SelectedIndex = 0;
        }
        #endregion

        #region FillDept
        private void FillDept()
        {
            cboDeptCode.Items.Clear();
            ModelEx.StaffDeptEx.LoadCombo(ref cboDeptCode, "DeptCode", false, true, String.Empty, String.Empty);
            cboDeptCode.SelectedIndex = 0;  
        }
        #endregion

        #region FillPosition
        private void FillPosition()
        {
            cmbPosition.Items.Clear();
            ModelEx.StaffJobTitleEx.LoadCombo(ref cmbPosition, "JobTitleName", false, true, String.Empty, String.Empty);
            cmbPosition.SelectedIndex = 0;
        }
        #endregion

        #region FillSex
        private void FillSex()
        {
            cboSmartTag5.Items.Clear();
            cboSmartTag5.Items.Add("Male");
            cboSmartTag5.Items.Add("Female");
            cboSmartTag5.SelectedIndex = 0;
        }
        #endregion

        #region Fill Assistants

        private void FillAssistants()
        {
            ModelEx.StaffEx.LoadCombo(ref cboSmartTag6, "StaffNumber", false, true, String.Empty, "StaffId NOT IN ('" + this.StaffId.ToString() + "')");
            if (cboSmartTag6.Items.Count > 0) cboSmartTag6.SelectedIndex = 0;

            ModelEx.StaffEx.LoadCombo(ref cboSmartTag7, "StaffNumber", false, true, String.Empty, "StaffId NOT IN ('" + this.StaffId.ToString() + "')");
            if (cboSmartTag7.Items.Count > 0) cboSmartTag7.SelectedIndex = 0;  
        }

        #endregion

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.StaffId);
            changePassword.Closed += new EventHandler(changePassword_Closed);
            changePassword.ShowDialog(); 

        }

        void changePassword_Closed(object sender, EventArgs e)
        {
            ChangePassword changePassword = sender as ChangePassword;
            if (changePassword.IsCompleted)
            {
                txtPassword.Text = changePassword.Password;
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim().Length > 0)
            {
                if (txtLastName.Text.Trim().Length > 0)
                {
                    txtName.Text = txtLastName.Text.Trim() + "," + txtFirstName.Text.Trim();
                }
                else
                {
                    txtName.Text = txtFirstName.Text.Trim();
                }
            }
            else
            {
                txtName.Text = txtLastName.Text.Trim();
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Trim().Length > 0)
            {
                if (txtFirstName.Text.Trim().Length > 0)
                {
                    txtName.Text = txtLastName.Text.Trim() + "," + txtFirstName.Text.Trim();
                }
                else
                {
                    txtName.Text = txtLastName.Text.Trim();
                }
            }
            else
            {
                txtName.Text = txtFirstName.Text.Trim();
            }
        }
    }
}