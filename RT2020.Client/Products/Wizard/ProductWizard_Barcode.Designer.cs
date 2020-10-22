namespace RT2020.Client.Products .Wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductWizard_Barcode));
            this.gbBarcode = new System.Windows.Forms.GroupBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgBarcodeList = new System.Windows.Forms.DataGridView();
            this.tbBarcode = new System.Windows.Forms.ToolBar();
            this.cmdRefresh = new System.Windows.Forms.ToolBarButton();
            this.cmdGenerate = new System.Windows.Forms.ToolBarButton();
            this.cmdAdd = new System.Windows.Forms.ToolBarButton();
            this.cmdDelete = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblBarcodeType = new System.Windows.Forms.Label();
            this.chkPrimaryBarcode = new System.Windows.Forms.CheckBox();
            this.lblPrimaryBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cboBarcodeType = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.colProductBarcodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrimaryBarcode = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbBarcode.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBarcodeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBarcode
            // 
            this.gbBarcode.Controls.Add(this.splitContainer);
            this.gbBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbBarcode.Location = new System.Drawing.Point(0, 0);
            this.gbBarcode.Name = "gbBarcode";
            this.gbBarcode.Size = new System.Drawing.Size(766, 350);
            this.gbBarcode.TabIndex = 0;
            this.gbBarcode.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 16);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgBarcodeList);
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
            this.splitContainer.Size = new System.Drawing.Size(760, 331);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 8;
            // 
            // dgBarcodeList
            // 
            this.dgBarcodeList.AllowUserToAddRows = false;
            this.dgBarcodeList.AllowUserToDeleteRows = false;
            this.dgBarcodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductBarcodeId,
            this.colStatus,
            this.colLN,
            this.colBarcode,
            this.colBarcodeType,
            this.colPrimaryBarcode});
            this.dgBarcodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBarcodeList.Location = new System.Drawing.Point(0, 0);
            this.dgBarcodeList.MultiSelect = false;
            this.dgBarcodeList.Name = "dgBarcodeList";
            this.dgBarcodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBarcodeList.Size = new System.Drawing.Size(350, 331);
            this.dgBarcodeList.TabIndex = 0;
            this.dgBarcodeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBarcodeList_CellClick);
            // 
            // tbBarcode
            // 
            this.tbBarcode.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.cmdRefresh,
            this.cmdGenerate,
            this.cmdAdd,
            this.cmdDelete});
            this.tbBarcode.DropDownArrows = true;
            this.tbBarcode.ImageList = this.imageList1;
            this.tbBarcode.Location = new System.Drawing.Point(0, 0);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.ShowToolTips = true;
            this.tbBarcode.Size = new System.Drawing.Size(406, 28);
            this.tbBarcode.TabIndex = 8;
            this.tbBarcode.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.tbBarcode.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbBarcode_ButtonClick);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.ImageIndex = 0;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Tag = "Refresh";
            this.cmdRefresh.Text = "Refresh";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.ImageIndex = 1;
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Tag = "Generate";
            this.cmdGenerate.Text = "Generate";
            // 
            // cmdAdd
            // 
            this.cmdAdd.ImageIndex = 2;
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Tag = "Add";
            this.cmdAdd.Text = "Add";
            // 
            // cmdDelete
            // 
            this.cmdDelete.ImageIndex = 3;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Tag = "Delete";
            this.cmdDelete.Text = "Delete";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "16_L_refresh.gif");
            this.imageList1.Images.SetKeyName(1, "ico_16_3.gif");
            this.imageList1.Images.SetKeyName(2, "16_converttooppo.gif");
            this.imageList1.Images.SetKeyName(3, "16_L_remove.gif");
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(16, 52);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode:";
            // 
            // lblBarcodeType
            // 
            this.lblBarcodeType.Location = new System.Drawing.Point(16, 80);
            this.lblBarcodeType.Name = "lblBarcodeType";
            this.lblBarcodeType.Size = new System.Drawing.Size(100, 23);
            this.lblBarcodeType.TabIndex = 0;
            this.lblBarcodeType.Text = "Type:";
            // 
            // chkPrimaryBarcode
            // 
            this.chkPrimaryBarcode.Location = new System.Drawing.Point(122, 108);
            this.chkPrimaryBarcode.Name = "chkPrimaryBarcode";
            this.chkPrimaryBarcode.Size = new System.Drawing.Size(104, 24);
            this.chkPrimaryBarcode.TabIndex = 7;
            // 
            // lblPrimaryBarcode
            // 
            this.lblPrimaryBarcode.Location = new System.Drawing.Point(16, 109);
            this.lblPrimaryBarcode.Name = "lblPrimaryBarcode";
            this.lblPrimaryBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblPrimaryBarcode.TabIndex = 0;
            this.lblPrimaryBarcode.Text = "Primary Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(122, 49);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(136, 20);
            this.txtBarcode.TabIndex = 5;
            // 
            // cboBarcodeType
            // 
            this.cboBarcodeType.DropDownWidth = 136;
            this.cboBarcodeType.Items.AddRange(new object[] {
            "INTERNAL (128B)",
            "EAN8",
            "EAN13",
            "UPC12"});
            this.cboBarcodeType.Location = new System.Drawing.Point(122, 77);
            this.cboBarcodeType.Name = "cboBarcodeType";
            this.cboBarcodeType.Size = new System.Drawing.Size(136, 21);
            this.cboBarcodeType.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // colProductBarcodeId
            // 
            this.colProductBarcodeId.DataPropertyName = "ProductBarcodeId";
            this.colProductBarcodeId.HeaderText = "BarcodeId";
            this.colProductBarcodeId.Name = "colProductBarcodeId";
            this.colProductBarcodeId.Visible = false;
            this.colProductBarcodeId.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 30;
            // 
            // colLN
            // 
            this.colLN.DataPropertyName = "rownum";
            this.colLN.HeaderText = "LN";
            this.colLN.Name = "colLN";
            this.colLN.ReadOnly = true;
            this.colLN.Width = 40;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 90;
            // 
            // colBarcodeType
            // 
            this.colBarcodeType.DataPropertyName = "BarcodeType";
            this.colBarcodeType.HeaderText = "Type";
            this.colBarcodeType.Name = "colBarcodeType";
            this.colBarcodeType.ReadOnly = true;
            this.colBarcodeType.Width = 50;
            // 
            // colPrimaryBarcode
            // 
            this.colPrimaryBarcode.DataPropertyName = "PrimaryBarcode";
            this.colPrimaryBarcode.HeaderText = "Primary";
            this.colPrimaryBarcode.Name = "colPrimaryBarcode";
            this.colPrimaryBarcode.ReadOnly = true;
            this.colPrimaryBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrimaryBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPrimaryBarcode.Width = 50;
            // 
            // ProductWizard_Barcode
            // 
            this.Controls.Add(this.gbBarcode);
            this.Name = "ProductWizard_Barcode";
            this.Size = new System.Drawing.Size(766, 350);
            this.gbBarcode.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBarcodeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBarcode;
        private System.Windows.Forms.CheckBox chkPrimaryBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cboBarcodeType;
        private System.Windows.Forms.Label lblPrimaryBarcode;
        private System.Windows.Forms.Label lblBarcodeType;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolBar tbBarcode;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgBarcodeList;
        private System.Windows.Forms.ToolBarButton cmdRefresh;
        private System.Windows.Forms.ToolBarButton cmdGenerate;
        private System.Windows.Forms.ToolBarButton cmdAdd;
        private System.Windows.Forms.ToolBarButton cmdDelete;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductBarcodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcodeType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrimaryBarcode;


    }
}