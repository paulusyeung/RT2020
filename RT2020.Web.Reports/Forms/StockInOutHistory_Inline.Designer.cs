namespace RT2020.Web.Reports.Forms
{
    partial class StockInOutHistory_Inline
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockInOutHistory_Inline));
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.chkUnPosted = new Gizmox.WebGUI.Forms.CheckBox();
            this.dtDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtSTK = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.lblSTYLE = new Gizmox.WebGUI.Forms.Label();
            this.txtFromSTK = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFABRICS = new Gizmox.WebGUI.Forms.Label();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.rptViewer = new RT2020.Web.Reports.Controls.Viewer();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.chkUnPosted);
            this.pnlLeft.Controls.Add(this.dtDateFrom);
            this.pnlLeft.Controls.Add(this.dtDateTo);
            this.pnlLeft.Controls.Add(this.txtSTK);
            this.pnlLeft.Controls.Add(this.lblBarcode);
            this.pnlLeft.Controls.Add(this.lblSTYLE);
            this.pnlLeft.Controls.Add(this.txtFromSTK);
            this.pnlLeft.Controls.Add(this.lblFABRICS);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(253, 600);
            this.pnlLeft.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(133, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // chkUnPosted
            // 
            this.chkUnPosted.Checked = false;
            this.chkUnPosted.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnPosted.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnPosted.Location = new System.Drawing.Point(15, 153);
            this.chkUnPosted.Name = "chkUnPosted";
            this.chkUnPosted.Size = new System.Drawing.Size(227, 20);
            this.chkUnPosted.TabIndex = 9;
            this.chkUnPosted.Text = "Include Un-Posted FEP Data";
            this.chkUnPosted.ThreeState = false;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(15, 107);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(109, 20);
            this.dtDateFrom.TabIndex = 7;
            // 
            // dtDateTo
            // 
            this.dtDateTo.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(133, 107);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(109, 20);
            this.dtDateTo.TabIndex = 8;
            // 
            // txtSTK
            // 
            this.txtSTK.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSTK.Location = new System.Drawing.Point(133, 52);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(109, 22);
            this.txtSTK.TabIndex = 4;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(133, 30);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(84, 17);
            this.lblBarcode.TabIndex = 2;
            this.lblBarcode.Text = "To";
            // 
            // lblSTYLE
            // 
            this.lblSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSTYLE.Location = new System.Drawing.Point(13, 32);
            this.lblSTYLE.Name = "lblSTYLE";
            this.lblSTYLE.Size = new System.Drawing.Size(74, 17);
            this.lblSTYLE.TabIndex = 1;
            this.lblSTYLE.Text = "STYLE*";
            // 
            // txtFromSTK
            // 
            this.txtFromSTK.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFromSTK.Location = new System.Drawing.Point(15, 52);
            this.txtFromSTK.Name = "txtFromSTK";
            this.txtFromSTK.Size = new System.Drawing.Size(109, 22);
            this.txtFromSTK.TabIndex = 3;
            // 
            // lblFABRICS
            // 
            this.lblFABRICS.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFABRICS.Location = new System.Drawing.Point(13, 87);
            this.lblFABRICS.Name = "lblFABRICS";
            this.lblFABRICS.Size = new System.Drawing.Size(74, 17);
            this.lblFABRICS.TabIndex = 5;
            this.lblFABRICS.Text = "Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(15, 196);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new Gizmox.WebGUI.Forms.Padding(4, 4, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock In Out History";
            // 
            // rptViewer
            // 
            this.rptViewer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.rptViewer.Datasource = null;
            this.rptViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Parameters = ((System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>)(resources.GetObject("rptViewer.Parameters")));
            this.rptViewer.ReportDatasourceName = "";
            this.rptViewer.ReportDestination = RT2020.Web.Reports.Controls.Viewer.ReportDestinations.Preview;
            this.rptViewer.ReportName = "";
            this.rptViewer.Size = new System.Drawing.Size(543, 600);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = ((System.Collections.Generic.Dictionary<string, System.Data.DataTable>)(resources.GetObject("rptViewer.SubReportDataSourceList")));
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            this.rptViewer.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.rptViewer.ZoomPercent = 0;
            // 
            // StockInOutHistory_Inline
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(271, 117);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "StockQtyStatus_Inline";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.Panel pnlLeft;
        private Gizmox.WebGUI.Forms.TextBox txtSTK;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.Label lblSTYLE;
        private Gizmox.WebGUI.Forms.TextBox txtFromSTK;
        private Gizmox.WebGUI.Forms.Label lblFABRICS;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Label label1;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateTo;
        private Gizmox.WebGUI.Forms.CheckBox chkUnPosted;
        private Gizmox.WebGUI.Forms.Label label2;


    }
}