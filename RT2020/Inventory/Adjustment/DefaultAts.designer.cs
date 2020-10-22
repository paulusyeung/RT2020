namespace RT2020.Inventory.Adjustment
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
            this.atsAdjustment = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsAdjustment
            // 
            this.atsAdjustment.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsAdjustment.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsAdjustment.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsAdjustment.DragHandle = true;
            this.atsAdjustment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsAdjustment.DropDownArrows = false;
            this.atsAdjustment.ImageList = null;
            this.atsAdjustment.Location = new System.Drawing.Point(0, 0);
            this.atsAdjustment.MenuHandle = true;
            this.atsAdjustment.Name = "atsAdjustment";
            //this.atsAdjustment.RightToLeft = false;
            this.atsAdjustment.ShowToolTips = true;
            this.atsAdjustment.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsAdjustment);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsAdjustment;


    }
}