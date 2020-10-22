namespace RT2020.Purchasing.Wizard
{
    partial class PurchaseOrder
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
            this.txtTotalQty = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCoeffcient = new Gizmox.WebGUI.Forms.TextBox();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtPaymentTerm = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.tpDetail = new Gizmox.WebGUI.Forms.TabPage();
            this.btnAddItem = new Gizmox.WebGUI.Forms.Button();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.btnEditItem = new Gizmox.WebGUI.Forms.Button();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtDisc = new Gizmox.WebGUI.Forms.TextBox();
            this.lvDetailsList = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPLU = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSeason = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colColor = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDescription = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOrderQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colUnitCost = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colDiscount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSubTotal = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRemark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPruductId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblLineCount = new Gizmox.WebGUI.Forms.Label();
            this.lblNumberOfLine = new Gizmox.WebGUI.Forms.Label();
            this.txtUnitCost = new Gizmox.WebGUI.Forms.TextBox();
            this.lblUnitAmount = new Gizmox.WebGUI.Forms.Label();
            this.lblUnitCost = new Gizmox.WebGUI.Forms.Label();
            this.txtQty = new Gizmox.WebGUI.Forms.TextBox();
            this.lblQty = new Gizmox.WebGUI.Forms.Label();
            this.txtDescription = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDescription = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.basicProduct = new RT2020.Controls.ProductSearcher.Basic();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.lblCoeffcient = new Gizmox.WebGUI.Forms.Label();
            this.cboPaymentMethod = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblPaymentMethod = new Gizmox.WebGUI.Forms.Label();
            this.cboStatus = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSupplierCode = new Gizmox.WebGUI.Forms.Label();
            this.lblPaymentRemark = new Gizmox.WebGUI.Forms.Label();
            this.dtpOrderDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblPaymentTerm = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.tabGoodsREJ = new Gizmox.WebGUI.Forms.TabControl();
            this.tpMain = new Gizmox.WebGUI.Forms.TabPage();
            this.dtpCancelDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpDeliveryDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblNetCost = new Gizmox.WebGUI.Forms.Label();
            this.lblLastUser = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUser = new Gizmox.WebGUI.Forms.TextBox();
            this.lblShipmentRemark = new Gizmox.WebGUI.Forms.Label();
            this.txtShipmentRemark = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDeposit = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.txtDeposit = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.cboShipmentMethod = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblShipmentMethod = new Gizmox.WebGUI.Forms.Label();
            this.lblPartialShipment = new Gizmox.WebGUI.Forms.Label();
            this.cboPartialShipment = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtXRate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInsuranceCharge = new Gizmox.WebGUI.Forms.Label();
            this.lblHandlingCharge = new Gizmox.WebGUI.Forms.Label();
            this.lblFreightCharge = new Gizmox.WebGUI.Forms.Label();
            this.lblXRate = new Gizmox.WebGUI.Forms.Label();
            this.lblOtherCharge = new Gizmox.WebGUI.Forms.Label();
            this.txtOtherCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtFreightCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHandlingCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInsuranceCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtGroupDiscount3 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtGroupDiscount2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtGroupDiscount1 = new Gizmox.WebGUI.Forms.TextBox();
            this.lblGroupDiscount3 = new Gizmox.WebGUI.Forms.Label();
            this.lblGroupDiscount2 = new Gizmox.WebGUI.Forms.Label();
            this.lblGroupDiscount1 = new Gizmox.WebGUI.Forms.Label();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.lblLocation = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblCancelDate = new Gizmox.WebGUI.Forms.Label();
            this.lblDeliveryDate = new Gizmox.WebGUI.Forms.Label();
            this.txtTypeDetail = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTypeDetail = new Gizmox.WebGUI.Forms.Label();
            this.txtNetCost = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdate = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPaymentRemark = new Gizmox.WebGUI.Forms.TextBox();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboSupplierCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblOrderDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.tpOther = new Gizmox.WebGUI.Forms.TabPage();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtPoRemark3 = new Gizmox.WebGUI.Forms.TextBox();
            this.btnCopy = new Gizmox.WebGUI.Forms.Button();
            this.cboPoRemark3 = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblPoRemark3 = new Gizmox.WebGUI.Forms.Label();
            this.txtPoRemark2 = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPoRemark2 = new Gizmox.WebGUI.Forms.Label();
            this.lblPoRemark1 = new Gizmox.WebGUI.Forms.Label();
            this.txtPoRemark1 = new Gizmox.WebGUI.Forms.TextBox();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblContactTel = new Gizmox.WebGUI.Forms.Label();
            this.lblContactPerson = new Gizmox.WebGUI.Forms.Label();
            this.txtContactTel = new Gizmox.WebGUI.Forms.TextBox();
            this.txtContactPerson = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDeliveryAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.lblDeliveryAddress = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtPurchaseOrderNo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtOrderAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.cboType = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.LightYellow;
            this.txtTotalQty.Location = new System.Drawing.Point(597, 154);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(92, 20);
            this.txtTotalQty.TabIndex = 23;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtCoeffcient
            // 
            this.txtCoeffcient.BackColor = System.Drawing.Color.LightYellow;
            this.txtCoeffcient.Location = new System.Drawing.Point(597, 202);
            this.txtCoeffcient.Name = "txtCoeffcient";
            this.txtCoeffcient.ReadOnly = true;
            this.txtCoeffcient.Size = new System.Drawing.Size(92, 20);
            this.txtCoeffcient.TabIndex = 22;
            this.txtCoeffcient.TabStop = false;
            this.txtCoeffcient.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
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
            // txtPaymentTerm
            // 
            this.txtPaymentTerm.Location = new System.Drawing.Point(123, 178);
            this.txtPaymentTerm.Name = "txtPaymentTerm";
            this.txtPaymentTerm.Size = new System.Drawing.Size(88, 20);
            this.txtPaymentTerm.TabIndex = 5;
            this.txtPaymentTerm.Text = "0";
            this.txtPaymentTerm.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblTxType
            // 
            this.lblTxType.Location = new System.Drawing.Point(12, 44);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(42, 23);
            this.lblTxType.TabIndex = 8;
            this.lblTxType.TabStop = false;
            this.lblTxType.Text = "Type:";
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.btnAddItem);
            this.tpDetail.Controls.Add(this.btnRemove);
            this.tpDetail.Controls.Add(this.btnEditItem);
            this.tpDetail.Controls.Add(this.txtRemarks);
            this.tpDetail.Controls.Add(this.lblRemarks);
            this.tpDetail.Controls.Add(this.label11);
            this.tpDetail.Controls.Add(this.txtDisc);
            this.tpDetail.Controls.Add(this.lvDetailsList);
            this.tpDetail.Controls.Add(this.lblLineCount);
            this.tpDetail.Controls.Add(this.lblNumberOfLine);
            this.tpDetail.Controls.Add(this.txtUnitCost);
            this.tpDetail.Controls.Add(this.lblUnitAmount);
            this.tpDetail.Controls.Add(this.lblUnitCost);
            this.tpDetail.Controls.Add(this.txtQty);
            this.tpDetail.Controls.Add(this.lblQty);
            this.tpDetail.Controls.Add(this.txtDescription);
            this.tpDetail.Controls.Add(this.lblDescription);
            this.tpDetail.Controls.Add(this.lblStockCode);
            this.tpDetail.Controls.Add(this.basicProduct);
            this.tpDetail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetail.Location = new System.Drawing.Point(4, 22);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(772, 379);
            this.tpDetail.TabIndex = 0;
            this.tpDetail.Text = "Detail";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(445, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(93, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(445, 61);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(445, 35);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 4;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.Click += new System.EventHandler(this.BtnEditItem_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(89, 81);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(284, 20);
            this.txtRemarks.TabIndex = 20;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(17, 84);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 13;
            this.lblRemarks.TabStop = false;
            this.lblRemarks.Text = "Remark(s)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(379, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 22;
            this.label11.TabStop = false;
            this.label11.Text = "%";
            // 
            // txtDisc
            // 
            this.txtDisc.Location = new System.Drawing.Point(319, 58);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(54, 20);
            this.txtDisc.TabIndex = 2;
            this.txtDisc.Text = "0.00";
            this.txtDisc.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lvDetailsList
            // 
            this.lvDetailsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailId,
            this.colLineNumber,
            this.colStatus,
            this.colPLU,
            this.colSeason,
            this.colColor,
            this.colSize,
            this.colDescription,
            this.colOrderQty,
            this.colUnitCost,
            this.colDiscount,
            this.colSubTotal,
            this.colRemark,
            this.colPruductId});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(10, 110);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(760, 266);
            this.lvDetailsList.TabIndex = 27;
            this.lvDetailsList.TabStop = false;
            this.lvDetailsList.SelectedIndexChanged += new System.EventHandler(this.LvDetailsList_SelectedIndexChanged);
            // 
            // colDetailId
            // 
            this.colDetailId.Image = null;
            this.colDetailId.Text = "DetailId";
            this.colDetailId.Visible = false;
            this.colDetailId.Width = 150;
            // 
            // colLineNumber
            // 
            this.colLineNumber.Image = null;
            this.colLineNumber.Text = "LN";
            this.colLineNumber.Width = 30;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 50;
            // 
            // colPLU
            // 
            this.colPLU.Image = null;
            this.colPLU.Text = "PLU";
            this.colPLU.Width = 80;
            // 
            // colSeason
            // 
            this.colSeason.Image = null;
            this.colSeason.Text = "SEASON";
            this.colSeason.Width = 55;
            // 
            // colColor
            // 
            this.colColor.Image = null;
            this.colColor.Text = "COLOR";
            this.colColor.Width = 55;
            // 
            // colSize
            // 
            this.colSize.Image = null;
            this.colSize.Text = "SIZE";
            this.colSize.Width = 40;
            // 
            // colDescription
            // 
            this.colDescription.Image = null;
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colOrderQty
            // 
            this.colOrderQty.Image = null;
            this.colOrderQty.Text = "Order Qty";
            this.colOrderQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colOrderQty.Width = 70;
            // 
            // colUnitCost
            // 
            this.colUnitCost.Image = null;
            this.colUnitCost.Text = "Unit Cost";
            this.colUnitCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colUnitCost.Width = 70;
            // 
            // colDiscount
            // 
            this.colDiscount.Image = null;
            this.colDiscount.Text = "Discount(%)";
            this.colDiscount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colDiscount.Width = 75;
            // 
            // colSubTotal
            // 
            this.colSubTotal.Image = null;
            this.colSubTotal.Text = "Sub Total";
            this.colSubTotal.Width = 70;
            // 
            // colRemark
            // 
            this.colRemark.Image = null;
            this.colRemark.Text = "Remark";
            this.colRemark.Width = 80;
            // 
            // colPruductId
            // 
            this.colPruductId.Image = null;
            this.colPruductId.Text = "ProductId";
            this.colPruductId.Visible = false;
            this.colPruductId.Width = 150;
            // 
            // lblLineCount
            // 
            this.lblLineCount.Location = new System.Drawing.Point(512, 84);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(38, 23);
            this.lblLineCount.TabIndex = 22;
            this.lblLineCount.TabStop = false;
            this.lblLineCount.Text = "0";
            // 
            // lblNumberOfLine
            // 
            this.lblNumberOfLine.Location = new System.Drawing.Point(442, 84);
            this.lblNumberOfLine.Name = "lblNumberOfLine";
            this.lblNumberOfLine.Size = new System.Drawing.Size(64, 23);
            this.lblNumberOfLine.TabIndex = 21;
            this.lblNumberOfLine.TabStop = false;
            this.lblNumberOfLine.Text = "# of Line(s)";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Location = new System.Drawing.Point(206, 58);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(71, 20);
            this.txtUnitCost.TabIndex = 20;
            this.txtUnitCost.Text = "0";
            this.txtUnitCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblUnitAmount
            // 
            this.lblUnitAmount.AutoSize = true;
            this.lblUnitAmount.Location = new System.Drawing.Point(283, 61);
            this.lblUnitAmount.Name = "lblUnitAmount";
            this.lblUnitAmount.Size = new System.Drawing.Size(30, 13);
            this.lblUnitAmount.TabIndex = 18;
            this.lblUnitAmount.TabStop = false;
            this.lblUnitAmount.Text = "Disc.";
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.AutoSize = true;
            this.lblUnitCost.Location = new System.Drawing.Point(149, 61);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(51, 13);
            this.lblUnitCost.TabIndex = 15;
            this.lblUnitCost.TabStop = false;
            this.lblUnitCost.Text = "Unit Cost";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(89, 58);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(54, 20);
            this.txtQty.TabIndex = 1;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(17, 61);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 23);
            this.lblQty.TabIndex = 13;
            this.lblQty.TabStop = false;
            this.lblQty.Text = "QTY";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescription.Location = new System.Drawing.Point(89, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(284, 20);
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
            this.lblStockCode.Text = "Stock Code";
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
            this.basicProduct.SelectionChanged += new System.EventHandler<RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs>(this.BasicProduct_SelectionChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // lblCoeffcient
            // 
            this.lblCoeffcient.AutoSize = true;
            this.lblCoeffcient.Location = new System.Drawing.Point(499, 205);
            this.lblCoeffcient.Name = "lblCoeffcient";
            this.lblCoeffcient.Size = new System.Drawing.Size(57, 13);
            this.lblCoeffcient.TabIndex = 21;
            this.lblCoeffcient.TabStop = false;
            this.lblCoeffcient.Text = "Coeffcient";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownWidth = 215;
            this.cboPaymentMethod.Location = new System.Drawing.Point(123, 154);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(132, 21);
            this.cboPaymentMethod.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Location = new System.Drawing.Point(17, 157);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(100, 23);
            this.lblPaymentMethod.TabIndex = 24;
            this.lblPaymentMethod.TabStop = false;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboStatus.DropDownWidth = 92;
            this.cboStatus.Items.AddRange(new object[] {
            "HOLD",
            "POST"});
            this.cboStatus.Location = new System.Drawing.Point(597, 17);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(92, 21);
            this.cboStatus.TabIndex = 7;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.Location = new System.Drawing.Point(17, 21);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(100, 18);
            this.lblSupplierCode.TabIndex = 6;
            this.lblSupplierCode.TabStop = false;
            this.lblSupplierCode.Text = "Supplier Code";
            // 
            // lblPaymentRemark
            // 
            this.lblPaymentRemark.AutoSize = true;
            this.lblPaymentRemark.Location = new System.Drawing.Point(17, 229);
            this.lblPaymentRemark.Name = "lblPaymentRemark";
            this.lblPaymentRemark.Size = new System.Drawing.Size(88, 13);
            this.lblPaymentRemark.TabIndex = 5;
            this.lblPaymentRemark.TabStop = false;
            this.lblPaymentRemark.Text = "Payment Remark";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpOrderDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpOrderDate.CustomFormat = "dd/MM/yyyy";
            this.dtpOrderDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(123, 64);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(132, 20);
            this.dtpOrderDate.TabIndex = 1;
            // 
            // lblPaymentTerm
            // 
            this.lblPaymentTerm.Location = new System.Drawing.Point(17, 181);
            this.lblPaymentTerm.Name = "lblPaymentTerm";
            this.lblPaymentTerm.Size = new System.Drawing.Size(82, 23);
            this.lblPaymentTerm.TabIndex = 10;
            this.lblPaymentTerm.TabStop = false;
            this.lblPaymentTerm.Text = "Payment Term";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Location = new System.Drawing.Point(499, 157);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(82, 23);
            this.lblTotalQty.TabIndex = 9;
            this.lblTotalQty.TabStop = false;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // tabGoodsREJ
            // 
            this.tabGoodsREJ.Controls.Add(this.tpMain);
            this.tabGoodsREJ.Controls.Add(this.tpDetail);
            this.tabGoodsREJ.Controls.Add(this.tpOther);
            this.tabGoodsREJ.Location = new System.Drawing.Point(9, 84);
            this.tabGoodsREJ.Multiline = false;
            this.tabGoodsREJ.Name = "tabGoodsREJ";
            this.tabGoodsREJ.SelectedIndex = 0;
            this.tabGoodsREJ.ShowCloseButton = false;
            this.tabGoodsREJ.Size = new System.Drawing.Size(780, 405);
            this.tabGoodsREJ.TabIndex = 9;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.dtpCancelDate);
            this.tpMain.Controls.Add(this.dtpDeliveryDate);
            this.tpMain.Controls.Add(this.lblNetCost);
            this.tpMain.Controls.Add(this.lblLastUser);
            this.tpMain.Controls.Add(this.txtLastUser);
            this.tpMain.Controls.Add(this.lblShipmentRemark);
            this.tpMain.Controls.Add(this.txtShipmentRemark);
            this.tpMain.Controls.Add(this.lblDeposit);
            this.tpMain.Controls.Add(this.label10);
            this.tpMain.Controls.Add(this.txtDeposit);
            this.tpMain.Controls.Add(this.label9);
            this.tpMain.Controls.Add(this.cboShipmentMethod);
            this.tpMain.Controls.Add(this.lblShipmentMethod);
            this.tpMain.Controls.Add(this.lblPartialShipment);
            this.tpMain.Controls.Add(this.cboPartialShipment);
            this.tpMain.Controls.Add(this.txtXRate);
            this.tpMain.Controls.Add(this.lblInsuranceCharge);
            this.tpMain.Controls.Add(this.lblHandlingCharge);
            this.tpMain.Controls.Add(this.lblFreightCharge);
            this.tpMain.Controls.Add(this.lblXRate);
            this.tpMain.Controls.Add(this.lblOtherCharge);
            this.tpMain.Controls.Add(this.txtOtherCharge);
            this.tpMain.Controls.Add(this.label8);
            this.tpMain.Controls.Add(this.txtFreightCharge);
            this.tpMain.Controls.Add(this.txtHandlingCharge);
            this.tpMain.Controls.Add(this.txtInsuranceCharge);
            this.tpMain.Controls.Add(this.label7);
            this.tpMain.Controls.Add(this.label6);
            this.tpMain.Controls.Add(this.label5);
            this.tpMain.Controls.Add(this.label4);
            this.tpMain.Controls.Add(this.label3);
            this.tpMain.Controls.Add(this.label2);
            this.tpMain.Controls.Add(this.txtGroupDiscount3);
            this.tpMain.Controls.Add(this.txtGroupDiscount2);
            this.tpMain.Controls.Add(this.txtGroupDiscount1);
            this.tpMain.Controls.Add(this.lblGroupDiscount3);
            this.tpMain.Controls.Add(this.lblGroupDiscount2);
            this.tpMain.Controls.Add(this.lblGroupDiscount1);
            this.tpMain.Controls.Add(this.cboCurrency);
            this.tpMain.Controls.Add(this.cboLocation);
            this.tpMain.Controls.Add(this.lblCurrency);
            this.tpMain.Controls.Add(this.lblLocation);
            this.tpMain.Controls.Add(this.label1);
            this.tpMain.Controls.Add(this.lblCancelDate);
            this.tpMain.Controls.Add(this.lblDeliveryDate);
            this.tpMain.Controls.Add(this.txtTypeDetail);
            this.tpMain.Controls.Add(this.lblTypeDetail);
            this.tpMain.Controls.Add(this.cboPaymentMethod);
            this.tpMain.Controls.Add(this.lblPaymentMethod);
            this.tpMain.Controls.Add(this.txtTotalQty);
            this.tpMain.Controls.Add(this.txtCoeffcient);
            this.tpMain.Controls.Add(this.lblCoeffcient);
            this.tpMain.Controls.Add(this.txtNetCost);
            this.tpMain.Controls.Add(this.txtLastUpdate);
            this.tpMain.Controls.Add(this.cboStatus);
            this.tpMain.Controls.Add(this.txtPaymentTerm);
            this.tpMain.Controls.Add(this.txtPaymentRemark);
            this.tpMain.Controls.Add(this.dtpOrderDate);
            this.tpMain.Controls.Add(this.cboOperatorCode);
            this.tpMain.Controls.Add(this.cboSupplierCode);
            this.tpMain.Controls.Add(this.lblPaymentTerm);
            this.tpMain.Controls.Add(this.lblTotalQty);
            this.tpMain.Controls.Add(this.lblLastUpdate);
            this.tpMain.Controls.Add(this.lblStatus);
            this.tpMain.Controls.Add(this.lblSupplierCode);
            this.tpMain.Controls.Add(this.lblPaymentRemark);
            this.tpMain.Controls.Add(this.lblOrderDate);
            this.tpMain.Controls.Add(this.lblOperatorCode);
            this.tpMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(772, 379);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // dtpCancelDate
            // 
            this.dtpCancelDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpCancelDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpCancelDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCancelDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpCancelDate.Location = new System.Drawing.Point(123, 108);
            this.dtpCancelDate.Name = "dtpCancelDate";
            this.dtpCancelDate.Size = new System.Drawing.Size(132, 20);
            this.dtpCancelDate.TabIndex = 1;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpDeliveryDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDeliveryDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(123, 86);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(132, 20);
            this.dtpDeliveryDate.TabIndex = 1;
            // 
            // lblNetCost
            // 
            this.lblNetCost.Location = new System.Drawing.Point(499, 181);
            this.lblNetCost.Name = "lblNetCost";
            this.lblNetCost.Size = new System.Drawing.Size(82, 23);
            this.lblNetCost.TabIndex = 9;
            this.lblNetCost.TabStop = false;
            this.lblNetCost.Text = "Net Cost";
            // 
            // lblLastUser
            // 
            this.lblLastUser.Location = new System.Drawing.Point(272, 228);
            this.lblLastUser.Name = "lblLastUser";
            this.lblLastUser.Size = new System.Drawing.Size(100, 23);
            this.lblLastUser.TabIndex = 21;
            this.lblLastUser.TabStop = false;
            this.lblLastUser.Text = "Last User";
            // 
            // txtLastUser
            // 
            this.txtLastUser.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUser.Location = new System.Drawing.Point(373, 225);
            this.txtLastUser.Name = "txtLastUser";
            this.txtLastUser.ReadOnly = true;
            this.txtLastUser.Size = new System.Drawing.Size(96, 20);
            this.txtLastUser.TabIndex = 22;
            this.txtLastUser.TabStop = false;
            // 
            // lblShipmentRemark
            // 
            this.lblShipmentRemark.AutoSize = true;
            this.lblShipmentRemark.Location = new System.Drawing.Point(272, 205);
            this.lblShipmentRemark.Name = "lblShipmentRemark";
            this.lblShipmentRemark.Size = new System.Drawing.Size(90, 13);
            this.lblShipmentRemark.TabIndex = 5;
            this.lblShipmentRemark.TabStop = false;
            this.lblShipmentRemark.Text = "Shipment Remark";
            // 
            // txtShipmentRemark
            // 
            this.txtShipmentRemark.Location = new System.Drawing.Point(373, 202);
            this.txtShipmentRemark.Name = "txtShipmentRemark";
            this.txtShipmentRemark.Size = new System.Drawing.Size(97, 20);
            this.txtShipmentRemark.TabIndex = 6;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(17, 205);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(43, 13);
            this.lblDeposit.TabIndex = 5;
            this.lblDeposit.TabStop = false;
            this.lblDeposit.Text = "Deposit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "%";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(123, 202);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(88, 20);
            this.txtDeposit.TabIndex = 38;
            this.txtDeposit.Text = "0.00";
            this.txtDeposit.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "day(s)";
            // 
            // cboShipmentMethod
            // 
            this.cboShipmentMethod.DropDownWidth = 215;
            this.cboShipmentMethod.Location = new System.Drawing.Point(373, 178);
            this.cboShipmentMethod.Name = "cboShipmentMethod";
            this.cboShipmentMethod.Size = new System.Drawing.Size(97, 21);
            this.cboShipmentMethod.TabIndex = 3;
            // 
            // lblShipmentMethod
            // 
            this.lblShipmentMethod.Location = new System.Drawing.Point(272, 181);
            this.lblShipmentMethod.Name = "lblShipmentMethod";
            this.lblShipmentMethod.Size = new System.Drawing.Size(100, 23);
            this.lblShipmentMethod.TabIndex = 24;
            this.lblShipmentMethod.TabStop = false;
            this.lblShipmentMethod.Text = "Shipment Method";
            // 
            // lblPartialShipment
            // 
            this.lblPartialShipment.Location = new System.Drawing.Point(272, 157);
            this.lblPartialShipment.Name = "lblPartialShipment";
            this.lblPartialShipment.Size = new System.Drawing.Size(100, 23);
            this.lblPartialShipment.TabIndex = 24;
            this.lblPartialShipment.TabStop = false;
            this.lblPartialShipment.Text = "Partial Shipment";
            // 
            // cboPartialShipment
            // 
            this.cboPartialShipment.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboPartialShipment.DropDownWidth = 97;
            this.cboPartialShipment.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.cboPartialShipment.Location = new System.Drawing.Point(373, 154);
            this.cboPartialShipment.Name = "cboPartialShipment";
            this.cboPartialShipment.Size = new System.Drawing.Size(97, 21);
            this.cboPartialShipment.TabIndex = 3;
            this.cboPartialShipment.Text = "YES";
            // 
            // txtXRate
            // 
            this.txtXRate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtXRate.Location = new System.Drawing.Point(597, 41);
            this.txtXRate.Name = "txtXRate";
            this.txtXRate.Size = new System.Drawing.Size(92, 20);
            this.txtXRate.TabIndex = 38;
            this.txtXRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtXRate.Leave += new System.EventHandler(this.TxtXRate_Leave);
            // 
            // lblInsuranceCharge
            // 
            this.lblInsuranceCharge.AutoSize = true;
            this.lblInsuranceCharge.Location = new System.Drawing.Point(499, 112);
            this.lblInsuranceCharge.Name = "lblInsuranceCharge";
            this.lblInsuranceCharge.Size = new System.Drawing.Size(93, 13);
            this.lblInsuranceCharge.TabIndex = 35;
            this.lblInsuranceCharge.Text = "Insurance Charge";
            // 
            // lblHandlingCharge
            // 
            this.lblHandlingCharge.AutoSize = true;
            this.lblHandlingCharge.Location = new System.Drawing.Point(499, 90);
            this.lblHandlingCharge.Name = "lblHandlingCharge";
            this.lblHandlingCharge.Size = new System.Drawing.Size(86, 13);
            this.lblHandlingCharge.TabIndex = 35;
            this.lblHandlingCharge.Text = "Handling Charge";
            // 
            // lblFreightCharge
            // 
            this.lblFreightCharge.AutoSize = true;
            this.lblFreightCharge.Location = new System.Drawing.Point(499, 68);
            this.lblFreightCharge.Name = "lblFreightCharge";
            this.lblFreightCharge.Size = new System.Drawing.Size(79, 13);
            this.lblFreightCharge.TabIndex = 35;
            this.lblFreightCharge.Text = "Freight Charge";
            // 
            // lblXRate
            // 
            this.lblXRate.Location = new System.Drawing.Point(499, 44);
            this.lblXRate.Name = "lblXRate";
            this.lblXRate.Size = new System.Drawing.Size(56, 17);
            this.lblXRate.TabIndex = 35;
            this.lblXRate.Text = "XRate";
            // 
            // lblOtherCharge
            // 
            this.lblOtherCharge.AutoSize = true;
            this.lblOtherCharge.Location = new System.Drawing.Point(499, 134);
            this.lblOtherCharge.Name = "lblOtherCharge";
            this.lblOtherCharge.Size = new System.Drawing.Size(73, 13);
            this.lblOtherCharge.TabIndex = 35;
            this.lblOtherCharge.Text = "Other Charge";
            // 
            // txtOtherCharge
            // 
            this.txtOtherCharge.Location = new System.Drawing.Point(597, 132);
            this.txtOtherCharge.Name = "txtOtherCharge";
            this.txtOtherCharge.Size = new System.Drawing.Size(72, 20);
            this.txtOtherCharge.TabIndex = 38;
            this.txtOtherCharge.Text = "0.00";
            this.txtOtherCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(675, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "%";
            // 
            // txtFreightCharge
            // 
            this.txtFreightCharge.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.txtFreightCharge.Location = new System.Drawing.Point(597, 65);
            this.txtFreightCharge.Name = "txtFreightCharge";
            this.txtFreightCharge.Size = new System.Drawing.Size(72, 20);
            this.txtFreightCharge.TabIndex = 38;
            this.txtFreightCharge.Text = "0.00";
            this.txtFreightCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtFreightCharge.VisibleChanged += new System.EventHandler(this.TxtFreightCharge_VisibleChanged);
            // 
            // txtHandlingCharge
            // 
            this.txtHandlingCharge.Location = new System.Drawing.Point(597, 87);
            this.txtHandlingCharge.Name = "txtHandlingCharge";
            this.txtHandlingCharge.Size = new System.Drawing.Size(72, 20);
            this.txtHandlingCharge.TabIndex = 38;
            this.txtHandlingCharge.Text = "0.00";
            this.txtHandlingCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtInsuranceCharge
            // 
            this.txtInsuranceCharge.Location = new System.Drawing.Point(597, 109);
            this.txtInsuranceCharge.Name = "txtInsuranceCharge";
            this.txtInsuranceCharge.Size = new System.Drawing.Size(72, 20);
            this.txtInsuranceCharge.TabIndex = 38;
            this.txtInsuranceCharge.Text = "0.00";
            this.txtInsuranceCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(675, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "%";
            // 
            // txtGroupDiscount3
            // 
            this.txtGroupDiscount3.Location = new System.Drawing.Point(373, 109);
            this.txtGroupDiscount3.Name = "txtGroupDiscount3";
            this.txtGroupDiscount3.Size = new System.Drawing.Size(72, 20);
            this.txtGroupDiscount3.TabIndex = 38;
            this.txtGroupDiscount3.Text = "0.00";
            this.txtGroupDiscount3.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtGroupDiscount2
            // 
            this.txtGroupDiscount2.Location = new System.Drawing.Point(373, 87);
            this.txtGroupDiscount2.Name = "txtGroupDiscount2";
            this.txtGroupDiscount2.Size = new System.Drawing.Size(72, 20);
            this.txtGroupDiscount2.TabIndex = 38;
            this.txtGroupDiscount2.Text = "0.00";
            this.txtGroupDiscount2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtGroupDiscount1
            // 
            this.txtGroupDiscount1.Location = new System.Drawing.Point(373, 65);
            this.txtGroupDiscount1.Name = "txtGroupDiscount1";
            this.txtGroupDiscount1.Size = new System.Drawing.Size(72, 20);
            this.txtGroupDiscount1.TabIndex = 38;
            this.txtGroupDiscount1.Text = "0.00";
            this.txtGroupDiscount1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblGroupDiscount3
            // 
            this.lblGroupDiscount3.AutoSize = true;
            this.lblGroupDiscount3.Location = new System.Drawing.Point(272, 112);
            this.lblGroupDiscount3.Name = "lblGroupDiscount3";
            this.lblGroupDiscount3.Size = new System.Drawing.Size(86, 13);
            this.lblGroupDiscount3.TabIndex = 35;
            this.lblGroupDiscount3.Text = "Group Discount3";
            // 
            // lblGroupDiscount2
            // 
            this.lblGroupDiscount2.AutoSize = true;
            this.lblGroupDiscount2.Location = new System.Drawing.Point(272, 90);
            this.lblGroupDiscount2.Name = "lblGroupDiscount2";
            this.lblGroupDiscount2.Size = new System.Drawing.Size(86, 13);
            this.lblGroupDiscount2.TabIndex = 35;
            this.lblGroupDiscount2.Text = "Group Discount2";
            // 
            // lblGroupDiscount1
            // 
            this.lblGroupDiscount1.AutoSize = true;
            this.lblGroupDiscount1.Location = new System.Drawing.Point(272, 67);
            this.lblGroupDiscount1.Name = "lblGroupDiscount1";
            this.lblGroupDiscount1.Size = new System.Drawing.Size(86, 13);
            this.lblGroupDiscount1.TabIndex = 35;
            this.lblGroupDiscount1.Text = "Group Discount1";
            // 
            // cboCurrency
            // 
            this.cboCurrency.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboCurrency.DropDownWidth = 215;
            this.cboCurrency.Location = new System.Drawing.Point(373, 41);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(97, 21);
            this.cboCurrency.TabIndex = 0;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.CboCurrency_SelectedIndexChanged);
            // 
            // cboLocation
            // 
            this.cboLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboLocation.DropDownWidth = 215;
            this.cboLocation.Location = new System.Drawing.Point(373, 17);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(97, 21);
            this.cboLocation.TabIndex = 0;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(272, 44);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(53, 18);
            this.lblCurrency.TabIndex = 37;
            this.lblCurrency.Text = "Currency";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(272, 21);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(56, 17);
            this.lblLocation.TabIndex = 35;
            this.lblLocation.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "(dd/mm/yyyy)";
            // 
            // lblCancelDate
            // 
            this.lblCancelDate.Location = new System.Drawing.Point(17, 112);
            this.lblCancelDate.Name = "lblCancelDate";
            this.lblCancelDate.Size = new System.Drawing.Size(92, 20);
            this.lblCancelDate.TabIndex = 32;
            this.lblCancelDate.Text = "Cancellation Date";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Location = new System.Drawing.Point(17, 90);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(89, 16);
            this.lblDeliveryDate.TabIndex = 30;
            this.lblDeliveryDate.Text = "Delivery Date";
            // 
            // txtTypeDetail
            // 
            this.txtTypeDetail.Location = new System.Drawing.Point(373, 131);
            this.txtTypeDetail.Name = "txtTypeDetail";
            this.txtTypeDetail.Size = new System.Drawing.Size(97, 20);
            this.txtTypeDetail.TabIndex = 4;
            // 
            // lblTypeDetail
            // 
            this.lblTypeDetail.Location = new System.Drawing.Point(272, 135);
            this.lblTypeDetail.Name = "lblTypeDetail";
            this.lblTypeDetail.Size = new System.Drawing.Size(70, 23);
            this.lblTypeDetail.TabIndex = 26;
            this.lblTypeDetail.TabStop = false;
            this.lblTypeDetail.Text = "Type Detail";
            // 
            // txtNetCost
            // 
            this.txtNetCost.BackColor = System.Drawing.Color.LightYellow;
            this.txtNetCost.Location = new System.Drawing.Point(597, 178);
            this.txtNetCost.Name = "txtNetCost";
            this.txtNetCost.ReadOnly = true;
            this.txtNetCost.Size = new System.Drawing.Size(92, 20);
            this.txtNetCost.TabIndex = 20;
            this.txtNetCost.TabStop = false;
            this.txtNetCost.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdate.Location = new System.Drawing.Point(597, 225);
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(92, 20);
            this.txtLastUpdate.TabIndex = 19;
            this.txtLastUpdate.TabStop = false;
            this.txtLastUpdate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtPaymentRemark
            // 
            this.txtPaymentRemark.Location = new System.Drawing.Point(123, 226);
            this.txtPaymentRemark.Name = "txtPaymentRemark";
            this.txtPaymentRemark.Size = new System.Drawing.Size(132, 20);
            this.txtPaymentRemark.TabIndex = 6;
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(123, 41);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(132, 21);
            this.cboOperatorCode.TabIndex = 2;
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboSupplierCode.DropDownWidth = 215;
            this.cboSupplierCode.Location = new System.Drawing.Point(123, 18);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.Size = new System.Drawing.Size(132, 21);
            this.cboSupplierCode.TabIndex = 0;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(499, 228);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(82, 23);
            this.lblLastUpdate.TabIndex = 8;
            this.lblLastUpdate.TabStop = false;
            this.lblLastUpdate.Text = "Last Update";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(499, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 18);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TabStop = false;
            this.lblStatus.Text = "Status";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Location = new System.Drawing.Point(17, 67);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(100, 23);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.TabStop = false;
            this.lblOrderDate.Text = "Order Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Location = new System.Drawing.Point(17, 44);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 18);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.TabStop = false;
            this.lblOperatorCode.Text = "Operator Code";
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.groupBox2);
            this.tpOther.Controls.Add(this.groupBox1);
            this.tpOther.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpOther.Location = new System.Drawing.Point(4, 22);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(772, 379);
            this.tpOther.TabIndex = 0;
            this.tpOther.Text = "Other";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPoRemark3);
            this.groupBox2.Controls.Add(this.btnCopy);
            this.groupBox2.Controls.Add(this.cboPoRemark3);
            this.groupBox2.Controls.Add(this.lblPoRemark3);
            this.groupBox2.Controls.Add(this.txtPoRemark2);
            this.groupBox2.Controls.Add(this.lblPoRemark2);
            this.groupBox2.Controls.Add(this.lblPoRemark1);
            this.groupBox2.Controls.Add(this.txtPoRemark1);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(9, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 191);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.Text = "Other Information";
            // 
            // txtPoRemark3
            // 
            this.txtPoRemark3.Location = new System.Drawing.Point(100, 72);
            this.txtPoRemark3.Multiline = true;
            this.txtPoRemark3.Name = "txtPoRemark3";
            this.txtPoRemark3.Size = new System.Drawing.Size(516, 113);
            this.txtPoRemark3.TabIndex = 1;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(329, 45);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(287, 21);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy to the end of Remark(s) -- Po Remark3";
            // 
            // cboPoRemark3
            // 
            this.cboPoRemark3.DropDownWidth = 221;
            this.cboPoRemark3.Location = new System.Drawing.Point(100, 45);
            this.cboPoRemark3.Name = "cboPoRemark3";
            this.cboPoRemark3.Size = new System.Drawing.Size(221, 21);
            this.cboPoRemark3.TabIndex = 2;
            // 
            // lblPoRemark3
            // 
            this.lblPoRemark3.AutoSize = true;
            this.lblPoRemark3.Location = new System.Drawing.Point(6, 48);
            this.lblPoRemark3.Name = "lblPoRemark3";
            this.lblPoRemark3.Size = new System.Drawing.Size(64, 13);
            this.lblPoRemark3.TabIndex = 0;
            this.lblPoRemark3.Text = "Po Remark3";
            // 
            // txtPoRemark2
            // 
            this.txtPoRemark2.Location = new System.Drawing.Point(395, 19);
            this.txtPoRemark2.Name = "txtPoRemark2";
            this.txtPoRemark2.Size = new System.Drawing.Size(221, 20);
            this.txtPoRemark2.TabIndex = 1;
            // 
            // lblPoRemark2
            // 
            this.lblPoRemark2.AutoSize = true;
            this.lblPoRemark2.Location = new System.Drawing.Point(325, 22);
            this.lblPoRemark2.Name = "lblPoRemark2";
            this.lblPoRemark2.Size = new System.Drawing.Size(64, 13);
            this.lblPoRemark2.TabIndex = 0;
            this.lblPoRemark2.Text = "Po Remark2";
            // 
            // lblPoRemark1
            // 
            this.lblPoRemark1.AutoSize = true;
            this.lblPoRemark1.Location = new System.Drawing.Point(6, 22);
            this.lblPoRemark1.Name = "lblPoRemark1";
            this.lblPoRemark1.Size = new System.Drawing.Size(64, 13);
            this.lblPoRemark1.TabIndex = 0;
            this.lblPoRemark1.Text = "Po Remark1";
            // 
            // txtPoRemark1
            // 
            this.txtPoRemark1.Location = new System.Drawing.Point(100, 19);
            this.txtPoRemark1.Name = "txtPoRemark1";
            this.txtPoRemark1.Size = new System.Drawing.Size(221, 20);
            this.txtPoRemark1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblContactTel);
            this.groupBox1.Controls.Add(this.lblContactPerson);
            this.groupBox1.Controls.Add(this.txtContactTel);
            this.groupBox1.Controls.Add(this.txtContactPerson);
            this.groupBox1.Controls.Add(this.txtDeliveryAddress);
            this.groupBox1.Controls.Add(this.lblDeliveryAddress);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Delivery Information";
            // 
            // lblContactTel
            // 
            this.lblContactTel.AutoSize = true;
            this.lblContactTel.Location = new System.Drawing.Point(6, 141);
            this.lblContactTel.Name = "lblContactTel";
            this.lblContactTel.Size = new System.Drawing.Size(66, 13);
            this.lblContactTel.TabIndex = 0;
            this.lblContactTel.Text = "Contact Tel.";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Location = new System.Drawing.Point(6, 115);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(81, 13);
            this.lblContactPerson.TabIndex = 0;
            this.lblContactPerson.Text = "Contact Person";
            // 
            // txtContactTel
            // 
            this.txtContactTel.Location = new System.Drawing.Point(100, 138);
            this.txtContactTel.Name = "txtContactTel";
            this.txtContactTel.Size = new System.Drawing.Size(465, 20);
            this.txtContactTel.TabIndex = 1;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(100, 112);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(465, 20);
            this.txtContactPerson.TabIndex = 1;
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Location = new System.Drawing.Point(100, 19);
            this.txtDeliveryAddress.Multiline = true;
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(465, 87);
            this.txtDeliveryAddress.TabIndex = 1;
            // 
            // lblDeliveryAddress
            // 
            this.lblDeliveryAddress.AutoSize = true;
            this.lblDeliveryAddress.Location = new System.Drawing.Point(6, 22);
            this.lblDeliveryAddress.Name = "lblDeliveryAddress";
            this.lblDeliveryAddress.Size = new System.Drawing.Size(88, 13);
            this.lblDeliveryAddress.TabIndex = 0;
            this.lblDeliveryAddress.Text = "Delivery Address";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.AutoSize = true;
            this.lblTxNumber.Location = new System.Drawing.Point(169, 47);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(102, 13);
            this.lblTxNumber.TabIndex = 10;
            this.lblTxNumber.TabStop = false;
            this.lblTxNumber.Text = "Purchase Order No.";
            this.lblTxNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(383, 47);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.TabStop = false;
            this.lblTotalAmount.Text = "Order Amount";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPurchaseOrderNo
            // 
            this.txtPurchaseOrderNo.BackColor = System.Drawing.Color.LightYellow;
            this.txtPurchaseOrderNo.Location = new System.Drawing.Point(277, 44);
            this.txtPurchaseOrderNo.Name = "txtPurchaseOrderNo";
            this.txtPurchaseOrderNo.ReadOnly = true;
            this.txtPurchaseOrderNo.Size = new System.Drawing.Size(100, 20);
            this.txtPurchaseOrderNo.TabIndex = 11;
            this.txtPurchaseOrderNo.TabStop = false;
            // 
            // txtOrderAmount
            // 
            this.txtOrderAmount.BackColor = System.Drawing.Color.LightYellow;
            this.txtOrderAmount.ForeColor = System.Drawing.Color.Blue;
            this.txtOrderAmount.Location = new System.Drawing.Point(491, 44);
            this.txtOrderAmount.Name = "txtOrderAmount";
            this.txtOrderAmount.ReadOnly = true;
            this.txtOrderAmount.Size = new System.Drawing.Size(100, 20);
            this.txtOrderAmount.TabIndex = 13;
            this.txtOrderAmount.TabStop = false;
            this.txtOrderAmount.Text = "0.00";
            this.txtOrderAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboType.DropDownWidth = 87;
            this.cboType.Location = new System.Drawing.Point(60, 43);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(87, 21);
            this.cboType.TabIndex = 1;
            // 
            // PurchaseOrder
            // 
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtOrderAmount);
            this.Controls.Add(this.txtPurchaseOrderNo);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.tabGoodsREJ);
            this.Controls.Add(this.lblTxType);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(798, 500);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order > Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtTotalQty;
        private Gizmox.WebGUI.Forms.TextBox txtCoeffcient;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TextBox txtPaymentTerm;
        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.TabPage tpDetail;
        private Gizmox.WebGUI.Forms.TextBox txtDisc;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colPLU;
        private Gizmox.WebGUI.Forms.ColumnHeader colSeason;
        private Gizmox.WebGUI.Forms.ColumnHeader colColor;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colOrderQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colUnitCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colDiscount;
        private Gizmox.WebGUI.Forms.ColumnHeader colSubTotal;
        private Gizmox.WebGUI.Forms.Label lblLineCount;
        private Gizmox.WebGUI.Forms.Label lblNumberOfLine;
        private Gizmox.WebGUI.Forms.TextBox txtUnitCost;
        private Gizmox.WebGUI.Forms.Label lblUnitAmount;
        private Gizmox.WebGUI.Forms.Label lblUnitCost;
        private Gizmox.WebGUI.Forms.TextBox txtQty;
        private Gizmox.WebGUI.Forms.Label lblQty;
        private Gizmox.WebGUI.Forms.TextBox txtDescription;
        private Gizmox.WebGUI.Forms.Label lblDescription;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private RT2020.Controls.ProductSearcher.Basic basicProduct;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblCoeffcient;
        private Gizmox.WebGUI.Forms.ComboBox cboPaymentMethod;
        private Gizmox.WebGUI.Forms.Label lblPaymentMethod;
        private Gizmox.WebGUI.Forms.ComboBox cboStatus;
        private Gizmox.WebGUI.Forms.Label lblSupplierCode;
        private Gizmox.WebGUI.Forms.Label lblPaymentRemark;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpOrderDate;
        private Gizmox.WebGUI.Forms.Label lblPaymentTerm;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.TabControl tabGoodsREJ;
        private Gizmox.WebGUI.Forms.TabPage tpMain;
        private Gizmox.WebGUI.Forms.TextBox txtTypeDetail;
        private Gizmox.WebGUI.Forms.Label lblTypeDetail;
        private Gizmox.WebGUI.Forms.TextBox txtNetCost;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdate;
        private Gizmox.WebGUI.Forms.TextBox txtPaymentRemark;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboSupplierCode;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblOrderDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTotalAmount;
        private Gizmox.WebGUI.Forms.TextBox txtPurchaseOrderNo;
        private Gizmox.WebGUI.Forms.TextBox txtOrderAmount;
        private Gizmox.WebGUI.Forms.TabPage tpOther;
        private Gizmox.WebGUI.Forms.ComboBox cboType;
        private Gizmox.WebGUI.Forms.Label lblDeliveryDate;
        private Gizmox.WebGUI.Forms.Label lblCancelDate;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblLocation;
        private Gizmox.WebGUI.Forms.Label lblGroupDiscount3;
        private Gizmox.WebGUI.Forms.Label lblGroupDiscount2;
        private Gizmox.WebGUI.Forms.Label lblGroupDiscount1;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.ComboBox cboLocation;
        private Gizmox.WebGUI.Forms.Label lblInsuranceCharge;
        private Gizmox.WebGUI.Forms.Label lblHandlingCharge;
        private Gizmox.WebGUI.Forms.Label lblFreightCharge;
        private Gizmox.WebGUI.Forms.Label lblXRate;
        private Gizmox.WebGUI.Forms.Label lblOtherCharge;
        private Gizmox.WebGUI.Forms.TextBox txtOtherCharge;
        private Gizmox.WebGUI.Forms.Label label8;
        private Gizmox.WebGUI.Forms.TextBox txtFreightCharge;
        private Gizmox.WebGUI.Forms.TextBox txtHandlingCharge;
        private Gizmox.WebGUI.Forms.TextBox txtInsuranceCharge;
        private Gizmox.WebGUI.Forms.Label label7;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.TextBox txtGroupDiscount3;
        private Gizmox.WebGUI.Forms.TextBox txtGroupDiscount2;
        private Gizmox.WebGUI.Forms.TextBox txtGroupDiscount1;
        private Gizmox.WebGUI.Forms.TextBox txtXRate;
        private Gizmox.WebGUI.Forms.ComboBox cboShipmentMethod;
        private Gizmox.WebGUI.Forms.Label lblShipmentMethod;
        private Gizmox.WebGUI.Forms.Label lblPartialShipment;
        private Gizmox.WebGUI.Forms.ComboBox cboPartialShipment;
        private Gizmox.WebGUI.Forms.Label label9;
        private Gizmox.WebGUI.Forms.Label lblDeposit;
        private Gizmox.WebGUI.Forms.Label label10;
        private Gizmox.WebGUI.Forms.TextBox txtDeposit;
        private Gizmox.WebGUI.Forms.Label lblShipmentRemark;
        private Gizmox.WebGUI.Forms.TextBox txtShipmentRemark;
        private Gizmox.WebGUI.Forms.Label lblLastUser;
        private Gizmox.WebGUI.Forms.TextBox txtLastUser;
        private Gizmox.WebGUI.Forms.Label lblNetCost;
        private Gizmox.WebGUI.Forms.Label label11;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.ColumnHeader colSize;
        private Gizmox.WebGUI.Forms.ColumnHeader colRemark;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.Label lblPoRemark1;
        private Gizmox.WebGUI.Forms.TextBox txtPoRemark1;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblContactTel;
        private Gizmox.WebGUI.Forms.Label lblContactPerson;
        private Gizmox.WebGUI.Forms.TextBox txtContactTel;
        private Gizmox.WebGUI.Forms.TextBox txtContactPerson;
        private Gizmox.WebGUI.Forms.TextBox txtDeliveryAddress;
        private Gizmox.WebGUI.Forms.Label lblDeliveryAddress;
        private Gizmox.WebGUI.Forms.Button btnCopy;
        private Gizmox.WebGUI.Forms.ComboBox cboPoRemark3;
        private Gizmox.WebGUI.Forms.Label lblPoRemark3;
        private Gizmox.WebGUI.Forms.TextBox txtPoRemark2;
        private Gizmox.WebGUI.Forms.Label lblPoRemark2;
        private Gizmox.WebGUI.Forms.Button btnEditItem;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.Button btnAddItem;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpCancelDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpDeliveryDate;
        private Gizmox.WebGUI.Forms.TextBox txtPoRemark3;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colPruductId;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailId;



    }
}