namespace RT2020.Member.Reports
{
    partial class RptVipCommtListForm
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
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cmbFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtCopies = new Gizmox.WebGUI.Forms.TextBox();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblFromCommencementDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpToCommencementDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.dtpFromCommencementDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblToCommencementDate = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(13, 21);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From VIP#";
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 46);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 2;
            this.rbnXLS.Text = "Print to XLS";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(13, 56);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(92, 23);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To VIP#";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copies";
            this.label1.Visible = false;
            // 
            // cmbFrom
            // 
            this.cmbFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbFrom.DropDownWidth = 121;
            this.cmbFrom.Location = new System.Drawing.Point(166, 18);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(120, 21);
            this.cmbFrom.TabIndex = 1;
            // 
            // cmbTo
            // 
            this.cmbTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTo.DropDownWidth = 121;
            this.cmbTo.Location = new System.Drawing.Point(166, 55);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(120, 21);
            this.cmbTo.TabIndex = 2;
            // 
            // txtCopies
            // 
            this.txtCopies.Enabled = false;
            this.txtCopies.Location = new System.Drawing.Point(166, 236);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(120, 20);
            this.txtCopies.TabIndex = 3;
            this.txtCopies.Text = "1";
            this.txtCopies.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnXLS);
            this.groupBox1.Controls.Add(this.rbnPrinter);
            this.groupBox1.Controls.Add(this.rbnPDF);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(375, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
            // 
            // rbnPrinter
            // 
            this.rbnPrinter.Enabled = false;
            this.rbnPrinter.Location = new System.Drawing.Point(18, 70);
            this.rbnPrinter.Name = "rbnPrinter";
            this.rbnPrinter.Size = new System.Drawing.Size(104, 24);
            this.rbnPrinter.TabIndex = 1;
            this.rbnPrinter.Text = "Print to Printer";
            // 
            // rbnPDF
            // 
            this.rbnPDF.Checked = true;
            this.rbnPDF.Location = new System.Drawing.Point(18, 22);
            this.rbnPDF.Name = "rbnPDF";
            this.rbnPDF.Size = new System.Drawing.Size(104, 24);
            this.rbnPDF.TabIndex = 0;
            this.rbnPDF.Text = "Print to PDF";
            // 
            // lblFromCommencementDate
            // 
            this.lblFromCommencementDate.Location = new System.Drawing.Point(13, 90);
            this.lblFromCommencementDate.Name = "lblFromCommencementDate";
            this.lblFromCommencementDate.Size = new System.Drawing.Size(141, 23);
            this.lblFromCommencementDate.TabIndex = 8;
            this.lblFromCommencementDate.Text = "From Commencement Date";
            // 
            // dtpToCommencementDate
            // 
            this.dtpToCommencementDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToCommencementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToCommencementDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToCommencementDate.Location = new System.Drawing.Point(166, 119);
            this.dtpToCommencementDate.Name = "dtpToCommencementDate";
            this.dtpToCommencementDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToCommencementDate.TabIndex = 11;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(120, 163);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Priview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // dtpFromCommencementDate
            // 
            this.dtpFromCommencementDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromCommencementDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromCommencementDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromCommencementDate.Location = new System.Drawing.Point(166, 87);
            this.dtpFromCommencementDate.Name = "dtpFromCommencementDate";
            this.dtpFromCommencementDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromCommencementDate.TabIndex = 10;
            // 
            // lblToCommencementDate
            // 
            this.lblToCommencementDate.Location = new System.Drawing.Point(13, 122);
            this.lblToCommencementDate.Name = "lblToCommencementDate";
            this.lblToCommencementDate.Size = new System.Drawing.Size(141, 23);
            this.lblToCommencementDate.TabIndex = 9;
            this.lblToCommencementDate.Text = "To Commencement Date";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(212, 163);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // RptVipCommtListForm
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblToCommencementDate);
            this.Controls.Add(this.dtpFromCommencementDate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpToCommencementDate);
            this.Controls.Add(this.lblFromCommencementDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Size = new System.Drawing.Size(317, 211);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Commencement List Printing Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrom;
        private Gizmox.WebGUI.Forms.ComboBox cmbTo;
        private Gizmox.WebGUI.Forms.TextBox txtCopies;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;
        private Gizmox.WebGUI.Forms.Label lblFromCommencementDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToCommencementDate;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromCommencementDate;
        private Gizmox.WebGUI.Forms.Label lblToCommencementDate;
        private Gizmox.WebGUI.Forms.Button btnExit;


    }
}