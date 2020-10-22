namespace RT2020.Inventory.Adjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard));
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.txtTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtRefNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblRefNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsADJ = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.lblRemarks_Details = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks_Details = new Gizmox.WebGUI.Forms.TextBox();
            this.txtOnHand = new Gizmox.WebGUI.Forms.TextBox();
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
            this.colQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOnHandQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAvgCost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTotalAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.lblNumberOfLine = new Gizmox.WebGUI.Forms.Label();
            this.txtAvgCost = new Gizmox.WebGUI.Forms.TextBox();
            this.lblOnHand = new Gizmox.WebGUI.Forms.Label();
            this.lblAvgCost = new Gizmox.WebGUI.Forms.Label();
            this.txtQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblQty = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.basicFindProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTxType
            // 
            this.lblTxType.Location = new System.Drawing.Point(23, 46);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(61, 23);
            this.lblTxType.TabIndex = 8;
            this.lblTxType.TabStop = false;
            this.lblTxType.Text = "Type:";
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
            this.tpGeneral.Controls.Add(this.txtTotalQty);
            this.tpGeneral.Controls.Add(this.txtLastUpdateBy);
            this.tpGeneral.Controls.Add(this.txtLastUpdateOn);
            this.tpGeneral.Controls.Add(this.cboStatus);
            this.tpGeneral.Controls.Add(this.txtRefNumber);
            this.tpGeneral.Controls.Add(this.txtRemarks);
            this.tpGeneral.Controls.Add(this.dtpTxDate);
            this.tpGeneral.Controls.Add(this.cboOperatorCode);
            this.tpGeneral.Controls.Add(this.cboWorkplace);
            this.tpGeneral.Controls.Add(this.lblRefNumber);
            this.tpGeneral.Controls.Add(this.lblTotalQty);
            this.tpGeneral.Controls.Add(this.lblLastUpdate);
            this.tpGeneral.Controls.Add(this.lblStatus);
            this.tpGeneral.Controls.Add(this.lblLocation);
            this.tpGeneral.Controls.Add(this.lblRemarks);
            this.tpGeneral.Controls.Add(this.lblTxDate);
            this.tpGeneral.Controls.Add(this.lblOperatorCode);
            this.tpGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(766, 379);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalQty.Location = new System.Drawing.Point(123, 150);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(100, 20);
            this.txtTotalQty.TabIndex = 23;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.Text = "0";
            // 
            // txtLastUpdateBy
            // 
            this.txtLastUpdateBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateBy.Location = new System.Drawing.Point(225, 196);
            this.txtLastUpdateBy.Name = "txtLastUpdateBy";
            this.txtLastUpdateBy.ReadOnly = true;
            this.txtLastUpdateBy.Size = new System.Drawing.Size(65, 20);
            this.txtLastUpdateBy.TabIndex = 20;
            this.txtLastUpdateBy.TabStop = false;
            // 
            // txtLastUpdateOn
            // 
            this.txtLastUpdateOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateOn.Location = new System.Drawing.Point(123, 196);
            this.txtLastUpdateOn.Name = "txtLastUpdateOn";
            this.txtLastUpdateOn.ReadOnly = true;
            this.txtLastUpdateOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdateOn.TabIndex = 19;
            this.txtLastUpdateOn.TabStop = false;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboStatus.DropDownWidth = 121;
            this.cboStatus.Items.AddRange(new object[] {
            "HOLD",
            "POST"});
            this.cboStatus.Location = new System.Drawing.Point(123, 127);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 5;
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.Location = new System.Drawing.Point(123, 81);
            this.txtRefNumber.MaxLength = 20;
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(215, 20);
            this.txtRefNumber.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(123, 104);
            this.txtRemarks.MaxLength = 30;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(347, 20);
            this.txtRemarks.TabIndex = 4;
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(123, 58);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 2;
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(123, 35);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(215, 21);
            this.cboOperatorCode.TabIndex = 1;
            this.cboOperatorCode.TextChanged += new System.EventHandler(this.cboOperatorCode_TextChanged);
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboWorkplace.DropDownWidth = 215;
            this.cboWorkplace.Location = new System.Drawing.Point(123, 12);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(215, 21);
            this.cboWorkplace.TabIndex = 0;
            this.cboWorkplace.TextChanged += new System.EventHandler(this.cboWorkplace_TextChanged);
            // 
            // lblRefNumber
            // 
            this.lblRefNumber.Location = new System.Drawing.Point(17, 84);
            this.lblRefNumber.Name = "lblRefNumber";
            this.lblRefNumber.Size = new System.Drawing.Size(82, 23);
            this.lblRefNumber.TabIndex = 10;
            this.lblRefNumber.TabStop = false;
            this.lblRefNumber.Text = "REF #";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Location = new System.Drawing.Point(17, 153);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(82, 23);
            this.lblTotalQty.TabIndex = 9;
            this.lblTotalQty.TabStop = false;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(17, 199);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(82, 23);
            this.lblLastUpdate.TabIndex = 8;
            this.lblLastUpdate.TabStop = false;
            this.lblLastUpdate.Text = "Last Update";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 130);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TabStop = false;
            this.lblStatus.Text = "Status";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(17, 15);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.TabStop = false;
            this.lblLocation.Text = "Loc#";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(17, 107);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.TabStop = false;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblTxDate
            // 
            this.lblTxDate.Location = new System.Drawing.Point(17, 61);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Size = new System.Drawing.Size(100, 23);
            this.lblTxDate.TabIndex = 2;
            this.lblTxDate.TabStop = false;
            this.lblTxDate.Text = "Transaction Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Location = new System.Drawing.Point(17, 38);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 23);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.TabStop = false;
            this.lblOperatorCode.Text = "Operator";
            // 
            // txtTxType
            // 
            this.txtTxType.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxType.Location = new System.Drawing.Point(90, 43);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.ReadOnly = true;
            this.txtTxType.Size = new System.Drawing.Size(64, 20);
            this.txtTxType.TabIndex = 1;
            this.txtTxType.TabStop = false;
            this.txtTxType.Text = "ADJ";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(172, 46);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(76, 23);
            this.lblTxNumber.TabIndex = 10;
            this.lblTxNumber.TabStop = false;
            this.lblTxNumber.Text = "Tx Number:";
            this.lblTxNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabGoodsADJ
            // 
            this.tabGoodsADJ.Controls.Add(this.tpGeneral);
            this.tabGoodsADJ.Controls.Add(this.tpDetails);
            this.tabGoodsADJ.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsADJ.Multiline = false;
            this.tabGoodsADJ.Name = "tabGoodsADJ";
            this.tabGoodsADJ.SelectedIndex = 0;
            this.tabGoodsADJ.ShowCloseButton = false;
            this.tabGoodsADJ.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsADJ.TabIndex = 9;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.lblRemarks_Details);
            this.tpDetails.Controls.Add(this.txtRemarks_Details);
            this.tpDetails.Controls.Add(this.txtOnHand);
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnRemove);
            this.tpDetails.Controls.Add(this.btnAddItem);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.lblNumberOfLine);
            this.tpDetails.Controls.Add(this.txtAvgCost);
            this.tpDetails.Controls.Add(this.lblOnHand);
            this.tpDetails.Controls.Add(this.lblAvgCost);
            this.tpDetails.Controls.Add(this.txtQty);
            this.tpDetails.Controls.Add(this.lblQty);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.basicFindProduct);
            this.tpDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // lblRemarks_Details
            // 
            this.lblRemarks_Details.Location = new System.Drawing.Point(17, 61);
            this.lblRemarks_Details.Name = "lblRemarks_Details";
            this.lblRemarks_Details.Size = new System.Drawing.Size(66, 23);
            this.lblRemarks_Details.TabIndex = 5;
            this.lblRemarks_Details.TabStop = false;
            this.lblRemarks_Details.Text = "Remarks";
            // 
            // txtRemarks_Details
            // 
            this.txtRemarks_Details.Location = new System.Drawing.Point(90, 58);
            this.txtRemarks_Details.MaxLength = 20;
            this.txtRemarks_Details.Name = "txtRemarks_Details";
            this.txtRemarks_Details.Size = new System.Drawing.Size(394, 20);
            this.txtRemarks_Details.TabIndex = 1;
            // 
            // txtOnHand
            // 
            this.txtOnHand.BackColor = System.Drawing.Color.LightYellow;
            this.txtOnHand.Location = new System.Drawing.Point(430, 81);
            this.txtOnHand.Name = "txtOnHand";
            this.txtOnHand.ReadOnly = true;
            this.txtOnHand.Size = new System.Drawing.Size(54, 20);
            this.txtOnHand.TabIndex = 29;
            this.txtOnHand.TabStop = false;
            this.txtOnHand.Text = "0";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(499, 33);
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
            this.colQty,
            this.colOnHandQty,
            this.colAvgCost,
            this.colTotalAmount,
            this.colRemarks,
            this.colProductId});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 107);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 269);
            this.lvDetailsList.TabIndex = 27;
            this.lvDetailsList.TabStop = false;
            this.lvDetailsList.SelectedIndexChanged += new System.EventHandler(this.lvDetailsList_SelectedIndexChanged);
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
            this.colAppendix1.Width = 45;
            // 
            // colAppendix2
            // 
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "COLOR";
            this.colAppendix2.Width = 45;
            // 
            // colAppendix3
            // 
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "SIZE";
            this.colAppendix3.Width = 45;
            // 
            // colDescription
            // 
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 80;
            // 
            // colQty
            // 
            this.colQty.Image = null;
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colQty.Width = 50;
            // 
            // colOnHandQty
            // 
            this.colOnHandQty.Image = null;
            this.colOnHandQty.Text = "On-Hand Qty";
            this.colOnHandQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colOnHandQty.Width = 50;
            // 
            // colAvgCost
            // 
            this.colAvgCost.Image = null;
            this.colAvgCost.Text = "Average Cost";
            this.colAvgCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colAvgCost.Width = 50;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.Image = null;
            this.colTotalAmount.Text = "Total Amount";
            this.colTotalAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTotalAmount.Width = 60;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // colProductId
            // 
            this.colProductId.Image = null;
            this.colProductId.Text = "ProductId";
            this.colProductId.Visible = false;
            this.colProductId.Width = 150;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(499, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(499, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(722, 84);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // lblNumberOfLine
            // 
            this.lblNumberOfLine.Location = new System.Drawing.Point(652, 84);
            this.lblNumberOfLine.Name = "lblNumberOfLine";
            this.lblNumberOfLine.Size = new System.Drawing.Size(64, 23);
            this.lblNumberOfLine.TabIndex = 21;
            this.lblNumberOfLine.TabStop = false;
            this.lblNumberOfLine.Text = "# of Line(s)";
            // 
            // txtAvgCost
            // 
            this.txtAvgCost.BackColor = System.Drawing.Color.LightYellow;
            this.txtAvgCost.Location = new System.Drawing.Point(270, 81);
            this.txtAvgCost.Name = "txtAvgCost";
            this.txtAvgCost.ReadOnly = true;
            this.txtAvgCost.Size = new System.Drawing.Size(61, 20);
            this.txtAvgCost.TabIndex = 20;
            this.txtAvgCost.TabStop = false;
            this.txtAvgCost.Text = "0.00";
            // 
            // lblOnHand
            // 
            this.lblOnHand.Location = new System.Drawing.Point(365, 84);
            this.lblOnHand.Name = "lblOnHand";
            this.lblOnHand.Size = new System.Drawing.Size(60, 23);
            this.lblOnHand.TabIndex = 18;
            this.lblOnHand.TabStop = false;
            this.lblOnHand.Text = "On-Hand";
            this.lblOnHand.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAvgCost
            // 
            this.lblAvgCost.Location = new System.Drawing.Point(170, 84);
            this.lblAvgCost.Name = "lblAvgCost";
            this.lblAvgCost.Size = new System.Drawing.Size(94, 23);
            this.lblAvgCost.TabIndex = 15;
            this.lblAvgCost.TabStop = false;
            this.lblAvgCost.Text = "Average Cost";
            this.lblAvgCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(89, 81);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(54, 20);
            this.txtQty.TabIndex = 2;
            this.txtQty.Text = "1";
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(17, 84);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 23);
            this.lblQty.TabIndex = 13;
            this.lblQty.TabStop = false;
            this.lblQty.Text = "Adj. Qty";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(89, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(395, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 23);
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
            // basicFindProduct
            // 
            this.basicFindProduct.Location = new System.Drawing.Point(87, 8);
            this.basicFindProduct.Name = "basicFindProduct";
            this.basicFindProduct.SelectedItem = null;
            this.basicFindProduct.SelectedText = " ";
            this.basicFindProduct.Size = new System.Drawing.Size(337, 27);
            this.basicFindProduct.TabIndex = 0;
            this.basicFindProduct.Text = "FindProduct";
            this.basicFindProduct.SelectionChanged += new System.EventHandler<RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs>(this.basicFindProduct_SelectionChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.DataSource = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.Icon = null;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxNumber.Location = new System.Drawing.Point(254, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 11;
            this.txtTxNumber.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(386, 46);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.TabStop = false;
            this.lblTotalAmount.Text = "Total Amount ($):";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalAmount.Location = new System.Drawing.Point(494, 43);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 13;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // Wizard
            // 
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.tabGoodsADJ);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxType);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblTxType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Adjustment > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsADJ;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtTotalAmount;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblTxDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblRefNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblLocation;
        private Gizmox.WebGUI.Forms.TextBox txtRefNumber;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.ComboBox cboStatus;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateOn;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.Label lblAvgCost;
        private Gizmox.WebGUI.Forms.TextBox txtQty;
        private Gizmox.WebGUI.Forms.Label lblQty;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label lblNumberOfLine;
        private Gizmox.WebGUI.Forms.TextBox txtAvgCost;
        private Gizmox.WebGUI.Forms.Label lblOnHand;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colOnHandQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colAvgCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductId;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.TextBox txtOnHand;
        private Gizmox.WebGUI.Forms.Label lblRemarks_Details;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks_Details;
        private Gizmox.WebGUI.Forms.ColumnHeader colTotalAmount;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private RT2020.Controls.ProductSearcher.Basic basicFindProduct;


    }
}