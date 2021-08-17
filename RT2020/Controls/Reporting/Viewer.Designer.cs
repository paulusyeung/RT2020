namespace RT2020.Controls.Reporting
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.RptViewer = new RT2020.Controls.Reporting.ReportViewer();
            this._RT2020_Controls_Reporting_DataSource1 = new RT2020.Controls.Reporting._RT2020_Controls_Reporting_DataSource();
            ((System.ComponentModel.ISupportInitialize)(this._RT2020_Controls_Reporting_DataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // RptViewer
            // 
            this.RptViewer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.RptViewer.ControlCode = resources.GetString("RptViewer.ControlCode");
            this.RptViewer.Location = new System.Drawing.Point(351, 372);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.Size = new System.Drawing.Size(345, 159);
            this.RptViewer.SizeToReportContent = true;
            this.RptViewer.TabIndex = 0;
            this.RptViewer.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.RptViewer.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.RptViewer_HostedPageLoad);
            this.RptViewer.HostedPageLoadComplete += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.RptViewer_HostedPageLoadComplete);
            // 
            // _RT2020_Controls_Reporting_DataSource1
            // 
            this._RT2020_Controls_Reporting_DataSource1.DataSetName = "RT2020.Controls.Reporting.DataSource";
            this._RT2020_Controls_Reporting_DataSource1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Viewer
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.RptViewer);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this._RT2020_Controls_Reporting_DataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReportViewer RptViewer;
        private _RT2020_Controls_Reporting_DataSource _RT2020_Controls_Reporting_DataSource1;
    }
}