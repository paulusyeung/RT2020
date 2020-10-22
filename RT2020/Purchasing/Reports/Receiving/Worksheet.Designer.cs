namespace RT2020.Purchasing.Reports.Receiving
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
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTxDateTo = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDateFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblSelectDate = new Gizmox.WebGUI.Forms.Label();
            this.lblOrderNumber = new Gizmox.WebGUI.Forms.Label();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.cmdPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdExcel = new Gizmox.WebGUI.Forms.Button();
            this.cmdPDF = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.ClientAction = null;
            this.groupBox2.Controls.Add(this.dtpDateTo);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Controls.Add(this.lblTxDateTo);
            this.groupBox2.Controls.Add(this.lblTxDateFrom);
            this.groupBox2.Controls.Add(this.lblSelectDate);
            this.groupBox2.Controls.Add(this.lblOrderNumber);
            this.groupBox2.Controls.Add(this.cboTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cboFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDateTo.ClientAction = null;
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(294, 63);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpDateTo.TabIndex = 3;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDateFrom.ClientAction = null;
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(294, 38);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.ClientAction = null;
            this.lblTxDateTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTxDateTo.Location = new System.Drawing.Point(242, 66);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Size = new System.Drawing.Size(42, 18);
            this.lblTxDateTo.TabIndex = 9;
            this.lblTxDateTo.TabStop = false;
            this.lblTxDateTo.Text = "To";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.ClientAction = null;
            this.lblTxDateFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTxDateFrom.Location = new System.Drawing.Point(242, 41);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Size = new System.Drawing.Size(46, 15);
            this.lblTxDateFrom.TabIndex = 8;
            this.lblTxDateFrom.TabStop = false;
            this.lblTxDateFrom.Text = "From";
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.ClientAction = null;
            this.lblSelectDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSelectDate.Location = new System.Drawing.Point(228, 19);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(82, 17);
            this.lblSelectDate.TabIndex = 7;
            this.lblSelectDate.TabStop = false;
            this.lblSelectDate.Text = "Select Date:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.ClientAction = null;
            this.lblOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblOrderNumber.Location = new System.Drawing.Point(15, 19);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(84, 17);
            this.lblOrderNumber.TabIndex = 6;
            this.lblOrderNumber.TabStop = false;
            this.lblOrderNumber.Text = "Rec.#  Number:";
            // 
            // cboTo
            // 
            this.cboTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTo.ClientAction = null;
            this.cboTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboTo.DropDownWidth = 143;
            this.cboTo.Location = new System.Drawing.Point(75, 63);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(140, 21);
            this.cboTo.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.ClientAction = null;
            this.lblFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblFrom.Location = new System.Drawing.Point(28, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 18);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // cboFrom
            // 
            this.cboFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFrom.ClientAction = null;
            this.cboFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboFrom.DropDownWidth = 143;
            this.cboFrom.Location = new System.Drawing.Point(75, 38);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(140, 21);
            this.cboFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.ClientAction = null;
            this.lblTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTo.Location = new System.Drawing.Point(28, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 18);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // btnExit
            // 
            this.btnExit.ClientAction = null;
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(329, 136);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.ClientAction = null;
            this.cmdPreview.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdPreview.Location = new System.Drawing.Point(246, 136);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdPreview.Click += new System.EventHandler(this.CmdPreview_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.ClientAction = null;
            this.cmdExcel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdExcel.Location = new System.Drawing.Point(163, 136);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(75, 23);
            this.cmdExcel.TabIndex = 4;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            // 
            // cmdPDF
            // 
            this.cmdPDF.ClientAction = null;
            this.cmdPDF.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdPDF.Location = new System.Drawing.Point(80, 136);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdPDF.TabIndex = 4;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdPDF.Click += new System.EventHandler(this.CmdPDF_Click);
            // 
            // Worksheet
            // 
            this.Controls.Add(this.cmdPDF);
            this.Controls.Add(this.cmdExcel);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(484, 194);
            this.Text = "Purchase Order > Reports > Receiving > Worksheet";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpDateFrom;
        private Gizmox.WebGUI.Forms.Label lblTxDateTo;
        private Gizmox.WebGUI.Forms.Label lblTxDateFrom;
        private Gizmox.WebGUI.Forms.Label lblSelectDate;
        private Gizmox.WebGUI.Forms.Label lblOrderNumber;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button cmdPreview;
        private Gizmox.WebGUI.Forms.Button cmdExcel;
        private Gizmox.WebGUI.Forms.Button cmdPDF;
    }
}