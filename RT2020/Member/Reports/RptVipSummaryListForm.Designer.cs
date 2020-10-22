namespace RT2020.Member.Reports
{
    partial class RptVipSummaryListForm
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
            this.lblFromGroup = new Gizmox.WebGUI.Forms.Label();
            this.lblShowSalesDetail = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.txtYTDNetSalesAmountOver = new Gizmox.WebGUI.Forms.TextBox();
            this.cmbTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblYTDNetSalesAmountOver = new Gizmox.WebGUI.Forms.Label();
            this.lblTo = new Gizmox.WebGUI.Forms.Label();
            this.lblFrom = new Gizmox.WebGUI.Forms.Label();
            this.txtCopies = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbnXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPrinter = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.chkShowSalesDetail = new Gizmox.WebGUI.Forms.CheckBox();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblDateRangeTo = new Gizmox.WebGUI.Forms.Label();
            this.dtpSpecifiedRangeTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.rbtnSpecifiedRange = new Gizmox.WebGUI.Forms.RadioButton();
            this.dtpSpecifiedRangeFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.rbtnAllToDate = new Gizmox.WebGUI.Forms.RadioButton();
            this.cboFromGroup = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboToGroup = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblToGroup = new Gizmox.WebGUI.Forms.Label();
            this.gbAppendix = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkAppendix3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkAppendix2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkAppendix1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.gbSubTotal = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbnYear = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnMonth = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbnTransaction = new Gizmox.WebGUI.Forms.RadioButton();
            this.gbPriview = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtXLS = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblFromGroup
            // 
            this.lblFromGroup.Location = new System.Drawing.Point(15, 167);
            this.lblFromGroup.Name = "lblFromGroup";
            this.lblFromGroup.Size = new System.Drawing.Size(115, 23);
            this.lblFromGroup.TabIndex = 0;
            this.lblFromGroup.Text = "From Group";
            // 
            // lblShowSalesDetail
            // 
            this.lblShowSalesDetail.Location = new System.Drawing.Point(15, 234);
            this.lblShowSalesDetail.Name = "lblShowSalesDetail";
            this.lblShowSalesDetail.Size = new System.Drawing.Size(115, 23);
            this.lblShowSalesDetail.TabIndex = 10;
            this.lblShowSalesDetail.Text = "Show Sales Detail";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(367, 258);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(291, 258);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Priview";
            this.btnPrint.Click += new System.EventHandler(this.btnPriview_Click);
            // 
            // txtYTDNetSalesAmountOver
            // 
            this.txtYTDNetSalesAmountOver.Location = new System.Drawing.Point(171, 210);
            this.txtYTDNetSalesAmountOver.Name = "txtYTDNetSalesAmountOver";
            this.txtYTDNetSalesAmountOver.Size = new System.Drawing.Size(120, 20);
            this.txtYTDNetSalesAmountOver.TabIndex = 3;
            this.txtYTDNetSalesAmountOver.Text = "0";
            // 
            // cmbTo
            // 
            this.cmbTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTo.DropDownWidth = 121;
            this.cmbTo.Location = new System.Drawing.Point(171, 141);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(120, 21);
            this.cmbTo.TabIndex = 2;
            // 
            // cmbFrom
            // 
            this.cmbFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbFrom.DropDownWidth = 121;
            this.cmbFrom.Location = new System.Drawing.Point(171, 118);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(120, 21);
            this.cmbFrom.TabIndex = 1;
            // 
            // lblYTDNetSalesAmountOver
            // 
            this.lblYTDNetSalesAmountOver.Location = new System.Drawing.Point(15, 213);
            this.lblYTDNetSalesAmountOver.Name = "lblYTDNetSalesAmountOver";
            this.lblYTDNetSalesAmountOver.Size = new System.Drawing.Size(149, 23);
            this.lblYTDNetSalesAmountOver.TabIndex = 0;
            this.lblYTDNetSalesAmountOver.Text = "YTD Net Sales Amount Over";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(15, 144);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(92, 23);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "To VIP#";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(15, 121);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(92, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From VIP#";
            // 
            // txtCopies
            // 
            this.txtCopies.Enabled = false;
            this.txtCopies.Location = new System.Drawing.Point(613, 133);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(32, 20);
            this.txtCopies.TabIndex = 3;
            this.txtCopies.Text = "1";
            this.txtCopies.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(515, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copies";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnXLS);
            this.groupBox1.Controls.Add(this.rbnPrinter);
            this.groupBox1.Controls.Add(this.rbnPDF);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(504, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "Output Destination";
            this.groupBox1.Visible = false;
            // 
            // rbnXLS
            // 
            this.rbnXLS.Location = new System.Drawing.Point(18, 46);
            this.rbnXLS.Name = "rbnXLS";
            this.rbnXLS.Size = new System.Drawing.Size(104, 24);
            this.rbnXLS.TabIndex = 2;
            this.rbnXLS.Text = "Print to XLS";
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
            // chkShowSalesDetail
            // 
            this.chkShowSalesDetail.Checked = false;
            this.chkShowSalesDetail.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkShowSalesDetail.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkShowSalesDetail.Location = new System.Drawing.Point(170, 231);
            this.chkShowSalesDetail.Name = "chkShowSalesDetail";
            this.chkShowSalesDetail.Size = new System.Drawing.Size(104, 24);
            this.chkShowSalesDetail.TabIndex = 11;
            this.chkShowSalesDetail.ThreeState = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDateRangeTo);
            this.groupBox2.Controls.Add(this.dtpSpecifiedRangeTo);
            this.groupBox2.Controls.Add(this.rbtnSpecifiedRange);
            this.groupBox2.Controls.Add(this.dtpSpecifiedRangeFrom);
            this.groupBox2.Controls.Add(this.rbtnAllToDate);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.Text = "Date Range";
            // 
            // lblDateRangeTo
            // 
            this.lblDateRangeTo.Location = new System.Drawing.Point(136, 76);
            this.lblDateRangeTo.Name = "lblDateRangeTo";
            this.lblDateRangeTo.Size = new System.Drawing.Size(26, 19);
            this.lblDateRangeTo.TabIndex = 13;
            this.lblDateRangeTo.Text = "To";
            // 
            // dtpSpecifiedRangeTo
            // 
            this.dtpSpecifiedRangeTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpSpecifiedRangeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSpecifiedRangeTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpSpecifiedRangeTo.Location = new System.Drawing.Point(168, 74);
            this.dtpSpecifiedRangeTo.Name = "dtpSpecifiedRangeTo";
            this.dtpSpecifiedRangeTo.Size = new System.Drawing.Size(104, 20);
            this.dtpSpecifiedRangeTo.TabIndex = 14;
            // 
            // rbtnSpecifiedRange
            // 
            this.rbtnSpecifiedRange.Location = new System.Drawing.Point(6, 46);
            this.rbtnSpecifiedRange.Name = "rbtnSpecifiedRange";
            this.rbtnSpecifiedRange.Size = new System.Drawing.Size(104, 24);
            this.rbtnSpecifiedRange.TabIndex = 14;
            this.rbtnSpecifiedRange.Text = "Specified Range";
            // 
            // dtpSpecifiedRangeFrom
            // 
            this.dtpSpecifiedRangeFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpSpecifiedRangeFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSpecifiedRangeFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpSpecifiedRangeFrom.Location = new System.Drawing.Point(26, 74);
            this.dtpSpecifiedRangeFrom.Name = "dtpSpecifiedRangeFrom";
            this.dtpSpecifiedRangeFrom.Size = new System.Drawing.Size(104, 20);
            this.dtpSpecifiedRangeFrom.TabIndex = 13;
            // 
            // rbtnAllToDate
            // 
            this.rbtnAllToDate.Checked = true;
            this.rbtnAllToDate.Location = new System.Drawing.Point(6, 22);
            this.rbtnAllToDate.Name = "rbtnAllToDate";
            this.rbtnAllToDate.Size = new System.Drawing.Size(104, 24);
            this.rbtnAllToDate.TabIndex = 13;
            this.rbtnAllToDate.Text = "All-To-Date";
            // 
            // cboFromGroup
            // 
            this.cboFromGroup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFromGroup.DropDownWidth = 121;
            this.cboFromGroup.Location = new System.Drawing.Point(171, 164);
            this.cboFromGroup.Name = "cboFromGroup";
            this.cboFromGroup.Size = new System.Drawing.Size(120, 21);
            this.cboFromGroup.TabIndex = 1;
            // 
            // cboToGroup
            // 
            this.cboToGroup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboToGroup.DropDownWidth = 121;
            this.cboToGroup.Location = new System.Drawing.Point(171, 187);
            this.cboToGroup.Name = "cboToGroup";
            this.cboToGroup.Size = new System.Drawing.Size(120, 21);
            this.cboToGroup.TabIndex = 2;
            // 
            // lblToGroup
            // 
            this.lblToGroup.Location = new System.Drawing.Point(15, 190);
            this.lblToGroup.Name = "lblToGroup";
            this.lblToGroup.Size = new System.Drawing.Size(115, 23);
            this.lblToGroup.TabIndex = 0;
            this.lblToGroup.Text = "To Group";
            // 
            // gbAppendix
            // 
            this.gbAppendix.Controls.Add(this.chkAppendix3);
            this.gbAppendix.Controls.Add(this.chkAppendix2);
            this.gbAppendix.Controls.Add(this.chkAppendix1);
            this.gbAppendix.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbAppendix.Location = new System.Drawing.Point(301, 64);
            this.gbAppendix.Name = "gbAppendix";
            this.gbAppendix.Size = new System.Drawing.Size(140, 82);
            this.gbAppendix.TabIndex = 13;
            this.gbAppendix.Text = "Show Description";
            // 
            // chkAppendix3
            // 
            this.chkAppendix3.Checked = true;
            this.chkAppendix3.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAppendix3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAppendix3.Location = new System.Drawing.Point(14, 58);
            this.chkAppendix3.Name = "chkAppendix3";
            this.chkAppendix3.Size = new System.Drawing.Size(104, 19);
            this.chkAppendix3.TabIndex = 0;
            this.chkAppendix3.Text = "Appendix3";
            this.chkAppendix3.ThreeState = false;
            this.chkAppendix3.CheckedChanged += new System.EventHandler(this.chkAppendix3_CheckedChanged);
            // 
            // chkAppendix2
            // 
            this.chkAppendix2.Checked = true;
            this.chkAppendix2.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAppendix2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAppendix2.Location = new System.Drawing.Point(14, 38);
            this.chkAppendix2.Name = "chkAppendix2";
            this.chkAppendix2.Size = new System.Drawing.Size(104, 18);
            this.chkAppendix2.TabIndex = 0;
            this.chkAppendix2.Text = "Appendix2";
            this.chkAppendix2.ThreeState = false;
            this.chkAppendix2.CheckedChanged += new System.EventHandler(this.chkAppendix2_CheckedChanged);
            // 
            // chkAppendix1
            // 
            this.chkAppendix1.Checked = true;
            this.chkAppendix1.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAppendix1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAppendix1.Location = new System.Drawing.Point(14, 19);
            this.chkAppendix1.Name = "chkAppendix1";
            this.chkAppendix1.Size = new System.Drawing.Size(104, 20);
            this.chkAppendix1.TabIndex = 0;
            this.chkAppendix1.Text = "Appendix1";
            this.chkAppendix1.ThreeState = false;
            this.chkAppendix1.CheckedChanged += new System.EventHandler(this.chkAppendix1_CheckedChanged);
            // 
            // gbSubTotal
            // 
            this.gbSubTotal.Controls.Add(this.rbnYear);
            this.gbSubTotal.Controls.Add(this.rbnMonth);
            this.gbSubTotal.Controls.Add(this.rbnTransaction);
            this.gbSubTotal.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbSubTotal.Location = new System.Drawing.Point(301, 152);
            this.gbSubTotal.Name = "gbSubTotal";
            this.gbSubTotal.Size = new System.Drawing.Size(141, 100);
            this.gbSubTotal.TabIndex = 14;
            this.gbSubTotal.Text = "Sub-Total per";
            // 
            // rbnYear
            // 
            this.rbnYear.Location = new System.Drawing.Point(14, 71);
            this.rbnYear.Name = "rbnYear";
            this.rbnYear.Size = new System.Drawing.Size(104, 20);
            this.rbnYear.TabIndex = 2;
            this.rbnYear.Text = "Year";
            this.rbnYear.CheckedChanged += new System.EventHandler(this.rbnYear_CheckedChanged);
            // 
            // rbnMonth
            // 
            this.rbnMonth.Location = new System.Drawing.Point(14, 45);
            this.rbnMonth.Name = "rbnMonth";
            this.rbnMonth.Size = new System.Drawing.Size(104, 18);
            this.rbnMonth.TabIndex = 1;
            this.rbnMonth.Text = "Month";
            this.rbnMonth.CheckedChanged += new System.EventHandler(this.rbnMonth_CheckedChanged);
            // 
            // rbnTransaction
            // 
            this.rbnTransaction.Checked = true;
            this.rbnTransaction.Location = new System.Drawing.Point(14, 20);
            this.rbnTransaction.Name = "rbnTransaction";
            this.rbnTransaction.Size = new System.Drawing.Size(104, 20);
            this.rbnTransaction.TabIndex = 0;
            this.rbnTransaction.Text = "Transaction";
            this.rbnTransaction.CheckedChanged += new System.EventHandler(this.rbnTransaction_CheckedChanged);
            // 
            // gbPriview
            // 
            this.gbPriview.Controls.Add(this.rbtXLS);
            this.gbPriview.Controls.Add(this.rbtPDF);
            this.gbPriview.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbPriview.Location = new System.Drawing.Point(301, 8);
            this.gbPriview.Name = "gbPriview";
            this.gbPriview.Size = new System.Drawing.Size(141, 50);
            this.gbPriview.TabIndex = 4;
            this.gbPriview.Text = "Format ";
            // 
            // rbtXLS
            // 
            this.rbtXLS.Checked = true;
            this.rbtXLS.Cursor = null;
            this.rbtXLS.Location = new System.Drawing.Point(73, 22);
            this.rbtXLS.Name = "rbtXLS";
            this.rbtXLS.Size = new System.Drawing.Size(49, 24);
            this.rbtXLS.TabIndex = 2;
            this.rbtXLS.Text = "XLS";
            this.rbtXLS.CheckedChanged += new System.EventHandler(this.rbtnVIP_L_CheckedChanged);
            // 
            // rbtPDF
            // 
            this.rbtPDF.Location = new System.Drawing.Point(18, 22);
            this.rbtPDF.Name = "rbtPDF";
            this.rbtPDF.Size = new System.Drawing.Size(49, 24);
            this.rbtPDF.TabIndex = 0;
            this.rbtPDF.Text = " PDF";
            this.rbtPDF.CheckedChanged += new System.EventHandler(this.rbtnVIP_L_CheckedChanged);
            // 
            // RptVipSummaryListForm
            // 
            this.Controls.Add(this.gbPriview);
            this.Controls.Add(this.gbSubTotal);
            this.Controls.Add(this.gbAppendix);
            this.Controls.Add(this.lblToGroup);
            this.Controls.Add(this.cboToGroup);
            this.Controls.Add(this.cboFromGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblYTDNetSalesAmountOver);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.txtYTDNetSalesAmountOver);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblShowSalesDetail);
            this.Controls.Add(this.lblFromGroup);
            this.Controls.Add(this.chkShowSalesDetail);
            this.Size = new System.Drawing.Size(455, 288);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Vip Summary List Printing Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblFromGroup;
        private Gizmox.WebGUI.Forms.Label lblShowSalesDetail;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button btnPrint;
        private Gizmox.WebGUI.Forms.TextBox txtYTDNetSalesAmountOver;
        private Gizmox.WebGUI.Forms.ComboBox cmbTo;
        private Gizmox.WebGUI.Forms.ComboBox cmbFrom;
        private Gizmox.WebGUI.Forms.Label lblYTDNetSalesAmountOver;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.TextBox txtCopies;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.RadioButton rbnXLS;
        private Gizmox.WebGUI.Forms.RadioButton rbnPrinter;
        private Gizmox.WebGUI.Forms.RadioButton rbnPDF;
        private Gizmox.WebGUI.Forms.CheckBox chkShowSalesDetail;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.Label lblDateRangeTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpSpecifiedRangeTo;
        private Gizmox.WebGUI.Forms.RadioButton rbtnSpecifiedRange;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpSpecifiedRangeFrom;
        private Gizmox.WebGUI.Forms.RadioButton rbtnAllToDate;
        private Gizmox.WebGUI.Forms.ComboBox cboFromGroup;
        private Gizmox.WebGUI.Forms.ComboBox cboToGroup;
        private Gizmox.WebGUI.Forms.Label lblToGroup;
        private Gizmox.WebGUI.Forms.GroupBox gbAppendix;
        private Gizmox.WebGUI.Forms.CheckBox chkAppendix2;
        private Gizmox.WebGUI.Forms.CheckBox chkAppendix1;
        private Gizmox.WebGUI.Forms.CheckBox chkAppendix3;
        private Gizmox.WebGUI.Forms.GroupBox gbSubTotal;
        private Gizmox.WebGUI.Forms.RadioButton rbnYear;
        private Gizmox.WebGUI.Forms.RadioButton rbnMonth;
        private Gizmox.WebGUI.Forms.RadioButton rbnTransaction;
        private Gizmox.WebGUI.Forms.GroupBox gbPriview;
        private Gizmox.WebGUI.Forms.RadioButton rbtXLS;
        private Gizmox.WebGUI.Forms.RadioButton rbtPDF;


    }
}