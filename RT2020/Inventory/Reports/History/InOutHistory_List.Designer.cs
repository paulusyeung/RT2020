namespace RT2020.Inventory.Reports.History
{
    partial class InOutHistory_List
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
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
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
            this.chkTakeQty = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(144, 239);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
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
            this.groupBox1.Controls.Add(this.chkTakeQty);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Selections";
            // 
            // dtpTxDateTo
            // 
            this.dtpTxDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateTo.Location = new System.Drawing.Point(121, 141);
            this.dtpTxDateTo.Name = "dtpTxDateTo";
            this.dtpTxDateTo.Size = new System.Drawing.Size(157, 20);
            this.dtpTxDateTo.TabIndex = 3;
            // 
            // dtpTxDateFrom
            // 
            this.dtpTxDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpTxDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTxDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpTxDateFrom.Location = new System.Drawing.Point(121, 98);
            this.dtpTxDateFrom.Name = "dtpTxDateFrom";
            this.dtpTxDateFrom.Size = new System.Drawing.Size(157, 20);
            this.dtpTxDateFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(121, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "(dd/mm/yyyy)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(121, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "(dd/mm/yyyy)";
            // 
            // lblSTkFrom
            // 
            this.lblSTkFrom.Location = new System.Drawing.Point(6, 27);
            this.lblSTkFrom.Name = "lblSTkFrom";
            this.lblSTkFrom.Size = new System.Drawing.Size(100, 23);
            this.lblSTkFrom.TabIndex = 5;
            this.lblSTkFrom.Text = "From Stock Code :";
            this.lblSTkFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTkTo
            // 
            this.lblSTkTo.Location = new System.Drawing.Point(9, 64);
            this.lblSTkTo.Name = "lblSTkTo";
            this.lblSTkTo.Size = new System.Drawing.Size(100, 23);
            this.lblSTkTo.TabIndex = 6;
            this.lblSTkTo.Text = "To Stock Code :";
            this.lblSTkTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(9, 103);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(100, 23);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "From Data :";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(6, 141);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(100, 23);
            this.lblMonth.TabIndex = 8;
            this.lblMonth.Text = "To Data :";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboFrom
            // 
            this.cboFrom.Location = new System.Drawing.Point(121, 24);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(157, 21);
            this.cboFrom.TabIndex = 0;
            // 
            // cboTo
            // 
            this.cboTo.Location = new System.Drawing.Point(121, 61);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(157, 21);
            this.cboTo.TabIndex = 1;
            // 
            // chkTakeQty
            // 
            this.chkTakeQty.Checked = false;
            this.chkTakeQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkTakeQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkTakeQty.Location = new System.Drawing.Point(121, 186);
            this.chkTakeQty.Name = "chkTakeQty";
            this.chkTakeQty.Size = new System.Drawing.Size(104, 24);
            this.chkTakeQty.TabIndex = 4;
            this.chkTakeQty.Text = "Show Take Qty";
            this.chkTakeQty.ThreeState = false;
            // 
            // InOutHistory_List
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnCancel);
            this.Size = new System.Drawing.Size(312, 268);
            this.Text = "In / Out History -> List";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblSTkFrom;
        private Gizmox.WebGUI.Forms.Label lblSTkTo;
        private Gizmox.WebGUI.Forms.Label lblYear;
        private Gizmox.WebGUI.Forms.Label lblMonth;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.CheckBox chkTakeQty;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpTxDateFrom;
        private Gizmox.WebGUI.Forms.Label label2;


    }
}