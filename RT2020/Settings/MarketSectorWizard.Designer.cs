namespace RT2020.Settings
{
    partial class MarketSectorWizard
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
            this.lvMarketSectorList = new Gizmox.WebGUI.Forms.ListView();
            this.colMarketSectorId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarketSectorCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarketSectorName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarketSectorNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarketSectorNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentSector = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentSector = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtMarketSectorNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMarketSectorNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMarketSectorName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMarketSectorNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblMarketSectorNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblMarketSectorName = new Gizmox.WebGUI.Forms.Label();
            this.txtMarketSectorCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMarketSectorCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvMarketSectorList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentSector);
            this.splitContainer.Panel2.Controls.Add(this.lblParentSector);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorName);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorName);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorCode);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvMarketSectorList
            // 
            this.lvMarketSectorList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvMarketSectorList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMarketSectorId,
            this.colLN,
            this.colMarketSectorCode,
            this.colMarketSectorName,
            this.colMarketSectorNameChs,
            this.colMarketSectorNameCht});
            this.lvMarketSectorList.DataMember = null;
            this.lvMarketSectorList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvMarketSectorList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvMarketSectorList.ItemsPerPage = 20;
            this.lvMarketSectorList.Location = new System.Drawing.Point(0, 0);
            this.lvMarketSectorList.Name = "lvMarketSectorList";
            this.lvMarketSectorList.Size = new System.Drawing.Size(499, 506);
            this.lvMarketSectorList.TabIndex = 0;
            this.lvMarketSectorList.UseInternalPaging = true;
            this.lvMarketSectorList.SelectedIndexChanged += new System.EventHandler(this.lvMarketSectorList_SelectedIndexChanged);
            // 
            // colMarketSectorId
            // 
            this.colMarketSectorId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarketSectorId.Image = null;
            this.colMarketSectorId.Text = "MarketSectorId";
            this.colMarketSectorId.Visible = false;
            this.colMarketSectorId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colMarketSectorCode
            // 
            this.colMarketSectorCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarketSectorCode.Image = null;
            this.colMarketSectorCode.Text = "Code";
            this.colMarketSectorCode.Width = 80;
            // 
            // colMarketSectorName
            // 
            this.colMarketSectorName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarketSectorName.Image = null;
            this.colMarketSectorName.Text = "Name";
            this.colMarketSectorName.Width = 120;
            // 
            // colMarketSectorNameChs
            // 
            this.colMarketSectorNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarketSectorNameChs.Image = null;
            this.colMarketSectorNameChs.Text = "Name Chs";
            this.colMarketSectorNameChs.Width = 120;
            // 
            // colMarketSectorNameCht
            // 
            this.colMarketSectorNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarketSectorNameCht.Image = null;
            this.colMarketSectorNameCht.Text = "Name Cht";
            this.colMarketSectorNameCht.Width = 120;
            // 
            // cboParentSector
            // 
            this.cboParentSector.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentSector.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentSector.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentSector.DropDownWidth = 142;
            this.cboParentSector.Location = new System.Drawing.Point(122, 129);
            this.cboParentSector.Name = "cboParentSector";
            this.cboParentSector.Size = new System.Drawing.Size(142, 21);
            this.cboParentSector.TabIndex = 5;
            // 
            // lblParentSector
            // 
            this.lblParentSector.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentSector.Location = new System.Drawing.Point(16, 132);
            this.lblParentSector.Name = "lblParentSector";
            this.lblParentSector.Size = new System.Drawing.Size(100, 23);
            this.lblParentSector.TabIndex = 9;
            this.lblParentSector.Text = "Attached To:";
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
            // txtMarketSectorNameCht
            // 
            this.txtMarketSectorNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMarketSectorNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtMarketSectorNameCht.Name = "txtMarketSectorNameCht";
            this.txtMarketSectorNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorNameCht.TabIndex = 4;
            // 
            // txtMarketSectorNameChs
            // 
            this.txtMarketSectorNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMarketSectorNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtMarketSectorNameChs.Name = "txtMarketSectorNameChs";
            this.txtMarketSectorNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorNameChs.TabIndex = 3;
            // 
            // txtMarketSectorName
            // 
            this.txtMarketSectorName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMarketSectorName.Location = new System.Drawing.Point(122, 60);
            this.txtMarketSectorName.Name = "txtMarketSectorName";
            this.txtMarketSectorName.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorName.TabIndex = 2;
            // 
            // lblMarketSectorNameCht
            // 
            this.lblMarketSectorNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMarketSectorNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblMarketSectorNameCht.Name = "lblMarketSectorNameCht";
            this.lblMarketSectorNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblMarketSectorNameCht.TabIndex = 4;
            this.lblMarketSectorNameCht.Text = "Name Cht";
            // 
            // lblMarketSectorNameChs
            // 
            this.lblMarketSectorNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMarketSectorNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblMarketSectorNameChs.Name = "lblMarketSectorNameChs";
            this.lblMarketSectorNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblMarketSectorNameChs.TabIndex = 3;
            this.lblMarketSectorNameChs.Text = "Name Chs:";
            // 
            // lblMarketSectorName
            // 
            this.lblMarketSectorName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMarketSectorName.Location = new System.Drawing.Point(16, 63);
            this.lblMarketSectorName.Name = "lblMarketSectorName";
            this.lblMarketSectorName.Size = new System.Drawing.Size(100, 23);
            this.lblMarketSectorName.TabIndex = 2;
            this.lblMarketSectorName.Text = "Name:";
            // 
            // txtMarketSectorCode
            // 
            this.txtMarketSectorCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMarketSectorCode.Location = new System.Drawing.Point(122, 37);
            this.txtMarketSectorCode.MaxLength = 10;
            this.txtMarketSectorCode.Name = "txtMarketSectorCode";
            this.txtMarketSectorCode.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorCode.TabIndex = 1;
            // 
            // lblMarketSectorCode
            // 
            this.lblMarketSectorCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMarketSectorCode.Location = new System.Drawing.Point(16, 40);
            this.lblMarketSectorCode.Name = "lblMarketSectorCode";
            this.lblMarketSectorCode.Size = new System.Drawing.Size(100, 23);
            this.lblMarketSectorCode.TabIndex = 0;
            this.lblMarketSectorCode.Text = "Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // MarketSectorWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MarketSector Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvMarketSectorList;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorName;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorName;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorNameCht;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorNameChs;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorName;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorCode;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentSector;
        private Gizmox.WebGUI.Forms.Label lblParentSector;


    }
}