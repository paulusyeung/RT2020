namespace RT2020.Product
{
    partial class ProductNatureWizard
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
            this.lvProductNatureList = new Gizmox.WebGUI.Forms.ListView();
            this.colProductNatureId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductNatureCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductNatureName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductNatureNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductNatureNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentNature = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentNature = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtProductNatureNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProductNatureNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProductNatureName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProductNatureNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblProductNatureNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblProductNatureName = new Gizmox.WebGUI.Forms.Label();
            this.txtProductNatureCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProductNatureCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvProductNatureList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentNature);
            this.splitContainer.Panel2.Controls.Add(this.lblParentNature);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtProductNatureNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtProductNatureNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtProductNatureName);
            this.splitContainer.Panel2.Controls.Add(this.lblProductNatureNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblProductNatureNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblProductNatureName);
            this.splitContainer.Panel2.Controls.Add(this.txtProductNatureCode);
            this.splitContainer.Panel2.Controls.Add(this.lblProductNatureCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvProductNatureList
            // 
            this.lvProductNatureList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvProductNatureList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colProductNatureId,
            this.colLN,
            this.colProductNatureCode,
            this.colProductNatureName,
            this.colProductNatureNameChs,
            this.colProductNatureNameCht});
            this.lvProductNatureList.DataMember = null;
            this.lvProductNatureList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvProductNatureList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvProductNatureList.ItemsPerPage = 20;
            this.lvProductNatureList.Location = new System.Drawing.Point(0, 0);
            this.lvProductNatureList.Name = "lvProductNatureList";
            this.lvProductNatureList.Size = new System.Drawing.Size(499, 506);
            this.lvProductNatureList.TabIndex = 0;
            this.lvProductNatureList.UseInternalPaging = true;
            this.lvProductNatureList.SelectedIndexChanged += new System.EventHandler(this.lvProductNatureList_SelectedIndexChanged);
            // 
            // colProductNatureId
            // 
            this.colProductNatureId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductNatureId.Image = null;
            this.colProductNatureId.Text = "ProductNatureId";
            this.colProductNatureId.Visible = false;
            this.colProductNatureId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colProductNatureCode
            // 
            this.colProductNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductNatureCode.Image = null;
            this.colProductNatureCode.Text = "Nature Code";
            this.colProductNatureCode.Width = 80;
            // 
            // colProductNatureName
            // 
            this.colProductNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductNatureName.Image = null;
            this.colProductNatureName.Text = "Nature Name";
            this.colProductNatureName.Width = 120;
            // 
            // colProductNatureNameChs
            // 
            this.colProductNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductNatureNameChs.Image = null;
            this.colProductNatureNameChs.Text = "Nature Name Chs";
            this.colProductNatureNameChs.Width = 120;
            // 
            // colProductNatureNameCht
            // 
            this.colProductNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductNatureNameCht.Image = null;
            this.colProductNatureNameCht.Text = "Nature Name Cht";
            this.colProductNatureNameCht.Width = 120;
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
            // txtProductNatureNameCht
            // 
            this.txtProductNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProductNatureNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtProductNatureNameCht.Name = "txtProductNatureNameCht";
            this.txtProductNatureNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureNameCht.TabIndex = 4;
            // 
            // txtProductNatureNameChs
            // 
            this.txtProductNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProductNatureNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtProductNatureNameChs.Name = "txtProductNatureNameChs";
            this.txtProductNatureNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureNameChs.TabIndex = 3;
            // 
            // txtProductNatureName
            // 
            this.txtProductNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProductNatureName.Location = new System.Drawing.Point(122, 60);
            this.txtProductNatureName.Name = "txtProductNatureName";
            this.txtProductNatureName.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureName.TabIndex = 2;
            // 
            // lblProductNatureNameCht
            // 
            this.lblProductNatureNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProductNatureNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblProductNatureNameCht.Name = "lblProductNatureNameCht";
            this.lblProductNatureNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureNameCht.TabIndex = 4;
            this.lblProductNatureNameCht.Text = "Nature Name Cht";
            // 
            // lblProductNatureNameChs
            // 
            this.lblProductNatureNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProductNatureNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblProductNatureNameChs.Name = "lblProductNatureNameChs";
            this.lblProductNatureNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureNameChs.TabIndex = 3;
            this.lblProductNatureNameChs.Text = "Nature Name Chs:";
            // 
            // lblProductNatureName
            // 
            this.lblProductNatureName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProductNatureName.Location = new System.Drawing.Point(16, 63);
            this.lblProductNatureName.Name = "lblProductNatureName";
            this.lblProductNatureName.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureName.TabIndex = 2;
            this.lblProductNatureName.Text = "Nature Name:";
            // 
            // txtProductNatureCode
            // 
            this.txtProductNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProductNatureCode.Location = new System.Drawing.Point(122, 37);
            this.txtProductNatureCode.MaxLength = 10;
            this.txtProductNatureCode.Name = "txtProductNatureCode";
            this.txtProductNatureCode.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureCode.TabIndex = 1;
            // 
            // lblProductNatureCode
            // 
            this.lblProductNatureCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProductNatureCode.Location = new System.Drawing.Point(16, 40);
            this.lblProductNatureCode.Name = "lblProductNatureCode";
            this.lblProductNatureCode.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureCode.TabIndex = 0;
            this.lblProductNatureCode.Text = "Nature Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProductNatureWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductNature Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvProductNatureList;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductNatureId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductNatureCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductNatureName;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductNatureNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductNatureNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtProductNatureNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtProductNatureNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtProductNatureName;
        private Gizmox.WebGUI.Forms.Label lblProductNatureNameCht;
        private Gizmox.WebGUI.Forms.Label lblProductNatureNameChs;
        private Gizmox.WebGUI.Forms.Label lblProductNatureName;
        private Gizmox.WebGUI.Forms.TextBox txtProductNatureCode;
        private Gizmox.WebGUI.Forms.Label lblProductNatureCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentNature;
        private Gizmox.WebGUI.Forms.Label lblParentNature;


    }
}