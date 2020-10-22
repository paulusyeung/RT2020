namespace RT2020.NavPane
{
    partial class InventoryNav
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
            this.navInvt = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navInvt
            // 
            this.navInvt.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navInvt.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navInvt.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navInvt.Location = new System.Drawing.Point(0, 0);
            this.navInvt.Name = "navInvt";
            this.navInvt.ShowLines = false;
            this.navInvt.Size = new System.Drawing.Size(391, 391);
            this.navInvt.TabIndex = 0;
            this.navInvt.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navInvt_AfterSelect);
            // 
            // Inventory
            // 
            this.Controls.Add(this.navInvt);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView navInvt;


    }
}