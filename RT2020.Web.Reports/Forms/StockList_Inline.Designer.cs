namespace RT2020.Web.Reports.Forms
{
    partial class StockList_Inline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockList_Inline));
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.lblSTYLE = new Gizmox.WebGUI.Forms.Label();
            this.txtSTYLE = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.btnLookup = new Gizmox.WebGUI.Forms.Button();
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
            this.pnlLeft.Controls.Add(this.txtBarcode);
            this.pnlLeft.Controls.Add(this.lblBarcode);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.lblSTYLE);
            this.pnlLeft.Controls.Add(this.txtSTYLE);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.btnLookup);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(253, 600);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBarcode.Location = new System.Drawing.Point(119, 60);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(123, 22);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtBarcode_EnterKeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(119, 38);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(84, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(94, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "or";
            // 
            // lblSTYLE
            // 
            this.lblSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSTYLE.Location = new System.Drawing.Point(13, 40);
            this.lblSTYLE.Name = "lblSTYLE";
            this.lblSTYLE.Size = new System.Drawing.Size(74, 17);
            this.lblSTYLE.TabIndex = 0;
            this.lblSTYLE.Text = "STYLE*";
            // 
            // txtSTYLE
            // 
            this.txtSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSTYLE.Location = new System.Drawing.Point(15, 60);
            this.txtSTYLE.Name = "txtSTYLE";
            this.txtSTYLE.Size = new System.Drawing.Size(100, 22);
            this.txtSTYLE.TabIndex = 2;
            this.txtSTYLE.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtSTYLE_EnterKeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(15, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLookup
            // 
            this.btnLookup.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLookup.Location = new System.Drawing.Point(96, 88);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 9;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
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
            this.label1.TabIndex = 3;
            this.label1.Text = "Stock List Enquiry";
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
            // StockList_Inline
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(251, 117);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "StockList_Inline";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.Panel pnlLeft;
        private Gizmox.WebGUI.Forms.TextBox txtBarcode;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label lblSTYLE;
        private Gizmox.WebGUI.Forms.TextBox txtSTYLE;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Button btnLookup;
        private Gizmox.WebGUI.Forms.Label label1;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;


    }
}