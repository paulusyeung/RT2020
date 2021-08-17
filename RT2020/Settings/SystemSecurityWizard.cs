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

using Gizmox.WebGUI.Common.Resources;
using RT2020.Helper;

#endregion

namespace RT2020.Settings
{
    public partial class SystemSecurityWizard : Form
    {
        public SystemSecurityWizard()
        {
            InitializeComponent();
        }

        public Guid _SecurityId { get; set; }

        public Guid _StaffId { get; set; }

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
            this.txtStaffNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            this.txtFullName.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
        }

        private void FillGradeList()
        {
            ModelEx.StaffGroupEx.LoadCombo(ref cboGrade, "GradeCode", false);
        }

        private void LoadDetail()
        {
            var oStaff = ModelEx.StaffEx.GetByStaffId(_StaffId);
            if (oStaff != null)
            {
                txtStaffNumber.Text = oStaff.StaffNumber;
                txtFullName.Text = oStaff.FullName;
                cboGrade.SelectedValue = oStaff.GroupId;
            }

            var oSecurity = ModelEx.StaffSecurityEx.GetById(_SecurityId);
            if (oSecurity != null)
            {
                chkCanRead.Checked = oSecurity.CanRead.Value;
                chkCanWrite.Checked = oSecurity.CanWrite.Value;
                chkCanPost.Checked = oSecurity.CanPost.Value;
                chkCanDelete.Checked = oSecurity.CanDelete.Value;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSecurity = ctx.StaffSecurity.Find(_SecurityId);
                if (oSecurity == null)
                {
                    oSecurity = new EF6.StaffSecurity();
                    oSecurity.SecurityId = Guid.NewGuid();
                    oSecurity.StaffId = _StaffId;
                    ctx.StaffSecurity.Add(oSecurity);
                }

                string gradeCode = ModelEx.StaffGroupEx.GetGradeCodeById((Guid)cboGrade.SelectedValue);
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

                ctx.SaveChanges();

                var id = Guid.Empty;
                if (Guid.TryParse(cboGrade.SelectedValue.ToString(), out id))
                {
                    var oStaff = ctx.Staff.Find(_StaffId);
                    if (oStaff != null)
                    {
                        if (oStaff.GroupId != new Guid(cboGrade.SelectedValue.ToString()))
                        {
                            oStaff.GroupId = new Guid(cboGrade.SelectedValue.ToString());
                            oStaff.ModifiedBy = ConfigHelper.CurrentUserId;
                            oStaff.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }
        #endregion

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(cboGrade.SelectedValue.ToString(), out id))
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var sg = ctx.StaffGroup.Where(x => x.GroupId == id).FirstOrDefault();
                    if (sg != null)
                    {
                        chkCanRead.Checked = sg.CanRead.Value;
                        chkCanWrite.Checked = sg.CanWrite.Value;
                        chkCanDelete.Checked = sg.CanDelete.Value;
                        chkCanPost.Checked = sg.CanPost.Value;
                    }
                }
            }
        }
    }
}