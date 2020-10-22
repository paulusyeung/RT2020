namespace RT2020.Purchasing.Wizard
{
    partial class AuthPurchaseOrder
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
            this.txtPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.colOrderNumberH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.lvHoldingTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxIdH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMarkH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLNH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTypeH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLocationH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecDateH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdateH = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblSysYear = new Gizmox.WebGUI.Forms.Label();
            this.txtSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.colOrderNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecvDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tpPosting = new Gizmox.WebGUI.Forms.TabPage();
            this.btnExit_P = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboFieldName = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lblSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.lblPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.tpHolding = new Gizmox.WebGUI.Forms.TabPage();
            this.btnExit_H = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.tabREJAuthorization = new Gizmox.WebGUI.Forms.TabControl();
            this.txtOrderNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblOrderNumber = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtPostedOn.ClientAction = null;
            this.txtPostedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPostedOn.Location = new System.Drawing.Point(615, 34);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.Size = new System.Drawing.Size(110, 18);
            this.txtPostedOn.TabIndex = 2;
            this.txtPostedOn.Text = "11/09/2008 23:55:45";
            // 
            // colOrderNumberH
            // 
            this.colOrderNumberH.ClientAction = null;
            this.colOrderNumberH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colOrderNumberH.Image = null;
            this.colOrderNumberH.Text = "Order Number";
            this.colOrderNumberH.Width = 80;
            // 
            // btnReload
            // 
            this.btnReload.ClientAction = null;
            this.btnReload.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(23, 217);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // lvHoldingTxList
            // 
            this.lvHoldingTxList.ClientAction = null;
            this.lvHoldingTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxIdH,
            this.colMarkH,
            this.colLNH,
            this.colOrderNumberH,
            this.colTypeH,
            this.colLocationH,
            this.colRecDateH,
            this.colLastUpdateH});
            this.lvHoldingTxList.DataMember = null;
            this.lvHoldingTxList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvHoldingTxList.ItemsPerPage = 20;
            this.lvHoldingTxList.Location = new System.Drawing.Point(3, 3);
            this.lvHoldingTxList.Name = "lvHoldingTxList";
            this.lvHoldingTxList.Size = new System.Drawing.Size(606, 475);
            this.lvHoldingTxList.TabIndex = 0;
            // 
            // colTxIdH
            // 
            this.colTxIdH.ClientAction = null;
            this.colTxIdH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTxIdH.Image = null;
            this.colTxIdH.Text = "TxId";
            this.colTxIdH.Visible = false;
            this.colTxIdH.Width = 150;
            // 
            // colMarkH
            // 
            this.colMarkH.ClientAction = null;
            this.colMarkH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMarkH.Image = null;
            this.colMarkH.Text = "Mark";
            this.colMarkH.Width = 40;
            // 
            // colLNH
            // 
            this.colLNH.ClientAction = null;
            this.colLNH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLNH.Image = null;
            this.colLNH.Text = "LN";
            this.colLNH.Width = 30;
            // 
            // colTypeH
            // 
            this.colTypeH.ClientAction = null;
            this.colTypeH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTypeH.Image = null;
            this.colTypeH.Text = "Type";
            this.colTypeH.Width = 40;
            // 
            // colLocationH
            // 
            this.colLocationH.ClientAction = null;
            this.colLocationH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLocationH.Image = null;
            this.colLocationH.Text = "Location";
            this.colLocationH.Width = 70;
            // 
            // colRecDateH
            // 
            this.colRecDateH.ClientAction = null;
            this.colRecDateH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colRecDateH.Image = null;
            this.colRecDateH.Text = "Receive Date";
            this.colRecDateH.Width = 80;
            // 
            // colLastUpdateH
            // 
            this.colLastUpdateH.ClientAction = null;
            this.colLastUpdateH.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLastUpdateH.Image = null;
            this.colLastUpdateH.Text = "Last Update";
            this.colLastUpdateH.Width = 80;
            // 
            // lblSysYear
            // 
            this.lblSysYear.ClientAction = null;
            this.lblSysYear.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSysYear.Location = new System.Drawing.Point(615, 78);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(75, 19);
            this.lblSysYear.TabIndex = 5;
            this.lblSysYear.Text = "System Year";
            // 
            // txtSysMonth
            // 
            this.txtSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysMonth.ClientAction = null;
            this.txtSysMonth.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSysMonth.Location = new System.Drawing.Point(689, 56);
            this.txtSysMonth.Name = "txtSysMonth";
            this.txtSysMonth.Size = new System.Drawing.Size(36, 19);
            this.txtSysMonth.TabIndex = 4;
            this.txtSysMonth.Text = "09";
            this.txtSysMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblData
            // 
            this.lblData.ClientAction = null;
            this.lblData.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblData.Location = new System.Drawing.Point(6, 163);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(72, 23);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            // 
            // lblOperator
            // 
            this.lblOperator.ClientAction = null;
            this.lblOperator.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOperator.Location = new System.Drawing.Point(6, 113);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(100, 23);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "Operator";
            // 
            // chkSortAndFilter
            // 
            this.chkSortAndFilter.Checked = false;
            this.chkSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSortAndFilter.ClientAction = null;
            this.chkSortAndFilter.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSortAndFilter.Location = new System.Drawing.Point(6, 14);
            this.chkSortAndFilter.Name = "chkSortAndFilter";
            this.chkSortAndFilter.Size = new System.Drawing.Size(107, 24);
            this.chkSortAndFilter.TabIndex = 0;
            this.chkSortAndFilter.Text = "Sort and Filter by";
            this.chkSortAndFilter.ThreeState = false;
            this.chkSortAndFilter.CheckedChanged += new System.EventHandler(this.ChkSortAndFilter_CheckedChanged);
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.ClientAction = null;
            this.colOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colOrderNumber.Image = null;
            this.colOrderNumber.Text = "Order Number";
            this.colOrderNumber.Width = 80;
            // 
            // cboOrdering
            // 
            this.cboOrdering.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOrdering.ClientAction = null;
            this.cboOrdering.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboOrdering.DropDownWidth = 107;
            this.cboOrdering.Enabled = false;
            this.cboOrdering.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboOrdering.Location = new System.Drawing.Point(6, 89);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(107, 21);
            this.cboOrdering.TabIndex = 3;
            // 
            // btnPost
            // 
            this.btnPost.ClientAction = null;
            this.btnPost.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnPost.Location = new System.Drawing.Point(635, 412);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post";
            this.btnPost.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnPost.Click += new System.EventHandler(this.BtnPost_Click);
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.ClientAction = null;
            this.colLastUpdated.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
            // 
            // lvPostTxList
            // 
            this.lvPostTxList.ClientAction = null;
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colMark,
            this.colLN,
            this.colOrderNumber,
            this.colType,
            this.colWorkplace,
            this.colRecvDate,
            this.colLastUpdated});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(3, 3);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(606, 475);
            this.lvPostTxList.TabIndex = 0;
            this.lvPostTxList.Click += new System.EventHandler(this.LvPostTxList_Click);
            // 
            // colTxId
            // 
            this.colTxId.ClientAction = null;
            this.colTxId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTxId.Image = null;
            this.colTxId.Text = "TxId";
            this.colTxId.Visible = false;
            this.colTxId.Width = 150;
            // 
            // colMark
            // 
            this.colMark.ClientAction = null;
            this.colMark.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.Width = 40;
            // 
            // colLN
            // 
            this.colLN.ClientAction = null;
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colType
            // 
            this.colType.ClientAction = null;
            this.colType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.Width = 40;
            // 
            // colWorkplace
            // 
            this.colWorkplace.ClientAction = null;
            this.colWorkplace.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colWorkplace.Image = null;
            this.colWorkplace.Text = "Location";
            this.colWorkplace.Width = 70;
            // 
            // colRecvDate
            // 
            this.colRecvDate.ClientAction = null;
            this.colRecvDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colRecvDate.Image = null;
            this.colRecvDate.Text = "Receive Date";
            this.colRecvDate.Width = 80;
            // 
            // tpPosting
            // 
            this.tpPosting.ClientAction = null;
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
            this.tpPosting.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpPosting.Location = new System.Drawing.Point(4, 22);
            this.tpPosting.Name = "tpPosting";
            this.tpPosting.Size = new System.Drawing.Size(734, 481);
            this.tpPosting.TabIndex = 0;
            this.tpPosting.Text = "Post Transactions";
            // 
            // btnExit_P
            // 
            this.btnExit_P.ClientAction = null;
            this.btnExit_P.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit_P.Location = new System.Drawing.Point(635, 443);
            this.btnExit_P.Name = "btnExit_P";
            this.btnExit_P.Size = new System.Drawing.Size(75, 23);
            this.btnExit_P.TabIndex = 10;
            this.btnExit_P.Text = "Exit";
            this.btnExit_P.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit_P.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.ClientAction = null;
            this.btnMarkAll.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnMarkAll.Location = new System.Drawing.Point(635, 381);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 8;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnMarkAll.Click += new System.EventHandler(this.BtnMarkAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.ClientAction = null;
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.lblData);
            this.groupBox1.Controls.Add(this.cboOperator);
            this.groupBox1.Controls.Add(this.lblOperator);
            this.groupBox1.Controls.Add(this.cboOrdering);
            this.groupBox1.Controls.Add(this.lblOrdering);
            this.groupBox1.Controls.Add(this.cboFieldName);
            this.groupBox1.Controls.Add(this.chkSortAndFilter);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(614, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 250);
            this.groupBox1.TabIndex = 7;
            // 
            // txtData
            // 
            this.txtData.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtData.ClientAction = null;
            this.txtData.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(6, 189);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(107, 20);
            this.txtData.TabIndex = 7;
            // 
            // cboOperator
            // 
            this.cboOperator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperator.ClientAction = null;
            this.cboOperator.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboOperator.DropDownWidth = 107;
            this.cboOperator.Enabled = false;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "Like",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(6, 139);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(107, 21);
            this.cboOperator.TabIndex = 5;
            // 
            // lblOrdering
            // 
            this.lblOrdering.ClientAction = null;
            this.lblOrdering.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOrdering.Location = new System.Drawing.Point(6, 63);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(100, 23);
            this.lblOrdering.TabIndex = 2;
            this.lblOrdering.Text = "Ordering";
            // 
            // cboFieldName
            // 
            this.cboFieldName.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFieldName.ClientAction = null;
            this.cboFieldName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboFieldName.DropDownWidth = 107;
            this.cboFieldName.Enabled = false;
            this.cboFieldName.Items.AddRange(new object[] {
            "Order Number",
            "Type",
            "Location",
            "Receive Date (dd/MM/yyyy)",
            "Last Update (dd/MM/yyyy)"});
            this.cboFieldName.Location = new System.Drawing.Point(6, 39);
            this.cboFieldName.Name = "cboFieldName";
            this.cboFieldName.Size = new System.Drawing.Size(107, 21);
            this.cboFieldName.TabIndex = 1;
            // 
            // txtSysYear
            // 
            this.txtSysYear.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysYear.ClientAction = null;
            this.txtSysYear.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSysYear.Location = new System.Drawing.Point(689, 78);
            this.txtSysYear.Name = "txtSysYear";
            this.txtSysYear.Size = new System.Drawing.Size(36, 19);
            this.txtSysYear.TabIndex = 6;
            this.txtSysYear.Text = "2008";
            this.txtSysYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.ClientAction = null;
            this.lblSysMonth.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSysMonth.Location = new System.Drawing.Point(615, 56);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(75, 19);
            this.lblSysMonth.TabIndex = 3;
            this.lblSysMonth.Text = "System Month";
            // 
            // lblPostedOn
            // 
            this.lblPostedOn.ClientAction = null;
            this.lblPostedOn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPostedOn.Location = new System.Drawing.Point(615, 15);
            this.lblPostedOn.Name = "lblPostedOn";
            this.lblPostedOn.Size = new System.Drawing.Size(100, 19);
            this.lblPostedOn.TabIndex = 1;
            this.lblPostedOn.Text = "Post Date";
            // 
            // tpHolding
            // 
            this.tpHolding.ClientAction = null;
            this.tpHolding.Controls.Add(this.btnExit_H);
            this.tpHolding.Controls.Add(this.lvHoldingTxList);
            this.tpHolding.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpHolding.Location = new System.Drawing.Point(4, 22);
            this.tpHolding.Name = "tpHolding";
            this.tpHolding.Size = new System.Drawing.Size(734, 481);
            this.tpHolding.TabIndex = 0;
            this.tpHolding.Text = "Holding Transactions";
            // 
            // btnExit_H
            // 
            this.btnExit_H.ClientAction = null;
            this.btnExit_H.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit_H.Location = new System.Drawing.Point(635, 443);
            this.btnExit_H.Name = "btnExit_H";
            this.btnExit_H.Size = new System.Drawing.Size(75, 23);
            this.btnExit_H.TabIndex = 10;
            this.btnExit_H.Text = "Exit";
            this.btnExit_H.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit_H.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // tabREJAuthorization
            // 
            this.tabREJAuthorization.ClientAction = null;
            this.tabREJAuthorization.Controls.Add(this.tpPosting);
            this.tabREJAuthorization.Controls.Add(this.tpHolding);
            this.tabREJAuthorization.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabREJAuthorization.Location = new System.Drawing.Point(12, 58);
            this.tabREJAuthorization.Multiline = false;
            this.tabREJAuthorization.Name = "tabREJAuthorization";
            this.tabREJAuthorization.SelectedIndex = 0;
            this.tabREJAuthorization.ShowCloseButton = false;
            this.tabREJAuthorization.Size = new System.Drawing.Size(742, 507);
            this.tabREJAuthorization.TabIndex = 2;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtOrderNumber.ClientAction = null;
            this.txtOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtOrderNumber.Location = new System.Drawing.Point(15, 32);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(253, 20);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtOrderNumber_KeyUp);
            this.txtOrderNumber.TextChanged += new System.EventHandler(this.TxtOrderNumber_TextChanged);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.ClientAction = null;
            this.lblOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 9);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(300, 23);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Please input a Order Number for searching :";
            // 
            // AuthPurchaseOrder
            // 
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.tabREJAuthorization);
            this.Size = new System.Drawing.Size(766, 577);
            this.Text = "Purchase Order > Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label txtPostedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colOrderNumberH;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.ListView lvHoldingTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxIdH;
        private Gizmox.WebGUI.Forms.ColumnHeader colMarkH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLNH;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLocationH;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecDateH;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdateH;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.Label txtSysMonth;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.ColumnHeader colOrderNumber;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecvDate;
        private Gizmox.WebGUI.Forms.TabPage tpPosting;
        private Gizmox.WebGUI.Forms.Button btnExit_P;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboFieldName;
        private Gizmox.WebGUI.Forms.Label txtSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.Label lblPostedOn;
        private Gizmox.WebGUI.Forms.TabPage tpHolding;
        private Gizmox.WebGUI.Forms.Button btnExit_H;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabControl tabREJAuthorization;
        private Gizmox.WebGUI.Forms.TextBox txtOrderNumber;
        private Gizmox.WebGUI.Forms.Label lblOrderNumber;


    }
}