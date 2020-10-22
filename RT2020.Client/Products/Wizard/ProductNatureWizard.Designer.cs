namespace RT2020.Client.Products.Wizard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductNatureWizard));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lvProductNatureList = new System.Windows.Forms.DataGridView();
            this.cboParentNature = new System.Windows.Forms.ComboBox();
            this.lblParentNature = new System.Windows.Forms.Label();
            this.tbWizardAction = new System.Windows.Forms.ToolStrip();
            this.cmdNew = new System.Windows.Forms.ToolStripButton();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.txtProductNatureNameCht = new System.Windows.Forms.TextBox();
            this.txtProductNatureNameChs = new System.Windows.Forms.TextBox();
            this.txtProductNatureName = new System.Windows.Forms.TextBox();
            this.lblProductNatureNameCht = new System.Windows.Forms.Label();
            this.lblProductNatureNameChs = new System.Windows.Forms.Label();
            this.lblProductNatureName = new System.Windows.Forms.Label();
            this.txtProductNatureCode = new System.Windows.Forms.TextBox();
            this.lblProductNatureCode = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.colProductNatureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNatureCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNatureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNatureNameChs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNatureNameCht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvProductNatureList)).BeginInit();
            this.tbWizardAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvProductNatureList);
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
            this.splitContainer.Size = new System.Drawing.Size(790, 468);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvProductNatureList
            // 
            this.lvProductNatureList.AllowUserToAddRows = false;
            this.lvProductNatureList.AllowUserToDeleteRows = false;
            this.lvProductNatureList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductNatureId,
            this.colLN,
            this.colProductNatureCode,
            this.colProductNatureName,
            this.colProductNatureNameChs,
            this.colProductNatureNameCht});
            this.lvProductNatureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProductNatureList.Location = new System.Drawing.Point(0, 0);
            this.lvProductNatureList.Name = "lvProductNatureList";
            this.lvProductNatureList.RowHeadersWidth = 5;
            this.lvProductNatureList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lvProductNatureList.Size = new System.Drawing.Size(500, 468);
            this.lvProductNatureList.TabIndex = 0;
            this.lvProductNatureList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lvProductNatureList_CellClick);
            // 
            // cboParentNature
            // 
            this.cboParentNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentNature.DropDownWidth = 142;
            this.cboParentNature.Location = new System.Drawing.Point(122, 129);
            this.cboParentNature.Name = "cboParentNature";
            this.cboParentNature.Size = new System.Drawing.Size(142, 21);
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
            this.tbWizardAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNew,
            this.cmdSave,
            this.cmdRefresh,
            this.toolStripSeparator1,
            this.cmdDelete});
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.Size = new System.Drawing.Size(286, 25);
            this.tbWizardAction.TabIndex = 8;
            // 
            // cmdNew
            // 
            this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(51, 22);
            this.cmdNew.Text = "New";
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(51, 22);
            this.cmdSave.Text = "Save";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(66, 22);
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(60, 22);
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtProductNatureNameCht
            // 
            this.txtProductNatureNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtProductNatureNameCht.Name = "txtProductNatureNameCht";
            this.txtProductNatureNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureNameCht.TabIndex = 4;
            // 
            // txtProductNatureNameChs
            // 
            this.txtProductNatureNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtProductNatureNameChs.Name = "txtProductNatureNameChs";
            this.txtProductNatureNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureNameChs.TabIndex = 3;
            // 
            // txtProductNatureName
            // 
            this.txtProductNatureName.Location = new System.Drawing.Point(122, 60);
            this.txtProductNatureName.Name = "txtProductNatureName";
            this.txtProductNatureName.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureName.TabIndex = 2;
            // 
            // lblProductNatureNameCht
            // 
            this.lblProductNatureNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblProductNatureNameCht.Name = "lblProductNatureNameCht";
            this.lblProductNatureNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureNameCht.TabIndex = 4;
            this.lblProductNatureNameCht.Text = "Nature Name Cht";
            // 
            // lblProductNatureNameChs
            // 
            this.lblProductNatureNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblProductNatureNameChs.Name = "lblProductNatureNameChs";
            this.lblProductNatureNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureNameChs.TabIndex = 3;
            this.lblProductNatureNameChs.Text = "Nature Name Chs:";
            // 
            // lblProductNatureName
            // 
            this.lblProductNatureName.Location = new System.Drawing.Point(16, 63);
            this.lblProductNatureName.Name = "lblProductNatureName";
            this.lblProductNatureName.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureName.TabIndex = 2;
            this.lblProductNatureName.Text = "Nature Name:";
            // 
            // txtProductNatureCode
            // 
            this.txtProductNatureCode.Location = new System.Drawing.Point(122, 37);
            this.txtProductNatureCode.MaxLength = 10;
            this.txtProductNatureCode.Name = "txtProductNatureCode";
            this.txtProductNatureCode.Size = new System.Drawing.Size(142, 20);
            this.txtProductNatureCode.TabIndex = 1;
            // 
            // lblProductNatureCode
            // 
            this.lblProductNatureCode.Location = new System.Drawing.Point(16, 40);
            this.lblProductNatureCode.Name = "lblProductNatureCode";
            this.lblProductNatureCode.Size = new System.Drawing.Size(100, 23);
            this.lblProductNatureCode.TabIndex = 0;
            this.lblProductNatureCode.Text = "Nature Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // colProductNatureId
            // 
            this.colProductNatureId.DataPropertyName = "NatureId";
            this.colProductNatureId.HeaderText = "";
            this.colProductNatureId.Name = "colProductNatureId";
            this.colProductNatureId.Visible = false;
            this.colProductNatureId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "rownum";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            this.colLN.Width = 30;
            // 
            // colProductNatureCode
            // 
            this.colProductNatureCode.DataPropertyName = "NatureCode";
            this.colProductNatureCode.HeaderText = "Nature Code";
            this.colProductNatureCode.Name = "colProductNatureCode";
            this.colProductNatureCode.ReadOnly = true;
            this.colProductNatureCode.Width = 80;
            // 
            // colProductNatureName
            // 
            this.colProductNatureName.DataPropertyName = "NatureName";
            this.colProductNatureName.HeaderText = "Nature Name";
            this.colProductNatureName.Name = "colProductNatureName";
            this.colProductNatureName.ReadOnly = true;
            this.colProductNatureName.Width = 120;
            // 
            // colProductNatureNameChs
            // 
            this.colProductNatureNameChs.DataPropertyName = "NatureName_Chs";
            this.colProductNatureNameChs.HeaderText = "Nature Name (Chs)";
            this.colProductNatureNameChs.Name = "colProductNatureNameChs";
            this.colProductNatureNameChs.ReadOnly = true;
            this.colProductNatureNameChs.Width = 120;
            // 
            // colProductNatureNameCht
            // 
            this.colProductNatureNameCht.DataPropertyName = "NatureName_Cht";
            this.colProductNatureNameCht.HeaderText = "Nature Name (Cht)";
            this.colProductNatureNameCht.Name = "colProductNatureNameCht";
            this.colProductNatureNameCht.ReadOnly = true;
            this.colProductNatureNameCht.Width = 120;
            // 
            // ProductNatureWizard
            // 
            this.ClientSize = new System.Drawing.Size(790, 468);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductNatureWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProductNature Wizard";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvProductNatureList)).EndInit();
            this.tbWizardAction.ResumeLayout(false);
            this.tbWizardAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView lvProductNatureList;
        private System.Windows.Forms.TextBox txtProductNatureNameCht;
        private System.Windows.Forms.TextBox txtProductNatureNameChs;
        private System.Windows.Forms.TextBox txtProductNatureName;
        private System.Windows.Forms.Label lblProductNatureNameCht;
        private System.Windows.Forms.Label lblProductNatureNameChs;
        private System.Windows.Forms.Label lblProductNatureName;
        private System.Windows.Forms.TextBox txtProductNatureCode;
        private System.Windows.Forms.Label lblProductNatureCode;
        private System.Windows.Forms.ToolStrip tbWizardAction;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cboParentNature;
        private System.Windows.Forms.Label lblParentNature;
        private System.Windows.Forms.ToolStripButton cmdNew;
        private System.Windows.Forms.ToolStripButton cmdSave;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNatureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNatureCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNatureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNatureNameChs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNatureNameCht;


    }
}