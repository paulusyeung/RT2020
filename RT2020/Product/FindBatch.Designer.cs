namespace RT2020.Product
{
    partial class FindBatch
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
            this.lblStkCode = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix1 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix2 = new Gizmox.WebGUI.Forms.Label();
            this.lblAppendix3 = new Gizmox.WebGUI.Forms.Label();
            this.lblProductName = new Gizmox.WebGUI.Forms.Label();
            this.txtStockCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAppendix1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAppendix2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAppendix3 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProductName = new Gizmox.WebGUI.Forms.TextBox();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.gbFindingResult = new Gizmox.WebGUI.Forms.GroupBox();
            this.lvProductBatchList = new Gizmox.WebGUI.Forms.ListView();
            this.colProductBatchId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStockCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDescription = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblStkCode
            // 
            this.lblStkCode.Location = new System.Drawing.Point(22, 18);
            this.lblStkCode.Name = "lblStkCode";
            this.lblStkCode.Size = new System.Drawing.Size(100, 23);
            this.lblStkCode.TabIndex = 0;
            this.lblStkCode.Text = "PLU:";
            // 
            // lblAppendix1
            // 
            this.lblAppendix1.Location = new System.Drawing.Point(22, 41);
            this.lblAppendix1.Name = "lblAppendix1";
            this.lblAppendix1.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix1.TabIndex = 1;
            this.lblAppendix1.Text = "Season:";
            // 
            // lblAppendix2
            // 
            this.lblAppendix2.Location = new System.Drawing.Point(22, 64);
            this.lblAppendix2.Name = "lblAppendix2";
            this.lblAppendix2.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix2.TabIndex = 2;
            this.lblAppendix2.Text = "Color:";
            // 
            // lblAppendix3
            // 
            this.lblAppendix3.Location = new System.Drawing.Point(22, 87);
            this.lblAppendix3.Name = "lblAppendix3";
            this.lblAppendix3.Size = new System.Drawing.Size(100, 23);
            this.lblAppendix3.TabIndex = 3;
            this.lblAppendix3.Text = "Size";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(22, 110);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 23);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "Product Name:";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(128, 15);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(370, 20);
            this.txtStockCode.TabIndex = 1;
            this.txtStockCode.Text = "*";
            // 
            // txtAppendix1
            // 
            this.txtAppendix1.Location = new System.Drawing.Point(128, 38);
            this.txtAppendix1.Name = "txtAppendix1";
            this.txtAppendix1.Size = new System.Drawing.Size(370, 20);
            this.txtAppendix1.TabIndex = 2;
            this.txtAppendix1.Text = "*";
            // 
            // txtAppendix2
            // 
            this.txtAppendix2.Location = new System.Drawing.Point(128, 61);
            this.txtAppendix2.Name = "txtAppendix2";
            this.txtAppendix2.Size = new System.Drawing.Size(370, 20);
            this.txtAppendix2.TabIndex = 3;
            this.txtAppendix2.Text = "*";
            // 
            // txtAppendix3
            // 
            this.txtAppendix3.Location = new System.Drawing.Point(128, 84);
            this.txtAppendix3.Name = "txtAppendix3";
            this.txtAppendix3.Size = new System.Drawing.Size(370, 20);
            this.txtAppendix3.TabIndex = 4;
            this.txtAppendix3.Text = "*";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(128, 107);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(370, 20);
            this.txtProductName.TabIndex = 5;
            this.txtProductName.Text = "*";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(522, 105);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gbFindingResult
            // 
            this.gbFindingResult.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbFindingResult.Controls.Add(this.lvProductBatchList);
            this.gbFindingResult.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.gbFindingResult.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbFindingResult.Location = new System.Drawing.Point(0, 133);
            this.gbFindingResult.Name = "gbFindingResult";
            this.gbFindingResult.Size = new System.Drawing.Size(644, 333);
            this.gbFindingResult.TabIndex = 11;
            // 
            // lvProductBatchList
            // 
            this.lvProductBatchList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvProductBatchList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colProductBatchId,
            this.colLN,
            this.colStockCode,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colDescription});
            this.lvProductBatchList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvProductBatchList.ItemsPerPage = 20;
            this.lvProductBatchList.Location = new System.Drawing.Point(3, 16);
            this.lvProductBatchList.Name = "lvProductBatchList";
            this.lvProductBatchList.Size = new System.Drawing.Size(644, 333);
            this.lvProductBatchList.TabIndex = 0;
            this.lvProductBatchList.UseInternalPaging = true;
            this.lvProductBatchList.SelectedIndexChanged += new System.EventHandler(this.lvProductList_SelectedIndexChanged);
            // 
            // colProductBatchId
            // 
            this.colProductBatchId.Image = null;
            this.colProductBatchId.Text = "ProductBatchId";
            this.colProductBatchId.Visible = false;
            this.colProductBatchId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 40;
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
            this.colAppendix1.Text = "Season Combin";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "Color Combin";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "Size Combin";
            this.colAppendix3.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 120;
            // 
            // ProdCare_FindBatch
            // 
            this.Controls.Add(this.gbFindingResult);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtAppendix3);
            this.Controls.Add(this.txtAppendix2);
            this.Controls.Add(this.txtAppendix1);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblAppendix3);
            this.Controls.Add(this.lblAppendix2);
            this.Controls.Add(this.lblAppendix1);
            this.Controls.Add(this.lblStkCode);
            this.Size = new System.Drawing.Size(644, 466);
            this.Text = "Find Product";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblStkCode;
        private Gizmox.WebGUI.Forms.Label lblAppendix1;
        private Gizmox.WebGUI.Forms.Label lblAppendix2;
        private Gizmox.WebGUI.Forms.Label lblAppendix3;
        private Gizmox.WebGUI.Forms.Label lblProductName;
        private Gizmox.WebGUI.Forms.TextBox txtStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix1;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix2;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix3;
        private Gizmox.WebGUI.Forms.TextBox txtProductName;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.GroupBox gbFindingResult;
        private Gizmox.WebGUI.Forms.ListView lvProductBatchList;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductBatchId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;



    }
}