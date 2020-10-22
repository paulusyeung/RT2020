namespace RT2020.Web.Reports.Forms
{
    partial class StockQtyStatus_Inline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockQtyStatus_Inline));
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.txtBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.lblShop = new Gizmox.WebGUI.Forms.Label();
            this.txtShop = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSTYLE = new Gizmox.WebGUI.Forms.Label();
            this.txtSTYLE = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCOLOR = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCOLOR = new Gizmox.WebGUI.Forms.Label();
            this.txtFABRICS = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFABRICS = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.txtSIZE = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSIZE = new Gizmox.WebGUI.Forms.Label();
            this.lblSkipRecords = new Gizmox.WebGUI.Forms.Label();
            this.chkQty = new Gizmox.WebGUI.Forms.CheckBox();
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
            this.pnlLeft.Controls.Add(this.lblShop);
            this.pnlLeft.Controls.Add(this.txtShop);
            this.pnlLeft.Controls.Add(this.lblSTYLE);
            this.pnlLeft.Controls.Add(this.txtSTYLE);
            this.pnlLeft.Controls.Add(this.txtCOLOR);
            this.pnlLeft.Controls.Add(this.lblCOLOR);
            this.pnlLeft.Controls.Add(this.txtFABRICS);
            this.pnlLeft.Controls.Add(this.lblFABRICS);
            this.pnlLeft.Controls.Add(this.txtRemarks);
            this.pnlLeft.Controls.Add(this.lblRemarks);
            this.pnlLeft.Controls.Add(this.txtSIZE);
            this.pnlLeft.Controls.Add(this.lblSIZE);
            this.pnlLeft.Controls.Add(this.lblSkipRecords);
            this.pnlLeft.Controls.Add(this.chkQty);
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
            this.txtBarcode.Location = new System.Drawing.Point(119, 104);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(123, 22);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtBarcode_EnterKeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(119, 82);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(84, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(94, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "or";
            // 
            // lblShop
            // 
            this.lblShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblShop.Location = new System.Drawing.Point(13, 32);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(74, 17);
            this.lblShop.TabIndex = 0;
            this.lblShop.Text = "Shop ID";
            // 
            // txtShop
            // 
            this.txtShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtShop.Location = new System.Drawing.Point(13, 52);
            this.txtShop.Name = "txtShop";
            this.txtShop.Size = new System.Drawing.Size(100, 22);
            this.txtShop.TabIndex = 1;
            // 
            // lblSTYLE
            // 
            this.lblSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSTYLE.Location = new System.Drawing.Point(13, 84);
            this.lblSTYLE.Name = "lblSTYLE";
            this.lblSTYLE.Size = new System.Drawing.Size(74, 17);
            this.lblSTYLE.TabIndex = 0;
            this.lblSTYLE.Text = "STYLE*";
            // 
            // txtSTYLE
            // 
            this.txtSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSTYLE.Location = new System.Drawing.Point(15, 104);
            this.txtSTYLE.Name = "txtSTYLE";
            this.txtSTYLE.Size = new System.Drawing.Size(100, 22);
            this.txtSTYLE.TabIndex = 2;
            this.txtSTYLE.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtSTYLE_EnterKeyDown);
            // 
            // txtCOLOR
            // 
            this.txtCOLOR.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCOLOR.Location = new System.Drawing.Point(13, 200);
            this.txtCOLOR.Name = "txtCOLOR";
            this.txtCOLOR.Size = new System.Drawing.Size(100, 22);
            this.txtCOLOR.TabIndex = 4;
            // 
            // lblCOLOR
            // 
            this.lblCOLOR.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCOLOR.Location = new System.Drawing.Point(13, 180);
            this.lblCOLOR.Name = "lblCOLOR";
            this.lblCOLOR.Size = new System.Drawing.Size(74, 17);
            this.lblCOLOR.TabIndex = 0;
            this.lblCOLOR.Text = "COLOR";
            // 
            // txtFABRICS
            // 
            this.txtFABRICS.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFABRICS.Location = new System.Drawing.Point(13, 152);
            this.txtFABRICS.Name = "txtFABRICS";
            this.txtFABRICS.Size = new System.Drawing.Size(100, 22);
            this.txtFABRICS.TabIndex = 3;
            // 
            // lblFABRICS
            // 
            this.lblFABRICS.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFABRICS.Location = new System.Drawing.Point(13, 132);
            this.lblFABRICS.Name = "lblFABRICS";
            this.lblFABRICS.Size = new System.Drawing.Size(74, 17);
            this.lblFABRICS.TabIndex = 0;
            this.lblFABRICS.Text = "FABRICS";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(13, 292);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(191, 22);
            this.txtRemarks.TabIndex = 6;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRemarks.Location = new System.Drawing.Point(13, 272);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(74, 17);
            this.lblRemarks.TabIndex = 0;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtSIZE
            // 
            this.txtSIZE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSIZE.Location = new System.Drawing.Point(13, 247);
            this.txtSIZE.Name = "txtSIZE";
            this.txtSIZE.Size = new System.Drawing.Size(100, 22);
            this.txtSIZE.TabIndex = 5;
            // 
            // lblSIZE
            // 
            this.lblSIZE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSIZE.Location = new System.Drawing.Point(13, 227);
            this.lblSIZE.Name = "lblSIZE";
            this.lblSIZE.Size = new System.Drawing.Size(74, 17);
            this.lblSIZE.TabIndex = 0;
            this.lblSIZE.Text = "SIZE";
            // 
            // lblSkipRecords
            // 
            this.lblSkipRecords.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSkipRecords.Location = new System.Drawing.Point(13, 323);
            this.lblSkipRecords.Name = "lblSkipRecords";
            this.lblSkipRecords.Size = new System.Drawing.Size(90, 17);
            this.lblSkipRecords.TabIndex = 0;
            this.lblSkipRecords.Text = "Skip Record(s)";
            // 
            // chkQty
            // 
            this.chkQty.Checked = true;
            this.chkQty.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkQty.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkQty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkQty.Location = new System.Drawing.Point(13, 343);
            this.chkQty.Name = "chkQty";
            this.chkQty.Size = new System.Drawing.Size(213, 20);
            this.chkQty.TabIndex = 7;
            this.chkQty.Text = "(CDQTY=FEPQTY=ATSQTY=0)";
            this.chkQty.ThreeState = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(13, 369);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLookup
            // 
            this.btnLookup.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLookup.Location = new System.Drawing.Point(94, 369);
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
            this.label1.Text = "Stock Qty Status Enquiry";
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
            // StockQtyStatus_Inline
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(105, -19);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "StockQtyStatus_Inline";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.Panel pnlLeft;
        private Gizmox.WebGUI.Forms.TextBox txtBarcode;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label lblShop;
        private Gizmox.WebGUI.Forms.TextBox txtShop;
        private Gizmox.WebGUI.Forms.Label lblSTYLE;
        private Gizmox.WebGUI.Forms.TextBox txtSTYLE;
        private Gizmox.WebGUI.Forms.TextBox txtCOLOR;
        private Gizmox.WebGUI.Forms.Label lblCOLOR;
        private Gizmox.WebGUI.Forms.TextBox txtFABRICS;
        private Gizmox.WebGUI.Forms.Label lblFABRICS;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.TextBox txtSIZE;
        private Gizmox.WebGUI.Forms.Label lblSIZE;
        private Gizmox.WebGUI.Forms.Label lblSkipRecords;
        private Gizmox.WebGUI.Forms.CheckBox chkQty;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Button btnLookup;
        private Gizmox.WebGUI.Forms.Label label1;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;


    }
}