namespace RT2020.Web.Reports.Forms
{
    partial class VIPProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIPProfile));
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhone = new Gizmox.WebGUI.Forms.Label();
            this.txtPhone = new Gizmox.WebGUI.Forms.TextBox();
            this.lblID = new Gizmox.WebGUI.Forms.Label();
            this.txtID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFirstName = new Gizmox.WebGUI.Forms.Label();
            this.txtFirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLastName = new Gizmox.WebGUI.Forms.Label();
            this.txtLastName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNickName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNickName = new Gizmox.WebGUI.Forms.Label();
            this.txtVip = new Gizmox.WebGUI.Forms.TextBox();
            this.lblVip = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.lblPhone);
            this.splitContainer.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer.Panel1.Controls.Add(this.lblID);
            this.splitContainer.Panel1.Controls.Add(this.txtID);
            this.splitContainer.Panel1.Controls.Add(this.lblFirstName);
            this.splitContainer.Panel1.Controls.Add(this.txtFirstName);
            this.splitContainer.Panel1.Controls.Add(this.lblLastName);
            this.splitContainer.Panel1.Controls.Add(this.txtLastName);
            this.splitContainer.Panel1.Controls.Add(this.txtNickName);
            this.splitContainer.Panel1.Controls.Add(this.lblNickName);
            this.splitContainer.Panel1.Controls.Add(this.txtVip);
            this.splitContainer.Panel1.Controls.Add(this.lblVip);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer.Size = new System.Drawing.Size(678, 588);
            this.splitContainer.SplitterDistance = 212;
            this.splitContainer.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(110, 179);
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
            this.label1.Size = new System.Drawing.Size(568, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "VIP Profile  Enquiry";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPhone.Location = new System.Drawing.Point(21, 130);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(74, 17);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone#";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPhone.Location = new System.Drawing.Point(110, 127);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblID.Location = new System.Drawing.Point(21, 154);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 17);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID#";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtID.Location = new System.Drawing.Point(110, 151);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 6;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFirstName.Location = new System.Drawing.Point(21, 82);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(74, 17);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(110, 79);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLastName.Location = new System.Drawing.Point(21, 106);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(74, 17);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtLastName.Location = new System.Drawing.Point(110, 103);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 22);
            this.txtLastName.TabIndex = 4;
            // 
            // txtNickName
            // 
            this.txtNickName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNickName.Location = new System.Drawing.Point(110, 55);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(100, 22);
            this.txtNickName.TabIndex = 2;
            // 
            // lblNickName
            // 
            this.lblNickName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNickName.Location = new System.Drawing.Point(21, 58);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(74, 17);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "Nick Name";
            // 
            // txtVip
            // 
            this.txtVip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtVip.Location = new System.Drawing.Point(110, 31);
            this.txtVip.Name = "txtVip";
            this.txtVip.Size = new System.Drawing.Size(100, 22);
            this.txtVip.TabIndex = 1;
            // 
            // lblVip
            // 
            this.lblVip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblVip.Location = new System.Drawing.Point(21, 34);
            this.lblVip.Name = "lblVip";
            this.lblVip.Size = new System.Drawing.Size(74, 17);
            this.lblVip.TabIndex = 0;
            this.lblVip.Text = "VIP#";
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
            this.rptViewer.Size = new System.Drawing.Size(678, 372);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = ((System.Collections.Generic.Dictionary<string, System.Data.DataTable>)(resources.GetObject("rptViewer.SubReportDataSourceList")));
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            // 
            // VIPProfile
            // 
            this.AcceptButton = this.btnSearch;
            this.Controls.Add(this.mainPane);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(690, 600);
            this.Text = "VIPProfileEnquiry";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;
        private Gizmox.WebGUI.Forms.Label lblVip;
        private Gizmox.WebGUI.Forms.TextBox txtVip;
        private Gizmox.WebGUI.Forms.Label lblPhone;
        private Gizmox.WebGUI.Forms.TextBox txtPhone;
        private Gizmox.WebGUI.Forms.Label lblID;
        private Gizmox.WebGUI.Forms.TextBox txtID;
        private Gizmox.WebGUI.Forms.Label lblFirstName;
        private Gizmox.WebGUI.Forms.TextBox txtFirstName;
        private Gizmox.WebGUI.Forms.Label lblLastName;
        private Gizmox.WebGUI.Forms.TextBox txtLastName;
        private Gizmox.WebGUI.Forms.TextBox txtNickName;
        private Gizmox.WebGUI.Forms.Label lblNickName;
        private System.ServiceProcess.ServiceController serviceController1;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnSearch;


    }
}