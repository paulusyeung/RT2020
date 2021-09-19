using RT2020.Common.Helper;

namespace RT2020.Inventory.Transfer
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
            this.txtAmendmentRetrict = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAmendmentRetrict = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUpdateBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtRefNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpCompDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxferDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboToLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboFromLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblRefNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblTransactionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblCompletionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxferDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.lblToLocation = new Gizmox.WebGUI.Forms.Label();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsTxfer = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
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
            this.colRequiredQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRetailPrice = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRetailPrice = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAmount = new Gizmox.WebGUI.Forms.Label();
            this.lblRetailPrice = new Gizmox.WebGUI.Forms.Label();
            this.txtRequiredQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRequiredQty = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks_Detail = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks_Details = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.txtAppendix3 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAppendix2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAppendix1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStockCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.rbtnStockCode_2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnStockCode_1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnBarcode = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
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
            this.tpGeneral.Controls.Add(this.txtAmendmentRetrict);
            this.tpGeneral.Controls.Add(this.lblAmendmentRetrict);
            this.tpGeneral.Controls.Add(this.txtLastUpdateBy);
            this.tpGeneral.Controls.Add(this.txtLastUpdateOn);
            this.tpGeneral.Controls.Add(this.cboStatus);
            this.tpGeneral.Controls.Add(this.txtRefNumber);
            this.tpGeneral.Controls.Add(this.txtRemarks);
            this.tpGeneral.Controls.Add(this.dtpTxDate);
            this.tpGeneral.Controls.Add(this.dtpCompDate);
            this.tpGeneral.Controls.Add(this.dtpTxferDate);
            this.tpGeneral.Controls.Add(this.cboOperatorCode);
            this.tpGeneral.Controls.Add(this.cboToLocation);
            this.tpGeneral.Controls.Add(this.cboFromLocation);
            this.tpGeneral.Controls.Add(this.lblRefNumber);
            this.tpGeneral.Controls.Add(this.lblTotalQty);
            this.tpGeneral.Controls.Add(this.lblLastUpdate);
            this.tpGeneral.Controls.Add(this.lblStatus);
            this.tpGeneral.Controls.Add(this.lblFromLocation);
            this.tpGeneral.Controls.Add(this.lblRemarks);
            this.tpGeneral.Controls.Add(this.lblTransactionDate);
            this.tpGeneral.Controls.Add(this.lblCompletionDate);
            this.tpGeneral.Controls.Add(this.lblTxferDate);
            this.tpGeneral.Controls.Add(this.lblOperatorCode);
            this.tpGeneral.Controls.Add(this.lblToLocation);
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
            this.txtTotalQty.Location = new System.Drawing.Point(478, 12);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(100, 20);
            this.txtTotalQty.TabIndex = 23;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.Text = "0";
            // 
            // txtAmendmentRetrict
            // 
            this.txtAmendmentRetrict.BackColor = System.Drawing.Color.LightYellow;
            this.txtAmendmentRetrict.Location = new System.Drawing.Point(478, 196);
            this.txtAmendmentRetrict.Name = "txtAmendmentRetrict";
            this.txtAmendmentRetrict.ReadOnly = true;
            this.txtAmendmentRetrict.Size = new System.Drawing.Size(32, 20);
            this.txtAmendmentRetrict.TabIndex = 22;
            this.txtAmendmentRetrict.TabStop = false;
            // 
            // lblAmendmentRetrict
            // 
            this.lblAmendmentRetrict.Location = new System.Drawing.Point(372, 199);
            this.lblAmendmentRetrict.Name = "lblAmendmentRetrict";
            this.lblAmendmentRetrict.Size = new System.Drawing.Size(100, 23);
            this.lblAmendmentRetrict.TabIndex = 21;
            this.lblAmendmentRetrict.TabStop = false;
            this.lblAmendmentRetrict.Text = "Amendment Retrict";
            this.lblAmendmentRetrict.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLastUpdateBy
            // 
            this.txtLastUpdateBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateBy.Location = new System.Drawing.Point(229, 196);
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
            this.cboStatus.Location = new System.Drawing.Point(123, 173);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 8;
            this.cboStatus.TextChanged += new System.EventHandler(this.cboStatus_TextChanged);
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.Location = new System.Drawing.Point(478, 150);
            this.txtRefNumber.MaxLength = 12;
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(100, 20);
            this.txtRefNumber.TabIndex = 7;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(123, 150);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(261, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(123, 128);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 5;
            // 
            // dtpCompDate
            // 
            this.dtpCompDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpCompDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpCompDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCompDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpCompDate.Location = new System.Drawing.Point(123, 105);
            this.dtpCompDate.Name = "dtpCompDate";
            this.dtpCompDate.Size = new System.Drawing.Size(132, 20);
            this.dtpCompDate.TabIndex = 4;
            // 
            // dtpTxferDate
            // 
            this.dtpTxferDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxferDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxferDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxferDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxferDate.Location = new System.Drawing.Point(123, 82);
            this.dtpTxferDate.Name = "dtpTxferDate";
            this.dtpTxferDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxferDate.TabIndex = 3;
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(123, 58);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(215, 21);
            this.cboOperatorCode.TabIndex = 2;
            this.cboOperatorCode.TextChanged += new System.EventHandler(this.cboOperatorCode_TextChanged);
            // 
            // cboToLocation
            // 
            this.cboToLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboToLocation.DropDownWidth = 215;
            this.cboToLocation.Location = new System.Drawing.Point(123, 35);
            this.cboToLocation.Name = "cboToLocation";
            this.cboToLocation.Size = new System.Drawing.Size(215, 21);
            this.cboToLocation.TabIndex = 1;
            this.cboToLocation.TextChanged += new System.EventHandler(this.cboToLocation_TextChanged);
            // 
            // cboFromLocation
            // 
            this.cboFromLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboFromLocation.DropDownWidth = 215;
            this.cboFromLocation.Location = new System.Drawing.Point(123, 12);
            this.cboFromLocation.Name = "cboFromLocation";
            this.cboFromLocation.Size = new System.Drawing.Size(215, 21);
            this.cboFromLocation.TabIndex = 0;
            this.cboFromLocation.TextChanged += new System.EventHandler(this.cboFromLocation_TextChanged);
            // 
            // lblRefNumber
            // 
            this.lblRefNumber.Location = new System.Drawing.Point(390, 153);
            this.lblRefNumber.Name = "lblRefNumber";
            this.lblRefNumber.Size = new System.Drawing.Size(82, 23);
            this.lblRefNumber.TabIndex = 10;
            this.lblRefNumber.Text = "REF #";
            this.lblRefNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Location = new System.Drawing.Point(388, 15);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(82, 23);
            this.lblTotalQty.TabIndex = 9;
            this.lblTotalQty.TabStop = false;
            this.lblTotalQty.Text = "Total Qty";
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(17, 199);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpdate.TabIndex = 8;
            this.lblLastUpdate.TabStop = false;
            this.lblLastUpdate.Text = "Last Update";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TabStop = false;
            this.lblStatus.Text = "Status";
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
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(17, 153);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.TabStop = false;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(17, 130);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(100, 23);
            this.lblTransactionDate.TabIndex = 4;
            this.lblTransactionDate.TabStop = false;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.Location = new System.Drawing.Point(17, 107);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(100, 23);
            this.lblCompletionDate.TabIndex = 3;
            this.lblCompletionDate.TabStop = false;
            this.lblCompletionDate.Text = "Completion Date";
            // 
            // lblTxferDate
            // 
            this.lblTxferDate.Location = new System.Drawing.Point(17, 84);
            this.lblTxferDate.Name = "lblTxferDate";
            this.lblTxferDate.Size = new System.Drawing.Size(100, 23);
            this.lblTxferDate.TabIndex = 2;
            this.lblTxferDate.TabStop = false;
            this.lblTxferDate.Text = "Transfer Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Location = new System.Drawing.Point(17, 61);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 23);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.TabStop = false;
            this.lblOperatorCode.Text = "Operator Code";
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
            this.tpDetails.Controls.Add(this.basicProduct);
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnRemove);
            this.tpDetails.Controls.Add(this.btnAddItem);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.label1);
            this.tpDetails.Controls.Add(this.txtAmount);
            this.tpDetails.Controls.Add(this.txtRetailPrice);
            this.tpDetails.Controls.Add(this.lblAmount);
            this.tpDetails.Controls.Add(this.lblRetailPrice);
            this.tpDetails.Controls.Add(this.txtRequiredQty);
            this.tpDetails.Controls.Add(this.lblRequiredQty);
            this.tpDetails.Controls.Add(this.txtRemarks_Detail);
            this.tpDetails.Controls.Add(this.lblRemarks_Details);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.txtAppendix3);
            this.tpDetails.Controls.Add(this.txtAppendix2);
            this.tpDetails.Controls.Add(this.txtAppendix1);
            this.tpDetails.Controls.Add(this.txtStockCode);
            this.tpDetails.Controls.Add(this.txtBarcode);
            this.tpDetails.Controls.Add(this.rbtnStockCode_2);
            this.tpDetails.Controls.Add(this.rbtnStockCode_1);
            this.tpDetails.Controls.Add(this.rbtnBarcode);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.lblBarcode);
            this.tpDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // basicProduct
            // 
            this.basicProduct.HasMatrix = true;
            this.basicProduct.Location = new System.Drawing.Point(141, 53);
            this.basicProduct.Name = "basicProduct";
            this.basicProduct.SelectedItem = null;
            this.basicProduct.SelectedText = " ";
            this.basicProduct.Size = new System.Drawing.Size(337, 27);
            this.basicProduct.TabIndex = 28;
            this.basicProduct.Text = "FindProduct";
            this.basicProduct.TxType = EnumHelper.TxType.CAS;
            this.basicProduct.SelectionChanged += new System.EventHandler<RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs>(this.basicProduct_SelectionChanged);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(655, 33);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 5;
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
            this.colRequiredQty,
            this.colRetailPrice,
            this.colAmount,
            this.colRemarks});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 132);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 244);
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
            // colRetailPrice
            // 
            this.colRetailPrice.Image = null;
            this.colRetailPrice.Text = "Retail Price";
            this.colRetailPrice.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colRetailPrice.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.Image = null;
            this.colAmount.Text = "Amount($)";
            this.colAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 80;
            // 
            // colRemarks
            // 
            this.colRemarks.Image = null;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(655, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(655, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(722, 106);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(652, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 21;
            this.label1.TabStop = false;
            this.label1.Text = "# of Line(s)";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtAmount.Location = new System.Drawing.Point(546, 103);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 20;
            // 
            // txtRetailPrice
            // 
            this.txtRetailPrice.BackColor = System.Drawing.Color.LightYellow;
            this.txtRetailPrice.Location = new System.Drawing.Point(546, 80);
            this.txtRetailPrice.Name = "txtRetailPrice";
            this.txtRetailPrice.ReadOnly = true;
            this.txtRetailPrice.Size = new System.Drawing.Size(100, 20);
            this.txtRetailPrice.TabIndex = 19;
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(475, 106);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(65, 23);
            this.lblAmount.TabIndex = 18;
            this.lblAmount.TabStop = false;
            this.lblAmount.Text = "Amount($)";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRetailPrice
            // 
            this.lblRetailPrice.Location = new System.Drawing.Point(475, 83);
            this.lblRetailPrice.Name = "lblRetailPrice";
            this.lblRetailPrice.Size = new System.Drawing.Size(65, 23);
            this.lblRetailPrice.TabIndex = 17;
            this.lblRetailPrice.TabStop = false;
            this.lblRetailPrice.Text = "Retail Price";
            this.lblRetailPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRequiredQty
            // 
            this.txtRequiredQty.Location = new System.Drawing.Point(369, 103);
            this.txtRequiredQty.Name = "txtRequiredQty";
            this.txtRequiredQty.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredQty.TabIndex = 3;
            this.txtRequiredQty.Text = "1";
            this.txtRequiredQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtRequiredQty.TextChanged += new System.EventHandler(this.txtRequiredQty_TextChanged);
            // 
            // lblRequiredQty
            // 
            this.lblRequiredQty.Location = new System.Drawing.Point(283, 106);
            this.lblRequiredQty.Name = "lblRequiredQty";
            this.lblRequiredQty.Size = new System.Drawing.Size(80, 23);
            this.lblRequiredQty.TabIndex = 15;
            this.lblRequiredQty.TabStop = false;
            this.lblRequiredQty.Text = "Required Qty";
            this.lblRequiredQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRemarks_Detail
            // 
            this.txtRemarks_Detail.Location = new System.Drawing.Point(144, 103);
            this.txtRemarks_Detail.MaxLength = 30;
            this.txtRemarks_Detail.Name = "txtRemarks_Detail";
            this.txtRemarks_Detail.Size = new System.Drawing.Size(133, 20);
            this.txtRemarks_Detail.TabIndex = 2;
            // 
            // lblRemarks_Details
            // 
            this.lblRemarks_Details.Location = new System.Drawing.Point(17, 106);
            this.lblRemarks_Details.Name = "lblRemarks_Details";
            this.lblRemarks_Details.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks_Details.TabIndex = 13;
            this.lblRemarks_Details.TabStop = false;
            this.lblRemarks_Details.Text = "Remarks";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(144, 80);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(325, 20);
            this.txtDescription.TabIndex = 12;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.TabStop = false;
            this.lblDescription.Text = "Description";
            // 
            // txtAppendix3
            // 
            this.txtAppendix3.BackColor = System.Drawing.Color.LightYellow;
            this.txtAppendix3.Location = new System.Drawing.Point(368, 35);
            this.txtAppendix3.Name = "txtAppendix3";
            this.txtAppendix3.ReadOnly = true;
            this.txtAppendix3.Size = new System.Drawing.Size(60, 20);
            this.txtAppendix3.TabIndex = 4;
            this.txtAppendix3.TextChanged += new System.EventHandler(this.txtAppendix3_TextChanged);
            // 
            // txtAppendix2
            // 
            this.txtAppendix2.BackColor = System.Drawing.Color.LightYellow;
            this.txtAppendix2.Location = new System.Drawing.Point(305, 35);
            this.txtAppendix2.Name = "txtAppendix2";
            this.txtAppendix2.ReadOnly = true;
            this.txtAppendix2.Size = new System.Drawing.Size(62, 20);
            this.txtAppendix2.TabIndex = 3;
            this.txtAppendix2.TextChanged += new System.EventHandler(this.txtAppendix2_TextChanged);
            // 
            // txtAppendix1
            // 
            this.txtAppendix1.BackColor = System.Drawing.Color.LightYellow;
            this.txtAppendix1.Location = new System.Drawing.Point(244, 35);
            this.txtAppendix1.Name = "txtAppendix1";
            this.txtAppendix1.ReadOnly = true;
            this.txtAppendix1.Size = new System.Drawing.Size(60, 20);
            this.txtAppendix1.TabIndex = 2;
            this.txtAppendix1.TextChanged += new System.EventHandler(this.txtAppendix1_TextChanged);
            // 
            // txtStockCode
            // 
            this.txtStockCode.BackColor = System.Drawing.Color.LightYellow;
            this.txtStockCode.Location = new System.Drawing.Point(144, 35);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.ReadOnly = true;
            this.txtStockCode.Size = new System.Drawing.Size(99, 20);
            this.txtStockCode.TabIndex = 1;
            this.txtStockCode.TextChanged += new System.EventHandler(this.txtStockCode_TextChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.LightYellow;
            this.txtBarcode.Location = new System.Drawing.Point(144, 12);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(284, 20);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtBarcode_EnterKeyDown);
            // 
            // rbtnStockCode_2
            // 
            this.rbtnStockCode_2.Checked = true;
            this.rbtnStockCode_2.Location = new System.Drawing.Point(89, 59);
            this.rbtnStockCode_2.Name = "rbtnStockCode_2";
            this.rbtnStockCode_2.Size = new System.Drawing.Size(49, 24);
            this.rbtnStockCode_2.TabIndex = 0;
            this.rbtnStockCode_2.Text = "#3";
            this.rbtnStockCode_2.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnStockCode_1
            // 
            this.rbtnStockCode_1.Location = new System.Drawing.Point(89, 37);
            this.rbtnStockCode_1.Name = "rbtnStockCode_1";
            this.rbtnStockCode_1.Size = new System.Drawing.Size(49, 24);
            this.rbtnStockCode_1.TabIndex = 0;
            this.rbtnStockCode_1.Text = "#2";
            this.rbtnStockCode_1.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnBarcode
            // 
            this.rbtnBarcode.Location = new System.Drawing.Point(89, 14);
            this.rbtnBarcode.Name = "rbtnBarcode";
            this.rbtnBarcode.Size = new System.Drawing.Size(49, 24);
            this.rbtnBarcode.TabIndex = 0;
            this.rbtnBarcode.Text = "#1";
            this.rbtnBarcode.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // lblStockCode
            // 
            this.lblStockCode.Location = new System.Drawing.Point(17, 38);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(66, 23);
            this.lblStockCode.TabIndex = 1;
            this.lblStockCode.TabStop = false;
            this.lblStockCode.Text = "StockCode";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(17, 15);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(66, 23);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.TabStop = false;
            this.lblBarcode.Text = "Barcode";
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
            this.Controls.Add(this.tabGoodsTxfer);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxType);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblTxType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer > Wizard";
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
        private Gizmox.WebGUI.Forms.TextBox txtTotalAmount;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblTransactionDate;
        private Gizmox.WebGUI.Forms.Label lblCompletionDate;
        private Gizmox.WebGUI.Forms.Label lblTxferDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblToLocation;
        private Gizmox.WebGUI.Forms.Label lblRefNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.TextBox txtRefNumber;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpCompDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxferDate;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboToLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboFromLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboStatus;
        private Gizmox.WebGUI.Forms.TextBox txtAmendmentRetrict;
        private Gizmox.WebGUI.Forms.Label lblAmendmentRetrict;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateOn;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.RadioButton rbtnStockCode_2;
        private Gizmox.WebGUI.Forms.RadioButton rbtnStockCode_1;
        private Gizmox.WebGUI.Forms.RadioButton rbtnBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtRequiredQty;
        private Gizmox.WebGUI.Forms.Label lblRequiredQty;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks_Detail;
        private Gizmox.WebGUI.Forms.Label lblRemarks_Details;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix3;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix2;
        private Gizmox.WebGUI.Forms.TextBox txtAppendix1;
        private Gizmox.WebGUI.Forms.TextBox txtStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtBarcode;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtAmount;
        private Gizmox.WebGUI.Forms.TextBox txtRetailPrice;
        private Gizmox.WebGUI.Forms.Label lblAmount;
        private Gizmox.WebGUI.Forms.Label lblRetailPrice;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colRequiredQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colRetailPrice;
        private Gizmox.WebGUI.Forms.ColumnHeader colAmount;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;


    }
}