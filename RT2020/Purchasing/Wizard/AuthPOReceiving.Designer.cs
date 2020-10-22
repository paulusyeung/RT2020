namespace RT2020.Purchasing.Wizard
{
    partial class AuthPOReceiving
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
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.colRecDateH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lvHoldingTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxIdH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarkH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLNH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTransactionNoH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRefPoNoH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTypeH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLocationH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdateH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.txtPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnExit_P = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboFieldName = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.tpPosting = new Gizmox.WebGUI.Forms.TabPage();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.txtSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lblSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.lblPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTransactionNo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRefPoNo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecvDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblOrderNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtReceivingNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.tpHolding = new Gizmox.WebGUI.Forms.TabPage();
            this.btnExit_H = new Gizmox.WebGUI.Forms.Button();
            this.tabREJAuthorization = new Gizmox.WebGUI.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(23, 219);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // colRecDateH
            // 
            this.colRecDateH.Image = null;
            this.colRecDateH.Text = "Receive Date";
            this.colRecDateH.Width = 80;
            // 
            // lblSysYear
            // 
            this.lblSysYear.Location = new System.Drawing.Point(608, 91);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(75, 19);
            this.lblSysYear.TabIndex = 5;
            this.lblSysYear.Text = "System Year";
            // 
            // lvHoldingTxList
            // 
            this.lvHoldingTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxIdH,
            this.colMarkH,
            this.colLNH,
            this.colTransactionNoH,
            this.colRefPoNoH,
            this.colTypeH,
            this.colLocationH,
            this.colRecDateH,
            this.colLastUpdateH});
            this.lvHoldingTxList.DataMember = null;
            this.lvHoldingTxList.ItemsPerPage = 20;
            this.lvHoldingTxList.Location = new System.Drawing.Point(3, 3);
            this.lvHoldingTxList.Name = "lvHoldingTxList";
            this.lvHoldingTxList.Size = new System.Drawing.Size(606, 475);
            this.lvHoldingTxList.TabIndex = 0;
            // 
            // colTxIdH
            // 
            this.colTxIdH.Image = null;
            this.colTxIdH.Text = "TxId";
            this.colTxIdH.Visible = false;
            this.colTxIdH.Width = 150;
            // 
            // colMarkH
            // 
            this.colMarkH.Image = null;
            this.colMarkH.Text = "Mark";
            this.colMarkH.Width = 40;
            // 
            // colLNH
            // 
            this.colLNH.Image = null;
            this.colLNH.Text = "LN";
            this.colLNH.Width = 30;
            // 
            // colTransactionNoH
            // 
            this.colTransactionNoH.Image = null;
            this.colTransactionNoH.Text = "Transaction No.";
            this.colTransactionNoH.Width = 100;
            // 
            // colRefPoNoH
            // 
            this.colRefPoNoH.Image = null;
            this.colRefPoNoH.Text = "Ref PO No.";
            this.colRefPoNoH.Width = 100;
            // 
            // colTypeH
            // 
            this.colTypeH.Image = null;
            this.colTypeH.Text = "Type";
            this.colTypeH.Width = 40;
            // 
            // colLocationH
            // 
            this.colLocationH.Image = null;
            this.colLocationH.Text = "Location";
            this.colLocationH.Width = 55;
            // 
            // colLastUpdateH
            // 
            this.colLastUpdateH.Image = null;
            this.colLastUpdateH.Text = "Last Update";
            this.colLastUpdateH.Width = 80;
            // 
            // txtSysMonth
            // 
            this.txtSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysMonth.Location = new System.Drawing.Point(682, 69);
            this.txtSysMonth.Name = "txtSysMonth";
            this.txtSysMonth.Size = new System.Drawing.Size(36, 19);
            this.txtSysMonth.TabIndex = 4;
            this.txtSysMonth.Text = "09";
            this.txtSysMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(6, 191);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(107, 20);
            this.txtData.TabIndex = 7;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.DataSource = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.Icon = null;
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtPostedOn.Location = new System.Drawing.Point(608, 47);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.Size = new System.Drawing.Size(110, 18);
            this.txtPostedOn.TabIndex = 2;
            this.txtPostedOn.Text = "11/09/2008 23:55:45";
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
            // 
            // btnExit_P
            // 
            this.btnExit_P.Location = new System.Drawing.Point(628, 456);
            this.btnExit_P.Name = "btnExit_P";
            this.btnExit_P.Size = new System.Drawing.Size(75, 23);
            this.btnExit_P.TabIndex = 10;
            this.btnExit_P.Text = "Exit";
            this.btnExit_P.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(628, 425);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.BtnPost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.lblData);
            this.groupBox1.Controls.Add(this.cboOperator);
            this.groupBox1.Controls.Add(this.lblOperator);
            this.groupBox1.Controls.Add(this.cboOrdering);
            this.groupBox1.Controls.Add(this.lblOrdering);
            this.groupBox1.Controls.Add(this.cboFieldName);
            this.groupBox1.Controls.Add(this.chkSortAndFilter);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(609, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 250);
            this.groupBox1.TabIndex = 7;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(6, 165);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(72, 23);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownWidth = 107;
            this.cboOperator.Enabled = false;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "Like",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(6, 141);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(107, 21);
            this.cboOperator.TabIndex = 5;
            // 
            // lblOperator
            // 
            this.lblOperator.Location = new System.Drawing.Point(6, 115);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(100, 23);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "Operator";
            // 
            // cboOrdering
            // 
            this.cboOrdering.DropDownWidth = 107;
            this.cboOrdering.Enabled = false;
            this.cboOrdering.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboOrdering.Location = new System.Drawing.Point(6, 91);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(107, 21);
            this.cboOrdering.TabIndex = 3;
            // 
            // lblOrdering
            // 
            this.lblOrdering.Location = new System.Drawing.Point(6, 65);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(100, 23);
            this.lblOrdering.TabIndex = 2;
            this.lblOrdering.Text = "Ordering";
            // 
            // cboFieldName
            // 
            this.cboFieldName.DropDownWidth = 107;
            this.cboFieldName.Enabled = false;
            this.cboFieldName.Items.AddRange(new object[] {
            "Receiving Number",
            "Type",
            "Location",
            "Receive Date (dd/MM/yyyy)",
            "Last Update (dd/MM/yyyy)"});
            this.cboFieldName.Location = new System.Drawing.Point(6, 41);
            this.cboFieldName.Name = "cboFieldName";
            this.cboFieldName.Size = new System.Drawing.Size(107, 21);
            this.cboFieldName.TabIndex = 1;
            // 
            // chkSortAndFilter
            // 
            this.chkSortAndFilter.Checked = false;
            this.chkSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSortAndFilter.Location = new System.Drawing.Point(6, 16);
            this.chkSortAndFilter.Name = "chkSortAndFilter";
            this.chkSortAndFilter.Size = new System.Drawing.Size(107, 24);
            this.chkSortAndFilter.TabIndex = 0;
            this.chkSortAndFilter.Text = "Sort and Filter by";
            this.chkSortAndFilter.ThreeState = false;
            this.chkSortAndFilter.CheckedChanged += new System.EventHandler(this.ChkSortAndFilter_CheckedChanged);
            // 
            // tpPosting
            // 
            this.tpPosting.Controls.Add(this.btnExit_P);
            this.tpPosting.Controls.Add(this.btnPost);
            this.tpPosting.Controls.Add(this.btnMarkAll);
            this.tpPosting.Controls.Add(this.groupBox1);
            this.tpPosting.Controls.Add(this.txtSysYear);
            this.tpPosting.Controls.Add(this.lblSysYear);
            this.tpPosting.Controls.Add(this.txtSysMonth);
            this.tpPosting.Controls.Add(this.lblSysMonth);
            this.tpPosting.Controls.Add(this.txtPostedOn);
            this.tpPosting.Controls.Add(this.lblPostedOn);
            this.tpPosting.Controls.Add(this.lvPostTxList);
            this.tpPosting.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpPosting.Location = new System.Drawing.Point(4, 22);
            this.tpPosting.Name = "tpPosting";
            this.tpPosting.Size = new System.Drawing.Size(734, 481);
            this.tpPosting.TabIndex = 0;
            this.tpPosting.Text = "Post Transaction(s)";
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(628, 394);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 8;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.BtnMarkAll_Click);
            // 
            // txtSysYear
            // 
            this.txtSysYear.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysYear.Location = new System.Drawing.Point(682, 91);
            this.txtSysYear.Name = "txtSysYear";
            this.txtSysYear.Size = new System.Drawing.Size(36, 19);
            this.txtSysYear.TabIndex = 6;
            this.txtSysYear.Text = "2008";
            this.txtSysYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.Location = new System.Drawing.Point(608, 69);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(75, 19);
            this.lblSysMonth.TabIndex = 3;
            this.lblSysMonth.Text = "System Month";
            // 
            // lblPostedOn
            // 
            this.lblPostedOn.Location = new System.Drawing.Point(608, 28);
            this.lblPostedOn.Name = "lblPostedOn";
            this.lblPostedOn.Size = new System.Drawing.Size(100, 19);
            this.lblPostedOn.TabIndex = 1;
            this.lblPostedOn.Text = "Post Date";
            // 
            // lvPostTxList
            // 
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colMark,
            this.colLN,
            this.colTransactionNo,
            this.colRefPoNo,
            this.colType,
            this.colWorkplace,
            this.colRecvDate,
            this.colLastUpdated});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(-4, 16);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(606, 475);
            this.lvPostTxList.TabIndex = 0;
            this.lvPostTxList.Click += new System.EventHandler(this.LvPostTxList_Click);
            // 
            // colTxId
            // 
            this.colTxId.Image = null;
            this.colTxId.Text = "TxId";
            this.colTxId.Visible = false;
            this.colTxId.Width = 150;
            // 
            // colMark
            // 
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.Width = 40;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTransactionNo
            // 
            this.colTransactionNo.Image = null;
            this.colTransactionNo.Text = "Transaction No.";
            this.colTransactionNo.Width = 100;
            // 
            // colRefPoNo
            // 
            this.colRefPoNo.Image = null;
            this.colRefPoNo.Text = "Ref PO No.";
            this.colRefPoNo.Width = 100;
            // 
            // colType
            // 
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.Width = 40;
            // 
            // colWorkplace
            // 
            this.colWorkplace.Image = null;
            this.colWorkplace.Text = "Location";
            this.colWorkplace.Width = 55;
            // 
            // colRecvDate
            // 
            this.colRecvDate.Image = null;
            this.colRecvDate.Text = "Receive Date";
            this.colRecvDate.Width = 80;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 9);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(300, 23);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Please input a Transaction Number for searching :";
            // 
            // txtReceivingNumber
            // 
            this.txtReceivingNumber.Location = new System.Drawing.Point(15, 32);
            this.txtReceivingNumber.Name = "txtReceivingNumber";
            this.txtReceivingNumber.Size = new System.Drawing.Size(253, 20);
            this.txtReceivingNumber.TabIndex = 1;
            // 
            // tpHolding
            // 
            this.tpHolding.Controls.Add(this.btnExit_H);
            this.tpHolding.Controls.Add(this.lvHoldingTxList);
            this.tpHolding.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpHolding.Location = new System.Drawing.Point(4, 22);
            this.tpHolding.Name = "tpHolding";
            this.tpHolding.Size = new System.Drawing.Size(734, 481);
            this.tpHolding.TabIndex = 0;
            this.tpHolding.Text = "Holding Transaction(s)";
            // 
            // btnExit_H
            // 
            this.btnExit_H.Location = new System.Drawing.Point(635, 443);
            this.btnExit_H.Name = "btnExit_H";
            this.btnExit_H.Size = new System.Drawing.Size(75, 23);
            this.btnExit_H.TabIndex = 10;
            this.btnExit_H.Text = "Exit";
            this.btnExit_H.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tabREJAuthorization
            // 
            this.tabREJAuthorization.Controls.Add(this.tpPosting);
            this.tabREJAuthorization.Controls.Add(this.tpHolding);
            this.tabREJAuthorization.Location = new System.Drawing.Point(12, 58);
            this.tabREJAuthorization.Multiline = false;
            this.tabREJAuthorization.Name = "tabREJAuthorization";
            this.tabREJAuthorization.SelectedIndex = 0;
            this.tabREJAuthorization.ShowCloseButton = false;
            this.tabREJAuthorization.Size = new System.Drawing.Size(742, 507);
            this.tabREJAuthorization.TabIndex = 2;
            // 
            // AuthPOReceiving
            // 
            this.Controls.Add(this.tabREJAuthorization);
            this.Controls.Add(this.txtReceivingNumber);
            this.Controls.Add(this.lblOrderNumber);
            this.Size = new System.Drawing.Size(766, 577);
            this.Text = "Purchase Order > Receiving";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecDateH;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.ListView lvHoldingTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxIdH;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarkH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLNH;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocationH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdateH;
        private Gizmox.WebGUI.Forms.Label txtSysMonth;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label txtPostedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.Button btnExit_P;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboFieldName;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.TabPage tpPosting;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Label txtSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.Label lblPostedOn;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecvDate;
        private Gizmox.WebGUI.Forms.Label lblOrderNumber;
        private Gizmox.WebGUI.Forms.TextBox txtReceivingNumber;
        private Gizmox.WebGUI.Forms.TabPage tpHolding;
        private Gizmox.WebGUI.Forms.Button btnExit_H;
        private Gizmox.WebGUI.Forms.TabControl tabREJAuthorization;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransactionNoH;
        private Gizmox.WebGUI.Forms.ColumnHeader colRefPoNoH;
        private Gizmox.WebGUI.Forms.ColumnHeader colTransactionNo;
        private Gizmox.WebGUI.Forms.ColumnHeader colRefPoNo;


    }
}