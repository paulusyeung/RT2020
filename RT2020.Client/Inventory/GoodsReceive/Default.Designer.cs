namespace RT2020.Client.Inventory.GoodsReceive
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lksPane = new System.Windows.Forms.Panel();
            this.cboView = new System.Windows.Forms.ComboBox();
            this.lblView = new System.Windows.Forms.Label();
            this.cboCreateBy = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.cmdLookup = new System.Windows.Forms.Button();
            this.txtLookup = new System.Windows.Forms.TextBox();
            this.lblLookup = new System.Windows.Forms.Label();
            this.ansList = new System.Windows.Forms.ToolStrip();
            this.ansAddNew = new System.Windows.Forms.ToolStripButton();
            this.ansRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lksPane.SuspendLayout();
            this.ansList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
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
            this.lksPane.Size = new System.Drawing.Size(707, 34);
            this.lksPane.TabIndex = 0;
            this.lksPane.UseWaitCursor = true;
            // 
            // cboView
            // 
            this.cboView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.FormattingEnabled = true;
            this.cboView.Location = new System.Drawing.Point(582, 3);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(120, 21);
            this.cboView.TabIndex = 6;
            this.cboView.UseWaitCursor = true;
            // 
            // lblView
            // 
            this.lblView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(541, 7);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(40, 14);
            this.lblView.TabIndex = 5;
            this.lblView.Text = "View:";
            this.lblView.UseWaitCursor = true;
            // 
            // cboCreateBy
            // 
            this.cboCreateBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreateBy.FormattingEnabled = true;
            this.cboCreateBy.Location = new System.Drawing.Point(321, 3);
            this.cboCreateBy.Name = "cboCreateBy";
            this.cboCreateBy.Size = new System.Drawing.Size(120, 21);
            this.cboCreateBy.TabIndex = 4;
            this.cboCreateBy.UseWaitCursor = true;
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
            this.lblCreatedBy.UseWaitCursor = true;
            // 
            // cmdLookup
            // 
            this.cmdLookup.Image = ((System.Drawing.Image)(resources.GetObject("cmdLookup.Image")));
            this.cmdLookup.Location = new System.Drawing.Point(193, 2);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(22, 22);
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
            this.txtLookup.UseWaitCursor = true;
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
            this.lblLookup.UseWaitCursor = true;
            // 
            // ansList
            // 
            this.ansList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansAddNew,
            this.ansRefresh});
            this.ansList.Location = new System.Drawing.Point(10, 44);
            this.ansList.Name = "ansList";
            this.ansList.Size = new System.Drawing.Size(707, 25);
            this.ansList.TabIndex = 1;
            this.ansList.Text = "toolStrip1";
            this.ansList.UseWaitCursor = true;
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
            // ansRefresh
            // 
            this.ansRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ansRefresh.Image")));
            this.ansRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ansRefresh.Name = "ansRefresh";
            this.ansRefresh.Size = new System.Drawing.Size(66, 22);
            this.ansRefresh.Text = "Refresh";
            this.ansRefresh.Click += new System.EventHandler(this.ansRefresh_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLN,
            this.colHeaderId,
            this.colTxNumber,
            this.colStatus,
            this.colTxDate,
            this.colStaffNumber,
            this.colWorkplace,
            this.colSupplier,
            this.colRef,
            this.colRemarks,
            this.colCreatedOn,
            this.colModifiedOn});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(10, 69);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(707, 366);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "LN";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            this.colLN.Width = 32;
            // 
            // colHeaderId
            // 
            this.colHeaderId.DataPropertyName = "HeaderId";
            this.colHeaderId.HeaderText = "HeaderId";
            this.colHeaderId.Name = "colHeaderId";
            this.colHeaderId.ReadOnly = true;
            this.colHeaderId.Visible = false;
            // 
            // colTxNumber
            // 
            this.colTxNumber.DataPropertyName = "TxNumber";
            this.colTxNumber.HeaderText = "Tx Number";
            this.colTxNumber.Name = "colTxNumber";
            this.colTxNumber.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "TxStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 60;
            // 
            // colTxDate
            // 
            this.colTxDate.DataPropertyName = "TxDate";
            dataGridViewCellStyle6.Format = "dd/MM/yyyy";
            this.colTxDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTxDate.HeaderText = "Tx Date";
            this.colTxDate.Name = "colTxDate";
            this.colTxDate.ReadOnly = true;
            this.colTxDate.Width = 80;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.DataPropertyName = "StaffNumber";
            this.colStaffNumber.HeaderText = "Staff";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.ReadOnly = true;
            this.colStaffNumber.Width = 80;
            // 
            // colWorkplace
            // 
            this.colWorkplace.DataPropertyName = "Location";
            this.colWorkplace.HeaderText = "Workplace";
            this.colWorkplace.Name = "colWorkplace";
            this.colWorkplace.ReadOnly = true;
            this.colWorkplace.Width = 80;
            // 
            // colSupplier
            // 
            this.colSupplier.DataPropertyName = "SupplierCode";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 80;
            // 
            // colRef
            // 
            this.colRef.DataPropertyName = "Reference";
            this.colRef.HeaderText = "Reference";
            this.colRef.Name = "colRef";
            this.colRef.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy HH:mm";
            this.colCreatedOn.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCreatedOn.HeaderText = "Created On";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.ReadOnly = true;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy HH:mm";
            this.colModifiedOn.DefaultCellStyle = dataGridViewCellStyle8;
            this.colModifiedOn.HeaderText = "Modified On";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 445);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.ansList);
            this.Controls.Add(this.lksPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Default";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Stock Receive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Default_FormClosing);
            this.lksPane.ResumeLayout(false);
            this.lksPane.PerformLayout();
            this.ansList.ResumeLayout(false);
            this.ansList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel lksPane;
        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.TextBox txtLookup;
        private System.Windows.Forms.Label lblLookup;
        private System.Windows.Forms.ComboBox cboView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.ComboBox cboCreateBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.ToolStrip ansList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStripButton ansAddNew;
        private System.Windows.Forms.ToolStripButton ansRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
    }
}