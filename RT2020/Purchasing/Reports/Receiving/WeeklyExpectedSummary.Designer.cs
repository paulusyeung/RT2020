namespace RT2020.Purchasing.Reports.Receiving
{
    partial class WeeklyExpectedSummary
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
            this.lblDeLiveryDate = new Gizmox.WebGUI.Forms.Label();
            this.lblDateFrom = new Gizmox.WebGUI.Forms.Label();
            this.lblDateTo = new Gizmox.WebGUI.Forms.Label();
            this.lblFromFormat = new Gizmox.WebGUI.Forms.Label();
            this.lblToFormat = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplier = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplerFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboSupplierFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSupplerTo = new Gizmox.WebGUI.Forms.Label();
            this.cboSupplierTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStockCode = new Gizmox.WebGUI.Forms.Label();
            this.lblStockCodeFrom = new Gizmox.WebGUI.Forms.Label();
            this.cboStockCodeFrom = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblStockCodeTo = new Gizmox.WebGUI.Forms.Label();
            this.cboStockCodeTo = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSortBy = new Gizmox.WebGUI.Forms.Label();
            this.cboSortBy = new Gizmox.WebGUI.Forms.ComboBox();
            this.gbLocation = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnNone = new Gizmox.WebGUI.Forms.Button();
            this.btnSelectAll = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lvLocationList = new Gizmox.WebGUI.Forms.ListView();
            this.HeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.Mark = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.LOC = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.Initial = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.gbWeekDay = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbMonday = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbSunday = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.dtDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblDeLiveryDate
            // 
            this.lblDeLiveryDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDeLiveryDate.Location = new System.Drawing.Point(11, 14);
            this.lblDeLiveryDate.Name = "lblDeLiveryDate";
            this.lblDeLiveryDate.Size = new System.Drawing.Size(84, 23);
            this.lblDeLiveryDate.TabIndex = 0;
            this.lblDeLiveryDate.Text = "Delivery Date";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Location = new System.Drawing.Point(109, 14);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(40, 23);
            this.lblDateFrom.TabIndex = 1;
            this.lblDateFrom.Text = "(From)";
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(109, 39);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(37, 23);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "(To)";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFromFormat
            // 
            this.lblFromFormat.Location = new System.Drawing.Point(250, 14);
            this.lblFromFormat.Name = "lblFromFormat";
            this.lblFromFormat.Size = new System.Drawing.Size(79, 23);
            this.lblFromFormat.TabIndex = 6;
            this.lblFromFormat.Text = "(dd/mm/yyyy)";
            // 
            // lblToFormat
            // 
            this.lblToFormat.Location = new System.Drawing.Point(250, 39);
            this.lblToFormat.Name = "lblToFormat";
            this.lblToFormat.Size = new System.Drawing.Size(79, 23);
            this.lblToFormat.TabIndex = 6;
            this.lblToFormat.Text = "(dd/mm/yyyy)";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(12, 65);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(83, 23);
            this.lblSupplier.TabIndex = 7;
            this.lblSupplier.Text = "Supplier#";
            // 
            // lblSupplerFrom
            // 
            this.lblSupplerFrom.Location = new System.Drawing.Point(109, 65);
            this.lblSupplerFrom.Name = "lblSupplerFrom";
            this.lblSupplerFrom.Size = new System.Drawing.Size(40, 23);
            this.lblSupplerFrom.TabIndex = 8;
            this.lblSupplerFrom.Text = "(From)";
            // 
            // cboSupplierFrom
            // 
            this.cboSupplierFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSupplierFrom.Location = new System.Drawing.Point(145, 62);
            this.cboSupplierFrom.Name = "cboSupplierFrom";
            this.cboSupplierFrom.Size = new System.Drawing.Size(184, 21);
            this.cboSupplierFrom.TabIndex = 2;
            // 
            // lblSupplerTo
            // 
            this.lblSupplerTo.Location = new System.Drawing.Point(109, 90);
            this.lblSupplerTo.Name = "lblSupplerTo";
            this.lblSupplerTo.Size = new System.Drawing.Size(37, 23);
            this.lblSupplerTo.TabIndex = 10;
            this.lblSupplerTo.Text = "(To)";
            this.lblSupplerTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboSupplierTo
            // 
            this.cboSupplierTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSupplierTo.Location = new System.Drawing.Point(145, 87);
            this.cboSupplierTo.Name = "cboSupplierTo";
            this.cboSupplierTo.Size = new System.Drawing.Size(184, 21);
            this.cboSupplierTo.TabIndex = 3;
            // 
            // lblStockCode
            // 
            this.lblStockCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStockCode.Location = new System.Drawing.Point(12, 117);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(83, 23);
            this.lblStockCode.TabIndex = 12;
            this.lblStockCode.Text = "Stock Code";
            // 
            // lblStockCodeFrom
            // 
            this.lblStockCodeFrom.Location = new System.Drawing.Point(109, 117);
            this.lblStockCodeFrom.Name = "lblStockCodeFrom";
            this.lblStockCodeFrom.Size = new System.Drawing.Size(49, 23);
            this.lblStockCodeFrom.TabIndex = 13;
            this.lblStockCodeFrom.Text = "(From)";
            // 
            // cboStockCodeFrom
            // 
            this.cboStockCodeFrom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboStockCodeFrom.Location = new System.Drawing.Point(145, 114);
            this.cboStockCodeFrom.Name = "cboStockCodeFrom";
            this.cboStockCodeFrom.Size = new System.Drawing.Size(184, 21);
            this.cboStockCodeFrom.TabIndex = 5;
            // 
            // lblStockCodeTo
            // 
            this.lblStockCodeTo.Location = new System.Drawing.Point(106, 142);
            this.lblStockCodeTo.Name = "lblStockCodeTo";
            this.lblStockCodeTo.Size = new System.Drawing.Size(40, 23);
            this.lblStockCodeTo.TabIndex = 15;
            this.lblStockCodeTo.Text = "(To)";
            this.lblStockCodeTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboStockCodeTo
            // 
            this.cboStockCodeTo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboStockCodeTo.Location = new System.Drawing.Point(145, 139);
            this.cboStockCodeTo.Name = "cboStockCodeTo";
            this.cboStockCodeTo.Size = new System.Drawing.Size(184, 21);
            this.cboStockCodeTo.TabIndex = 5;
            // 
            // lblSortBy
            // 
            this.lblSortBy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSortBy.Location = new System.Drawing.Point(15, 169);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(80, 23);
            this.lblSortBy.TabIndex = 17;
            this.lblSortBy.Text = "Sort By";
            // 
            // cboSortBy
            // 
            this.cboSortBy.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboSortBy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboSortBy.Items.AddRange(new object[] {
            "Supplier#",
            "Stock Code"});
            this.cboSortBy.Location = new System.Drawing.Point(145, 166);
            this.cboSortBy.Name = "cboSortBy";
            this.cboSortBy.Size = new System.Drawing.Size(184, 21);
            this.cboSortBy.TabIndex = 6;
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.btnNone);
            this.gbLocation.Controls.Add(this.btnSelectAll);
            this.gbLocation.Controls.Add(this.label2);
            this.gbLocation.Controls.Add(this.label1);
            this.gbLocation.Controls.Add(this.lvLocationList);
            this.gbLocation.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbLocation.Location = new System.Drawing.Point(345, 12);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(232, 166);
            this.gbLocation.TabIndex = 19;
            this.gbLocation.Text = "Location";
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(171, 131);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(55, 23);
            this.btnNone.TabIndex = 9;
            this.btnNone.Text = "None";
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(99, 131);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(48, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "10 Record(s)";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lvLocationList
            // 
            this.lvLocationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.HeaderId,
            this.Mark,
            this.LOC,
            this.Initial});
            this.lvLocationList.DataMember = null;
            this.lvLocationList.ItemsPerPage = 20;
            this.lvLocationList.Location = new System.Drawing.Point(6, 19);
            this.lvLocationList.Name = "lvLocationList";
            this.lvLocationList.Size = new System.Drawing.Size(226, 97);
            this.lvLocationList.TabIndex = 7;
            this.lvLocationList.Click += new System.EventHandler(this.lvLocationList_Click);
            // 
            // HeaderId
            // 
            this.HeaderId.Image = null;
            this.HeaderId.Text = "HeaderId";
            this.HeaderId.Visible = false;
            this.HeaderId.Width = 150;
            // 
            // Mark
            // 
            this.Mark.Image = null;
            this.Mark.Text = "Mark";
            this.Mark.Width = 45;
            // 
            // LOC
            // 
            this.LOC.Image = null;
            this.LOC.Text = "LOC#";
            this.LOC.Width = 60;
            // 
            // Initial
            // 
            this.Initial.AllowDrop = true;
            this.Initial.Image = null;
            this.Initial.Text = "Initial";
            this.Initial.Width = 80;
            // 
            // gbWeekDay
            // 
            this.gbWeekDay.Controls.Add(this.rbMonday);
            this.gbWeekDay.Controls.Add(this.rbSunday);
            this.gbWeekDay.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbWeekDay.Location = new System.Drawing.Point(345, 184);
            this.gbWeekDay.Name = "gbWeekDay";
            this.gbWeekDay.Size = new System.Drawing.Size(235, 50);
            this.gbWeekDay.TabIndex = 20;
            this.gbWeekDay.Text = "Week day Start";
            // 
            // rbMonday
            // 
            this.rbMonday.Location = new System.Drawing.Point(133, 19);
            this.rbMonday.Name = "rbMonday";
            this.rbMonday.Size = new System.Drawing.Size(87, 24);
            this.rbMonday.TabIndex = 11;
            this.rbMonday.Text = "Monday";
            // 
            // rbSunday
            // 
            this.rbSunday.Checked = true;
            this.rbSunday.Location = new System.Drawing.Point(6, 19);
            this.rbSunday.Name = "rbSunday";
            this.rbSunday.Size = new System.Drawing.Size(90, 24);
            this.rbSunday.TabIndex = 10;
            this.rbSunday.Text = "Sunday";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(412, 242);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(496, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(145, 10);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(99, 20);
            this.dtDateFrom.TabIndex = 0;
            // 
            // dtDateTo
            // 
            this.dtDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(145, 35);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(99, 20);
            this.dtDateTo.TabIndex = 1;
            // 
            // WeeklyExpectedSummary
            // 
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.gbWeekDay);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.cboSortBy);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.cboStockCodeTo);
            this.Controls.Add(this.lblStockCodeTo);
            this.Controls.Add(this.cboStockCodeFrom);
            this.Controls.Add(this.lblStockCodeFrom);
            this.Controls.Add(this.lblStockCode);
            this.Controls.Add(this.cboSupplierTo);
            this.Controls.Add(this.lblSupplerTo);
            this.Controls.Add(this.cboSupplierFrom);
            this.Controls.Add(this.lblSupplerFrom);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblToFormat);
            this.Controls.Add(this.lblFromFormat);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.lblDeLiveryDate);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(590, 277);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weekly Expected Receiving Summary";
            this.Load += new System.EventHandler(this.WeeklyExpectedSummary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblDeLiveryDate;
        private Gizmox.WebGUI.Forms.Label lblDateFrom;
        private Gizmox.WebGUI.Forms.Label lblDateTo;
        private Gizmox.WebGUI.Forms.Label lblFromFormat;
        private Gizmox.WebGUI.Forms.Label lblToFormat;
        private Gizmox.WebGUI.Forms.Label lblSupplier;
        private Gizmox.WebGUI.Forms.Label lblSupplerFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboSupplierFrom;
        private Gizmox.WebGUI.Forms.Label lblSupplerTo;
        private Gizmox.WebGUI.Forms.ComboBox cboSupplierTo;
        private Gizmox.WebGUI.Forms.Label lblStockCode;
        private Gizmox.WebGUI.Forms.Label lblStockCodeFrom;
        private Gizmox.WebGUI.Forms.ComboBox cboStockCodeFrom;
        private Gizmox.WebGUI.Forms.Label lblStockCodeTo;
        private Gizmox.WebGUI.Forms.ComboBox cboStockCodeTo;
        private Gizmox.WebGUI.Forms.Label lblSortBy;
        private Gizmox.WebGUI.Forms.ComboBox cboSortBy;
        private Gizmox.WebGUI.Forms.GroupBox gbLocation;
        private Gizmox.WebGUI.Forms.GroupBox gbWeekDay;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.RadioButton rbMonday;
        private Gizmox.WebGUI.Forms.RadioButton rbSunday;
        private Gizmox.WebGUI.Forms.ListView lvLocationList;
        private Gizmox.WebGUI.Forms.ColumnHeader Mark;
        private Gizmox.WebGUI.Forms.ColumnHeader LOC;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateTo;
        private Gizmox.WebGUI.Forms.ColumnHeader Initial;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnNone;
        private Gizmox.WebGUI.Forms.Button btnSelectAll;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.ColumnHeader HeaderId;


    }
}