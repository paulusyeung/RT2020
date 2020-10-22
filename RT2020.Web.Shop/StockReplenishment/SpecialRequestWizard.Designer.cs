namespace RT2020.Web.Shop.StockReplenishment
{
    partial class SpecialRequestWizard
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnUpdate = new Gizmox.WebGUI.Forms.Button();
            this.txtTotalReplenishQty = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalReplenishQty = new Gizmox.WebGUI.Forms.Label();
            this.txtReplenishQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblReplenishQty = new Gizmox.WebGUI.Forms.Label();
            this.btnClear = new Gizmox.WebGUI.Forms.Button();
            this.cboAppendix3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix2 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboAppendix1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboSTKCODE = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.txtFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.listView = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSTKCODE = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromLocCDQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colToLocationCDQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colReplenishQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.toolBar = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbtnSave = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnSeparator = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnPrint = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer.Panel1.Controls.Add(this.txtTotalReplenishQty);
            this.splitContainer.Panel1.Controls.Add(this.lblTotalReplenishQty);
            this.splitContainer.Panel1.Controls.Add(this.txtReplenishQty);
            this.splitContainer.Panel1.Controls.Add(this.lblReplenishQty);
            this.splitContainer.Panel1.Controls.Add(this.btnClear);
            this.splitContainer.Panel1.Controls.Add(this.cboAppendix3);
            this.splitContainer.Panel1.Controls.Add(this.cboAppendix2);
            this.splitContainer.Panel1.Controls.Add(this.cboAppendix1);
            this.splitContainer.Panel1.Controls.Add(this.cboSTKCODE);
            this.splitContainer.Panel1.Controls.Add(this.lblStockCode);
            this.splitContainer.Panel1.Controls.Add(this.txtBarcode);
            this.splitContainer.Panel1.Controls.Add(this.lblBarcode);
            this.splitContainer.Panel1.Controls.Add(this.txtTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblFromLocation);
            this.splitContainer.Panel1.Controls.Add(this.txtFromLocation);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(770, 536);
            this.splitContainer.SplitterDistance = 120;
            this.splitContainer.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRemove.Location = new System.Drawing.Point(673, 88);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(576, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Add";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtTotalReplenishQty
            // 
            this.txtTotalReplenishQty.AutoSize = true;
            this.txtTotalReplenishQty.BackColor = System.Drawing.Color.Gold;
            this.txtTotalReplenishQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTotalReplenishQty.Location = new System.Drawing.Point(391, 66);
            this.txtTotalReplenishQty.Name = "txtTotalReplenishQty";
            this.txtTotalReplenishQty.Size = new System.Drawing.Size(91, 14);
            this.txtTotalReplenishQty.TabIndex = 15;
            this.txtTotalReplenishQty.Text = "{Total Rpl Qty}";
            // 
            // lblTotalReplenishQty
            // 
            this.lblTotalReplenishQty.AutoSize = true;
            this.lblTotalReplenishQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotalReplenishQty.Location = new System.Drawing.Point(267, 66);
            this.lblTotalReplenishQty.Name = "lblTotalReplenishQty";
            this.lblTotalReplenishQty.Size = new System.Drawing.Size(118, 14);
            this.lblTotalReplenishQty.TabIndex = 14;
            this.lblTotalReplenishQty.Text = "Total Replenish Qty:";
            // 
            // txtReplenishQty
            // 
            this.txtReplenishQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtReplenishQty.Location = new System.Drawing.Point(128, 63);
            this.txtReplenishQty.Name = "txtReplenishQty";
            this.txtReplenishQty.Size = new System.Drawing.Size(121, 22);
            this.txtReplenishQty.TabIndex = 13;
            this.txtReplenishQty.Text = "0";
            // 
            // lblReplenishQty
            // 
            this.lblReplenishQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblReplenishQty.Location = new System.Drawing.Point(16, 66);
            this.lblReplenishQty.Name = "lblReplenishQty";
            this.lblReplenishQty.Size = new System.Drawing.Size(108, 23);
            this.lblReplenishQty.TabIndex = 12;
            this.lblReplenishQty.Text = "Replenish Qty:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnClear.Location = new System.Drawing.Point(673, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboAppendix3
            // 
            this.cboAppendix3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix3.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboAppendix3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboAppendix3.Location = new System.Drawing.Point(591, 35);
            this.cboAppendix3.Name = "cboAppendix3";
            this.cboAppendix3.Size = new System.Drawing.Size(60, 22);
            this.cboAppendix3.TabIndex = 10;
            // 
            // cboAppendix2
            // 
            this.cboAppendix2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix2.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboAppendix2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboAppendix2.Location = new System.Drawing.Point(525, 35);
            this.cboAppendix2.Name = "cboAppendix2";
            this.cboAppendix2.Size = new System.Drawing.Size(60, 22);
            this.cboAppendix2.TabIndex = 9;
            // 
            // cboAppendix1
            // 
            this.cboAppendix1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAppendix1.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboAppendix1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboAppendix1.Location = new System.Drawing.Point(459, 35);
            this.cboAppendix1.Name = "cboAppendix1";
            this.cboAppendix1.Size = new System.Drawing.Size(60, 22);
            this.cboAppendix1.TabIndex = 8;
            // 
            // cboSTKCODE
            // 
            this.cboSTKCODE.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSTKCODE.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboSTKCODE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboSTKCODE.Location = new System.Drawing.Point(352, 35);
            this.cboSTKCODE.Name = "cboSTKCODE";
            this.cboSTKCODE.Size = new System.Drawing.Size(101, 22);
            this.cboSTKCODE.TabIndex = 7;
            // 
            // lblStockCode
            // 
            this.lblStockCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblStockCode.Location = new System.Drawing.Point(267, 38);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(79, 23);
            this.lblStockCode.TabIndex = 6;
            this.lblStockCode.Text = "Stock Code:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBarcode.Location = new System.Drawing.Point(130, 35);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(119, 22);
            this.txtBarcode.TabIndex = 5;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(16, 38);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(108, 23);
            this.lblBarcode.TabIndex = 4;
            this.lblBarcode.Text = "Barcode:";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.AutoSize = true;
            this.txtTxNumber.BackColor = System.Drawing.Color.Gold;
            this.txtTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTxNumber.Location = new System.Drawing.Point(352, 15);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(80, 14);
            this.txtTxNumber.TabIndex = 3;
            this.txtTxNumber.Text = "{Tx Number}";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTxNumber.Location = new System.Drawing.Point(267, 15);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(73, 23);
            this.lblTxNumber.TabIndex = 1;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFromLocation.Location = new System.Drawing.Point(16, 15);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(108, 23);
            this.lblFromLocation.TabIndex = 0;
            this.lblFromLocation.Text = "From Location:";
            // 
            // txtFromLocation
            // 
            this.txtFromLocation.BackColor = System.Drawing.Color.Gold;
            this.txtFromLocation.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFromLocation.Location = new System.Drawing.Point(130, 15);
            this.txtFromLocation.Name = "txtFromLocation";
            this.txtFromLocation.Size = new System.Drawing.Size(119, 14);
            this.txtFromLocation.TabIndex = 2;
            this.txtFromLocation.Text = "{From Location}";
            // 
            // listView
            // 
            this.listView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailId,
            this.colStatus,
            this.colSTKCODE,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colFromLocCDQty,
            this.colToLocationCDQty,
            this.colReplenishQty,
            this.colProductName});
            this.listView.DataMember = null;
            this.listView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listView.ItemsPerPage = 20;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(770, 412);
            this.listView.TabIndex = 0;
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // colDetailId
            // 
            this.colDetailId.Image = null;
            this.colDetailId.Text = "DetailId";
            this.colDetailId.Visible = false;
            this.colDetailId.Width = 50;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 50;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.Image = null;
            this.colSTKCODE.Text = "STKCODE";
            this.colSTKCODE.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.Image = null;
            this.colAppendix1.Text = "Appendix1";
            this.colAppendix1.Width = 80;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "Appendix2";
            this.colAppendix2.Width = 80;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "Appendix3";
            this.colAppendix3.Width = 80;
            // 
            // colFromLocCDQty
            // 
            this.colFromLocCDQty.Image = null;
            this.colFromLocCDQty.Text = "FM C/D";
            this.colFromLocCDQty.Width = 60;
            // 
            // colToLocationCDQty
            // 
            this.colToLocationCDQty.Image = null;
            this.colToLocationCDQty.Text = "TO C/D";
            this.colToLocationCDQty.Width = 60;
            // 
            // colReplenishQty
            // 
            this.colReplenishQty.Image = null;
            this.colReplenishQty.Text = "RPL";
            this.colReplenishQty.Width = 60;
            // 
            // colProductName
            // 
            this.colProductName.Image = null;
            this.colProductName.Text = "DESC.";
            this.colProductName.Width = 150;
            // 
            // toolBar
            // 
            this.toolBar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtnSave,
            this.tbtnSeparator,
            this.tbtnPrint});
            this.toolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar.DragHandle = true;
            this.toolBar.DropDownArrows = false;
            this.toolBar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolBar.ImageList = null;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.MenuHandle = true;
            this.toolBar.Name = "toolBar";
            //this.toolBar.RightToLeft = false;
            this.toolBar.ShowToolTips = true;
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnSave
            // 
            this.tbtnSave.CustomStyle = "";
            iconResourceHandle1.File = "16x16.16_L_save.gif";
            this.tbtnSave.Image = iconResourceHandle1;
            this.tbtnSave.ImageKey = null;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Pushed = true;
            this.tbtnSave.Size = 24;
            this.tbtnSave.Text = "Save";
            this.tbtnSave.ToolTipText = "";
            // 
            // tbtnSeparator
            // 
            this.tbtnSeparator.CustomStyle = "";
            this.tbtnSeparator.ImageKey = null;
            this.tbtnSeparator.Name = "tbtnSeparator";
            this.tbtnSeparator.Pushed = true;
            this.tbtnSeparator.Size = 24;
            this.tbtnSeparator.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.tbtnSeparator.ToolTipText = "";
            // 
            // tbtnPrint
            // 
            this.tbtnPrint.CustomStyle = "";
            iconResourceHandle2.File = "16x16.16_print.gif";
            this.tbtnPrint.Image = iconResourceHandle2;
            this.tbtnPrint.ImageKey = null;
            this.tbtnPrint.Name = "tbtnPrint";
            this.tbtnPrint.Pushed = true;
            this.tbtnPrint.Size = 24;
            this.tbtnPrint.Text = "Print";
            this.tbtnPrint.ToolTipText = "";
            // 
            // SpecialRequestWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBar);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(770, 564);
            this.Text = "Special Request Wizard";
            this.Load += new System.EventHandler(this.SpecialRequestWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Label txtFromLocation;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix3;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix2;
        private Gizmox.WebGUI.Forms.ComboBox cboAppendix1;
        private Gizmox.WebGUI.Forms.ComboBox cboSTKCODE;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtBarcode;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.Label txtTxNumber;
        private Gizmox.WebGUI.Forms.Button btnClear;
        private Gizmox.WebGUI.Forms.Label txtTotalReplenishQty;
        private Gizmox.WebGUI.Forms.Label lblTotalReplenishQty;
        private Gizmox.WebGUI.Forms.TextBox txtReplenishQty;
        private Gizmox.WebGUI.Forms.Label lblReplenishQty;
        private Gizmox.WebGUI.Forms.ToolBar toolBar;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSave;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnSeparator;
        private Gizmox.WebGUI.Forms.ToolBarButton tbtnPrint;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnUpdate;
        private Gizmox.WebGUI.Forms.ListView listView;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailId;
        private Gizmox.WebGUI.Forms.ColumnHeader colSTKCODE;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromLocCDQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colToLocationCDQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colReplenishQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductName;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;


    }
}