namespace RT2020.Client.Inventory.GoodsReceive
{
    partial class Wizard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPane = new System.Windows.Forms.Panel();
            this.chkApLink = new System.Windows.Forms.CheckBox();
            this.txtAmendmentRestrict = new System.Windows.Forms.TextBox();
            this.lblAmendmentRestrict = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtExchgRate = new System.Windows.Forms.TextBox();
            this.lblExchgRate = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtSupplierInvoice = new System.Windows.Forms.TextBox();
            this.lblSupplierInvoice = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.dtpTxDate = new System.Windows.Forms.DateTimePicker();
            this.lblTxDate = new System.Windows.Forms.Label();
            this.cboWorkplace = new System.Windows.Forms.ComboBox();
            this.lblWorkplace = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtTxNumber = new System.Windows.Forms.TextBox();
            this.txtTxType = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTxNumber = new System.Windows.Forms.Label();
            this.lblTxType = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.txtModifiedBy = new System.Windows.Forms.Label();
            this.txtModifiedOn = new System.Windows.Forms.Label();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.colDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTKCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitAmountInForeignCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wspDetails.SuspendLayout();
            this.wspStatus.SuspendLayout();
            this.wspHeader.SuspendLayout();
            this.headerPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // wspDetails
            // 
            this.wspDetails.Controls.Add(this.dgvDetailList);
            this.wspDetails.Location = new System.Drawing.Point(10, 237);
            this.wspDetails.Size = new System.Drawing.Size(924, 424);
            this.wspDetails.Controls.SetChildIndex(this.dgvDetailList, 0);
            // 
            // wspStatus
            // 
            this.wspStatus.BackColor = System.Drawing.SystemColors.Control;
            this.wspStatus.Controls.Add(this.txtModifiedOn);
            this.wspStatus.Controls.Add(this.txtModifiedBy);
            this.wspStatus.Controls.Add(this.lblLastUpdate);
            this.wspStatus.Location = new System.Drawing.Point(10, 661);
            this.wspStatus.Size = new System.Drawing.Size(924, 48);
            // 
            // wspHeader
            // 
            this.wspHeader.Controls.Add(this.headerPane);
            this.wspHeader.Size = new System.Drawing.Size(924, 227);
            // 
            // headerPane
            // 
            this.headerPane.BackColor = System.Drawing.SystemColors.Control;
            this.headerPane.Controls.Add(this.chkApLink);
            this.headerPane.Controls.Add(this.txtAmendmentRestrict);
            this.headerPane.Controls.Add(this.lblAmendmentRestrict);
            this.headerPane.Controls.Add(this.cboStatus);
            this.headerPane.Controls.Add(this.lblStatus);
            this.headerPane.Controls.Add(this.txtExchgRate);
            this.headerPane.Controls.Add(this.lblExchgRate);
            this.headerPane.Controls.Add(this.cboCurrency);
            this.headerPane.Controls.Add(this.lblCurrency);
            this.headerPane.Controls.Add(this.txtTotalQty);
            this.headerPane.Controls.Add(this.lblTotalQty);
            this.headerPane.Controls.Add(this.txtRemarks);
            this.headerPane.Controls.Add(this.lblRemarks);
            this.headerPane.Controls.Add(this.txtReference);
            this.headerPane.Controls.Add(this.lblReference);
            this.headerPane.Controls.Add(this.txtSupplierInvoice);
            this.headerPane.Controls.Add(this.lblSupplierInvoice);
            this.headerPane.Controls.Add(this.cboSupplier);
            this.headerPane.Controls.Add(this.lblSupplier);
            this.headerPane.Controls.Add(this.cboStaff);
            this.headerPane.Controls.Add(this.lblStaff);
            this.headerPane.Controls.Add(this.dtpTxDate);
            this.headerPane.Controls.Add(this.lblTxDate);
            this.headerPane.Controls.Add(this.cboWorkplace);
            this.headerPane.Controls.Add(this.lblWorkplace);
            this.headerPane.Controls.Add(this.txtTotalAmount);
            this.headerPane.Controls.Add(this.txtTxNumber);
            this.headerPane.Controls.Add(this.txtTxType);
            this.headerPane.Controls.Add(this.lblTotalAmount);
            this.headerPane.Controls.Add(this.lblTxNumber);
            this.headerPane.Controls.Add(this.lblTxType);
            this.headerPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPane.Location = new System.Drawing.Point(0, 0);
            this.headerPane.Name = "headerPane";
            this.headerPane.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.headerPane.Size = new System.Drawing.Size(924, 224);
            this.headerPane.TabIndex = 0;
            // 
            // chkApLink
            // 
            this.chkApLink.AutoSize = true;
            this.chkApLink.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApLink.Enabled = false;
            this.chkApLink.Location = new System.Drawing.Point(570, 89);
            this.chkApLink.Name = "chkApLink";
            this.chkApLink.Size = new System.Drawing.Size(64, 17);
            this.chkApLink.TabIndex = 30;
            this.chkApLink.TabStop = false;
            this.chkApLink.Text = "AP Link:";
            this.chkApLink.UseVisualStyleBackColor = true;
            // 
            // txtAmendmentRestrict
            // 
            this.txtAmendmentRestrict.Enabled = false;
            this.txtAmendmentRestrict.Location = new System.Drawing.Point(622, 60);
            this.txtAmendmentRestrict.Name = "txtAmendmentRestrict";
            this.txtAmendmentRestrict.Size = new System.Drawing.Size(45, 21);
            this.txtAmendmentRestrict.TabIndex = 29;
            this.txtAmendmentRestrict.TabStop = false;
            this.txtAmendmentRestrict.Text = "N";
            // 
            // lblAmendmentRestrict
            // 
            this.lblAmendmentRestrict.AutoSize = true;
            this.lblAmendmentRestrict.Location = new System.Drawing.Point(511, 63);
            this.lblAmendmentRestrict.Name = "lblAmendmentRestrict";
            this.lblAmendmentRestrict.Size = new System.Drawing.Size(108, 13);
            this.lblAmendmentRestrict.TabIndex = 28;
            this.lblAmendmentRestrict.Text = "Amendment Restrict:";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(622, 193);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(129, 21);
            this.cboStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(576, 196);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 26;
            this.lblStatus.Text = "Status:";
            // 
            // txtExchgRate
            // 
            this.txtExchgRate.Location = new System.Drawing.Point(622, 167);
            this.txtExchgRate.Name = "txtExchgRate";
            this.txtExchgRate.Size = new System.Drawing.Size(129, 21);
            this.txtExchgRate.TabIndex = 8;
            // 
            // lblExchgRate
            // 
            this.lblExchgRate.AutoSize = true;
            this.lblExchgRate.Location = new System.Drawing.Point(532, 170);
            this.lblExchgRate.Name = "lblExchgRate";
            this.lblExchgRate.Size = new System.Drawing.Size(84, 13);
            this.lblExchgRate.TabIndex = 24;
            this.lblExchgRate.Text = "Exchange Rate:";
            // 
            // cboCurrency
            // 
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(622, 141);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(129, 21);
            this.cboCurrency.TabIndex = 7;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(564, 144);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 22;
            this.lblCurrency.Text = "Currency:";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Location = new System.Drawing.Point(622, 34);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(129, 21);
            this.txtTotalQty.TabIndex = 21;
            this.txtTotalQty.TabStop = false;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(563, 37);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(56, 13);
            this.lblTotalQty.TabIndex = 20;
            this.lblTotalQty.Text = "Total Qty:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(112, 193);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(334, 21);
            this.txtRemarks.TabIndex = 6;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(16, 196);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 18;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(112, 167);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(334, 21);
            this.txtReference.TabIndex = 5;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(16, 170);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(61, 13);
            this.lblReference.TabIndex = 16;
            this.lblReference.Text = "Reference:";
            // 
            // txtSupplierInvoice
            // 
            this.txtSupplierInvoice.Location = new System.Drawing.Point(112, 141);
            this.txtSupplierInvoice.Name = "txtSupplierInvoice";
            this.txtSupplierInvoice.Size = new System.Drawing.Size(210, 21);
            this.txtSupplierInvoice.TabIndex = 4;
            // 
            // lblSupplierInvoice
            // 
            this.lblSupplierInvoice.AutoSize = true;
            this.lblSupplierInvoice.Location = new System.Drawing.Point(16, 144);
            this.lblSupplierInvoice.Name = "lblSupplierInvoice";
            this.lblSupplierInvoice.Size = new System.Drawing.Size(76, 13);
            this.lblSupplierInvoice.TabIndex = 14;
            this.lblSupplierInvoice.Text = "Supplier Inv#:";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(112, 114);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(210, 21);
            this.cboSupplier.TabIndex = 3;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(16, 117);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(49, 13);
            this.lblSupplier.TabIndex = 12;
            this.lblSupplier.Text = "Supplier:";
            // 
            // cboStaff
            // 
            this.cboStaff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStaff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStaff.FormattingEnabled = true;
            this.cboStaff.Location = new System.Drawing.Point(112, 87);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(210, 21);
            this.cboStaff.TabIndex = 2;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(16, 90);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(35, 13);
            this.lblStaff.TabIndex = 10;
            this.lblStaff.Text = "Staff:";
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(112, 61);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(210, 21);
            this.dtpTxDate.TabIndex = 1;
            // 
            // lblTxDate
            // 
            this.lblTxDate.AutoSize = true;
            this.lblTxDate.Location = new System.Drawing.Point(16, 65);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Size = new System.Drawing.Size(72, 13);
            this.lblTxDate.TabIndex = 8;
            this.lblTxDate.Text = "Received On:";
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWorkplace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWorkplace.FormattingEnabled = true;
            this.cboWorkplace.Location = new System.Drawing.Point(112, 34);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(210, 21);
            this.cboWorkplace.TabIndex = 0;
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.AutoSize = true;
            this.lblWorkplace.Location = new System.Drawing.Point(16, 37);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(61, 13);
            this.lblWorkplace.TabIndex = 6;
            this.lblWorkplace.Text = "Workplace:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(622, 8);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(129, 21);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.TabStop = false;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Enabled = false;
            this.txtTxNumber.Location = new System.Drawing.Point(269, 8);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(177, 21);
            this.txtTxNumber.TabIndex = 4;
            this.txtTxNumber.TabStop = false;
            // 
            // txtTxType
            // 
            this.txtTxType.Enabled = false;
            this.txtTxType.Location = new System.Drawing.Point(112, 8);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.Size = new System.Drawing.Size(59, 21);
            this.txtTxType.TabIndex = 3;
            this.txtTxType.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(493, 11);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(123, 13);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "Total Amount {0}:";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.AutoSize = true;
            this.lblTxNumber.Location = new System.Drawing.Point(201, 11);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(63, 13);
            this.lblTxNumber.TabIndex = 1;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblTxType
            // 
            this.lblTxType.AutoSize = true;
            this.lblTxType.Location = new System.Drawing.Point(16, 11);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(47, 13);
            this.lblTxType.TabIndex = 0;
            this.lblTxType.Text = "TxType:";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(31, 18);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(69, 13);
            this.lblLastUpdate.TabIndex = 0;
            this.lblLastUpdate.Text = "Last Update:";
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtModifiedBy.Location = new System.Drawing.Point(182, 14);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(70, 20);
            this.txtModifiedBy.TabIndex = 1;
            this.txtModifiedBy.Text = "[Modified By]";
            this.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModifiedOn
            // 
            this.txtModifiedOn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtModifiedOn.Location = new System.Drawing.Point(109, 14);
            this.txtModifiedOn.Name = "txtModifiedOn";
            this.txtModifiedOn.Size = new System.Drawing.Size(70, 20);
            this.txtModifiedOn.TabIndex = 2;
            this.txtModifiedOn.Text = "dd/MM/yyyy";
            this.txtModifiedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailId,
            this.colLineNumber,
            this.colStatus,
            this.colSTKCODE,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colDescription,
            this.colQty,
            this.colUnitAmountInForeignCurrency,
            this.colUnitAmount,
            this.colAmount,
            this.colProductId});
            this.dgvDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailList.Location = new System.Drawing.Point(0, 25);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.RowHeadersWidth = 5;
            this.dgvDetailList.Size = new System.Drawing.Size(924, 396);
            this.dgvDetailList.TabIndex = 7;
            this.dgvDetailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailList_CellDoubleClick);
            this.dgvDetailList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailList_CellEndEdit);
            // 
            // colDetailId
            // 
            this.colDetailId.DataPropertyName = "DetailsId";
            this.colDetailId.HeaderText = "DetailsId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = false;
            // 
            // colLineNumber
            // 
            this.colLineNumber.DataPropertyName = "LineNumber";
            this.colLineNumber.HeaderText = "LN";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.Width = 50;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 60;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.DataPropertyName = "STKCODE";
            this.colSTKCODE.HeaderText = "STKCODE";
            this.colSTKCODE.Name = "colSTKCODE";
            // 
            // colAppendix1
            // 
            this.colAppendix1.DataPropertyName = "APPENDIX1";
            this.colAppendix1.HeaderText = "APPENDIX1";
            this.colAppendix1.Name = "colAppendix1";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.DataPropertyName = "APPENDIX2";
            this.colAppendix2.HeaderText = "APPENDIX2";
            this.colAppendix2.Name = "colAppendix2";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.DataPropertyName = "APPENDIX3";
            this.colAppendix3.HeaderText = "APPENDIX3";
            this.colAppendix3.Name = "colAppendix3";
            this.colAppendix3.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "ProductName";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 150;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.colQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Width = 80;
            // 
            // colUnitAmountInForeignCurrency
            // 
            this.colUnitAmountInForeignCurrency.DataPropertyName = "UnitAmountInForeignCurrency";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.colUnitAmountInForeignCurrency.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUnitAmountInForeignCurrency.HeaderText = "Unit Amount ({0})";
            this.colUnitAmountInForeignCurrency.Name = "colUnitAmountInForeignCurrency";
            this.colUnitAmountInForeignCurrency.Width = 120;
            // 
            // colUnitAmount
            // 
            this.colUnitAmount.DataPropertyName = "UnitAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.colUnitAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUnitAmount.HeaderText = "Unit Amount (HKD)";
            this.colUnitAmount.Name = "colUnitAmount";
            this.colUnitAmount.Width = 120;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAmount.HeaderText = "Amount (HKD)";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 120;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.Visible = false;
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 744);
            this.Font = global::RT2020.Client.Properties.Settings.Default.GlobalFont;
            this.Name = "Wizard";
            this.Text = "Wizard";
            this.wspDetails.ResumeLayout(false);
            this.wspDetails.PerformLayout();
            this.wspStatus.ResumeLayout(false);
            this.wspStatus.PerformLayout();
            this.wspHeader.ResumeLayout(false);
            this.headerPane.ResumeLayout(false);
            this.headerPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPane;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTxNumber;
        private System.Windows.Forms.Label lblTxType;
        private System.Windows.Forms.TextBox txtTxType;
        private System.Windows.Forms.TextBox txtTxNumber;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cboWorkplace;
        private System.Windows.Forms.Label lblWorkplace;
        private System.Windows.Forms.Label lblTxDate;
        private System.Windows.Forms.ComboBox cboStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.DateTimePicker dtpTxDate;
        private System.Windows.Forms.TextBox txtSupplierInvoice;
        private System.Windows.Forms.Label lblSupplierInvoice;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtExchgRate;
        private System.Windows.Forms.Label lblExchgRate;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.CheckBox chkApLink;
        private System.Windows.Forms.TextBox txtAmendmentRestrict;
        private System.Windows.Forms.Label lblAmendmentRestrict;
        private System.Windows.Forms.Label txtModifiedOn;
        private System.Windows.Forms.Label txtModifiedBy;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTKCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitAmountInForeignCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
    }
}