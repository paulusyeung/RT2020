namespace RT2020.Workplace
{
    partial class WorkplaceNatureWizard
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
            this.lvNatureList = new Gizmox.WebGUI.Forms.ListView();
            this.colNatureId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNatureCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colParent = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNatureName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNatureNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNatureNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentNature = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentNature = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtNatureNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNatureNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNatureName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNatureNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblNatureNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblNatureName = new Gizmox.WebGUI.Forms.Label();
            this.txtNatureCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNatureCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
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
            this.splitContainer.Panel1.Controls.Add(this.lvNatureList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentNature);
            this.splitContainer.Panel2.Controls.Add(this.lblParentNature);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtNatureNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtNatureNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtNatureName);
            this.splitContainer.Panel2.Controls.Add(this.lblNatureNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblNatureNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblNatureName);
            this.splitContainer.Panel2.Controls.Add(this.txtNatureCode);
            this.splitContainer.Panel2.Controls.Add(this.lblNatureCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvNatureList
            // 
            this.lvNatureList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colNatureId,
            this.colLN,
            this.colNatureCode,
            this.colParent,
            this.colNatureName,
            this.colNatureNameAlt1,
            this.colNatureNameAlt2});
            this.lvNatureList.DataMember = null;
            this.lvNatureList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvNatureList.Location = new System.Drawing.Point(0, 0);
            this.lvNatureList.Name = "lvNatureList";
            this.lvNatureList.Size = new System.Drawing.Size(499, 506);
            this.lvNatureList.TabIndex = 0;
            this.lvNatureList.UseInternalPaging = true;
            this.lvNatureList.SelectedIndexChanged += new System.EventHandler(this.lvWorkplaceNatureList_SelectedIndexChanged);
            // 
            // colNatureId
            // 
            this.colNatureId.Text = "WorkplaceNatureId";
            this.colNatureId.Visible = false;
            this.colNatureId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colNatureCode
            // 
            this.colNatureCode.Text = "Nature Code";
            this.colNatureCode.Width = 80;
            // 
            // colParent
            // 
            this.colParent.Text = "Parent";
            this.colParent.Width = 80;
            // 
            // colNatureName
            // 
            this.colNatureName.Text = "Nature Name";
            this.colNatureName.Width = 120;
            // 
            // colNatureNameAlt1
            // 
            this.colNatureNameAlt1.Text = "Nature Name Chs";
            this.colNatureNameAlt1.Width = 120;
            // 
            // colNatureNameAlt2
            // 
            this.colNatureNameAlt2.Text = "Nature Name Cht";
            this.colNatureNameAlt2.Width = 120;
            // 
            // cboParentNature
            // 
            this.cboParentNature.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentNature.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentNature.DropDownWidth = 142;
            this.cboParentNature.Location = new System.Drawing.Point(159, 129);
            this.cboParentNature.Name = "cboParentNature";
            this.cboParentNature.Size = new System.Drawing.Size(130, 21);
            this.cboParentNature.TabIndex = 5;
            // 
            // lblParentNature
            // 
            this.lblParentNature.Location = new System.Drawing.Point(16, 132);
            this.lblParentNature.Name = "lblParentNature";
            this.lblParentNature.Size = new System.Drawing.Size(100, 23);
            this.lblParentNature.TabIndex = 9;
            this.lblParentNature.Text = "Attached To:";
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
            // txtNatureNameAlt2
            // 
            this.txtNatureNameAlt2.Location = new System.Drawing.Point(159, 106);
            this.txtNatureNameAlt2.Name = "txtNatureNameAlt2";
            this.txtNatureNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtNatureNameAlt2.TabIndex = 4;
            // 
            // txtNatureNameAlt1
            // 
            this.txtNatureNameAlt1.Location = new System.Drawing.Point(159, 83);
            this.txtNatureNameAlt1.Name = "txtNatureNameAlt1";
            this.txtNatureNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtNatureNameAlt1.TabIndex = 3;
            // 
            // txtNatureName
            // 
            this.txtNatureName.Location = new System.Drawing.Point(159, 60);
            this.txtNatureName.Name = "txtNatureName";
            this.txtNatureName.Size = new System.Drawing.Size(130, 20);
            this.txtNatureName.TabIndex = 2;
            // 
            // lblNatureNameAlt2
            // 
            this.lblNatureNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblNatureNameAlt2.Name = "lblNatureNameAlt2";
            this.lblNatureNameAlt2.Size = new System.Drawing.Size(128, 20);
            this.lblNatureNameAlt2.TabIndex = 4;
            this.lblNatureNameAlt2.Text = "Nature Name Cht";
            // 
            // lblNatureNameAlt1
            // 
            this.lblNatureNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblNatureNameAlt1.Name = "lblNatureNameAlt1";
            this.lblNatureNameAlt1.Size = new System.Drawing.Size(128, 20);
            this.lblNatureNameAlt1.TabIndex = 3;
            this.lblNatureNameAlt1.Text = "Nature Name Chs:";
            // 
            // lblNatureName
            // 
            this.lblNatureName.Location = new System.Drawing.Point(16, 63);
            this.lblNatureName.Name = "lblNatureName";
            this.lblNatureName.Size = new System.Drawing.Size(100, 23);
            this.lblNatureName.TabIndex = 2;
            this.lblNatureName.Text = "Nature Name:";
            // 
            // txtNatureCode
            // 
            this.txtNatureCode.Location = new System.Drawing.Point(159, 37);
            this.txtNatureCode.MaxLength = 10;
            this.txtNatureCode.Name = "txtNatureCode";
            this.txtNatureCode.Size = new System.Drawing.Size(130, 20);
            this.txtNatureCode.TabIndex = 1;
            // 
            // lblNatureCode
            // 
            this.lblNatureCode.Location = new System.Drawing.Point(16, 40);
            this.lblNatureCode.Name = "lblNatureCode";
            this.lblNatureCode.Size = new System.Drawing.Size(100, 23);
            this.lblNatureCode.TabIndex = 0;
            this.lblNatureCode.Text = "Nature Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // WorkplaceNatureWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkplaceNature Wizard";
            this.Load += new System.EventHandler(this.WorkplaceNatureWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvNatureList;
        private Gizmox.WebGUI.Forms.ColumnHeader colNatureId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colNatureCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colNatureName;
        private Gizmox.WebGUI.Forms.ColumnHeader colNatureNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colNatureNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNatureNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNatureNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtNatureName;
        private Gizmox.WebGUI.Forms.Label lblNatureNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblNatureNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblNatureName;
        private Gizmox.WebGUI.Forms.TextBox txtNatureCode;
        private Gizmox.WebGUI.Forms.Label lblNatureCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentNature;
        private Gizmox.WebGUI.Forms.Label lblParentNature;
        private Gizmox.WebGUI.Forms.ColumnHeader colParent;
    }
}