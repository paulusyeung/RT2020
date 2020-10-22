namespace RT2020.Member.Reports
{
    partial class RptVipBirthdayListForm
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
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cmbFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.cmbTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtCopies = new Gizmox.WebGUI.Forms.TextBox();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lblFromBirthday = new Gizmox.WebGUI.Forms.Label();
            this.lblToBirthday = new Gizmox.WebGUI.Forms.Label();
            this.dtpFromBirthday = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpToBirthday = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.SuspendLayout();
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
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(15, 23);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From VIP#";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(15, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(92, 23);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To VIP#";
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 228);
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
            this.cmbFrom.Location = new System.Drawing.Point(113, 23);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(120, 21);
            this.cmbFrom.TabIndex = 1;
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 46);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 2;
            this.rbnXLS.Text = "Print to XLS";
            // 
            // cmbTo
            // 
            this.cmbTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTo.DropDownWidth = 121;
            this.cmbTo.Location = new System.Drawing.Point(113, 60);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(120, 21);
            this.cmbTo.TabIndex = 2;
            // 
            // txtCopies
            // 
            this.txtCopies.Enabled = false;
            this.txtCopies.Location = new System.Drawing.Point(113, 229);
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
            this.groupBox1.Location = new System.Drawing.Point(351, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(79, 168);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Priview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(159, 168);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFromBirthday
            // 
            this.lblFromBirthday.Location = new System.Drawing.Point(15, 92);
            this.lblFromBirthday.Name = "lblFromBirthday";
            this.lblFromBirthday.Size = new System.Drawing.Size(92, 23);
            this.lblFromBirthday.TabIndex = 8;
            this.lblFromBirthday.Text = "From Birthday";
            // 
            // lblToBirthday
            // 
            this.lblToBirthday.Location = new System.Drawing.Point(15, 124);
            this.lblToBirthday.Name = "lblToBirthday";
            this.lblToBirthday.Size = new System.Drawing.Size(92, 23);
            this.lblToBirthday.TabIndex = 9;
            this.lblToBirthday.Text = "To Birthday";
            // 
            // dtpFromBirthday
            // 
            this.dtpFromBirthday.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpFromBirthday.CustomFormat = "dd/MM";
            this.dtpFromBirthday.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpFromBirthday.Location = new System.Drawing.Point(113, 92);
            this.dtpFromBirthday.Name = "dtpFromBirthday";
            this.dtpFromBirthday.Size = new System.Drawing.Size(120, 20);
            this.dtpFromBirthday.TabIndex = 10;
            // 
            // dtpToBirthday
            // 
            this.dtpToBirthday.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpToBirthday.CustomFormat = "dd/MM";
            this.dtpToBirthday.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpToBirthday.Location = new System.Drawing.Point(113, 124);
            this.dtpToBirthday.Name = "dtpToBirthday";
            this.dtpToBirthday.Size = new System.Drawing.Size(120, 20);
            this.dtpToBirthday.TabIndex = 11;
            // 
            // RptVipBirthdayListForm
            // 
            this.Controls.Add(this.dtpToBirthday);
            this.Controls.Add(this.dtpFromBirthday);
            this.Controls.Add(this.lblToBirthday);
            this.Controls.Add(this.lblFromBirthday);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Size = new System.Drawing.Size(265, 214);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Birthday List Printing Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrom;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.ComboBox cmbTo;
        private Gizmox.WebGUI.Forms.TextBox txtCopies;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Label lblFromBirthday;
        private Gizmox.WebGUI.Forms.Label lblToBirthday;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpFromBirthday;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpToBirthday;


    }
}