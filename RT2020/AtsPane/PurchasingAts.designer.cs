namespace RT2020.AtsPane
{
    partial class PurchasingAts
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
            this.atsPurchase = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsPurchase
            // 
            this.atsPurchase.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsPurchase.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsPurchase.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsPurchase.DragHandle = true;
            this.atsPurchase.DropDownArrows = false;
            this.atsPurchase.ImageList = null;
            this.atsPurchase.Location = new System.Drawing.Point(0, 0);
            this.atsPurchase.MenuHandle = true;
            this.atsPurchase.Name = "atsPurchase";
            //this.atsPurchase.RightToLeft = false;
            this.atsPurchase.ShowToolTips = true;
            this.atsPurchase.TabIndex = 0;
            // 
            // Inventory
            // 
            this.Controls.Add(this.atsPurchase);
            this.Size = new System.Drawing.Size(391, 24);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsPurchase;


    }
}