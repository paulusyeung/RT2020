namespace RT2020.Inventory.Olap
{
    partial class OlapViewForm
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle11 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle12 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.normalQoH_ATS = new Gizmox.WebGUI.Forms.Panel();
            this.chkSkipZeroQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowRemarks = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowRetailAmount = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowOSTOnLoanQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowATSQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowPOQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.dtpToDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFromDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtToStkCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromStkCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblToDate = new Gizmox.WebGUI.Forms.Label();
            this.lblToStkCode = new Gizmox.WebGUI.Forms.Label();
            this.lblFromDate = new Gizmox.WebGUI.Forms.Label();
            this.lblFromStockCode = new Gizmox.WebGUI.Forms.Label();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.headerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.btnShow = new Gizmox.WebGUI.Forms.Button();
            this.stockReorder = new Gizmox.WebGUI.Forms.Panel();
            this.chkShowBFQty_Reorder = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowCDQty_Reorder = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowPOQty_Reorder = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowATSQty_Reorder = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblFromStkCode_Reorder = new Gizmox.WebGUI.Forms.Label();
            this.lblFromData_Reorder = new Gizmox.WebGUI.Forms.Label();
            this.lblToStkCode_Reorder = new Gizmox.WebGUI.Forms.Label();
            this.lblToDate_Reorder = new Gizmox.WebGUI.Forms.Label();
            this.txtFromStkCode_Reorder = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToStkCode_Reorder = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFromDate_Reorder = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToDate_Reorder = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.stockInOutHistory = new Gizmox.WebGUI.Forms.Panel();
            this.dtpToDate_IOHistory = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFromDate_IOHistory = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblToDate_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.lblFromDate_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.txtToWorkplace_IOHistory = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromWorkplace_IOHistory = new Gizmox.WebGUI.Forms.TextBox();
            this.lblToWorkplace_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.lblFromWorkplace_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.txtToStkCode_IOHistory = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromStkCode_IOHistory = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromStkCode_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.lblToStkCode_IOHistory = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.openingClosingInvt = new Gizmox.WebGUI.Forms.Panel();
            this.lblToStkCode_OCInventory = new Gizmox.WebGUI.Forms.Label();
            this.lblFromStkCode_OCInventory = new Gizmox.WebGUI.Forms.Label();
            this.txtFromStkCode_OCInventory = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToStkCode_OCInventory = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromMonth_OCInventory = new Gizmox.WebGUI.Forms.Label();
            this.lblToMonth_OCInventory = new Gizmox.WebGUI.Forms.Label();
            this.txtFromMonth_OCInventory = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToMonth_OCInventory = new Gizmox.WebGUI.Forms.TextBox();
            this.discrepancyAudit = new Gizmox.WebGUI.Forms.Panel();
            this.chkShowDiff_DiscrepancyAudit = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblToStkCode_DiscrepancyAudit = new Gizmox.WebGUI.Forms.Label();
            this.lblFromStkCode_DiscrepancyAudit = new Gizmox.WebGUI.Forms.Label();
            this.txtFromStkCode_DiscrepancyAudit = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToStkCode_DiscrepancyAudit = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMonth_DiscrepancyAudit = new Gizmox.WebGUI.Forms.Label();
            this.txtMonth_DiscrepancyAudit = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromDate_DiscrepancyAudit = new Gizmox.WebGUI.Forms.Label();
            this.lblToDate_DiscrepancyAudit = new Gizmox.WebGUI.Forms.Label();
            this.dtpFromDate_DiscrepancyAudit = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToDate_DiscrepancyAudit = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.stockTransfer = new Gizmox.WebGUI.Forms.Panel();
            this.gbRecordType_Transfer = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkUnPostRecord_Transfer = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkPostedRecords_Transfer = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbConfirmationStatus_Transfer = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkUnprocessed_Transfer = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkInCompleted_Transfer = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCompleted_Transfer = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblFromDate_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.lblToDate_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.dtpFromDate_Transfer = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToDate_Transfer = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtToTxNumber_Transfer = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromTxNumber_Transfer = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromTxNumber_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.lblToTxNumber_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.txtToStkCode_Transfer = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromStkCode_Transfer = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromStkCode_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.lblToStkCode_Transfer = new Gizmox.WebGUI.Forms.Label();
            this.capSummary = new Gizmox.WebGUI.Forms.Panel();
            this.btnFindToTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.Button();
            this.btnFindFromTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkUnPostRecord_CAPSummary = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkPostedRecord_CAPSummary = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkShowRemarks_CAPSummary = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblToWorkplace_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.lblFromWorkplace_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.txtFromWorkplace_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToWorkplace_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToSupplierNumber_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFromSupplierNumber_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFromSupplierNumber_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplierNumber_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.lblToTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.lblFromTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.txtFromTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.txtToTxNumber_CAPSummary = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpToDate_CAPSummary = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFromDate_CAPSummary = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblToDate_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.lblFromDate_CAPSummary = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // normalQoH_ATS
            // 
            this.normalQoH_ATS.Controls.Add(this.chkSkipZeroQty);
            this.normalQoH_ATS.Controls.Add(this.chkShowRemarks);
            this.normalQoH_ATS.Controls.Add(this.chkShowRetailAmount);
            this.normalQoH_ATS.Controls.Add(this.chkShowOSTOnLoanQty);
            this.normalQoH_ATS.Controls.Add(this.chkShowATSQty);
            this.normalQoH_ATS.Controls.Add(this.chkShowPOQty);
            this.normalQoH_ATS.Controls.Add(this.dtpToDate);
            this.normalQoH_ATS.Controls.Add(this.dtpFromDate);
            this.normalQoH_ATS.Controls.Add(this.txtToStkCode);
            this.normalQoH_ATS.Controls.Add(this.txtFromStkCode);
            this.normalQoH_ATS.Controls.Add(this.lblToDate);
            this.normalQoH_ATS.Controls.Add(this.lblToStkCode);
            this.normalQoH_ATS.Controls.Add(this.lblFromDate);
            this.normalQoH_ATS.Controls.Add(this.lblFromStockCode);
            this.normalQoH_ATS.Location = new System.Drawing.Point(234, 39);
            this.normalQoH_ATS.Name = "normalQoH_ATS";
            this.normalQoH_ATS.Size = new System.Drawing.Size(766, 96);
            this.normalQoH_ATS.TabIndex = 0;
            this.normalQoH_ATS.Visible = false;
            // 
            // chkSkipZeroQty
            // 
            this.chkSkipZeroQty.Checked = false;
            this.chkSkipZeroQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSkipZeroQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSkipZeroQty.Location = new System.Drawing.Point(440, 69);
            this.chkSkipZeroQty.Name = "chkSkipZeroQty";
            this.chkSkipZeroQty.Size = new System.Drawing.Size(283, 24);
            this.chkSkipZeroQty.TabIndex = 12;
            this.chkSkipZeroQty.Text = "Skip ZERO Qty (C/D Qty, B/F Qty, ATS Qty, PO Qty)";
            this.chkSkipZeroQty.ThreeState = false;
            // 
            // chkShowRemarks
            // 
            this.chkShowRemarks.Checked = false;
            this.chkShowRemarks.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowRemarks.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowRemarks.Location = new System.Drawing.Point(222, 69);
            this.chkShowRemarks.Name = "chkShowRemarks";
            this.chkShowRemarks.Size = new System.Drawing.Size(152, 24);
            this.chkShowRemarks.TabIndex = 11;
            this.chkShowRemarks.Text = "Show Remark1 - Remark6";
            this.chkShowRemarks.ThreeState = false;
            // 
            // chkShowRetailAmount
            // 
            this.chkShowRetailAmount.Checked = false;
            this.chkShowRetailAmount.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowRetailAmount.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowRetailAmount.Location = new System.Drawing.Point(24, 69);
            this.chkShowRetailAmount.Name = "chkShowRetailAmount";
            this.chkShowRetailAmount.Size = new System.Drawing.Size(126, 24);
            this.chkShowRetailAmount.TabIndex = 10;
            this.chkShowRetailAmount.Text = "Show Retail Amount";
            this.chkShowRetailAmount.ThreeState = false;
            // 
            // chkShowOSTOnLoanQty
            // 
            this.chkShowOSTOnLoanQty.Checked = false;
            this.chkShowOSTOnLoanQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowOSTOnLoanQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowOSTOnLoanQty.Location = new System.Drawing.Point(440, 39);
            this.chkShowOSTOnLoanQty.Name = "chkShowOSTOnLoanQty";
            this.chkShowOSTOnLoanQty.Size = new System.Drawing.Size(202, 24);
            this.chkShowOSTOnLoanQty.TabIndex = 9;
            this.chkShowOSTOnLoanQty.Text = "Show Outstanding OnLoan Quantity";
            this.chkShowOSTOnLoanQty.ThreeState = false;
            // 
            // chkShowATSQty
            // 
            this.chkShowATSQty.Checked = false;
            this.chkShowATSQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowATSQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowATSQty.Location = new System.Drawing.Point(222, 39);
            this.chkShowATSQty.Name = "chkShowATSQty";
            this.chkShowATSQty.Size = new System.Drawing.Size(190, 24);
            this.chkShowATSQty.TabIndex = 8;
            this.chkShowATSQty.Text = "Show Available-To-Sales Quantity";
            this.chkShowATSQty.ThreeState = false;
            // 
            // chkShowPOQty
            // 
            this.chkShowPOQty.Checked = false;
            this.chkShowPOQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowPOQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowPOQty.Location = new System.Drawing.Point(24, 39);
            this.chkShowPOQty.Name = "chkShowPOQty";
            this.chkShowPOQty.Size = new System.Drawing.Size(169, 24);
            this.chkShowPOQty.TabIndex = 7;
            this.chkShowPOQty.Text = "Show PO Quantity and Cost";
            this.chkShowPOQty.ThreeState = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(648, 13);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate.TabIndex = 6;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(513, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate.TabIndex = 6;
            // 
            // txtToStkCode
            // 
            this.txtToStkCode.Location = new System.Drawing.Point(288, 13);
            this.txtToStkCode.Name = "txtToStkCode";
            this.txtToStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode.TabIndex = 5;
            // 
            // txtFromStkCode
            // 
            this.txtFromStkCode.Location = new System.Drawing.Point(143, 13);
            this.txtFromStkCode.Name = "txtFromStkCode";
            this.txtFromStkCode.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode.TabIndex = 4;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(619, 16);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(100, 23);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To:";
            // 
            // lblToStkCode
            // 
            this.lblToStkCode.AutoSize = true;
            this.lblToStkCode.Location = new System.Drawing.Point(249, 16);
            this.lblToStkCode.Name = "lblToStkCode";
            this.lblToStkCode.Size = new System.Drawing.Size(100, 23);
            this.lblToStkCode.TabIndex = 2;
            this.lblToStkCode.Text = "To:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(414, 16);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Date          FROM:";
            // 
            // lblFromStockCode
            // 
            this.lblFromStockCode.AutoSize = true;
            this.lblFromStockCode.Location = new System.Drawing.Point(21, 16);
            this.lblFromStockCode.Name = "lblFromStockCode";
            this.lblFromStockCode.Size = new System.Drawing.Size(100, 23);
            this.lblFromStockCode.TabIndex = 0;
            this.lblFromStockCode.Text = "STKCODE          FROM:";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(35, 27);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.Panel1.Controls.Add(this.headerPanel);
            this.splitContainer.Size = new System.Drawing.Size(150, 460);
            this.splitContainer.SplitterDistance = 120;
            this.splitContainer.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.headerPanel.Controls.Add(this.btnShow);
            this.headerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(150, 120);
            this.headerPanel.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(63, 85);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 13;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // stockReorder
            // 
            this.stockReorder.Controls.Add(this.chkShowBFQty_Reorder);
            this.stockReorder.Controls.Add(this.chkShowCDQty_Reorder);
            this.stockReorder.Controls.Add(this.chkShowPOQty_Reorder);
            this.stockReorder.Controls.Add(this.chkShowATSQty_Reorder);
            this.stockReorder.Controls.Add(this.lblFromStkCode_Reorder);
            this.stockReorder.Controls.Add(this.lblFromData_Reorder);
            this.stockReorder.Controls.Add(this.lblToStkCode_Reorder);
            this.stockReorder.Controls.Add(this.lblToDate_Reorder);
            this.stockReorder.Controls.Add(this.txtFromStkCode_Reorder);
            this.stockReorder.Controls.Add(this.txtToStkCode_Reorder);
            this.stockReorder.Controls.Add(this.dtpFromDate_Reorder);
            this.stockReorder.Controls.Add(this.dtpToDate_Reorder);
            this.stockReorder.Location = new System.Drawing.Point(234, 150);
            this.stockReorder.Name = "stockReorder";
            this.stockReorder.Size = new System.Drawing.Size(766, 96);
            this.stockReorder.TabIndex = 2;
            this.stockReorder.Visible = false;
            // 
            // chkShowBFQty_Reorder
            // 
            this.chkShowBFQty_Reorder.Checked = false;
            this.chkShowBFQty_Reorder.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowBFQty_Reorder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowBFQty_Reorder.Location = new System.Drawing.Point(24, 39);
            this.chkShowBFQty_Reorder.Name = "chkShowBFQty_Reorder";
            this.chkShowBFQty_Reorder.Size = new System.Drawing.Size(169, 24);
            this.chkShowBFQty_Reorder.TabIndex = 7;
            this.chkShowBFQty_Reorder.Text = "Show B/F Quantity and Cost";
            this.chkShowBFQty_Reorder.ThreeState = false;
            // 
            // chkShowCDQty_Reorder
            // 
            this.chkShowCDQty_Reorder.Checked = false;
            this.chkShowCDQty_Reorder.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowCDQty_Reorder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowCDQty_Reorder.Location = new System.Drawing.Point(222, 39);
            this.chkShowCDQty_Reorder.Name = "chkShowCDQty_Reorder";
            this.chkShowCDQty_Reorder.Size = new System.Drawing.Size(190, 24);
            this.chkShowCDQty_Reorder.TabIndex = 8;
            this.chkShowCDQty_Reorder.Text = "Show C/D Quantity and Cost";
            this.chkShowCDQty_Reorder.ThreeState = false;
            // 
            // chkShowPOQty_Reorder
            // 
            this.chkShowPOQty_Reorder.Checked = false;
            this.chkShowPOQty_Reorder.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowPOQty_Reorder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowPOQty_Reorder.Location = new System.Drawing.Point(440, 39);
            this.chkShowPOQty_Reorder.Name = "chkShowPOQty_Reorder";
            this.chkShowPOQty_Reorder.Size = new System.Drawing.Size(202, 24);
            this.chkShowPOQty_Reorder.TabIndex = 9;
            this.chkShowPOQty_Reorder.Text = "Show PO Quantity and Cost";
            this.chkShowPOQty_Reorder.ThreeState = false;
            // 
            // chkShowATSQty_Reorder
            // 
            this.chkShowATSQty_Reorder.Checked = true;
            this.chkShowATSQty_Reorder.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.chkShowATSQty_Reorder.Enabled = false;
            this.chkShowATSQty_Reorder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowATSQty_Reorder.Location = new System.Drawing.Point(24, 69);
            this.chkShowATSQty_Reorder.Name = "chkShowATSQty_Reorder";
            this.chkShowATSQty_Reorder.Size = new System.Drawing.Size(190, 24);
            this.chkShowATSQty_Reorder.TabIndex = 10;
            this.chkShowATSQty_Reorder.Text = "Show Available-To-Sales Quantity";
            this.chkShowATSQty_Reorder.ThreeState = false;
            // 
            // lblFromStkCode_Reorder
            // 
            this.lblFromStkCode_Reorder.AutoSize = true;
            this.lblFromStkCode_Reorder.Location = new System.Drawing.Point(21, 16);
            this.lblFromStkCode_Reorder.Name = "lblFromStkCode_Reorder";
            this.lblFromStkCode_Reorder.Size = new System.Drawing.Size(100, 23);
            this.lblFromStkCode_Reorder.TabIndex = 0;
            this.lblFromStkCode_Reorder.Text = "STKCODE          FROM:";
            // 
            // lblFromData_Reorder
            // 
            this.lblFromData_Reorder.AutoSize = true;
            this.lblFromData_Reorder.Location = new System.Drawing.Point(414, 16);
            this.lblFromData_Reorder.Name = "lblFromData_Reorder";
            this.lblFromData_Reorder.Size = new System.Drawing.Size(100, 23);
            this.lblFromData_Reorder.TabIndex = 1;
            this.lblFromData_Reorder.Text = "Date          FROM:";
            // 
            // lblToStkCode_Reorder
            // 
            this.lblToStkCode_Reorder.AutoSize = true;
            this.lblToStkCode_Reorder.Location = new System.Drawing.Point(249, 16);
            this.lblToStkCode_Reorder.Name = "lblToStkCode_Reorder";
            this.lblToStkCode_Reorder.Size = new System.Drawing.Size(100, 23);
            this.lblToStkCode_Reorder.TabIndex = 2;
            this.lblToStkCode_Reorder.Text = "To:";
            // 
            // lblToDate_Reorder
            // 
            this.lblToDate_Reorder.AutoSize = true;
            this.lblToDate_Reorder.Location = new System.Drawing.Point(619, 16);
            this.lblToDate_Reorder.Name = "lblToDate_Reorder";
            this.lblToDate_Reorder.Size = new System.Drawing.Size(100, 23);
            this.lblToDate_Reorder.TabIndex = 3;
            this.lblToDate_Reorder.Text = "To:";
            // 
            // txtFromStkCode_Reorder
            // 
            this.txtFromStkCode_Reorder.Location = new System.Drawing.Point(143, 13);
            this.txtFromStkCode_Reorder.Name = "txtFromStkCode_Reorder";
            this.txtFromStkCode_Reorder.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode_Reorder.TabIndex = 4;
            // 
            // txtToStkCode_Reorder
            // 
            this.txtToStkCode_Reorder.Location = new System.Drawing.Point(288, 13);
            this.txtToStkCode_Reorder.Name = "txtToStkCode_Reorder";
            this.txtToStkCode_Reorder.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode_Reorder.TabIndex = 5;
            // 
            // dtpFromDate_Reorder
            // 
            this.dtpFromDate_Reorder.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate_Reorder.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate_Reorder.Enabled = false;
            this.dtpFromDate_Reorder.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate_Reorder.Location = new System.Drawing.Point(513, 13);
            this.dtpFromDate_Reorder.Name = "dtpFromDate_Reorder";
            this.dtpFromDate_Reorder.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate_Reorder.TabIndex = 6;
            // 
            // dtpToDate_Reorder
            // 
            this.dtpToDate_Reorder.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate_Reorder.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate_Reorder.Enabled = false;
            this.dtpToDate_Reorder.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate_Reorder.Location = new System.Drawing.Point(648, 13);
            this.dtpToDate_Reorder.Name = "dtpToDate_Reorder";
            this.dtpToDate_Reorder.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate_Reorder.TabIndex = 6;
            // 
            // stockInOutHistory
            // 
            this.stockInOutHistory.Controls.Add(this.dtpToDate_IOHistory);
            this.stockInOutHistory.Controls.Add(this.dtpFromDate_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblToDate_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblFromDate_IOHistory);
            this.stockInOutHistory.Controls.Add(this.txtToWorkplace_IOHistory);
            this.stockInOutHistory.Controls.Add(this.txtFromWorkplace_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblToWorkplace_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblFromWorkplace_IOHistory);
            this.stockInOutHistory.Controls.Add(this.txtToStkCode_IOHistory);
            this.stockInOutHistory.Controls.Add(this.txtFromStkCode_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblFromStkCode_IOHistory);
            this.stockInOutHistory.Controls.Add(this.lblToStkCode_IOHistory);
            this.stockInOutHistory.Location = new System.Drawing.Point(234, 252);
            this.stockInOutHistory.Name = "stockInOutHistory";
            this.stockInOutHistory.Size = new System.Drawing.Size(399, 96);
            this.stockInOutHistory.TabIndex = 3;
            this.stockInOutHistory.Visible = false;
            // 
            // dtpToDate_IOHistory
            // 
            this.dtpToDate_IOHistory.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate_IOHistory.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate_IOHistory.Enabled = false;
            this.dtpToDate_IOHistory.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate_IOHistory.Location = new System.Drawing.Point(288, 65);
            this.dtpToDate_IOHistory.Name = "dtpToDate_IOHistory";
            this.dtpToDate_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate_IOHistory.TabIndex = 6;
            // 
            // dtpFromDate_IOHistory
            // 
            this.dtpFromDate_IOHistory.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate_IOHistory.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate_IOHistory.Enabled = false;
            this.dtpFromDate_IOHistory.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate_IOHistory.Location = new System.Drawing.Point(143, 65);
            this.dtpFromDate_IOHistory.Name = "dtpFromDate_IOHistory";
            this.dtpFromDate_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate_IOHistory.TabIndex = 6;
            // 
            // lblToDate_IOHistory
            // 
            this.lblToDate_IOHistory.AutoSize = true;
            this.lblToDate_IOHistory.Location = new System.Drawing.Point(249, 68);
            this.lblToDate_IOHistory.Name = "lblToDate_IOHistory";
            this.lblToDate_IOHistory.Size = new System.Drawing.Size(100, 23);
            this.lblToDate_IOHistory.TabIndex = 3;
            this.lblToDate_IOHistory.Text = "To:";
            // 
            // lblFromDate_IOHistory
            // 
            this.lblFromDate_IOHistory.AutoSize = true;
            this.lblFromDate_IOHistory.Location = new System.Drawing.Point(43, 68);
            this.lblFromDate_IOHistory.Name = "lblFromDate_IOHistory";
            this.lblFromDate_IOHistory.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate_IOHistory.TabIndex = 1;
            this.lblFromDate_IOHistory.Text = "Date          FROM:";
            // 
            // txtToWorkplace_IOHistory
            // 
            this.txtToWorkplace_IOHistory.Location = new System.Drawing.Point(288, 39);
            this.txtToWorkplace_IOHistory.Name = "txtToWorkplace_IOHistory";
            this.txtToWorkplace_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.txtToWorkplace_IOHistory.TabIndex = 9;
            // 
            // txtFromWorkplace_IOHistory
            // 
            this.txtFromWorkplace_IOHistory.Location = new System.Drawing.Point(143, 39);
            this.txtFromWorkplace_IOHistory.Name = "txtFromWorkplace_IOHistory";
            this.txtFromWorkplace_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.txtFromWorkplace_IOHistory.TabIndex = 8;
            // 
            // lblToWorkplace_IOHistory
            // 
            this.lblToWorkplace_IOHistory.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lblToWorkplace_IOHistory.AutoSize = true;
            this.lblToWorkplace_IOHistory.Location = new System.Drawing.Point(249, 42);
            this.lblToWorkplace_IOHistory.Name = "lblToWorkplace_IOHistory";
            this.lblToWorkplace_IOHistory.Size = new System.Drawing.Size(100, 23);
            this.lblToWorkplace_IOHistory.TabIndex = 7;
            this.lblToWorkplace_IOHistory.Text = "To:";
            // 
            // lblFromWorkplace_IOHistory
            // 
            this.lblFromWorkplace_IOHistory.AutoSize = true;
            this.lblFromWorkplace_IOHistory.Location = new System.Drawing.Point(43, 42);
            this.lblFromWorkplace_IOHistory.Name = "lblFromWorkplace_IOHistory";
            this.lblFromWorkplace_IOHistory.Size = new System.Drawing.Size(100, 23);
            this.lblFromWorkplace_IOHistory.TabIndex = 6;
            this.lblFromWorkplace_IOHistory.Text = "Shop          FROM:";
            // 
            // txtToStkCode_IOHistory
            // 
            this.txtToStkCode_IOHistory.Location = new System.Drawing.Point(288, 13);
            this.txtToStkCode_IOHistory.Name = "txtToStkCode_IOHistory";
            this.txtToStkCode_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode_IOHistory.TabIndex = 5;
            // 
            // txtFromStkCode_IOHistory
            // 
            this.txtFromStkCode_IOHistory.Location = new System.Drawing.Point(143, 13);
            this.txtFromStkCode_IOHistory.Name = "txtFromStkCode_IOHistory";
            this.txtFromStkCode_IOHistory.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode_IOHistory.TabIndex = 4;
            // 
            // lblFromStkCode_IOHistory
            // 
            this.lblFromStkCode_IOHistory.AutoSize = true;
            this.lblFromStkCode_IOHistory.Location = new System.Drawing.Point(21, 16);
            this.lblFromStkCode_IOHistory.Name = "lblFromStkCode_IOHistory";
            this.lblFromStkCode_IOHistory.Size = new System.Drawing.Size(116, 13);
            this.lblFromStkCode_IOHistory.TabIndex = 0;
            this.lblFromStkCode_IOHistory.Text = "STKCODE          FROM:";
            // 
            // lblToStkCode_IOHistory
            // 
            this.lblToStkCode_IOHistory.AutoSize = true;
            this.lblToStkCode_IOHistory.Location = new System.Drawing.Point(249, 16);
            this.lblToStkCode_IOHistory.Name = "lblToStkCode_IOHistory";
            this.lblToStkCode_IOHistory.Size = new System.Drawing.Size(23, 13);
            this.lblToStkCode_IOHistory.TabIndex = 2;
            this.lblToStkCode_IOHistory.Text = "To:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // openingClosingInvt
            // 
            this.openingClosingInvt.Controls.Add(this.lblToStkCode_OCInventory);
            this.openingClosingInvt.Controls.Add(this.lblFromStkCode_OCInventory);
            this.openingClosingInvt.Controls.Add(this.txtFromStkCode_OCInventory);
            this.openingClosingInvt.Controls.Add(this.txtToStkCode_OCInventory);
            this.openingClosingInvt.Controls.Add(this.lblFromMonth_OCInventory);
            this.openingClosingInvt.Controls.Add(this.lblToMonth_OCInventory);
            this.openingClosingInvt.Controls.Add(this.txtFromMonth_OCInventory);
            this.openingClosingInvt.Controls.Add(this.txtToMonth_OCInventory);
            this.openingClosingInvt.Location = new System.Drawing.Point(639, 252);
            this.openingClosingInvt.Name = "openingClosingInvt";
            this.openingClosingInvt.Size = new System.Drawing.Size(399, 96);
            this.openingClosingInvt.TabIndex = 4;
            this.openingClosingInvt.Visible = false;
            // 
            // lblToStkCode_OCInventory
            // 
            this.lblToStkCode_OCInventory.AutoSize = true;
            this.lblToStkCode_OCInventory.Location = new System.Drawing.Point(249, 16);
            this.lblToStkCode_OCInventory.Name = "lblToStkCode_OCInventory";
            this.lblToStkCode_OCInventory.Size = new System.Drawing.Size(23, 13);
            this.lblToStkCode_OCInventory.TabIndex = 2;
            this.lblToStkCode_OCInventory.Text = "To:";
            // 
            // lblFromStkCode_OCInventory
            // 
            this.lblFromStkCode_OCInventory.AutoSize = true;
            this.lblFromStkCode_OCInventory.Location = new System.Drawing.Point(21, 16);
            this.lblFromStkCode_OCInventory.Name = "lblFromStkCode_OCInventory";
            this.lblFromStkCode_OCInventory.Size = new System.Drawing.Size(116, 13);
            this.lblFromStkCode_OCInventory.TabIndex = 0;
            this.lblFromStkCode_OCInventory.Text = "STKCODE          FROM:";
            // 
            // txtFromStkCode_OCInventory
            // 
            this.txtFromStkCode_OCInventory.Location = new System.Drawing.Point(143, 13);
            this.txtFromStkCode_OCInventory.Name = "txtFromStkCode_OCInventory";
            this.txtFromStkCode_OCInventory.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode_OCInventory.TabIndex = 4;
            // 
            // txtToStkCode_OCInventory
            // 
            this.txtToStkCode_OCInventory.Location = new System.Drawing.Point(288, 13);
            this.txtToStkCode_OCInventory.Name = "txtToStkCode_OCInventory";
            this.txtToStkCode_OCInventory.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode_OCInventory.TabIndex = 5;
            // 
            // lblFromMonth_OCInventory
            // 
            this.lblFromMonth_OCInventory.AutoSize = true;
            this.lblFromMonth_OCInventory.Location = new System.Drawing.Point(37, 42);
            this.lblFromMonth_OCInventory.Name = "lblFromMonth_OCInventory";
            this.lblFromMonth_OCInventory.Size = new System.Drawing.Size(100, 23);
            this.lblFromMonth_OCInventory.TabIndex = 6;
            this.lblFromMonth_OCInventory.Text = "Month          FROM:";
            // 
            // lblToMonth_OCInventory
            // 
            this.lblToMonth_OCInventory.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lblToMonth_OCInventory.AutoSize = true;
            this.lblToMonth_OCInventory.Location = new System.Drawing.Point(249, 42);
            this.lblToMonth_OCInventory.Name = "lblToMonth_OCInventory";
            this.lblToMonth_OCInventory.Size = new System.Drawing.Size(100, 23);
            this.lblToMonth_OCInventory.TabIndex = 7;
            this.lblToMonth_OCInventory.Text = "To:";
            // 
            // txtFromMonth_OCInventory
            // 
            this.txtFromMonth_OCInventory.Location = new System.Drawing.Point(143, 39);
            this.txtFromMonth_OCInventory.Name = "txtFromMonth_OCInventory";
            this.txtFromMonth_OCInventory.Size = new System.Drawing.Size(100, 20);
            this.txtFromMonth_OCInventory.TabIndex = 8;
            // 
            // txtToMonth_OCInventory
            // 
            this.txtToMonth_OCInventory.Location = new System.Drawing.Point(288, 39);
            this.txtToMonth_OCInventory.Name = "txtToMonth_OCInventory";
            this.txtToMonth_OCInventory.Size = new System.Drawing.Size(100, 20);
            this.txtToMonth_OCInventory.TabIndex = 9;
            // 
            // discrepancyAudit
            // 
            this.discrepancyAudit.Controls.Add(this.chkShowDiff_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.lblToStkCode_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.lblFromStkCode_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.txtFromStkCode_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.txtToStkCode_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.lblMonth_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.txtMonth_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.lblFromDate_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.lblToDate_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.dtpFromDate_DiscrepancyAudit);
            this.discrepancyAudit.Controls.Add(this.dtpToDate_DiscrepancyAudit);
            this.discrepancyAudit.Location = new System.Drawing.Point(234, 354);
            this.discrepancyAudit.Name = "discrepancyAudit";
            this.discrepancyAudit.Size = new System.Drawing.Size(766, 96);
            this.discrepancyAudit.TabIndex = 5;
            this.discrepancyAudit.Visible = false;
            // 
            // chkShowDiff_DiscrepancyAudit
            // 
            this.chkShowDiff_DiscrepancyAudit.Checked = false;
            this.chkShowDiff_DiscrepancyAudit.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowDiff_DiscrepancyAudit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowDiff_DiscrepancyAudit.Location = new System.Drawing.Point(405, 63);
            this.chkShowDiff_DiscrepancyAudit.Name = "chkShowDiff_DiscrepancyAudit";
            this.chkShowDiff_DiscrepancyAudit.Size = new System.Drawing.Size(237, 24);
            this.chkShowDiff_DiscrepancyAudit.TabIndex = 9;
            this.chkShowDiff_DiscrepancyAudit.Text = "Show Diff$ <> 0 ONLY";
            this.chkShowDiff_DiscrepancyAudit.ThreeState = false;
            // 
            // lblToStkCode_DiscrepancyAudit
            // 
            this.lblToStkCode_DiscrepancyAudit.AutoSize = true;
            this.lblToStkCode_DiscrepancyAudit.Location = new System.Drawing.Point(249, 16);
            this.lblToStkCode_DiscrepancyAudit.Name = "lblToStkCode_DiscrepancyAudit";
            this.lblToStkCode_DiscrepancyAudit.Size = new System.Drawing.Size(23, 13);
            this.lblToStkCode_DiscrepancyAudit.TabIndex = 2;
            this.lblToStkCode_DiscrepancyAudit.Text = "To:";
            // 
            // lblFromStkCode_DiscrepancyAudit
            // 
            this.lblFromStkCode_DiscrepancyAudit.AutoSize = true;
            this.lblFromStkCode_DiscrepancyAudit.Location = new System.Drawing.Point(21, 16);
            this.lblFromStkCode_DiscrepancyAudit.Name = "lblFromStkCode_DiscrepancyAudit";
            this.lblFromStkCode_DiscrepancyAudit.Size = new System.Drawing.Size(116, 13);
            this.lblFromStkCode_DiscrepancyAudit.TabIndex = 0;
            this.lblFromStkCode_DiscrepancyAudit.Text = "STKCODE          FROM:";
            // 
            // txtFromStkCode_DiscrepancyAudit
            // 
            this.txtFromStkCode_DiscrepancyAudit.Location = new System.Drawing.Point(143, 13);
            this.txtFromStkCode_DiscrepancyAudit.Name = "txtFromStkCode_DiscrepancyAudit";
            this.txtFromStkCode_DiscrepancyAudit.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode_DiscrepancyAudit.TabIndex = 4;
            // 
            // txtToStkCode_DiscrepancyAudit
            // 
            this.txtToStkCode_DiscrepancyAudit.Location = new System.Drawing.Point(288, 13);
            this.txtToStkCode_DiscrepancyAudit.Name = "txtToStkCode_DiscrepancyAudit";
            this.txtToStkCode_DiscrepancyAudit.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode_DiscrepancyAudit.TabIndex = 5;
            // 
            // lblMonth_DiscrepancyAudit
            // 
            this.lblMonth_DiscrepancyAudit.AutoSize = true;
            this.lblMonth_DiscrepancyAudit.Location = new System.Drawing.Point(49, 42);
            this.lblMonth_DiscrepancyAudit.Name = "lblMonth_DiscrepancyAudit";
            this.lblMonth_DiscrepancyAudit.Size = new System.Drawing.Size(100, 23);
            this.lblMonth_DiscrepancyAudit.TabIndex = 6;
            this.lblMonth_DiscrepancyAudit.Text = "For          Month:";
            // 
            // txtMonth_DiscrepancyAudit
            // 
            this.txtMonth_DiscrepancyAudit.Location = new System.Drawing.Point(143, 39);
            this.txtMonth_DiscrepancyAudit.Name = "txtMonth_DiscrepancyAudit";
            this.txtMonth_DiscrepancyAudit.Size = new System.Drawing.Size(100, 20);
            this.txtMonth_DiscrepancyAudit.TabIndex = 8;
            this.txtMonth_DiscrepancyAudit.TextChanged += new System.EventHandler(this.txtMonth_DiscrepancyAudit_TextChanged);
            // 
            // lblFromDate_DiscrepancyAudit
            // 
            this.lblFromDate_DiscrepancyAudit.AutoSize = true;
            this.lblFromDate_DiscrepancyAudit.Location = new System.Drawing.Point(43, 68);
            this.lblFromDate_DiscrepancyAudit.Name = "lblFromDate_DiscrepancyAudit";
            this.lblFromDate_DiscrepancyAudit.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate_DiscrepancyAudit.TabIndex = 1;
            this.lblFromDate_DiscrepancyAudit.Text = "Date          FROM:";
            // 
            // lblToDate_DiscrepancyAudit
            // 
            this.lblToDate_DiscrepancyAudit.AutoSize = true;
            this.lblToDate_DiscrepancyAudit.Location = new System.Drawing.Point(249, 68);
            this.lblToDate_DiscrepancyAudit.Name = "lblToDate_DiscrepancyAudit";
            this.lblToDate_DiscrepancyAudit.Size = new System.Drawing.Size(100, 23);
            this.lblToDate_DiscrepancyAudit.TabIndex = 3;
            this.lblToDate_DiscrepancyAudit.Text = "To:";
            // 
            // dtpFromDate_DiscrepancyAudit
            // 
            this.dtpFromDate_DiscrepancyAudit.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate_DiscrepancyAudit.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate_DiscrepancyAudit.Enabled = false;
            this.dtpFromDate_DiscrepancyAudit.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate_DiscrepancyAudit.Location = new System.Drawing.Point(143, 65);
            this.dtpFromDate_DiscrepancyAudit.Name = "dtpFromDate_DiscrepancyAudit";
            this.dtpFromDate_DiscrepancyAudit.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate_DiscrepancyAudit.TabIndex = 6;
            // 
            // dtpToDate_DiscrepancyAudit
            // 
            this.dtpToDate_DiscrepancyAudit.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate_DiscrepancyAudit.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate_DiscrepancyAudit.Enabled = false;
            this.dtpToDate_DiscrepancyAudit.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate_DiscrepancyAudit.Location = new System.Drawing.Point(288, 65);
            this.dtpToDate_DiscrepancyAudit.Name = "dtpToDate_DiscrepancyAudit";
            this.dtpToDate_DiscrepancyAudit.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate_DiscrepancyAudit.TabIndex = 6;
            // 
            // stockTransfer
            // 
            this.stockTransfer.Controls.Add(this.gbRecordType_Transfer);
            this.stockTransfer.Controls.Add(this.gbConfirmationStatus_Transfer);
            this.stockTransfer.Controls.Add(this.lblFromDate_Transfer);
            this.stockTransfer.Controls.Add(this.lblToDate_Transfer);
            this.stockTransfer.Controls.Add(this.dtpFromDate_Transfer);
            this.stockTransfer.Controls.Add(this.dtpToDate_Transfer);
            this.stockTransfer.Controls.Add(this.txtToTxNumber_Transfer);
            this.stockTransfer.Controls.Add(this.txtFromTxNumber_Transfer);
            this.stockTransfer.Controls.Add(this.lblFromTxNumber_Transfer);
            this.stockTransfer.Controls.Add(this.lblToTxNumber_Transfer);
            this.stockTransfer.Controls.Add(this.txtToStkCode_Transfer);
            this.stockTransfer.Controls.Add(this.txtFromStkCode_Transfer);
            this.stockTransfer.Controls.Add(this.lblFromStkCode_Transfer);
            this.stockTransfer.Controls.Add(this.lblToStkCode_Transfer);
            this.stockTransfer.Location = new System.Drawing.Point(234, 456);
            this.stockTransfer.Name = "stockTransfer";
            this.stockTransfer.Size = new System.Drawing.Size(766, 96);
            this.stockTransfer.TabIndex = 6;
            this.stockTransfer.Visible = false;
            // 
            // gbRecordType_Transfer
            // 
            this.gbRecordType_Transfer.Controls.Add(this.chkUnPostRecord_Transfer);
            this.gbRecordType_Transfer.Controls.Add(this.chkPostedRecords_Transfer);
            this.gbRecordType_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbRecordType_Transfer.Location = new System.Drawing.Point(557, 3);
            this.gbRecordType_Transfer.Name = "gbRecordType_Transfer";
            this.gbRecordType_Transfer.Size = new System.Drawing.Size(134, 90);
            this.gbRecordType_Transfer.TabIndex = 8;
            this.gbRecordType_Transfer.Text = "Record Type";
            // 
            // chkUnPostRecord_Transfer
            // 
            this.chkUnPostRecord_Transfer.Checked = false;
            this.chkUnPostRecord_Transfer.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnPostRecord_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnPostRecord_Transfer.Location = new System.Drawing.Point(16, 40);
            this.chkUnPostRecord_Transfer.Name = "chkUnPostRecord_Transfer";
            this.chkUnPostRecord_Transfer.Size = new System.Drawing.Size(104, 24);
            this.chkUnPostRecord_Transfer.TabIndex = 1;
            this.chkUnPostRecord_Transfer.Text = "Un-Post Record";
            this.chkUnPostRecord_Transfer.ThreeState = false;
            // 
            // chkPostedRecords_Transfer
            // 
            this.chkPostedRecords_Transfer.Checked = true;
            this.chkPostedRecords_Transfer.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.chkPostedRecords_Transfer.Enabled = false;
            this.chkPostedRecords_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPostedRecords_Transfer.Location = new System.Drawing.Point(16, 19);
            this.chkPostedRecords_Transfer.Name = "chkPostedRecords_Transfer";
            this.chkPostedRecords_Transfer.Size = new System.Drawing.Size(104, 24);
            this.chkPostedRecords_Transfer.TabIndex = 0;
            this.chkPostedRecords_Transfer.Text = "Posted Record";
            this.chkPostedRecords_Transfer.ThreeState = false;
            // 
            // gbConfirmationStatus_Transfer
            // 
            this.gbConfirmationStatus_Transfer.Controls.Add(this.chkUnprocessed_Transfer);
            this.gbConfirmationStatus_Transfer.Controls.Add(this.chkInCompleted_Transfer);
            this.gbConfirmationStatus_Transfer.Controls.Add(this.chkCompleted_Transfer);
            this.gbConfirmationStatus_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbConfirmationStatus_Transfer.Location = new System.Drawing.Point(417, 3);
            this.gbConfirmationStatus_Transfer.Name = "gbConfirmationStatus_Transfer";
            this.gbConfirmationStatus_Transfer.Size = new System.Drawing.Size(134, 90);
            this.gbConfirmationStatus_Transfer.TabIndex = 7;
            this.gbConfirmationStatus_Transfer.Text = "Confirmation Status";
            // 
            // chkUnprocessed_Transfer
            // 
            this.chkUnprocessed_Transfer.Checked = false;
            this.chkUnprocessed_Transfer.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnprocessed_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnprocessed_Transfer.Location = new System.Drawing.Point(12, 60);
            this.chkUnprocessed_Transfer.Name = "chkUnprocessed_Transfer";
            this.chkUnprocessed_Transfer.Size = new System.Drawing.Size(104, 24);
            this.chkUnprocessed_Transfer.TabIndex = 2;
            this.chkUnprocessed_Transfer.Text = "Unprocessed";
            this.chkUnprocessed_Transfer.ThreeState = false;
            // 
            // chkInCompleted_Transfer
            // 
            this.chkInCompleted_Transfer.Checked = false;
            this.chkInCompleted_Transfer.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkInCompleted_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkInCompleted_Transfer.Location = new System.Drawing.Point(12, 40);
            this.chkInCompleted_Transfer.Name = "chkInCompleted_Transfer";
            this.chkInCompleted_Transfer.Size = new System.Drawing.Size(104, 24);
            this.chkInCompleted_Transfer.TabIndex = 1;
            this.chkInCompleted_Transfer.Text = "InCompleted";
            this.chkInCompleted_Transfer.ThreeState = false;
            // 
            // chkCompleted_Transfer
            // 
            this.chkCompleted_Transfer.Checked = false;
            this.chkCompleted_Transfer.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCompleted_Transfer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCompleted_Transfer.Location = new System.Drawing.Point(12, 19);
            this.chkCompleted_Transfer.Name = "chkCompleted_Transfer";
            this.chkCompleted_Transfer.Size = new System.Drawing.Size(104, 24);
            this.chkCompleted_Transfer.TabIndex = 0;
            this.chkCompleted_Transfer.Text = "Completed";
            this.chkCompleted_Transfer.ThreeState = false;
            // 
            // lblFromDate_Transfer
            // 
            this.lblFromDate_Transfer.AutoSize = true;
            this.lblFromDate_Transfer.Location = new System.Drawing.Point(42, 68);
            this.lblFromDate_Transfer.Name = "lblFromDate_Transfer";
            this.lblFromDate_Transfer.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate_Transfer.TabIndex = 1;
            this.lblFromDate_Transfer.Text = "Date          FROM:";
            // 
            // lblToDate_Transfer
            // 
            this.lblToDate_Transfer.AutoSize = true;
            this.lblToDate_Transfer.Location = new System.Drawing.Point(248, 68);
            this.lblToDate_Transfer.Name = "lblToDate_Transfer";
            this.lblToDate_Transfer.Size = new System.Drawing.Size(100, 23);
            this.lblToDate_Transfer.TabIndex = 3;
            this.lblToDate_Transfer.Text = "To:";
            // 
            // dtpFromDate_Transfer
            // 
            this.dtpFromDate_Transfer.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate_Transfer.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate_Transfer.Enabled = false;
            this.dtpFromDate_Transfer.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate_Transfer.Location = new System.Drawing.Point(142, 65);
            this.dtpFromDate_Transfer.Name = "dtpFromDate_Transfer";
            this.dtpFromDate_Transfer.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate_Transfer.TabIndex = 6;
            // 
            // dtpToDate_Transfer
            // 
            this.dtpToDate_Transfer.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate_Transfer.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate_Transfer.Enabled = false;
            this.dtpToDate_Transfer.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate_Transfer.Location = new System.Drawing.Point(287, 65);
            this.dtpToDate_Transfer.Name = "dtpToDate_Transfer";
            this.dtpToDate_Transfer.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate_Transfer.TabIndex = 6;
            // 
            // txtToTxNumber_Transfer
            // 
            this.txtToTxNumber_Transfer.Location = new System.Drawing.Point(287, 13);
            this.txtToTxNumber_Transfer.Name = "txtToTxNumber_Transfer";
            this.txtToTxNumber_Transfer.Size = new System.Drawing.Size(100, 20);
            this.txtToTxNumber_Transfer.TabIndex = 5;
            this.txtToTxNumber_Transfer.Text = "ZZZZZZZZZZZZ";
            // 
            // txtFromTxNumber_Transfer
            // 
            this.txtFromTxNumber_Transfer.Location = new System.Drawing.Point(142, 13);
            this.txtFromTxNumber_Transfer.Name = "txtFromTxNumber_Transfer";
            this.txtFromTxNumber_Transfer.Size = new System.Drawing.Size(100, 20);
            this.txtFromTxNumber_Transfer.TabIndex = 4;
            this.txtFromTxNumber_Transfer.Text = "0";
            // 
            // lblFromTxNumber_Transfer
            // 
            this.lblFromTxNumber_Transfer.AutoSize = true;
            this.lblFromTxNumber_Transfer.Location = new System.Drawing.Point(38, 16);
            this.lblFromTxNumber_Transfer.Name = "lblFromTxNumber_Transfer";
            this.lblFromTxNumber_Transfer.Size = new System.Drawing.Size(116, 13);
            this.lblFromTxNumber_Transfer.TabIndex = 0;
            this.lblFromTxNumber_Transfer.Text = "TRN#          FROM:";
            // 
            // lblToTxNumber_Transfer
            // 
            this.lblToTxNumber_Transfer.AutoSize = true;
            this.lblToTxNumber_Transfer.Location = new System.Drawing.Point(248, 16);
            this.lblToTxNumber_Transfer.Name = "lblToTxNumber_Transfer";
            this.lblToTxNumber_Transfer.Size = new System.Drawing.Size(23, 13);
            this.lblToTxNumber_Transfer.TabIndex = 2;
            this.lblToTxNumber_Transfer.Text = "To:";
            // 
            // txtToStkCode_Transfer
            // 
            this.txtToStkCode_Transfer.Location = new System.Drawing.Point(287, 39);
            this.txtToStkCode_Transfer.Name = "txtToStkCode_Transfer";
            this.txtToStkCode_Transfer.Size = new System.Drawing.Size(100, 20);
            this.txtToStkCode_Transfer.TabIndex = 5;
            // 
            // txtFromStkCode_Transfer
            // 
            this.txtFromStkCode_Transfer.Location = new System.Drawing.Point(142, 39);
            this.txtFromStkCode_Transfer.Name = "txtFromStkCode_Transfer";
            this.txtFromStkCode_Transfer.Size = new System.Drawing.Size(100, 20);
            this.txtFromStkCode_Transfer.TabIndex = 4;
            // 
            // lblFromStkCode_Transfer
            // 
            this.lblFromStkCode_Transfer.AutoSize = true;
            this.lblFromStkCode_Transfer.Location = new System.Drawing.Point(20, 42);
            this.lblFromStkCode_Transfer.Name = "lblFromStkCode_Transfer";
            this.lblFromStkCode_Transfer.Size = new System.Drawing.Size(116, 13);
            this.lblFromStkCode_Transfer.TabIndex = 0;
            this.lblFromStkCode_Transfer.Text = "STKCODE          FROM:";
            // 
            // lblToStkCode_Transfer
            // 
            this.lblToStkCode_Transfer.AutoSize = true;
            this.lblToStkCode_Transfer.Location = new System.Drawing.Point(248, 42);
            this.lblToStkCode_Transfer.Name = "lblToStkCode_Transfer";
            this.lblToStkCode_Transfer.Size = new System.Drawing.Size(23, 13);
            this.lblToStkCode_Transfer.TabIndex = 2;
            this.lblToStkCode_Transfer.Text = "To:";
            // 
            // capSummary
            // 
            this.capSummary.Controls.Add(this.btnFindToTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.btnFindFromTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.groupBox1);
            this.capSummary.Controls.Add(this.chkShowRemarks_CAPSummary);
            this.capSummary.Controls.Add(this.lblToWorkplace_CAPSummary);
            this.capSummary.Controls.Add(this.lblFromWorkplace_CAPSummary);
            this.capSummary.Controls.Add(this.txtFromWorkplace_CAPSummary);
            this.capSummary.Controls.Add(this.txtToWorkplace_CAPSummary);
            this.capSummary.Controls.Add(this.txtToSupplierNumber_CAPSummary);
            this.capSummary.Controls.Add(this.txtFromSupplierNumber_CAPSummary);
            this.capSummary.Controls.Add(this.lblFromSupplierNumber_CAPSummary);
            this.capSummary.Controls.Add(this.lblSupplierNumber_CAPSummary);
            this.capSummary.Controls.Add(this.lblToTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.lblFromTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.txtFromTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.txtToTxNumber_CAPSummary);
            this.capSummary.Controls.Add(this.dtpToDate_CAPSummary);
            this.capSummary.Controls.Add(this.dtpFromDate_CAPSummary);
            this.capSummary.Controls.Add(this.lblToDate_CAPSummary);
            this.capSummary.Controls.Add(this.lblFromDate_CAPSummary);
            this.capSummary.Location = new System.Drawing.Point(234, 558);
            this.capSummary.Name = "capSummary";
            this.capSummary.Size = new System.Drawing.Size(766, 120);
            this.capSummary.TabIndex = 7;
            this.capSummary.Visible = false;
            // 
            // btnFindToTxNumber_CAPSummary
            // 
            iconResourceHandle11.File = "16x16.16_find.gif";
            this.btnFindToTxNumber_CAPSummary.Image = iconResourceHandle11;
            this.btnFindToTxNumber_CAPSummary.Location = new System.Drawing.Point(367, 39);
            this.btnFindToTxNumber_CAPSummary.Name = "btnFindToTxNumber_CAPSummary";
            this.btnFindToTxNumber_CAPSummary.Size = new System.Drawing.Size(25, 23);
            this.btnFindToTxNumber_CAPSummary.TabIndex = 10;
            this.btnFindToTxNumber_CAPSummary.Click += new System.EventHandler(this.btnFindToTxNumber_CAPSummary_Click);
            // 
            // btnFindFromTxNumber_CAPSummary
            // 
            iconResourceHandle12.File = "16x16.16_find.gif";
            this.btnFindFromTxNumber_CAPSummary.Image = iconResourceHandle12;
            this.btnFindFromTxNumber_CAPSummary.Location = new System.Drawing.Point(222, 37);
            this.btnFindFromTxNumber_CAPSummary.Name = "btnFindFromTxNumber_CAPSummary";
            this.btnFindFromTxNumber_CAPSummary.Size = new System.Drawing.Size(25, 23);
            this.btnFindFromTxNumber_CAPSummary.TabIndex = 9;
            this.btnFindFromTxNumber_CAPSummary.Click += new System.EventHandler(this.btnFindFromTxNumber_CAPSummary_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnPostRecord_CAPSummary);
            this.groupBox1.Controls.Add(this.chkPostedRecord_CAPSummary);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(417, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 53);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.Text = "Record Type";
            // 
            // chkUnPostRecord_CAPSummary
            // 
            this.chkUnPostRecord_CAPSummary.Checked = false;
            this.chkUnPostRecord_CAPSummary.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnPostRecord_CAPSummary.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnPostRecord_CAPSummary.Location = new System.Drawing.Point(144, 19);
            this.chkUnPostRecord_CAPSummary.Name = "chkUnPostRecord_CAPSummary";
            this.chkUnPostRecord_CAPSummary.Size = new System.Drawing.Size(104, 24);
            this.chkUnPostRecord_CAPSummary.TabIndex = 1;
            this.chkUnPostRecord_CAPSummary.Text = "Un-Post Record";
            this.chkUnPostRecord_CAPSummary.ThreeState = false;
            // 
            // chkPostedRecord_CAPSummary
            // 
            this.chkPostedRecord_CAPSummary.Checked = true;
            this.chkPostedRecord_CAPSummary.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.chkPostedRecord_CAPSummary.Enabled = false;
            this.chkPostedRecord_CAPSummary.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPostedRecord_CAPSummary.Location = new System.Drawing.Point(16, 19);
            this.chkPostedRecord_CAPSummary.Name = "chkPostedRecord_CAPSummary";
            this.chkPostedRecord_CAPSummary.Size = new System.Drawing.Size(104, 24);
            this.chkPostedRecord_CAPSummary.TabIndex = 0;
            this.chkPostedRecord_CAPSummary.Text = "Posted Record";
            this.chkPostedRecord_CAPSummary.ThreeState = false;
            // 
            // chkShowRemarks_CAPSummary
            // 
            this.chkShowRemarks_CAPSummary.Checked = false;
            this.chkShowRemarks_CAPSummary.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowRemarks_CAPSummary.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowRemarks_CAPSummary.Location = new System.Drawing.Point(440, 75);
            this.chkShowRemarks_CAPSummary.Name = "chkShowRemarks_CAPSummary";
            this.chkShowRemarks_CAPSummary.Size = new System.Drawing.Size(150, 24);
            this.chkShowRemarks_CAPSummary.TabIndex = 7;
            this.chkShowRemarks_CAPSummary.Text = "Show Remark1 - Remark6";
            this.chkShowRemarks_CAPSummary.ThreeState = false;
            // 
            // lblToWorkplace_CAPSummary
            // 
            this.lblToWorkplace_CAPSummary.AutoSize = true;
            this.lblToWorkplace_CAPSummary.Location = new System.Drawing.Point(248, 94);
            this.lblToWorkplace_CAPSummary.Name = "lblToWorkplace_CAPSummary";
            this.lblToWorkplace_CAPSummary.Size = new System.Drawing.Size(23, 13);
            this.lblToWorkplace_CAPSummary.TabIndex = 2;
            this.lblToWorkplace_CAPSummary.Text = "To:";
            // 
            // lblFromWorkplace_CAPSummary
            // 
            this.lblFromWorkplace_CAPSummary.AutoSize = true;
            this.lblFromWorkplace_CAPSummary.Location = new System.Drawing.Point(42, 94);
            this.lblFromWorkplace_CAPSummary.Name = "lblFromWorkplace_CAPSummary";
            this.lblFromWorkplace_CAPSummary.Size = new System.Drawing.Size(116, 13);
            this.lblFromWorkplace_CAPSummary.TabIndex = 0;
            this.lblFromWorkplace_CAPSummary.Text = "Loc#          FROM:";
            // 
            // txtFromWorkplace_CAPSummary
            // 
            this.txtFromWorkplace_CAPSummary.Location = new System.Drawing.Point(142, 91);
            this.txtFromWorkplace_CAPSummary.Name = "txtFromWorkplace_CAPSummary";
            this.txtFromWorkplace_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtFromWorkplace_CAPSummary.TabIndex = 4;
            this.txtFromWorkplace_CAPSummary.Text = "0";
            // 
            // txtToWorkplace_CAPSummary
            // 
            this.txtToWorkplace_CAPSummary.Location = new System.Drawing.Point(287, 91);
            this.txtToWorkplace_CAPSummary.Name = "txtToWorkplace_CAPSummary";
            this.txtToWorkplace_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtToWorkplace_CAPSummary.TabIndex = 5;
            this.txtToWorkplace_CAPSummary.Text = "ZZZZZZZZZZZZ";
            // 
            // txtToSupplierNumber_CAPSummary
            // 
            this.txtToSupplierNumber_CAPSummary.Location = new System.Drawing.Point(287, 65);
            this.txtToSupplierNumber_CAPSummary.Name = "txtToSupplierNumber_CAPSummary";
            this.txtToSupplierNumber_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtToSupplierNumber_CAPSummary.TabIndex = 5;
            this.txtToSupplierNumber_CAPSummary.Text = "ZZZZZZZZZZZZ";
            // 
            // txtFromSupplierNumber_CAPSummary
            // 
            this.txtFromSupplierNumber_CAPSummary.Location = new System.Drawing.Point(142, 65);
            this.txtFromSupplierNumber_CAPSummary.Name = "txtFromSupplierNumber_CAPSummary";
            this.txtFromSupplierNumber_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtFromSupplierNumber_CAPSummary.TabIndex = 4;
            this.txtFromSupplierNumber_CAPSummary.Text = "0";
            // 
            // lblFromSupplierNumber_CAPSummary
            // 
            this.lblFromSupplierNumber_CAPSummary.AutoSize = true;
            this.lblFromSupplierNumber_CAPSummary.Location = new System.Drawing.Point(34, 68);
            this.lblFromSupplierNumber_CAPSummary.Name = "lblFromSupplierNumber_CAPSummary";
            this.lblFromSupplierNumber_CAPSummary.Size = new System.Drawing.Size(116, 13);
            this.lblFromSupplierNumber_CAPSummary.TabIndex = 0;
            this.lblFromSupplierNumber_CAPSummary.Text = "Supp#          FROM:";
            // 
            // lblSupplierNumber_CAPSummary
            // 
            this.lblSupplierNumber_CAPSummary.AutoSize = true;
            this.lblSupplierNumber_CAPSummary.Location = new System.Drawing.Point(248, 68);
            this.lblSupplierNumber_CAPSummary.Name = "lblSupplierNumber_CAPSummary";
            this.lblSupplierNumber_CAPSummary.Size = new System.Drawing.Size(23, 13);
            this.lblSupplierNumber_CAPSummary.TabIndex = 2;
            this.lblSupplierNumber_CAPSummary.Text = "To:";
            // 
            // lblToTxNumber_CAPSummary
            // 
            this.lblToTxNumber_CAPSummary.AutoSize = true;
            this.lblToTxNumber_CAPSummary.Location = new System.Drawing.Point(248, 42);
            this.lblToTxNumber_CAPSummary.Name = "lblToTxNumber_CAPSummary";
            this.lblToTxNumber_CAPSummary.Size = new System.Drawing.Size(23, 13);
            this.lblToTxNumber_CAPSummary.TabIndex = 2;
            this.lblToTxNumber_CAPSummary.Text = "To:";
            // 
            // lblFromTxNumber_CAPSummary
            // 
            this.lblFromTxNumber_CAPSummary.AutoSize = true;
            this.lblFromTxNumber_CAPSummary.Location = new System.Drawing.Point(38, 42);
            this.lblFromTxNumber_CAPSummary.Name = "lblFromTxNumber_CAPSummary";
            this.lblFromTxNumber_CAPSummary.Size = new System.Drawing.Size(116, 13);
            this.lblFromTxNumber_CAPSummary.TabIndex = 0;
            this.lblFromTxNumber_CAPSummary.Text = "TRN#          FROM:";
            // 
            // txtFromTxNumber_CAPSummary
            // 
            this.txtFromTxNumber_CAPSummary.Location = new System.Drawing.Point(142, 39);
            this.txtFromTxNumber_CAPSummary.Name = "txtFromTxNumber_CAPSummary";
            this.txtFromTxNumber_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtFromTxNumber_CAPSummary.TabIndex = 4;
            this.txtFromTxNumber_CAPSummary.Text = "0";
            // 
            // txtToTxNumber_CAPSummary
            // 
            this.txtToTxNumber_CAPSummary.Location = new System.Drawing.Point(287, 39);
            this.txtToTxNumber_CAPSummary.Name = "txtToTxNumber_CAPSummary";
            this.txtToTxNumber_CAPSummary.Size = new System.Drawing.Size(80, 20);
            this.txtToTxNumber_CAPSummary.TabIndex = 5;
            this.txtToTxNumber_CAPSummary.Text = "ZZZZZZZZZZZZ";
            // 
            // dtpToDate_CAPSummary
            // 
            this.dtpToDate_CAPSummary.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate_CAPSummary.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate_CAPSummary.Enabled = false;
            this.dtpToDate_CAPSummary.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate_CAPSummary.Location = new System.Drawing.Point(287, 13);
            this.dtpToDate_CAPSummary.Name = "dtpToDate_CAPSummary";
            this.dtpToDate_CAPSummary.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate_CAPSummary.TabIndex = 6;
            // 
            // dtpFromDate_CAPSummary
            // 
            this.dtpFromDate_CAPSummary.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate_CAPSummary.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate_CAPSummary.Enabled = false;
            this.dtpFromDate_CAPSummary.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate_CAPSummary.Location = new System.Drawing.Point(142, 13);
            this.dtpFromDate_CAPSummary.Name = "dtpFromDate_CAPSummary";
            this.dtpFromDate_CAPSummary.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate_CAPSummary.TabIndex = 6;
            // 
            // lblToDate_CAPSummary
            // 
            this.lblToDate_CAPSummary.AutoSize = true;
            this.lblToDate_CAPSummary.Location = new System.Drawing.Point(248, 16);
            this.lblToDate_CAPSummary.Name = "lblToDate_CAPSummary";
            this.lblToDate_CAPSummary.Size = new System.Drawing.Size(100, 23);
            this.lblToDate_CAPSummary.TabIndex = 3;
            this.lblToDate_CAPSummary.Text = "To:";
            // 
            // lblFromDate_CAPSummary
            // 
            this.lblFromDate_CAPSummary.AutoSize = true;
            this.lblFromDate_CAPSummary.Location = new System.Drawing.Point(42, 16);
            this.lblFromDate_CAPSummary.Name = "lblFromDate_CAPSummary";
            this.lblFromDate_CAPSummary.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate_CAPSummary.TabIndex = 1;
            this.lblFromDate_CAPSummary.Text = "Date          FROM:";
            // 
            // OlapViewForm
            // 
            this.Controls.Add(this.capSummary);
            this.Controls.Add(this.stockTransfer);
            this.Controls.Add(this.discrepancyAudit);
            this.Controls.Add(this.openingClosingInvt);
            this.Controls.Add(this.stockInOutHistory);
            this.Controls.Add(this.normalQoH_ATS);
            this.Controls.Add(this.stockReorder);
            this.Controls.Add(this.splitContainer);
            this.Size = new System.Drawing.Size(1170, 718);
            this.Text = "OlapViewForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel normalQoH_ATS;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode;
        private Gizmox.WebGUI.Forms.Label lblToDate;
        private Gizmox.WebGUI.Forms.Label lblToStkCode;
        private Gizmox.WebGUI.Forms.Label lblFromDate;
        private Gizmox.WebGUI.Forms.Label lblFromStockCode;
        private Gizmox.WebGUI.Forms.CheckBox chkSkipZeroQty;
        private Gizmox.WebGUI.Forms.CheckBox chkShowRemarks;
        private Gizmox.WebGUI.Forms.CheckBox chkShowRetailAmount;
        private Gizmox.WebGUI.Forms.CheckBox chkShowOSTOnLoanQty;
        private Gizmox.WebGUI.Forms.CheckBox chkShowATSQty;
        private Gizmox.WebGUI.Forms.CheckBox chkShowPOQty;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Button btnShow;
        public Gizmox.WebGUI.Forms.Panel headerPanel;
        private Gizmox.WebGUI.Forms.Panel stockReorder;
        private Gizmox.WebGUI.Forms.Label lblFromStkCode_Reorder;
        private Gizmox.WebGUI.Forms.Label lblFromData_Reorder;
        private Gizmox.WebGUI.Forms.Label lblToStkCode_Reorder;
        private Gizmox.WebGUI.Forms.Label lblToDate_Reorder;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode_Reorder;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode_Reorder;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate_Reorder;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate_Reorder;
        private Gizmox.WebGUI.Forms.CheckBox chkShowBFQty_Reorder;
        private Gizmox.WebGUI.Forms.CheckBox chkShowCDQty_Reorder;
        private Gizmox.WebGUI.Forms.CheckBox chkShowPOQty_Reorder;
        private Gizmox.WebGUI.Forms.CheckBox chkShowATSQty_Reorder;
        private Gizmox.WebGUI.Forms.Panel stockInOutHistory;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate_IOHistory;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblToDate_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblFromDate_IOHistory;
        private Gizmox.WebGUI.Forms.TextBox txtToWorkplace_IOHistory;
        private Gizmox.WebGUI.Forms.TextBox txtFromWorkplace_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblToWorkplace_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblFromWorkplace_IOHistory;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode_IOHistory;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblFromStkCode_IOHistory;
        private Gizmox.WebGUI.Forms.Label lblToStkCode_IOHistory;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Panel openingClosingInvt;
        private Gizmox.WebGUI.Forms.Label lblToStkCode_OCInventory;
        private Gizmox.WebGUI.Forms.Label lblFromStkCode_OCInventory;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode_OCInventory;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode_OCInventory;
        private Gizmox.WebGUI.Forms.Label lblFromMonth_OCInventory;
        private Gizmox.WebGUI.Forms.Label lblToMonth_OCInventory;
        private Gizmox.WebGUI.Forms.TextBox txtFromMonth_OCInventory;
        private Gizmox.WebGUI.Forms.TextBox txtToMonth_OCInventory;
        private Gizmox.WebGUI.Forms.Panel discrepancyAudit;
        private Gizmox.WebGUI.Forms.Label lblToStkCode_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.Label lblFromStkCode_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.Label lblMonth_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.TextBox txtMonth_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.Label lblFromDate_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.Label lblToDate_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.CheckBox chkShowDiff_DiscrepancyAudit;
        private Gizmox.WebGUI.Forms.Panel stockTransfer;
        private Gizmox.WebGUI.Forms.TextBox txtToTxNumber_Transfer;
        private Gizmox.WebGUI.Forms.TextBox txtFromTxNumber_Transfer;
        private Gizmox.WebGUI.Forms.Label lblFromTxNumber_Transfer;
        private Gizmox.WebGUI.Forms.Label lblToTxNumber_Transfer;
        private Gizmox.WebGUI.Forms.TextBox txtToStkCode_Transfer;
        private Gizmox.WebGUI.Forms.TextBox txtFromStkCode_Transfer;
        private Gizmox.WebGUI.Forms.Label lblFromStkCode_Transfer;
        private Gizmox.WebGUI.Forms.Label lblToStkCode_Transfer;
        private Gizmox.WebGUI.Forms.Label lblFromDate_Transfer;
        private Gizmox.WebGUI.Forms.Label lblToDate_Transfer;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate_Transfer;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate_Transfer;
        private Gizmox.WebGUI.Forms.GroupBox gbRecordType_Transfer;
        private Gizmox.WebGUI.Forms.CheckBox chkUnPostRecord_Transfer;
        private Gizmox.WebGUI.Forms.CheckBox chkPostedRecords_Transfer;
        private Gizmox.WebGUI.Forms.GroupBox gbConfirmationStatus_Transfer;
        private Gizmox.WebGUI.Forms.CheckBox chkUnprocessed_Transfer;
        private Gizmox.WebGUI.Forms.CheckBox chkInCompleted_Transfer;
        private Gizmox.WebGUI.Forms.CheckBox chkCompleted_Transfer;
        private Gizmox.WebGUI.Forms.Panel capSummary;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate_CAPSummary;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblToDate_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblFromDate_CAPSummary;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.CheckBox chkUnPostRecord_CAPSummary;
        private Gizmox.WebGUI.Forms.CheckBox chkPostedRecord_CAPSummary;
        private Gizmox.WebGUI.Forms.CheckBox chkShowRemarks_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblToWorkplace_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblFromWorkplace_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtFromWorkplace_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtToWorkplace_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtToSupplierNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtFromSupplierNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblFromSupplierNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblSupplierNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblToTxNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Label lblFromTxNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtFromTxNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.TextBox txtToTxNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Button btnFindToTxNumber_CAPSummary;
        private Gizmox.WebGUI.Forms.Button btnFindFromTxNumber_CAPSummary;


    }
}