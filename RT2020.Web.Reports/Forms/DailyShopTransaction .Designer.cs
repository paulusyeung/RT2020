namespace RT2020.Web.Reports.Forms
{
    partial class DailyShopTransaction 
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
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtYear = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtMonth = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtDate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFABRICS = new Gizmox.WebGUI.Forms.Label();
            this.txtType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCOLOR = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtShop = new Gizmox.WebGUI.Forms.TextBox();
            this.lblShop = new Gizmox.WebGUI.Forms.Label();
            this.rptViewer = new RT2020.Web.Reports.Controls.Viewer();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.splitContainer);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(690, 600);
            this.mainPane.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.splitContainer.Location = new System.Drawing.Point(6, 6);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.txtYear);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.txtMonth);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.lblBarcode);
            this.splitContainer.Panel1.Controls.Add(this.txtDate);
            this.splitContainer.Panel1.Controls.Add(this.lblFABRICS);
            this.splitContainer.Panel1.Controls.Add(this.txtType);
            this.splitContainer.Panel1.Controls.Add(this.lblCOLOR);
            this.splitContainer.Panel1.Controls.Add(this.txtTxNumber);
            this.splitContainer.Panel1.Controls.Add(this.txtShop);
            this.splitContainer.Panel1.Controls.Add(this.lblShop);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer.Size = new System.Drawing.Size(678, 588);
            this.splitContainer.SplitterDistance = 165;
            this.splitContainer.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label6.Location = new System.Drawing.Point(10, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "(CAS,CRT,VOD,TXI,TXO)";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtYear.Location = new System.Drawing.Point(533, 55);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(60, 22);
            this.txtYear.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(494, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Year";
            // 
            // txtMonth
            // 
            this.txtMonth.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMonth.Location = new System.Drawing.Point(428, 55);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(60, 22);
            this.txtMonth.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(385, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Month";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(279, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(59, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "(By Shop/Date)";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(132, 131);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = " Daily Shop Transaction   Enquiry";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(233, 58);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(47, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Sales*";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDate.Location = new System.Drawing.Point(318, 55);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(60, 22);
            this.txtDate.TabIndex = 2;
            // 
            // lblFABRICS
            // 
            this.lblFABRICS.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFABRICS.Location = new System.Drawing.Point(21, 76);
            this.lblFABRICS.Name = "lblFABRICS";
            this.lblFABRICS.Size = new System.Drawing.Size(105, 15);
            this.lblFABRICS.TabIndex = 0;
            this.lblFABRICS.Text = "Transcation Type";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtType.Location = new System.Drawing.Point(132, 79);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(60, 22);
            this.txtType.TabIndex = 5;
            // 
            // lblCOLOR
            // 
            this.lblCOLOR.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCOLOR.Location = new System.Drawing.Point(21, 109);
            this.lblCOLOR.Name = "lblCOLOR";
            this.lblCOLOR.Size = new System.Drawing.Size(105, 17);
            this.lblCOLOR.TabIndex = 0;
            this.lblCOLOR.Text = "Transcation No.";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTxNumber.Location = new System.Drawing.Point(132, 103);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(100, 22);
            this.txtTxNumber.TabIndex = 6;
            // 
            // txtShop
            // 
            this.txtShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtShop.Location = new System.Drawing.Point(132, 55);
            this.txtShop.Name = "txtShop";
            this.txtShop.Size = new System.Drawing.Size(60, 22);
            this.txtShop.TabIndex = 1;
            // 
            // lblShop
            // 
            this.lblShop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblShop.Location = new System.Drawing.Point(21, 58);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(74, 17);
            this.lblShop.TabIndex = 0;
            this.lblShop.Text = "Shop ID*";
            // 
            // rptViewer
            // 
            this.rptViewer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.rptViewer.Datasource = null;
            this.rptViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Parameters = null;
            this.rptViewer.ReportDatasourceName = "";
            this.rptViewer.ReportDestination = RT2020.Web.Reports.Controls.Viewer.ReportDestinations.Preview;
            this.rptViewer.ReportName = "";
            this.rptViewer.Size = new System.Drawing.Size(678, 419);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = null;
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            // 
            // DailyShopTransaction
            // 
            this.AcceptButton = this.btnSearch;
            this.Controls.Add(this.mainPane);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(690, 600);
            this.Text = "DailyShopTransaction";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;
        private Gizmox.WebGUI.Forms.Label lblShop;
        private Gizmox.WebGUI.Forms.TextBox txtShop;
        private Gizmox.WebGUI.Forms.Label lblFABRICS;
        private Gizmox.WebGUI.Forms.TextBox txtType;
        private Gizmox.WebGUI.Forms.Label lblCOLOR;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private System.ServiceProcess.ServiceController serviceController1;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtDate;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.TextBox txtYear;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.TextBox txtMonth;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label6;


    }
}