namespace RT2020.Inventory.StockTake
{
    partial class HHTDataReviewAndSummation
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.gbHHTDataList = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblMessage = new Gizmox.WebGUI.Forms.Label();
            this.dgvDataList = new Gizmox.WebGUI.Forms.DataGridView();
            this.colHeaderId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colPost = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.colDelete = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.colTxNumber = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colHHTID = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colUploadedOn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colTotalLine = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colTotalQty = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colLastUser = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnSummation = new Gizmox.WebGUI.Forms.Button();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.gbHHTDataList);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(831, 611);
            this.mainPane.TabIndex = 0;
            // 
            // gbHHTDataList
            // 
            this.gbHHTDataList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.gbHHTDataList.Controls.Add(this.lblMessage);
            this.gbHHTDataList.Controls.Add(this.dgvDataList);
            this.gbHHTDataList.Controls.Add(this.btnExit);
            this.gbHHTDataList.Controls.Add(this.btnSummation);
            this.gbHHTDataList.Controls.Add(this.btnMarkAll);
            this.gbHHTDataList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gbHHTDataList.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbHHTDataList.Location = new System.Drawing.Point(6, 6);
            this.gbHHTDataList.Name = "gbHHTDataList";
            this.gbHHTDataList.Size = new System.Drawing.Size(819, 599);
            this.gbHHTDataList.TabIndex = 0;
            this.gbHHTDataList.Text = "HHT Data List";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(6, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(699, 17);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "** Please RUN \'Re-capture On-Hand Quantity\' after Summation process completed **";
            // 
            // dgvDataList
            // 
            this.dgvDataList.AllowUserToAddRows = false;
            this.dgvDataList.AllowUserToDeleteRows = false;
            this.dgvDataList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvDataList.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.colHeaderId,
            this.colPost,
            this.colDelete,
            this.colTxNumber,
            this.colHHTID,
            this.colUploadedOn,
            this.colLocation,
            this.colTotalLine,
            this.colTotalQty,
            this.colLastUser});
            this.dgvDataList.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvDataList.Location = new System.Drawing.Point(6, 46);
            this.dgvDataList.MultiSelect = false;
            this.dgvDataList.Name = "dgvDataList";
            this.dgvDataList.RowHeadersVisible = false;
            this.dgvDataList.RowHeadersWidth = 20;
            this.dgvDataList.RowTemplate.Height = 9;
            this.dgvDataList.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataList.ShowEditingIcon = false;
            this.dgvDataList.Size = new System.Drawing.Size(699, 547);
            this.dgvDataList.TabIndex = 4;
            this.dgvDataList.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellContentClick);
            this.dgvDataList.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellDoubleClick);
            // 
            // colHeaderId
            // 
            this.colHeaderId.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colHeaderId.DataPropertyName = "HeaderId";
            this.colHeaderId.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colHeaderId.HeaderText = "HeaderId";
            this.colHeaderId.MaxInputLength = -1;
            this.colHeaderId.Name = "colHeaderId";
            this.colHeaderId.ReadOnly = true;
            this.colHeaderId.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colHeaderId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colHeaderId.Visible = false;
            this.colHeaderId.Width = 100;
            // 
            // colPost
            // 
            this.colPost.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colPost.DataPropertyName = "Post";
            this.colPost.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colPost.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.colPost.HeaderText = "Post";
            this.colPost.Name = "colPost";
            this.colPost.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.colPost.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPost.Width = 50;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colDelete.DataPropertyName = "Delete";
            this.colDelete.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.colDelete.HeaderText = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.colDelete.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDelete.Width = 50;
            // 
            // colTxNumber
            // 
            this.colTxNumber.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colTxNumber.DataPropertyName = "TxNumber";
            this.colTxNumber.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colTxNumber.HeaderText = "TxNumber";
            this.colTxNumber.MaxInputLength = -1;
            this.colTxNumber.Name = "colTxNumber";
            this.colTxNumber.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colTxNumber.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTxNumber.Width = 90;
            // 
            // colHHTID
            // 
            this.colHHTID.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colHHTID.DataPropertyName = "HHTId";
            this.colHHTID.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colHHTID.HeaderText = "HHTID";
            this.colHHTID.MaxInputLength = -1;
            this.colHHTID.Name = "colHHTID";
            this.colHHTID.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colHHTID.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colHHTID.Width = 50;
            // 
            // colUploadedOn
            // 
            this.colUploadedOn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colUploadedOn.DataPropertyName = "UploadedOn";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.NullValue = null;
            this.colUploadedOn.DefaultCellStyle = dataGridViewCellStyle1;
            this.colUploadedOn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colUploadedOn.HeaderText = "Upload Date";
            this.colUploadedOn.MaxInputLength = -1;
            this.colUploadedOn.Name = "colUploadedOn";
            this.colUploadedOn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colUploadedOn.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUploadedOn.Width = 90;
            // 
            // colLocation
            // 
            this.colLocation.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colLocation.DataPropertyName = "WorkplaceCode";
            this.colLocation.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colLocation.HeaderText = "Location";
            this.colLocation.MaxInputLength = -1;
            this.colLocation.Name = "colLocation";
            this.colLocation.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colLocation.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLocation.Width = 60;
            // 
            // colTotalLine
            // 
            this.colTotalLine.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colTotalLine.DataPropertyName = "TotalRows";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle2.NullValue = null;
            this.colTotalLine.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotalLine.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colTotalLine.HeaderText = "Total Line";
            this.colTotalLine.MaxInputLength = -1;
            this.colTotalLine.Name = "colTotalLine";
            this.colTotalLine.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colTotalLine.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTotalLine.Width = 80;
            // 
            // colTotalQty
            // 
            this.colTotalQty.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colTotalQty.DataPropertyName = "TOTALQTY";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle3.NullValue = null;
            this.colTotalQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotalQty.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colTotalQty.HeaderText = "Total Qty";
            this.colTotalQty.MaxInputLength = -1;
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colTotalQty.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTotalQty.Width = 80;
            // 
            // colLastUser
            // 
            this.colLastUser.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colLastUser.DataPropertyName = "ModifiedBy";
            this.colLastUser.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colLastUser.HeaderText = "Last User";
            this.colLastUser.MaxInputLength = -1;
            this.colLastUser.Name = "colLastUser";
            this.colLastUser.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colLastUser.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLastUser.Width = 80;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(724, 539);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSummation
            // 
            this.btnSummation.Location = new System.Drawing.Point(724, 508);
            this.btnSummation.Name = "btnSummation";
            this.btnSummation.Size = new System.Drawing.Size(75, 23);
            this.btnSummation.TabIndex = 2;
            this.btnSummation.Text = "Summation";
            this.btnSummation.Click += new System.EventHandler(this.btnSummation_Click);
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(724, 477);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 1;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // HHTDataReviewAndSummation
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.mainPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(831, 611);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "HHT Data Review And Summation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.GroupBox gbHHTDataList;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnSummation;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.DataGridView dgvDataList;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colHeaderId;
        private Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn colPost;
        private Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn colDelete;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colTxNumber;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colHHTID;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colUploadedOn;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colLocation;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colTotalLine;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colTotalQty;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colLastUser;
        private Gizmox.WebGUI.Forms.Label lblMessage;


    }
}