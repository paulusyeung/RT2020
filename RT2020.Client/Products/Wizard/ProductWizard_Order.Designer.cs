namespace RT2020.Client.Products .Wizard
{
    partial class ProductWizard_Order
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
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.gbPurchaseHistory = new System.Windows.Forms.GroupBox();
            this.lvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.colRecDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuppNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReorderQuantity = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.txtVendorItemNum = new System.Windows.Forms.TextBox();
            this.lblReorderQuantity = new System.Windows.Forms.Label();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.lblVendorItemNum = new System.Windows.Forms.Label();
            this.gbOrder.SuspendLayout();
            this.gbPurchaseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvPurchaseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.gbPurchaseHistory);
            this.gbOrder.Controls.Add(this.txtReorderQuantity);
            this.gbOrder.Controls.Add(this.txtReorderLevel);
            this.gbOrder.Controls.Add(this.txtVendorItemNum);
            this.gbOrder.Controls.Add(this.lblReorderQuantity);
            this.gbOrder.Controls.Add(this.lblReorderLevel);
            this.gbOrder.Controls.Add(this.lblVendorItemNum);
            this.gbOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbOrder.Location = new System.Drawing.Point(0, 0);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(766, 350);
            this.gbOrder.TabIndex = 0;
            this.gbOrder.TabStop = false;
            // 
            // gbPurchaseHistory
            // 
            this.gbPurchaseHistory.Controls.Add(this.lvPurchaseHistory);
            this.gbPurchaseHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPurchaseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPurchaseHistory.Location = new System.Drawing.Point(3, 39);
            this.gbPurchaseHistory.Name = "gbPurchaseHistory";
            this.gbPurchaseHistory.Size = new System.Drawing.Size(760, 308);
            this.gbPurchaseHistory.TabIndex = 6;
            this.gbPurchaseHistory.TabStop = false;
            this.gbPurchaseHistory.Text = "Purchase History";
            // 
            // lvPurchaseHistory
            // 
            this.lvPurchaseHistory.AllowUserToAddRows = false;
            this.lvPurchaseHistory.AllowUserToDeleteRows = false;
            this.lvPurchaseHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecDate,
            this.colSuppNumber,
            this.colSuppName,
            this.colTxNumber,
            this.colPONumber,
            this.colCost,
            this.colNetCost});
            this.lvPurchaseHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPurchaseHistory.Location = new System.Drawing.Point(3, 16);
            this.lvPurchaseHistory.Name = "lvPurchaseHistory";
            this.lvPurchaseHistory.Size = new System.Drawing.Size(754, 289);
            this.lvPurchaseHistory.TabIndex = 0;
            // 
            // colRecDate
            // 
            this.colRecDate.DataPropertyName = "RecDate";
            this.colRecDate.HeaderText = "Rec. Date";
            this.colRecDate.Name = "colRecDate";
            this.colRecDate.ReadOnly = true;
            // 
            // colSuppNumber
            // 
            this.colSuppNumber.DataPropertyName = "SuppNumber";
            this.colSuppNumber.HeaderText = "Supplier#";
            this.colSuppNumber.Name = "colSuppNumber";
            this.colSuppNumber.ReadOnly = true;
            // 
            // colSuppName
            // 
            this.colSuppName.DataPropertyName = "SuppName";
            this.colSuppName.HeaderText = "Supplier Name";
            this.colSuppName.Name = "colSuppName";
            this.colSuppName.ReadOnly = true;
            // 
            // colTxNumber
            // 
            this.colTxNumber.DataPropertyName = "TxNumber";
            this.colTxNumber.HeaderText = "TRN#";
            this.colTxNumber.Name = "colTxNumber";
            this.colTxNumber.ReadOnly = true;
            // 
            // colPONumber
            // 
            this.colPONumber.DataPropertyName = "PONumber";
            this.colPONumber.HeaderText = "PO#";
            this.colPONumber.Name = "colPONumber";
            this.colPONumber.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "Cost";
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colNetCost
            // 
            this.colNetCost.DataPropertyName = "Net Cost";
            this.colNetCost.HeaderText = "Net Cost";
            this.colNetCost.Name = "colNetCost";
            this.colNetCost.ReadOnly = true;
            // 
            // txtReorderQuantity
            // 
            this.txtReorderQuantity.Location = new System.Drawing.Point(572, 13);
            this.txtReorderQuantity.Name = "txtReorderQuantity";
            this.txtReorderQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtReorderQuantity.TabIndex = 7;
            this.txtReorderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(331, 13);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(100, 20);
            this.txtReorderLevel.TabIndex = 6;
            this.txtReorderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVendorItemNum
            // 
            this.txtVendorItemNum.Location = new System.Drawing.Point(107, 13);
            this.txtVendorItemNum.Name = "txtVendorItemNum";
            this.txtVendorItemNum.Size = new System.Drawing.Size(100, 20);
            this.txtVendorItemNum.TabIndex = 5;
            // 
            // lblReorderQuantity
            // 
            this.lblReorderQuantity.Location = new System.Drawing.Point(466, 16);
            this.lblReorderQuantity.Name = "lblReorderQuantity";
            this.lblReorderQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblReorderQuantity.TabIndex = 2;
            this.lblReorderQuantity.Text = "Re-Order Quantity:";
            // 
            // lblReorderLevel
            // 
            this.lblReorderLevel.Location = new System.Drawing.Point(238, 16);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Size = new System.Drawing.Size(87, 23);
            this.lblReorderLevel.TabIndex = 1;
            this.lblReorderLevel.Text = "Re-Order Level:";
            // 
            // lblVendorItemNum
            // 
            this.lblVendorItemNum.Location = new System.Drawing.Point(16, 16);
            this.lblVendorItemNum.Name = "lblVendorItemNum";
            this.lblVendorItemNum.Size = new System.Drawing.Size(85, 23);
            this.lblVendorItemNum.TabIndex = 0;
            this.lblVendorItemNum.Text = "Vendor Item#:";
            // 
            // ProductWizard_Order
            // 
            this.Controls.Add(this.gbOrder);
            this.Name = "ProductWizard_Order";
            this.Size = new System.Drawing.Size(766, 350);
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.gbPurchaseHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvPurchaseHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.Label lblReorderQuantity;
        private System.Windows.Forms.Label lblReorderLevel;
        private System.Windows.Forms.Label lblVendorItemNum;
        public System.Windows.Forms.TextBox txtReorderQuantity;
        public System.Windows.Forms.TextBox txtReorderLevel;
        public System.Windows.Forms.TextBox txtVendorItemNum;
        public System.Windows.Forms.GroupBox gbPurchaseHistory;
        private System.Windows.Forms.DataGridView lvPurchaseHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuppNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetCost;


    }
}