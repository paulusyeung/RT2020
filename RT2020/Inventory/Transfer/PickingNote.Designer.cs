namespace RT2020.Inventory.Transfer
{
    partial class PickingNote
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
            this.btnEditItem = new Gizmox.WebGUI.Forms.Button();
            this.lvDetailsList = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailsId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStockCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDescription = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRequiredQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtRequiredQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRequiredQty = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks_Detail = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks_Details = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.SuspendLayout();
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(512, 33);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 4;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // lvDetailsList
            // 
            this.lvDetailsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailsId,
            this.colLN,
            this.colStatus,
            this.colStockCode,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colDescription,
            this.colRequiredQty,
            this.colRemarks});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 87);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 289);
            this.lvDetailsList.TabIndex = 27;
            this.lvDetailsList.TabStop = false;
            this.lvDetailsList.Click += new System.EventHandler(this.lvDetailsList_Click);
            // 
            // colDetailsId
            // 
            this.colDetailsId.Image = null;
            this.colDetailsId.Text = "DetailsId";
            this.colDetailsId.Visible = false;
            this.colDetailsId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 40;
            // 
            // colStockCode
            // 
            this.colStockCode.Image = null;
            this.colStockCode.Text = "PLU";
            this.colStockCode.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.Image = null;
            this.colAppendix1.Text = "SEASON";
            this.colAppendix1.Width = 50;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "COLOR";
            this.colAppendix2.Width = 50;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "SIZE";
            this.colAppendix3.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colRequiredQty
            // 
            this.colRequiredQty.Image = null;
            this.colRequiredQty.Text = "Required Qty";
            this.colRequiredQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colRequiredQty.Width = 80;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(512, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(512, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(721, 61);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(651, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 21;
            this.label1.TabStop = false;
            this.label1.Text = "# of Line(s)";
            // 
            // txtRequiredQty
            // 
            this.txtRequiredQty.Location = new System.Drawing.Point(369, 58);
            this.txtRequiredQty.Name = "txtRequiredQty";
            this.txtRequiredQty.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredQty.TabIndex = 2;
            // 
            // lblRequiredQty
            // 
            this.lblRequiredQty.Location = new System.Drawing.Point(283, 61);
            this.lblRequiredQty.Name = "lblRequiredQty";
            this.lblRequiredQty.Size = new System.Drawing.Size(80, 23);
            this.lblRequiredQty.TabIndex = 15;
            this.lblRequiredQty.TabStop = false;
            this.lblRequiredQty.Text = "Required Qty";
            this.lblRequiredQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRemarks_Detail
            // 
            this.txtRemarks_Detail.Location = new System.Drawing.Point(144, 58);
            this.txtRemarks_Detail.MaxLength = 30;
            this.txtRemarks_Detail.Name = "txtRemarks_Detail";
            this.txtRemarks_Detail.Size = new System.Drawing.Size(133, 20);
            this.txtRemarks_Detail.TabIndex = 1;
            // 
            // lblRemarks_Details
            // 
            this.lblRemarks_Details.Location = new System.Drawing.Point(17, 61);
            this.lblRemarks_Details.Name = "lblRemarks_Details";
            this.lblRemarks_Details.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks_Details.TabIndex = 13;
            this.lblRemarks_Details.TabStop = false;
            this.lblRemarks_Details.Text = "Remarks";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(144, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(325, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.TabStop = false;
            this.lblDescription.Text = "Description";
            // 
            // lblStockCode
            // 
            this.lblStockCode.Location = new System.Drawing.Point(17, 15);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(66, 23);
            this.lblStockCode.TabIndex = 1;
            this.lblStockCode.TabStop = false;
            this.lblStockCode.Text = "StockCode";
            // 
            // basicProduct
            // 
            this.basicProduct.Location = new System.Drawing.Point(141, 8);
            this.basicProduct.Name = "basicProduct";
            this.basicProduct.SelectedItem = null;
            this.basicProduct.SelectedText = " ";
            this.basicProduct.Size = new System.Drawing.Size(337, 27);
            this.basicProduct.TabIndex = 0;
            this.basicProduct.Text = "FindProduct";
            this.basicProduct.SelectionChanged += new System.EventHandler<RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs>(this.basicProduct_SelectionChanged);
            // 
            // PickingNote
            // 
            this.Controls.Add(this.lblStockCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblRemarks_Details);
            this.Controls.Add(this.txtRemarks_Detail);
            this.Controls.Add(this.lblRequiredQty);
            this.Controls.Add(this.txtRequiredQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLineCount);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lvDetailsList);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.basicProduct);
            this.Size = new System.Drawing.Size(766, 379);
            this.Text = "Invt_GoodsTransferWizard_PickingNote";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequiredQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblRemarks_Details;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        public Gizmox.WebGUI.Forms.ListView lvDetailsList;
        public Gizmox.WebGUI.Forms.TextBox txtRemarks_Detail;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;


    }
}