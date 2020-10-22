namespace RT2020.Inventory.GoodsReturn
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
            this.atsGoodsReturn = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsGoodsReturn
            // 
            this.atsGoodsReturn.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsGoodsReturn.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsGoodsReturn.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsGoodsReturn.DragHandle = true;
            this.atsGoodsReturn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsGoodsReturn.DropDownArrows = false;
            this.atsGoodsReturn.ImageList = null;
            this.atsGoodsReturn.Location = new System.Drawing.Point(0, 0);
            this.atsGoodsReturn.MenuHandle = true;
            this.atsGoodsReturn.Name = "atsGoodsReturn";
            //this.atsGoodsReturn.RightToLeft = false;
            this.atsGoodsReturn.ShowToolTips = true;
            this.atsGoodsReturn.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsGoodsReturn);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsGoodsReturn;


    }
}