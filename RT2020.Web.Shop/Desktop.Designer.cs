namespace RT2020.Web.Shop
{
    partial class Desktop
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle4 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.btnGotoReplenishment = new Gizmox.WebGUI.Forms.Button();
            this.btnGotoTransferIn = new Gizmox.WebGUI.Forms.Button();
            this.flowLayoutPanel = new Gizmox.WebGUI.Forms.FlowLayoutPanel();
            this.headerPane = new RT2020.Web.Shop.Public.HeaderPane();
            this.SuspendLayout();
            // 
            // btnGotoReplenishment
            // 
            this.btnGotoReplenishment.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            iconResourceHandle1.File = "2x2.ico_lrg_btn_bg_2x106.png";
            this.btnGotoReplenishment.BackgroundImage = iconResourceHandle1;
            this.btnGotoReplenishment.Font = new System.Drawing.Font("Tahoma", 16F);
            iconResourceHandle2.File = "48x48.ico_rpl_48x48.png";
            this.btnGotoReplenishment.Image = iconResourceHandle2;
            this.btnGotoReplenishment.Location = new System.Drawing.Point(18, 18);
            this.btnGotoReplenishment.Name = "btnGotoReplenishment";
            this.btnGotoReplenishment.Size = new System.Drawing.Size(280, 106);
            this.btnGotoReplenishment.TabIndex = 0;
            this.btnGotoReplenishment.Text = "Stock Replenishment Confirmation";
            this.btnGotoReplenishment.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.btnGotoReplenishment.Click += new System.EventHandler(this.btnGotoReplenishment_Click);
            // 
            // btnGotoTransferIn
            // 
            this.btnGotoTransferIn.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            iconResourceHandle3.File = "2x2.ico_lrg_btn_bg_2x106.png";
            this.btnGotoTransferIn.BackgroundImage = iconResourceHandle3;
            this.btnGotoTransferIn.Font = new System.Drawing.Font("Tahoma", 16F);
            iconResourceHandle4.File = "48x48.ico_txf_48x48.png";
            this.btnGotoTransferIn.Image = iconResourceHandle4;
            this.btnGotoTransferIn.Location = new System.Drawing.Point(304, 18);
            this.btnGotoTransferIn.Name = "btnGotoTransferIn";
            this.btnGotoTransferIn.Size = new System.Drawing.Size(280, 106);
            this.btnGotoTransferIn.TabIndex = 1;
            this.btnGotoTransferIn.Text = "Transfer-In Confirmation";
            this.btnGotoTransferIn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            this.btnGotoTransferIn.Click += new System.EventHandler(this.btnGotoTransferIn_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.flowLayoutPanel.Controls.Add(this.btnGotoReplenishment);
            this.flowLayoutPanel.Controls.Add(this.btnGotoTransferIn);
            this.flowLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.flowLayoutPanel.DockPadding.All = 15;
            this.flowLayoutPanel.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 111);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(623, 518);
            this.flowLayoutPanel.TabIndex = 3;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // headerPane
            // 
            this.headerPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.headerPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.headerPane.FormTitle = "{Form}";
            this.headerPane.Location = new System.Drawing.Point(0, 0);
            this.headerPane.Name = "headerPane";
            this.headerPane.Size = new System.Drawing.Size(623, 111);
            this.headerPane.TabIndex = 2;
            this.headerPane.Text = "HeaderPane";
            // 
            // Desktop
            // 
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.headerPane);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Size = new System.Drawing.Size(623, 629);
            this.Text = "RT2020 > Web Shop";
            this.Load += new System.EventHandler(this.Default_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnGotoReplenishment;
        private Gizmox.WebGUI.Forms.Button btnGotoTransferIn;
        private RT2020.Web.Shop.Public.HeaderPane headerPane;
        private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel;

    }
}