namespace RT2020.Web.Reports.Forms
{
    partial class DailyShopTransaction_Inline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyShopTransaction_Inline));
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.lblTxTypeTips = new Gizmox.WebGUI.Forms.Label();
            this.lblShop = new Gizmox.WebGUI.Forms.Label();
            this.txtShop = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.txtType = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCOLOR = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFABRICS = new Gizmox.WebGUI.Forms.Label();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSIZE = new Gizmox.WebGUI.Forms.Label();
            this.lblSkipRecords = new Gizmox.WebGUI.Forms.Label();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.rptViewer = new RT2020.Web.Reports.Controls.Viewer();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblTxTypeTips);
            this.pnlLeft.Controls.Add(this.lblShop);
            this.pnlLeft.Controls.Add(this.txtShop);
            this.pnlLeft.Controls.Add(this.lblTxType);
            this.pnlLeft.Controls.Add(this.txtType);
            this.pnlLeft.Controls.Add(this.txtDate);
            this.pnlLeft.Controls.Add(this.lblCOLOR);
            this.pnlLeft.Controls.Add(this.txtTxNumber);
            this.pnlLeft.Controls.Add(this.lblFABRICS);
            this.pnlLeft.Controls.Add(this.txtYear);
            this.pnlLeft.Controls.Add(this.lblRemarks);
            this.pnlLeft.Controls.Add(this.txtMonth);
            this.pnlLeft.Controls.Add(this.lblSIZE);
            this.pnlLeft.Controls.Add(this.lblSkipRecords);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(220, 600);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblTxTypeTips
            // 
            this.lblTxTypeTips.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTxTypeTips.Location = new System.Drawing.Point(13, 104);
            this.lblTxTypeTips.Name = "lblTxTypeTips";
            this.lblTxTypeTips.Size = new System.Drawing.Size(191, 17);
            this.lblTxTypeTips.TabIndex = 0;
            this.lblTxTypeTips.Text = "(CAS, CRT, VOD, TXI, TXO)";
            // 
            // lblShop
            // 
            this.lblShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblShop.Location = new System.Drawing.Point(13, 32);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(74, 17);
            this.lblShop.TabIndex = 0;
            this.lblShop.Text = "Shop ID*";
            // 
            // txtShop
            // 
            this.txtShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtShop.Location = new System.Drawing.Point(13, 52);
            this.txtShop.Name = "txtShop";
            this.txtShop.Size = new System.Drawing.Size(100, 22);
            this.txtShop.TabIndex = 1;
            // 
            // lblTxType
            // 
            this.lblTxType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTxType.Location = new System.Drawing.Point(13, 84);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(167, 17);
            this.lblTxType.TabIndex = 0;
            this.lblTxType.Text = "Transaction Type";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtType.Location = new System.Drawing.Point(13, 124);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(191, 22);
            this.txtType.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDate.Location = new System.Drawing.Point(13, 257);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(54, 22);
            this.txtDate.TabIndex = 4;
            // 
            // lblCOLOR
            // 
            this.lblCOLOR.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCOLOR.Location = new System.Drawing.Point(13, 218);
            this.lblCOLOR.Name = "lblCOLOR";
            this.lblCOLOR.Size = new System.Drawing.Size(74, 17);
            this.lblCOLOR.TabIndex = 0;
            this.lblCOLOR.Text = "Sales*";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTxNumber.Location = new System.Drawing.Point(13, 183);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(191, 22);
            this.txtTxNumber.TabIndex = 3;
            // 
            // lblFABRICS
            // 
            this.lblFABRICS.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFABRICS.Location = new System.Drawing.Point(13, 163);
            this.lblFABRICS.Name = "lblFABRICS";
            this.lblFABRICS.Size = new System.Drawing.Size(191, 17);
            this.lblFABRICS.TabIndex = 0;
            this.lblFABRICS.Text = "Transaction No.";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtYear.Location = new System.Drawing.Point(150, 257);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(54, 22);
            this.txtYear.TabIndex = 6;
            this.txtYear.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtYear_EnterKeyDown);
            // 
            // lblRemarks
            // 
            this.lblRemarks.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRemarks.Location = new System.Drawing.Point(90, 237);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(54, 17);
            this.lblRemarks.TabIndex = 0;
            this.lblRemarks.Text = "Month";
            // 
            // txtMonth
            // 
            this.txtMonth.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMonth.Location = new System.Drawing.Point(82, 257);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(54, 22);
            this.txtMonth.TabIndex = 5;
            // 
            // lblSIZE
            // 
            this.lblSIZE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSIZE.Location = new System.Drawing.Point(30, 235);
            this.lblSIZE.Name = "lblSIZE";
            this.lblSIZE.Size = new System.Drawing.Size(54, 17);
            this.lblSIZE.TabIndex = 0;
            this.lblSIZE.Text = "Day";
            // 
            // lblSkipRecords
            // 
            this.lblSkipRecords.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSkipRecords.Location = new System.Drawing.Point(159, 237);
            this.lblSkipRecords.Name = "lblSkipRecords";
            this.lblSkipRecords.Size = new System.Drawing.Size(54, 17);
            this.lblSkipRecords.TabIndex = 0;
            this.lblSkipRecords.Text = "Year";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(13, 298);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new Gizmox.WebGUI.Forms.Padding(4, 4, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Daily Shop Transaction";
            // 
            // rptViewer
            // 
            this.rptViewer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.rptViewer.Datasource = null;
            this.rptViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Parameters = ((System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>)(resources.GetObject("rptViewer.Parameters")));
            this.rptViewer.ReportDatasourceName = "";
            this.rptViewer.ReportDestination = RT2020.Web.Reports.Controls.Viewer.ReportDestinations.Preview;
            this.rptViewer.ReportName = "";
            this.rptViewer.Size = new System.Drawing.Size(576, 600);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = ((System.Collections.Generic.Dictionary<string, System.Data.DataTable>)(resources.GetObject("rptViewer.SubReportDataSourceList")));
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            this.rptViewer.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.rptViewer.ZoomPercent = 0;
            // 
            // DailyShopTransaction_Inline
            // 
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(153, 373);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "StockQtyStatus_Inline";
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.Panel pnlLeft;
        private Gizmox.WebGUI.Forms.Label lblTxTypeTips;
        private Gizmox.WebGUI.Forms.Label lblShop;
        private Gizmox.WebGUI.Forms.TextBox txtShop;
        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.TextBox txtType;
        private Gizmox.WebGUI.Forms.TextBox txtDate;
        private Gizmox.WebGUI.Forms.Label lblCOLOR;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblFABRICS;
        private Gizmox.WebGUI.Forms.TextBox txtYear;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.TextBox txtMonth;
        private Gizmox.WebGUI.Forms.Label lblSIZE;
        private Gizmox.WebGUI.Forms.Label lblSkipRecords;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Label label1;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;


    }
}