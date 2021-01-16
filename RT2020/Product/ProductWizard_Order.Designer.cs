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
            this.lvPurchaseHistory = new Gizmox.WebGUI.Forms.ListView();
            this.colRecDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSuppNumber = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSuppName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTxNumber = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPONumber = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCost = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNetCost = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtReorderQuantity = new Gizmox.WebGUI.Forms.TextBox();
            this.txtReorderLevel = new Gizmox.WebGUI.Forms.TextBox();
            this.txtVendorItemNum = new Gizmox.WebGUI.Forms.TextBox();
            this.lblReorderQuantity = new Gizmox.WebGUI.Forms.Label();
            this.lblReorderLevel = new Gizmox.WebGUI.Forms.Label();
            this.lblVendorItemNum = new Gizmox.WebGUI.Forms.Label();
            this.lblPurchaseHistory = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // lvPurchaseHistory
            // 
            this.lvPurchaseHistory.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colRecDate,
            this.colSuppNumber,
            this.colSuppName,
            this.colTxNumber,
            this.colPONumber,
            this.colCost,
            this.colNetCost});
            this.lvPurchaseHistory.DataMember = null;
            this.lvPurchaseHistory.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.lvPurchaseHistory.Location = new System.Drawing.Point(10, 59);
            this.lvPurchaseHistory.Name = "lvPurchaseHistory";
            this.lvPurchaseHistory.Size = new System.Drawing.Size(746, 281);
            this.lvPurchaseHistory.TabIndex = 0;
            // 
            // colRecDate
            // 
            this.colRecDate.Text = "Rec. Date";
            this.colRecDate.Width = 100;
            // 
            // colSuppNumber
            // 
            this.colSuppNumber.Text = "Supplier#";
            this.colSuppNumber.Width = 100;
            // 
            // colSuppName
            // 
            this.colSuppName.Text = "Supplier Name";
            this.colSuppName.Width = 100;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Text = "TRN#";
            this.colTxNumber.Width = 100;
            // 
            // colPONumber
            // 
            this.colPONumber.Text = "PO#";
            this.colPONumber.Width = 100;
            // 
            // colCost
            // 
            this.colCost.Text = "Cost";
            this.colCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colCost.Width = 100;
            // 
            // colNetCost
            // 
            this.colNetCost.Text = "Net Cost";
            this.colNetCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colNetCost.Width = 100;
            // 
            // txtReorderQuantity
            // 
            this.txtReorderQuantity.Location = new System.Drawing.Point(566, 13);
            this.txtReorderQuantity.Name = "txtReorderQuantity";
            this.txtReorderQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtReorderQuantity.TabIndex = 7;
            this.txtReorderQuantity.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Location = new System.Drawing.Point(325, 13);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(100, 20);
            this.txtReorderLevel.TabIndex = 6;
            this.txtReorderLevel.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtVendorItemNum
            // 
            this.txtVendorItemNum.Location = new System.Drawing.Point(117, 13);
            this.txtVendorItemNum.Name = "txtVendorItemNum";
            this.txtVendorItemNum.Size = new System.Drawing.Size(100, 20);
            this.txtVendorItemNum.TabIndex = 5;
            // 
            // lblReorderQuantity
            // 
            this.lblReorderQuantity.Location = new System.Drawing.Point(464, 13);
            this.lblReorderQuantity.Name = "lblReorderQuantity";
            this.lblReorderQuantity.Size = new System.Drawing.Size(100, 20);
            this.lblReorderQuantity.TabIndex = 2;
            this.lblReorderQuantity.Text = "Re-Order Qty:";
            this.lblReorderQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReorderLevel
            // 
            this.lblReorderLevel.Location = new System.Drawing.Point(236, 13);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Size = new System.Drawing.Size(87, 20);
            this.lblReorderLevel.TabIndex = 1;
            this.lblReorderLevel.Text = "Re-Order Level:";
            this.lblReorderLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendorItemNum
            // 
            this.lblVendorItemNum.Location = new System.Drawing.Point(10, 13);
            this.lblVendorItemNum.Name = "lblVendorItemNum";
            this.lblVendorItemNum.Size = new System.Drawing.Size(104, 20);
            this.lblVendorItemNum.TabIndex = 0;
            this.lblVendorItemNum.Text = "Vendor Item#:";
            this.lblVendorItemNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPurchaseHistory
            // 
            this.lblPurchaseHistory.Location = new System.Drawing.Point(10, 39);
            this.lblPurchaseHistory.Name = "lblPurchaseHistory";
            this.lblPurchaseHistory.Size = new System.Drawing.Size(104, 20);
            this.lblPurchaseHistory.TabIndex = 0;
            this.lblPurchaseHistory.Text = "Purchase History:";
            this.lblPurchaseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductWizard_Order
            // 
            this.Controls.Add(this.lblPurchaseHistory);
            this.Controls.Add(this.lvPurchaseHistory);
            this.Controls.Add(this.txtReorderQuantity);
            this.Controls.Add(this.txtReorderLevel);
            this.Controls.Add(this.lblVendorItemNum);
            this.Controls.Add(this.txtVendorItemNum);
            this.Controls.Add(this.lblReorderLevel);
            this.Controls.Add(this.lblReorderQuantity);
            this.DockPadding.All = 10;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(766, 350);
            this.Text = "ProductWizard_Order";
            this.Load += new System.EventHandler(this.ProductWizard_Order_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.Label lblReorderQuantity;
        private Gizmox.WebGUI.Forms.Label lblReorderLevel;
        private Gizmox.WebGUI.Forms.Label lblVendorItemNum;
        public Gizmox.WebGUI.Forms.TextBox txtReorderQuantity;
        public Gizmox.WebGUI.Forms.TextBox txtReorderLevel;
        public Gizmox.WebGUI.Forms.TextBox txtVendorItemNum;
        private Gizmox.WebGUI.Forms.ListView lvPurchaseHistory;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colSuppNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colSuppName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colPONumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colNetCost;
        private Gizmox.WebGUI.Forms.Label lblPurchaseHistory;
    }
}