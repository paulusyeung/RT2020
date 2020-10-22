namespace RT2020.Inventory.GoodsReturn
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
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.tpGeneral = new Gizmox.WebGUI.Forms.TabPage();
            this.chkAPLink = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblAPLink = new Gizmox.WebGUI.Forms.Label();
            this.txtSupplierInvoice = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSupplierInvoice = new Gizmox.WebGUI.Forms.Label();
            this.cboSupplierList = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSupplier = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAmendmentRetrict = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAmendmentRetrict = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUpdateBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdateOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtRefNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpRecvDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblRefNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblRecvDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsREJ = new Gizmox.WebGUI.Forms.TabControl();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.txtUnitAmount = new Gizmox.WebGUI.Forms.TextBox();
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
            this.colUnitAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProductId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.lblNumberOfLine = new Gizmox.WebGUI.Forms.Label();
            this.txtUnitPrice = new Gizmox.WebGUI.Forms.TextBox();
            this.lblUnitAmount = new Gizmox.WebGUI.Forms.Label();
            this.lblUnitPrice = new Gizmox.WebGUI.Forms.Label();
            this.txtQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblQty = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTxType
            // 
            this.lblTxType.ClientAction = null;
            this.lblTxType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.tbWizardAction.ClientAction = null;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.tpGeneral.ClientAction = null;
            this.tpGeneral.Controls.Add(this.chkAPLink);
            this.tpGeneral.Controls.Add(this.lblAPLink);
            this.tpGeneral.Controls.Add(this.txtSupplierInvoice);
            this.tpGeneral.Controls.Add(this.lblSupplierInvoice);
            this.tpGeneral.Controls.Add(this.cboSupplierList);
            this.tpGeneral.Controls.Add(this.lblSupplier);
            this.tpGeneral.Controls.Add(this.txtTotalQty);
            this.tpGeneral.Controls.Add(this.txtAmendmentRetrict);
            this.tpGeneral.Controls.Add(this.lblAmendmentRetrict);
            this.tpGeneral.Controls.Add(this.txtLastUpdateBy);
            this.tpGeneral.Controls.Add(this.txtLastUpdateOn);
            this.tpGeneral.Controls.Add(this.cboStatus);
            this.tpGeneral.Controls.Add(this.txtRefNumber);
            this.tpGeneral.Controls.Add(this.txtRemarks);
            this.tpGeneral.Controls.Add(this.dtpRecvDate);
            this.tpGeneral.Controls.Add(this.cboOperatorCode);
            this.tpGeneral.Controls.Add(this.cboWorkplace);
            this.tpGeneral.Controls.Add(this.lblRefNumber);
            this.tpGeneral.Controls.Add(this.lblTotalQty);
            this.tpGeneral.Controls.Add(this.lblLastUpdate);
            this.tpGeneral.Controls.Add(this.lblStatus);
            this.tpGeneral.Controls.Add(this.lblLocation);
            this.tpGeneral.Controls.Add(this.lblRemarks);
            this.tpGeneral.Controls.Add(this.lblRecvDate);
            this.tpGeneral.Controls.Add(this.lblOperatorCode);
            this.tpGeneral.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(766, 379);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // chkAPLink
            // 
            this.chkAPLink.Checked = false;
            this.chkAPLink.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAPLink.ClientAction = null;
            this.chkAPLink.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkAPLink.Enabled = false;
            this.chkAPLink.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAPLink.Location = new System.Drawing.Point(478, 106);
            this.chkAPLink.Name = "chkAPLink";
            this.chkAPLink.Size = new System.Drawing.Size(32, 24);
            this.chkAPLink.TabIndex = 29;
            this.chkAPLink.TabStop = false;
            this.chkAPLink.ThreeState = false;
            // 
            // lblAPLink
            // 
            this.lblAPLink.ClientAction = null;
            this.lblAPLink.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAPLink.Location = new System.Drawing.Point(370, 107);
            this.lblAPLink.Name = "lblAPLink";
            this.lblAPLink.Size = new System.Drawing.Size(100, 23);
            this.lblAPLink.TabIndex = 28;
            this.lblAPLink.TabStop = false;
            this.lblAPLink.Text = "AP Link";
            this.lblAPLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSupplierInvoice
            // 
            this.txtSupplierInvoice.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtSupplierInvoice.ClientAction = null;
            this.txtSupplierInvoice.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSupplierInvoice.Location = new System.Drawing.Point(123, 104);
            this.txtSupplierInvoice.Name = "txtSupplierInvoice";
            this.txtSupplierInvoice.Size = new System.Drawing.Size(215, 20);
            this.txtSupplierInvoice.TabIndex = 4;
            // 
            // lblSupplierInvoice
            // 
            this.lblSupplierInvoice.ClientAction = null;
            this.lblSupplierInvoice.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplierInvoice.Location = new System.Drawing.Point(17, 107);
            this.lblSupplierInvoice.Name = "lblSupplierInvoice";
            this.lblSupplierInvoice.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierInvoice.TabIndex = 26;
            this.lblSupplierInvoice.TabStop = false;
            this.lblSupplierInvoice.Text = "Supplier INV#";
            // 
            // cboSupplierList
            // 
            this.cboSupplierList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSupplierList.ClientAction = null;
            this.cboSupplierList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboSupplierList.DropDownWidth = 215;
            this.cboSupplierList.Location = new System.Drawing.Point(123, 81);
            this.cboSupplierList.Name = "cboSupplierList";
            this.cboSupplierList.Size = new System.Drawing.Size(215, 21);
            this.cboSupplierList.TabIndex = 3;
            // 
            // lblSupplier
            // 
            this.lblSupplier.ClientAction = null;
            this.lblSupplier.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplier.Location = new System.Drawing.Point(17, 84);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(100, 23);
            this.lblSupplier.TabIndex = 24;
            this.lblSupplier.TabStop = false;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalQty.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtTotalQty.ClientAction = null;
            this.txtTotalQty.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.txtAmendmentRetrict.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtAmendmentRetrict.ClientAction = null;
            this.txtAmendmentRetrict.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAmendmentRetrict.Location = new System.Drawing.Point(478, 81);
            this.txtAmendmentRetrict.Name = "txtAmendmentRetrict";
            this.txtAmendmentRetrict.ReadOnly = true;
            this.txtAmendmentRetrict.Size = new System.Drawing.Size(32, 20);
            this.txtAmendmentRetrict.TabIndex = 22;
            this.txtAmendmentRetrict.TabStop = false;
            // 
            // lblAmendmentRetrict
            // 
            this.lblAmendmentRetrict.ClientAction = null;
            this.lblAmendmentRetrict.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAmendmentRetrict.Location = new System.Drawing.Point(370, 84);
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
            this.txtLastUpdateBy.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtLastUpdateBy.ClientAction = null;
            this.txtLastUpdateBy.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLastUpdateBy.Location = new System.Drawing.Point(478, 58);
            this.txtLastUpdateBy.Name = "txtLastUpdateBy";
            this.txtLastUpdateBy.ReadOnly = true;
            this.txtLastUpdateBy.Size = new System.Drawing.Size(65, 20);
            this.txtLastUpdateBy.TabIndex = 20;
            this.txtLastUpdateBy.TabStop = false;
            // 
            // txtLastUpdateOn
            // 
            this.txtLastUpdateOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdateOn.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtLastUpdateOn.ClientAction = null;
            this.txtLastUpdateOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLastUpdateOn.Location = new System.Drawing.Point(478, 35);
            this.txtLastUpdateOn.Name = "txtLastUpdateOn";
            this.txtLastUpdateOn.ReadOnly = true;
            this.txtLastUpdateOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdateOn.TabIndex = 19;
            this.txtLastUpdateOn.TabStop = false;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboStatus.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboStatus.ClientAction = null;
            this.cboStatus.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboStatus.DropDownWidth = 121;
            this.cboStatus.Items.AddRange(new object[] {
            "HOLD",
            "POST"});
            this.cboStatus.Location = new System.Drawing.Point(123, 173);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 7;
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtRefNumber.ClientAction = null;
            this.txtRefNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRefNumber.Location = new System.Drawing.Point(123, 127);
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(215, 20);
            this.txtRefNumber.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtRemarks.ClientAction = null;
            this.txtRemarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRemarks.Location = new System.Drawing.Point(123, 150);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(455, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // dtpRecvDate
            // 
            this.dtpRecvDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpRecvDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpRecvDate.ClientAction = null;
            this.dtpRecvDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRecvDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpRecvDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpRecvDate.Location = new System.Drawing.Point(123, 35);
            this.dtpRecvDate.Name = "dtpRecvDate";
            this.dtpRecvDate.Size = new System.Drawing.Size(132, 20);
            this.dtpRecvDate.TabIndex = 1;
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperatorCode.ClientAction = null;
            this.cboOperatorCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(123, 58);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(215, 21);
            this.cboOperatorCode.TabIndex = 2;
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboWorkplace.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboWorkplace.ClientAction = null;
            this.cboWorkplace.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboWorkplace.DropDownWidth = 215;
            this.cboWorkplace.Location = new System.Drawing.Point(123, 12);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(215, 21);
            this.cboWorkplace.TabIndex = 0;
            // 
            // lblRefNumber
            // 
            this.lblRefNumber.ClientAction = null;
            this.lblRefNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRefNumber.Location = new System.Drawing.Point(17, 130);
            this.lblRefNumber.Name = "lblRefNumber";
            this.lblRefNumber.Size = new System.Drawing.Size(82, 23);
            this.lblRefNumber.TabIndex = 10;
            this.lblRefNumber.TabStop = false;
            this.lblRefNumber.Text = "REF #";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.ClientAction = null;
            this.lblTotalQty.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.lblLastUpdate.ClientAction = null;
            this.lblLastUpdate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLastUpdate.Location = new System.Drawing.Point(388, 38);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(82, 23);
            this.lblLastUpdate.TabIndex = 8;
            this.lblLastUpdate.TabStop = false;
            this.lblLastUpdate.Text = "Last Update";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatus
            // 
            this.lblStatus.ClientAction = null;
            this.lblStatus.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblStatus.Location = new System.Drawing.Point(17, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TabStop = false;
            this.lblStatus.Text = "Status";
            // 
            // lblLocation
            // 
            this.lblLocation.ClientAction = null;
            this.lblLocation.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLocation.Location = new System.Drawing.Point(17, 15);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.TabStop = false;
            this.lblLocation.Text = "Loc#";
            // 
            // lblRemarks
            // 
            this.lblRemarks.ClientAction = null;
            this.lblRemarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRemarks.Location = new System.Drawing.Point(17, 153);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.TabStop = false;
            this.lblRemarks.Text = "Remark(s)";
            // 
            // lblRecvDate
            // 
            this.lblRecvDate.ClientAction = null;
            this.lblRecvDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRecvDate.Location = new System.Drawing.Point(17, 38);
            this.lblRecvDate.Name = "lblRecvDate";
            this.lblRecvDate.Size = new System.Drawing.Size(100, 23);
            this.lblRecvDate.TabIndex = 2;
            this.lblRecvDate.TabStop = false;
            this.lblRecvDate.Text = "Receive Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.ClientAction = null;
            this.lblOperatorCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOperatorCode.Location = new System.Drawing.Point(17, 61);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 23);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.TabStop = false;
            this.lblOperatorCode.Text = "Operator";
            // 
            // txtTxType
            // 
            this.txtTxType.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxType.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtTxType.ClientAction = null;
            this.txtTxType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTxType.Location = new System.Drawing.Point(90, 43);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.ReadOnly = true;
            this.txtTxType.Size = new System.Drawing.Size(64, 20);
            this.txtTxType.TabIndex = 1;
            this.txtTxType.TabStop = false;
            this.txtTxType.Text = "REJ";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.ClientAction = null;
            this.lblTxNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTxNumber.Location = new System.Drawing.Point(172, 46);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(76, 23);
            this.lblTxNumber.TabIndex = 10;
            this.lblTxNumber.TabStop = false;
            this.lblTxNumber.Text = "Tx Number:";
            this.lblTxNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabGoodsREJ
            // 
            this.tabGoodsREJ.ClientAction = null;
            this.tabGoodsREJ.Controls.Add(this.tpGeneral);
            this.tabGoodsREJ.Controls.Add(this.tpDetails);
            this.tabGoodsREJ.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabGoodsREJ.Location = new System.Drawing.Point(12, 83);
            this.tabGoodsREJ.Multiline = false;
            this.tabGoodsREJ.Name = "tabGoodsREJ";
            this.tabGoodsREJ.SelectedIndex = 0;
            this.tabGoodsREJ.ShowCloseButton = false;
            this.tabGoodsREJ.Size = new System.Drawing.Size(774, 405);
            this.tabGoodsREJ.TabIndex = 9;
            // 
            // tpDetails
            // 
            this.tpDetails.ClientAction = null;
            this.tpDetails.Controls.Add(this.txtUnitAmount);
            this.tpDetails.Controls.Add(this.btnEditItem);
            this.tpDetails.Controls.Add(this.lvDetailsList);
            this.tpDetails.Controls.Add(this.btnRemove);
            this.tpDetails.Controls.Add(this.btnAddItem);
            this.tpDetails.Controls.Add(this.lblLineCount);
            this.tpDetails.Controls.Add(this.lblNumberOfLine);
            this.tpDetails.Controls.Add(this.txtUnitPrice);
            this.tpDetails.Controls.Add(this.lblUnitAmount);
            this.tpDetails.Controls.Add(this.lblUnitPrice);
            this.tpDetails.Controls.Add(this.txtQty);
            this.tpDetails.Controls.Add(this.lblQty);
            this.tpDetails.Controls.Add(this.txtDescription);
            this.tpDetails.Controls.Add(this.lblDescription);
            this.tpDetails.Controls.Add(this.lblStockCode);
            this.tpDetails.Controls.Add(this.basicProduct);
            this.tpDetails.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(766, 379);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Detail";
            // 
            // txtUnitAmount
            // 
            this.txtUnitAmount.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtUnitAmount.ClientAction = null;
            this.txtUnitAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtUnitAmount.Location = new System.Drawing.Point(371, 58);
            this.txtUnitAmount.Name = "txtUnitAmount";
            this.txtUnitAmount.Size = new System.Drawing.Size(54, 20);
            this.txtUnitAmount.TabIndex = 2;
            this.txtUnitAmount.Text = "0.00";
            // 
            // btnEditItem
            // 
            this.btnEditItem.ClientAction = null;
            this.btnEditItem.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnEditItem.Location = new System.Drawing.Point(443, 33);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 4;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // lvDetailsList
            // 
            this.lvDetailsList.ClientAction = null;
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
            this.colUnitAmount,
            this.colAmount,
            this.colProductId});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 87);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 289);
            this.lvDetailsList.TabIndex = 27;
            this.lvDetailsList.TabStop = false;
            this.lvDetailsList.SelectedIndexChanged += new System.EventHandler(this.lvDetailsList_SelectedIndexChanged);
            // 
            // colDetailsId
            // 
            this.colDetailsId.ClientAction = null;
            this.colDetailsId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colDetailsId.Image = null;
            this.colDetailsId.Text = "DetailsId";
            this.colDetailsId.Visible = false;
            this.colDetailsId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.ClientAction = null;
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStatus
            // 
            this.colStatus.ClientAction = null;
            this.colStatus.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 40;
            // 
            // colStockCode
            // 
            this.colStockCode.ClientAction = null;
            this.colStockCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colStockCode.Image = null;
            this.colStockCode.Text = "PLU";
            this.colStockCode.Width = 80;
            // 
            // colAppendix1
            // 
            this.colAppendix1.ClientAction = null;
            this.colAppendix1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAppendix1.Image = null;
            this.colAppendix1.Text = "SEASON";
            this.colAppendix1.Width = 50;
            // 
            // colAppendix2
            // 
            this.colAppendix2.ClientAction = null;
            this.colAppendix2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAppendix2.Image = null;
            this.colAppendix2.Text = "COLOR";
            this.colAppendix2.Width = 50;
            // 
            // colAppendix3
            // 
            this.colAppendix3.ClientAction = null;
            this.colAppendix3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAppendix3.Image = null;
            this.colAppendix3.Text = "SIZE";
            this.colAppendix3.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.ClientAction = null;
            this.colDescription.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colQty
            // 
            this.colQty.ClientAction = null;
            this.colQty.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colQty.Image = null;
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colQty.Width = 80;
            // 
            // colUnitAmount
            // 
            this.colUnitAmount.ClientAction = null;
            this.colUnitAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colUnitAmount.Image = null;
            this.colUnitAmount.Text = "Unit Amount";
            this.colUnitAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colUnitAmount.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.ClientAction = null;
            this.colAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAmount.Image = null;
            this.colAmount.Text = "Amount($)";
            this.colAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 80;
            // 
            // colProductId
            // 
            this.colProductId.ClientAction = null;
            this.colProductId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProductId.Image = null;
            this.colProductId.Text = "ProductId";
            this.colProductId.Visible = false;
            this.colProductId.Width = 150;
            // 
            // btnRemove
            // 
            this.btnRemove.ClientAction = null;
            this.btnRemove.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnRemove.Location = new System.Drawing.Point(443, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.ClientAction = null;
            this.btnAddItem.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAddItem.Location = new System.Drawing.Point(443, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.ClientAction = null;
            this.lblLineCount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLineCount.Location = new System.Drawing.Point(721, 61);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // lblNumberOfLine
            // 
            this.lblNumberOfLine.ClientAction = null;
            this.lblNumberOfLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblNumberOfLine.Location = new System.Drawing.Point(651, 61);
            this.lblNumberOfLine.Name = "lblNumberOfLine";
            this.lblNumberOfLine.Size = new System.Drawing.Size(64, 23);
            this.lblNumberOfLine.TabIndex = 21;
            this.lblNumberOfLine.TabStop = false;
            this.lblNumberOfLine.Text = "# of Line(s)";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.BackColor = System.Drawing.Color.LightYellow;
            this.txtUnitPrice.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtUnitPrice.ClientAction = null;
            this.txtUnitPrice.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtUnitPrice.Location = new System.Drawing.Point(89, 58);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(54, 20);
            this.txtUnitPrice.TabIndex = 20;
            this.txtUnitPrice.TabStop = false;
            this.txtUnitPrice.Text = "0.00";
            // 
            // lblUnitAmount
            // 
            this.lblUnitAmount.ClientAction = null;
            this.lblUnitAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblUnitAmount.Location = new System.Drawing.Point(269, 61);
            this.lblUnitAmount.Name = "lblUnitAmount";
            this.lblUnitAmount.Size = new System.Drawing.Size(96, 23);
            this.lblUnitAmount.TabIndex = 18;
            this.lblUnitAmount.TabStop = false;
            this.lblUnitAmount.Text = "Rej. Unit Amount";
            this.lblUnitAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.ClientAction = null;
            this.lblUnitPrice.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblUnitPrice.Location = new System.Drawing.Point(17, 61);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(66, 23);
            this.lblUnitPrice.TabIndex = 15;
            this.lblUnitPrice.TabStop = false;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtQty.ClientAction = null;
            this.txtQty.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtQty.Location = new System.Drawing.Point(209, 58);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(54, 20);
            this.txtQty.TabIndex = 1;
            this.txtQty.Text = "1";
            // 
            // lblQty
            // 
            this.lblQty.ClientAction = null;
            this.lblQty.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblQty.Location = new System.Drawing.Point(149, 61);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 23);
            this.lblQty.TabIndex = 13;
            this.lblQty.TabStop = false;
            this.lblQty.Text = "Rej. Qty";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtDescription.ClientAction = null;
            this.txtDescription.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtDescription.Location = new System.Drawing.Point(89, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(336, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.ClientAction = null;
            this.lblDescription.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblDescription.Location = new System.Drawing.Point(17, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.TabStop = false;
            this.lblDescription.Text = "Description";
            // 
            // lblStockCode
            // 
            this.lblStockCode.ClientAction = null;
            this.lblStockCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblStockCode.Location = new System.Drawing.Point(17, 15);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(66, 23);
            this.lblStockCode.TabIndex = 1;
            this.lblStockCode.TabStop = false;
            this.lblStockCode.Text = "Stock Code";
            // 
            // basicProduct
            // 
            this.basicProduct.ClientAction = null;
            this.basicProduct.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.LightYellow;
            this.txtTxNumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtTxNumber.ClientAction = null;
            this.txtTxNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTxNumber.Location = new System.Drawing.Point(254, 43);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 11;
            this.txtTxNumber.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.ClientAction = null;
            this.lblTotalAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.txtTotalAmount.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtTotalAmount.ClientAction = null;
            this.txtTotalAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.Controls.Add(this.tabGoodsREJ);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxType);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblTxType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Goods Return > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TabPage tpGeneral;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsREJ;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtTotalAmount;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblRecvDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblRefNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblLocation;
        private Gizmox.WebGUI.Forms.TextBox txtRefNumber;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpRecvDate;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.ComboBox cboStatus;
        private Gizmox.WebGUI.Forms.TextBox txtAmendmentRetrict;
        private Gizmox.WebGUI.Forms.Label lblAmendmentRetrict;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdateOn;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.Label lblUnitPrice;
        private Gizmox.WebGUI.Forms.TextBox txtQty;
        private Gizmox.WebGUI.Forms.Label lblQty;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label lblNumberOfLine;
        private Gizmox.WebGUI.Forms.TextBox txtUnitPrice;
        private Gizmox.WebGUI.Forms.Label lblUnitAmount;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colStockCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAppendix3;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colUnitAmount;
        private Gizmox.WebGUI.Forms.ColumnHeader colAmount;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductId;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.TextBox txtSupplierInvoice;
        private Gizmox.WebGUI.Forms.Label lblSupplierInvoice;
        private Gizmox.WebGUI.Forms.ComboBox cboSupplierList;
        private Gizmox.WebGUI.Forms.Label lblSupplier;
        private Gizmox.WebGUI.Forms.Label lblAPLink;
        private Gizmox.WebGUI.Forms.CheckBox chkAPLink;
        private Gizmox.WebGUI.Forms.TextBox txtUnitAmount;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;


    }
}