namespace RT2020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desktop));
            this.amsMain = new Gizmox.WebGUI.Forms.MainMenu();
            this.amsFile = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsFileExit = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsView = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewEn = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewChs = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewCht = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewVista = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewBlack = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsViewWinXP = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsHelp = new Gizmox.WebGUI.Forms.MenuItem();
            this.amsHelpAbout = new Gizmox.WebGUI.Forms.MenuItem();
            this.atsPane = new Gizmox.WebGUI.Forms.Panel();
            this.navPane = new Gizmox.WebGUI.Forms.Panel();
            this.navTabs = new Gizmox.WebGUI.Forms.NavigationTabs();
            this.tabInvt = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabPurchasing = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabMemberMgmt = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabSettings = new Gizmox.WebGUI.Forms.NavigationTab();
            this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
            this.wspPane = new Gizmox.WebGUI.Forms.HeaderedPanel();
            this.picBgImage = new Gizmox.WebGUI.Forms.PictureBox();
            this.pnlRight = new Gizmox.WebGUI.Forms.Panel();
            this.clientStorage1 = new Gizmox.WebGUI.Forms.Client.ClientStorage();
            this.navPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navTabs)).BeginInit();
            this.navTabs.SuspendLayout();
            this.wspPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBgImage)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // amsMain
            // 
            this.amsMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.amsMain.Location = new System.Drawing.Point(0, 0);
            this.amsMain.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.amsFile,
            this.amsView,
            this.amsHelp});
            this.amsMain.Name = "amsMain";
            this.amsMain.Size = new System.Drawing.Size(369, 22);
            this.amsMain.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.amsMain_MenuClick);
            // 
            // amsFile
            // 
            this.amsFile.Index = 0;
            this.amsFile.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.amsFileExit});
            this.amsFile.Tag = "amsFile";
            this.amsFile.Text = "File";
            // 
            // amsFileExit
            // 
            this.amsFileExit.Index = 0;
            this.amsFileExit.Tag = "amsFileExit";
            this.amsFileExit.Text = "Exit";
            // 
            // amsView
            // 
            this.amsView.Index = 1;
            this.amsView.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.amsViewEn,
            this.amsViewChs,
            this.amsViewCht,
            this.menuItem1,
            this.amsViewVista,
            this.amsViewBlack,
            this.amsViewWinXP});
            this.amsView.Tag = "amsView";
            this.amsView.Text = "View";
            // 
            // amsViewEn
            // 
            this.amsViewEn.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("amsViewEn.Icon"));
            this.amsViewEn.Index = 0;
            this.amsViewEn.Tag = "amsViewEn";
            this.amsViewEn.Text = "English";
            // 
            // amsViewChs
            // 
            this.amsViewChs.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("amsViewChs.Icon"));
            this.amsViewChs.Index = 1;
            this.amsViewChs.Tag = "amsViewChs";
            this.amsViewChs.Text = "Simplified Chinese";
            // 
            // amsViewCht
            // 
            this.amsViewCht.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("amsViewCht.Icon"));
            this.amsViewCht.Index = 2;
            this.amsViewCht.Tag = "amsViewCht";
            this.amsViewCht.Text = "Traditional Chinese";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // amsViewVista
            // 
            this.amsViewVista.Index = 4;
            this.amsViewVista.Tag = "amsViewVista";
            this.amsViewVista.Text = "Vista Theme";
            // 
            // amsViewBlack
            // 
            this.amsViewBlack.Index = 5;
            this.amsViewBlack.Tag = "amsViewBlack";
            this.amsViewBlack.Text = "Black Theme";
            // 
            // amsViewWinXP
            // 
            this.amsViewWinXP.Index = 6;
            this.amsViewWinXP.Tag = "amsViewWinXP";
            this.amsViewWinXP.Text = "WinXP Theme";
            // 
            // amsHelp
            // 
            this.amsHelp.Index = 2;
            this.amsHelp.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.amsHelpAbout});
            this.amsHelp.Tag = "amsHelp";
            this.amsHelp.Text = "Help";
            // 
            // amsHelpAbout
            // 
            this.amsHelpAbout.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("amsHelpAbout.Icon"));
            this.amsHelpAbout.Index = 0;
            this.amsHelpAbout.Tag = "amsHelpAbout";
            this.amsHelpAbout.Text = "About";
            // 
            // atsPane
            // 
            this.atsPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsPane.Location = new System.Drawing.Point(0, 0);
            this.atsPane.Name = "atsPane";
            this.atsPane.Size = new System.Drawing.Size(520, 28);
            this.atsPane.TabIndex = 0;
            // 
            // navPane
            // 
            this.navPane.Controls.Add(this.navTabs);
            this.navPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.navPane.Location = new System.Drawing.Point(0, 28);
            this.navPane.Name = "navPane";
            this.navPane.Size = new System.Drawing.Size(150, 341);
            this.navPane.TabIndex = 1;
            // 
            // navTabs
            // 
            this.navTabs.Controls.Add(this.tabInvt);
            this.navTabs.Controls.Add(this.tabPurchasing);
            this.navTabs.Controls.Add(this.tabMemberMgmt);
            this.navTabs.Controls.Add(this.tabSettings);
            this.navTabs.Location = new System.Drawing.Point(19, 72);
            this.navTabs.Name = "navTabs";
            this.navTabs.SelectedIndex = 0;
            this.navTabs.Size = new System.Drawing.Size(112, 185);
            this.navTabs.TabIndex = 0;
            this.navTabs.SelectedIndexChanged += new System.EventHandler(this.navTabs_SelectedIndexChanged);
            // 
            // tabInvt
            // 
            this.tabInvt.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabInvt.Extra = true;
            this.tabInvt.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabInvt.Image"));
            this.tabInvt.Location = new System.Drawing.Point(4, 22);
            this.tabInvt.Name = "tabInvt";
            this.tabInvt.Size = new System.Drawing.Size(104, 156);
            this.tabInvt.TabIndex = 0;
            this.tabInvt.Tag = "Inventory";
            this.tabInvt.Text = "Inventory";
            // 
            // tabPurchasing
            // 
            this.tabPurchasing.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPurchasing.Extra = true;
            this.tabPurchasing.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabPurchasing.Image"));
            this.tabPurchasing.Location = new System.Drawing.Point(4, 22);
            this.tabPurchasing.Name = "tabPurchasing";
            this.tabPurchasing.Size = new System.Drawing.Size(142, 316);
            this.tabPurchasing.TabIndex = 1;
            this.tabPurchasing.Tag = "Purchasing";
            this.tabPurchasing.Text = "Purchasing";
            // 
            // tabMemberMgmt
            // 
            this.tabMemberMgmt.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabMemberMgmt.Extra = true;
            this.tabMemberMgmt.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabMemberMgmt.Image"));
            this.tabMemberMgmt.Location = new System.Drawing.Point(4, 22);
            this.tabMemberMgmt.Name = "tabMemberMgmt";
            this.tabMemberMgmt.Size = new System.Drawing.Size(142, 316);
            this.tabMemberMgmt.TabIndex = 2;
            this.tabMemberMgmt.Tag = "Member Mgmt";
            this.tabMemberMgmt.Text = "Member Mgmt";
            // 
            // tabSettings
            // 
            this.tabSettings.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabSettings.Extra = true;
            this.tabSettings.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabSettings.Image"));
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(104, 156);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Tag = "Settings";
            this.tabSettings.Text = "Settings";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(150, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 341);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // wspPane
            // 
            this.wspPane.Controls.Add(this.picBgImage);
            this.wspPane.CustomStyle = "HeaderedPanel";
            this.wspPane.Location = new System.Drawing.Point(64, 116);
            this.wspPane.Name = "wspPane";
            this.wspPane.Size = new System.Drawing.Size(226, 160);
            this.wspPane.TabIndex = 3;
            this.wspPane.Text = "Text";
            // 
            // picBgImage
            // 
            this.picBgImage.Location = new System.Drawing.Point(54, 53);
            this.picBgImage.Name = "picBgImage";
            this.picBgImage.Size = new System.Drawing.Size(100, 50);
            this.picBgImage.TabIndex = 0;
            this.picBgImage.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.wspPane);
            this.pnlRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(151, 28);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(369, 341);
            this.pnlRight.TabIndex = 4;
            // 
            // clientStorage1
            // 
            this.clientStorage1.Description = "";
            this.clientStorage1.MajorVersion = ((ushort)(1));
            this.clientStorage1.MinorVersion = ((ushort)(0));
            // 
            // Desktop
            // 
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.navPane);
            this.Controls.Add(this.atsPane);
            this.Menu = this.amsMain;
            this.Size = new System.Drawing.Size(520, 370);
            this.Text = "RT2020";
            this.navPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navTabs)).EndInit();
            this.navTabs.ResumeLayout(false);
            this.wspPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBgImage)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MainMenu amsMain;
        private Gizmox.WebGUI.Forms.MenuItem amsFile;
        private Gizmox.WebGUI.Forms.MenuItem amsFileExit;
        private Gizmox.WebGUI.Forms.MenuItem amsView;
        private Gizmox.WebGUI.Forms.MenuItem amsViewEn;
        private Gizmox.WebGUI.Forms.MenuItem amsViewChs;
        private Gizmox.WebGUI.Forms.MenuItem amsViewCht;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem amsViewVista;
        private Gizmox.WebGUI.Forms.MenuItem amsViewBlack;
        private Gizmox.WebGUI.Forms.MenuItem amsViewWinXP;
        private Gizmox.WebGUI.Forms.MenuItem amsHelp;
        private Gizmox.WebGUI.Forms.MenuItem amsHelpAbout;
        private Gizmox.WebGUI.Forms.Panel atsPane;
        private Gizmox.WebGUI.Forms.Panel navPane;
        private Gizmox.WebGUI.Forms.Splitter splitter1;
        private Gizmox.WebGUI.Forms.HeaderedPanel wspPane;
        private Gizmox.WebGUI.Forms.NavigationTabs navTabs;
        private Gizmox.WebGUI.Forms.NavigationTab tabMemberMgmt;
        private Gizmox.WebGUI.Forms.NavigationTab tabPurchasing;
        private Gizmox.WebGUI.Forms.NavigationTab tabInvt;
        private Gizmox.WebGUI.Forms.NavigationTab tabSettings;
        private Gizmox.WebGUI.Forms.PictureBox picBgImage;
        private Gizmox.WebGUI.Forms.Panel pnlRight;
        private Gizmox.WebGUI.Forms.Client.ClientStorage clientStorage1;
    }
}