namespace RT2020.Inventory.Replenishment
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
            this.txtSpecialRequest = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSpecialRequest = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUpdateBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpCompDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxferDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboToLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboFromLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblTransactionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblCompletionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxferDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.lblToLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsRpl = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
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
            this.colReplenishQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colActualQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemarks = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtReplenishQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblReplenishQty = new Gizmox.WebGUI.Forms.Label();
            this.txtActualQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks_Detail = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks_Details = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.lblActualQty = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxConfirmed = new Gizmox.WebGUI.Forms.Label();
            this.txtTxConfirmed = new Gizmox.WebGUI.Forms.TextBox();
            this.lblConfirmedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtConfirmedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblConfirmedBy = new Gizmox.WebGUI.Forms.Label();
            this.txtConfirmedBy = new Gizmox.WebGUI.Forms.TextBox();
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
            this.tpGeneral.Controls.Add(this.txtSpecialRequest);
            this.tpGeneral.Controls.Add(this.lblSpecialRequest);
            this.tpGeneral.Controls.Add(this.txtLastUpdateBy);
            this.tpGeneral.Controls.Add(this.txtLastUpdateOn);
            this.tpGeneral.Controls.Add(this.cboStatus);
            this.tpGeneral.Controls.Add(this.txtRemarks);
            this.tpGeneral.Controls.Add(this.dtpTxDate);
            this.tpGeneral.Controls.Add(this.dtpCompDate);
            this.tpGeneral.Controls.Add(this.dtpTxferDate);
            this.tpGeneral.Controls.Add(this.cboOperatorCode);
            this.tpGeneral.Controls.Add(this.cboToLocation);
            this.tpGeneral.Controls.Add(this.cboFromLocation);
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
            // txtSpecialRequest
            // 
            this.txtSpecialRequest.BackColor = System.Drawing.Color.LightYellow;
            this.txtSpecialRequest.Location = new System.Drawing.Point(123, 196);
            this.txtSpecialRequest.Name = "txtSpecialRequest";
            this.txtSpecialRequest.ReadOnly = true;
            this.txtSpecialRequest.Size = new System.Drawing.Size(32, 20);
            this.txtSpecialRequest.TabIndex = 8;
            this.txtSpecialRequest.Text = "Y";
            // 
            // lblSpecialRequest
            // 
            this.lblSpecialRequest.Location = new System.Drawing.Point(17, 199);
            this.lblSpecialRequest.Name = "lblSpecialRequest";
            this.lblSpecialRequest.Size = new System.Drawing.Size(100, 23);
            this.lblSpecialRequest.TabIndex = 17;
            this.lblSpecialRequest.Text = "Special Request";
            // 
            // txtLastUpdateBy
            // 
            this.txtLastUpdateBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateBy.Location = new System.Drawing.Point(229, 242);
            this.txtLastUpdateBy.Name = "txtLastUpdateBy";
            this.txtLastUpdateBy.ReadOnly = true;
            this.txtLastUpdateBy.Size = new System.Drawing.Size(65, 20);
            this.txtLastUpdateBy.TabIndex = 20;
            // 
            // txtLastUpdateOn
            // 
            this.txtLastUpdateOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateOn.Location = new System.Drawing.Point(123, 242);
            this.txtLastUpdateOn.Name = "txtLastUpdateOn";
            this.txtLastUpdateOn.ReadOnly = true;
            this.txtLastUpdateOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdateOn.TabIndex = 19;
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
            this.cboStatus.Size = new System.Drawing.Size(66, 21);
            this.cboStatus.TabIndex = 7;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(123, 81);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(261, 20);
            this.txtRemarks.TabIndex = 3;
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
            this.dtpTxDate.TabIndex = 0;
            // 
            // dtpCompDate
            // 
            this.dtpCompDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpCompDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpCompDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCompDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpCompDate.Location = new System.Drawing.Point(123, 58);
            this.dtpCompDate.Name = "dtpCompDate";
            this.dtpCompDate.Size = new System.Drawing.Size(132, 20);
            this.dtpCompDate.TabIndex = 2;
            this.dtpCompDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtpTxferDate
            // 
            this.dtpTxferDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxferDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxferDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxferDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxferDate.Location = new System.Drawing.Point(123, 35);
            this.dtpTxferDate.Name = "dtpTxferDate";
            this.dtpTxferDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxferDate.TabIndex = 1;
            this.dtpTxferDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(123, 104);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(261, 21);
            this.cboOperatorCode.TabIndex = 4;
            // 
            // cboToLocation
            // 
            this.cboToLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboToLocation.DropDownWidth = 215;
            this.cboToLocation.Location = new System.Drawing.Point(123, 150);
            this.cboToLocation.Name = "cboToLocation";
            this.cboToLocation.Size = new System.Drawing.Size(261, 21);
            this.cboToLocation.TabIndex = 6;
            // 
            // cboFromLocation
            // 
            this.cboFromLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboFromLocation.DropDownWidth = 215;
            this.cboFromLocation.Location = new System.Drawing.Point(123, 127);
            this.cboFromLocation.Name = "cboFromLocation";
            this.cboFromLocation.Size = new System.Drawing.Size(261, 21);
            this.cboFromLocation.TabIndex = 5;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(17, 245);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpdate.TabIndex = 18;
            this.lblLastUpdate.Text = "Last Update";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Location = new System.Drawing.Point(17, 130);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(100, 23);
            this.lblFromLocation.TabIndex = 14;
            this.lblFromLocation.Text = "From Location";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(17, 84);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 12;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(17, 14);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(100, 23);
            this.lblTransactionDate.TabIndex = 9;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.Location = new System.Drawing.Point(17, 60);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(100, 23);
            this.lblCompletionDate.TabIndex = 11;
            this.lblCompletionDate.Text = "Completion Date";
            // 
            // lblTxferDate
            // 
            this.lblTxferDate.Location = new System.Drawing.Point(17, 37);
            this.lblTxferDate.Name = "lblTxferDate";
            this.lblTxferDate.Size = new System.Drawing.Size(100, 23);
            this.lblTxferDate.TabIndex = 10;
            this.lblTxferDate.Text = "Transfer Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Location = new System.Drawing.Point(17, 107);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 23);
            this.lblOperatorCode.TabIndex = 13;
            this.lblOperatorCode.Text = "Operator Code";
            // 
            // lblToLocation
            // 
            this.lblToLocation.Location = new System.Drawing.Point(17, 153);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(100, 23);
            this.lblToLocation.TabIndex = 15;
            this.lblToLocation.Text = "To Location";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(23, 46);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(76, 23);
            this.lblTxNumber.TabIndex = 10;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // tabGoodsRpl
            // 
            this.tabGoodsRpl.Controls.Add(this.tpGeneral);
            this.tabGoodsRpl.Controls.Add(this.tpDetails);
            this.tabGoodsRpl.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsRpl.Multiline = false;
            this.tabGoodsRpl.Name = "tabGoodsRpl";
            this.tabGoodsRpl.SelectedIndex = 0;
            this.tabGoodsRpl.ShowCloseButton = false;
            this.tabGoodsRpl.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsRpl.TabIndex = 3;
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnRemove);
            this.tpDetails.Controls.Add(this.btnAddItem);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.label1);
            this.tpDetails.Controls.Add(this.txtReplenishQty);
            this.tpDetails.Controls.Add(this.lblReplenishQty);
            this.tpDetails.Controls.Add(this.txtActualQty);
            this.tpDetails.Controls.Add(this.txtRemarks_Detail);
            this.tpDetails.Controls.Add(this.lblRemarks_Details);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.lblActualQty);
            this.tpDetails.Controls.Add(this.basicProduct);
            this.tpDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(655, 33);
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
            this.colReplenishQty,
            this.colActualQty,
            this.colRemarks});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 98);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 278);
            this.lvDetailsList.TabIndex = 6;
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
            // colReplenishQty
            // 
            this.colReplenishQty.Image = null;
            this.colReplenishQty.Text = "Replenish Qty";
            this.colReplenishQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colReplenishQty.Width = 80;
            // 
            // colActualQty
            // 
            this.colActualQty.Image = null;
            this.colActualQty.Text = "ActualQty";
            this.colActualQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colActualQty.Width = 80;
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
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(655, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(722, 82);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 14;
            this.lblLineCount.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(652, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "# of Line(s)";
            // 
            // txtReplenishQty
            // 
            this.txtReplenishQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtReplenishQty.Location = new System.Drawing.Point(533, 12);
            this.txtReplenishQty.Name = "txtReplenishQty";
            this.txtReplenishQty.ReadOnly = true;
            this.txtReplenishQty.Size = new System.Drawing.Size(92, 20);
            this.txtReplenishQty.TabIndex = 12;
            // 
            // lblReplenishQty
            // 
            this.lblReplenishQty.Location = new System.Drawing.Point(447, 15);
            this.lblReplenishQty.Name = "lblReplenishQty";
            this.lblReplenishQty.Size = new System.Drawing.Size(80, 23);
            this.lblReplenishQty.TabIndex = 10;
            this.lblReplenishQty.Text = "Replenish Qty";
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(533, 35);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(92, 20);
            this.txtActualQty.TabIndex = 1;
            // 
            // txtRemarks_Detail
            // 
            this.txtRemarks_Detail.Location = new System.Drawing.Point(89, 58);
            this.txtRemarks_Detail.Name = "txtRemarks_Detail";
            this.txtRemarks_Detail.Size = new System.Drawing.Size(536, 20);
            this.txtRemarks_Detail.TabIndex = 2;
            // 
            // lblRemarks_Details
            // 
            this.lblRemarks_Details.Location = new System.Drawing.Point(17, 61);
            this.lblRemarks_Details.Name = "lblRemarks_Details";
            this.lblRemarks_Details.Size = new System.Drawing.Size(66, 23);
            this.lblRemarks_Details.TabIndex = 9;
            this.lblRemarks_Details.Text = "Remarks";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(89, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(332, 20);
            this.txtDescription.TabIndex = 12;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 23);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // lblStockCode
            // 
            this.lblStockCode.Location = new System.Drawing.Point(17, 15);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(66, 23);
            this.lblStockCode.TabIndex = 7;
            this.lblStockCode.Text = "StockCode";
            // 
            // lblActualQty
            // 
            this.lblActualQty.Location = new System.Drawing.Point(447, 38);
            this.lblActualQty.Name = "lblActualQty";
            this.lblActualQty.Size = new System.Drawing.Size(80, 23);
            this.lblActualQty.TabIndex = 11;
            this.lblActualQty.Text = "Actual Qty";
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
            this.txtTxNumber.Location = new System.Drawing.Point(105, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 0;
            // 
            // lblTxConfirmed
            // 
            this.lblTxConfirmed.Location = new System.Drawing.Point(225, 46);
            this.lblTxConfirmed.Name = "lblTxConfirmed";
            this.lblTxConfirmed.Size = new System.Drawing.Size(100, 23);
            this.lblTxConfirmed.TabIndex = 12;
            this.lblTxConfirmed.Text = "Tx Confirmed";
            this.lblTxConfirmed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTxConfirmed
            // 
            this.txtTxConfirmed.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxConfirmed.Location = new System.Drawing.Point(331, 43);
            this.txtTxConfirmed.Name = "txtTxConfirmed";
            this.txtTxConfirmed.ReadOnly = true;
            this.txtTxConfirmed.Size = new System.Drawing.Size(23, 20);
            this.txtTxConfirmed.TabIndex = 13;
            this.txtTxConfirmed.Text = "N";
            this.txtTxConfirmed.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            // 
            // lblConfirmedOn
            // 
            this.lblConfirmedOn.Location = new System.Drawing.Point(360, 46);
            this.lblConfirmedOn.Name = "lblConfirmedOn";
            this.lblConfirmedOn.Size = new System.Drawing.Size(40, 23);
            this.lblConfirmedOn.TabIndex = 14;
            this.lblConfirmedOn.Text = "at";
            this.lblConfirmedOn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtConfirmedOn
            // 
            this.txtConfirmedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtConfirmedOn.Location = new System.Drawing.Point(406, 43);
            this.txtConfirmedOn.Name = "txtConfirmedOn";
            this.txtConfirmedOn.ReadOnly = true;
            this.txtConfirmedOn.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmedOn.TabIndex = 1;
            // 
            // lblConfirmedBy
            // 
            this.lblConfirmedBy.Location = new System.Drawing.Point(512, 46);
            this.lblConfirmedBy.Name = "lblConfirmedBy";
            this.lblConfirmedBy.Size = new System.Drawing.Size(40, 23);
            this.lblConfirmedBy.TabIndex = 16;
            this.lblConfirmedBy.Text = "by";
            this.lblConfirmedBy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtConfirmedBy
            // 
            this.txtConfirmedBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtConfirmedBy.Location = new System.Drawing.Point(558, 43);
            this.txtConfirmedBy.Name = "txtConfirmedBy";
            this.txtConfirmedBy.ReadOnly = true;
            this.txtConfirmedBy.Size = new System.Drawing.Size(64, 20);
            this.txtConfirmedBy.TabIndex = 2;
            // 
            // Wizard
            // 
            this.Controls.Add(this.txtConfirmedBy);
            this.Controls.Add(this.lblConfirmedBy);
            this.Controls.Add(this.txtConfirmedOn);
            this.Controls.Add(this.lblConfirmedOn);
            this.Controls.Add(this.txtTxConfirmed);
            this.Controls.Add(this.lblTxConfirmed);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.tabGoodsRpl);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.tbWizardAction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Replenishment > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsRpl;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblTransactionDate;
        private Gizmox.WebGUI.Forms.Label lblCompletionDate;
        private Gizmox.WebGUI.Forms.Label lblTxferDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblToLocation;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpCompDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxferDate;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboToLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboFromLocation;
        private Gizmox.WebGUI.Forms.ComboBox cboStatus;
        private Gizmox.WebGUI.Forms.TextBox txtSpecialRequest;
        private Gizmox.WebGUI.Forms.Label lblSpecialRequest;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateOn;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.TextBox txtActualQty;
        private Gizmox.WebGUI.Forms.Label lblActualQty;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks_Detail;
        private Gizmox.WebGUI.Forms.Label lblRemarks_Details;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox txtReplenishQty;
        private Gizmox.WebGUI.Forms.Label lblReplenishQty;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colReplenishQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colActualQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemarks;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.Label lblTxConfirmed;
        private Gizmox.WebGUI.Forms.TextBox txtTxConfirmed;
        private Gizmox.WebGUI.Forms.Label lblConfirmedOn;
        private Gizmox.WebGUI.Forms.TextBox txtConfirmedOn;
        private Gizmox.WebGUI.Forms.Label lblConfirmedBy;
        private Gizmox.WebGUI.Forms.TextBox txtConfirmedBy;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;


    }
}