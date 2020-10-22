namespace RT2020.Staff
{
    partial class StaffDeptWizard
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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvStaffDeptList = new Gizmox.WebGUI.Forms.ListView();
            this.colStaffDeptId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffDeptCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffDeptName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffDeptNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffDeptNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentDept = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentDept = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtStaffDeptNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffDeptNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffDeptName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffDeptNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffDeptNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffDeptName = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffDeptCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffDeptCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvStaffDeptList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentDept);
            this.splitContainer.Panel2.Controls.Add(this.lblParentDept);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptName);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptName);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptCode);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvStaffDeptList
            // 
            this.lvStaffDeptList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvStaffDeptList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colStaffDeptId,
            this.colLN,
            this.colStaffDeptCode,
            this.colStaffDeptName,
            this.colStaffDeptNameChs,
            this.colStaffDeptNameCht});
            this.lvStaffDeptList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvStaffDeptList.ItemsPerPage = 20;
            this.lvStaffDeptList.Location = new System.Drawing.Point(0, 0);
            this.lvStaffDeptList.Name = "lvStaffDeptList";
            this.lvStaffDeptList.Size = new System.Drawing.Size(499, 506);
            this.lvStaffDeptList.TabIndex = 0;
            this.lvStaffDeptList.UseInternalPaging = true;
            this.lvStaffDeptList.SelectedIndexChanged += new System.EventHandler(this.lvStaffDeptList_SelectedIndexChanged);
            // 
            // colStaffDeptId
            // 
            this.colStaffDeptId.Image = null;
            this.colStaffDeptId.Text = "StaffDeptId";
            this.colStaffDeptId.Visible = false;
            this.colStaffDeptId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStaffDeptCode
            // 
            this.colStaffDeptCode.Image = null;
            this.colStaffDeptCode.Text = "Dept Code";
            this.colStaffDeptCode.Width = 80;
            // 
            // colStaffDeptName
            // 
            this.colStaffDeptName.Image = null;
            this.colStaffDeptName.Text = "Dept Name";
            this.colStaffDeptName.Width = 120;
            // 
            // colStaffDeptNameChs
            // 
            this.colStaffDeptNameChs.Image = null;
            this.colStaffDeptNameChs.Text = "Dept Name Chs";
            this.colStaffDeptNameChs.Width = 120;
            // 
            // colStaffDeptNameCht
            // 
            this.colStaffDeptNameCht.Image = null;
            this.colStaffDeptNameCht.Text = "Dept Name Cht";
            this.colStaffDeptNameCht.Width = 120;
            // 
            // cboParentDept
            // 
            this.cboParentDept.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentDept.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentDept.DropDownWidth = 142;
            this.cboParentDept.Location = new System.Drawing.Point(122, 129);
            this.cboParentDept.Name = "cboParentDept";
            this.cboParentDept.Size = new System.Drawing.Size(142, 21);
            this.cboParentDept.TabIndex = 5;
            // 
            // lblParentDept
            // 
            this.lblParentDept.Location = new System.Drawing.Point(16, 132);
            this.lblParentDept.Name = "lblParentDept";
            this.lblParentDept.Size = new System.Drawing.Size(100, 23);
            this.lblParentDept.TabIndex = 9;
            this.lblParentDept.Text = "Attached To:";
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
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtStaffDeptNameCht
            // 
            this.txtStaffDeptNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtStaffDeptNameCht.Name = "txtStaffDeptNameCht";
            this.txtStaffDeptNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtStaffDeptNameCht.TabIndex = 4;
            // 
            // txtStaffDeptNameChs
            // 
            this.txtStaffDeptNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtStaffDeptNameChs.Name = "txtStaffDeptNameChs";
            this.txtStaffDeptNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtStaffDeptNameChs.TabIndex = 3;
            // 
            // txtStaffDeptName
            // 
            this.txtStaffDeptName.Location = new System.Drawing.Point(122, 60);
            this.txtStaffDeptName.Name = "txtStaffDeptName";
            this.txtStaffDeptName.Size = new System.Drawing.Size(142, 20);
            this.txtStaffDeptName.TabIndex = 2;
            // 
            // lblStaffDeptNameCht
            // 
            this.lblStaffDeptNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblStaffDeptNameCht.Name = "lblStaffDeptNameCht";
            this.lblStaffDeptNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblStaffDeptNameCht.TabIndex = 4;
            this.lblStaffDeptNameCht.Text = "Dept Name Cht";
            // 
            // lblStaffDeptNameChs
            // 
            this.lblStaffDeptNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblStaffDeptNameChs.Name = "lblStaffDeptNameChs";
            this.lblStaffDeptNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblStaffDeptNameChs.TabIndex = 3;
            this.lblStaffDeptNameChs.Text = "Dept Name Chs:";
            // 
            // lblStaffDeptName
            // 
            this.lblStaffDeptName.Location = new System.Drawing.Point(16, 63);
            this.lblStaffDeptName.Name = "lblStaffDeptName";
            this.lblStaffDeptName.Size = new System.Drawing.Size(100, 23);
            this.lblStaffDeptName.TabIndex = 2;
            this.lblStaffDeptName.Text = "Dept Name:";
            // 
            // txtStaffDeptCode
            // 
            this.txtStaffDeptCode.Location = new System.Drawing.Point(122, 37);
            this.txtStaffDeptCode.Name = "txtStaffDeptCode";
            this.txtStaffDeptCode.Size = new System.Drawing.Size(142, 20);
            this.txtStaffDeptCode.TabIndex = 1;
            // 
            // lblStaffDeptCode
            // 
            this.lblStaffDeptCode.Location = new System.Drawing.Point(16, 40);
            this.lblStaffDeptCode.Name = "lblStaffDeptCode";
            this.lblStaffDeptCode.Size = new System.Drawing.Size(100, 23);
            this.lblStaffDeptCode.TabIndex = 0;
            this.lblStaffDeptCode.Text = "Dept Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // StaffDeptWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "StaffDept Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvStaffDeptList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptName;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptName;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptNameCht;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptNameChs;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptName;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptCode;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentDept;
        private Gizmox.WebGUI.Forms.Label lblParentDept;


    }
}