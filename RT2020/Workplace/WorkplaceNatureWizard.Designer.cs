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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvWorkplaceNatureList = new Gizmox.WebGUI.Forms.ListView();
            this.colWorkplaceNatureId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceNatureCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceNatureName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceNatureNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceNatureNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentNature = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentNature = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtWorkplaceNatureNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtWorkplaceNatureNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtWorkplaceNatureName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblWorkplaceNatureNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblWorkplaceNatureNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblWorkplaceNatureName = new Gizmox.WebGUI.Forms.Label();
            this.txtWorkplaceNatureCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblWorkplaceNatureCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvWorkplaceNatureList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentNature);
            this.splitContainer.Panel2.Controls.Add(this.lblParentNature);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtWorkplaceNatureNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtWorkplaceNatureNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtWorkplaceNatureName);
            this.splitContainer.Panel2.Controls.Add(this.lblWorkplaceNatureNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblWorkplaceNatureNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblWorkplaceNatureName);
            this.splitContainer.Panel2.Controls.Add(this.txtWorkplaceNatureCode);
            this.splitContainer.Panel2.Controls.Add(this.lblWorkplaceNatureCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvWorkplaceNatureList
            // 
            this.lvWorkplaceNatureList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvWorkplaceNatureList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colWorkplaceNatureId,
            this.colLN,
            this.colWorkplaceNatureCode,
            this.colWorkplaceNatureName,
            this.colWorkplaceNatureNameChs,
            this.colWorkplaceNatureNameCht});
            this.lvWorkplaceNatureList.DataMember = null;
            this.lvWorkplaceNatureList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvWorkplaceNatureList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvWorkplaceNatureList.ItemsPerPage = 20;
            this.lvWorkplaceNatureList.Location = new System.Drawing.Point(0, 0);
            this.lvWorkplaceNatureList.Name = "lvWorkplaceNatureList";
            this.lvWorkplaceNatureList.Size = new System.Drawing.Size(499, 506);
            this.lvWorkplaceNatureList.TabIndex = 0;
            this.lvWorkplaceNatureList.UseInternalPaging = true;
            this.lvWorkplaceNatureList.SelectedIndexChanged += new System.EventHandler(this.lvWorkplaceNatureList_SelectedIndexChanged);
            // 
            // colWorkplaceNatureId
            // 
            this.colWorkplaceNatureId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplaceNatureId.Image = null;
            this.colWorkplaceNatureId.Text = "WorkplaceNatureId";
            this.colWorkplaceNatureId.Visible = false;
            this.colWorkplaceNatureId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colWorkplaceNatureCode
            // 
            this.colWorkplaceNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplaceNatureCode.Image = null;
            this.colWorkplaceNatureCode.Text = "Nature Code";
            this.colWorkplaceNatureCode.Width = 80;
            // 
            // colWorkplaceNatureName
            // 
            this.colWorkplaceNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplaceNatureName.Image = null;
            this.colWorkplaceNatureName.Text = "Nature Name";
            this.colWorkplaceNatureName.Width = 120;
            // 
            // colWorkplaceNatureNameChs
            // 
            this.colWorkplaceNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplaceNatureNameChs.Image = null;
            this.colWorkplaceNatureNameChs.Text = "Nature Name Chs";
            this.colWorkplaceNatureNameChs.Width = 120;
            // 
            // colWorkplaceNatureNameCht
            // 
            this.colWorkplaceNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplaceNatureNameCht.Image = null;
            this.colWorkplaceNatureNameCht.Text = "Nature Name Cht";
            this.colWorkplaceNatureNameCht.Width = 120;
            // 
            // cboParentNature
            // 
            this.cboParentNature.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentNature.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentNature.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentNature.DropDownWidth = 142;
            this.cboParentNature.Location = new System.Drawing.Point(122, 129);
            this.cboParentNature.Name = "cboParentNature";
            this.cboParentNature.Size = new System.Drawing.Size(142, 21);
            this.cboParentNature.TabIndex = 5;
            // 
            // lblParentNature
            // 
            this.lblParentNature.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentNature.Location = new System.Drawing.Point(16, 132);
            this.lblParentNature.Name = "lblParentNature";
            this.lblParentNature.Size = new System.Drawing.Size(100, 23);
            this.lblParentNature.TabIndex = 9;
            this.lblParentNature.Text = "Attached To:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtWorkplaceNatureNameCht
            // 
            this.txtWorkplaceNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtWorkplaceNatureNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtWorkplaceNatureNameCht.Name = "txtWorkplaceNatureNameCht";
            this.txtWorkplaceNatureNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtWorkplaceNatureNameCht.TabIndex = 4;
            // 
            // txtWorkplaceNatureNameChs
            // 
            this.txtWorkplaceNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtWorkplaceNatureNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtWorkplaceNatureNameChs.Name = "txtWorkplaceNatureNameChs";
            this.txtWorkplaceNatureNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtWorkplaceNatureNameChs.TabIndex = 3;
            // 
            // txtWorkplaceNatureName
            // 
            this.txtWorkplaceNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtWorkplaceNatureName.Location = new System.Drawing.Point(122, 60);
            this.txtWorkplaceNatureName.Name = "txtWorkplaceNatureName";
            this.txtWorkplaceNatureName.Size = new System.Drawing.Size(142, 20);
            this.txtWorkplaceNatureName.TabIndex = 2;
            // 
            // lblWorkplaceNatureNameCht
            // 
            this.lblWorkplaceNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblWorkplaceNatureNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblWorkplaceNatureNameCht.Name = "lblWorkplaceNatureNameCht";
            this.lblWorkplaceNatureNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplaceNatureNameCht.TabIndex = 4;
            this.lblWorkplaceNatureNameCht.Text = "Nature Name Cht";
            // 
            // lblWorkplaceNatureNameChs
            // 
            this.lblWorkplaceNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblWorkplaceNatureNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblWorkplaceNatureNameChs.Name = "lblWorkplaceNatureNameChs";
            this.lblWorkplaceNatureNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplaceNatureNameChs.TabIndex = 3;
            this.lblWorkplaceNatureNameChs.Text = "Nature Name Chs:";
            // 
            // lblWorkplaceNatureName
            // 
            this.lblWorkplaceNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblWorkplaceNatureName.Location = new System.Drawing.Point(16, 63);
            this.lblWorkplaceNatureName.Name = "lblWorkplaceNatureName";
            this.lblWorkplaceNatureName.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplaceNatureName.TabIndex = 2;
            this.lblWorkplaceNatureName.Text = "Nature Name:";
            // 
            // txtWorkplaceNatureCode
            // 
            this.txtWorkplaceNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtWorkplaceNatureCode.Location = new System.Drawing.Point(122, 37);
            this.txtWorkplaceNatureCode.MaxLength = 10;
            this.txtWorkplaceNatureCode.Name = "txtWorkplaceNatureCode";
            this.txtWorkplaceNatureCode.Size = new System.Drawing.Size(142, 20);
            this.txtWorkplaceNatureCode.TabIndex = 1;
            // 
            // lblWorkplaceNatureCode
            // 
            this.lblWorkplaceNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblWorkplaceNatureCode.Location = new System.Drawing.Point(16, 40);
            this.lblWorkplaceNatureCode.Name = "lblWorkplaceNatureCode";
            this.lblWorkplaceNatureCode.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplaceNatureCode.TabIndex = 0;
            this.lblWorkplaceNatureCode.Text = "Nature Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // WorkplaceNatureWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkplaceNature Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvWorkplaceNatureList;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNatureId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNatureCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNatureName;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNatureNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceNatureNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplaceNatureNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplaceNatureNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplaceNatureName;
        private Gizmox.WebGUI.Forms.Label lblWorkplaceNatureNameCht;
        private Gizmox.WebGUI.Forms.Label lblWorkplaceNatureNameChs;
        private Gizmox.WebGUI.Forms.Label lblWorkplaceNatureName;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplaceNatureCode;
        private Gizmox.WebGUI.Forms.Label lblWorkplaceNatureCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentNature;
        private Gizmox.WebGUI.Forms.Label lblParentNature;


    }
}