namespace RT2020.PriceMgmt
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
            this.lblTxNumberToLookup = new Gizmox.WebGUI.Forms.Label();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPost = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkItems = new Gizmox.WebGUI.Forms.Button();
            this.gbSortAndFilter = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtSearchData = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSearchData = new Gizmox.WebGUI.Forms.Label();
            this.btnReload = new Gizmox.WebGUI.Forms.Button();
            this.cboOperator = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOperator = new Gizmox.WebGUI.Forms.Label();
            this.cboOrdering = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblOrdering = new Gizmox.WebGUI.Forms.Label();
            this.cboSortAndFilterBy = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkEnableSortAndFilter = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtCurrentSystemYear = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCurrentSystemMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCurrentSystemYear = new Gizmox.WebGUI.Forms.Label();
            this.lblCurrentSystemMonth = new Gizmox.WebGUI.Forms.Label();
            this.lvAuthList = new Gizmox.WebGUI.Forms.ListView();
            this.colHeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colReason = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colEffectiveDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtPostedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPostedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumberToLookup = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // lblTxNumberToLookup
            // 
            this.lblTxNumberToLookup.AutoSize = true;
            this.lblTxNumberToLookup.Location = new System.Drawing.Point(17, 14);
            this.lblTxNumberToLookup.Name = "lblTxNumberToLookup";
            this.lblTxNumberToLookup.Size = new System.Drawing.Size(243, 13);
            this.lblTxNumberToLookup.TabIndex = 0;
            this.lblTxNumberToLookup.Text = "Please input a {0} Change Number for searching:";
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.btnExit);
            this.mainPane.Controls.Add(this.btnPost);
            this.mainPane.Controls.Add(this.btnMarkItems);
            this.mainPane.Controls.Add(this.gbSortAndFilter);
            this.mainPane.Controls.Add(this.txtCurrentSystemYear);
            this.mainPane.Controls.Add(this.txtCurrentSystemMonth);
            this.mainPane.Controls.Add(this.lblCurrentSystemYear);
            this.mainPane.Controls.Add(this.lblCurrentSystemMonth);
            this.mainPane.Controls.Add(this.lvAuthList);
            this.mainPane.Controls.Add(this.txtPostedOn);
            this.mainPane.Controls.Add(this.lblPostedOn);
            this.mainPane.Controls.Add(this.txtTxNumberToLookup);
            this.mainPane.Controls.Add(this.lblTxNumberToLookup);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(756, 501);
            this.mainPane.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(649, 450);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(649, 420);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 10;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnMarkItems
            // 
            this.btnMarkItems.Location = new System.Drawing.Point(649, 390);
            this.btnMarkItems.Name = "btnMarkItems";
            this.btnMarkItems.Size = new System.Drawing.Size(75, 23);
            this.btnMarkItems.TabIndex = 9;
            this.btnMarkItems.Text = "Mark All";
            this.btnMarkItems.Click += new System.EventHandler(this.Button_Click);
            // 
            // gbSortAndFilter
            // 
            this.gbSortAndFilter.Controls.Add(this.txtSearchData);
            this.gbSortAndFilter.Controls.Add(this.lblSearchData);
            this.gbSortAndFilter.Controls.Add(this.btnReload);
            this.gbSortAndFilter.Controls.Add(this.cboOperator);
            this.gbSortAndFilter.Controls.Add(this.lblOperator);
            this.gbSortAndFilter.Controls.Add(this.cboOrdering);
            this.gbSortAndFilter.Controls.Add(this.lblOrdering);
            this.gbSortAndFilter.Controls.Add(this.cboSortAndFilterBy);
            this.gbSortAndFilter.Controls.Add(this.chkEnableSortAndFilter);
            this.gbSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSortAndFilter.Location = new System.Drawing.Point(625, 105);
            this.gbSortAndFilter.Name = "gbSortAndFilter";
            this.gbSortAndFilter.Size = new System.Drawing.Size(122, 249);
            this.gbSortAndFilter.TabIndex = 8;
            // 
            // txtSearchData
            // 
            this.txtSearchData.Enabled = false;
            this.txtSearchData.Location = new System.Drawing.Point(8, 175);
            this.txtSearchData.Name = "txtSearchData";
            this.txtSearchData.Size = new System.Drawing.Size(104, 20);
            this.txtSearchData.TabIndex = 11;
            // 
            // lblSearchData
            // 
            this.lblSearchData.AutoSize = true;
            this.lblSearchData.Location = new System.Drawing.Point(7, 159);
            this.lblSearchData.Name = "lblSearchData";
            this.lblSearchData.Size = new System.Drawing.Size(40, 13);
            this.lblSearchData.TabIndex = 10;
            this.lblSearchData.Text = "Data : ";
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(24, 211);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.Button_Click);
            // 
            // cboOperator
            // 
            this.cboOperator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOperator.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.Enabled = false;
            this.cboOperator.Items.AddRange(new object[] {
            "None",
            "LIKE",
            "="});
            this.cboOperator.Location = new System.Drawing.Point(8, 129);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(104, 21);
            this.cboOperator.TabIndex = 1;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(5, 113);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(61, 13);
            this.lblOperator.TabIndex = 3;
            this.lblOperator.Text = "Operator : ";
            // 
            // cboOrdering
            // 
            this.cboOrdering.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboOrdering.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdering.Enabled = false;
            this.cboOrdering.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboOrdering.Location = new System.Drawing.Point(8, 83);
            this.cboOrdering.Name = "cboOrdering";
            this.cboOrdering.Size = new System.Drawing.Size(104, 21);
            this.cboOrdering.TabIndex = 1;
            // 
            // lblOrdering
            // 
            this.lblOrdering.AutoSize = true;
            this.lblOrdering.Location = new System.Drawing.Point(5, 67);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(56, 13);
            this.lblOrdering.TabIndex = 2;
            this.lblOrdering.Text = "Ordering :";
            // 
            // cboSortAndFilterBy
            // 
            this.cboSortAndFilterBy.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSortAndFilterBy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboSortAndFilterBy.Enabled = false;
            this.cboSortAndFilterBy.Items.AddRange(new object[] {
            "TRN#",
            "Type",
            "Reason",
            "Effective Date (dd/MM/yyyy)",
            "Last Update (dd/MM/yyyy)"});
            this.cboSortAndFilterBy.Location = new System.Drawing.Point(8, 37);
            this.cboSortAndFilterBy.Name = "cboSortAndFilterBy";
            this.cboSortAndFilterBy.Size = new System.Drawing.Size(104, 21);
            this.cboSortAndFilterBy.TabIndex = 1;
            // 
            // chkEnableSortAndFilter
            // 
            this.chkEnableSortAndFilter.Checked = false;
            this.chkEnableSortAndFilter.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkEnableSortAndFilter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkEnableSortAndFilter.Location = new System.Drawing.Point(8, 12);
            this.chkEnableSortAndFilter.Name = "chkEnableSortAndFilter";
            this.chkEnableSortAndFilter.Size = new System.Drawing.Size(104, 24);
            this.chkEnableSortAndFilter.TabIndex = 0;
            this.chkEnableSortAndFilter.Text = "Sort and Filter by";
            this.chkEnableSortAndFilter.ThreeState = false;
            this.chkEnableSortAndFilter.Click += new System.EventHandler(this.chkEnableSortAndFilter_Click);
            // 
            // txtCurrentSystemYear
            // 
            this.txtCurrentSystemYear.Enabled = false;
            this.txtCurrentSystemYear.Location = new System.Drawing.Point(706, 79);
            this.txtCurrentSystemYear.Name = "txtCurrentSystemYear";
            this.txtCurrentSystemYear.ReadOnly = true;
            this.txtCurrentSystemYear.Size = new System.Drawing.Size(41, 20);
            this.txtCurrentSystemYear.TabIndex = 7;
            // 
            // txtCurrentSystemMonth
            // 
            this.txtCurrentSystemMonth.Enabled = false;
            this.txtCurrentSystemMonth.Location = new System.Drawing.Point(706, 53);
            this.txtCurrentSystemMonth.Name = "txtCurrentSystemMonth";
            this.txtCurrentSystemMonth.ReadOnly = true;
            this.txtCurrentSystemMonth.Size = new System.Drawing.Size(41, 20);
            this.txtCurrentSystemMonth.TabIndex = 7;
            // 
            // lblCurrentSystemYear
            // 
            this.lblCurrentSystemYear.AutoSize = true;
            this.lblCurrentSystemYear.Location = new System.Drawing.Point(622, 82);
            this.lblCurrentSystemYear.Name = "lblCurrentSystemYear";
            this.lblCurrentSystemYear.Size = new System.Drawing.Size(77, 13);
            this.lblCurrentSystemYear.TabIndex = 6;
            this.lblCurrentSystemYear.Text = "System Year : ";
            // 
            // lblCurrentSystemMonth
            // 
            this.lblCurrentSystemMonth.AutoSize = true;
            this.lblCurrentSystemMonth.Location = new System.Drawing.Point(622, 56);
            this.lblCurrentSystemMonth.Name = "lblCurrentSystemMonth";
            this.lblCurrentSystemMonth.Size = new System.Drawing.Size(85, 13);
            this.lblCurrentSystemMonth.TabIndex = 5;
            this.lblCurrentSystemMonth.Text = "System Month : ";
            // 
            // lvAuthList
            // 
            this.lvAuthList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colHeaderId,
            this.colMark,
            this.colTxNumber,
            this.colTxType,
            this.colReason,
            this.colEffectiveDate,
            this.colLastUpdate});
            this.lvAuthList.DataMember = null;
            this.lvAuthList.ItemsPerPage = 20;
            this.lvAuthList.Location = new System.Drawing.Point(12, 56);
            this.lvAuthList.Name = "lvAuthList";
            this.lvAuthList.Size = new System.Drawing.Size(607, 433);
            this.lvAuthList.TabIndex = 4;
            this.lvAuthList.Click += new System.EventHandler(this.lvAuthList_Click);
            // 
            // colHeaderId
            // 
            this.colHeaderId.Image = null;
            this.colHeaderId.Text = "HeaderId";
            this.colHeaderId.Visible = false;
            this.colHeaderId.Width = 150;
            // 
            // colMark
            // 
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.Width = 50;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Trn#";
            this.colTxNumber.Width = 90;
            // 
            // colTxType
            // 
            this.colTxType.Image = null;
            this.colTxType.Text = "Type";
            this.colTxType.Width = 50;
            // 
            // colReason
            // 
            this.colReason.Image = null;
            this.colReason.Text = "Reason";
            this.colReason.Width = 80;
            // 
            // colEffectiveDate
            // 
            this.colEffectiveDate.Image = null;
            this.colEffectiveDate.Text = "Effective Date";
            this.colEffectiveDate.Width = 90;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.Image = null;
            this.colLastUpdate.Text = "Last Updated";
            this.colLastUpdate.Width = 90;
            // 
            // txtPostedOn
            // 
            this.txtPostedOn.Enabled = false;
            this.txtPostedOn.Location = new System.Drawing.Point(635, 11);
            this.txtPostedOn.Name = "txtPostedOn";
            this.txtPostedOn.ReadOnly = true;
            this.txtPostedOn.Size = new System.Drawing.Size(100, 20);
            this.txtPostedOn.TabIndex = 3;
            // 
            // lblPostedOn
            // 
            this.lblPostedOn.AutoSize = true;
            this.lblPostedOn.Location = new System.Drawing.Point(566, 14);
            this.lblPostedOn.Name = "lblPostedOn";
            this.lblPostedOn.Size = new System.Drawing.Size(61, 13);
            this.lblPostedOn.TabIndex = 2;
            this.lblPostedOn.Text = "Post Date :";
            // 
            // txtTxNumberToLookup
            // 
            this.txtTxNumberToLookup.Location = new System.Drawing.Point(12, 30);
            this.txtTxNumberToLookup.Name = "txtTxNumberToLookup";
            this.txtTxNumberToLookup.Size = new System.Drawing.Size(294, 20);
            this.txtTxNumberToLookup.TabIndex = 1;
            this.txtTxNumberToLookup.TextChanged += new System.EventHandler(this.txtTxNumberToLookup_TextChanged);
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
            this.Controls.Add(this.mainPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(756, 501);
            this.Text = "Authentication";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxNumberToLookup;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.ListView lvAuthList;
        private Gizmox.WebGUI.Forms.TextBox txtPostedOn;
        private Gizmox.WebGUI.Forms.Label lblPostedOn;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumberToLookup;
        private Gizmox.WebGUI.Forms.TextBox txtCurrentSystemYear;
        private Gizmox.WebGUI.Forms.TextBox txtCurrentSystemMonth;
        private Gizmox.WebGUI.Forms.Label lblCurrentSystemYear;
        private Gizmox.WebGUI.Forms.Label lblCurrentSystemMonth;
        private Gizmox.WebGUI.Forms.GroupBox gbSortAndFilter;
        private Gizmox.WebGUI.Forms.ComboBox cboSortAndFilterBy;
        private Gizmox.WebGUI.Forms.CheckBox chkEnableSortAndFilter;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPost;
        private Gizmox.WebGUI.Forms.Button btnMarkItems;
        private Gizmox.WebGUI.Forms.Button btnReload;
        private Gizmox.WebGUI.Forms.ComboBox cboOperator;
        private Gizmox.WebGUI.Forms.Label lblOperator;
        private Gizmox.WebGUI.Forms.ComboBox cboOrdering;
        private Gizmox.WebGUI.Forms.Label lblOrdering;
        private Gizmox.WebGUI.Forms.TextBox txtSearchData;
        private Gizmox.WebGUI.Forms.Label lblSearchData;
        private Gizmox.WebGUI.Forms.ColumnHeader colHeaderId;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxType;
        private Gizmox.WebGUI.Forms.ColumnHeader colReason;
        private Gizmox.WebGUI.Forms.ColumnHeader colEffectiveDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdate;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}