namespace RT2020.Client.Inventory.GoodsReceive
{
    partial class Detail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStockCode = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.dgvDetailList = new RT2020.Client.Common.MyDataGrideView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnShowAllWorkplaceQty = new System.Windows.Forms.Button();
            this.btnShowAllWarehouseQty = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtySubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colWorkplace,
            this.colQty,
            this.colQtySubTotal,
            this.colUnitAmount,
            this.colAmountSubTotal});
            this.dgvDetailList.Location = new System.Drawing.Point(12, 76);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.Size = new System.Drawing.Size(862, 471);
            this.dgvDetailList.TabIndex = 6;
            this.dgvDetailList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailList_CellEndEdit);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(783, 567);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(672, 567);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnShowAllWorkplaceQty
            // 
            this.btnShowAllWorkplaceQty.Location = new System.Drawing.Point(410, 44);
            this.btnShowAllWorkplaceQty.Name = "btnShowAllWorkplaceQty";
            this.btnShowAllWorkplaceQty.Size = new System.Drawing.Size(139, 23);
            this.btnShowAllWorkplaceQty.TabIndex = 9;
            this.btnShowAllWorkplaceQty.Text = "Show &All Loc# Qty";
            this.btnShowAllWorkplaceQty.UseVisualStyleBackColor = true;
            this.btnShowAllWorkplaceQty.Click += new System.EventHandler(this.btnShowAllWorkplaceQty_Click);
            // 
            // btnShowAllWarehouseQty
            // 
            this.btnShowAllWarehouseQty.Location = new System.Drawing.Point(565, 44);
            this.btnShowAllWarehouseQty.Name = "btnShowAllWarehouseQty";
            this.btnShowAllWarehouseQty.Size = new System.Drawing.Size(139, 23);
            this.btnShowAllWarehouseQty.TabIndex = 10;
            this.btnShowAllWarehouseQty.Text = "Show &W/H Qty";
            this.btnShowAllWarehouseQty.UseVisualStyleBackColor = true;
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
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colAppendix1
            // 
            this.colAppendix1.DataPropertyName = "APPENDIX1";
            this.colAppendix1.HeaderText = "Appendix1";
            this.colAppendix1.Name = "colAppendix1";
            this.colAppendix1.ReadOnly = true;
            // 
            // colAppendix2
            // 
            this.colAppendix2.DataPropertyName = "APPENDIX2";
            this.colAppendix2.HeaderText = "Appendix2";
            this.colAppendix2.Name = "colAppendix2";
            this.colAppendix2.ReadOnly = true;
            // 
            // colAppendix3
            // 
            this.colAppendix3.DataPropertyName = "APPENDIX3";
            this.colAppendix3.HeaderText = "Appendix3";
            this.colAppendix3.Name = "colAppendix3";
            this.colAppendix3.ReadOnly = true;
            // 
            // colWorkplace
            // 
            this.colWorkplace.DataPropertyName = "WorkplaceCode";
            this.colWorkplace.HeaderText = "LOC#";
            this.colWorkplace.Name = "colWorkplace";
            this.colWorkplace.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "CDQTY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            // 
            // colQtySubTotal
            // 
            this.colQtySubTotal.DataPropertyName = "CDQTY";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.colQtySubTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtySubTotal.HeaderText = "Sub-Total";
            this.colQtySubTotal.Name = "colQtySubTotal";
            this.colQtySubTotal.ReadOnly = true;
            // 
            // colUnitAmount
            // 
            this.colUnitAmount.DataPropertyName = "UnitAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,###.00";
            dataGridViewCellStyle7.NullValue = "0.00";
            this.colUnitAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUnitAmount.HeaderText = "Rec UAmt";
            this.colUnitAmount.Name = "colUnitAmount";
            // 
            // colAmountSubTotal
            // 
            this.colAmountSubTotal.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0.00";
            this.colAmountSubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAmountSubTotal.HeaderText = "Sub-Total Amt";
            this.colAmountSubTotal.Name = "colAmountSubTotal";
            this.colAmountSubTotal.ReadOnly = true;
            // 
            // Detail
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(886, 602);
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
            this.Font = global::RT2020.Client.Properties.Settings.Default.GlobalFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Detail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detail";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockCode;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.TextBox txtTotalQty;
        private RT2020.Client.Common.MyDataGrideView dgvDetailList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnShowAllWorkplaceQty;
        private System.Windows.Forms.Button btnShowAllWarehouseQty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtySubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountSubTotal;
    }
}