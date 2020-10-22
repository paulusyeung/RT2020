namespace RT2020.Controls
{
    partial class DefaultListBase
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
            this.lvList = new Gizmox.WebGUI.Forms.ListView();
            this.tbControl = new Gizmox.WebGUI.Forms.ToolBar();
            this.cboView = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtLookup = new Gizmox.WebGUI.Forms.TextBox();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.ansCare = new Gizmox.WebGUI.Forms.ToolBar();
            this.lksPane = new Gizmox.WebGUI.Forms.Panel();
            this.lblView = new Gizmox.WebGUI.Forms.Label();
            this.cboStaffList = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCreatedBy = new Gizmox.WebGUI.Forms.Label();
            this.cmdLookup = new Gizmox.WebGUI.Forms.Button();
            this.lblLookup = new Gizmox.WebGUI.Forms.Label();
            this.alphaBinding = new RT2020.Controls.AlphaBinding();
            this.SuspendLayout();
            // 
            // lvList
            // 
            this.lvList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvList.DataMember = null;
            this.lvList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvList.GridLines = true;
            this.lvList.ItemsPerPage = 50;
            this.lvList.Location = new System.Drawing.Point(0, 0);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(1031, 290);
            this.lvList.TabIndex = 0;
            this.lvList.UseInternalPaging = true;
            this.lvList.DoubleClick += new System.EventHandler(this.lvSalesList_DoubleClick);
            // 
            // tbControl
            // 
            this.tbControl.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbControl.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbControl.DragHandle = true;
            this.tbControl.DropDownArrows = false;
            this.tbControl.ImageList = null;
            this.tbControl.Location = new System.Drawing.Point(0, 0);
            this.tbControl.MenuHandle = true;
            this.tbControl.Name = "tbControl";
            //this.tbControl.RightToLeft = false;
            this.tbControl.ShowToolTips = true;
            this.tbControl.TabIndex = 0;
            // 
            // cboView
            // 
            this.cboView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.cboView.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboView.Location = new System.Drawing.Point(864, 7);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(121, 21);
            this.cboView.TabIndex = 6;
            this.cboView.SelectedIndexChanged += new System.EventHandler(this.cboView_SelectedIndexChanged);
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(61, 7);
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(120, 20);
            this.txtLookup.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.ansCare);
            this.splitContainer.Panel1.Controls.Add(this.lksPane);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lvList);
            this.splitContainer.Panel2.Controls.Add(this.alphaBinding);
            this.splitContainer.Size = new System.Drawing.Size(1031, 377);
            this.splitContainer.SplitterDistance = 60;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // ansCare
            // 
            this.ansCare.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.ansCare.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.ansCare.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.ansCare.DragHandle = true;
            this.ansCare.DropDownArrows = false;
            this.ansCare.ImageList = null;
            this.ansCare.Location = new System.Drawing.Point(0, 34);
            this.ansCare.MenuHandle = true;
            this.ansCare.Name = "ansCare";
            //this.ansCare.RightToLeft = false;
            this.ansCare.ShowToolTips = true;
            this.ansCare.TabIndex = 1;
            // 
            // lksPane
            // 
            this.lksPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lksPane.AutoSizeMode = Gizmox.WebGUI.Forms.AutoSizeMode.GrowAndShrink;
            this.lksPane.Controls.Add(this.lblView);
            this.lksPane.Controls.Add(this.cboView);
            this.lksPane.Controls.Add(this.cboStaffList);
            this.lksPane.Controls.Add(this.lblCreatedBy);
            this.lksPane.Controls.Add(this.cmdLookup);
            this.lksPane.Controls.Add(this.txtLookup);
            this.lksPane.Controls.Add(this.lblLookup);
            this.lksPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lksPane.Location = new System.Drawing.Point(0, 0);
            this.lksPane.Name = "lksPane";
            this.lksPane.Size = new System.Drawing.Size(1031, 34);
            this.lksPane.TabIndex = 0;
            // 
            // lblView
            // 
            this.lblView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lblView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblView.Location = new System.Drawing.Point(819, 9);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(39, 23);
            this.lblView.TabIndex = 5;
            this.lblView.Text = "View: ";
            // 
            // cboStaffList
            // 
            this.cboStaffList.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboStaffList.Location = new System.Drawing.Point(323, 6);
            this.cboStaffList.Name = "cboStaffList";
            this.cboStaffList.Size = new System.Drawing.Size(121, 21);
            this.cboStaffList.TabIndex = 6;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.Location = new System.Drawing.Point(241, 9);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(76, 23);
            this.lblCreatedBy.TabIndex = 5;
            this.lblCreatedBy.Text = "Created By: ";
            // 
            // cmdLookup
            // 
            iconResourceHandle1.File = "16x16.16_find.gif";
            this.cmdLookup.Image = iconResourceHandle1;
            this.cmdLookup.Location = new System.Drawing.Point(181, 5);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(24, 23);
            this.cmdLookup.TabIndex = 4;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // lblLookup
            // 
            this.lblLookup.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLookup.Location = new System.Drawing.Point(2, 9);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(61, 18);
            this.lblLookup.TabIndex = 0;
            this.lblLookup.Text = "Look for:";
            // 
            // alphaBinding
            // 
            this.alphaBinding.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.alphaBinding.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.alphaBinding.Location = new System.Drawing.Point(0, 290);
            this.alphaBinding.Name = "alphaBinding";
            this.alphaBinding.Size = new System.Drawing.Size(1031, 26);
            this.alphaBinding.TabIndex = 1;
            this.alphaBinding.Text = "AlphaBinding";
            this.alphaBinding.ButtonClick += new System.EventHandler(this.alphaBinding_ButtonClick);
            // 
            // DefaultListBase
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.tbControl);
            this.Size = new System.Drawing.Size(1031, 405);
            this.Text = "SalesList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtLookup;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ToolBar ansCare;
        private Gizmox.WebGUI.Forms.Panel lksPane;
        private Gizmox.WebGUI.Forms.Button cmdLookup;
        private Gizmox.WebGUI.Forms.Label lblLookup;
        public Gizmox.WebGUI.Forms.ListView lvList;
        public Gizmox.WebGUI.Forms.ToolBar tbControl;
        public AlphaBinding alphaBinding;
        public Gizmox.WebGUI.Forms.ComboBox cboView;
        public Gizmox.WebGUI.Forms.Label lblView;
        public Gizmox.WebGUI.Forms.ComboBox cboStaffList;
        public Gizmox.WebGUI.Forms.Label lblCreatedBy;


    }
}