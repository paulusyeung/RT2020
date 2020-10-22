namespace RT2020.Inventory.StockTake
{
    partial class Wizard
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
            this.components = new System.ComponentModel.Container();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.txtStockTakeTotalAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCurrentTotalAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStockTakeTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCurrentTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.lblStockTakeTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblCurrentTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtCapturedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCapturedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtStatus = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateOn = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblTransactionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsStk = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.lblAverageCost = new Gizmox.WebGUI.Forms.Label();
            this.txtAverageCost = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRetailAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRetailPrice = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRetailAmount = new Gizmox.WebGUI.Forms.Label();
            this.lblRetailPrice = new Gizmox.WebGUI.Forms.Label();
            this.txtBookNum1Qty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBookNum1Qty = new Gizmox.WebGUI.Forms.Label();
            this.btnEditItem = new Gizmox.WebGUI.Forms.Button();
            this.lvDetailsList = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailsId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStockCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAppendix3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOnHandQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHHTQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBook1Qty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBook2Qty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBook3Qty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBook4Qty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBook5Qty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAverageCost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRetailPrice = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTotalRetailAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnCancelUpdate = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.txtLineCount = new Gizmox.WebGUI.Forms.Label();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.txtCurrentQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCurrentQty = new Gizmox.WebGUI.Forms.Label();
            this.txtHHTQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.lblHHTQty = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBookNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalRetailAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalRetailAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.cboBookNumber = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.txtStockTakeTotalAmount);
            this.tpGeneral.Controls.Add(this.txtCurrentTotalAmount);
            this.tpGeneral.Controls.Add(this.txtStockTakeTotalQty);
            this.tpGeneral.Controls.Add(this.txtCurrentTotalQty);
            this.tpGeneral.Controls.Add(this.lblTotalAmount);
            this.tpGeneral.Controls.Add(this.lblStockTakeTotalQty);
            this.tpGeneral.Controls.Add(this.lblCurrentTotalQty);
            this.tpGeneral.Controls.Add(this.lblTotalQty);
            this.tpGeneral.Controls.Add(this.txtCreatedOn);
            this.tpGeneral.Controls.Add(this.lblCreatedOn);
            this.tpGeneral.Controls.Add(this.txtCapturedOn);
            this.tpGeneral.Controls.Add(this.lblCapturedOn);
            this.tpGeneral.Controls.Add(this.txtStatus);
            this.tpGeneral.Controls.Add(this.txtLastUpdateBy);
            this.tpGeneral.Controls.Add(this.txtLastUpdateOn);
            this.tpGeneral.Controls.Add(this.dtpTxDate);
            this.tpGeneral.Controls.Add(this.cboLocation);
            this.tpGeneral.Controls.Add(this.lblLastUpdate);
            this.tpGeneral.Controls.Add(this.lblStatus);
            this.tpGeneral.Controls.Add(this.lblLocation);
            this.tpGeneral.Controls.Add(this.lblTransactionDate);
            this.tpGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(766, 379);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // txtStockTakeTotalAmount
            // 
            this.txtStockTakeTotalAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtStockTakeTotalAmount.Enabled = false;
            this.txtStockTakeTotalAmount.Location = new System.Drawing.Point(597, 54);
            this.txtStockTakeTotalAmount.Name = "txtStockTakeTotalAmount";
            this.txtStockTakeTotalAmount.ReadOnly = true;
            this.txtStockTakeTotalAmount.Size = new System.Drawing.Size(59, 20);
            this.txtStockTakeTotalAmount.TabIndex = 7;
            // 
            // txtCurrentTotalAmount
            // 
            this.txtCurrentTotalAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtCurrentTotalAmount.Enabled = false;
            this.txtCurrentTotalAmount.Location = new System.Drawing.Point(526, 54);
            this.txtCurrentTotalAmount.Name = "txtCurrentTotalAmount";
            this.txtCurrentTotalAmount.ReadOnly = true;
            this.txtCurrentTotalAmount.Size = new System.Drawing.Size(62, 20);
            this.txtCurrentTotalAmount.TabIndex = 5;
            // 
            // txtStockTakeTotalQty
            // 
            this.txtStockTakeTotalQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtStockTakeTotalQty.Enabled = false;
            this.txtStockTakeTotalQty.Location = new System.Drawing.Point(597, 31);
            this.txtStockTakeTotalQty.Name = "txtStockTakeTotalQty";
            this.txtStockTakeTotalQty.ReadOnly = true;
            this.txtStockTakeTotalQty.Size = new System.Drawing.Size(59, 20);
            this.txtStockTakeTotalQty.TabIndex = 6;
            // 
            // txtCurrentTotalQty
            // 
            this.txtCurrentTotalQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtCurrentTotalQty.Enabled = false;
            this.txtCurrentTotalQty.Location = new System.Drawing.Point(526, 31);
            this.txtCurrentTotalQty.Name = "txtCurrentTotalQty";
            this.txtCurrentTotalQty.ReadOnly = true;
            this.txtCurrentTotalQty.Size = new System.Drawing.Size(62, 20);
            this.txtCurrentTotalQty.TabIndex = 4;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(458, 57);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(62, 23);
            this.lblTotalAmount.TabIndex = 18;
            this.lblTotalAmount.Text = "Amount";
            // 
            // lblStockTakeTotalQty
            // 
            this.lblStockTakeTotalQty.Location = new System.Drawing.Point(594, 14);
            this.lblStockTakeTotalQty.Name = "lblStockTakeTotalQty";
            this.lblStockTakeTotalQty.Size = new System.Drawing.Size(62, 23);
            this.lblStockTakeTotalQty.TabIndex = 20;
            this.lblStockTakeTotalQty.Text = "Stock Take";
            // 
            // lblCurrentTotalQty
            // 
            this.lblCurrentTotalQty.Location = new System.Drawing.Point(526, 14);
            this.lblCurrentTotalQty.Name = "lblCurrentTotalQty";
            this.lblCurrentTotalQty.Size = new System.Drawing.Size(62, 23);
            this.lblCurrentTotalQty.TabIndex = 19;
            this.lblCurrentTotalQty.Text = "Current";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Location = new System.Drawing.Point(458, 34);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(62, 23);
            this.lblTotalQty.TabIndex = 17;
            this.lblTotalQty.Text = "Qty";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtCreatedOn.Enabled = false;
            this.txtCreatedOn.Location = new System.Drawing.Point(123, 265);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtCreatedOn.TabIndex = 16;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Location = new System.Drawing.Point(17, 268);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedOn.TabIndex = 15;
            this.lblCreatedOn.Text = "Creation Date";
            // 
            // txtCapturedOn
            // 
            this.txtCapturedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtCapturedOn.Enabled = false;
            this.txtCapturedOn.Location = new System.Drawing.Point(123, 80);
            this.txtCapturedOn.Name = "txtCapturedOn";
            this.txtCapturedOn.ReadOnly = true;
            this.txtCapturedOn.Size = new System.Drawing.Size(244, 20);
            this.txtCapturedOn.TabIndex = 3;
            // 
            // lblCapturedOn
            // 
            this.lblCapturedOn.Location = new System.Drawing.Point(17, 83);
            this.lblCapturedOn.Name = "lblCapturedOn";
            this.lblCapturedOn.Size = new System.Drawing.Size(100, 23);
            this.lblCapturedOn.TabIndex = 11;
            this.lblCapturedOn.Text = "Capture Date";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.LightYellow;
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(123, 57);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 2;
            // 
            // txtLastUpdateBy
            // 
            this.txtLastUpdateBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateBy.Enabled = false;
            this.txtLastUpdateBy.Location = new System.Drawing.Point(229, 242);
            this.txtLastUpdateBy.Name = "txtLastUpdateBy";
            this.txtLastUpdateBy.ReadOnly = true;
            this.txtLastUpdateBy.Size = new System.Drawing.Size(65, 20);
            this.txtLastUpdateBy.TabIndex = 14;
            // 
            // txtLastUpdateOn
            // 
            this.txtLastUpdateOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateOn.Enabled = false;
            this.txtLastUpdateOn.Location = new System.Drawing.Point(123, 242);
            this.txtLastUpdateOn.Name = "txtLastUpdateOn";
            this.txtLastUpdateOn.ReadOnly = true;
            this.txtLastUpdateOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdateOn.TabIndex = 13;
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(123, 12);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 1;
            // 
            // cboLocation
            // 
            this.cboLocation.BackColor = System.Drawing.Color.LightYellow;
            this.cboLocation.DropDownWidth = 215;
            this.cboLocation.Enabled = false;
            this.cboLocation.Location = new System.Drawing.Point(123, 34);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(244, 21);
            this.cboLocation.TabIndex = 1;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(17, 245);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpdate.TabIndex = 12;
            this.lblLastUpdate.Text = "Last Update";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(17, 37);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Loc#";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(17, 14);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(100, 23);
            this.lblTransactionDate.TabIndex = 8;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(23, 46);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(76, 23);
            this.lblTxNumber.TabIndex = 4;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // tabGoodsStk
            // 
            this.tabGoodsStk.Controls.Add(this.tpGeneral);
            this.tabGoodsStk.Controls.Add(this.tpDetails);
            this.tabGoodsStk.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsStk.Multiline = false;
            this.tabGoodsStk.Name = "tabGoodsStk";
            this.tabGoodsStk.SelectedIndex = 0;
            this.tabGoodsStk.ShowCloseButton = false;
            this.tabGoodsStk.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsStk.TabIndex = 3;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.lblAverageCost);
            this.tpDetails.Controls.Add(this.txtAverageCost);
            this.tpDetails.Controls.Add(this.txtRetailAmount);
            this.tpDetails.Controls.Add(this.txtRetailPrice);
            this.tpDetails.Controls.Add(this.lblRetailAmount);
            this.tpDetails.Controls.Add(this.lblRetailPrice);
            this.tpDetails.Controls.Add(this.txtBookNum1Qty);
            this.tpDetails.Controls.Add(this.lblBookNum1Qty);
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnCancelUpdate);
            this.tpDetails.Controls.Add(this.btnAddItem);
            this.tpDetails.Controls.Add(this.txtLineCount);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.txtCurrentQty);
            this.tpDetails.Controls.Add(this.lblCurrentQty);
            this.tpDetails.Controls.Add(this.txtHHTQty);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.lblHHTQty);
            this.tpDetails.Controls.Add(this.basicProduct);
            this.tpDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // lblAverageCost
            // 
            this.lblAverageCost.Location = new System.Drawing.Point(443, 15);
            this.lblAverageCost.Name = "lblAverageCost";
            this.lblAverageCost.Size = new System.Drawing.Size(100, 23);
            this.lblAverageCost.TabIndex = 17;
            this.lblAverageCost.Text = "Average Cost:";
            this.lblAverageCost.Visible = false;
            // 
            // txtAverageCost
            // 
            this.txtAverageCost.BackColor = System.Drawing.Color.LightYellow;
            this.txtAverageCost.Location = new System.Drawing.Point(549, 9);
            this.txtAverageCost.Name = "txtAverageCost";
            this.txtAverageCost.ReadOnly = true;
            this.txtAverageCost.Size = new System.Drawing.Size(100, 20);
            this.txtAverageCost.TabIndex = 8;
            this.txtAverageCost.Visible = false;
            // 
            // txtRetailAmount
            // 
            this.txtRetailAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtRetailAmount.Location = new System.Drawing.Point(549, 58);
            this.txtRetailAmount.Name = "txtRetailAmount";
            this.txtRetailAmount.ReadOnly = true;
            this.txtRetailAmount.Size = new System.Drawing.Size(100, 20);
            this.txtRetailAmount.TabIndex = 10;
            // 
            // txtRetailPrice
            // 
            this.txtRetailPrice.BackColor = System.Drawing.Color.LightYellow;
            this.txtRetailPrice.Location = new System.Drawing.Point(549, 35);
            this.txtRetailPrice.Name = "txtRetailPrice";
            this.txtRetailPrice.ReadOnly = true;
            this.txtRetailPrice.Size = new System.Drawing.Size(100, 20);
            this.txtRetailPrice.TabIndex = 9;
            // 
            // lblRetailAmount
            // 
            this.lblRetailAmount.Location = new System.Drawing.Point(443, 61);
            this.lblRetailAmount.Name = "lblRetailAmount";
            this.lblRetailAmount.Size = new System.Drawing.Size(103, 23);
            this.lblRetailAmount.TabIndex = 19;
            this.lblRetailAmount.Text = "Retail Amount($)";
            // 
            // lblRetailPrice
            // 
            this.lblRetailPrice.Location = new System.Drawing.Point(443, 38);
            this.lblRetailPrice.Name = "lblRetailPrice";
            this.lblRetailPrice.Size = new System.Drawing.Size(103, 23);
            this.lblRetailPrice.TabIndex = 18;
            this.lblRetailPrice.Text = "Retail Price";
            // 
            // txtBookNum1Qty
            // 
            this.txtBookNum1Qty.Location = new System.Drawing.Point(358, 58);
            this.txtBookNum1Qty.Name = "txtBookNum1Qty";
            this.txtBookNum1Qty.Size = new System.Drawing.Size(63, 20);
            this.txtBookNum1Qty.TabIndex = 1;
            this.txtBookNum1Qty.TextChanged += new System.EventHandler(this.txtBookNum1Qty_TextChanged);
            // 
            // lblBookNum1Qty
            // 
            this.lblBookNum1Qty.Location = new System.Drawing.Point(284, 61);
            this.lblBookNum1Qty.Name = "lblBookNum1Qty";
            this.lblBookNum1Qty.Size = new System.Drawing.Size(72, 23);
            this.lblBookNum1Qty.TabIndex = 16;
            this.lblBookNum1Qty.Text = "Book# {0} Qty";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(655, 33);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 3;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // lvDetailsList
            // 
            this.lvDetailsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailsId,
            this.colStatus,
            this.colLN,
            this.colStockCode,
            this.colAppendix1,
            this.colAppendix2,
            this.colAppendix3,
            this.colOnHandQty,
            this.colHHTQty,
            this.colBook1Qty,
            this.colBook2Qty,
            this.colBook3Qty,
            this.colBook4Qty,
            this.colBook5Qty,
            this.colAverageCost,
            this.colRetailPrice,
            this.colTotalRetailAmount});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 98);
            this.lvDetailsList.MultiSelect = false;
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 278);
            this.lvDetailsList.TabIndex = 20;
            this.lvDetailsList.SelectedIndexChanged += new System.EventHandler(this.lvDetailsList_SelectedIndexChanged);
            // 
            // colDetailsId
            // 
            this.colDetailsId.Image = null;
            this.colDetailsId.Text = "DetailsId";
            this.colDetailsId.Visible = false;
            this.colDetailsId.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 40;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
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
            // colOnHandQty
            // 
            this.colOnHandQty.Image = null;
            this.colOnHandQty.Text = "On-Hand";
            this.colOnHandQty.Width = 50;
            // 
            // colHHTQty
            // 
            this.colHHTQty.Image = null;
            this.colHHTQty.Text = "HHT";
            this.colHHTQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHHTQty.Width = 50;
            // 
            // colBook1Qty
            // 
            this.colBook1Qty.Image = null;
            this.colBook1Qty.Text = "Book1";
            this.colBook1Qty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colBook1Qty.Width = 80;
            // 
            // colBook2Qty
            // 
            this.colBook2Qty.Image = null;
            this.colBook2Qty.Text = "Book2";
            this.colBook2Qty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colBook2Qty.Width = 80;
            // 
            // colBook3Qty
            // 
            this.colBook3Qty.Image = null;
            this.colBook3Qty.Text = "Book3";
            this.colBook3Qty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colBook3Qty.Width = 80;
            // 
            // colBook4Qty
            // 
            this.colBook4Qty.Image = null;
            this.colBook4Qty.Text = "Book4";
            this.colBook4Qty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colBook4Qty.Width = 80;
            // 
            // colBook5Qty
            // 
            this.colBook5Qty.Image = null;
            this.colBook5Qty.Text = "Book5";
            this.colBook5Qty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colBook5Qty.Width = 80;
            // 
            // colAverageCost
            // 
            this.colAverageCost.Image = null;
            this.colAverageCost.Text = "Average Cost";
            this.colAverageCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colAverageCost.Width = 80;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.Image = null;
            this.colRetailPrice.Text = "Retail Price";
            this.colRetailPrice.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colRetailPrice.Width = 80;
            // 
            // colTotalRetailAmount
            // 
            this.colTotalRetailAmount.Image = null;
            this.colTotalRetailAmount.Text = "Retail Amount($)";
            this.colTotalRetailAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTotalRetailAmount.Width = 80;
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Location = new System.Drawing.Point(655, 56);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnCancelUpdate.TabIndex = 4;
            this.btnCancelUpdate.Text = "Cancel Update";
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(655, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtLineCount
            // 
            this.txtLineCount.Location = new System.Drawing.Point(722, 82);
            this.txtLineCount.Name = "txtLineCount";
            this.txtLineCount.Size = new System.Drawing.Size(38, 23);
            this.txtLineCount.TabIndex = 21;
            this.txtLineCount.Text = "0";
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(652, 82);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(64, 23);
            this.lblLineCount.TabIndex = 21;
            this.lblLineCount.Text = "# of Line(s)";
            // 
            // txtCurrentQty
            // 
            this.txtCurrentQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtCurrentQty.Location = new System.Drawing.Point(89, 58);
            this.txtCurrentQty.Name = "txtCurrentQty";
            this.txtCurrentQty.ReadOnly = true;
            this.txtCurrentQty.Size = new System.Drawing.Size(63, 20);
            this.txtCurrentQty.TabIndex = 6;
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.Location = new System.Drawing.Point(17, 61);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(80, 23);
            this.lblCurrentQty.TabIndex = 14;
            this.lblCurrentQty.Text = "Current Qty";
            // 
            // txtHHTQty
            // 
            this.txtHHTQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtHHTQty.Location = new System.Drawing.Point(215, 58);
            this.txtHHTQty.Name = "txtHHTQty";
            this.txtHHTQty.ReadOnly = true;
            this.txtHHTQty.Size = new System.Drawing.Size(63, 20);
            this.txtHHTQty.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(89, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(284, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 23);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Description";
            // 
            // lblStockCode
            // 
            this.lblStockCode.Location = new System.Drawing.Point(17, 15);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(66, 23);
            this.lblStockCode.TabIndex = 12;
            this.lblStockCode.Text = "StockCode";
            // 
            // lblHHTQty
            // 
            this.lblHHTQty.Location = new System.Drawing.Point(158, 61);
            this.lblHHTQty.Name = "lblHHTQty";
            this.lblHHTQty.Size = new System.Drawing.Size(57, 23);
            this.lblHHTQty.TabIndex = 15;
            this.lblHHTQty.Text = "HHT Qty";
            // 
            // basicProduct
            // 
            this.basicProduct.Location = new System.Drawing.Point(86, 8);
            this.basicProduct.Name = "basicProduct";
            this.basicProduct.SelectedItem = null;
            this.basicProduct.SelectedText = " ";
            this.basicProduct.Size = new System.Drawing.Size(337, 27);
            this.basicProduct.TabIndex = 0;
            this.basicProduct.Text = "FindProduct";
            this.basicProduct.SelectionChanged += new System.EventHandler<RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs>(this.basicProduct_SelectionChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxNumber.Enabled = false;
            this.txtTxNumber.Location = new System.Drawing.Point(105, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 0;
            // 
            // lblBookNumber
            // 
            this.lblBookNumber.Location = new System.Drawing.Point(242, 46);
            this.lblBookNumber.Name = "lblBookNumber";
            this.lblBookNumber.Size = new System.Drawing.Size(47, 23);
            this.lblBookNumber.TabIndex = 5;
            this.lblBookNumber.Text = "Book#";
            // 
            // lblTotalRetailAmount
            // 
            this.lblTotalRetailAmount.Location = new System.Drawing.Point(371, 46);
            this.lblTotalRetailAmount.Name = "lblTotalRetailAmount";
            this.lblTotalRetailAmount.Size = new System.Drawing.Size(85, 23);
            this.lblTotalRetailAmount.TabIndex = 6;
            this.lblTotalRetailAmount.Text = "Total Retail($):";
            // 
            // txtTotalRetailAmount
            // 
            this.txtTotalRetailAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalRetailAmount.Enabled = false;
            this.txtTotalRetailAmount.Location = new System.Drawing.Point(462, 43);
            this.txtTotalRetailAmount.Name = "txtTotalRetailAmount";
            this.txtTotalRetailAmount.ReadOnly = true;
            this.txtTotalRetailAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalRetailAmount.TabIndex = 2;
            // 
            // cboBookNumber
            // 
            this.cboBookNumber.DropDownWidth = 48;
            this.cboBookNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboBookNumber.Location = new System.Drawing.Point(295, 43);
            this.cboBookNumber.Name = "cboBookNumber";
            this.cboBookNumber.Size = new System.Drawing.Size(48, 21);
            this.cboBookNumber.TabIndex = 0;
            this.cboBookNumber.SelectedIndexChanged += new System.EventHandler(this.cboBookNumber_SelectedIndexChanged);
            // 
            // Wizard
            // 
            this.Controls.Add(this.cboBookNumber);
            this.Controls.Add(this.txtTotalRetailAmount);
            this.Controls.Add(this.lblTotalRetailAmount);
            this.Controls.Add(this.lblBookNumber);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.tabGoodsStk);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.tbWizardAction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Take > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsStk;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTransactionDate;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblLocation;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.ComboBox cboLocation;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateOn;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtHHTQty;
        private Gizmox.WebGUI.Forms.Label lblHHTQty;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label txtLineCount;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.TextBox txtCurrentQty;
        private Gizmox.WebGUI.Forms.Label lblCurrentQty;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colOnHandQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colHHTQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colBook1Qty;
        private Gizmox.WebGUI.Forms.ColumnHeader colBook2Qty;
        private Gizmox.WebGUI.Forms.Button btnCancelUpdate;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedOn;
        private Gizmox.WebGUI.Forms.Label lblCreatedOn;
        private Gizmox.WebGUI.Forms.TextBox txtCapturedOn;
        private Gizmox.WebGUI.Forms.Label lblCapturedOn;
        private Gizmox.WebGUI.Forms.TextBox txtStatus;
        private Gizmox.WebGUI.Forms.TextBox txtStockTakeTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtCurrentTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtStockTakeTotalQty;
        private Gizmox.WebGUI.Forms.TextBox txtCurrentTotalQty;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.Label lblStockTakeTotalQty;
        private Gizmox.WebGUI.Forms.Label lblCurrentTotalQty;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label lblBookNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalRetailAmount;
        private Gizmox.WebGUI.Forms.TextBox txtTotalRetailAmount;
        private Gizmox.WebGUI.Forms.TextBox txtBookNum1Qty;
        private Gizmox.WebGUI.Forms.Label lblBookNum1Qty;
        private Gizmox.WebGUI.Forms.TextBox txtRetailAmount;
        private Gizmox.WebGUI.Forms.TextBox txtRetailPrice;
        private Gizmox.WebGUI.Forms.Label lblRetailAmount;
        private Gizmox.WebGUI.Forms.Label lblRetailPrice;
        private Gizmox.WebGUI.Forms.ColumnHeader colBook3Qty;
        private Gizmox.WebGUI.Forms.ColumnHeader colBook4Qty;
        private Gizmox.WebGUI.Forms.ColumnHeader colBook5Qty;
        private Gizmox.WebGUI.Forms.ColumnHeader colAverageCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colRetailPrice;
        private Gizmox.WebGUI.Forms.ColumnHeader colTotalRetailAmount;
        private Gizmox.WebGUI.Forms.ComboBox cboBookNumber;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;
        private Gizmox.WebGUI.Forms.Label lblAverageCost;
        private Gizmox.WebGUI.Forms.TextBox txtAverageCost;


    }
}