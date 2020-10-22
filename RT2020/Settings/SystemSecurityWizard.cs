#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace RT2020.Settings
{
    public partial class SystemSecurityWizard : Form
    {
        public SystemSecurityWizard()
        {
            InitializeComponent();
        }

        public string SecurityId { get; set; }

        public string StaffId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetToolBar();
            this.SetAttributes();
            this.FillGradeList();

            this.LoadDetail();
        }

        #region Load

        private void SetAttributes()
        {
            this.txtStaffNumber.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            this.txtFullName.BackColor = SystemInfo.ControlBackColor.DisabledBox;
        }

        private void FillGradeList()
        {
            StaffGroup.LoadCombo(ref cboGrade, new string[] { "GradeCode", "GradeName" }, "{0} - {1}", false, false, string.Empty, string.Empty, string.Empty, null);
        }

        private void LoadDetail()
        {
            if (Common.Utility.IsGUID(StaffId))
            {
                RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(new Guid(StaffId));
                if (oStaff != null)
                {
                    StaffId = oStaff.StaffId.ToString();
                    txtStaffNumber.Text = oStaff.StaffNumber;
                    txtFullName.Text = oStaff.FullName;
                    cboGrade.SelectedValue = oStaff.GroupId;
                }

                if (Common.Utility.IsGUID(SecurityId))
                {
                    StaffSecurity oSecurity = StaffSecurity.Load(new Guid(SecurityId));
                    if (oSecurity != null)
                    {
                        chkCanRead.Checked = oSecurity.CanRead;
                        chkCanWrite.Checked = oSecurity.CanWrite;
                        chkCanPost.Checked = oSecurity.CanPost;
                        chkCanDelete.Checked = oSecurity.CanDelete;
                    }
                }
            }
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// Sets the tool bar.
        /// </summary>
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);
            this.tbWizardAction.Buttons.Add(sep);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the tbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                }
            }
        }

        void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                this.Save();

                MessageBox.Show("Save Successfully!", "Result", new EventHandler(CloseHandler));
            }
        }

        void CloseHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Save

        private void Save()
        {
            if (Common.Utility.IsGUID(SecurityId) && Common.Utility.IsGUID(StaffId))
            {
                StaffSecurity oSecurity = StaffSecurity.Load(new Guid(SecurityId));
                if (oSecurity == null)
                {
                    oSecurity = new StaffSecurity();

                    oSecurity.StaffId = new Guid(StaffId);
                }

                string gradeCode = GetGradeCode(cboGrade.SelectedValue.ToString());
                if (gradeCode.Length > 0)
                {
                    oSecurity.GradeCode = gradeCode;
                }

                oSecurity.Module = "*";
                oSecurity.Functions = "*";
                oSecurity.CanRead = chkCanRead.Checked;
                oSecurity.CanWrite = chkCanWrite.Checked;
                oSecurity.CanPost = chkCanPost.Checked;
                oSecurity.CanDelete = chkCanDelete.Checked;
                oSecurity.Save();

                if (Common.Utility.IsGUID(cboGrade.SelectedValue.ToString()))
                {
                    RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(new Guid(StaffId));
                    if (oStaff != null)
                    {
                        if (oStaff.GroupId != new Guid(cboGrade.SelectedValue.ToString()))
                        {
                            oStaff.GroupId = new Guid(cboGrade.SelectedValue.ToString());
                            oStaff.ModifiedBy = Common.Config.CurrentUserId;
                            oStaff.ModifiedOn = DateTime.Now;
                            oStaff.Save();
                        }
                    }
                }
            }
        }

        private string GetGradeCode(string groupId)
        {
            string gradeCode = string.Empty;

            if (Common.Utility.IsGUID(groupId))
            {
                StaffGroup oGroup = StaffGroup.Load(new Guid(groupId));
                if (oGroup != null)
                {
                    gradeCode = oGroup.GradeCode;
                }
            }

            return gradeCode;
        }

        #endregion

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Common.Utility.IsGUID(cboGrade.SelectedValue.ToString()))
            {
                StaffGroup oGroup = StaffGroup.Load(new Guid(cboGrade.SelectedValue.ToString()));
                if (oGroup != null)
                {
                    chkCanRead.Checked = oGroup.CanRead;
                    chkCanWrite.Checked = oGroup.CanWrite;
                    chkCanDelete.Checked = oGroup.CanDelete;
                    chkCanPost.Checked = oGroup.CanPost;
                }
            }
        }
    }
}