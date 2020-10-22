namespace RT2020.AtsPane
{
    partial class SettingsAts
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
            this.atsSettings = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsSettings
            // 
            this.atsSettings.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsSettings.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsSettings.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsSettings.DragHandle = true;
            this.atsSettings.DropDownArrows = false;
            this.atsSettings.ImageList = null;
            this.atsSettings.Location = new System.Drawing.Point(0, 0);
            this.atsSettings.MenuHandle = true;
            this.atsSettings.Name = "atsSettings";
            //this.atsSettings.RightToLeft = false;
            this.atsSettings.ShowToolTips = true;
            this.atsSettings.TabIndex = 0;
            // 
            // Settings
            // 
            this.Controls.Add(this.atsSettings);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsSettings;


    }
}