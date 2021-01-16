namespace RT2020.Product
{
    partial class ProductWizard_Barcode
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvBarcodeList = new Gizmox.WebGUI.Forms.ListView();
            this.colBarcodeId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStatus = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colBarcode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colBarcodeType = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPrimaryBarcode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.tbBarcode = new Gizmox.WebGUI.Forms.ToolBar();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcodeType = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryBarcode = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblPrimaryBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.cboBarcodeType = new Gizmox.WebGUI.Forms.ComboBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(10, 10);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvBarcodeList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbBarcode);
            this.splitContainer.Panel2.Controls.Add(this.lblBarcode);
            this.splitContainer.Panel2.Controls.Add(this.lblBarcodeType);
            this.splitContainer.Panel2.Controls.Add(this.chkPrimaryBarcode);
            this.splitContainer.Panel2.Controls.Add(this.lblPrimaryBarcode);
            this.splitContainer.Panel2.Controls.Add(this.txtBarcode);
            this.splitContainer.Panel2.Controls.Add(this.cboBarcodeType);
            this.splitContainer.Size = new System.Drawing.Size(761, 343);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 8;
            // 
            // lvBarcodeList
            // 
            this.lvBarcodeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colBarcodeId,
            this.colStatus,
            this.colLN,
            this.colBarcode,
            this.colBarcodeType,
            this.colPrimaryBarcode});
            this.lvBarcodeList.DataMember = null;
            this.lvBarcodeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvBarcodeList.ItemsPerPage = 10;
            this.lvBarcodeList.Location = new System.Drawing.Point(0, 0);
            this.lvBarcodeList.Name = "lvBarcodeList";
            this.lvBarcodeList.Size = new System.Drawing.Size(350, 343);
            this.lvBarcodeList.TabIndex = 0;
            this.lvBarcodeList.UseInternalPaging = true;
            this.lvBarcodeList.Click += new System.EventHandler(this.lvBarcodeList_Click);
            // 
            // colBarcodeId
            // 
            this.colBarcodeId.Text = "BarcodeId";
            this.colBarcodeId.Visible = false;
            this.colBarcodeId.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "";
            this.colStatus.Width = 30;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLN.Width = 40;
            // 
            // colBarcode
            // 
            this.colBarcode.Text = "Barcode";
            this.colBarcode.Width = 150;
            // 
            // colBarcodeType
            // 
            this.colBarcodeType.Text = "Type";
            this.colBarcodeType.Width = 50;
            // 
            // colPrimaryBarcode
            // 
            this.colPrimaryBarcode.Text = "Primary";
            this.colPrimaryBarcode.Width = 50;
            // 
            // tbBarcode
            // 
            this.tbBarcode.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbBarcode.DragHandle = true;
            this.tbBarcode.DropDownArrows = true;
            this.tbBarcode.ImageSize = new System.Drawing.Size(16, 16);
            this.tbBarcode.Location = new System.Drawing.Point(0, 0);
            this.tbBarcode.MenuHandle = true;
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.ShowToolTips = true;
            this.tbBarcode.Size = new System.Drawing.Size(407, 26);
            this.tbBarcode.TabIndex = 8;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(16, 40);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode:";
            // 
            // lblBarcodeType
            // 
            this.lblBarcodeType.Location = new System.Drawing.Point(16, 68);
            this.lblBarcodeType.Name = "lblBarcodeType";
            this.lblBarcodeType.Size = new System.Drawing.Size(100, 23);
            this.lblBarcodeType.TabIndex = 0;
            this.lblBarcodeType.Text = "Type:";
            // 
            // chkPrimaryBarcode
            // 
            this.chkPrimaryBarcode.Location = new System.Drawing.Point(122, 96);
            this.chkPrimaryBarcode.Name = "chkPrimaryBarcode";
            this.chkPrimaryBarcode.Size = new System.Drawing.Size(104, 24);
            this.chkPrimaryBarcode.TabIndex = 7;
            // 
            // lblPrimaryBarcode
            // 
            this.lblPrimaryBarcode.Location = new System.Drawing.Point(16, 97);
            this.lblPrimaryBarcode.Name = "lblPrimaryBarcode";
            this.lblPrimaryBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblPrimaryBarcode.TabIndex = 0;
            this.lblPrimaryBarcode.Text = "Primary Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(122, 37);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(136, 20);
            this.txtBarcode.TabIndex = 5;
            // 
            // cboBarcodeType
            // 
            this.cboBarcodeType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboBarcodeType.DropDownWidth = 136;
            this.cboBarcodeType.Items.AddRange(new object[] {
            "INTERNAL (128B)",
            "EAN8",
            "EAN13",
            "UPC12"});
            this.cboBarcodeType.Location = new System.Drawing.Point(122, 65);
            this.cboBarcodeType.Name = "cboBarcodeType";
            this.cboBarcodeType.Size = new System.Drawing.Size(136, 21);
            this.cboBarcodeType.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // ProductWizard_Barcode
            // 
            this.Controls.Add(this.splitContainer);
            this.DockPadding.All = 10;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.Size = new System.Drawing.Size(781, 363);
            this.Text = "ProductWizard_Barcode";
            this.Load += new System.EventHandler(this.ProductWizard_Barcode_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.CheckBox chkPrimaryBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtBarcode;
        private Gizmox.WebGUI.Forms.ComboBox cboBarcodeType;
        private Gizmox.WebGUI.Forms.Label lblPrimaryBarcode;
        private Gizmox.WebGUI.Forms.Label lblBarcodeType;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ToolBar tbBarcode;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ListView lvBarcodeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcodeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcode;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcodeType;
        private Gizmox.WebGUI.Forms.ColumnHeader colPrimaryBarcode;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;


    }
}