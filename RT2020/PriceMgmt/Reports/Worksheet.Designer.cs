namespace RT2020.PriceMgmt.Reports
{
    partial class Worksheet
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpTxDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpTxDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSTkTo = new Gizmox.WebGUI.Forms.Label();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.lblMonth = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnPriview = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpTxDateTo);
            this.groupBox1.Controls.Add(this.dtpTxDateFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSTkFrom);
            this.groupBox1.Controls.Add(this.lblSTkTo);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.cboFrom);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.Text = "Selections";
            // 
            // dtpTxDateTo
            // 
            this.dtpTxDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateTo.Location = new System.Drawing.Point(87, 141);
            this.dtpTxDateTo.Name = "dtpTxDateTo";
            this.dtpTxDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTxDateTo.TabIndex = 10;
            // 
            // dtpTxDateFrom
            // 
            this.dtpTxDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateFrom.Location = new System.Drawing.Point(87, 98);
            this.dtpTxDateFrom.Name = "dtpTxDateFrom";
            this.dtpTxDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpTxDateFrom.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(188, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "(dd/mm/yyyy)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(188, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "(dd/mm/yyyy)";
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(12, 27);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(72, 23);
            this.lblSTkFrom.TabIndex = 0;
            this.lblSTkFrom.Text = "From TRN# :";
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(12, 64);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(72, 23);
            this.lblSTkTo.TabIndex = 1;
            this.lblSTkTo.Text = "To TRN# :";
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(12, 103);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(72, 23);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "From Data :";
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(12, 141);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(72, 23);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "To Data :";
            // 
            // cboFrom
            // 
            this.cboFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFrom.Location = new System.Drawing.Point(87, 24);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(175, 21);
            this.cboFrom.TabIndex = 4;
            // 
            // cboTo
            // 
            this.cboTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTo.Location = new System.Drawing.Point(87, 61);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(175, 21);
            this.cboTo.TabIndex = 5;
            // 
            // btnPriview
            // 
            this.btnPriview.Location = new System.Drawing.Point(132, 215);
            this.btnPriview.Name = "btnPriview";
            this.btnPriview.Size = new System.Drawing.Size(75, 23);
            this.btnPriview.TabIndex = 10;
            this.btnPriview.Text = "Priview";
            this.btnPriview.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Worksheet
            // 
            this.AcceptButton = this.btnPriview;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPriview);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(303, 249);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worksheet";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateFrom;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label lblSTkFrom;
        private Gizmox.WebGUI.Forms.Label lblSTkTo;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Button btnPriview;
        private Gizmox.WebGUI.Forms.Button btnCancel;




    }
}