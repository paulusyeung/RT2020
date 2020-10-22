namespace RT2020.Purchasing.Reports.OfficialDocument
{
    partial class OrderSummary
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
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.cboType = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cboSortedBy = new Gizmox.WebGUI.Forms.ComboBox();
            this.groupBox6 = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.lvLocationsList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colWorkplaceInitial = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox5 = new Gizmox.WebGUI.Forms.GroupBox();
            this.chkHideAPPENDIX3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkPrintPhoto = new Gizmox.WebGUI.Forms.CheckBox();
            this.dtpDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblDeliveryDate = new Gizmox.WebGUI.Forms.Label();
            this.lblSuppler = new Gizmox.WebGUI.Forms.Label();
            this.lblTxDateFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTxDateTo = new Gizmox.WebGUI.Forms.Label();
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
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboSortedBy);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.dtpDateFrom);
            this.groupBox2.Controls.Add(this.dtpDateTo);
            this.groupBox2.Controls.Add(this.lblDeliveryDate);
            this.groupBox2.Controls.Add(this.lblSuppler);
            this.groupBox2.Controls.Add(this.lblTxDateFrom);
            this.groupBox2.Controls.Add(this.cboTo);
            this.groupBox2.Controls.Add(this.lblTxDateTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cboFrom);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 470);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Range";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboType.DropDownWidth = 121;
            this.cboType.Items.AddRange(new object[] {
            "Active",
            "Batch"});
            this.cboType.Location = new System.Drawing.Point(75, 186);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(140, 21);
            this.cboType.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sorted By:";
            // 
            // cboSortedBy
            // 
            this.cboSortedBy.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSortedBy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboSortedBy.DropDownWidth = 121;
            this.cboSortedBy.Items.AddRange(new object[] {
            "Stock Code",
            "Supplier Number"});
            this.cboSortedBy.Location = new System.Drawing.Point(75, 117);
            this.cboSortedBy.Name = "cboSortedBy";
            this.cboSortedBy.Size = new System.Drawing.Size(140, 21);
            this.cboSortedBy.TabIndex = 14;
            this.cboSortedBy.SelectedIndexChanged += new System.EventHandler(this.cboSortedBy_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnMarkAll);
            this.groupBox6.Controls.Add(this.lvLocationsList);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(231, 93);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 343);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.Text = "Location";
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(188, 310);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 8;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.BtnMarkAll_Click);
            // 
            // lvLocationsList
            // 
            this.lvLocationsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colMark,
            this.colLN,
            this.colWorkplaceCode,
            this.colWorkplaceInitial});
            this.lvLocationsList.DataMember = null;
            this.lvLocationsList.ItemsPerPage = 20;
            this.lvLocationsList.Location = new System.Drawing.Point(9, 19);
            this.lvLocationsList.Name = "lvLocationsList";
            this.lvLocationsList.Size = new System.Drawing.Size(254, 285);
            this.lvLocationsList.TabIndex = 0;
            this.lvLocationsList.Click += new System.EventHandler(this.LvLocationsList_Click);
            // 
            // colTxId
            // 
            this.colTxId.Image = null;
            this.colTxId.Text = "TxId";
            this.colTxId.Visible = false;
            this.colTxId.Width = 5;
            // 
            // colMark
            // 
            this.colMark.Image = null;
            this.colMark.Text = "Mark";
            this.colMark.Width = 40;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colWorkplaceCode
            // 
            this.colWorkplaceCode.Image = null;
            this.colWorkplaceCode.Text = "LOC#";
            this.colWorkplaceCode.Width = 70;
            // 
            // colWorkplaceInitial
            // 
            this.colWorkplaceInitial.Image = null;
            this.colWorkplaceInitial.Text = "Initial";
            this.colWorkplaceInitial.Width = 100;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "**Max Selection : 10 Record(s)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkHideAPPENDIX3);
            this.groupBox5.Controls.Add(this.chkPrintPhoto);
            this.groupBox5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(9, 236);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 100);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.Text = "Options";
            // 
            // chkHideAPPENDIX3
            // 
            this.chkHideAPPENDIX3.Checked = true;
            this.chkHideAPPENDIX3.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkHideAPPENDIX3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkHideAPPENDIX3.Location = new System.Drawing.Point(65, 58);
            this.chkHideAPPENDIX3.Name = "chkHideAPPENDIX3";
            this.chkHideAPPENDIX3.Size = new System.Drawing.Size(140, 24);
            this.chkHideAPPENDIX3.TabIndex = 12;
            this.chkHideAPPENDIX3.Text = "Hide APPENDIX3 (SIZE)";
            this.chkHideAPPENDIX3.ThreeState = false;
            // 
            // chkPrintPhoto
            // 
            this.chkPrintPhoto.Checked = true;
            this.chkPrintPhoto.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkPrintPhoto.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPrintPhoto.Location = new System.Drawing.Point(65, 28);
            this.chkPrintPhoto.Name = "chkPrintPhoto";
            this.chkPrintPhoto.Size = new System.Drawing.Size(135, 24);
            this.chkPrintPhoto.TabIndex = 12;
            this.chkPrintPhoto.Text = "Print out Item Photo";
            this.chkPrintPhoto.ThreeState = false;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(75, 38);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(75, 63);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(140, 20);
            this.dtpDateTo.TabIndex = 3;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Location = new System.Drawing.Point(9, 19);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(82, 17);
            this.lblDeliveryDate.TabIndex = 7;
            this.lblDeliveryDate.TabStop = false;
            this.lblDeliveryDate.Text = "Delivery Date:";
            // 
            // lblSuppler
            // 
            this.lblSuppler.Location = new System.Drawing.Point(231, 20);
            this.lblSuppler.Name = "lblSuppler";
            this.lblSuppler.Size = new System.Drawing.Size(84, 17);
            this.lblSuppler.TabIndex = 6;
            this.lblSuppler.TabStop = false;
            this.lblSuppler.Text = "Suppler#:";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.Location = new System.Drawing.Point(23, 41);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Size = new System.Drawing.Size(46, 15);
            this.lblTxDateFrom.TabIndex = 8;
            this.lblTxDateFrom.TabStop = false;
            this.lblTxDateFrom.Text = "From";
            // 
            // cboTo
            // 
            this.cboTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTo.DropDownWidth = 143;
            this.cboTo.Location = new System.Drawing.Point(291, 64);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(140, 21);
            this.cboTo.TabIndex = 1;
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.Location = new System.Drawing.Point(23, 66);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Size = new System.Drawing.Size(42, 18);
            this.lblTxDateTo.TabIndex = 9;
            this.lblTxDateTo.TabStop = false;
            this.lblTxDateTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(244, 42);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(41, 18);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.TabStop = false;
            this.lblFrom.Text = "From";
            // 
            // cboFrom
            // 
            this.cboFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboFrom.DropDownWidth = 143;
            this.cboFrom.Location = new System.Drawing.Point(291, 39);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(140, 21);
            this.cboFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(244, 67);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(41, 18);
            this.lblTo.TabIndex = 3;
            this.lblTo.TabStop = false;
            this.lblTo.Text = "To";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(342, 511);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Cancel";
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(259, 511);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(75, 23);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.Click += new System.EventHandler(this.CmdPreview_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Location = new System.Drawing.Point(176, 511);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(75, 23);
            this.cmdExcel.TabIndex = 4;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.Visible = false;
            this.cmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            // 
            // cmdPDF
            // 
            this.cmdPDF.Location = new System.Drawing.Point(93, 511);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(75, 23);
            this.cmdPDF.TabIndex = 4;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.Visible = false;
            this.cmdPDF.Click += new System.EventHandler(this.CmdPDF_Click);
            // 
            // OrderSummary
            // 
            this.Controls.Add(this.cmdPDF);
            this.Controls.Add(this.cmdExcel);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(553, 579);
            this.Text = "Purchase Order > Reports > Official Document > Order Summary";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpDateFrom;
        private Gizmox.WebGUI.Forms.Label lblTxDateTo;
        private Gizmox.WebGUI.Forms.Label lblTxDateFrom;
        private Gizmox.WebGUI.Forms.Label lblDeliveryDate;
        private Gizmox.WebGUI.Forms.Label lblSuppler;
        private Gizmox.WebGUI.Forms.ComboBox cboTo;
        private Gizmox.WebGUI.Forms.Label lblFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboFrom;
        private Gizmox.WebGUI.Forms.Label lblTo;
        private Gizmox.WebGUI.Forms.GroupBox groupBox5;
        private Gizmox.WebGUI.Forms.CheckBox chkPrintPhoto;
        private Gizmox.WebGUI.Forms.CheckBox chkHideAPPENDIX3;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.Button cmdPreview;
        private Gizmox.WebGUI.Forms.Button cmdExcel;
        private Gizmox.WebGUI.Forms.Button cmdPDF;
        private Gizmox.WebGUI.Forms.ListView lvLocationsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colMark;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceInitial;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.GroupBox groupBox6;
        private Gizmox.WebGUI.Forms.ComboBox cboType;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.ComboBox cboSortedBy;

    }
}