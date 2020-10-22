namespace RT2020.NavPane
{
    partial class SettingsNav
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
            this.navSettings = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navSettings
            // 
            this.navSettings.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navSettings.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navSettings.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navSettings.Location = new System.Drawing.Point(0, 0);
            this.navSettings.Name = "navSettings";
            this.navSettings.ShowLines = false;
            this.navSettings.Size = new System.Drawing.Size(391, 391);
            this.navSettings.TabIndex = 0;
            this.navSettings.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navSettings_AfterSelect);
            // 
            // Settings
            // 
            this.Controls.Add(this.navSettings);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView navSettings;


    }
}