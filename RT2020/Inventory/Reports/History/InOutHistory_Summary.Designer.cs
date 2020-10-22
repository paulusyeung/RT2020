namespace RT2020.Inventory.Reports.History
{
    partial class InOutHistory_Summary
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
            this.gbLocation = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnNone = new Gizmox.WebGUI.Forms.Button();
            this.btnSelectAll = new Gizmox.WebGUI.Forms.Button();
            this.lvLocationList = new Gizmox.WebGUI.Forms.ListView();
            this.HeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.Mark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.LOC = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.gbData = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkReCalulated = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCD = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkTXO = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkTXI = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkRetail = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkADJ = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkSAL = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkREJ = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCAP = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkREC = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkBF = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblStockCodeFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboSTKCodeFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStockCodeTo = new Gizmox.WebGUI.Forms.Label();
            this.cboSTKCodeTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.gbGroupby = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbLoction = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbStk = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbStkAndLoc = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblForMonth = new Gizmox.WebGUI.Forms.Label();
            this.txtForMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblFromDate = new Gizmox.WebGUI.Forms.Label();
            this.lblToDate = new Gizmox.WebGUI.Forms.Label();
            this.dtDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.chkSkipZeroQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.btnNone);
            this.gbLocation.Controls.Add(this.btnSelectAll);
            this.gbLocation.Controls.Add(this.lvLocationList);
            this.gbLocation.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbLocation.Location = new System.Drawing.Point(11, 9);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(246, 196);
            this.gbLocation.TabIndex = 0;
            this.gbLocation.Text = "Location(s)";
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(165, 169);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
            this.btnNone.TabIndex = 2;
            this.btnNone.Text = "None";
            this.btnNone.Click += new System.EventHandler(this.btNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(84, 169);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "All";
            this.btnSelectAll.Click += new System.EventHandler(this.btAll_Click);
            // 
            // lvLocationList
            // 
            this.lvLocationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.HeaderId,
            this.Mark,
            this.LOC});
            this.lvLocationList.DataMember = null;
            this.lvLocationList.ItemsPerPage = 20;
            this.lvLocationList.Location = new System.Drawing.Point(6, 19);
            this.lvLocationList.Name = "lvLocationList";
            this.lvLocationList.Size = new System.Drawing.Size(234, 148);
            this.lvLocationList.TabIndex = 0;
            this.lvLocationList.Click += new System.EventHandler(this.lvLocationList_Click);
            // 
            // HeaderId
            // 
            this.HeaderId.Image = null;
            this.HeaderId.Text = "HeaderId";
            this.HeaderId.Visible = false;
            this.HeaderId.Width = 100;
            // 
            // Mark
            // 
            this.Mark.Image = null;
            this.Mark.Text = "Mark";
            this.Mark.Width = 50;
            // 
            // LOC
            // 
            this.LOC.Image = null;
            this.LOC.Text = "LOC#";
            this.LOC.Width = 150;
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.chkReCalulated);
            this.gbData.Controls.Add(this.chkCD);
            this.gbData.Controls.Add(this.chkTXO);
            this.gbData.Controls.Add(this.chkTXI);
            this.gbData.Controls.Add(this.chkRetail);
            this.gbData.Controls.Add(this.chkADJ);
            this.gbData.Controls.Add(this.chkSAL);
            this.gbData.Controls.Add(this.chkREJ);
            this.gbData.Controls.Add(this.chkCAP);
            this.gbData.Controls.Add(this.chkREC);
            this.gbData.Controls.Add(this.chkBF);
            this.gbData.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbData.Location = new System.Drawing.Point(263, 9);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(182, 196);
            this.gbData.TabIndex = 1;
            this.gbData.Text = "Data Column includes";
            // 
            // chkReCalulated
            // 
            this.chkReCalulated.Checked = false;
            this.chkReCalulated.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkReCalulated.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkReCalulated.Location = new System.Drawing.Point(6, 169);
            this.chkReCalulated.Name = "chkReCalulated";
            this.chkReCalulated.Size = new System.Drawing.Size(166, 15);
            this.chkReCalulated.TabIndex = 10;
            this.chkReCalulated.Text = "Re-Calculated C/D";
            this.chkReCalulated.ThreeState = false;
            // 
            // chkCD
            // 
            this.chkCD.Checked = true;
            this.chkCD.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCD.Enabled = false;
            this.chkCD.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCD.Location = new System.Drawing.Point(6, 154);
            this.chkCD.Name = "chkCD";
            this.chkCD.Size = new System.Drawing.Size(166, 15);
            this.chkCD.TabIndex = 9;
            this.chkCD.Text = "Closing Stock(C/D)";
            this.chkCD.ThreeState = false;
            // 
            // chkTXO
            // 
            this.chkTXO.Checked = true;
            this.chkTXO.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkTXO.Enabled = false;
            this.chkTXO.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkTXO.Location = new System.Drawing.Point(6, 139);
            this.chkTXO.Name = "chkTXO";
            this.chkTXO.Size = new System.Drawing.Size(166, 15);
            this.chkTXO.TabIndex = 8;
            this.chkTXO.Text = "Transfer Out(TXO,TRO)";
            this.chkTXO.ThreeState = false;
            // 
            // chkTXI
            // 
            this.chkTXI.Checked = true;
            this.chkTXI.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkTXI.Enabled = false;
            this.chkTXI.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkTXI.Location = new System.Drawing.Point(6, 124);
            this.chkTXI.Name = "chkTXI";
            this.chkTXI.Size = new System.Drawing.Size(166, 15);
            this.chkTXI.TabIndex = 7;
            this.chkTXI.Text = "Transfer In(TXI,TRI)";
            this.chkTXI.ThreeState = false;
            // 
            // chkRetail
            // 
            this.chkRetail.Checked = true;
            this.chkRetail.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkRetail.Enabled = false;
            this.chkRetail.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkRetail.Location = new System.Drawing.Point(6, 109);
            this.chkRetail.Name = "chkRetail";
            this.chkRetail.Size = new System.Drawing.Size(166, 15);
            this.chkRetail.TabIndex = 6;
            this.chkRetail.Text = "Retail(CRT,CAS,VOD)";
            this.chkRetail.ThreeState = false;
            // 
            // chkADJ
            // 
            this.chkADJ.Checked = true;
            this.chkADJ.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkADJ.Enabled = false;
            this.chkADJ.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkADJ.Location = new System.Drawing.Point(6, 94);
            this.chkADJ.Name = "chkADJ";
            this.chkADJ.Size = new System.Drawing.Size(166, 15);
            this.chkADJ.TabIndex = 5;
            this.chkADJ.Text = "Adjustment(ADJ)";
            this.chkADJ.ThreeState = false;
            // 
            // chkSAL
            // 
            this.chkSAL.Checked = true;
            this.chkSAL.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSAL.Enabled = false;
            this.chkSAL.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSAL.Location = new System.Drawing.Point(6, 79);
            this.chkSAL.Name = "chkSAL";
            this.chkSAL.Size = new System.Drawing.Size(166, 15);
            this.chkSAL.TabIndex = 4;
            this.chkSAL.Text = "Wholesale(SAL,SRT)";
            this.chkSAL.ThreeState = false;
            // 
            // chkREJ
            // 
            this.chkREJ.Checked = true;
            this.chkREJ.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkREJ.Enabled = false;
            this.chkREJ.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkREJ.Location = new System.Drawing.Point(6, 64);
            this.chkREJ.Name = "chkREJ";
            this.chkREJ.Size = new System.Drawing.Size(166, 15);
            this.chkREJ.TabIndex = 3;
            this.chkREJ.Text = "Stock Reject(REJ)";
            this.chkREJ.ThreeState = false;
            // 
            // chkCAP
            // 
            this.chkCAP.Checked = true;
            this.chkCAP.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCAP.Enabled = false;
            this.chkCAP.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCAP.Location = new System.Drawing.Point(6, 49);
            this.chkCAP.Name = "chkCAP";
            this.chkCAP.Size = new System.Drawing.Size(166, 15);
            this.chkCAP.TabIndex = 2;
            this.chkCAP.Text = "Cash Purchase(CAP)";
            this.chkCAP.ThreeState = false;
            // 
            // chkREC
            // 
            this.chkREC.Checked = true;
            this.chkREC.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkREC.Enabled = false;
            this.chkREC.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkREC.Location = new System.Drawing.Point(6, 34);
            this.chkREC.Name = "chkREC";
            this.chkREC.Size = new System.Drawing.Size(166, 15);
            this.chkREC.TabIndex = 1;
            this.chkREC.Text = "Purchase Order(REC)";
            this.chkREC.ThreeState = false;
            // 
            // chkBF
            // 
            this.chkBF.Checked = true;
            this.chkBF.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkBF.Enabled = false;
            this.chkBF.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkBF.Location = new System.Drawing.Point(6, 19);
            this.chkBF.Name = "chkBF";
            this.chkBF.Size = new System.Drawing.Size(166, 15);
            this.chkBF.TabIndex = 0;
            this.chkBF.Text = "Opering Stock(B/F)";
            this.chkBF.ThreeState = false;
            // 
            // lblStockCodeFrom
            // 
            this.lblStockCodeFrom.Location = new System.Drawing.Point(9, 218);
            this.lblStockCodeFrom.Name = "lblStockCodeFrom";
            this.lblStockCodeFrom.Size = new System.Drawing.Size(100, 15);
            this.lblStockCodeFrom.TabIndex = 10;
            this.lblStockCodeFrom.Text = "Stock Code From :";
            this.lblStockCodeFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSTKCodeFrom
            // 
            this.cboSTKCodeFrom.Location = new System.Drawing.Point(115, 212);
            this.cboSTKCodeFrom.Name = "cboSTKCodeFrom";
            this.cboSTKCodeFrom.Size = new System.Drawing.Size(142, 21);
            this.cboSTKCodeFrom.TabIndex = 2;
            // 
            // lblStockCodeTo
            // 
            this.lblStockCodeTo.Location = new System.Drawing.Point(9, 240);
            this.lblStockCodeTo.Name = "lblStockCodeTo";
            this.lblStockCodeTo.Size = new System.Drawing.Size(100, 15);
            this.lblStockCodeTo.TabIndex = 11;
            this.lblStockCodeTo.Text = "Stock Code To :";
            this.lblStockCodeTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSTKCodeTo
            // 
            this.cboSTKCodeTo.Location = new System.Drawing.Point(115, 235);
            this.cboSTKCodeTo.Name = "cboSTKCodeTo";
            this.cboSTKCodeTo.Size = new System.Drawing.Size(142, 21);
            this.cboSTKCodeTo.TabIndex = 3;
            // 
            // gbGroupby
            // 
            this.gbGroupby.Controls.Add(this.rbLoction);
            this.gbGroupby.Controls.Add(this.rbStk);
            this.gbGroupby.Controls.Add(this.rbStkAndLoc);
            this.gbGroupby.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbGroupby.Location = new System.Drawing.Point(263, 212);
            this.gbGroupby.Name = "gbGroupby";
            this.gbGroupby.Size = new System.Drawing.Size(182, 70);
            this.gbGroupby.TabIndex = 6;
            this.gbGroupby.Text = "Group by";
            // 
            // rbLoction
            // 
            this.rbLoction.Location = new System.Drawing.Point(7, 46);
            this.rbLoction.Name = "rbLoction";
            this.rbLoction.Size = new System.Drawing.Size(165, 15);
            this.rbLoction.TabIndex = 2;
            this.rbLoction.Text = "Location";
            // 
            // rbStk
            // 
            this.rbStk.Location = new System.Drawing.Point(7, 31);
            this.rbStk.Name = "rbStk";
            this.rbStk.Size = new System.Drawing.Size(165, 15);
            this.rbStk.TabIndex = 1;
            this.rbStk.Text = "Stock Code";
            // 
            // rbStkAndLoc
            // 
            this.rbStkAndLoc.Checked = true;
            this.rbStkAndLoc.Location = new System.Drawing.Point(7, 16);
            this.rbStkAndLoc.Name = "rbStkAndLoc";
            this.rbStkAndLoc.Size = new System.Drawing.Size(165, 15);
            this.rbStkAndLoc.TabIndex = 0;
            this.rbStkAndLoc.Text = "Stock Code + Location";
            // 
            // lblForMonth
            // 
            this.lblForMonth.Location = new System.Drawing.Point(12, 263);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(100, 16);
            this.lblForMonth.TabIndex = 12;
            this.lblForMonth.Text = "For Month :";
            this.lblForMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForMonth
            // 
            this.txtForMonth.Location = new System.Drawing.Point(115, 259);
            this.txtForMonth.Name = "txtForMonth";
            this.txtForMonth.Size = new System.Drawing.Size(75, 20);
            this.txtForMonth.TabIndex = 4;
            this.txtForMonth.TextChanged += new System.EventHandler(this.txtForMonth_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(196, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "(yyyymm)";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(12, 286);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(100, 16);
            this.lblFromDate.TabIndex = 13;
            this.lblFromDate.Text = "From Date :";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(11, 307);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(100, 16);
            this.lblToDate.TabIndex = 14;
            this.lblToDate.Text = "To Date :";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Enabled = false;
            this.dtDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(115, 283);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(142, 21);
            this.dtDateFrom.TabIndex = 5;
            // 
            // dtDateTo
            // 
            this.dtDateTo.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Enabled = false;
            this.dtDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(115, 305);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(142, 20);
            this.dtDateTo.TabIndex = 6;
            // 
            // chkSkipZeroQty
            // 
            this.chkSkipZeroQty.Checked = false;
            this.chkSkipZeroQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSkipZeroQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSkipZeroQty.Location = new System.Drawing.Point(11, 331);
            this.chkSkipZeroQty.Name = "chkSkipZeroQty";
            this.chkSkipZeroQty.Size = new System.Drawing.Size(246, 24);
            this.chkSkipZeroQty.TabIndex = 7;
            this.chkSkipZeroQty.Text = "Skip ZERO Qty(B/F QTY, C/D QTY)";
            this.chkSkipZeroQty.ThreeState = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(289, 332);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(370, 331);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // InOutHistory_Summary
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkSkipZeroQty);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtForMonth);
            this.Controls.Add(this.lblForMonth);
            this.Controls.Add(this.gbGroupby);
            this.Controls.Add(this.cboSTKCodeTo);
            this.Controls.Add(this.lblStockCodeTo);
            this.Controls.Add(this.cboSTKCodeFrom);
            this.Controls.Add(this.lblStockCodeFrom);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.gbLocation);
            this.Size = new System.Drawing.Size(452, 359);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "In / Out History -> Summary";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox gbLocation;
        private Gizmox.WebGUI.Forms.ListView lvLocationList;
        private Gizmox.WebGUI.Forms.Button btnNone;
        private Gizmox.WebGUI.Forms.Button btnSelectAll;
        private Gizmox.WebGUI.Forms.GroupBox gbData;
        private Gizmox.WebGUI.Forms.CheckBox chkBF;
        private Gizmox.WebGUI.Forms.CheckBox chkREC;
        private Gizmox.WebGUI.Forms.CheckBox chkCAP;
        private Gizmox.WebGUI.Forms.CheckBox chkRetail;
        private Gizmox.WebGUI.Forms.CheckBox chkADJ;
        private Gizmox.WebGUI.Forms.CheckBox chkSAL;
        private Gizmox.WebGUI.Forms.CheckBox chkREJ;
        private Gizmox.WebGUI.Forms.CheckBox chkReCalulated;
        private Gizmox.WebGUI.Forms.CheckBox chkCD;
        private Gizmox.WebGUI.Forms.CheckBox chkTXO;
        private Gizmox.WebGUI.Forms.CheckBox chkTXI;
        private Gizmox.WebGUI.Forms.ColumnHeader HeaderId;
        private Gizmox.WebGUI.Forms.ColumnHeader Mark;
        private Gizmox.WebGUI.Forms.ColumnHeader LOC;
        private Gizmox.WebGUI.Forms.Label lblStockCodeFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboSTKCodeFrom;
        private Gizmox.WebGUI.Forms.Label lblStockCodeTo;
        private Gizmox.WebGUI.Forms.ComboBox cboSTKCodeTo;
        private Gizmox.WebGUI.Forms.GroupBox gbGroupby;
        private Gizmox.WebGUI.Forms.RadioButton rbStkAndLoc;
        private Gizmox.WebGUI.Forms.RadioButton rbStk;
        private Gizmox.WebGUI.Forms.RadioButton rbLoction;
        private Gizmox.WebGUI.Forms.Label lblForMonth;
        private Gizmox.WebGUI.Forms.TextBox txtForMonth;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label lblFromDate;
        private Gizmox.WebGUI.Forms.Label lblToDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateTo;
        private Gizmox.WebGUI.Forms.CheckBox chkSkipZeroQty;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.Button btnExit;



    }
}