namespace RT2020.Member.Reports
{
    partial class RptVipExpireListForm
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
            this.dtpToExpiryDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFromExpiryDate = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblToExpiryDate = new Gizmox.WebGUI.Forms.Label();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.dtpFromExpiryDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.txtCopies = new Gizmox.WebGUI.Forms.TextBox();
            this.cmbTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpToExpiryDate
            // 
            this.dtpToExpiryDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToExpiryDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToExpiryDate.Location = new System.Drawing.Point(110, 121);
            this.dtpToExpiryDate.Name = "dtpToExpiryDate";
            this.dtpToExpiryDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToExpiryDate.TabIndex = 11;
            // 
            // lblFromExpiryDate
            // 
            this.lblFromExpiryDate.Location = new System.Drawing.Point(12, 89);
            this.lblFromExpiryDate.Name = "lblFromExpiryDate";
            this.lblFromExpiryDate.Size = new System.Drawing.Size(92, 23);
            this.lblFromExpiryDate.TabIndex = 8;
            this.lblFromExpiryDate.Text = "From Expiry Date";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(156, 167);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 46);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 2;
            this.rbnXLS.Text = "Print to XLS";
            // 
            // lblToExpiryDate
            // 
            this.lblToExpiryDate.Location = new System.Drawing.Point(12, 121);
            this.lblToExpiryDate.Name = "lblToExpiryDate";
            this.lblToExpiryDate.Size = new System.Drawing.Size(92, 23);
            this.lblToExpiryDate.TabIndex = 9;
            this.lblToExpiryDate.Text = "To Expiry Date";
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
            // dtpFromExpiryDate
            // 
            this.dtpFromExpiryDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromExpiryDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromExpiryDate.Location = new System.Drawing.Point(110, 89);
            this.dtpFromExpiryDate.Name = "dtpFromExpiryDate";
            this.dtpFromExpiryDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromExpiryDate.TabIndex = 10;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(70, 167);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Priview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnXLS);
            this.groupBox1.Controls.Add(this.rbnPrinter);
            this.groupBox1.Controls.Add(this.rbnPDF);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(354, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
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
            // txtCopies
            // 
            this.txtCopies.Enabled = false;
            this.txtCopies.Location = new System.Drawing.Point(110, 243);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(120, 20);
            this.txtCopies.TabIndex = 3;
            this.txtCopies.Text = "1";
            this.txtCopies.Visible = false;
            // 
            // cmbTo
            // 
            this.cmbTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTo.DropDownWidth = 121;
            this.cmbTo.Location = new System.Drawing.Point(110, 57);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(120, 21);
            this.cmbTo.TabIndex = 2;
            // 
            // cmbFrom
            // 
            this.cmbFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbFrom.DropDownWidth = 121;
            this.cmbFrom.Location = new System.Drawing.Point(110, 20);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(120, 21);
            this.cmbFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copies";
            this.label1.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(12, 55);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(92, 23);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To VIP#";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(12, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From VIP#";
            // 
            // RptVipExpireListForm
            // 
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpFromExpiryDate);
            this.Controls.Add(this.lblToExpiryDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFromExpiryDate);
            this.Controls.Add(this.dtpToExpiryDate);
            this.Size = new System.Drawing.Size(270, 214);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Expire List Printing Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker dtpToExpiryDate;
        private Gizmox.WebGUI.Forms.Label lblFromExpiryDate;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.Label lblToExpiryDate;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromExpiryDate;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;
        private Gizmox.WebGUI.Forms.TextBox txtCopies;
        private Gizmox.WebGUI.Forms.ComboBox cmbTo;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrom;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;


    }
}