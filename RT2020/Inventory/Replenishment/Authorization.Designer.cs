namespace RT2020.Inventory.Replenishment
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
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.tabREJAuthorization = new Gizmox.WebGUI.Forms.TabControl();
            this.tpPosting = new Gizmox.WebGUI.Forms.TabPage();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPostingStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colToWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnExit_P = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboFieldName = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lblSysYear = new Gizmox.WebGUI.Forms.Label();
            this.txtSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.lblSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtItemRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lblItemRemarks = new Gizmox.WebGUI.Forms.Label();
            this.cboStaff = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStaff = new Gizmox.WebGUI.Forms.Label();
            this.dtpCompletedDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblCompletedDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpTxferDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTxferDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTxDate = new Gizmox.WebGUI.Forms.Label();
            this.lblNotes = new Gizmox.WebGUI.Forms.Label();
            this.chkConsolidate = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblConsolidate = new Gizmox.WebGUI.Forms.Label();
            this.txtPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.lblPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(300, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Please input a Replenishment Number for searching :";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(15, 32);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(253, 20);
            this.txtTxNumber.TabIndex = 1;
            this.txtTxNumber.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtTxNumber_KeyUp);
            this.txtTxNumber.TextChanged += new System.EventHandler(this.txtTxNumber_TextChanged);
            // 
            // tabREJAuthorization
            // 
            this.tabREJAuthorization.Controls.Add(this.tpPosting);
            this.tabREJAuthorization.Location = new System.Drawing.Point(12, 58);
            this.tabREJAuthorization.Multiline = false;
            this.tabREJAuthorization.Name = "tabREJAuthorization";
            this.tabREJAuthorization.SelectedIndex = 0;
            this.tabREJAuthorization.ShowCloseButton = false;
            this.tabREJAuthorization.Size = new System.Drawing.Size(742, 451);
            this.tabREJAuthorization.TabIndex = 2;
            // 
            // tpPosting
            // 
            this.tpPosting.Controls.Add(this.lvPostTxList);
            this.tpPosting.Controls.Add(this.btnExit_P);
            this.tpPosting.Controls.Add(this.btnPost);
            this.tpPosting.Controls.Add(this.btnMarkAll);
            this.tpPosting.Controls.Add(this.groupBox1);
            this.tpPosting.Controls.Add(this.txtSysYear);
            this.tpPosting.Controls.Add(this.lblSysYear);
            this.tpPosting.Controls.Add(this.txtSysMonth);
            this.tpPosting.Controls.Add(this.lblSysMonth);
            this.tpPosting.Controls.Add(this.groupBox2);
            this.tpPosting.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpPosting.Location = new System.Drawing.Point(4, 22);
            this.tpPosting.Name = "tpPosting";
            this.tpPosting.Size = new System.Drawing.Size(734, 425);
            this.tpPosting.TabIndex = 0;
            this.tpPosting.Text = "Post Transactions";
            // 
            // lvPostTxList
            // 
            this.lvPostTxList.CheckBoxes = true;
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colPostingStatus,
            this.colLN,
            this.colTxNumber,
            this.colFromWorkplace,
            this.colToWorkplace,
            this.colTxDate,
            this.colLastUpdated});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(3, 3);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(453, 418);
            this.lvPostTxList.TabIndex = 0;
            this.lvPostTxList.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.lvPostTxList_ItemCheck);
            this.lvPostTxList.DoubleClick += new System.EventHandler(this.lvPostTxList_DoubleClick);
            // 
            // colTxId
            // 
            this.colTxId.Image = null;
            this.colTxId.Text = "TxId";
            this.colTxId.Visible = false;
            this.colTxId.Width = 150;
            // 
            // colPostingStatus
            // 
            this.colPostingStatus.Image = null;
            this.colPostingStatus.Text = "Posting";
            this.colPostingStatus.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colPostingStatus.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.colPostingStatus.Visible = false;
            this.colPostingStatus.Width = 60;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.Width = 80;
            // 
            // colFromWorkplace
            // 
            this.colFromWorkplace.Image = null;
            this.colFromWorkplace.Text = "From Loc#";
            this.colFromWorkplace.Width = 80;
            // 
            // colToWorkplace
            // 
            this.colToWorkplace.Image = null;
            this.colToWorkplace.Text = "To Loc#";
            this.colToWorkplace.Width = 80;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 70;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
            // 
            // btnExit_P
            // 
            this.btnExit_P.Location = new System.Drawing.Point(632, 398);
            this.btnExit_P.Name = "btnExit_P";
            this.btnExit_P.Size = new System.Drawing.Size(75, 23);
            this.btnExit_P.TabIndex = 10;
            this.btnExit_P.Text = "Exit";
            this.btnExit_P.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(632, 367);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(632, 336);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 8;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(609, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 250);
            this.groupBox1.TabIndex = 7;
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(23, 217);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(6, 189);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(107, 20);
            this.txtData.TabIndex = 7;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(6, 163);
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
            this.cboOperator.Location = new System.Drawing.Point(6, 139);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(107, 21);
            this.cboOperator.TabIndex = 5;
            // 
            // lblOperator
            // 
            this.lblOperator.Location = new System.Drawing.Point(6, 113);
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
            this.cboOrdering.Location = new System.Drawing.Point(6, 89);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(107, 21);
            this.cboOrdering.TabIndex = 3;
            // 
            // lblOrdering
            // 
            this.lblOrdering.Location = new System.Drawing.Point(6, 63);
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
            "Tx#",
            "From Loc#",
            "To Loc#",
            "Tx Date",
            "Last Update (dd/MM/yyyy)",
            "Last Update "});
            this.cboFieldName.Location = new System.Drawing.Point(6, 39);
            this.cboFieldName.Name = "cboFieldName";
            this.cboFieldName.Size = new System.Drawing.Size(107, 21);
            this.cboFieldName.TabIndex = 1;
            // 
            // chkSortAndFilter
            // 
            this.chkSortAndFilter.Checked = false;
            this.chkSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkSortAndFilter.Location = new System.Drawing.Point(6, 14);
            this.chkSortAndFilter.Name = "chkSortAndFilter";
            this.chkSortAndFilter.Size = new System.Drawing.Size(107, 24);
            this.chkSortAndFilter.TabIndex = 0;
            this.chkSortAndFilter.Text = "Sort and Filter by";
            this.chkSortAndFilter.ThreeState = false;
            this.chkSortAndFilter.CheckedChanged += new System.EventHandler(this.chkSortAndFilter_CheckedChanged);
            // 
            // txtSysYear
            // 
            this.txtSysYear.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysYear.Location = new System.Drawing.Point(686, 33);
            this.txtSysYear.Name = "txtSysYear";
            this.txtSysYear.Size = new System.Drawing.Size(36, 19);
            this.txtSysYear.TabIndex = 6;
            this.txtSysYear.Text = "2008";
            this.txtSysYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysYear
            // 
            this.lblSysYear.Location = new System.Drawing.Point(612, 33);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(75, 19);
            this.lblSysYear.TabIndex = 5;
            this.lblSysYear.Text = "System Year";
            // 
            // txtSysMonth
            // 
            this.txtSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysMonth.Location = new System.Drawing.Point(686, 11);
            this.txtSysMonth.Name = "txtSysMonth";
            this.txtSysMonth.Size = new System.Drawing.Size(36, 19);
            this.txtSysMonth.TabIndex = 4;
            this.txtSysMonth.Text = "03";
            this.txtSysMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.Location = new System.Drawing.Point(612, 11);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(75, 19);
            this.lblSysMonth.TabIndex = 3;
            this.lblSysMonth.Text = "System Month";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtItemRemarks);
            this.groupBox2.Controls.Add(this.lblItemRemarks);
            this.groupBox2.Controls.Add(this.cboStaff);
            this.groupBox2.Controls.Add(this.lblStaff);
            this.groupBox2.Controls.Add(this.dtpCompletedDate);
            this.groupBox2.Controls.Add(this.lblCompletedDate);
            this.groupBox2.Controls.Add(this.dtpTxferDate);
            this.groupBox2.Controls.Add(this.lblTxferDate);
            this.groupBox2.Controls.Add(this.dtpTxDate);
            this.groupBox2.Controls.Add(this.lblTxDate);
            this.groupBox2.Controls.Add(this.lblNotes);
            this.groupBox2.Controls.Add(this.chkConsolidate);
            this.groupBox2.Controls.Add(this.lblConsolidate);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(462, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 393);
            this.groupBox2.TabIndex = 11;
            // 
            // txtItemRemarks
            // 
            this.txtItemRemarks.Location = new System.Drawing.Point(9, 329);
            this.txtItemRemarks.Name = "txtItemRemarks";
            this.txtItemRemarks.Size = new System.Drawing.Size(104, 20);
            this.txtItemRemarks.TabIndex = 12;
            // 
            // lblItemRemarks
            // 
            this.lblItemRemarks.Location = new System.Drawing.Point(6, 313);
            this.lblItemRemarks.Name = "lblItemRemarks";
            this.lblItemRemarks.Size = new System.Drawing.Size(132, 23);
            this.lblItemRemarks.TabIndex = 11;
            this.lblItemRemarks.Text = "5. Item Remarks";
            // 
            // cboStaff
            // 
            this.cboStaff.DropDownWidth = 129;
            this.cboStaff.Location = new System.Drawing.Point(9, 289);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(104, 21);
            this.cboStaff.TabIndex = 10;
            // 
            // lblStaff
            // 
            this.lblStaff.Location = new System.Drawing.Point(6, 269);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(132, 23);
            this.lblStaff.TabIndex = 9;
            this.lblStaff.Text = "4. Operator";
            // 
            // dtpCompletedDate
            // 
            this.dtpCompletedDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpCompletedDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCompletedDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpCompletedDate.Location = new System.Drawing.Point(9, 241);
            this.dtpCompletedDate.Name = "dtpCompletedDate";
            this.dtpCompletedDate.Size = new System.Drawing.Size(104, 20);
            this.dtpCompletedDate.TabIndex = 8;
            // 
            // lblCompletedDate
            // 
            this.lblCompletedDate.Location = new System.Drawing.Point(6, 226);
            this.lblCompletedDate.Name = "lblCompletedDate";
            this.lblCompletedDate.Size = new System.Drawing.Size(132, 23);
            this.lblCompletedDate.TabIndex = 7;
            this.lblCompletedDate.Text = "3. Completion Date";
            // 
            // dtpTxferDate
            // 
            this.dtpTxferDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxferDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxferDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxferDate.Location = new System.Drawing.Point(9, 199);
            this.dtpTxferDate.Name = "dtpTxferDate";
            this.dtpTxferDate.Size = new System.Drawing.Size(104, 20);
            this.dtpTxferDate.TabIndex = 6;
            // 
            // lblTxferDate
            // 
            this.lblTxferDate.Location = new System.Drawing.Point(6, 183);
            this.lblTxferDate.Name = "lblTxferDate";
            this.lblTxferDate.Size = new System.Drawing.Size(132, 23);
            this.lblTxferDate.TabIndex = 5;
            this.lblTxferDate.Text = "2. Transfer Date";
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(9, 156);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(104, 20);
            this.dtpTxDate.TabIndex = 4;
            // 
            // lblTxDate
            // 
            this.lblTxDate.Location = new System.Drawing.Point(6, 140);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Size = new System.Drawing.Size(132, 23);
            this.lblTxDate.TabIndex = 3;
            this.lblTxDate.Text = "1. Transaction Date";
            // 
            // lblNotes
            // 
            this.lblNotes.BorderColor = System.Drawing.Color.Transparent;
            this.lblNotes.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNotes.Location = new System.Drawing.Point(6, 90);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(132, 44);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Perform posting ONLY when all record(s) have passed the checking";
            // 
            // chkConsolidate
            // 
            this.chkConsolidate.Checked = false;
            this.chkConsolidate.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkConsolidate.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkConsolidate.Location = new System.Drawing.Point(9, 62);
            this.chkConsolidate.Name = "chkConsolidate";
            this.chkConsolidate.Size = new System.Drawing.Size(104, 24);
            this.chkConsolidate.TabIndex = 1;
            this.chkConsolidate.Text = "Yes";
            this.chkConsolidate.ThreeState = false;
            // 
            // lblConsolidate
            // 
            this.lblConsolidate.Location = new System.Drawing.Point(6, 16);
            this.lblConsolidate.Name = "lblConsolidate";
            this.lblConsolidate.Size = new System.Drawing.Size(132, 44);
            this.lblConsolidate.TabIndex = 0;
            this.lblConsolidate.Text = "Consolidate Marked RPL Transaction(s) into ONE Transfer Worksheet ?";
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtPostedOn.Location = new System.Drawing.Point(637, 9);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.Size = new System.Drawing.Size(110, 18);
            this.txtPostedOn.TabIndex = 2;
            // 
            // lblPostedOn
            // 
            this.lblPostedOn.Location = new System.Drawing.Point(573, 9);
            this.lblPostedOn.Name = "lblPostedOn";
            this.lblPostedOn.Size = new System.Drawing.Size(58, 19);
            this.lblPostedOn.TabIndex = 1;
            this.lblPostedOn.Text = "Post Date";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // Authorization
            // 
            this.Controls.Add(this.tabREJAuthorization);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.lblPostedOn);
            this.Controls.Add(this.txtPostedOn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(766, 521);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replenishment > Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabREJAuthorization;
        private Gizmox.WebGUI.Forms.TabPage tpPosting;
        private Gizmox.WebGUI.Forms.Label txtSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.Label txtSysMonth;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.Label txtPostedOn;
        private Gizmox.WebGUI.Forms.Label lblPostedOn;
        private Gizmox.WebGUI.Forms.Button btnExit_P;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboFieldName;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colPostingStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colToWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.Label lblNotes;
        private Gizmox.WebGUI.Forms.CheckBox chkConsolidate;
        private Gizmox.WebGUI.Forms.Label lblConsolidate;
        private Gizmox.WebGUI.Forms.Label lblTxDate;
        private Gizmox.WebGUI.Forms.TextBox txtItemRemarks;
        private Gizmox.WebGUI.Forms.Label lblItemRemarks;
        private Gizmox.WebGUI.Forms.ComboBox cboStaff;
        private Gizmox.WebGUI.Forms.Label lblStaff;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpCompletedDate;
        private Gizmox.WebGUI.Forms.Label lblCompletedDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxferDate;
        private Gizmox.WebGUI.Forms.Label lblTxferDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;


    }
}