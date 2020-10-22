namespace RT2020.Inventory.Transfer.Import
{
    partial class AdvanceImport_ListView
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
            this.lvDetailList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStockCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDescription = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvDetailList
            // 
            this.lvDetailList.CheckBoxes = true;
            this.lvDetailList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxNumber,
            this.colStockCode,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colBarcode,
            this.colDescription,
            this.colQty});
            this.lvDetailList.DataMember = null;
            this.lvDetailList.ItemsPerPage = 20;
            this.lvDetailList.Location = new System.Drawing.Point(3, 3);
            this.lvDetailList.Name = "lvDetailList";
            this.lvDetailList.Size = new System.Drawing.Size(692, 555);
            this.lvDetailList.TabIndex = 0;
            this.lvDetailList.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.lvDetailList_ItemCheck);
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.Width = 80;
            // 
            // colStockCode
            // 
            this.colStockCode.Image = null;
            this.colStockCode.Text = "PLU";
            this.colStockCode.Width = 100;
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
            // colBarcode
            // 
            this.colBarcode.Image = null;
            this.colBarcode.Text = "Barcode";
            this.colBarcode.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colQty
            // 
            this.colQty.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Right;
            this.colQty.Image = null;
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colQty.Width = 60;
            // 
            // AdvanceImport_ListView
            // 
            this.Controls.Add(this.lvDetailList);
            this.Size = new System.Drawing.Size(698, 561);
            this.Text = "Invt_TxferImportAdvanceWizard_ListView";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvDetailList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcode;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colQty;


    }
}