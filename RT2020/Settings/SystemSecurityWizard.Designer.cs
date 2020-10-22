namespace RT2020.Settings
{
    partial class SystemSecurityWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGrade = new Gizmox.WebGUI.Forms.Label();
            this.cboGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.lblStaffNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFullName = new Gizmox.WebGUI.Forms.TextBox();
            this.chkCanPost = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanDelete = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanWrite = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanRead = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbPermissions = new Gizmox.WebGUI.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(23, 80);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(100, 23);
            this.lblGrade.TabIndex = 0;
            this.lblGrade.Text = "Staff Grade:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.Location = new System.Drawing.Point(96, 77);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(227, 21);
            this.cboGrade.TabIndex = 1;
            this.cboGrade.SelectedIndexChanged += new System.EventHandler(this.cboGrade_SelectedIndexChanged);
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 2;
            // 
            // lblStaffNumber
            // 
            this.lblStaffNumber.AutoSize = true;
            this.lblStaffNumber.Location = new System.Drawing.Point(23, 54);
            this.lblStaffNumber.Name = "lblStaffNumber";
            this.lblStaffNumber.Size = new System.Drawing.Size(100, 23);
            this.lblStaffNumber.TabIndex = 3;
            this.lblStaffNumber.Text = "Staff #:";
            // 
            // txtStaffNumber
            // 
            this.txtStaffNumber.Enabled = false;
            this.txtStaffNumber.Location = new System.Drawing.Point(96, 51);
            this.txtStaffNumber.Name = "txtStaffNumber";
            this.txtStaffNumber.ReadOnly = true;
            this.txtStaffNumber.Size = new System.Drawing.Size(58, 20);
            this.txtStaffNumber.TabIndex = 4;
            // 
            // txtFullName
            // 
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(160, 51);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(163, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // chkCanPost
            // 
            this.chkCanPost.Checked = false;
            this.chkCanPost.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanPost.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanPost.Location = new System.Drawing.Point(220, 35);
            this.chkCanPost.Name = "chkCanPost";
            this.chkCanPost.Size = new System.Drawing.Size(62, 24);
            this.chkCanPost.TabIndex = 13;
            this.chkCanPost.Text = "Post";
            this.chkCanPost.ThreeState = false;
            // 
            // chkCanDelete
            // 
            this.chkCanDelete.Checked = false;
            this.chkCanDelete.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanDelete.Location = new System.Drawing.Point(152, 35);
            this.chkCanDelete.Name = "chkCanDelete";
            this.chkCanDelete.Size = new System.Drawing.Size(62, 24);
            this.chkCanDelete.TabIndex = 12;
            this.chkCanDelete.Text = "Delete";
            this.chkCanDelete.ThreeState = false;
            // 
            // chkCanWrite
            // 
            this.chkCanWrite.Checked = false;
            this.chkCanWrite.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanWrite.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanWrite.Location = new System.Drawing.Point(84, 35);
            this.chkCanWrite.Name = "chkCanWrite";
            this.chkCanWrite.Size = new System.Drawing.Size(62, 24);
            this.chkCanWrite.TabIndex = 11;
            this.chkCanWrite.Text = "Write";
            this.chkCanWrite.ThreeState = false;
            // 
            // chkCanRead
            // 
            this.chkCanRead.Checked = false;
            this.chkCanRead.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanRead.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanRead.Location = new System.Drawing.Point(16, 35);
            this.chkCanRead.Name = "chkCanRead";
            this.chkCanRead.Size = new System.Drawing.Size(62, 24);
            this.chkCanRead.TabIndex = 10;
            this.chkCanRead.Text = "Read";
            this.chkCanRead.ThreeState = false;
            // 
            // gbPermissions
            // 
            this.gbPermissions.Controls.Add(this.chkCanPost);
            this.gbPermissions.Controls.Add(this.chkCanRead);
            this.gbPermissions.Controls.Add(this.chkCanDelete);
            this.gbPermissions.Controls.Add(this.chkCanWrite);
            this.gbPermissions.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbPermissions.Location = new System.Drawing.Point(26, 104);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(297, 79);
            this.gbPermissions.TabIndex = 14;
            this.gbPermissions.Text = "Permissions";
            // 
            // SystemSecurityWizard
            // 
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtStaffNumber);
            this.Controls.Add(this.lblStaffNumber);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.lblGrade);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(348, 207);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "RT2020 > Settings > System Security Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblGrade;
        private Gizmox.WebGUI.Forms.ComboBox cboGrade;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Label lblStaffNumber;
        private Gizmox.WebGUI.Forms.TextBox txtStaffNumber;
        private Gizmox.WebGUI.Forms.TextBox txtFullName;
        private Gizmox.WebGUI.Forms.CheckBox chkCanPost;
        private Gizmox.WebGUI.Forms.CheckBox chkCanDelete;
        private Gizmox.WebGUI.Forms.CheckBox chkCanWrite;
        private Gizmox.WebGUI.Forms.CheckBox chkCanRead;
        private Gizmox.WebGUI.Forms.GroupBox gbPermissions;


    }
}