namespace RT2020.Inventory.StockTake.Reports
{
    partial class VarianceList
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
            this.lblFromTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblToTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblFromDate = new Gizmox.WebGUI.Forms.Label();
            this.lblToDate = new Gizmox.WebGUI.Forms.Label();
            this.cboFromTxNumber = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboToTxNumber = new Gizmox.WebGUI.Forms.ComboBox();
            this.dtpFromDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.chkIgnoreDiffZeroRecord = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFromTxNumber
            // 
            this.lblFromTxNumber.AutoSize = true;
            this.lblFromTxNumber.Location = new System.Drawing.Point(24, 18);
            this.lblFromTxNumber.Name = "lblFromTxNumber";
            this.lblFromTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblFromTxNumber.TabIndex = 0;
            this.lblFromTxNumber.Text = "From TRN#";
            // 
            // lblToTxNumber
            // 
            this.lblToTxNumber.AutoSize = true;
            this.lblToTxNumber.Location = new System.Drawing.Point(24, 45);
            this.lblToTxNumber.Name = "lblToTxNumber";
            this.lblToTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblToTxNumber.TabIndex = 1;
            this.lblToTxNumber.Text = "To TRN#";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(24, 75);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(100, 23);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(24, 101);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(100, 23);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To Date";
            // 
            // cboFromTxNumber
            // 
            this.cboFromTxNumber.Location = new System.Drawing.Point(108, 15);
            this.cboFromTxNumber.Name = "cboFromTxNumber";
            this.cboFromTxNumber.Size = new System.Drawing.Size(154, 21);
            this.cboFromTxNumber.TabIndex = 4;
            // 
            // cboToTxNumber
            // 
            this.cboToTxNumber.Location = new System.Drawing.Point(108, 42);
            this.cboToTxNumber.Name = "cboToTxNumber";
            this.cboToTxNumber.Size = new System.Drawing.Size(154, 21);
            this.cboToTxNumber.TabIndex = 5;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(108, 69);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(154, 20);
            this.dtpFromDate.TabIndex = 6;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(108, 95);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(154, 20);
            this.dtpToDate.TabIndex = 7;
            // 
            // chkIgnoreDiffZeroRecord
            // 
            this.chkIgnoreDiffZeroRecord.Checked = true;
            this.chkIgnoreDiffZeroRecord.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.chkIgnoreDiffZeroRecord.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkIgnoreDiffZeroRecord.Location = new System.Drawing.Point(108, 121);
            this.chkIgnoreDiffZeroRecord.Name = "chkIgnoreDiffZeroRecord";
            this.chkIgnoreDiffZeroRecord.Size = new System.Drawing.Size(215, 24);
            this.chkIgnoreDiffZeroRecord.TabIndex = 8;
            this.chkIgnoreDiffZeroRecord.Text = "Ignore Record(s) with Zero Differenct";
            this.chkIgnoreDiffZeroRecord.ThreeState = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(145, 165);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(248, 165);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // VarianceList
            // 
            this.CancelButton = this.btnPreview;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkIgnoreDiffZeroRecord);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cboToTxNumber);
            this.Controls.Add(this.cboFromTxNumber);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblToTxNumber);
            this.Controls.Add(this.lblFromTxNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(337, 211);
            this.Text = "VarianceList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFromTxNumber;
        private Gizmox.WebGUI.Forms.Label lblToTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFromDate;
        private Gizmox.WebGUI.Forms.Label lblToDate;
        private Gizmox.WebGUI.Forms.ComboBox cboFromTxNumber;
        private Gizmox.WebGUI.Forms.ComboBox cboToTxNumber;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToDate;
        private Gizmox.WebGUI.Forms.CheckBox chkIgnoreDiffZeroRecord;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.Button btnExit;


    }
}