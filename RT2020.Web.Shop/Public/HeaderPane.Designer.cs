namespace RT2020.Web.Shop.Public
{
    partial class HeaderPane
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.topPane = new Gizmox.WebGUI.Forms.Panel();
            this.lblShop = new Gizmox.WebGUI.Forms.Label();
            this.lblFormTitle = new Gizmox.WebGUI.Forms.Label();
            this.lnkLogoff = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lblCompanyName = new Gizmox.WebGUI.Forms.Label();
            this.lblVersionNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTitle = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // topPane
            // 
            this.topPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.topPane.BackColor = System.Drawing.Color.LightYellow;
            iconResourceHandle1.File = "2x2.ico_lrg_hdr_bg_2x106.png";
            this.topPane.BackgroundImage = iconResourceHandle1;
            this.topPane.Controls.Add(this.lblShop);
            this.topPane.Controls.Add(this.lblFormTitle);
            this.topPane.Controls.Add(this.lnkLogoff);
            this.topPane.Controls.Add(this.lblCompanyName);
            this.topPane.Controls.Add(this.lblVersionNumber);
            this.topPane.Controls.Add(this.lblTitle);
            this.topPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.topPane.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(580, 106);
            this.topPane.TabIndex = 1;
            // 
            // lblShop
            // 
            this.lblShop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblShop.AutoSize = true;
            this.lblShop.BackColor = System.Drawing.Color.Gold;
            this.lblShop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblShop.Location = new System.Drawing.Point(382, 56);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(49, 13);
            this.lblShop.TabIndex = 5;
            this.lblShop.Text = "{Shop}";
            this.lblShop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFormTitle.Location = new System.Drawing.Point(80, 74);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(54, 17);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "{Form}";
            // 
            // lnkLogoff
            // 
            this.lnkLogoff.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lnkLogoff.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogoff.Location = new System.Drawing.Point(413, 70);
            this.lnkLogoff.Name = "lnkLogoff";
            this.lnkLogoff.Size = new System.Drawing.Size(100, 23);
            this.lnkLogoff.TabIndex = 3;
            this.lnkLogoff.Text = "Log off";
            this.lnkLogoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLogoff.Click += new System.EventHandler(this.lnkLogoff_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(291, 36);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(92, 13);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "{Company Name}";
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.ForeColor = System.Drawing.Color.Silver;
            this.lblVersionNumber.Location = new System.Drawing.Point(221, 56);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(92, 13);
            this.lblVersionNumber.TabIndex = 1;
            this.lblVersionNumber.Text = "{Version Number}";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(34, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(251, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RT2020 Web Access";
            // 
            // HeaderPane
            // 
            this.Controls.Add(this.topPane);
            this.Size = new System.Drawing.Size(580, 106);
            this.Text = "HeaderPane";
            this.Load += new System.EventHandler(this.HeaderPane_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel topPane;
        private Gizmox.WebGUI.Forms.Label lblCompanyName;
        private Gizmox.WebGUI.Forms.Label lblVersionNumber;
        private Gizmox.WebGUI.Forms.Label lblTitle;
        private Gizmox.WebGUI.Forms.LinkLabel lnkLogoff;
        private Gizmox.WebGUI.Forms.Label lblFormTitle;
        private Gizmox.WebGUI.Forms.Label lblShop;


    }
}