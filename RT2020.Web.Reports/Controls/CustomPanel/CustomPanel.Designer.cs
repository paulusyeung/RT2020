namespace RT2020.Web.Reports.Controls.CustomPanel
{
    partial class CustomPanel
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
            this.flowLayoutPanel = new Gizmox.WebGUI.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.flowLayoutPanel.DockPadding.All = 24;
            this.flowLayoutPanel.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Margin = new Gizmox.WebGUI.Forms.Padding(3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(731, 599);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // CustomPanel
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.flowLayoutPanel);
            this.Size = new System.Drawing.Size(731, 599);
            this.Text = "PanelList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel;


    }
}