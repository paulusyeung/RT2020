namespace RT2020.Supplier
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvMarketSectorList = new Gizmox.WebGUI.Forms.ListView();
            this.colMarketSectorId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colMarketSectorCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colMarketSectorName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colMarketSectorNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colMarketSectorNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentSector = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentSector = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtMarketSectorNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMarketSectorNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMarketSectorName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMarketSectorNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblMarketSectorNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblMarketSectorName = new Gizmox.WebGUI.Forms.Label();
            this.txtMarketSectorCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMarketSectorCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.colParent = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
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
            this.splitContainer.Panel1.Controls.Add(this.lvMarketSectorList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentSector);
            this.splitContainer.Panel2.Controls.Add(this.lblParentSector);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorName);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorName);
            this.splitContainer.Panel2.Controls.Add(this.txtMarketSectorCode);
            this.splitContainer.Panel2.Controls.Add(this.lblMarketSectorCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvMarketSectorList
            // 
            this.lvMarketSectorList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMarketSectorId,
            this.colLN,
            this.colMarketSectorCode,
            this.colParent,
            this.colMarketSectorName,
            this.colMarketSectorNameAlt1,
            this.colMarketSectorNameAlt2});
            this.lvMarketSectorList.DataMember = null;
            this.lvMarketSectorList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvMarketSectorList.Location = new System.Drawing.Point(0, 0);
            this.lvMarketSectorList.Name = "lvMarketSectorList";
            this.lvMarketSectorList.Size = new System.Drawing.Size(499, 506);
            this.lvMarketSectorList.TabIndex = 0;
            this.lvMarketSectorList.UseInternalPaging = true;
            this.lvMarketSectorList.SelectedIndexChanged += new System.EventHandler(this.lvMarketSectorList_SelectedIndexChanged);
            // 
            // colMarketSectorId
            // 
            this.colMarketSectorId.Text = "MarketSectorId";
            this.colMarketSectorId.Visible = false;
            this.colMarketSectorId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colMarketSectorCode
            // 
            this.colMarketSectorCode.Text = "Code";
            this.colMarketSectorCode.Width = 80;
            // 
            // colMarketSectorName
            // 
            this.colMarketSectorName.Text = "Name";
            this.colMarketSectorName.Width = 120;
            // 
            // colMarketSectorNameAlt1
            // 
            this.colMarketSectorNameAlt1.Text = "Name Chs";
            this.colMarketSectorNameAlt1.Width = 120;
            // 
            // colMarketSectorNameAlt2
            // 
            this.colMarketSectorNameAlt2.Text = "Name Cht";
            this.colMarketSectorNameAlt2.Width = 120;
            // 
            // cboParentSector
            // 
            this.cboParentSector.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentSector.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentSector.DropDownWidth = 142;
            this.cboParentSector.Location = new System.Drawing.Point(148, 129);
            this.cboParentSector.Name = "cboParentSector";
            this.cboParentSector.Size = new System.Drawing.Size(142, 21);
            this.cboParentSector.TabIndex = 5;
            // 
            // lblParentSector
            // 
            this.lblParentSector.Location = new System.Drawing.Point(16, 132);
            this.lblParentSector.Name = "lblParentSector";
            this.lblParentSector.Size = new System.Drawing.Size(129, 23);
            this.lblParentSector.TabIndex = 9;
            this.lblParentSector.Text = "Attached To:";
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
            // txtMarketSectorNameAlt2
            // 
            this.txtMarketSectorNameAlt2.Location = new System.Drawing.Point(148, 106);
            this.txtMarketSectorNameAlt2.Name = "txtMarketSectorNameAlt2";
            this.txtMarketSectorNameAlt2.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorNameAlt2.TabIndex = 4;
            // 
            // txtMarketSectorNameAlt1
            // 
            this.txtMarketSectorNameAlt1.Location = new System.Drawing.Point(148, 83);
            this.txtMarketSectorNameAlt1.Name = "txtMarketSectorNameAlt1";
            this.txtMarketSectorNameAlt1.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorNameAlt1.TabIndex = 3;
            // 
            // txtMarketSectorName
            // 
            this.txtMarketSectorName.Location = new System.Drawing.Point(148, 60);
            this.txtMarketSectorName.Name = "txtMarketSectorName";
            this.txtMarketSectorName.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorName.TabIndex = 2;
            // 
            // lblMarketSectorNameAlt2
            // 
            this.lblMarketSectorNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblMarketSectorNameAlt2.Name = "lblMarketSectorNameAlt2";
            this.lblMarketSectorNameAlt2.Size = new System.Drawing.Size(117, 23);
            this.lblMarketSectorNameAlt2.TabIndex = 4;
            this.lblMarketSectorNameAlt2.Text = "Name Cht";
            // 
            // lblMarketSectorNameAlt1
            // 
            this.lblMarketSectorNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblMarketSectorNameAlt1.Name = "lblMarketSectorNameAlt1";
            this.lblMarketSectorNameAlt1.Size = new System.Drawing.Size(117, 23);
            this.lblMarketSectorNameAlt1.TabIndex = 3;
            this.lblMarketSectorNameAlt1.Text = "Name Chs:";
            // 
            // lblMarketSectorName
            // 
            this.lblMarketSectorName.Location = new System.Drawing.Point(16, 63);
            this.lblMarketSectorName.Name = "lblMarketSectorName";
            this.lblMarketSectorName.Size = new System.Drawing.Size(129, 23);
            this.lblMarketSectorName.TabIndex = 2;
            this.lblMarketSectorName.Text = "Name:";
            // 
            // txtMarketSectorCode
            // 
            this.txtMarketSectorCode.Location = new System.Drawing.Point(148, 37);
            this.txtMarketSectorCode.MaxLength = 10;
            this.txtMarketSectorCode.Name = "txtMarketSectorCode";
            this.txtMarketSectorCode.Size = new System.Drawing.Size(142, 20);
            this.txtMarketSectorCode.TabIndex = 1;
            // 
            // lblMarketSectorCode
            // 
            this.lblMarketSectorCode.Location = new System.Drawing.Point(16, 40);
            this.lblMarketSectorCode.Name = "lblMarketSectorCode";
            this.lblMarketSectorCode.Size = new System.Drawing.Size(129, 23);
            this.lblMarketSectorCode.TabIndex = 0;
            this.lblMarketSectorCode.Text = "Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // colParent
            // 
            this.colParent.Text = "Parent";
            this.colParent.Width = 100;
            // 
            // MarketSectorWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MarketSector Wizard";
            this.Load += new System.EventHandler(this.MarketSectorWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvMarketSectorList;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorName;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarketSectorNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorName;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorName;
        private Gizmox.WebGUI.Forms.TextBox txtMarketSectorCode;
        private Gizmox.WebGUI.Forms.Label lblMarketSectorCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentSector;
        private Gizmox.WebGUI.Forms.Label lblParentSector;
        private Gizmox.WebGUI.Forms.ColumnHeader colParent;
    }
}