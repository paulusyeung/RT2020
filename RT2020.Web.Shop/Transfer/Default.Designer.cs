namespace RT2020.Web.Shop.Transfer
{
    partial class Default
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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.tvLeftPaneMenu = new Gizmox.WebGUI.Forms.TreeView();
            this.contentPane = new Gizmox.WebGUI.Forms.Panel();
            this.headerPane = new RT2020.Web.Shop.Public.HeaderPane();
            this.treePane = new Gizmox.WebGUI.Forms.Panel();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 111);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treePane);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.contentPane);
            this.splitContainer.Size = new System.Drawing.Size(950, 576);
            this.splitContainer.SplitterDistance = 210;
            this.splitContainer.TabIndex = 1;
            // 
            // tvLeftPaneMenu
            // 
            this.tvLeftPaneMenu.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tvLeftPaneMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tvLeftPaneMenu.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tvLeftPaneMenu.Location = new System.Drawing.Point(6, 6);
            this.tvLeftPaneMenu.Name = "tvLeftPaneMenu";
            this.tvLeftPaneMenu.Size = new System.Drawing.Size(204, 564);
            this.tvLeftPaneMenu.TabIndex = 0;
            this.tvLeftPaneMenu.NodeMouseClick += new Gizmox.WebGUI.Forms.TreeNodeMouseClickEventHandler(this.tvLeftPaneMenu_NodeMouseClick);
            // 
            // contentPane
            // 
            this.contentPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.contentPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.contentPane.DockPadding.Bottom = 6;
            this.contentPane.DockPadding.Right = 6;
            this.contentPane.DockPadding.Top = 6;
            this.contentPane.Location = new System.Drawing.Point(0, 0);
            this.contentPane.Name = "contentPane";
            this.contentPane.Size = new System.Drawing.Size(736, 576);
            this.contentPane.TabIndex = 0;
            // 
            // headerPane
            // 
            this.headerPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.headerPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.headerPane.FormTitle = "{Form}";
            this.headerPane.Location = new System.Drawing.Point(0, 0);
            this.headerPane.Name = "headerPane";
            this.headerPane.Size = new System.Drawing.Size(950, 111);
            this.headerPane.TabIndex = 0;
            this.headerPane.Text = "HeaderPane";
            // 
            // treePane
            // 
            this.treePane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.treePane.Controls.Add(this.tvLeftPaneMenu);
            this.treePane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.treePane.DockPadding.Bottom = 6;
            this.treePane.DockPadding.Left = 6;
            this.treePane.DockPadding.Top = 6;
            this.treePane.Location = new System.Drawing.Point(0, 0);
            this.treePane.Name = "treePane";
            this.treePane.Size = new System.Drawing.Size(210, 576);
            this.treePane.TabIndex = 1;
            // 
            // Default
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.headerPane);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.SizableToolWindow;
            this.Size = new System.Drawing.Size(950, 687);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "RT2020 > Web Shop > Transfer-In Confirmation > Default";
            this.Load += new System.EventHandler(this.Default_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.TreeView tvLeftPaneMenu;
        private Gizmox.WebGUI.Forms.Panel contentPane;
        private RT2020.Web.Shop.Public.HeaderPane headerPane;
        private Gizmox.WebGUI.Forms.Panel treePane;


    }
}