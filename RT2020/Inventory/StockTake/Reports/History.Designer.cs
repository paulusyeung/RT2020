namespace RT2020.Inventory.StockTake.Reports
{
    partial class History
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
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtTxNumberTo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTxNumberFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpTxDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTxDateTo = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDateFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDate = new Gizmox.WebGUI.Forms.Label();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(399, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Cancel";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(318, 130);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdPreview.TabIndex = 3;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTxNumberTo);
            this.groupBox2.Controls.Add(this.txtTxNumberFrom);
            this.groupBox2.Controls.Add(this.dtpTxDateTo);
            this.groupBox2.Controls.Add(this.dtpTxDateFrom);
            this.groupBox2.Controls.Add(this.lblTxDateTo);
            this.groupBox2.Controls.Add(this.lblTxDateFrom);
            this.groupBox2.Controls.Add(this.lblTxDate);
            this.groupBox2.Controls.Add(this.lblTxNumber);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // txtTxNumberTo
            // 
            this.txtTxNumberTo.Location = new System.Drawing.Point(75, 63);
            this.txtTxNumberTo.Name = "txtTxNumberTo";
            this.txtTxNumberTo.Size = new System.Drawing.Size(140, 20);
            this.txtTxNumberTo.TabIndex = 1;
            this.txtTxNumberTo.Text = "zz";
            // 
            // txtTxNumberFrom
            // 
            this.txtTxNumberFrom.Location = new System.Drawing.Point(75, 37);
            this.txtTxNumberFrom.Name = "txtTxNumberFrom";
            this.txtTxNumberFrom.Size = new System.Drawing.Size(140, 20);
            this.txtTxNumberFrom.TabIndex = 0;
            this.txtTxNumberFrom.Text = "00";
            // 
            // dtpTxDateTo
            // 
            this.dtpTxDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateTo.Location = new System.Drawing.Point(305, 62);
            this.dtpTxDateTo.Name = "dtpTxDateTo";
            this.dtpTxDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpTxDateTo.TabIndex = 3;
            // 
            // dtpTxDateFrom
            // 
            this.dtpTxDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateFrom.Location = new System.Drawing.Point(305, 39);
            this.dtpTxDateFrom.Name = "dtpTxDateFrom";
            this.dtpTxDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpTxDateFrom.TabIndex = 2;
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.Location = new System.Drawing.Point(253, 66);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Size = new System.Drawing.Size(42, 18);
            this.lblTxDateTo.TabIndex = 9;
            this.lblTxDateTo.TabStop = false;
            this.lblTxDateTo.Text = "To";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.Location = new System.Drawing.Point(253, 43);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Size = new System.Drawing.Size(46, 15);
            this.lblTxDateFrom.TabIndex = 8;
            this.lblTxDateFrom.TabStop = false;
            this.lblTxDateFrom.Text = "From";
            // 
            // lblTxDate
            // 
            this.lblTxDate.Location = new System.Drawing.Point(239, 19);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Size = new System.Drawing.Size(60, 17);
            this.lblTxDate.TabIndex = 7;
            this.lblTxDate.TabStop = false;
            this.lblTxDate.Text = "Tx Date:";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(15, 19);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(64, 17);
            this.lblTxNumber.TabIndex = 6;
            this.lblTxNumber.TabStop = false;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(28, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 18);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(28, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 18);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // History
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.btnExit);
            this.Size = new System.Drawing.Size(481, 168);
            this.Text = "History";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button cmdPreview;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumberTo;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumberFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateFrom;
        private Gizmox.WebGUI.Forms.Label lblTxDateTo;
        private Gizmox.WebGUI.Forms.Label lblTxDateFrom;
        private Gizmox.WebGUI.Forms.Label lblTxDate;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;


    }
}