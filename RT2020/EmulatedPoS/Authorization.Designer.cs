namespace RT2020.EmulatedPoS
{
    partial class Authorization
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.txtPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.tabPosAuthorization = new Gizmox.WebGUI.Forms.TabControl();
            this.tabpPostTran = new Gizmox.WebGUI.Forms.TabPage();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.lvPostTransaction = new Gizmox.WebGUI.Forms.ListView();
            this.colPosId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTrn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTotalAmount = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTrnDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.chkCheckQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnOption = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboFieldName = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.lblSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lblSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.tabpHoldTran = new Gizmox.WebGUI.Forms.TabPage();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.lvHoldTransaction = new Gizmox.WebGUI.Forms.ListView();
            this.colHoldPosId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldTrn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldTotalAmt = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldTrnDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHoldLastUpdate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnExit2 = new Gizmox.WebGUI.Forms.Button();
            this.tabpPostingResult = new Gizmox.WebGUI.Forms.TabPage();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.lvPostingResult = new Gizmox.WebGUI.Forms.ListView();
            this.colHeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTrnNo = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStyle = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFabrics = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colColor = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colReason = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.btnExit3 = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.txtPostedOn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTxNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 47);
            this.panel1.TabIndex = 0;
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtPostedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtPostedOn.Location = new System.Drawing.Point(581, 9);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.Size = new System.Drawing.Size(77, 16);
            this.txtPostedOn.TabIndex = 3;
            this.txtPostedOn.Text = "04/13/2010";
            // 
            // label2
            // 
            this.label2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Post Date:";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(18, 24);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(293, 20);
            this.txtTxNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please input a Sales Input Number for searching";
            // 
            // panel2
            // 
            this.panel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.tabPosAuthorization);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 468);
            this.panel2.TabIndex = 1;
            // 
            // tabPosAuthorization
            // 
            this.tabPosAuthorization.Controls.Add(this.tabpPostTran);
            this.tabPosAuthorization.Controls.Add(this.tabpHoldTran);
            this.tabPosAuthorization.Controls.Add(this.tabpPostingResult);
            this.tabPosAuthorization.Location = new System.Drawing.Point(14, 0);
            this.tabPosAuthorization.Multiline = false;
            this.tabPosAuthorization.Name = "tabPosAuthorization";
            this.tabPosAuthorization.SelectedIndex = 0;
            this.tabPosAuthorization.Size = new System.Drawing.Size(644, 456);
            this.tabPosAuthorization.TabIndex = 0;
            // 
            // tabpPostTran
            // 
            this.tabpPostTran.Controls.Add(this.panel4);
            this.tabpPostTran.Controls.Add(this.panel3);
            this.tabpPostTran.Location = new System.Drawing.Point(4, 22);
            this.tabpPostTran.Name = "tabpPostTran";
            this.tabpPostTran.Size = new System.Drawing.Size(636, 430);
            this.tabpPostTran.TabIndex = 0;
            this.tabpPostTran.Text = "Post Transaction(s)";
            // 
            // panel4
            // 
            this.panel4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.lvPostTransaction);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(493, 430);
            this.panel4.TabIndex = 1;
            // 
            // lvPostTransaction
            // 
            this.lvPostTransaction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvPostTransaction.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPosId,
            this.colMark,
            this.colTrn,
            this.colType,
            this.colTotalAmount,
            this.colTrnDate,
            this.colLastUpdate});
            this.lvPostTransaction.DataMember = null;
            this.lvPostTransaction.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPostTransaction.ItemsPerPage = 20;
            this.lvPostTransaction.Location = new System.Drawing.Point(0, 0);
            this.lvPostTransaction.Name = "lvPostTransaction";
            this.lvPostTransaction.Size = new System.Drawing.Size(493, 430);
            this.lvPostTransaction.TabIndex = 0;
            this.lvPostTransaction.DoubleClick += new System.EventHandler(this.lvPostTransaction_DoubleClick);
            // 
            // colPosId
            // 
            this.colPosId.Image = null;
            this.colPosId.Text = "PosId";
            this.colPosId.Visible = false;
            this.colPosId.Width = 50;
            // 
            // colMark
            // 
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colMark.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colMark.Visible = false;
            this.colMark.Width = 50;
            // 
            // colTrn
            // 
            this.colTrn.Image = null;
            this.colTrn.Text = "Trn#";
            this.colTrn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTrn.Width = 100;
            // 
            // colType
            // 
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colType.Width = 50;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.Image = null;
            this.colTotalAmount.Text = "Total Amount";
            this.colTotalAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTotalAmount.Width = 100;
            // 
            // colTrnDate
            // 
            this.colTrnDate.Image = null;
            this.colTrnDate.Text = "Trn. Date";
            this.colTrnDate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colTrnDate.Width = 100;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.Image = null;
            this.colLastUpdate.Text = "Last Update";
            this.colLastUpdate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colLastUpdate.Width = 100;
            // 
            // panel3
            // 
            this.panel3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.chkCheckQty);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnPost);
            this.panel3.Controls.Add(this.btnMarkAll);
            this.panel3.Controls.Add(this.btnOption);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblSysYear);
            this.panel3.Controls.Add(this.lblSysMonth);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(493, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 430);
            this.panel3.TabIndex = 0;
            // 
            // chkCheckQty
            // 
            this.chkCheckQty.Checked = true;
            this.chkCheckQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCheckQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCheckQty.Location = new System.Drawing.Point(13, 266);
            this.chkCheckQty.Name = "chkCheckQty";
            this.chkCheckQty.Size = new System.Drawing.Size(104, 24);
            this.chkCheckQty.TabIndex = 4;
            this.chkCheckQty.Text = "Check -ve Qty";
            this.chkCheckQty.ThreeState = false;
            this.chkCheckQty.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(38, 399);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(38, 365);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(38, 331);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 3;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(38, 297);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(75, 23);
            this.btnOption.TabIndex = 3;
            this.btnOption.Text = "Option";
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.lblData);
            this.groupBox1.Controls.Add(this.lblOperator);
            this.groupBox1.Controls.Add(this.lblOrdering);
            this.groupBox1.Controls.Add(this.cboOperator);
            this.groupBox1.Controls.Add(this.cboOrdering);
            this.groupBox1.Controls.Add(this.cboFieldName);
            this.groupBox1.Controls.Add(this.chkSortAndFilter);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 210);
            this.groupBox1.TabIndex = 2;
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(34, 177);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(6, 151);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(126, 20);
            this.txtData.TabIndex = 3;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(6, 135);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(6, 94);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(51, 13);
            this.lblOperator.TabIndex = 2;
            this.lblOperator.Text = "Operator";
            // 
            // lblOrdering
            // 
            this.lblOrdering.AutoSize = true;
            this.lblOrdering.Location = new System.Drawing.Point(6, 54);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(49, 13);
            this.lblOrdering.TabIndex = 2;
            this.lblOrdering.Text = "Ordering";
            // 
            // cboOperator
            // 
            this.cboOperator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperator.Enabled = false;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "Like",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(6, 111);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(126, 21);
            this.cboOperator.TabIndex = 1;
            // 
            // cboOrdering
            // 
            this.cboOrdering.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOrdering.Enabled = false;
            this.cboOrdering.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboOrdering.Location = new System.Drawing.Point(6, 70);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(126, 21);
            this.cboOrdering.TabIndex = 1;
            // 
            // cboFieldName
            // 
            this.cboFieldName.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFieldName.Enabled = false;
            this.cboFieldName.Items.AddRange(new object[] {
            "Trn#",
            "Type",
            "Total Amount",
            "Receive Date (dd/MM/yyyy)",
            "Last Update (dd/MM/yyyy)"});
            this.cboFieldName.Location = new System.Drawing.Point(5, 30);
            this.cboFieldName.Name = "cboFieldName";
            this.cboFieldName.Size = new System.Drawing.Size(126, 21);
            this.cboFieldName.TabIndex = 1;
            // 
            // chkSortAndFilter
            // 
            this.chkSortAndFilter.Checked = false;
            this.chkSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSortAndFilter.Location = new System.Drawing.Point(5, 6);
            this.chkSortAndFilter.Name = "chkSortAndFilter";
            this.chkSortAndFilter.Size = new System.Drawing.Size(127, 24);
            this.chkSortAndFilter.TabIndex = 0;
            this.chkSortAndFilter.Text = "Sort and Filter by";
            this.chkSortAndFilter.ThreeState = false;
            this.chkSortAndFilter.CheckedChanged += new System.EventHandler(this.chkSortAndFilter_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "System Year:";
            // 
            // lblSysYear
            // 
            this.lblSysYear.BackColor = System.Drawing.Color.LightYellow;
            this.lblSysYear.Location = new System.Drawing.Point(91, 26);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(48, 16);
            this.lblSysYear.TabIndex = 1;
            this.lblSysYear.Text = "2009";
            this.lblSysYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.lblSysMonth.Location = new System.Drawing.Point(91, 4);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(48, 16);
            this.lblSysMonth.TabIndex = 1;
            this.lblSysMonth.Text = "8";
            this.lblSysMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "System Month:";
            // 
            // tabpHoldTran
            // 
            this.tabpHoldTran.Controls.Add(this.panel6);
            this.tabpHoldTran.Controls.Add(this.panel5);
            this.tabpHoldTran.Location = new System.Drawing.Point(4, 22);
            this.tabpHoldTran.Name = "tabpHoldTran";
            this.tabpHoldTran.Size = new System.Drawing.Size(636, 430);
            this.tabpHoldTran.TabIndex = 0;
            this.tabpHoldTran.Text = "Hold Transaction(s)";
            // 
            // panel6
            // 
            this.panel6.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel6.Controls.Add(this.lvHoldTransaction);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(506, 430);
            this.panel6.TabIndex = 1;
            // 
            // lvHoldTransaction
            // 
            this.lvHoldTransaction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvHoldTransaction.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colHoldPosId,
            this.colHoldMark,
            this.colHoldTrn,
            this.colHoldType,
            this.colHoldTotalAmt,
            this.colHoldTrnDate,
            this.colHoldLastUpdate});
            this.lvHoldTransaction.DataMember = null;
            this.lvHoldTransaction.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvHoldTransaction.ItemsPerPage = 20;
            this.lvHoldTransaction.Location = new System.Drawing.Point(0, 0);
            this.lvHoldTransaction.Name = "lvHoldTransaction";
            this.lvHoldTransaction.Size = new System.Drawing.Size(506, 430);
            this.lvHoldTransaction.TabIndex = 0;
            // 
            // colHoldPosId
            // 
            this.colHoldPosId.Image = null;
            this.colHoldPosId.Text = "PosId";
            this.colHoldPosId.Visible = false;
            this.colHoldPosId.Width = 50;
            // 
            // colHoldMark
            // 
            this.colHoldMark.Image = null;
            this.colHoldMark.Text = "Mark";
            this.colHoldMark.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colHoldMark.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colHoldMark.Width = 50;
            // 
            // colHoldTrn
            // 
            this.colHoldTrn.Image = null;
            this.colHoldTrn.Text = "Trn#";
            this.colHoldTrn.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHoldTrn.Width = 100;
            // 
            // colHoldType
            // 
            this.colHoldType.Image = null;
            this.colHoldType.Text = "Type";
            this.colHoldType.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHoldType.Width = 50;
            // 
            // colHoldTotalAmt
            // 
            this.colHoldTotalAmt.Image = null;
            this.colHoldTotalAmt.Text = "Total Amount";
            this.colHoldTotalAmt.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHoldTotalAmt.Width = 100;
            // 
            // colHoldTrnDate
            // 
            this.colHoldTrnDate.Image = null;
            this.colHoldTrnDate.Text = "Trn. Date";
            this.colHoldTrnDate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHoldTrnDate.Width = 100;
            // 
            // colHoldLastUpdate
            // 
            this.colHoldLastUpdate.Image = null;
            this.colHoldLastUpdate.Text = "Last Update";
            this.colHoldLastUpdate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHoldLastUpdate.Width = 100;
            // 
            // panel5
            // 
            this.panel5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel5.Controls.Add(this.btnExit2);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(506, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(130, 430);
            this.panel5.TabIndex = 0;
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(30, 394);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(75, 23);
            this.btnExit2.TabIndex = 3;
            this.btnExit2.Text = "Exit";
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabpPostingResult
            // 
            this.tabpPostingResult.Controls.Add(this.panel8);
            this.tabpPostingResult.Controls.Add(this.panel7);
            this.tabpPostingResult.Location = new System.Drawing.Point(4, 22);
            this.tabpPostingResult.Name = "tabpPostingResult";
            this.tabpPostingResult.Size = new System.Drawing.Size(636, 430);
            this.tabpPostingResult.TabIndex = 0;
            this.tabpPostingResult.Text = "Posting Result";
            // 
            // panel8
            // 
            this.panel8.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel8.Controls.Add(this.lvPostingResult);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(506, 430);
            this.panel8.TabIndex = 1;
            // 
            // lvPostingResult
            // 
            this.lvPostingResult.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvPostingResult.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colHeaderId,
            this.colStatus,
            this.colTrnNo,
            this.colStyle,
            this.colFabrics,
            this.colColor,
            this.colSize,
            this.colReason});
            this.lvPostingResult.DataMember = null;
            this.lvPostingResult.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPostingResult.ItemsPerPage = 20;
            this.lvPostingResult.Location = new System.Drawing.Point(0, 0);
            this.lvPostingResult.Name = "lvPostingResult";
            this.lvPostingResult.Size = new System.Drawing.Size(506, 430);
            this.lvPostingResult.TabIndex = 0;
            // 
            // colHeaderId
            // 
            this.colHeaderId.Image = null;
            this.colHeaderId.Text = "HeaderId";
            this.colHeaderId.Visible = false;
            this.colHeaderId.Width = 50;
            // 
            // colStatus
            // 
            this.colStatus.Image = null;
            this.colStatus.Text = "STATUS";
            this.colStatus.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colStatus.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colStatus.Width = 50;
            // 
            // colTrnNo
            // 
            this.colTrnNo.Image = null;
            this.colTrnNo.Text = "Trn#";
            this.colTrnNo.Width = 80;
            // 
            // colStyle
            // 
            this.colStyle.Image = null;
            this.colStyle.Text = "STYLE";
            this.colStyle.Width = 50;
            // 
            // colFabrics
            // 
            this.colFabrics.Image = null;
            this.colFabrics.Text = "FABRICS";
            this.colFabrics.Width = 60;
            // 
            // colColor
            // 
            this.colColor.Image = null;
            this.colColor.Text = "COLOR";
            this.colColor.Width = 50;
            // 
            // colSize
            // 
            this.colSize.Image = null;
            this.colSize.Text = "SIZE";
            this.colSize.Width = 40;
            // 
            // colReason
            // 
            this.colReason.Image = null;
            this.colReason.Text = "Reason";
            this.colReason.Width = 120;
            // 
            // panel7
            // 
            this.panel7.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.panel7.Controls.Add(this.btnExit3);
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(506, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(130, 430);
            this.panel7.TabIndex = 0;
            // 
            // btnExit3
            // 
            this.btnExit3.Location = new System.Drawing.Point(31, 395);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(75, 23);
            this.btnExit3.TabIndex = 3;
            this.btnExit3.Text = "Exit";
            this.btnExit3.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.DataSource = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.Icon = null;
            // 
            // Authorization
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(670, 515);
            this.Text = "Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Panel panel2;
        private Gizmox.WebGUI.Forms.Label txtPostedOn;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabPosAuthorization;
        private Gizmox.WebGUI.Forms.TabPage tabpPostTran;
        private Gizmox.WebGUI.Forms.TabPage tabpHoldTran;
        private Gizmox.WebGUI.Forms.TabPage tabpPostingResult;
        private Gizmox.WebGUI.Forms.Panel panel4;
        private Gizmox.WebGUI.Forms.Panel panel3;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboFieldName;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnOption;
        private Gizmox.WebGUI.Forms.Panel panel6;
        private Gizmox.WebGUI.Forms.Panel panel5;
        private Gizmox.WebGUI.Forms.Button btnExit2;
        private Gizmox.WebGUI.Forms.Panel panel8;
        private Gizmox.WebGUI.Forms.Panel panel7;
        private Gizmox.WebGUI.Forms.Button btnExit3;
        private Gizmox.WebGUI.Forms.ListView lvPostTransaction;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colTrn;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
        private Gizmox.WebGUI.Forms.ColumnHeader colTotalAmount;
        private Gizmox.WebGUI.Forms.ColumnHeader colTrnDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdate;
        private Gizmox.WebGUI.Forms.ListView lvHoldTransaction;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldTrn;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldType;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldTotalAmt;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldTrnDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldLastUpdate;
        private Gizmox.WebGUI.Forms.ListView lvPostingResult;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colTrnNo;
        private Gizmox.WebGUI.Forms.ColumnHeader colStyle;
        private Gizmox.WebGUI.Forms.ColumnHeader colFabrics;
        private Gizmox.WebGUI.Forms.ColumnHeader colColor;
        private Gizmox.WebGUI.Forms.ColumnHeader colSize;
        private Gizmox.WebGUI.Forms.ColumnHeader colReason;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosId;
        private Gizmox.WebGUI.Forms.ColumnHeader colHoldPosId;
        private Gizmox.WebGUI.Forms.CheckBox chkCheckQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colHeaderId;


    }
}