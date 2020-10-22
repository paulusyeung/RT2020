namespace RT2020.Staff
{
    partial class StaffCode
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
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle4 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
            this.toolBarSave = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolSaveNew = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarSaveClose = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarDelete = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tabStaff = new Gizmox.WebGUI.Forms.TabControl();
            this.tabGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tabPersonal = new Gizmox.WebGUI.Forms.TabPage();
            this.lblLoc = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.toolBarSave,
            this.toolSaveNew,
            this.toolBarSaveClose,
            this.toolBarButton1,
            this.toolBarDelete});
            this.toolBar.ClientAction = null;
            this.toolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar.DragHandle = false;
            this.toolBar.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.toolBar.DropDownArrows = false;
            this.toolBar.ImageList = null;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = false;
            this.toolBar.Name = "toolBar";
            //this.toolBar.RightToLeft = false;
            this.toolBar.ShowToolTips = true;
            this.toolBar.TabIndex = 100;
            this.toolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarSave
            // 
            this.toolBarSave.ClientAction = null;
            this.toolBarSave.CustomStyle = "";
            this.toolBarSave.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle1.File = "16x16.16_save.gif";
            this.toolBarSave.Image = iconResourceHandle1;
            this.toolBarSave.ImageIndex = 2;
            this.toolBarSave.ImageKey = null;
            this.toolBarSave.Name = "toolBarSave";
            this.toolBarSave.Pushed = true;
            this.toolBarSave.Size = 24;
            this.toolBarSave.Tag = "Save";
            this.toolBarSave.Text = "Save";
            this.toolBarSave.ToolTipText = "Save";
            // 
            // toolSaveNew
            // 
            this.toolSaveNew.ClientAction = null;
            this.toolSaveNew.CustomStyle = "";
            this.toolSaveNew.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle2.File = "16x16.16_L_saveOpen.gif";
            this.toolSaveNew.Image = iconResourceHandle2;
            this.toolSaveNew.ImageIndex = 1;
            this.toolSaveNew.ImageKey = null;
            this.toolSaveNew.Name = "toolSaveNew";
            this.toolSaveNew.Pushed = true;
            this.toolSaveNew.Size = 24;
            this.toolSaveNew.Tag = "SaveNew";
            this.toolSaveNew.Text = "Save & New";
            this.toolSaveNew.ToolTipText = "Save & New";
            // 
            // toolBarSaveClose
            // 
            this.toolBarSaveClose.ClientAction = null;
            this.toolBarSaveClose.CustomStyle = "";
            this.toolBarSaveClose.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle3.File = "16x16.16_saveClose.gif";
            this.toolBarSaveClose.Image = iconResourceHandle3;
            this.toolBarSaveClose.ImageKey = null;
            this.toolBarSaveClose.Name = "toolBarSaveClose";
            this.toolBarSaveClose.Pushed = true;
            this.toolBarSaveClose.Size = 24;
            this.toolBarSaveClose.Tag = "SaveClose";
            this.toolBarSaveClose.Text = "Save & Close";
            this.toolBarSaveClose.ToolTipText = "Save & Close";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ClientAction = null;
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.toolBarButton1.ImageKey = null;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Pushed = true;
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton1.ToolTipText = "";
            // 
            // toolBarDelete
            // 
            this.toolBarDelete.ClientAction = null;
            this.toolBarDelete.CustomStyle = "";
            this.toolBarDelete.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            iconResourceHandle4.File = "16x16.16_L_remove.gif";
            this.toolBarDelete.Image = iconResourceHandle4;
            this.toolBarDelete.ImageKey = null;
            this.toolBarDelete.Name = "toolBarDelete";
            this.toolBarDelete.Pushed = true;
            this.toolBarDelete.Size = 24;
            this.toolBarDelete.Tag = "Delete";
            this.toolBarDelete.Text = "Delete";
            this.toolBarDelete.ToolTipText = "Delete";
            // 
            // tabStaff
            // 
            this.tabStaff.ClientAction = null;
            this.tabStaff.Controls.Add(this.tabGeneral);
            this.tabStaff.Controls.Add(this.tabPersonal);
            this.tabStaff.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabStaff.Location = new System.Drawing.Point(12, 91);
            this.tabStaff.Multiline = false;
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.SelectedIndex = 0;
            this.tabStaff.ShowCloseButton = false;
            this.tabStaff.Size = new System.Drawing.Size(766, 397);
            this.tabStaff.TabIndex = 101;
            // 
            // tabGeneral
            // 
            this.tabGeneral.ClientAction = null;
            this.tabGeneral.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(758, 371);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // tabPersonal
            // 
            this.tabPersonal.ClientAction = null;
            this.tabPersonal.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabPersonal.Location = new System.Drawing.Point(4, 22);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(758, 371);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal";
            // 
            // lblLoc
            // 
            this.lblLoc.ClientAction = null;
            this.lblLoc.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLoc.Location = new System.Drawing.Point(22, 44);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(57, 21);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "Staff #";
            this.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStaffNumber
            // 
            this.txtStaffNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtStaffNumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtStaffNumber.ClientAction = null;
            this.txtStaffNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtStaffNumber.Location = new System.Drawing.Point(85, 44);
            this.txtStaffNumber.MaxLength = 4;
            this.txtStaffNumber.Name = "txtStaffNumber";
            this.txtStaffNumber.ReadOnly = true;
            this.txtStaffNumber.Size = new System.Drawing.Size(100, 21);
            this.txtStaffNumber.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // StaffCode
            // 
            this.Controls.Add(this.txtStaffNumber);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.tabStaff);
            this.Controls.Add(this.toolBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(790, 500);
            this.Text = "StaffCode";
            this.Load += new System.EventHandler(this.StaffCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar toolBar;
        private Gizmox.WebGUI.Forms.ToolBarButton toolSaveNew;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarSave;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarSaveClose;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarDelete;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton1;
        private Gizmox.WebGUI.Forms.TabControl tabStaff;
        private Gizmox.WebGUI.Forms.TabPage tabGeneral;
        private Gizmox.WebGUI.Forms.TabPage tabPersonal;
        private Gizmox.WebGUI.Forms.Label lblLoc;
        private Gizmox.WebGUI.Forms.TextBox txtStaffNumber;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}