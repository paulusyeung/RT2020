namespace RT2020.Web.Reports
{
    partial class WebReports
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
            this.headerPane = new RT2020.Web.Reports.Controls.HeaderPane();
            this.advancePane = new Gizmox.WebGUI.Forms.Panel();
            this.listPane = new Gizmox.WebGUI.Forms.Panel();
            this.customPanel = new RT2020.Web.Reports.Controls.CustomPanel.CustomPanel();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.splitContainer);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(800, 600);
            this.mainPane.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.LightYellow;
            this.splitContainer.Panel1.Controls.Add(this.headerPane);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.Panel2.Controls.Add(this.advancePane);
            this.splitContainer.Size = new System.Drawing.Size(800, 600);
            this.splitContainer.SplitterDistance = 106;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // headerPane
            // 
            this.headerPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.headerPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.headerPane.Location = new System.Drawing.Point(0, 0);
            this.headerPane.Name = "headerPane";
            this.headerPane.Size = new System.Drawing.Size(800, 106);
            this.headerPane.TabIndex = 0;
            this.headerPane.Text = "HeaderPane";
            // 
            // advancePane
            // 
            this.advancePane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.advancePane.Controls.Add(this.listPane);
            this.advancePane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.advancePane.Location = new System.Drawing.Point(0, 0);
            this.advancePane.Name = "advancePane";
            this.advancePane.Size = new System.Drawing.Size(800, 493);
            this.advancePane.TabIndex = 7;
            // 
            // listPane
            // 
            this.listPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.listPane.Controls.Add(this.customPanel);
            this.listPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listPane.DockPadding.Top = 6;
            this.listPane.Location = new System.Drawing.Point(0, 0);
            this.listPane.Name = "listPane";
            this.listPane.Size = new System.Drawing.Size(800, 493);
            this.listPane.TabIndex = 2;
            // 
            // customPanel
            // 
            this.customPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.customPanel.AutoScroll = true;
            this.customPanel.DataSource = null;
            this.customPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.customPanel.Location = new System.Drawing.Point(0, 6);
            this.customPanel.Name = "customPanel";
            this.customPanel.PanelType = RT2020.Web.Reports.Controls.CustomPanel.PanelEnums.PanelViews.CardView;
            this.customPanel.Size = new System.Drawing.Size(800, 487);
            this.customPanel.TabIndex = 1;
            this.customPanel.Text = "PanelList";
            this.customPanel.Click += new System.EventHandler(this.customPanel_Click);
            // 
            // Default
            // 
            this.Controls.Add(this.mainPane);
            this.Location = new System.Drawing.Point(-7, 15);
            this.Size = new System.Drawing.Size(800, 600);
            this.Text = "RT2020 > Web Reports";
            this.Load += new System.EventHandler(this.Default_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Panel advancePane;
        private RT2020.Web.Reports.Controls.HeaderPane headerPane;
        private Gizmox.WebGUI.Forms.Panel listPane;
        private RT2020.Web.Reports.Controls.CustomPanel.CustomPanel customPanel;
    }
}
