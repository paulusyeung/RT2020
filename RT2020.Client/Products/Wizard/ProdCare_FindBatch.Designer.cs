namespace RT2020.Client.Products.Wizard
{
    partial class ProdCare_FindBatch
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
            this.lblStkCode = new System.Windows.Forms.Label();
            this.lblAppendix1 = new System.Windows.Forms.Label();
            this.lblAppendix2 = new System.Windows.Forms.Label();
            this.lblAppendix3 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.txtAppendix1 = new System.Windows.Forms.TextBox();
            this.txtAppendix2 = new System.Windows.Forms.TextBox();
            this.txtAppendix3 = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbFindingResult = new System.Windows.Forms.GroupBox();
            this.dgProductBatchList = new System.Windows.Forms.DataGridView();
            this.colProductBatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppendix3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFindingResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductBatchList)).BeginInit();
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
            this.btnFind.Location = new System.Drawing.Point(520, 82);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gbFindingResult
            // 
            this.gbFindingResult.Controls.Add(this.dgProductBatchList);
            this.gbFindingResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbFindingResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFindingResult.Location = new System.Drawing.Point(0, 105);
            this.gbFindingResult.Name = "gbFindingResult";
            this.gbFindingResult.Size = new System.Drawing.Size(638, 333);
            this.gbFindingResult.TabIndex = 11;
            this.gbFindingResult.TabStop = false;
            // 
            // dgProductBatchList
            // 
            this.dgProductBatchList.AllowUserToAddRows = false;
            this.dgProductBatchList.AllowUserToDeleteRows = false;
            this.dgProductBatchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductBatchId,
            this.colLN,
            this.colStockCode,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colDescription});
            this.dgProductBatchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProductBatchList.Location = new System.Drawing.Point(3, 16);
            this.dgProductBatchList.Name = "dgProductBatchList";
            this.dgProductBatchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductBatchList.Size = new System.Drawing.Size(632, 314);
            this.dgProductBatchList.TabIndex = 0;
            this.dgProductBatchList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductBatchList_CellClick);
            // 
            // colProductBatchId
            // 
            this.colProductBatchId.DataPropertyName = "BatchId";
            this.colProductBatchId.HeaderText = "ProductBatchId";
            this.colProductBatchId.Name = "colProductBatchId";
            this.colProductBatchId.Visible = false;
            this.colProductBatchId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "rownum";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.Width = 40;
            // 
            // colStockCode
            // 
            this.colStockCode.DataPropertyName = "STKCODE";
            this.colStockCode.HeaderText = "PLU";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.DataPropertyName = "APP1_COMBIN";
            this.colAppendix1.HeaderText = "Season Combin";
            this.colAppendix1.Name = "colAppendix1";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.DataPropertyName = "APP2_COMBIN";
            this.colAppendix2.HeaderText = "Color Combin";
            this.colAppendix2.Name = "colAppendix2";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.DataPropertyName = "APP3_COMBIN";
            this.colAppendix3.HeaderText = "Size Combin";
            this.colAppendix3.Name = "colAppendix3";
            this.colAppendix3.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 120;
            // 
            // ProdCare_FindBatch
            // 
            this.ClientSize = new System.Drawing.Size(638, 438);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdCare_FindBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Product";
            this.gbFindingResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductBatchList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStkCode;
        private System.Windows.Forms.Label lblAppendix1;
        private System.Windows.Forms.Label lblAppendix2;
        private System.Windows.Forms.Label lblAppendix3;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.TextBox txtAppendix1;
        private System.Windows.Forms.TextBox txtAppendix2;
        private System.Windows.Forms.TextBox txtAppendix3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox gbFindingResult;
        private System.Windows.Forms.DataGridView dgProductBatchList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductBatchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppendix3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;



    }
}