namespace RT2020.Web.Reports.Forms
{
    partial class StockInOutHistory
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
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.dtDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtSTK = new Gizmox.WebGUI.Forms.TextBox();
            this.chkUnPosted = new Gizmox.WebGUI.Forms.CheckBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtFromSTK = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSTYLE = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer.Panel1.Controls.Add(this.dtDateTo);
            this.splitContainer.Panel1.Controls.Add(this.dtDateFrom);
            this.splitContainer.Panel1.Controls.Add(this.txtSTK);
            this.splitContainer.Panel1.Controls.Add(this.chkUnPosted);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.lblBarcode);
            this.splitContainer.Panel1.Controls.Add(this.txtFromSTK);
            this.splitContainer.Panel1.Controls.Add(this.lblSTYLE);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer.Size = new System.Drawing.Size(678, 588);
            this.splitContainer.SplitterDistance = 172;
            this.splitContainer.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(86, 143);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtDateTo
            // 
            this.dtDateTo.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(86, 91);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(103, 20);
            this.dtDateTo.TabIndex = 4;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(86, 65);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(103, 22);
            this.dtDateFrom.TabIndex = 3;
            // 
            // txtSTK
            // 
            this.txtSTK.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSTK.Location = new System.Drawing.Point(234, 36);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(100, 22);
            this.txtSTK.TabIndex = 2;
            // 
            // chkUnPosted
            // 
            this.chkUnPosted.Checked = false;
            this.chkUnPosted.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkUnPosted.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkUnPosted.Location = new System.Drawing.Point(17, 119);
            this.chkUnPosted.Name = "chkUnPosted";
            this.chkUnPosted.Size = new System.Drawing.Size(247, 20);
            this.chkUnPosted.TabIndex = 5;
            this.chkUnPosted.Text = "Display of Un-Posted FEP Data";
            this.chkUnPosted.ThreeState = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(195, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "(DD/MM/YYYY)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(195, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "(DD/MM/YYYY)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "To Date";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "From Date";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock In/Out History";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(198, 39);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(30, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "To";
            // 
            // txtFromSTK
            // 
            this.txtFromSTK.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFromSTK.Location = new System.Drawing.Point(88, 36);
            this.txtFromSTK.Name = "txtFromSTK";
            this.txtFromSTK.Size = new System.Drawing.Size(100, 22);
            this.txtFromSTK.TabIndex = 1;
            // 
            // lblSTYLE
            // 
            this.lblSTYLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSTYLE.Location = new System.Drawing.Point(17, 39);
            this.lblSTYLE.Name = "lblSTYLE";
            this.lblSTYLE.Size = new System.Drawing.Size(65, 17);
            this.lblSTYLE.TabIndex = 0;
            this.lblSTYLE.Text = "STYLE*";
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
            this.rptViewer.Size = new System.Drawing.Size(678, 412);
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            // 
            // StockInOutHistory
            // 
            this.Controls.Add(this.mainPane);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(690, 600);
            this.Text = "StockInOutHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;
        private Gizmox.WebGUI.Forms.TextBox txtFromSTK;
        private Gizmox.WebGUI.Forms.Label lblSTYLE;
        private System.ServiceProcess.ServiceController serviceController1;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.CheckBox chkUnPosted;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.TextBox txtSTK;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateTo;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateFrom;
        private Gizmox.WebGUI.Forms.Button btnSearch;


    }
}