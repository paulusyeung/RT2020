using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.NavPane
{
    partial class ShopNav
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
            this.navShop = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navShop
            // 
            this.navShop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navShop.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navShop.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navShop.Location = new System.Drawing.Point(0, 0);
            this.navShop.Name = "navShop";
            this.navShop.ShowLines = false;
            this.navShop.Size = new System.Drawing.Size(100, 100);
            this.navShop.TabIndex = 0;
            this.navShop.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navShop_AfterSelect);
            // 
            // ShopNav
            // 
            this.Controls.Add(this.navShop);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ShopNav";
            this.ResumeLayout(false);

        }


        #endregion

        private TreeView navShop;
    }
}