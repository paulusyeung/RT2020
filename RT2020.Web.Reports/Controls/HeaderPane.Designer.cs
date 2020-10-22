namespace RT2020.Web.Reports.Controls
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
            this.lnkGotoWepShop = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkHome = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lblStatement = new Gizmox.WebGUI.Forms.Label();
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
            this.topPane.Controls.Add(this.lnkGotoWepShop);
            this.topPane.Controls.Add(this.lnkHome);
            this.topPane.Controls.Add(this.lblStatement);
            this.topPane.Controls.Add(this.lblCompanyName);
            this.topPane.Controls.Add(this.lblVersionNumber);
            this.topPane.Controls.Add(this.lblTitle);
            this.topPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.topPane.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topPane.Location = new System.Drawing.Point(0, 0);
            this.topPane.Name = "topPane";
            this.topPane.Size = new System.Drawing.Size(764, 106);
            this.topPane.TabIndex = 1;
            // 
            // lnkGotoWepShop
            // 
            this.lnkGotoWepShop.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lnkGotoWepShop.Location = new System.Drawing.Point(418, 80);
            this.lnkGotoWepShop.Name = "lnkGotoWepShop";
            this.lnkGotoWepShop.Size = new System.Drawing.Size(87, 13);
            this.lnkGotoWepShop.TabIndex = 6;
            this.lnkGotoWepShop.Text = "Go To Web Shop";
            // 
            // lnkHome
            // 
            this.lnkHome.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lnkHome.AutoSize = true;
            this.lnkHome.Location = new System.Drawing.Point(304, 80);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(34, 13);
            this.lnkHome.TabIndex = 3;
            this.lnkHome.Text = "Home";
            this.lnkHome.Click += new System.EventHandler(this.lnkHome_Click);
            // 
            // lblStatement
            // 
            this.lblStatement.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblStatement.AutoSize = true;
            this.lblStatement.ForeColor = System.Drawing.Color.Silver;
            this.lblStatement.Location = new System.Drawing.Point(522, 80);
            this.lblStatement.Name = "lblStatement";
            this.lblStatement.Size = new System.Drawing.Size(239, 13);
            this.lblStatement.TabIndex = 2;
            this.lblStatement.Text = "Developed By: Synergy Information System Ltd.";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(88, 80);
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
            this.lblVersionNumber.Location = new System.Drawing.Point(304, 33);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(92, 13);
            this.lblVersionNumber.TabIndex = 1;
            this.lblVersionNumber.Text = "{Version Number}";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(42, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RT2020 > Web Reports";
            // 
            // HeaderPane
            // 
            this.Controls.Add(this.topPane);
            this.Size = new System.Drawing.Size(764, 106);
            this.Text = "HeaderPane";
            this.Load += new System.EventHandler(this.HeaderPane_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel topPane;
        private Gizmox.WebGUI.Forms.Label lblCompanyName;
        private Gizmox.WebGUI.Forms.Label lblVersionNumber;
        private Gizmox.WebGUI.Forms.Label lblTitle;
        private Gizmox.WebGUI.Forms.Label lblStatement;
        private Gizmox.WebGUI.Forms.LinkLabel lnkHome;
        private Gizmox.WebGUI.Forms.LinkLabel lnkGotoWepShop;


    }
}