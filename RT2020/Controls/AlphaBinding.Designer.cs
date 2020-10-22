namespace RT2020.Controls
{
    partial class AlphaBinding
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
            this.flowLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.flowLayoutPanel.DockPadding.All = 3;
            this.flowLayoutPanel.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(720, 26);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // AlphaBinding
            // 
            this.Controls.Add(this.flowLayoutPanel);
            this.Size = new System.Drawing.Size(720, 26);
            this.Text = "AlphaBinding";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel;


    }
}