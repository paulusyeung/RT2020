namespace RT2020.Client
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Goods Receive");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Purchase Orders");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("P.O. Receiving");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Product");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslCurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.atsMain = new System.Windows.Forms.ToolStrip();
            this.atsNew = new System.Windows.Forms.ToolStripSplitButton();
            this.atsNewCAP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.atsNewPOM = new System.Windows.Forms.ToolStripMenuItem();
            this.atsNewPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.atsNewPOR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.atsProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.atsProductFast = new System.Windows.Forms.ToolStripMenuItem();
            this.atsProductBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.atsProductMU = new System.Windows.Forms.ToolStripMenuItem();
            this.amsMain = new System.Windows.Forms.MenuStrip();
            this.amsRT2020Client = new System.Windows.Forms.ToolStripMenuItem();
            this.amsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.amsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.amsHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nBar = new Itchin.Winforms.Controls_F2.NavigationBar();
            this.bpInventory = new Itchin.Winforms.Controls_F2.NavigationBarPane();
            this.tvwInventory = new System.Windows.Forms.TreeView();
            this.bpPurchasing = new Itchin.Winforms.Controls_F2.NavigationBarPane();
            this.tvwPurchasing = new System.Windows.Forms.TreeView();
            this.bpProduct = new Itchin.Winforms.Controls_F2.NavigationBarPane();
            this.tvwProduct = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bcmBreadcrumb = new Itchin.Winforms.Controls_F2.NavBarHeaderPanel();
            this.statusStrip1.SuspendLayout();
            this.atsMain.SuspendLayout();
            this.amsMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.nBar.SuspendLayout();
            this.bpInventory.SuspendLayout();
            this.bpPurchasing.SuspendLayout();
            this.bpProduct.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslUserName,
            this.sslCurrentDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslUserName
            // 
            this.sslUserName.Name = "sslUserName";
            this.sslUserName.Size = new System.Drawing.Size(71, 17);
            this.sslUserName.Text = "User Name: ";
            // 
            // sslCurrentDate
            // 
            this.sslCurrentDate.Name = "sslCurrentDate";
            this.sslCurrentDate.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.sslCurrentDate.Size = new System.Drawing.Size(140, 17);
            this.sslCurrentDate.Text = "Current Date: ";
            // 
            // atsMain
            // 
            this.atsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atsNew});
            this.atsMain.Location = new System.Drawing.Point(0, 24);
            this.atsMain.Name = "atsMain";
            this.atsMain.Size = new System.Drawing.Size(1016, 25);
            this.atsMain.TabIndex = 12;
            this.atsMain.Text = "toolStrip1";
            // 
            // atsNew
            // 
            this.atsNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atsNewCAP,
            this.toolStripSeparator1,
            this.atsNewPOM,
            this.atsNewPOS,
            this.atsNewPOR,
            this.toolStripSeparator2,
            this.atsProduct,
            this.atsProductFast,
            this.atsProductBatch,
            this.atsProductMU});
            this.atsNew.Image = ((System.Drawing.Image)(resources.GetObject("atsNew.Image")));
            this.atsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.atsNew.Name = "atsNew";
            this.atsNew.Size = new System.Drawing.Size(63, 22);
            this.atsNew.Text = "New";
            this.atsNew.ToolTipText = "New";
            // 
            // atsNewCAP
            // 
            this.atsNewCAP.Name = "atsNewCAP";
            this.atsNewCAP.Size = new System.Drawing.Size(226, 22);
            this.atsNewCAP.Text = "Goods Receive";
            this.atsNewCAP.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // atsNewPOM
            // 
            this.atsNewPOM.Name = "atsNewPOM";
            this.atsNewPOM.Size = new System.Drawing.Size(226, 22);
            this.atsNewPOM.Text = "P.O. (Multi-Locations)";
            this.atsNewPOM.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // atsNewPOS
            // 
            this.atsNewPOS.Name = "atsNewPOS";
            this.atsNewPOS.Size = new System.Drawing.Size(226, 22);
            this.atsNewPOS.Text = "Purchase Order";
            this.atsNewPOS.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // atsNewPOR
            // 
            this.atsNewPOR.Name = "atsNewPOR";
            this.atsNewPOR.Size = new System.Drawing.Size(226, 22);
            this.atsNewPOR.Text = "P.O. Receiving";
            this.atsNewPOR.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // atsProduct
            // 
            this.atsProduct.Name = "atsProduct";
            this.atsProduct.Size = new System.Drawing.Size(226, 22);
            this.atsProduct.Text = "Product Code";
            this.atsProduct.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // atsProductFast
            // 
            this.atsProductFast.Name = "atsProductFast";
            this.atsProductFast.Size = new System.Drawing.Size(226, 22);
            this.atsProductFast.Text = "Product Code [Fast]";
            this.atsProductFast.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // atsProductBatch
            // 
            this.atsProductBatch.Name = "atsProductBatch";
            this.atsProductBatch.Size = new System.Drawing.Size(226, 22);
            this.atsProductBatch.Text = "Product Code [Batch]";
            this.atsProductBatch.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // atsProductMU
            // 
            this.atsProductMU.Name = "atsProductMU";
            this.atsProductMU.Size = new System.Drawing.Size(226, 22);
            this.atsProductMU.Text = "Product Code [Mass Update]";
            this.atsProductMU.Click += new System.EventHandler(this.atsMain_ItemClicked);
            // 
            // amsMain
            // 
            this.amsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amsRT2020Client,
            this.amsHelp});
            this.amsMain.Location = new System.Drawing.Point(0, 0);
            this.amsMain.Name = "amsMain";
            this.amsMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.amsMain.Size = new System.Drawing.Size(1016, 24);
            this.amsMain.TabIndex = 11;
            this.amsMain.Text = "menuStrip1";
            // 
            // amsRT2020Client
            // 
            this.amsRT2020Client.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amsExit});
            this.amsRT2020Client.Name = "amsRT2020Client";
            this.amsRT2020Client.Size = new System.Drawing.Size(91, 20);
            this.amsRT2020Client.Text = "&RT2020.Client";
            // 
            // amsExit
            // 
            this.amsExit.Name = "amsExit";
            this.amsExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.amsExit.Size = new System.Drawing.Size(152, 22);
            this.amsExit.Text = "E&xit";
            this.amsExit.Click += new System.EventHandler(this.amsExit_Click);
            // 
            // amsHelp
            // 
            this.amsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amsHelpAbout});
            this.amsHelp.Name = "amsHelp";
            this.amsHelp.Size = new System.Drawing.Size(44, 20);
            this.amsHelp.Text = "&Help";
            // 
            // amsHelpAbout
            // 
            this.amsHelpAbout.Name = "amsHelpAbout";
            this.amsHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.amsHelpAbout.Text = "&About";
            this.amsHelpAbout.Click += new System.EventHandler(this.amsHelpAbout_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(170, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 663);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 663);
            this.panel2.TabIndex = 13;
            // 
            // nBar
            // 
            this.nBar.AlphaSettings.HoverItemAlpha = 70;
            this.nBar.AlphaSettings.SelectedItemAlpha = 100;
            this.nBar.AlphaSettings.UnselectedItemAlpha = 70;
            this.nBar.AlphaSettings.UseAlphaSettings = false;
            this.nBar.Controls.Add(this.bpInventory);
            this.nBar.Controls.Add(this.bpPurchasing);
            this.nBar.Controls.Add(this.bpProduct);
            this.nBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.nBar.DesignTimeEdit = true;
            this.nBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nBar.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.nBar.HeaderForeColor = System.Drawing.Color.White;
            this.nBar.HeaderTextalignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.nBar.Location = new System.Drawing.Point(0, 0);
            this.nBar.Logo.Alpha = 50;
            this.nBar.Logo.DisplayLogo = true;
            this.nBar.Logo.Image = null;
            this.nBar.LogoImagePosition = System.Drawing.ContentAlignment.BottomRight;
            this.nBar.Name = "nBar";
            this.nBar.Panels.Add(this.bpInventory);
            this.nBar.Panels.Add(this.bpPurchasing);
            this.nBar.Panels.Add(this.bpProduct);
            this.nBar.SelectedForecolor = System.Drawing.Color.Red;
            this.nBar.SelectedItem = this.bpInventory;
            this.nBar.ShowAddRemoveMenu = true;
            this.nBar.ShowMenuButton = true;
            this.nBar.Size = new System.Drawing.Size(170, 663);
            this.nBar.TabIndex = 1;
            this.nBar.Text = "navigationBar1";
            this.nBar.ThemeFormat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.nBar.ThemeFormat.HeaderColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(128)))), ((int)(((byte)(208)))));
            this.nBar.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(57)))), ((int)(((byte)(138)))));
            this.nBar.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(216)))), ((int)(((byte)(126)))));
            this.nBar.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(160)))), ((int)(((byte)(38)))));
            this.nBar.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(221)))), ((int)(((byte)(250)))));
            this.nBar.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(167)))), ((int)(((byte)(225)))));
            this.nBar.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(160)))), ((int)(((byte)(38)))));
            this.nBar.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(216)))), ((int)(((byte)(126)))));
            this.nBar.ThemeFormat.SplitterBarColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(128)))), ((int)(((byte)(208)))));
            this.nBar.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(57)))), ((int)(((byte)(138)))));
            this.nBar.ToolTipTimeOut = 5000;
            this.nBar.VisibleItems = 3;
            // 
            // bpInventory
            // 
            this.bpInventory.Caption = "Inventory";
            this.bpInventory.Controls.Add(this.tvwInventory);
            this.bpInventory.Hidden = false;
            this.bpInventory.Location = new System.Drawing.Point(1, 26);
            this.bpInventory.MainImagePosition = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpInventory.Name = "bpInventory";
            this.bpInventory.Selected = true;
            this.bpInventory.Size = new System.Drawing.Size(168, 505);
            this.bpInventory.TabIndex = 0;
            this.bpInventory.TabStop = true;
            this.bpInventory.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpInventory.TextPaddingOffset = new System.Drawing.Point(30, 0);
            // 
            // tvwInventory
            // 
            this.tvwInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwInventory.Location = new System.Drawing.Point(0, 0);
            this.tvwInventory.Name = "tvwInventory";
            treeNode1.Name = "nodCAP";
            treeNode1.Text = "Goods Receive";
            this.tvwInventory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvwInventory.Size = new System.Drawing.Size(168, 505);
            this.tvwInventory.TabIndex = 0;
            this.tvwInventory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwInventory_NodeMouseClick);
            // 
            // bpPurchasing
            // 
            this.bpPurchasing.Caption = "Purchasing";
            this.bpPurchasing.Controls.Add(this.tvwPurchasing);
            this.bpPurchasing.Hidden = false;
            this.bpPurchasing.Location = new System.Drawing.Point(1, 26);
            this.bpPurchasing.MainImagePosition = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpPurchasing.Name = "bpPurchasing";
            this.bpPurchasing.Selected = true;
            this.bpPurchasing.Size = new System.Drawing.Size(168, 505);
            this.bpPurchasing.TabIndex = 1;
            this.bpPurchasing.TabStop = true;
            this.bpPurchasing.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpPurchasing.TextPaddingOffset = new System.Drawing.Point(30, 0);
            // 
            // tvwPurchasing
            // 
            this.tvwPurchasing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwPurchasing.Location = new System.Drawing.Point(0, 0);
            this.tvwPurchasing.Name = "tvwPurchasing";
            treeNode2.Name = "nodPOS";
            treeNode2.Text = "Purchase Orders";
            treeNode3.Name = "nodPOR";
            treeNode3.Text = "P.O. Receiving";
            this.tvwPurchasing.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.tvwPurchasing.Size = new System.Drawing.Size(168, 505);
            this.tvwPurchasing.TabIndex = 0;
            this.tvwPurchasing.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwPurchasing_NodeMouseClick);
            // 
            // bpProduct
            // 
            this.bpProduct.Caption = "Product";
            this.bpProduct.Controls.Add(this.tvwProduct);
            this.bpProduct.Hidden = false;
            this.bpProduct.Location = new System.Drawing.Point(1, 26);
            this.bpProduct.MainImagePosition = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpProduct.Name = "bpProduct";
            this.bpProduct.Selected = false;
            this.bpProduct.Size = new System.Drawing.Size(168, 505);
            this.bpProduct.TabIndex = 2;
            this.bpProduct.TabStop = true;
            this.bpProduct.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bpProduct.TextPaddingOffset = new System.Drawing.Point(30, 0);
            // 
            // tvwProduct
            // 
            this.tvwProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwProduct.Location = new System.Drawing.Point(0, 0);
            this.tvwProduct.Name = "tvwProduct";
            treeNode4.Name = "nodProduct";
            treeNode4.Text = "Product";
            this.tvwProduct.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvwProduct.Size = new System.Drawing.Size(168, 505);
            this.tvwProduct.TabIndex = 0;
            this.tvwProduct.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwProduct_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bcmBreadcrumb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(173, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 29);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // bcmBreadcrumb
            // 
            this.bcmBreadcrumb.BackColor = System.Drawing.SystemColors.Control;
            this.bcmBreadcrumb.Caption = "Breadcrumb";
            this.bcmBreadcrumb.DisplayFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcmBreadcrumb.DisplayForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(96)))), ((int)(((byte)(148)))));
            this.bcmBreadcrumb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bcmBreadcrumb.DrawRightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcmBreadcrumb.DrawStyle = Itchin.Winforms.Controls_F2.EHeaderDrawStyle.Normal;
            this.bcmBreadcrumb.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcmBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(96)))), ((int)(((byte)(148)))));
            this.bcmBreadcrumb.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bcmBreadcrumb.ImageAlpha = 100;
            this.bcmBreadcrumb.Location = new System.Drawing.Point(0, 0);
            this.bcmBreadcrumb.Name = "bcmBreadcrumb";
            this.bcmBreadcrumb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bcmBreadcrumb.Size = new System.Drawing.Size(843, 29);
            this.bcmBreadcrumb.TabIndex = 0;
            this.bcmBreadcrumb.Text = "navBarHeaderPanel1";
            this.bcmBreadcrumb.ThemeFormat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.bcmBreadcrumb.ThemeFormat.BorderColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.bcmBreadcrumb.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.bcmBreadcrumb.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(193)))), ((int)(((byte)(245)))));
            this.bcmBreadcrumb.UseAplha = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.atsMain);
            this.Controls.Add(this.amsMain);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RT2020.Client.Properties.Settings.Default, "GlobalFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::RT2020.Client.Properties.Settings.Default.GlobalFont;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.amsMain;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RT2020.Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.atsMain.ResumeLayout(false);
            this.atsMain.PerformLayout();
            this.amsMain.ResumeLayout(false);
            this.amsMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.nBar.ResumeLayout(false);
            this.bpInventory.ResumeLayout(false);
            this.bpPurchasing.ResumeLayout(false);
            this.bpProduct.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip atsMain;
		private System.Windows.Forms.MenuStrip amsMain;
        private System.Windows.Forms.ToolStripMenuItem amsRT2020Client;
		private System.Windows.Forms.ToolStripMenuItem amsHelp;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private Itchin.Winforms.Controls_F2.NavigationBar nBar;
		private Itchin.Winforms.Controls_F2.NavigationBarPane bpInventory;
        private System.Windows.Forms.TreeView tvwInventory;
		private System.Windows.Forms.Panel panel1;
		private Itchin.Winforms.Controls_F2.NavBarHeaderPanel bcmBreadcrumb;
		private System.Windows.Forms.ToolStripStatusLabel sslUserName;
        private System.Windows.Forms.ToolStripStatusLabel sslCurrentDate;
        private System.Windows.Forms.ToolStripSplitButton atsNew;
        private System.Windows.Forms.ToolStripMenuItem amsExit;
        private System.Windows.Forms.ToolStripMenuItem amsHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem atsNewCAP;
        private Itchin.Winforms.Controls_F2.NavigationBarPane bpPurchasing;
        private Itchin.Winforms.Controls_F2.NavigationBarPane bpProduct;
        private System.Windows.Forms.TreeView tvwPurchasing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem atsNewPOM;
        private System.Windows.Forms.ToolStripMenuItem atsNewPOS;
        private System.Windows.Forms.ToolStripMenuItem atsNewPOR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TreeView tvwProduct;
        private System.Windows.Forms.ToolStripMenuItem atsProduct;
        private System.Windows.Forms.ToolStripMenuItem atsProductFast;
        private System.Windows.Forms.ToolStripMenuItem atsProductBatch;
        private System.Windows.Forms.ToolStripMenuItem atsProductMU;
    }
}

