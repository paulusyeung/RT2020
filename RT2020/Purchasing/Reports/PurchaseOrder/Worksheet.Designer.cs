namespace RT2020.Purchasing.Reports.PurchaseOrder
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
            this.tabPOWorksheet = new Gizmox.WebGUI.Forms.TabControl();
            this.tpOrderNumber = new Gizmox.WebGUI.Forms.TabPage();
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
            this.tpSupplierNumber = new Gizmox.WebGUI.Forms.TabPage();
            this.cmdSuppPDF = new Gizmox.WebGUI.Forms.Button();
            this.cmdSuppExcel = new Gizmox.WebGUI.Forms.Button();
            this.cmdSuppPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdSuppExit = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpSuppDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpSuppDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.cboSuppTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.cboSuppFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.tpLocation = new Gizmox.WebGUI.Forms.TabPage();
            this.mainPanel = new Gizmox.WebGUI.Forms.Panel();
            this.cmdLocPDF = new Gizmox.WebGUI.Forms.Button();
            this.cmdLocExcel = new Gizmox.WebGUI.Forms.Button();
            this.cmdLocPreview = new Gizmox.WebGUI.Forms.Button();
            this.cmdLocExit = new Gizmox.WebGUI.Forms.Button();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpLocDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpLocDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.cboLocTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.cboLocFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // tabPOWorksheet
            // 
            this.tabPOWorksheet.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tabPOWorksheet.ClientAction = null;
            this.tabPOWorksheet.Controls.Add(this.tpOrderNumber);
            this.tabPOWorksheet.Controls.Add(this.tpSupplierNumber);
            this.tabPOWorksheet.Controls.Add(this.tpLocation);
            this.tabPOWorksheet.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPOWorksheet.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tabPOWorksheet.Location = new System.Drawing.Point(0, 0);
            this.tabPOWorksheet.Multiline = false;
            this.tabPOWorksheet.Name = "tabPOWorksheet";
            this.tabPOWorksheet.SelectedIndex = 0;
            this.tabPOWorksheet.ShowCloseButton = false;
            this.tabPOWorksheet.Size = new System.Drawing.Size(506, 211);
            this.tabPOWorksheet.TabIndex = 0;
            // 
            // tpOrderNumber
            // 
            this.tpOrderNumber.ClientAction = null;
            this.tpOrderNumber.Controls.Add(this.groupBox2);
            this.tpOrderNumber.Controls.Add(this.btnExit);
            this.tpOrderNumber.Controls.Add(this.cmdPreview);
            this.tpOrderNumber.Controls.Add(this.cmdExcel);
            this.tpOrderNumber.Controls.Add(this.cmdPDF);
            this.tpOrderNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpOrderNumber.Location = new System.Drawing.Point(4, 22);
            this.tpOrderNumber.Name = "tpOrderNumber";
            this.tpOrderNumber.Size = new System.Drawing.Size(498, 185);
            this.tpOrderNumber.TabIndex = 0;
            this.tpOrderNumber.Text = "Order Number";
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
            this.dtpDateTo.Location = new System.Drawing.Point(305, 62);
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
            this.dtpDateFrom.Location = new System.Drawing.Point(305, 39);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.ClientAction = null;
            this.lblTxDateTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTxDateTo.Location = new System.Drawing.Point(253, 66);
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
            this.lblTxDateFrom.Location = new System.Drawing.Point(253, 43);
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
            this.lblSelectDate.Location = new System.Drawing.Point(239, 19);
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
            this.lblOrderNumber.Text = "Order Number:";
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
            // tpSupplierNumber
            // 
            this.tpSupplierNumber.ClientAction = null;
            this.tpSupplierNumber.Controls.Add(this.cmdSuppPDF);
            this.tpSupplierNumber.Controls.Add(this.cmdSuppExcel);
            this.tpSupplierNumber.Controls.Add(this.cmdSuppPreview);
            this.tpSupplierNumber.Controls.Add(this.cmdSuppExit);
            this.tpSupplierNumber.Controls.Add(this.groupBox1);
            this.tpSupplierNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpSupplierNumber.Location = new System.Drawing.Point(4, 22);
            this.tpSupplierNumber.Name = "tpSupplierNumber";
            this.tpSupplierNumber.Size = new System.Drawing.Size(498, 185);
            this.tpSupplierNumber.TabIndex = 0;
            this.tpSupplierNumber.Text = "Supplier Number";
            // 
            // cmdSuppPDF
            // 
            this.cmdSuppPDF.ClientAction = null;
            this.cmdSuppPDF.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdSuppPDF.Location = new System.Drawing.Point(80, 136);
            this.cmdSuppPDF.Name = "cmdSuppPDF";
            this.cmdSuppPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdSuppPDF.TabIndex = 4;
            this.cmdSuppPDF.Text = "PDF";
            this.cmdSuppPDF.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdSuppPDF.Click += new System.EventHandler(this.CmdSuppPDF_Click);
            // 
            // cmdSuppExcel
            // 
            this.cmdSuppExcel.ClientAction = null;
            this.cmdSuppExcel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdSuppExcel.Location = new System.Drawing.Point(163, 136);
            this.cmdSuppExcel.Name = "cmdSuppExcel";
            this.cmdSuppExcel.Size = new System.Drawing.Size(75, 23);
            this.cmdSuppExcel.TabIndex = 4;
            this.cmdSuppExcel.Text = "Excel";
            this.cmdSuppExcel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdSuppExcel.Click += new System.EventHandler(this.CmdSuppExcel_Click);
            // 
            // cmdSuppPreview
            // 
            this.cmdSuppPreview.ClientAction = null;
            this.cmdSuppPreview.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdSuppPreview.Location = new System.Drawing.Point(246, 136);
            this.cmdSuppPreview.Name = "cmdSuppPreview";
            this.cmdSuppPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdSuppPreview.TabIndex = 4;
            this.cmdSuppPreview.Text = "Preview";
            this.cmdSuppPreview.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdSuppPreview.Click += new System.EventHandler(this.CmdSuppPreview_Click);
            // 
            // cmdSuppExit
            // 
            this.cmdSuppExit.ClientAction = null;
            this.cmdSuppExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdSuppExit.Location = new System.Drawing.Point(329, 136);
            this.cmdSuppExit.Name = "cmdSuppExit";
            this.cmdSuppExit.Size = new System.Drawing.Size(75, 23);
            this.cmdSuppExit.TabIndex = 5;
            this.cmdSuppExit.Text = "Cancel";
            this.cmdSuppExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdSuppExit.Click += new System.EventHandler(this.CmdSuppExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.ClientAction = null;
            this.groupBox1.Controls.Add(this.dtpSuppDateTo);
            this.groupBox1.Controls.Add(this.dtpSuppDateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboSuppTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboSuppFrom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
            // 
            // dtpSuppDateTo
            // 
            this.dtpSuppDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpSuppDateTo.ClientAction = null;
            this.dtpSuppDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSuppDateTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpSuppDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpSuppDateTo.Location = new System.Drawing.Point(305, 62);
            this.dtpSuppDateTo.Name = "dtpSuppDateTo";
            this.dtpSuppDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpSuppDateTo.TabIndex = 3;
            // 
            // dtpSuppDateFrom
            // 
            this.dtpSuppDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpSuppDateFrom.ClientAction = null;
            this.dtpSuppDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSuppDateFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpSuppDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpSuppDateFrom.Location = new System.Drawing.Point(305, 39);
            this.dtpSuppDateFrom.Name = "dtpSuppDateFrom";
            this.dtpSuppDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpSuppDateFrom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.ClientAction = null;
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(253, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 9;
            this.label1.TabStop = false;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.ClientAction = null;
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(253, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 8;
            this.label2.TabStop = false;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.ClientAction = null;
            this.label3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label3.Location = new System.Drawing.Point(239, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 7;
            this.label3.TabStop = false;
            this.label3.Text = "Select Date:";
            // 
            // label4
            // 
            this.label4.ClientAction = null;
            this.label4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label4.Location = new System.Drawing.Point(15, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 6;
            this.label4.TabStop = false;
            this.label4.Text = "Supplier Code:";
            // 
            // cboSuppTo
            // 
            this.cboSuppTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSuppTo.ClientAction = null;
            this.cboSuppTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboSuppTo.DropDownWidth = 143;
            this.cboSuppTo.Location = new System.Drawing.Point(75, 63);
            this.cboSuppTo.Name = "cboSuppTo";
            this.cboSuppTo.Size = new System.Drawing.Size(140, 21);
            this.cboSuppTo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.ClientAction = null;
            this.label5.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label5.Location = new System.Drawing.Point(28, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 2;
            this.label5.TabStop = false;
            this.label5.Text = "From";
            // 
            // cboSuppFrom
            // 
            this.cboSuppFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSuppFrom.ClientAction = null;
            this.cboSuppFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboSuppFrom.DropDownWidth = 143;
            this.cboSuppFrom.Location = new System.Drawing.Point(75, 38);
            this.cboSuppFrom.Name = "cboSuppFrom";
            this.cboSuppFrom.Size = new System.Drawing.Size(140, 21);
            this.cboSuppFrom.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.ClientAction = null;
            this.label6.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label6.Location = new System.Drawing.Point(28, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 3;
            this.label6.TabStop = false;
            this.label6.Text = "To";
            // 
            // tpLocation
            // 
            this.tpLocation.ClientAction = null;
            this.tpLocation.Controls.Add(this.groupBox3);
            this.tpLocation.Controls.Add(this.cmdLocExit);
            this.tpLocation.Controls.Add(this.cmdLocPreview);
            this.tpLocation.Controls.Add(this.cmdLocExcel);
            this.tpLocation.Controls.Add(this.cmdLocPDF);
            this.tpLocation.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tpLocation.Location = new System.Drawing.Point(4, 22);
            this.tpLocation.Name = "tpLocation";
            this.tpLocation.Size = new System.Drawing.Size(498, 185);
            this.tpLocation.TabIndex = 0;
            this.tpLocation.Text = "Location";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPanel.ClientAction = null;
            this.mainPanel.Controls.Add(this.tabPOWorksheet);
            this.mainPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPanel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(506, 211);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.TabStop = false;
            // 
            // cmdLocPDF
            // 
            this.cmdLocPDF.ClientAction = null;
            this.cmdLocPDF.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdLocPDF.Location = new System.Drawing.Point(80, 136);
            this.cmdLocPDF.Name = "cmdLocPDF";
            this.cmdLocPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdLocPDF.TabIndex = 4;
            this.cmdLocPDF.Text = "PDF";
            this.cmdLocPDF.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdLocPDF.Click += new System.EventHandler(this.CmdLocPDF_Click);
            // 
            // cmdLocExcel
            // 
            this.cmdLocExcel.ClientAction = null;
            this.cmdLocExcel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdLocExcel.Location = new System.Drawing.Point(163, 136);
            this.cmdLocExcel.Name = "cmdLocExcel";
            this.cmdLocExcel.Size = new System.Drawing.Size(75, 23);
            this.cmdLocExcel.TabIndex = 4;
            this.cmdLocExcel.Text = "Excel";
            this.cmdLocExcel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdLocExcel.Click += new System.EventHandler(this.CmdLocExcel_Click);
            // 
            // cmdLocPreview
            // 
            this.cmdLocPreview.ClientAction = null;
            this.cmdLocPreview.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdLocPreview.Location = new System.Drawing.Point(246, 136);
            this.cmdLocPreview.Name = "cmdLocPreview";
            this.cmdLocPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdLocPreview.TabIndex = 4;
            this.cmdLocPreview.Text = "Preview";
            this.cmdLocPreview.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdLocPreview.Click += new System.EventHandler(this.CmdLocPreview_Click);
            // 
            // cmdLocExit
            // 
            this.cmdLocExit.ClientAction = null;
            this.cmdLocExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cmdLocExit.Location = new System.Drawing.Point(329, 136);
            this.cmdLocExit.Name = "cmdLocExit";
            this.cmdLocExit.Size = new System.Drawing.Size(75, 23);
            this.cmdLocExit.TabIndex = 5;
            this.cmdLocExit.Text = "Cancel";
            this.cmdLocExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.cmdLocExit.Click += new System.EventHandler(this.CmdLocExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.ClientAction = null;
            this.groupBox3.Controls.Add(this.dtpLocDateTo);
            this.groupBox3.Controls.Add(this.dtpLocDateFrom);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboLocTo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cboLocFrom);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Range";
            // 
            // dtpLocDateTo
            // 
            this.dtpLocDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpLocDateTo.ClientAction = null;
            this.dtpLocDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpLocDateTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpLocDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpLocDateTo.Location = new System.Drawing.Point(305, 62);
            this.dtpLocDateTo.Name = "dtpLocDateTo";
            this.dtpLocDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpLocDateTo.TabIndex = 3;
            // 
            // dtpLocDateFrom
            // 
            this.dtpLocDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpLocDateFrom.ClientAction = null;
            this.dtpLocDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpLocDateFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.dtpLocDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpLocDateFrom.Location = new System.Drawing.Point(305, 39);
            this.dtpLocDateFrom.Name = "dtpLocDateFrom";
            this.dtpLocDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpLocDateFrom.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.ClientAction = null;
            this.label7.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label7.Location = new System.Drawing.Point(253, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 9;
            this.label7.TabStop = false;
            this.label7.Text = "To";
            // 
            // label8
            // 
            this.label8.ClientAction = null;
            this.label8.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label8.Location = new System.Drawing.Point(253, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 8;
            this.label8.TabStop = false;
            this.label8.Text = "From";
            // 
            // label9
            // 
            this.label9.ClientAction = null;
            this.label9.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label9.Location = new System.Drawing.Point(239, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 7;
            this.label9.TabStop = false;
            this.label9.Text = "Select Date:";
            // 
            // label10
            // 
            this.label10.ClientAction = null;
            this.label10.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label10.Location = new System.Drawing.Point(15, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
            this.label10.TabIndex = 6;
            this.label10.TabStop = false;
            this.label10.Text = "Location Code:";
            // 
            // cboLocTo
            // 
            this.cboLocTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboLocTo.ClientAction = null;
            this.cboLocTo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboLocTo.DropDownWidth = 143;
            this.cboLocTo.Location = new System.Drawing.Point(75, 63);
            this.cboLocTo.Name = "cboLocTo";
            this.cboLocTo.Size = new System.Drawing.Size(140, 21);
            this.cboLocTo.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.ClientAction = null;
            this.label11.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label11.Location = new System.Drawing.Point(28, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 18);
            this.label11.TabIndex = 2;
            this.label11.TabStop = false;
            this.label11.Text = "From";
            // 
            // cboLocFrom
            // 
            this.cboLocFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboLocFrom.ClientAction = null;
            this.cboLocFrom.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboLocFrom.DropDownWidth = 143;
            this.cboLocFrom.Location = new System.Drawing.Point(75, 38);
            this.cboLocFrom.Name = "cboLocFrom";
            this.cboLocFrom.Size = new System.Drawing.Size(140, 21);
            this.cboLocFrom.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.ClientAction = null;
            this.label12.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label12.Location = new System.Drawing.Point(28, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 18);
            this.label12.TabIndex = 3;
            this.label12.TabStop = false;
            this.label12.Text = "To";
            // 
            // Worksheet
            // 
            this.Controls.Add(this.mainPanel);
            this.Size = new System.Drawing.Size(506, 211);
            this.Text = "Purchase Order > Reports > Worksheet";
            this.Load += new System.EventHandler(this.Worksheet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TabControl tabPOWorksheet;
        private Gizmox.WebGUI.Forms.TabPage tpOrderNumber;
        private Gizmox.WebGUI.Forms.TabPage tpSupplierNumber;
        private Gizmox.WebGUI.Forms.Panel mainPanel;
        private Gizmox.WebGUI.Forms.TabPage tpLocation;
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
        private Gizmox.WebGUI.Forms.Button cmdSuppPDF;
        private Gizmox.WebGUI.Forms.Button cmdSuppExcel;
        private Gizmox.WebGUI.Forms.Button cmdSuppPreview;
        private Gizmox.WebGUI.Forms.Button cmdSuppExit;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpSuppDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpSuppDateFrom;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.ComboBox cboSuppTo;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.ComboBox cboSuppFrom;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Button cmdLocPDF;
        private Gizmox.WebGUI.Forms.Button cmdLocExcel;
        private Gizmox.WebGUI.Forms.Button cmdLocPreview;
        private Gizmox.WebGUI.Forms.Button cmdLocExit;
        private Gizmox.WebGUI.Forms.GroupBox groupBox3;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpLocDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpLocDateFrom;
        private Gizmox.WebGUI.Forms.Label label7;
        private Gizmox.WebGUI.Forms.Label label8;
        private Gizmox.WebGUI.Forms.Label label9;
        private Gizmox.WebGUI.Forms.Label label10;
        private Gizmox.WebGUI.Forms.ComboBox cboLocTo;
        private Gizmox.WebGUI.Forms.Label label11;
        private Gizmox.WebGUI.Forms.ComboBox cboLocFrom;
        private Gizmox.WebGUI.Forms.Label label12;


    }
}