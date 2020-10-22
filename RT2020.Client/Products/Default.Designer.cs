namespace RT2020.Client.Products 
{
    partial class Default
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPPENDIX1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPPENDIX2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPPENDIX3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNameChs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductNameCht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboView = new System.Windows.Forms.ComboBox();
            this.cboCreateBy = new System.Windows.Forms.ComboBox();
            this.lblView = new System.Windows.Forms.Label();
            this.ansRefresh = new System.Windows.Forms.ToolStripButton();
            this.lksPane = new System.Windows.Forms.Panel();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.cmdLookup = new System.Windows.Forms.Button();
            this.txtLookup = new System.Windows.Forms.TextBox();
            this.lblLookup = new System.Windows.Forms.Label();
            this.ansList = new System.Windows.Forms.ToolStrip();
            this.ansAddNew = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.lksPane.SuspendLayout();
            this.ansList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLN,
            this.colProductCode,
            this.colProductId,
            this.colAPPENDIX1,
            this.colAPPENDIX2,
            this.colAPPENDIX3,
            this.colProductName,
            this.colProductNameChs,
            this.colProductNameCht,
            this.colNature,
            this.colUnit,
            this.colRemarks,
            this.colCreatedOn,
            this.colModifiedOn});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(10, 69);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(913, 600);
            this.dgvList.TabIndex = 5;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "LN";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            this.colLN.Width = 50;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "STKCODE";
            this.colProductCode.HeaderText = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Width = 80;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            this.colProductId.Width = 150;
            // 
            // colAPPENDIX1
            // 
            this.colAPPENDIX1.DataPropertyName = "APPENDIX1";
            this.colAPPENDIX1.HeaderText = "APPENDIX1";
            this.colAPPENDIX1.Name = "colAPPENDIX1";
            this.colAPPENDIX1.ReadOnly = true;
            this.colAPPENDIX1.Width = 60;
            // 
            // colAPPENDIX2
            // 
            this.colAPPENDIX2.DataPropertyName = "APPENDIX2";
            this.colAPPENDIX2.HeaderText = "APPENDIX2";
            this.colAPPENDIX2.Name = "colAPPENDIX2";
            this.colAPPENDIX2.ReadOnly = true;
            this.colAPPENDIX2.Width = 60;
            // 
            // colAPPENDIX3
            // 
            this.colAPPENDIX3.DataPropertyName = "APPENDIX3";
            this.colAPPENDIX3.HeaderText = "APPENDIX3";
            this.colAPPENDIX3.Name = "colAPPENDIX3";
            this.colAPPENDIX3.ReadOnly = true;
            this.colAPPENDIX3.Width = 60;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 120;
            // 
            // colProductNameChs
            // 
            this.colProductNameChs.DataPropertyName = "ProductName_Chs";
            this.colProductNameChs.HeaderText = "ProductName(Chs)";
            this.colProductNameChs.Name = "colProductNameChs";
            this.colProductNameChs.ReadOnly = true;
            this.colProductNameChs.Width = 120;
            // 
            // colProductNameCht
            // 
            this.colProductNameCht.DataPropertyName = "ProductName_Cht";
            this.colProductNameCht.HeaderText = "ProductName(Cht)";
            this.colProductNameCht.Name = "colProductNameCht";
            this.colProductNameCht.ReadOnly = true;
            this.colProductNameCht.Width = 120;
            // 
            // colNature
            // 
            this.colNature.DataPropertyName = "Nature";
            this.colNature.HeaderText = "Nature";
            this.colNature.Name = "colNature";
            this.colNature.ReadOnly = true;
            this.colNature.Width = 50;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "UOM";
            this.colUnit.HeaderText = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Width = 40;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.Width = 150;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            this.colCreatedOn.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCreatedOn.HeaderText = "Created On";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.ReadOnly = true;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            this.colModifiedOn.DefaultCellStyle = dataGridViewCellStyle3;
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // cboView
            // 
            this.cboView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.FormattingEnabled = true;
            this.cboView.Location = new System.Drawing.Point(788, 3);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(120, 21);
            this.cboView.TabIndex = 6;
            // 
            // cboCreateBy
            // 
            this.cboCreateBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreateBy.FormattingEnabled = true;
            this.cboCreateBy.Location = new System.Drawing.Point(321, 3);
            this.cboCreateBy.Name = "cboCreateBy";
            this.cboCreateBy.Size = new System.Drawing.Size(120, 21);
            this.cboCreateBy.TabIndex = 4;
            // 
            // lblView
            // 
            this.lblView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(747, 7);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(40, 14);
            this.lblView.TabIndex = 5;
            this.lblView.Text = "View:";
            // 
            // ansRefresh
            // 
            this.ansRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ansRefresh.Image")));
            this.ansRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ansRefresh.Name = "ansRefresh";
            this.ansRefresh.Size = new System.Drawing.Size(66, 22);
            this.ansRefresh.Text = "Refresh";
            this.ansRefresh.Click += new System.EventHandler(this.ansRefresh_Click);
            // 
            // lksPane
            // 
            this.lksPane.BackColor = System.Drawing.Color.Transparent;
            this.lksPane.Controls.Add(this.cboView);
            this.lksPane.Controls.Add(this.lblView);
            this.lksPane.Controls.Add(this.cboCreateBy);
            this.lksPane.Controls.Add(this.lblCreatedBy);
            this.lksPane.Controls.Add(this.cmdLookup);
            this.lksPane.Controls.Add(this.txtLookup);
            this.lksPane.Controls.Add(this.lblLookup);
            this.lksPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.lksPane.Location = new System.Drawing.Point(10, 10);
            this.lksPane.Name = "lksPane";
            this.lksPane.Size = new System.Drawing.Size(913, 34);
            this.lksPane.TabIndex = 3;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(240, 7);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(78, 14);
            this.lblCreatedBy.TabIndex = 3;
            this.lblCreatedBy.Text = "Created By:";
            // 
            // cmdLookup
            // 
            this.cmdLookup.Image = ((System.Drawing.Image)(resources.GetObject("cmdLookup.Image")));
            this.cmdLookup.Location = new System.Drawing.Point(197, 0);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(26, 26);
            this.cmdLookup.TabIndex = 2;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(73, 3);
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(120, 20);
            this.txtLookup.TabIndex = 1;
            // 
            // lblLookup
            // 
            this.lblLookup.AutoSize = true;
            this.lblLookup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookup.Location = new System.Drawing.Point(4, 7);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(63, 14);
            this.lblLookup.TabIndex = 0;
            this.lblLookup.Text = "Look for:";
            // 
            // ansList
            // 
            this.ansList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansAddNew,
            this.ansRefresh});
            this.ansList.Location = new System.Drawing.Point(10, 44);
            this.ansList.Name = "ansList";
            this.ansList.Size = new System.Drawing.Size(913, 25);
            this.ansList.TabIndex = 4;
            this.ansList.Text = "toolStrip1";
            // 
            // ansAddNew
            // 
            this.ansAddNew.Image = ((System.Drawing.Image)(resources.GetObject("ansAddNew.Image")));
            this.ansAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ansAddNew.Name = "ansAddNew";
            this.ansAddNew.Size = new System.Drawing.Size(76, 22);
            this.ansAddNew.Text = "Add New";
            this.ansAddNew.Click += new System.EventHandler(this.ansAddNew_Click);
            // 
            // Default
            // 
            this.ClientSize = new System.Drawing.Size(933, 679);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.ansList);
            this.Controls.Add(this.lksPane);
            this.Name = "Default";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DefaultList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.lksPane.ResumeLayout(false);
            this.lksPane.PerformLayout();
            this.ansList.ResumeLayout(false);
            this.ansList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ComboBox cboView;
        private System.Windows.Forms.ComboBox cboCreateBy;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.ToolStripButton ansRefresh;
        private System.Windows.Forms.Panel lksPane;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.TextBox txtLookup;
        private System.Windows.Forms.Label lblLookup;
        private System.Windows.Forms.ToolStrip ansList;
        private System.Windows.Forms.ToolStripButton ansAddNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPPENDIX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPPENDIX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPPENDIX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNameChs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductNameCht;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNature;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;


    }
}