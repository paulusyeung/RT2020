namespace RT2020.Staff
{
    partial class StaffWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffWizard));
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
            this.toolBarSave = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolSaveNew = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarSaveClose = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarDelete = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tabStaff = new Gizmox.WebGUI.Forms.TabControl();
            this.tabGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.tabPersonal = new Gizmox.WebGUI.Forms.TabPage();
            this.lblStaffNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabStaff)).BeginInit();
            this.tabStaff.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.toolBarSave,
            this.toolSaveNew,
            this.toolBarSaveClose,
            this.toolBarButton1,
            this.toolBarDelete});
            this.toolBar.DragHandle = true;
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = true;
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(100, 22);
            this.toolBar.TabIndex = 100;
            this.toolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarSave
            // 
            this.toolBarSave.CustomStyle = "";
            this.toolBarSave.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarSave.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("toolBarSave.Image"));
            this.toolBarSave.Name = "toolBarSave";
            this.toolBarSave.Pushed = true;
            this.toolBarSave.Size = 24;
            this.toolBarSave.Tag = "Save";
            this.toolBarSave.Text = "Save";
            this.toolBarSave.ToolTipText = "Save";
            // 
            // toolSaveNew
            // 
            this.toolSaveNew.CustomStyle = "";
            this.toolSaveNew.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolSaveNew.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("toolSaveNew.Image"));
            this.toolSaveNew.Name = "toolSaveNew";
            this.toolSaveNew.Pushed = true;
            this.toolSaveNew.Size = 24;
            this.toolSaveNew.Tag = "SaveNew";
            this.toolSaveNew.Text = "Save & New";
            this.toolSaveNew.ToolTipText = "Save & New";
            // 
            // toolBarSaveClose
            // 
            this.toolBarSaveClose.CustomStyle = "";
            this.toolBarSaveClose.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarSaveClose.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("toolBarSaveClose.Image"));
            this.toolBarSaveClose.Name = "toolBarSaveClose";
            this.toolBarSaveClose.Pushed = true;
            this.toolBarSaveClose.Size = 24;
            this.toolBarSaveClose.Tag = "SaveClose";
            this.toolBarSaveClose.Text = "Save & Close";
            this.toolBarSaveClose.ToolTipText = "Save & Close";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Pushed = true;
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton1.ToolTipText = "";
            // 
            // toolBarDelete
            // 
            this.toolBarDelete.CustomStyle = "";
            this.toolBarDelete.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarDelete.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("toolBarDelete.Image"));
            this.toolBarDelete.Name = "toolBarDelete";
            this.toolBarDelete.Pushed = true;
            this.toolBarDelete.Size = 24;
            this.toolBarDelete.Tag = "Delete";
            this.toolBarDelete.Text = "Delete";
            this.toolBarDelete.ToolTipText = "Delete";
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.tabGeneral);
            this.tabStaff.Controls.Add(this.tabPersonal);
            this.tabStaff.Location = new System.Drawing.Point(12, 91);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.SelectedIndex = 0;
            this.tabStaff.Size = new System.Drawing.Size(766, 397);
            this.tabStaff.TabIndex = 101;
            this.tabStaff.SelectedIndexChanged += new System.EventHandler(this.tabStaff_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(758, 371);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // tabPersonal
            // 
            this.tabPersonal.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPersonal.Location = new System.Drawing.Point(4, 22);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(758, 371);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal";
            // 
            // lblStaffNumber
            // 
            this.lblStaffNumber.Location = new System.Drawing.Point(18, 55);
            this.lblStaffNumber.Name = "lblStaffNumber";
            this.lblStaffNumber.Size = new System.Drawing.Size(82, 21);
            this.lblStaffNumber.TabIndex = 0;
            this.lblStaffNumber.Text = "Staff #";
            this.lblStaffNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStaffNumber
            // 
            this.txtStaffNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtStaffNumber.Location = new System.Drawing.Point(100, 55);
            this.txtStaffNumber.MaxLength = 4;
            this.txtStaffNumber.Name = "txtStaffNumber";
            this.txtStaffNumber.ReadOnly = true;
            this.txtStaffNumber.Size = new System.Drawing.Size(100, 21);
            this.txtStaffNumber.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // StaffWizard
            // 
            this.Controls.Add(this.txtStaffNumber);
            this.Controls.Add(this.lblStaffNumber);
            this.Controls.Add(this.tabStaff);
            this.Controls.Add(this.toolBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(790, 500);
            this.Text = "StaffCode";
            this.Load += new System.EventHandler(this.StaffCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabStaff)).EndInit();
            this.tabStaff.ResumeLayout(false);
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
        private Gizmox.WebGUI.Forms.Label lblStaffNumber;
        private Gizmox.WebGUI.Forms.TextBox txtStaffNumber;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}