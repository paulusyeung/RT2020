namespace RT2020.AtsPane
{
    partial class InventoryAts
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
            this.atsInvt = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsInvt
            // 
            this.atsInvt.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsInvt.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsInvt.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsInvt.DragHandle = true;
            this.atsInvt.DropDownArrows = false;
            this.atsInvt.ImageList = null;
            this.atsInvt.Location = new System.Drawing.Point(0, 0);
            this.atsInvt.MenuHandle = true;
            this.atsInvt.Name = "atsInvt";
            //this.atsInvt.RightToLeft = false;
            this.atsInvt.ShowToolTips = true;
            this.atsInvt.TabIndex = 0;
            // 
            // Inventory
            // 
            this.Controls.Add(this.atsInvt);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsInvt;


    }
}