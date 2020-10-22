namespace RT2020.Web.Reports.Controls
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.RptViewer = new RT2020.Web.Reports.Controls.Reporting.ReportViewer();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.RptViewer);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(742, 607);
            this.mainPane.TabIndex = 1;
            // 
            // RptViewer
            // 
            this.RptViewer.ControlCode = resources.GetString("RptViewer.ControlCode");
            this.RptViewer.Location = new System.Drawing.Point(0, 0);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.Size = new System.Drawing.Size(400, 400);
            this.RptViewer.SizeToReportContent = true;
            this.RptViewer.TabIndex = 0;
            this.RptViewer.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.RptViewer.HostedControlPreRender += new Gizmox.WebGUI.Forms.Hosts.AspControlEventHandler(this.RptViewer_HostedControlPreRender);
            this.RptViewer.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.RptViewer_ReportRefresh);
            this.RptViewer.Drillthrough += new Microsoft.Reporting.WebForms.DrillthroughEventHandler(this.RptViewer_Drillthrough);
            // 
            // Viewer
            // 
            this.Controls.Add(this.mainPane);
            this.Size = new System.Drawing.Size(742, 607);
            this.Text = "Viewer";
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        public RT2020.Web.Reports.Controls.Reporting.ReportViewer RptViewer;


    }
}