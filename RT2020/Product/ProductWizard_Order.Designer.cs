namespace RT2020.Product
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
            this.gbOrder = new Gizmox.WebGUI.Forms.GroupBox();
            this.gbPurchaseHistory = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtReorderQuantity = new Gizmox.WebGUI.Forms.TextBox();
            this.txtReorderLevel = new Gizmox.WebGUI.Forms.TextBox();
            this.txtVendorItemNum = new Gizmox.WebGUI.Forms.TextBox();
            this.lblReorderQuantity = new Gizmox.WebGUI.Forms.Label();
            this.lblReorderLevel = new Gizmox.WebGUI.Forms.Label();
            this.lblVendorItemNum = new Gizmox.WebGUI.Forms.Label();
            this.lvPurchaseHistory = new Gizmox.WebGUI.Forms.ListView();
            this.colRecDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSuppNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSuppName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPONumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colNetCost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // gbOrder
            // 
            this.gbOrder.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbOrder.Controls.Add(this.gbPurchaseHistory);
            this.gbOrder.Controls.Add(this.txtReorderQuantity);
            this.gbOrder.Controls.Add(this.txtReorderLevel);
            this.gbOrder.Controls.Add(this.txtVendorItemNum);
            this.gbOrder.Controls.Add(this.lblReorderQuantity);
            this.gbOrder.Controls.Add(this.lblReorderLevel);
            this.gbOrder.Controls.Add(this.lblVendorItemNum);
            this.gbOrder.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gbOrder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbOrder.Location = new System.Drawing.Point(0, 0);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(766, 350);
            this.gbOrder.TabIndex = 0;
            // 
            // gbPurchaseHistory
            // 
            this.gbPurchaseHistory.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbPurchaseHistory.Controls.Add(this.lvPurchaseHistory);
            this.gbPurchaseHistory.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.gbPurchaseHistory.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbPurchaseHistory.Location = new System.Drawing.Point(3, 39);
            this.gbPurchaseHistory.Name = "gbPurchaseHistory";
            this.gbPurchaseHistory.Size = new System.Drawing.Size(760, 308);
            this.gbPurchaseHistory.TabIndex = 6;
            this.gbPurchaseHistory.Text = "Purchase History";
            // 
            // txtReorderQuantity
            // 
            this.txtReorderQuantity.Location = new System.Drawing.Point(572, 13);
            this.txtReorderQuantity.Name = "txtReorderQuantity";
            this.txtReorderQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtReorderQuantity.TabIndex = 7;
            this.txtReorderQuantity.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(331, 13);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(100, 20);
            this.txtReorderLevel.TabIndex = 6;
            this.txtReorderLevel.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
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
            // lvPurchaseHistory
            // 
            this.lvPurchaseHistory.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvPurchaseHistory.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colRecDate,
            this.colSuppNumber,
            this.colSuppName,
            this.colTxNumber,
            this.colPONumber,
            this.colCost,
            this.colNetCost});
            this.lvPurchaseHistory.DataMember = null;
            this.lvPurchaseHistory.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPurchaseHistory.ItemsPerPage = 20;
            this.lvPurchaseHistory.Location = new System.Drawing.Point(3, 16);
            this.lvPurchaseHistory.Name = "lvPurchaseHistory";
            this.lvPurchaseHistory.Size = new System.Drawing.Size(754, 289);
            this.lvPurchaseHistory.TabIndex = 0;
            // 
            // colRecDate
            // 
            this.colRecDate.Image = null;
            this.colRecDate.Text = "Rec. Date";
            this.colRecDate.Width = 100;
            // 
            // colSuppNumber
            // 
            this.colSuppNumber.Image = null;
            this.colSuppNumber.Text = "Supplier#";
            this.colSuppNumber.Width = 100;
            // 
            // colSuppName
            // 
            this.colSuppName.Image = null;
            this.colSuppName.Text = "Supplier Name";
            this.colSuppName.Width = 100;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "TRN#";
            this.colTxNumber.Width = 100;
            // 
            // colPONumber
            // 
            this.colPONumber.Image = null;
            this.colPONumber.Text = "PO#";
            this.colPONumber.Width = 100;
            // 
            // colCost
            // 
            this.colCost.Image = null;
            this.colCost.Text = "Cost";
            this.colCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colCost.Width = 100;
            // 
            // colNetCost
            // 
            this.colNetCost.Image = null;
            this.colNetCost.Text = "Net Cost";
            this.colNetCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colNetCost.Width = 100;
            // 
            // ProductWizard_Order
            // 
            this.Controls.Add(this.gbOrder);
            this.Size = new System.Drawing.Size(766, 350);
            this.Text = "ProductWizard_Order";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbOrder;
        private Gizmox.WebGUI.Forms.Label lblReorderQuantity;
        private Gizmox.WebGUI.Forms.Label lblReorderLevel;
        private Gizmox.WebGUI.Forms.Label lblVendorItemNum;
        public Gizmox.WebGUI.Forms.TextBox txtReorderQuantity;
        public Gizmox.WebGUI.Forms.TextBox txtReorderLevel;
        public Gizmox.WebGUI.Forms.TextBox txtVendorItemNum;
        public Gizmox.WebGUI.Forms.GroupBox gbPurchaseHistory;
        private Gizmox.WebGUI.Forms.ListView lvPurchaseHistory;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colSuppNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colSuppName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colPONumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colNetCost;


    }
}