namespace RT2020.Inventory.StockTake
{
    partial class Approval
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
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.btnApprove = new Gizmox.WebGUI.Forms.Button();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtData = new Gizmox.WebGUI.Forms.TextBox();
            this.lblData = new Gizmox.WebGUI.Forms.Label();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboFieldName = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdateDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMessage = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnExit_P = new Gizmox.WebGUI.Forms.Button();
            this.txtSysYear = new Gizmox.WebGUI.Forms.Label();
            this.lblSysYear = new Gizmox.WebGUI.Forms.Label();
            this.txtSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.lblSysMonth = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(15, 32);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(253, 20);
            this.txtTxNumber.TabIndex = 1;
            this.txtTxNumber.TextChanged += new System.EventHandler(this.txtTxNumber_TextChanged);
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(300, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Please input a Transaction Number for searching :";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(658, 471);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
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
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(658, 440);
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
            this.groupBox1.Location = new System.Drawing.Point(627, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 250);
            this.groupBox1.TabIndex = 7;
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
            "Loc#",
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
            // lvPostTxList
            // 
            this.lvPostTxList.CheckBoxes = true;
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colMark,
            this.colLN,
            this.colTxNumber,
            this.colWorkplace,
            this.colTxDate,
            this.colLastUpdateDate,
            this.colMessage});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(12, 59);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(606, 475);
            this.lvPostTxList.TabIndex = 0;
            this.lvPostTxList.Click += new System.EventHandler(this.lvPostTxList_Click);
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
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.Width = 80;
            // 
            // colWorkplace
            // 
            this.colWorkplace.Image = null;
            this.colWorkplace.Text = "Location";
            this.colWorkplace.Width = 60;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 70;
            // 
            // colLastUpdateDate
            // 
            this.colLastUpdateDate.Image = null;
            this.colLastUpdateDate.Text = "Last Update";
            this.colLastUpdateDate.Width = 110;
            // 
            // colMessage
            // 
            this.colMessage.Image = null;
            this.colMessage.Text = "Message";
            this.colMessage.Width = 300;
            // 
            // btnExit_P
            // 
            this.btnExit_P.Location = new System.Drawing.Point(658, 502);
            this.btnExit_P.Name = "btnExit_P";
            this.btnExit_P.Size = new System.Drawing.Size(75, 23);
            this.btnExit_P.TabIndex = 10;
            this.btnExit_P.Text = "Exit";
            this.btnExit_P.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtSysYear
            // 
            this.txtSysYear.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysYear.Location = new System.Drawing.Point(704, 81);
            this.txtSysYear.Name = "txtSysYear";
            this.txtSysYear.Size = new System.Drawing.Size(36, 19);
            this.txtSysYear.TabIndex = 6;
            this.txtSysYear.Text = "2008";
            this.txtSysYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysYear
            // 
            this.lblSysYear.Location = new System.Drawing.Point(630, 81);
            this.lblSysYear.Name = "lblSysYear";
            this.lblSysYear.Size = new System.Drawing.Size(75, 19);
            this.lblSysYear.TabIndex = 5;
            this.lblSysYear.Text = "System Year";
            // 
            // txtSysMonth
            // 
            this.txtSysMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtSysMonth.Location = new System.Drawing.Point(704, 59);
            this.txtSysMonth.Name = "txtSysMonth";
            this.txtSysMonth.Size = new System.Drawing.Size(36, 19);
            this.txtSysMonth.TabIndex = 4;
            this.txtSysMonth.Text = "03";
            this.txtSysMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSysMonth
            // 
            this.lblSysMonth.Location = new System.Drawing.Point(630, 59);
            this.lblSysMonth.Name = "lblSysMonth";
            this.lblSysMonth.Size = new System.Drawing.Size(75, 19);
            this.lblSysMonth.TabIndex = 3;
            this.lblSysMonth.Text = "System Month";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            this.errorProvider.Icon = null;
            // 
            // Approval
            // 
            this.Controls.Add(this.lblSysMonth);
            this.Controls.Add(this.txtSysMonth);
            this.Controls.Add(this.lblSysYear);
            this.Controls.Add(this.txtSysYear);
            this.Controls.Add(this.btnExit_P);
            this.Controls.Add(this.lvPostTxList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMarkAll);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxNumber);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(758, 546);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Take > Approval";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Button btnApprove;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.TextBox txtData;
        private Gizmox.WebGUI.Forms.Label lblData;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.ComboBox cboFieldName;
        private Gizmox.WebGUI.Forms.CheckBox chkSortAndFilter;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdateDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.Button btnExit_P;
        private Gizmox.WebGUI.Forms.Label txtSysYear;
        private Gizmox.WebGUI.Forms.Label lblSysYear;
        private Gizmox.WebGUI.Forms.Label txtSysMonth;
        private Gizmox.WebGUI.Forms.Label lblSysMonth;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colMessage;


    }
}