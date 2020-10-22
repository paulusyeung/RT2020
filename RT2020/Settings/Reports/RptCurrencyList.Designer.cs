namespace RT2020.Settings.Reports
{
    partial class RptCurrencyList
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
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.txtNum = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCopies = new Gizmox.WebGUI.Forms.Label();
            this.cmbToCurrencyCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbFrmCurrencyCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblToCurrencyCode = new Gizmox.WebGUI.Forms.Label();
            this.lblFrmCurrency = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnXLS);
            this.groupBox1.Controls.Add(this.rbnPrinter);
            this.groupBox1.Controls.Add(this.rbnPDF);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(314, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 45);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 1;
            this.rbnXLS.Text = "Print to XLS";
            // 
            // rbnPrinter
            // 
            this.rbnPrinter.Enabled = false;
            this.rbnPrinter.Location = new System.Drawing.Point(18, 69);
            this.rbnPrinter.Name = "rbnPrinter";
            this.rbnPrinter.Size = new System.Drawing.Size(104, 24);
            this.rbnPrinter.TabIndex = 2;
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
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(85, 82);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Priview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(176, 82);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtNum
            // 
            this.txtNum.Enabled = false;
            this.txtNum.Location = new System.Drawing.Point(131, 140);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(120, 20);
            this.txtNum.TabIndex = 3;
            this.txtNum.Text = "1";
            this.txtNum.Visible = false;
            // 
            // lblCopies
            // 
            this.lblCopies.Location = new System.Drawing.Point(12, 143);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(107, 23);
            this.lblCopies.TabIndex = 0;
            this.lblCopies.TabStop = false;
            this.lblCopies.Text = "Copies";
            this.lblCopies.Visible = false;
            // 
            // cmbToCurrencyCode
            // 
            this.cmbToCurrencyCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbToCurrencyCode.DropDownWidth = 121;
            this.cmbToCurrencyCode.Location = new System.Drawing.Point(130, 38);
            this.cmbToCurrencyCode.Name = "cmbToCurrencyCode";
            this.cmbToCurrencyCode.Size = new System.Drawing.Size(121, 21);
            this.cmbToCurrencyCode.TabIndex = 2;
            // 
            // cmbFrmCurrencyCode
            // 
            this.cmbFrmCurrencyCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbFrmCurrencyCode.DropDownWidth = 121;
            this.cmbFrmCurrencyCode.Location = new System.Drawing.Point(130, 9);
            this.cmbFrmCurrencyCode.Name = "cmbFrmCurrencyCode";
            this.cmbFrmCurrencyCode.Size = new System.Drawing.Size(121, 21);
            this.cmbFrmCurrencyCode.TabIndex = 1;
            // 
            // lblToCurrencyCode
            // 
            this.lblToCurrencyCode.Location = new System.Drawing.Point(12, 41);
            this.lblToCurrencyCode.Name = "lblToCurrencyCode";
            this.lblToCurrencyCode.Size = new System.Drawing.Size(107, 23);
            this.lblToCurrencyCode.TabIndex = 0;
            this.lblToCurrencyCode.TabStop = false;
            this.lblToCurrencyCode.Text = "To Currency Code";
            // 
            // lblFrmCurrency
            // 
            this.lblFrmCurrency.Location = new System.Drawing.Point(12, 12);
            this.lblFrmCurrency.Name = "lblFrmCurrency";
            this.lblFrmCurrency.Size = new System.Drawing.Size(107, 24);
            this.lblFrmCurrency.TabIndex = 0;
            this.lblFrmCurrency.TabStop = false;
            this.lblFrmCurrency.Text = "From Currency Code";
            // 
            // RptCurrencyList
            // 
            this.Controls.Add(this.lblFrmCurrency);
            this.Controls.Add(this.lblToCurrencyCode);
            this.Controls.Add(this.cmbFrmCurrencyCode);
            this.Controls.Add(this.cmbToCurrencyCode);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Size = new System.Drawing.Size(281, 124);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Currency List Printing Wizard";
            this.Load += new System.EventHandler(this.RptCurrencyList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.TextBox txtNum;
        private Gizmox.WebGUI.Forms.Label lblCopies;
        private Gizmox.WebGUI.Forms.ComboBox cmbToCurrencyCode;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrmCurrencyCode;
        private Gizmox.WebGUI.Forms.Label lblToCurrencyCode;
        private Gizmox.WebGUI.Forms.Label lblFrmCurrency;


    }
}