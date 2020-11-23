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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvStaffDeptList = new Gizmox.WebGUI.Forms.ListView();
            this.colStaffDeptId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffDeptCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffDeptName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffDeptNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffDeptNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentDept = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentDept = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtStaffDeptNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffDeptNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffDeptName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffDeptNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffDeptNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffDeptName = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffDeptCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffDeptCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.colParentDept = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
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
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptName);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptName);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffDeptCode);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffDeptCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvStaffDeptList
            // 
            this.lvStaffDeptList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colStaffDeptId,
            this.colLN,
            this.colParentDept,
            this.colStaffDeptCode,
            this.colStaffDeptName,
            this.colStaffDeptNameAlt1,
            this.colStaffDeptNameAlt2});
            this.lvStaffDeptList.DataMember = null;
            this.lvStaffDeptList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvStaffDeptList.Location = new System.Drawing.Point(0, 0);
            this.lvStaffDeptList.Name = "lvStaffDeptList";
            this.lvStaffDeptList.Size = new System.Drawing.Size(499, 506);
            this.lvStaffDeptList.TabIndex = 0;
            this.lvStaffDeptList.UseInternalPaging = true;
            this.lvStaffDeptList.SelectedIndexChanged += new System.EventHandler(this.lvStaffDeptList_SelectedIndexChanged);
            // 
            // colStaffDeptId
            // 
            this.colStaffDeptId.Text = "StaffDeptId";
            this.colStaffDeptId.Visible = false;
            this.colStaffDeptId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStaffDeptCode
            // 
            this.colStaffDeptCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            this.colStaffDeptCode.Text = "Dept Code";
            this.colStaffDeptCode.Width = 80;
            // 
            // colStaffDeptName
            // 
            this.colStaffDeptName.Text = "Dept Name";
            this.colStaffDeptName.Width = 120;
            // 
            // colStaffDeptNameAlt1
            // 
            this.colStaffDeptNameAlt1.Text = "Dept Name Chs";
            this.colStaffDeptNameAlt1.Width = 120;
            // 
            // colStaffDeptNameAlt2
            // 
            this.colStaffDeptNameAlt2.Text = "Dept Name Cht";
            this.colStaffDeptNameAlt2.Width = 120;
            // 
            // cboParentDept
            // 
            this.cboParentDept.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentDept.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentDept.DropDownWidth = 142;
            this.cboParentDept.Location = new System.Drawing.Point(153, 129);
            this.cboParentDept.Name = "cboParentDept";
            this.cboParentDept.Size = new System.Drawing.Size(131, 21);
            this.cboParentDept.TabIndex = 5;
            // 
            // lblParentDept
            // 
            this.lblParentDept.Location = new System.Drawing.Point(16, 132);
            this.lblParentDept.Name = "lblParentDept";
            this.lblParentDept.Size = new System.Drawing.Size(131, 23);
            this.lblParentDept.TabIndex = 9;
            this.lblParentDept.Text = "Attached To:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(302, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtStaffDeptNameAlt2
            // 
            this.txtStaffDeptNameAlt2.Location = new System.Drawing.Point(153, 106);
            this.txtStaffDeptNameAlt2.Name = "txtStaffDeptNameAlt2";
            this.txtStaffDeptNameAlt2.Size = new System.Drawing.Size(131, 20);
            this.txtStaffDeptNameAlt2.TabIndex = 4;
            // 
            // txtStaffDeptNameAlt1
            // 
            this.txtStaffDeptNameAlt1.Location = new System.Drawing.Point(153, 83);
            this.txtStaffDeptNameAlt1.Name = "txtStaffDeptNameAlt1";
            this.txtStaffDeptNameAlt1.Size = new System.Drawing.Size(131, 20);
            this.txtStaffDeptNameAlt1.TabIndex = 3;
            // 
            // txtStaffDeptName
            // 
            this.txtStaffDeptName.Location = new System.Drawing.Point(153, 60);
            this.txtStaffDeptName.Name = "txtStaffDeptName";
            this.txtStaffDeptName.Size = new System.Drawing.Size(131, 20);
            this.txtStaffDeptName.TabIndex = 2;
            // 
            // lblStaffDeptNameAlt2
            // 
            this.lblStaffDeptNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblStaffDeptNameAlt2.Name = "lblStaffDeptNameAlt2";
            this.lblStaffDeptNameAlt2.Size = new System.Drawing.Size(125, 23);
            this.lblStaffDeptNameAlt2.TabIndex = 4;
            this.lblStaffDeptNameAlt2.Text = "Dept Name Cht";
            // 
            // lblStaffDeptNameAlt1
            // 
            this.lblStaffDeptNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblStaffDeptNameAlt1.Name = "lblStaffDeptNameAlt1";
            this.lblStaffDeptNameAlt1.Size = new System.Drawing.Size(125, 23);
            this.lblStaffDeptNameAlt1.TabIndex = 3;
            this.lblStaffDeptNameAlt1.Text = "Dept Name Chs:";
            // 
            // lblStaffDeptName
            // 
            this.lblStaffDeptName.Location = new System.Drawing.Point(16, 63);
            this.lblStaffDeptName.Name = "lblStaffDeptName";
            this.lblStaffDeptName.Size = new System.Drawing.Size(131, 23);
            this.lblStaffDeptName.TabIndex = 2;
            this.lblStaffDeptName.Text = "Dept Name:";
            // 
            // txtStaffDeptCode
            // 
            this.txtStaffDeptCode.Location = new System.Drawing.Point(153, 37);
            this.txtStaffDeptCode.Name = "txtStaffDeptCode";
            this.txtStaffDeptCode.Size = new System.Drawing.Size(131, 20);
            this.txtStaffDeptCode.TabIndex = 1;
            // 
            // lblStaffDeptCode
            // 
            this.lblStaffDeptCode.Location = new System.Drawing.Point(16, 40);
            this.lblStaffDeptCode.Name = "lblStaffDeptCode";
            this.lblStaffDeptCode.Size = new System.Drawing.Size(131, 23);
            this.lblStaffDeptCode.TabIndex = 0;
            this.lblStaffDeptCode.Text = "Dept Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // colParentDept
            // 
            this.colParentDept.Text = "Parent Dept.";
            this.colParentDept.Width = 80;
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
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDeptNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptName;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptName;
        private Gizmox.WebGUI.Forms.TextBox txtStaffDeptCode;
        private Gizmox.WebGUI.Forms.Label lblStaffDeptCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentDept;
        private Gizmox.WebGUI.Forms.Label lblParentDept;
        private Gizmox.WebGUI.Forms.ColumnHeader colParentDept;
    }
}