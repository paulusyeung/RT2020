namespace RT2020.Inventory.Transfer
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
            this.atsTransfer = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsTransfer
            // 
            this.atsTransfer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsTransfer.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsTransfer.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsTransfer.DragHandle = true;
            this.atsTransfer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.atsTransfer.DropDownArrows = false;
            this.atsTransfer.ImageList = null;
            this.atsTransfer.Location = new System.Drawing.Point(0, 0);
            this.atsTransfer.MenuHandle = true;
            this.atsTransfer.Name = "atsTransfer";
            //this.atsTransfer.RightToLeft = false;
            this.atsTransfer.ShowToolTips = true;
            this.atsTransfer.TabIndex = 0;
            // 
            // DefaultAts
            // 
            this.Controls.Add(this.atsTransfer);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsTransfer;


    }
}