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
            this.gbBarcode = new Gizmox.WebGUI.Forms.GroupBox();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvBarcodeList = new Gizmox.WebGUI.Forms.ListView();
            this.colBarcodeId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcodeType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPrimaryBarcode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tbBarcode = new Gizmox.WebGUI.Forms.ToolBar();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcodeType = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryBarcode = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblPrimaryBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.cboBarcodeType = new Gizmox.WebGUI.Forms.ComboBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            this.SuspendLayout();
            // 
            // gbBarcode
            // 
            this.gbBarcode.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbBarcode.Controls.Add(this.splitContainer);
            this.gbBarcode.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gbBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.gbBarcode.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbBarcode.Location = new System.Drawing.Point(0, 0);
            this.gbBarcode.Name = "gbBarcode";
            this.gbBarcode.Size = new System.Drawing.Size(766, 350);
            this.gbBarcode.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 16);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvBarcodeList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(766, 350);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 8;
            // 
            // lvBarcodeList
            // 
            this.lvBarcodeList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvBarcodeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colBarcodeId,
            this.colStatus,
            this.colLN,
            this.colBarcode,
            this.colBarcodeType,
            this.colPrimaryBarcode});
            this.lvBarcodeList.DataMember = null;
            this.lvBarcodeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvBarcodeList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvBarcodeList.ItemsPerPage = 10;
            this.lvBarcodeList.Location = new System.Drawing.Point(0, 0);
            this.lvBarcodeList.Name = "lvBarcodeList";
            this.lvBarcodeList.Size = new System.Drawing.Size(347, 331);
            this.lvBarcodeList.TabIndex = 0;
            this.lvBarcodeList.UseInternalPaging = true;
            this.lvBarcodeList.Click += new System.EventHandler(this.lvBarcodeList_Click);
            // 
            // colBarcodeId
            // 
            this.colBarcodeId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colBarcodeId.Image = null;
            this.colBarcodeId.Text = "BarcodeId";
            this.colBarcodeId.Visible = false;
            this.colBarcodeId.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colStatus.Image = null;
            this.colStatus.Text = "";
            this.colStatus.Width = 30;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLN.Width = 40;
            // 
            // colBarcode
            // 
            this.colBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colBarcode.Image = null;
            this.colBarcode.Text = "Barcode";
            this.colBarcode.Width = 150;
            // 
            // colBarcodeType
            // 
            this.colBarcodeType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colBarcodeType.Image = null;
            this.colBarcodeType.Text = "Type";
            this.colBarcodeType.Width = 50;
            // 
            // colPrimaryBarcode
            // 
            this.colPrimaryBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPrimaryBarcode.Image = null;
            this.colPrimaryBarcode.Text = "Primary";
            this.colPrimaryBarcode.Width = 50;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbBarcode.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbBarcode.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbBarcode.DragHandle = false;
            this.tbBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tbBarcode.DropDownArrows = false;
            this.tbBarcode.ImageList = null;
            this.tbBarcode.Location = new System.Drawing.Point(0, 0);
            this.tbBarcode.MenuHandle = false;
            this.tbBarcode.Name = "tbBarcode";
            //this.tbBarcode.RightToLeft = false;
            this.tbBarcode.ShowToolTips = true;
            this.tbBarcode.TabIndex = 8;
            // 
            // lblBarcode
            // 
            this.lblBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblBarcode.Location = new System.Drawing.Point(16, 40);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode:";
            // 
            // lblBarcodeType
            // 
            this.lblBarcodeType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblBarcodeType.Location = new System.Drawing.Point(16, 68);
            this.lblBarcodeType.Name = "lblBarcodeType";
            this.lblBarcodeType.Size = new System.Drawing.Size(100, 23);
            this.lblBarcodeType.TabIndex = 0;
            this.lblBarcodeType.Text = "Type:";
            // 
            // chkPrimaryBarcode
            // 
            this.chkPrimaryBarcode.Checked = false;
            this.chkPrimaryBarcode.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkPrimaryBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkPrimaryBarcode.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPrimaryBarcode.Location = new System.Drawing.Point(122, 96);
            this.chkPrimaryBarcode.Name = "chkPrimaryBarcode";
            this.chkPrimaryBarcode.Size = new System.Drawing.Size(104, 24);
            this.chkPrimaryBarcode.TabIndex = 7;
            this.chkPrimaryBarcode.ThreeState = false;
            // 
            // lblPrimaryBarcode
            // 
            this.lblPrimaryBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPrimaryBarcode.Location = new System.Drawing.Point(16, 97);
            this.lblPrimaryBarcode.Name = "lblPrimaryBarcode";
            this.lblPrimaryBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblPrimaryBarcode.TabIndex = 0;
            this.lblPrimaryBarcode.Text = "Primary Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtBarcode.Location = new System.Drawing.Point(122, 37);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(136, 20);
            this.txtBarcode.TabIndex = 5;
            // 
            // cboBarcodeType
            // 
            this.cboBarcodeType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboBarcodeType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProductWizard_Barcode
            // 
            this.Controls.Add(this.gbBarcode);
            this.Size = new System.Drawing.Size(766, 350);
            this.Text = "ProductWizard_Barcode";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbBarcode;
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