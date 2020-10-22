namespace RT2020.Inventory.GoodsReceive
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
            this.atsGoodsReceive = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsGoodsReceive
            // 
            this.atsGoodsReceive.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsGoodsReceive.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsGoodsReceive.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsGoodsReceive.DragHandle = true;
            this.atsGoodsReceive.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsGoodsReceive.DropDownArrows = false;
            this.atsGoodsReceive.ImageList = null;
            this.atsGoodsReceive.Location = new System.Drawing.Point(0, 0);
            this.atsGoodsReceive.MenuHandle = true;
            this.atsGoodsReceive.Name = "atsGoodsReceive";
            //this.atsGoodsReceive.RightToLeft = false;
            this.atsGoodsReceive.ShowToolTips = true;
            this.atsGoodsReceive.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsGoodsReceive);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsGoodsReceive;


    }
}