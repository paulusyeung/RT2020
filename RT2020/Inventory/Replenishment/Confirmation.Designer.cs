namespace RT2020.Inventory.Replenishment
{
    partial class Confirmation
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
            this.btnConfirm = new Gizmox.WebGUI.Forms.Button();
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
            this.colPostingStatus = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxferDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCompDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colToWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colErrorMsg = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnExit_P = new Gizmox.WebGUI.Forms.Button();
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
            this.lblTxNumber.Text = "Please input a Replenishment Number for searching :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(658, 471);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnPost_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(627, 58);
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
            "Tx Date",
            "Txfer Date",
            "Complete Date",
            "From Loc#",
            "To Loc#",
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
            this.colPostingStatus,
            this.colLN,
            this.colTxNumber,
            this.colTxDate,
            this.colTxferDate,
            this.colCompDate,
            this.colFromWorkplace,
            this.colToWorkplace,
            this.colLastUpdated,
            this.colErrorMsg});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(15, 58);
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
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 70;
            // 
            // colTxferDate
            // 
            this.colTxferDate.Image = null;
            this.colTxferDate.Text = "Txfer Date";
            this.colTxferDate.Width = 70;
            // 
            // colCompDate
            // 
            this.colCompDate.Image = null;
            this.colCompDate.Text = "Completed Date";
            this.colCompDate.Width = 70;
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
            // colLastUpdated
            // 
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
            // 
            // colErrorMsg
            // 
            this.colErrorMsg.Image = null;
            this.colErrorMsg.Text = "Error Message";
            this.colErrorMsg.Width = 150;
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
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.Icon = null;
            // 
            // Confirmation
            // 
            this.Controls.Add(this.btnExit_P);
            this.Controls.Add(this.lvPostTxList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMarkAll);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxNumber);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(758, 546);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replenishment > Confirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Button btnConfirm;
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
        private Gizmox.WebGUI.Forms.ColumnHeader colPostingStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxferDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colCompDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colToWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.Button btnExit_P;
        private Gizmox.WebGUI.Forms.ColumnHeader colErrorMsg;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}