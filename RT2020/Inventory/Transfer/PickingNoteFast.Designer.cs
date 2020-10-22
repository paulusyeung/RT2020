namespace RT2020.Inventory.Transfer
{
    partial class PickingNoteFast
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpCompDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxferDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.cboOperatorCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboFromLocation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFromLocation = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblTransactionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblCompletionDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxferDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOperatorCode = new Gizmox.WebGUI.Forms.Label();
            this.lblToLocation = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.dgvToLocation = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnInfo = new Gizmox.WebGUI.Forms.Button();
            this.btnSelectAll = new Gizmox.WebGUI.Forms.Button();
            this.btnClearAll = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnGenerate = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(122, 69);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(337, 20);
            this.txtRemarks.TabIndex = 17;
            // 
            // dtpTxDate
            // 
            this.dtpTxDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDate.Location = new System.Drawing.Point(122, 138);
            this.dtpTxDate.Name = "dtpTxDate";
            this.dtpTxDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxDate.TabIndex = 16;
            // 
            // dtpCompDate
            // 
            this.dtpCompDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpCompDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpCompDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCompDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpCompDate.Location = new System.Drawing.Point(122, 115);
            this.dtpCompDate.Name = "dtpCompDate";
            this.dtpCompDate.Size = new System.Drawing.Size(132, 20);
            this.dtpCompDate.TabIndex = 15;
            // 
            // dtpTxferDate
            // 
            this.dtpTxferDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpTxferDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxferDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTxferDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxferDate.Location = new System.Drawing.Point(122, 92);
            this.dtpTxferDate.Name = "dtpTxferDate";
            this.dtpTxferDate.Size = new System.Drawing.Size(132, 20);
            this.dtpTxferDate.TabIndex = 14;
            // 
            // cboOperatorCode
            // 
            this.cboOperatorCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboOperatorCode.DropDownWidth = 215;
            this.cboOperatorCode.Location = new System.Drawing.Point(122, 46);
            this.cboOperatorCode.Name = "cboOperatorCode";
            this.cboOperatorCode.Size = new System.Drawing.Size(337, 21);
            this.cboOperatorCode.TabIndex = 13;
            this.cboOperatorCode.TextChanged += new System.EventHandler(this.cboOperatorCode_TextChanged);
            // 
            // cboFromLocation
            // 
            this.cboFromLocation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboFromLocation.DropDownWidth = 215;
            this.cboFromLocation.Location = new System.Drawing.Point(122, 23);
            this.cboFromLocation.Name = "cboFromLocation";
            this.cboFromLocation.Size = new System.Drawing.Size(337, 21);
            this.cboFromLocation.TabIndex = 11;
            this.cboFromLocation.SelectedIndexChanged += new System.EventHandler(this.cboFromLocation_SelectedIndexChanged);
            this.cboFromLocation.TextChanged += new System.EventHandler(this.cboFromLocation_TextChanged);
            // 
            // lblFromLocation
            // 
            this.lblFromLocation.Location = new System.Drawing.Point(16, 26);
            this.lblFromLocation.Name = "lblFromLocation";
            this.lblFromLocation.Size = new System.Drawing.Size(100, 23);
            this.lblFromLocation.TabIndex = 6;
            this.lblFromLocation.Text = "From Location";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(16, 72);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Location = new System.Drawing.Point(16, 140);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(100, 23);
            this.lblTransactionDate.TabIndex = 4;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.Location = new System.Drawing.Point(16, 117);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(100, 23);
            this.lblCompletionDate.TabIndex = 3;
            this.lblCompletionDate.Text = "Completion Date";
            // 
            // lblTxferDate
            // 
            this.lblTxferDate.Location = new System.Drawing.Point(16, 94);
            this.lblTxferDate.Name = "lblTxferDate";
            this.lblTxferDate.Size = new System.Drawing.Size(100, 23);
            this.lblTxferDate.TabIndex = 2;
            this.lblTxferDate.Text = "Transfer Date";
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Location = new System.Drawing.Point(16, 49);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.lblOperatorCode.Size = new System.Drawing.Size(100, 23);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.Text = "Operator Code";
            // 
            // lblToLocation
            // 
            this.lblToLocation.Location = new System.Drawing.Point(16, 162);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(100, 23);
            this.lblToLocation.TabIndex = 0;
            this.lblToLocation.Text = "To Location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvToLocation);
            this.groupBox1.Controls.Add(this.btnInfo);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.lblFromLocation);
            this.groupBox1.Controls.Add(this.lblToLocation);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.lblOperatorCode);
            this.groupBox1.Controls.Add(this.dtpTxDate);
            this.groupBox1.Controls.Add(this.lblTxferDate);
            this.groupBox1.Controls.Add(this.dtpCompDate);
            this.groupBox1.Controls.Add(this.lblCompletionDate);
            this.groupBox1.Controls.Add(this.dtpTxferDate);
            this.groupBox1.Controls.Add(this.lblTransactionDate);
            this.groupBox1.Controls.Add(this.cboOperatorCode);
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Controls.Add(this.cboFromLocation);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 451);
            this.groupBox1.TabIndex = 18;
            // 
            // dgvToLocation
            // 
            this.dgvToLocation.AllowUserToAddRows = false;
            this.dgvToLocation.AllowUserToDeleteRows = false;
            this.dgvToLocation.AllowUserToResizeRows = false;
            this.dgvToLocation.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvToLocation.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.colStatus,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvToLocation.Location = new System.Drawing.Point(122, 162);
            this.dgvToLocation.Name = "dgvToLocation";
            this.dgvToLocation.RowHeadersWidth = 50;
            this.dgvToLocation.RowTemplate.Height = 9;
            this.dgvToLocation.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToLocation.Size = new System.Drawing.Size(337, 245);
            this.dgvToLocation.TabIndex = 22;
            this.dgvToLocation.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvToLocation_CellClick);
            this.dgvToLocation.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.dgvToLocation_KeyPress);
            this.dgvToLocation.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvToLocation_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ZoneId";
            this.dataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn1.HeaderText = "ZoneId";
            this.dataGridViewTextBoxColumn1.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 100;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RowNum";
            this.dataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn3.HeaderText = "LN";
            this.dataGridViewTextBoxColumn3.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Shop";
            this.dataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn2.HeaderText = "Shop";
            this.dataGridViewTextBoxColumn2.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.colStatus.DataPropertyName = "SelStatus";
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStatus.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.colStatus.HeaderText = "Status";
            this.colStatus.MaxInputLength = -1;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NumberOfPN";
            this.dataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn4.HeaderText = "Number Of PN";
            this.dataGridViewTextBoxColumn4.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.dataGridViewTextBoxColumn5.HeaderText = "Result";
            this.dataGridViewTextBoxColumn5.MaxInputLength = -1;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Width = 100;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(265, 413);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(32, 23);
            this.btnInfo.TabIndex = 21;
            this.btnInfo.Text = "?";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(303, 413);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 20;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(384, 413);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 19;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(396, 469);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(315, 469);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // PickingNoteFast
            // 
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(489, 504);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer > Picking Note > Fast";
            ((System.ComponentModel.ISupportInitialize)(this.dgvToLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpCompDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxferDate;
        private Gizmox.WebGUI.Forms.ComboBox cboOperatorCode;
        private Gizmox.WebGUI.Forms.ComboBox cboFromLocation;
        private Gizmox.WebGUI.Forms.Label lblFromLocation;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblTransactionDate;
        private Gizmox.WebGUI.Forms.Label lblCompletionDate;
        private Gizmox.WebGUI.Forms.Label lblTxferDate;
        private Gizmox.WebGUI.Forms.Label lblOperatorCode;
        private Gizmox.WebGUI.Forms.Label lblToLocation;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnGenerate;
        private Gizmox.WebGUI.Forms.Button btnInfo;
        private Gizmox.WebGUI.Forms.Button btnSelectAll;
        private Gizmox.WebGUI.Forms.Button btnClearAll;
        private Gizmox.WebGUI.Forms.DataGridView dgvToLocation;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn colStatus;


    }
}