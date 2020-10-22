namespace RT2020.NavPane
{
    partial class ProductNav
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
            this.navProduct = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navSettings
            // 
            this.navProduct.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navProduct.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navProduct.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navProduct.Location = new System.Drawing.Point(0, 0);
            this.navProduct.Name = "navProduct";
            this.navProduct.ShowLines = false;
            this.navProduct.Size = new System.Drawing.Size(391, 391);
            this.navProduct.TabIndex = 0;
            this.navProduct.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navSettings_AfterSelect);
            // 
            // Settings
            // 
            this.Controls.Add(this.navProduct);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Product Care";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView navProduct;


    }
}