namespace RT2020.Controls.ProductSearcher
{
    partial class MatrixDetail
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.txtStockCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProductName = new Gizmox.WebGUI.Forms.Label();
            this.txtProductName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.dgvDetailList = new Gizmox.WebGUI.Forms.DataGridView();
            this.colProductId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colWorkplace = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colQty = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colQtySubTotal = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colUnitAmount = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colAmountSubTotal = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnShowAllWorkplaceQty = new Gizmox.WebGUI.Forms.Button();
            this.btnShowAllWarehouseQty = new Gizmox.WebGUI.Forms.Button();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.btnLoad = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockCode
            // 
            this.lblStockCode.AutoSize = true;
            this.lblStockCode.Location = new System.Drawing.Point(33, 20);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(65, 13);
            this.lblStockCode.TabIndex = 0;
            this.lblStockCode.Text = "Stock Code:";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(105, 17);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(100, 21);
            this.txtStockCode.TabIndex = 1;
            this.txtStockCode.TextChanged += new System.EventHandler(this.txtStockCode_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(33, 49);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(64, 13);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Description:";
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(105, 46);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(255, 21);
            this.txtProductName.TabIndex = 3;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(407, 20);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(56, 13);
            this.lblTotalQty.TabIndex = 4;
            this.lblTotalQty.Text = "Total Qty:";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Location = new System.Drawing.Point(469, 17);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(100, 21);
            this.txtTotalQty.TabIndex = 5;
            this.txtTotalQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colWorkplace,
            this.colQty,
            this.colQtySubTotal,
            this.colUnitAmount,
            this.colAmountSubTotal});
            this.dgvDetailList.ItemsPerPage = 500;
            this.dgvDetailList.Location = new System.Drawing.Point(12, 76);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.RowHeadersWidth = 50;
            this.dgvDetailList.RowTemplate.Height = 9;
            this.dgvDetailList.Size = new System.Drawing.Size(862, 471);
            this.dgvDetailList.TabIndex = 6;
            this.dgvDetailList.CellEndEdit += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDetailList_CellEndEdit);
            // 
            // colProductId
            // 
            this.colProductId.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.MaxInputLength = -1;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colProductId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProductId.Visible = false;
            this.colProductId.Width = 100;
            // 
            // colAppendix1
            // 
            this.colAppendix1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colAppendix1.DataPropertyName = "APPENDIX1";
            this.colAppendix1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colAppendix1.HeaderText = "Appendix1";
            this.colAppendix1.MaxInputLength = -1;
            this.colAppendix1.Name = "colAppendix1";
            this.colAppendix1.ReadOnly = true;
            this.colAppendix1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colAppendix1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colAppendix2.DataPropertyName = "APPENDIX2";
            this.colAppendix2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colAppendix2.HeaderText = "Appendix2";
            this.colAppendix2.MaxInputLength = -1;
            this.colAppendix2.Name = "colAppendix2";
            this.colAppendix2.ReadOnly = true;
            this.colAppendix2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colAppendix2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colAppendix3.DataPropertyName = "APPENDIX3";
            this.colAppendix3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colAppendix3.HeaderText = "Appendix3";
            this.colAppendix3.MaxInputLength = -1;
            this.colAppendix3.Name = "colAppendix3";
            this.colAppendix3.ReadOnly = true;
            this.colAppendix3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colAppendix3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAppendix3.Width = 80;
            // 
            // colWorkplace
            // 
            this.colWorkplace.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colWorkplace.DataPropertyName = "WorkplaceCode";
            this.colWorkplace.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colWorkplace.HeaderText = "LOC#";
            this.colWorkplace.MaxInputLength = -1;
            this.colWorkplace.Name = "colWorkplace";
            this.colWorkplace.ReadOnly = true;
            this.colWorkplace.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colWorkplace.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWorkplace.Width = 80;
            // 
            // colQty
            // 
            this.colQty.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colQty.DataPropertyName = "CDQTY";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQty.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colQty.HeaderText = "Qty";
            this.colQty.MaxInputLength = -1;
            this.colQty.Name = "colQty";
            this.colQty.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colQty.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colQty.Width = 100;
            // 
            // colQtySubTotal
            // 
            this.colQtySubTotal.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colQtySubTotal.DataPropertyName = "CDQTY";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.colQtySubTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtySubTotal.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colQtySubTotal.HeaderText = "Sub-Total";
            this.colQtySubTotal.MaxInputLength = -1;
            this.colQtySubTotal.Name = "colQtySubTotal";
            this.colQtySubTotal.ReadOnly = true;
            this.colQtySubTotal.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colQtySubTotal.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colQtySubTotal.Width = 100;
            // 
            // colUnitAmount
            // 
            this.colUnitAmount.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colUnitAmount.DataPropertyName = "UnitAmount";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle7.NullValue = "0.00";
            this.colUnitAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUnitAmount.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colUnitAmount.HeaderText = "Rec UAmt";
            this.colUnitAmount.MaxInputLength = -1;
            this.colUnitAmount.Name = "colUnitAmount";
            this.colUnitAmount.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colUnitAmount.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUnitAmount.Width = 100;
            // 
            // colAmountSubTotal
            // 
            this.colAmountSubTotal.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colAmountSubTotal.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0.00";
            this.colAmountSubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAmountSubTotal.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colAmountSubTotal.HeaderText = "Sub-Total Amt";
            this.colAmountSubTotal.MaxInputLength = -1;
            this.colAmountSubTotal.Name = "colAmountSubTotal";
            this.colAmountSubTotal.ReadOnly = true;
            this.colAmountSubTotal.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colAmountSubTotal.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAmountSubTotal.Width = 100;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(783, 564);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(672, 564);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnShowAllWorkplaceQty
            // 
            this.btnShowAllWorkplaceQty.Location = new System.Drawing.Point(410, 44);
            this.btnShowAllWorkplaceQty.Name = "btnShowAllWorkplaceQty";
            this.btnShowAllWorkplaceQty.Size = new System.Drawing.Size(139, 23);
            this.btnShowAllWorkplaceQty.TabIndex = 9;
            this.btnShowAllWorkplaceQty.Text = "Show All Loc# Qty";
            this.btnShowAllWorkplaceQty.Click += new System.EventHandler(this.btnShowAllWorkplaceQty_Click);
            // 
            // btnShowAllWarehouseQty
            // 
            this.btnShowAllWarehouseQty.Location = new System.Drawing.Point(565, 44);
            this.btnShowAllWarehouseQty.Name = "btnShowAllWarehouseQty";
            this.btnShowAllWarehouseQty.Size = new System.Drawing.Size(139, 23);
            this.btnShowAllWarehouseQty.TabIndex = 10;
            this.btnShowAllWarehouseQty.Text = "Show W/H Qty";
            this.btnShowAllWarehouseQty.Click += new System.EventHandler(this.btnShowAllWarehouseQty_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(599, 20);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(57, 13);
            this.lblTotalAmount.TabIndex = 11;
            this.lblTotalAmount.Text = "Total Amt:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(672, 17);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 21);
            this.txtTotalAmount.TabIndex = 12;
            this.txtTotalAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(211, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // MatrixDetail
            // 
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnShowAllWarehouseQty);
            this.Controls.Add(this.btnShowAllWorkplaceQty);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvDetailList);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.lblStockCode);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(886, 602);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Detail";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtStockCode;
        private Gizmox.WebGUI.Forms.Label lblProductName;
        private Gizmox.WebGUI.Forms.TextBox txtProductName;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty;
        private Gizmox.WebGUI.Forms.DataGridView dgvDetailList;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnShowAllWorkplaceQty;
        private Gizmox.WebGUI.Forms.Button btnShowAllWarehouseQty;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colProductId;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colAppendix1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colAppendix2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colAppendix3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colWorkplace;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colQty;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colQtySubTotal;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colUnitAmount;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colAmountSubTotal;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtTotalAmount;
        private Gizmox.WebGUI.Forms.Button btnLoad;
    }
}