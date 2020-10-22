namespace RT2020.Web.Reports.Forms
{
    partial class VIPProfile_Inline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIPProfile_Inline));
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.txtFirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFirstName = new Gizmox.WebGUI.Forms.Label();
            this.lblVip = new Gizmox.WebGUI.Forms.Label();
            this.txtVip = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNickName = new Gizmox.WebGUI.Forms.Label();
            this.txtNickName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhone = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhone = new Gizmox.WebGUI.Forms.Label();
            this.txtLastName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLastName = new Gizmox.WebGUI.Forms.Label();
            this.txtID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblID = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.pnlLeft.Controls.Add(this.txtFirstName);
            this.pnlLeft.Controls.Add(this.lblFirstName);
            this.pnlLeft.Controls.Add(this.lblVip);
            this.pnlLeft.Controls.Add(this.txtVip);
            this.pnlLeft.Controls.Add(this.lblNickName);
            this.pnlLeft.Controls.Add(this.txtNickName);
            this.pnlLeft.Controls.Add(this.txtPhone);
            this.pnlLeft.Controls.Add(this.lblPhone);
            this.pnlLeft.Controls.Add(this.txtLastName);
            this.pnlLeft.Controls.Add(this.lblLastName);
            this.pnlLeft.Controls.Add(this.txtID);
            this.pnlLeft.Controls.Add(this.lblID);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(190, 600);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(15, 172);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(160, 22);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtFirstName_EnterKeyDown);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFirstName.Location = new System.Drawing.Point(15, 150);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(84, 17);
            this.lblFirstName.TabIndex = 5;
            this.lblFirstName.Text = "First Name";
            // 
            // lblVip
            // 
            this.lblVip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVip.Location = new System.Drawing.Point(13, 32);
            this.lblVip.Name = "lblVip";
            this.lblVip.Size = new System.Drawing.Size(74, 17);
            this.lblVip.TabIndex = 1;
            this.lblVip.Text = "VIP#";
            // 
            // txtVip
            // 
            this.txtVip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtVip.Location = new System.Drawing.Point(15, 52);
            this.txtVip.Name = "txtVip";
            this.txtVip.Size = new System.Drawing.Size(160, 22);
            this.txtVip.TabIndex = 2;
            this.txtVip.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtVip_EnterKeyDown);
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNickName.Location = new System.Drawing.Point(13, 90);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(74, 17);
            this.lblNickName.TabIndex = 3;
            this.lblNickName.Text = "Nick Name";
            // 
            // txtNickName
            // 
            this.txtNickName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNickName.Location = new System.Drawing.Point(15, 110);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(160, 22);
            this.txtNickName.TabIndex = 4;
            this.txtNickName.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtNickName_EnterKeyDown);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPhone.Location = new System.Drawing.Point(15, 294);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(160, 22);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtPhone_EnterKeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPhone.Location = new System.Drawing.Point(15, 274);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(74, 17);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Phone";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtLastName.Location = new System.Drawing.Point(15, 235);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(160, 22);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtLastName_EnterKeyDown);
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLastName.Location = new System.Drawing.Point(14, 215);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 17);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtID.Location = new System.Drawing.Point(15, 358);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(160, 22);
            this.txtID.TabIndex = 12;
            this.txtID.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtID_EnterKeyDown);
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblID.Location = new System.Drawing.Point(15, 338);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 17);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "ID#";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(15, 401);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
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
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 0;
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
            this.rptViewer.Size = new System.Drawing.Size(606, 600);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = ((System.Collections.Generic.Dictionary<string, System.Data.DataTable>)(resources.GetObject("rptViewer.SubReportDataSourceList")));
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            this.rptViewer.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.rptViewer.ZoomPercent = 0;
            // 
            // VIPProfile_Inline
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
        private Gizmox.WebGUI.Forms.TextBox txtFirstName;
        private Gizmox.WebGUI.Forms.Label lblFirstName;
        private Gizmox.WebGUI.Forms.Label lblVip;
        private Gizmox.WebGUI.Forms.TextBox txtVip;
        private Gizmox.WebGUI.Forms.Label lblNickName;
        private Gizmox.WebGUI.Forms.TextBox txtNickName;
        private Gizmox.WebGUI.Forms.TextBox txtPhone;
        private Gizmox.WebGUI.Forms.Label lblPhone;
        private Gizmox.WebGUI.Forms.TextBox txtLastName;
        private Gizmox.WebGUI.Forms.Label lblLastName;
        private Gizmox.WebGUI.Forms.TextBox txtID;
        private Gizmox.WebGUI.Forms.Label lblID;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Label label1;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;


    }
}