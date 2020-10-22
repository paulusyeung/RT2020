namespace RT2020.Settings
{
    partial class SystemSecurity
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.securityPane = new Gizmox.WebGUI.Forms.Panel();
            this.lvStaffSecurity = new Gizmox.WebGUI.Forms.ListView();
            this.colSecurityId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colGradeCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colModule = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFunctions = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCanRead = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCanWrite = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCanDelete = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCanPost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.topPanel = new Gizmox.WebGUI.Forms.Panel();
            this.lblLookfor = new Gizmox.WebGUI.Forms.Label();
            this.txtLookfor = new Gizmox.WebGUI.Forms.TextBox();
            this.btnLookfor = new Gizmox.WebGUI.Forms.Button();
            this.toolTip = new Gizmox.WebGUI.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // securityPane
            // 
            this.securityPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.securityPane.BackColor = System.Drawing.Color.WhiteSmoke;
            this.securityPane.Controls.Add(this.lvStaffSecurity);
            this.securityPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.securityPane.Location = new System.Drawing.Point(0, 58);
            this.securityPane.Name = "securityPane";
            this.securityPane.Size = new System.Drawing.Size(821, 616);
            this.securityPane.TabIndex = 0;
            // 
            // lvStaffSecurity
            // 
            this.lvStaffSecurity.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvStaffSecurity.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colSecurityId,
            this.colStaffId,
            this.colLineNumber,
            this.colStaffNumber,
            this.colGradeCode,
            this.colModule,
            this.colFunctions,
            this.colCanRead,
            this.colCanWrite,
            this.colCanDelete,
            this.colCanPost});
            this.lvStaffSecurity.DataMember = null;
            this.lvStaffSecurity.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvStaffSecurity.GridLines = true;
            this.lvStaffSecurity.ItemsPerPage = 20;
            this.lvStaffSecurity.Location = new System.Drawing.Point(0, 0);
            this.lvStaffSecurity.MultiSelect = false;
            this.lvStaffSecurity.Name = "lvStaffSecurity";
            this.lvStaffSecurity.Size = new System.Drawing.Size(821, 616);
            this.lvStaffSecurity.TabIndex = 0;
            this.toolTip.SetToolTip(this.lvStaffSecurity, "Double click single row to edit");
            this.lvStaffSecurity.UseInternalPaging = true;
            this.lvStaffSecurity.DoubleClick += new System.EventHandler(this.lvStaffSecurity_DoubleClick);
            // 
            // colSecurityId
            // 
            this.colSecurityId.Image = null;
            this.colSecurityId.Text = "SecurityId";
            this.colSecurityId.Visible = false;
            this.colSecurityId.Width = 150;
            // 
            // colStaffId
            // 
            this.colStaffId.Image = null;
            this.colStaffId.Text = "StaffId";
            this.colStaffId.Visible = false;
            this.colStaffId.Width = 150;
            // 
            // colLineNumber
            // 
            this.colLineNumber.Image = null;
            this.colLineNumber.Text = "Line#";
            this.colLineNumber.Width = 50;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.Image = null;
            this.colStaffNumber.Text = "Staff#";
            this.colStaffNumber.Width = 80;
            // 
            // colGradeCode
            // 
            this.colGradeCode.Image = null;
            this.colGradeCode.Text = "Grade";
            this.colGradeCode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colGradeCode.Width = 50;
            // 
            // colModule
            // 
            this.colModule.Image = null;
            this.colModule.Text = "Module";
            this.colModule.Visible = false;
            this.colModule.Width = 80;
            // 
            // colFunctions
            // 
            this.colFunctions.Image = null;
            this.colFunctions.Text = "Functions";
            this.colFunctions.Visible = false;
            this.colFunctions.Width = 80;
            // 
            // colCanRead
            // 
            this.colCanRead.Image = null;
            this.colCanRead.Text = "Read";
            this.colCanRead.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colCanRead.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colCanRead.Width = 60;
            // 
            // colCanWrite
            // 
            this.colCanWrite.Image = null;
            this.colCanWrite.Text = "Write";
            this.colCanWrite.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colCanWrite.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colCanWrite.Width = 60;
            // 
            // colCanDelete
            // 
            this.colCanDelete.Image = null;
            this.colCanDelete.Text = "Delete";
            this.colCanDelete.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colCanDelete.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colCanDelete.Width = 60;
            // 
            // colCanPost
            // 
            this.colCanPost.Image = null;
            this.colCanPost.Text = "Post";
            this.colCanPost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colCanPost.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colCanPost.Width = 60;
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 30);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 3;
            // 
            // topPanel
            // 
            this.topPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.topPanel.Controls.Add(this.btnLookfor);
            this.topPanel.Controls.Add(this.txtLookfor);
            this.topPanel.Controls.Add(this.lblLookfor);
            this.topPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(821, 30);
            this.topPanel.TabIndex = 4;
            // 
            // lblLookfor
            // 
            this.lblLookfor.AutoSize = true;
            this.lblLookfor.Location = new System.Drawing.Point(23, 8);
            this.lblLookfor.Name = "lblLookfor";
            this.lblLookfor.Size = new System.Drawing.Size(100, 23);
            this.lblLookfor.TabIndex = 0;
            this.lblLookfor.Text = "Look for:";
            // 
            // txtLookfor
            // 
            this.txtLookfor.Location = new System.Drawing.Point(79, 5);
            this.txtLookfor.Name = "txtLookfor";
            this.txtLookfor.Size = new System.Drawing.Size(100, 20);
            this.txtLookfor.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtLookfor, "Look for Staff number");
            this.txtLookfor.TextChanged += new System.EventHandler(this.txtLookfor_TextChanged);
            // 
            // btnLookfor
            // 
            iconResourceHandle2.File = "16x16.16_find.gif";
            this.btnLookfor.Image = iconResourceHandle2;
            this.btnLookfor.Location = new System.Drawing.Point(185, 3);
            this.btnLookfor.Name = "btnLookfor";
            this.btnLookfor.Size = new System.Drawing.Size(25, 23);
            this.btnLookfor.TabIndex = 2;
            this.btnLookfor.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnLookfor.Click += new System.EventHandler(this.btnLookfor_Click);
            // 
            // SystemSecurity
            // 
            this.Controls.Add(this.securityPane);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.topPanel);
            this.Size = new System.Drawing.Size(821, 674);
            this.Text = "SystemSecurity";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel securityPane;
        private Gizmox.WebGUI.Forms.ListView lvStaffSecurity;
        private Gizmox.WebGUI.Forms.ColumnHeader colSecurityId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colCanRead;
        private Gizmox.WebGUI.Forms.ColumnHeader colCanWrite;
        private Gizmox.WebGUI.Forms.ColumnHeader colCanDelete;
        private Gizmox.WebGUI.Forms.ColumnHeader colCanPost;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffId;
        private Gizmox.WebGUI.Forms.ColumnHeader colModule;
        private Gizmox.WebGUI.Forms.ColumnHeader colFunctions;
        private Gizmox.WebGUI.Forms.ColumnHeader colGradeCode;
        private Gizmox.WebGUI.Forms.Panel topPanel;
        private Gizmox.WebGUI.Forms.Button btnLookfor;
        private Gizmox.WebGUI.Forms.TextBox txtLookfor;
        private Gizmox.WebGUI.Forms.Label lblLookfor;
        private Gizmox.WebGUI.Forms.ToolTip toolTip;


    }
}