namespace RT2020.Inventory.Adjustment
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
            this.tabADJAuthorization = new Gizmox.WebGUI.Forms.TabControl();
            this.tpPosting = new Gizmox.WebGUI.Forms.TabPage();
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
            this.txtPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.lblPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPostingStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colOperator = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tpHolding = new Gizmox.WebGUI.Forms.TabPage();
            this.btnExit_H = new Gizmox.WebGUI.Forms.Button();
            this.lvHoldingTxList = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader10 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader4 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader5 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader6 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader8 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader9 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(300, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Please input a Adjustment Number for searching :";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(15, 32);
            this.txtTxNumber.MaxLength = 12;
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(253, 20);
            this.txtTxNumber.TabIndex = 1;
            this.txtTxNumber.TextChanged += new System.EventHandler(this.txtTxNumber_TextChanged);
            this.txtTxNumber.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtTxNumber_EnterKeyDown);
            // 
            // tabADJAuthorization
            // 
            this.tabADJAuthorization.Controls.Add(this.tpPosting);
            this.tabADJAuthorization.Controls.Add(this.tpHolding);
            this.tabADJAuthorization.Location = new System.Drawing.Point(12, 58);
            this.tabADJAuthorization.Multiline = false;
            this.tabADJAuthorization.Name = "tabADJAuthorization";
            this.tabADJAuthorization.SelectedIndex = 0;
            this.tabADJAuthorization.ShowCloseButton = false;
            this.tabADJAuthorization.Size = new System.Drawing.Size(742, 507);
            this.tabADJAuthorization.TabIndex = 2;
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
            this.tpPosting.Text = "Post Transactions";
            // 
            // btnExit_P
            // 
            this.btnExit_P.Location = new System.Drawing.Point(635, 443);
            this.btnExit_P.Name = "btnExit_P";
            this.btnExit_P.Size = new System.Drawing.Size(75, 23);
            this.btnExit_P.TabIndex = 10;
            this.btnExit_P.Text = "Exit";
            this.btnExit_P.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(635, 412);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(635, 381);
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
            this.groupBox1.Location = new System.Drawing.Point(612, 104);
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
            "ADJ#",
            "Type",
            "LOC#",
            "Receive Date (dd/MM/yyyy)",
            "Last Update (dd/MM/yyyy)"});
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
            this.txtSysYear.Location = new System.Drawing.Point(689, 78);
            this.txtSysYear.Name = "txtSysYear";
            this.txtSysYear.Size = new System.Drawing.Size(36, 19);
            this.txtSysYear.TabIndex = 6;
            this.txtSysYear.Text = "2008";
            this.txtSysYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysYear
            // 
            this.lblSysYear.Location = new System.Drawing.Point(615, 78);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(75, 19);
            this.lblSysYear.TabIndex = 5;
            this.lblSysYear.Text = "System Year";
            // 
            // txtSysMonth
            // 
            this.txtSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysMonth.Location = new System.Drawing.Point(689, 56);
            this.txtSysMonth.Name = "txtSysMonth";
            this.txtSysMonth.Size = new System.Drawing.Size(36, 19);
            this.txtSysMonth.TabIndex = 4;
            this.txtSysMonth.Text = "03";
            this.txtSysMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.Location = new System.Drawing.Point(615, 56);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(75, 19);
            this.lblSysMonth.TabIndex = 3;
            this.lblSysMonth.Text = "System Month";
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtPostedOn.Location = new System.Drawing.Point(615, 34);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.Size = new System.Drawing.Size(110, 18);
            this.txtPostedOn.TabIndex = 2;
            this.txtPostedOn.Text = "11/03/2008 09:47:45";
            // 
            // lblPostedOn
            // 
            this.lblPostedOn.Location = new System.Drawing.Point(615, 15);
            this.lblPostedOn.Name = "lblPostedOn";
            this.lblPostedOn.Size = new System.Drawing.Size(100, 19);
            this.lblPostedOn.TabIndex = 1;
            this.lblPostedOn.Text = "Post Date";
            // 
            // lvPostTxList
            // 
            this.lvPostTxList.CheckBoxes = true;
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colPostingStatus,
            this.colLN,
            this.colTxNumber,
            this.colType,
            this.colWorkplace,
            this.colTxDate,
            this.colOperator,
            this.colLastUpdated});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(3, 3);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(606, 475);
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
            this.colTxNumber.Text = "ADJ#";
            this.colTxNumber.Width = 80;
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
            this.colWorkplace.Text = "LOC#";
            this.colWorkplace.Width = 70;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Transaction Date";
            this.colTxDate.Width = 100;
            // 
            // colOperator
            // 
            this.colOperator.Image = null;
            this.colOperator.Text = "Operator";
            this.colOperator.Visible = false;
            this.colOperator.Width = 80;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
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
            this.tpHolding.Text = "Holding Transactions";
            // 
            // btnExit_H
            // 
            this.btnExit_H.Location = new System.Drawing.Point(635, 443);
            this.btnExit_H.Name = "btnExit_H";
            this.btnExit_H.Size = new System.Drawing.Size(75, 23);
            this.btnExit_H.TabIndex = 10;
            this.btnExit_H.Text = "Exit";
            this.btnExit_H.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lvHoldingTxList
            // 
            this.lvHoldingTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9});
            this.lvHoldingTxList.DataMember = null;
            this.lvHoldingTxList.ItemsPerPage = 20;
            this.lvHoldingTxList.Location = new System.Drawing.Point(3, 3);
            this.lvHoldingTxList.Name = "lvHoldingTxList";
            this.lvHoldingTxList.Size = new System.Drawing.Size(606, 475);
            this.lvHoldingTxList.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "TxId";
            this.columnHeader1.Visible = false;
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Image = null;
            this.columnHeader2.Text = "Mark";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Image = null;
            this.columnHeader10.Text = "LN";
            this.columnHeader10.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Image = null;
            this.columnHeader3.Text = "ADJ#";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Image = null;
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Image = null;
            this.columnHeader5.Text = "LOC#";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Image = null;
            this.columnHeader6.Text = "Transaction Date";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Image = null;
            this.columnHeader8.Text = "Operator";
            this.columnHeader8.Visible = false;
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Image = null;
            this.columnHeader9.Text = "Last Update";
            this.columnHeader9.Width = 80;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // Authorization
            // 
            this.Controls.Add(this.tabADJAuthorization);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.lblTxNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(766, 577);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustment > Authorization";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tabADJAuthorization;
        private Gizmox.WebGUI.Forms.TabPage tpPosting;
        private Gizmox.WebGUI.Forms.TabPage tpHolding;
        private Gizmox.WebGUI.Forms.Label txtSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.Label txtSysMonth;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.Label txtPostedOn;
        private Gizmox.WebGUI.Forms.Label lblPostedOn;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
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
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colPostingStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colOperator;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.ListView lvHoldingTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader3;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader4;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader5;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader6;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader8;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader9;
        private Gizmox.WebGUI.Forms.Button btnExit_H;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader10;


    }
}