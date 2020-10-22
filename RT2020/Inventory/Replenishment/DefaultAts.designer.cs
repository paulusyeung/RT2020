namespace RT2020.Inventory.Replenishment
{
    partial class DefaultAts
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
            this.atsReplenishment = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsReplenishment
            // 
            this.atsReplenishment.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsReplenishment.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsReplenishment.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsReplenishment.DragHandle = true;
            this.atsReplenishment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsReplenishment.DropDownArrows = false;
            this.atsReplenishment.ImageList = null;
            this.atsReplenishment.Location = new System.Drawing.Point(0, 0);
            this.atsReplenishment.MenuHandle = true;
            this.atsReplenishment.Name = "atsReplenishment";
            //this.atsReplenishment.RightToLeft = false;
            this.atsReplenishment.ShowToolTips = true;
            this.atsReplenishment.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsReplenishment);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsReplenishment;


    }
}