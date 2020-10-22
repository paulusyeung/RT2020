namespace RT2020.Inventory.Transfer
{
    partial class ConfirmationWizard
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
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalConfirmedQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalRequiredQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRecordStatus = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRecordStatus = new Gizmox.WebGUI.Forms.Label();
            this.txtLatestConfirmedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLatestConfirmedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboToLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboFromLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTotalRequiredQty = new Gizmox.WebGUI.Forms.Label();
            this.lblLatestConfirmation = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblTransactionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblToLocation = new Gizmox.WebGUI.Forms.Label();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsTxfer = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.btnResetAllItems = new Gizmox.WebGUI.Forms.Button();
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
            this.colConfirmedQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnConfirmAllItems = new Gizmox.WebGUI.Forms.Button();
            this.btnEditItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtConfirmedQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblConfirmedQty = new Gizmox.WebGUI.Forms.Label();
            this.txtRequiredQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRequiredQty = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtConfirmationStatus = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.tpGeneral.Controls.Add(this.dtpTxDate);
            this.tpGeneral.Controls.Add(this.label3);
            this.tpGeneral.Controls.Add(this.txtTotalConfirmedQty);
            this.tpGeneral.Controls.Add(this.txtTotalRequiredQty);
            this.tpGeneral.Controls.Add(this.txtRecordStatus);
            this.tpGeneral.Controls.Add(this.lblRecordStatus);
            this.tpGeneral.Controls.Add(this.txtLatestConfirmedBy);
            this.tpGeneral.Controls.Add(this.txtLatestConfirmedOn);
            this.tpGeneral.Controls.Add(this.cboToLocation);
            this.tpGeneral.Controls.Add(this.cboFromLocation);
            this.tpGeneral.Controls.Add(this.lblTotalRequiredQty);
            this.tpGeneral.Controls.Add(this.lblLatestConfirmation);
            this.tpGeneral.Controls.Add(this.lblFromLocation);
            this.tpGeneral.Controls.Add(this.lblTransactionDate);
            this.tpGeneral.Controls.Add(this.lblToLocation);
            this.tpGeneral.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(766, 379);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightYellow;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Enabled = false;
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(133, 58);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 5;
            this.dtpTxDate.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(344, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 9;
            this.label3.TabStop = false;
            this.label3.Text = "Total Confirmed Qty";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalConfirmedQty
            // 
            this.txtTotalConfirmedQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalConfirmedQty.Enabled = false;
            this.txtTotalConfirmedQty.Location = new System.Drawing.Point(472, 35);
            this.txtTotalConfirmedQty.Name = "txtTotalConfirmedQty";
            this.txtTotalConfirmedQty.ReadOnly = true;
            this.txtTotalConfirmedQty.Size = new System.Drawing.Size(100, 20);
            this.txtTotalConfirmedQty.TabIndex = 23;
            this.txtTotalConfirmedQty.TabStop = false;
            this.txtTotalConfirmedQty.Text = "0";
            this.txtTotalConfirmedQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalRequiredQty
            // 
            this.txtTotalRequiredQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalRequiredQty.Enabled = false;
            this.txtTotalRequiredQty.Location = new System.Drawing.Point(472, 12);
            this.txtTotalRequiredQty.Name = "txtTotalRequiredQty";
            this.txtTotalRequiredQty.ReadOnly = true;
            this.txtTotalRequiredQty.Size = new System.Drawing.Size(100, 20);
            this.txtTotalRequiredQty.TabIndex = 23;
            this.txtTotalRequiredQty.TabStop = false;
            this.txtTotalRequiredQty.Text = "0";
            this.txtTotalRequiredQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtRecordStatus
            // 
            this.txtRecordStatus.BackColor = System.Drawing.Color.LightYellow;
            this.txtRecordStatus.Enabled = false;
            this.txtRecordStatus.Location = new System.Drawing.Point(133, 219);
            this.txtRecordStatus.Name = "txtRecordStatus";
            this.txtRecordStatus.ReadOnly = true;
            this.txtRecordStatus.Size = new System.Drawing.Size(100, 20);
            this.txtRecordStatus.TabIndex = 22;
            this.txtRecordStatus.TabStop = false;
            this.txtRecordStatus.Text = "{0} History";
            // 
            // lblRecordStatus
            // 
            this.lblRecordStatus.Location = new System.Drawing.Point(17, 222);
            this.lblRecordStatus.Name = "lblRecordStatus";
            this.lblRecordStatus.Size = new System.Drawing.Size(100, 23);
            this.lblRecordStatus.TabIndex = 21;
            this.lblRecordStatus.TabStop = false;
            this.lblRecordStatus.Text = "Record Status";
            // 
            // txtLatestConfirmedBy
            // 
            this.txtLatestConfirmedBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLatestConfirmedBy.Enabled = false;
            this.txtLatestConfirmedBy.Location = new System.Drawing.Point(239, 196);
            this.txtLatestConfirmedBy.Name = "txtLatestConfirmedBy";
            this.txtLatestConfirmedBy.ReadOnly = true;
            this.txtLatestConfirmedBy.Size = new System.Drawing.Size(65, 20);
            this.txtLatestConfirmedBy.TabIndex = 20;
            this.txtLatestConfirmedBy.TabStop = false;
            // 
            // txtLatestConfirmedOn
            // 
            this.txtLatestConfirmedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLatestConfirmedOn.Enabled = false;
            this.txtLatestConfirmedOn.Location = new System.Drawing.Point(133, 196);
            this.txtLatestConfirmedOn.Name = "txtLatestConfirmedOn";
            this.txtLatestConfirmedOn.ReadOnly = true;
            this.txtLatestConfirmedOn.Size = new System.Drawing.Size(100, 20);
            this.txtLatestConfirmedOn.TabIndex = 19;
            this.txtLatestConfirmedOn.TabStop = false;
            // 
            // cboToLocation
            // 
            this.cboToLocation.BackColor = System.Drawing.Color.LightYellow;
            this.cboToLocation.DropDownWidth = 215;
            this.cboToLocation.Enabled = false;
            this.cboToLocation.Location = new System.Drawing.Point(133, 35);
            this.cboToLocation.Name = "cboToLocation";
            this.cboToLocation.Size = new System.Drawing.Size(215, 21);
            this.cboToLocation.TabIndex = 1;
            this.cboToLocation.TabStop = false;
            // 
            // cboFromLocation
            // 
            this.cboFromLocation.BackColor = System.Drawing.Color.LightYellow;
            this.cboFromLocation.DropDownWidth = 215;
            this.cboFromLocation.Enabled = false;
            this.cboFromLocation.Location = new System.Drawing.Point(133, 12);
            this.cboFromLocation.Name = "cboFromLocation";
            this.cboFromLocation.Size = new System.Drawing.Size(215, 21);
            this.cboFromLocation.TabIndex = 0;
            this.cboFromLocation.TabStop = false;
            // 
            // lblTotalRequiredQty
            // 
            this.lblTotalRequiredQty.Location = new System.Drawing.Point(344, 15);
            this.lblTotalRequiredQty.Name = "lblTotalRequiredQty";
            this.lblTotalRequiredQty.Size = new System.Drawing.Size(122, 23);
            this.lblTotalRequiredQty.TabIndex = 9;
            this.lblTotalRequiredQty.TabStop = false;
            this.lblTotalRequiredQty.Text = "Total Required Qty";
            this.lblTotalRequiredQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLatestConfirmation
            // 
            this.lblLatestConfirmation.Location = new System.Drawing.Point(17, 199);
            this.lblLatestConfirmation.Name = "lblLatestConfirmation";
            this.lblLatestConfirmation.Size = new System.Drawing.Size(110, 23);
            this.lblLatestConfirmation.TabIndex = 8;
            this.lblLatestConfirmation.TabStop = false;
            this.lblLatestConfirmation.Text = "Latest Confirmation";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Location = new System.Drawing.Point(17, 15);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(100, 23);
            this.lblFromLocation.TabIndex = 6;
            this.lblFromLocation.TabStop = false;
            this.lblFromLocation.Text = "From Location";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(17, 61);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(100, 23);
            this.lblTransactionDate.TabIndex = 4;
            this.lblTransactionDate.TabStop = false;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblToLocation
            // 
            this.lblToLocation.Location = new System.Drawing.Point(17, 38);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(100, 23);
            this.lblToLocation.TabIndex = 0;
            this.lblToLocation.TabStop = false;
            this.lblToLocation.Text = "To Location";
            // 
            // txtTxType
            // 
            this.txtTxType.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxType.Enabled = false;
            this.txtTxType.Location = new System.Drawing.Point(90, 43);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.ReadOnly = true;
            this.txtTxType.Size = new System.Drawing.Size(64, 20);
            this.txtTxType.TabIndex = 1;
            this.txtTxType.TabStop = false;
            this.txtTxType.Text = "TXF";
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
            // tabGoodsTxfer
            // 
            this.tabGoodsTxfer.Controls.Add(this.tpGeneral);
            this.tabGoodsTxfer.Controls.Add(this.tpDetails);
            this.tabGoodsTxfer.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsTxfer.Multiline = false;
            this.tabGoodsTxfer.Name = "tabGoodsTxfer";
            this.tabGoodsTxfer.SelectedIndex = 0;
            this.tabGoodsTxfer.ShowCloseButton = false;
            this.tabGoodsTxfer.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsTxfer.TabIndex = 9;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.btnResetAllItems);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnConfirmAllItems);
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.label1);
            this.tpDetails.Controls.Add(this.txtConfirmedQty);
            this.tpDetails.Controls.Add(this.lblConfirmedQty);
            this.tpDetails.Controls.Add(this.txtRequiredQty);
            this.tpDetails.Controls.Add(this.lblRequiredQty);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.basicProduct);
            this.tpDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // btnResetAllItems
            // 
            this.btnResetAllItems.Location = new System.Drawing.Point(468, 36);
            this.btnResetAllItems.Name = "btnResetAllItems";
            this.btnResetAllItems.Size = new System.Drawing.Size(133, 23);
            this.btnResetAllItems.TabIndex = 2;
            this.btnResetAllItems.Text = "Reset All Item(s)";
            this.btnResetAllItems.Click += new System.EventHandler(this.btnResetAllItems_Click);
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
            this.colConfirmedQty});
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
            // colConfirmedQty
            // 
            this.colConfirmedQty.Image = null;
            this.colConfirmedQty.Text = "Confirmed Qty";
            this.colConfirmedQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colConfirmedQty.Width = 150;
            // 
            // btnConfirmAllItems
            // 
            this.btnConfirmAllItems.Location = new System.Drawing.Point(468, 59);
            this.btnConfirmAllItems.Name = "btnConfirmAllItems";
            this.btnConfirmAllItems.Size = new System.Drawing.Size(133, 23);
            this.btnConfirmAllItems.TabIndex = 3;
            this.btnConfirmAllItems.Text = "Confirm All Item(s)";
            this.btnConfirmAllItems.Click += new System.EventHandler(this.btnConfirmAllItems_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(468, 13);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(133, 23);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(713, 64);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(643, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 21;
            this.label1.TabStop = false;
            this.label1.Text = "# of Line(s)";
            // 
            // txtConfirmedQty
            // 
            this.txtConfirmedQty.Location = new System.Drawing.Point(328, 61);
            this.txtConfirmedQty.Name = "txtConfirmedQty";
            this.txtConfirmedQty.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmedQty.TabIndex = 0;
            this.txtConfirmedQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblConfirmedQty
            // 
            this.lblConfirmedQty.Location = new System.Drawing.Point(209, 64);
            this.lblConfirmedQty.Name = "lblConfirmedQty";
            this.lblConfirmedQty.Size = new System.Drawing.Size(113, 23);
            this.lblConfirmedQty.TabIndex = 18;
            this.lblConfirmedQty.TabStop = false;
            this.lblConfirmedQty.Text = "Confirmed Qty";
            this.lblConfirmedQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRequiredQty
            // 
            this.txtRequiredQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtRequiredQty.Location = new System.Drawing.Point(103, 61);
            this.txtRequiredQty.Name = "txtRequiredQty";
            this.txtRequiredQty.ReadOnly = true;
            this.txtRequiredQty.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredQty.TabIndex = 3;
            this.txtRequiredQty.TabStop = false;
            this.txtRequiredQty.Text = "0";
            this.txtRequiredQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblRequiredQty
            // 
            this.lblRequiredQty.Location = new System.Drawing.Point(17, 64);
            this.lblRequiredQty.Name = "lblRequiredQty";
            this.lblRequiredQty.Size = new System.Drawing.Size(80, 23);
            this.lblRequiredQty.TabIndex = 15;
            this.lblRequiredQty.TabStop = false;
            this.lblRequiredQty.Text = "Required Qty";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(103, 38);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(325, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 41);
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
            this.basicProduct.Location = new System.Drawing.Point(103, 10);
            this.basicProduct.Name = "basicProduct";
            this.basicProduct.SelectedItem = null;
            this.basicProduct.SelectedText = " ";
            this.basicProduct.Size = new System.Drawing.Size(337, 27);
            this.basicProduct.TabIndex = 1;
            this.basicProduct.TabStop = false;
            this.basicProduct.Text = "FindProduct";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxNumber.Enabled = false;
            this.txtTxNumber.Location = new System.Drawing.Point(254, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 11;
            this.txtTxNumber.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(360, 46);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(151, 23);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.TabStop = false;
            this.lblTotalAmount.Text = "Confirmation Status:";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConfirmationStatus
            // 
            this.txtConfirmationStatus.BackColor = System.Drawing.Color.LightYellow;
            this.txtConfirmationStatus.Enabled = false;
            this.txtConfirmationStatus.ForeColor = System.Drawing.Color.Blue;
            this.txtConfirmationStatus.Location = new System.Drawing.Point(517, 43);
            this.txtConfirmationStatus.Name = "txtConfirmationStatus";
            this.txtConfirmationStatus.ReadOnly = true;
            this.txtConfirmationStatus.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmationStatus.TabIndex = 13;
            this.txtConfirmationStatus.TabStop = false;
            this.txtConfirmationStatus.Text = "Unprocessed";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightYellow;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(472, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "0";
            // 
            // ConfirmationWizard
            // 
            this.Controls.Add(this.txtConfirmationStatus);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.tabGoodsTxfer);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxType);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblTxType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer > Confirmation > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsTxfer;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtConfirmationStatus;
        private Gizmox.WebGUI.Forms.Label lblTransactionDate;
        private Gizmox.WebGUI.Forms.Label lblToLocation;
        private Gizmox.WebGUI.Forms.Label lblTotalRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblLatestConfirmation;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboToLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboFromLocation;
        private Gizmox.WebGUI.Forms.TextBox txtRecordStatus;
        private Gizmox.WebGUI.Forms.Label lblRecordStatus;
        private Gizmox.WebGUI.Forms.TextBox txtLatestConfirmedBy;
        private Gizmox.WebGUI.Forms.TextBox txtLatestConfirmedOn;
        private Gizmox.WebGUI.Forms.TextBox txtTotalRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblRequiredQty;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtConfirmedQty;
        private Gizmox.WebGUI.Forms.Label lblConfirmedQty;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequiredQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colConfirmedQty;
        private Gizmox.WebGUI.Forms.Button btnConfirmAllItems;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnResetAllItems;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;
        private System.Windows.Forms.TextBox textBox1;
        private Gizmox.WebGUI.Forms.TextBox txtTotalConfirmedQty;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;


    }
}