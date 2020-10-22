namespace RT2020.Client.Purchasing
{
    partial class DefaultRECList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultRECList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.colTxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(722, 34);
            this.panel1.TabIndex = 1;
            // 
            // cboView
            // 
            this.cboView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.FormattingEnabled = true;
            this.cboView.Location = new System.Drawing.Point(597, 5);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(120, 21);
            this.cboView.TabIndex = 13;
            // 
            // lblView
            // 
            this.lblView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(556, 9);
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
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
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
            this.ansList.Size = new System.Drawing.Size(722, 25);
            this.ansList.TabIndex = 3;
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
            this.colTxNumber,
            this.colLN,
            this.colTxDate,
            this.colStaffNumber,
            this.colLocation,
            this.colSupplier,
            this.colCreatedOn,
            this.colModifiedOn});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(10, 69);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.Size = new System.Drawing.Size(722, 431);
            this.dgvList.TabIndex = 4;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // colOrderHeaderId
            // 
            this.colOrderHeaderId.DataPropertyName = "ReceiveHeaderId";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.colOrderHeaderId.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOrderHeaderId.HeaderText = "OrderHeaderId";
            this.colOrderHeaderId.Name = "colOrderHeaderId";
            this.colOrderHeaderId.ReadOnly = true;
            this.colOrderHeaderId.Visible = false;
            // 
            // colTxNumber
            // 
            this.colTxNumber.DataPropertyName = "TxNumber";
            this.colTxNumber.HeaderText = "TxNumber";
            this.colTxNumber.Name = "colTxNumber";
            this.colTxNumber.ReadOnly = true;
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "LN";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            // 
            // colTxDate
            // 
            this.colTxDate.DataPropertyName = "TxDate";
            this.colTxDate.HeaderText = "TxDate";
            this.colTxDate.Name = "colTxDate";
            this.colTxDate.ReadOnly = true;
            // 
            // colStaffNumber
            // 
            this.colStaffNumber.DataPropertyName = "StaffNumber";
            this.colStaffNumber.HeaderText = "StaffNumber";
            this.colStaffNumber.Name = "colStaffNumber";
            this.colStaffNumber.ReadOnly = true;
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
            // colCreatedOn
            // 
            this.colCreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            this.colCreatedOn.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCreatedOn.HeaderText = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.ReadOnly = true;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.DataPropertyName = "ModifiedOn";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            this.colModifiedOn.DefaultCellStyle = dataGridViewCellStyle3;
            this.colModifiedOn.HeaderText = "ModifiedOn";
            this.colModifiedOn.Name = "colModifiedOn";
            this.colModifiedOn.ReadOnly = true;
            // 
            // DefaultRECList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 510);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.ansList);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefaultRECList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DefaultRECList";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedOn;
    }
}