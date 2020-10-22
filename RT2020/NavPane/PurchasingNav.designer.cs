namespace RT2020.NavPane
{
    partial class PurchasingNav
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
            this.navPurchase = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navPurchase
            // 
            this.navPurchase.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navPurchase.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navPurchase.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navPurchase.Location = new System.Drawing.Point(0, 0);
            this.navPurchase.Name = "navPurchase";
            this.navPurchase.ShowLines = false;
            this.navPurchase.Size = new System.Drawing.Size(391, 391);
            this.navPurchase.TabIndex = 0;
            this.navPurchase.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navPurchase_AfterSelect);
            // 
            // Purchasing
            // 
            this.Controls.Add(this.navPurchase);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Purchasing";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView navPurchase;


    }
}