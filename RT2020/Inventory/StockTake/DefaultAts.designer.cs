namespace RT2020.Inventory.StockTake
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
            this.atsStockTake = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsStockTake
            // 
            this.atsStockTake.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsStockTake.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsStockTake.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsStockTake.DragHandle = true;
            this.atsStockTake.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsStockTake.DropDownArrows = false;
            this.atsStockTake.ImageList = null;
            this.atsStockTake.Location = new System.Drawing.Point(0, 0);
            this.atsStockTake.MenuHandle = true;
            this.atsStockTake.Name = "atsStockTake";
            //this.atsStockTake.RightToLeft = false;
            this.atsStockTake.ShowToolTips = true;
            this.atsStockTake.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsStockTake);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsStockTake;


    }
}