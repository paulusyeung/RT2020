namespace RT2020.Staff.Reports
{
    partial class RptStaffList
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
            this.lblFrmStaff = new Gizmox.WebGUI.Forms.Label();
            this.lblToStaffCode = new Gizmox.WebGUI.Forms.Label();
            this.cmbFrmStaffCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbToStaffCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCopies = new Gizmox.WebGUI.Forms.Label();
            this.txtNum = new Gizmox.WebGUI.Forms.TextBox();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblFrmStaff
            // 
            this.lblFrmStaff.Location = new System.Drawing.Point(30, 31);
            this.lblFrmStaff.Name = "lblFrmStaff";
            this.lblFrmStaff.Size = new System.Drawing.Size(100, 23);
            this.lblFrmStaff.TabIndex = 0;
            this.lblFrmStaff.TabStop = false;
            this.lblFrmStaff.Text = "From Staff#";
            // 
            // lblToStaffCode
            // 
            this.lblToStaffCode.Location = new System.Drawing.Point(30, 62);
            this.lblToStaffCode.Name = "lblToStaffCode";
            this.lblToStaffCode.Size = new System.Drawing.Size(100, 23);
            this.lblToStaffCode.TabIndex = 0;
            this.lblToStaffCode.TabStop = false;
            this.lblToStaffCode.Text = "To Staff#";
            // 
            // cmbFrmStaffCode
            // 
            this.cmbFrmStaffCode.DropDownWidth = 121;
            this.cmbFrmStaffCode.Location = new System.Drawing.Point(136, 28);
            this.cmbFrmStaffCode.Name = "cmbFrmStaffCode";
            this.cmbFrmStaffCode.Size = new System.Drawing.Size(121, 21);
            this.cmbFrmStaffCode.TabIndex = 0;
            // 
            // cmbToStaffCode
            // 
            this.cmbToStaffCode.DropDownWidth = 121;
            this.cmbToStaffCode.Location = new System.Drawing.Point(136, 59);
            this.cmbToStaffCode.Name = "cmbToStaffCode";
            this.cmbToStaffCode.Size = new System.Drawing.Size(121, 21);
            this.cmbToStaffCode.TabIndex = 1;
            // 
            // lblCopies
            // 
            this.lblCopies.Location = new System.Drawing.Point(16, 146);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(100, 23);
            this.lblCopies.TabIndex = 0;
            this.lblCopies.TabStop = false;
            this.lblCopies.Text = "Copies";
            this.lblCopies.Visible = false;
            // 
            // txtNum
            // 
            this.txtNum.Enabled = false;
            this.txtNum.Location = new System.Drawing.Point(122, 143);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(121, 20);
            this.txtNum.TabIndex = 2;
            this.txtNum.Text = "1";
            this.txtNum.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(180, 140);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(99, 140);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Preview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnXLS);
            this.groupBox1.Controls.Add(this.rbnPrinter);
            this.groupBox1.Controls.Add(this.rbnPDF);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(327, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 41);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 4;
            this.rbnXLS.Text = "Print to XLS";
            // 
            // rbnPrinter
            // 
            this.rbnPrinter.Enabled = false;
            this.rbnPrinter.Location = new System.Drawing.Point(18, 65);
            this.rbnPrinter.Name = "rbnPrinter";
            this.rbnPrinter.Size = new System.Drawing.Size(104, 24);
            this.rbnPrinter.TabIndex = 5;
            this.rbnPrinter.Text = "Print to Printer";
            // 
            // rbnPDF
            // 
            this.rbnPDF.Checked = true;
            this.rbnPDF.Location = new System.Drawing.Point(18, 18);
            this.rbnPDF.Name = "rbnPDF";
            this.rbnPDF.Size = new System.Drawing.Size(104, 24);
            this.rbnPDF.TabIndex = 3;
            this.rbnPDF.Text = "Print to PDF";
            // 
            // RptStaffList
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.cmbToStaffCode);
            this.Controls.Add(this.cmbFrmStaffCode);
            this.Controls.Add(this.lblToStaffCode);
            this.Controls.Add(this.lblFrmStaff);
            this.Size = new System.Drawing.Size(291, 207);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Staff List Printing Wizard";
            this.Load += new System.EventHandler(this.frmStaffList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFrmStaff;
        private Gizmox.WebGUI.Forms.Label lblToStaffCode;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrmStaffCode;
        private Gizmox.WebGUI.Forms.ComboBox cmbToStaffCode;
        private Gizmox.WebGUI.Forms.Label lblCopies;
        private Gizmox.WebGUI.Forms.TextBox txtNum;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;


    }
}