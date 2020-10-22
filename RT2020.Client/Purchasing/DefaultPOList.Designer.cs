namespace RT2020.Client.Purchasing
{
    partial class DefaultPOList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultPOList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.colOrderHeaderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.ansList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboView);
            this.panel1.Controls.Add(this.lblView);
            this.panel1.Controls.Add(this.cboCreateBy);
            this.panel1.Controls.Add(this.lblCreatedBy);
            this.panel1.Controls.Add(this.cmdLookup);
            this.panel1.Controls.Add(this.txtLookup);
            this.panel1.Controls.Add(this.lblLookup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 34);
            this.panel1.TabIndex = 0;
            // 
            // cboView
            // 
            this.cboView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.FormattingEnabled = true;
            this.cboView.Location = new System.Drawing.Point(593, 5);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(120, 21);
            this.cboView.TabIndex = 13;
            // 
            // lblView
            // 
            this.lblView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(552, 9);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(40, 14);
            this.lblView.TabIndex = 12;
            this.lblView.Text = "View:";
            // 
            // cboCreateBy
            // 
            this.cboCreateBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreateBy.FormattingEnabled = true;
            this.cboCreateBy.Location = new System.Drawing.Point(320, 5);
            this.cboCreateBy.Name = "cboCreateBy";
            this.cboCreateBy.Size = new System.Drawing.Size(120, 21);
            this.cboCreateBy.TabIndex = 11;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(239, 9);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(78, 14);
            this.lblCreatedBy.TabIndex = 10;
            this.lblCreatedBy.Text = "Created By:";
            // 
            // cmdLookup
            // 
            this.cmdLookup.Image = ((System.Drawing.Image)(resources.GetObject("cmdLookup.Image")));
            this.cmdLookup.Location = new System.Drawing.Point(192, 4);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(22, 22);
            this.cmdLookup.TabIndex = 9;
            this.cmdLookup.UseVisualStyleBackColor = true;
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(72, 5);
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(120, 20);
            this.txtLookup.TabIndex = 8;
            // 
            // lblLookup
            // 
            this.lblLookup.AutoSize = true;
            this.lblLookup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookup.Location = new System.Drawing.Point(3, 9);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(63, 14);
            this.lblLookup.TabIndex = 7;
            this.lblLookup.Text = "Look for:";
            // 
            // ansList
            // 
            this.ansList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansAddNew,
            this.ansRefresh});
            this.ansList.Location = new System.Drawing.Point(10, 44);
            this.ansList.Name = "ansList";
            this.ansList.Size = new System.Drawing.Size(718, 25);
            this.ansList.TabIndex = 2;
            this.ansList.Text = "toolStrip1";
            // 
            // ansAddNew
            // 
            this.ansAddNew.Image = ((System.Drawing.Image)(resources.GetObject("ansAddNew.Image")));
            this.ansAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ansAddNew.Name = "ansAddNew";
            this.ansAddNew.Size = new System.Drawing.Size(67, 22);
            this.ansAddNew.Text = "Add New";
            this.ansAddNew.Click += new System.EventHandler(this.ansAddNew_Click);
            // 
            // ansRefresh
            // 
            this.ansRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ansRefresh.Image")));
            this.ansRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ansRefresh.Name = "ansRefresh";
            this.ansRefresh.Size = new System.Drawing.Size(67, 22);
            this.ansRefresh.Text = "Refresh";
            this.ansRefresh.Click += new System.EventHandler(this.ansRefresh_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderHeaderId,
            this.colOrderNumber,
            this.colStatus,
            this.colLN,
            this.colStaffNumber,
            this.colOrderOn,
            this.colLocation,
            this.colSupplier,
            this.colRemarks1,
            this.colRemarks2,
            this.colRemarks3,
            this.colCreatedOn,
            this.colModifiedOn});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(10, 69);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.Size = new System.Drawing.Size(718, 427);
            this.dgvList.TabIndex = 3;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // colOrderHeaderId
            // 
            this.colOrderHeaderId.DataPropertyName = "OrderHeaderId";
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = null;
            this.colOrderHeaderId.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOrderHeaderId.HeaderText = "OrderHeaderId";
            this.colOrderHeaderId.Name = "colOrderHeaderId";
            this.colOrderHeaderId.ReadOnly = true;
            this.colOrderHeaderId.Visible = false;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "OrderNumber";
            this.colOrderNumber.HeaderText = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "LN";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.DataPropertyName = "StaffNumber";
            this.colStaffNumber.HeaderText = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.ReadOnly = true;
            // 
            // colOrderOn
            // 
            this.colOrderOn.DataPropertyName = "OrderOn";
            dataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm";
            this.colOrderOn.DefaultCellStyle = dataGridViewCellStyle6;
            this.colOrderOn.HeaderText = "OrderOn";
            this.colOrderOn.Name = "colOrderOn";
            this.colOrderOn.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            // 
            // colSupplier
            // 
            this.colSupplier.DataPropertyName = "SupplierCode";
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            // 
            // colRemarks1
            // 
            this.colRemarks1.DataPropertyName = "Remarks1";
            this.colRemarks1.HeaderText = "Remarks1";
            this.colRemarks1.Name = "colRemarks1";
            this.colRemarks1.ReadOnly = true;
            // 
            // colRemarks2
            // 
            this.colRemarks2.DataPropertyName = "Remarks2";
            this.colRemarks2.HeaderText = "Remarks2";
            this.colRemarks2.Name = "colRemarks2";
            this.colRemarks2.ReadOnly = true;
            // 
            // colRemarks3
            // 
            this.colRemarks3.DataPropertyName = "Remarks3";
            this.colRemarks3.HeaderText = "Remarks3";
            this.colRemarks3.Name = "colRemarks3";
            this.colRemarks3.ReadOnly = true;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy HH:mm";
            this.colCreatedOn.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCreatedOn.HeaderText = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.ReadOnly = true;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy HH:mm";
            this.colModifiedOn.DefaultCellStyle = dataGridViewCellStyle8;
            this.colModifiedOn.HeaderText = "ModifiedOn";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // DefaultPOList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 506);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.ansList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefaultPOList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DefaultPOList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ansList.ResumeLayout(false);
            this.ansList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.ComboBox cboCreateBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.TextBox txtLookup;
        private System.Windows.Forms.Label lblLookup;
        private System.Windows.Forms.ToolStrip ansList;
        private System.Windows.Forms.ToolStripButton ansAddNew;
        private System.Windows.Forms.ToolStripButton ansRefresh;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderHeaderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
    }
}