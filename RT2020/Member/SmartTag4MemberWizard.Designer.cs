namespace RT2020.Member
{
    partial class SmartTag4MemberWizard
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvTagList = new Gizmox.WebGUI.Forms.ListView();
            this.colTagId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTagCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPriority = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTagName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTagNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTagNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtTagNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTagNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTagName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTagNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblTagNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTagName = new Gizmox.WebGUI.Forms.Label();
            this.txtTagCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTagCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.lnkOptions = new Gizmox.WebGUI.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvTagList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lnkOptions);
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtTagNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtTagNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtTagName);
            this.splitContainer.Panel2.Controls.Add(this.lblTagNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblTagNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblTagName);
            this.splitContainer.Panel2.Controls.Add(this.txtTagCode);
            this.splitContainer.Panel2.Controls.Add(this.lblTagCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTagId,
            this.colLN,
            this.colTagCode,
            this.colPriority,
            this.colTagName,
            this.colTagNameAlt1,
            this.colTagNameAlt2});
            this.lvTagList.DataMember = null;
            this.lvTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTagList.Location = new System.Drawing.Point(0, 0);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(499, 506);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseInternalPaging = true;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            this.lvTagList.ColumnClick += new Gizmox.WebGUI.Forms.ColumnClickEventHandler(this.lvTagList_ColumnClick);
            // 
            // colTagId
            // 
            this.colTagId.Text = "TagId";
            this.colTagId.Visible = false;
            this.colTagId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTagCode
            // 
            this.colTagCode.Text = "Tag Code";
            this.colTagCode.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.Tag = "Numeric";
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 60;
            // 
            // colTagName
            // 
            this.colTagName.Text = "Tag Name";
            this.colTagName.Width = 120;
            // 
            // colTagNameAlt1
            // 
            this.colTagNameAlt1.Text = "Tag Name Chs";
            this.colTagNameAlt1.Width = 120;
            // 
            // colTagNameAlt2
            // 
            this.colTagNameAlt2.Text = "Tag Name Cht";
            this.colTagNameAlt2.Width = 120;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(164, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(120, 20);
            this.txtPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(16, 132);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(100, 23);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "Priority:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(302, 20);
            this.tbWizardAction.TabIndex = 6;
            // 
            // txtTagNameAlt2
            // 
            this.txtTagNameAlt2.Location = new System.Drawing.Point(164, 106);
            this.txtTagNameAlt2.Name = "txtTagNameAlt2";
            this.txtTagNameAlt2.Size = new System.Drawing.Size(120, 20);
            this.txtTagNameAlt2.TabIndex = 4;
            // 
            // txtTagNameAlt1
            // 
            this.txtTagNameAlt1.Location = new System.Drawing.Point(164, 83);
            this.txtTagNameAlt1.Name = "txtTagNameAlt1";
            this.txtTagNameAlt1.Size = new System.Drawing.Size(120, 20);
            this.txtTagNameAlt1.TabIndex = 3;
            // 
            // txtTagName
            // 
            this.txtTagName.Location = new System.Drawing.Point(164, 60);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(120, 20);
            this.txtTagName.TabIndex = 2;
            // 
            // lblTagNameAlt2
            // 
            this.lblTagNameAlt2.Location = new System.Drawing.Point(29, 109);
            this.lblTagNameAlt2.Name = "lblTagNameAlt2";
            this.lblTagNameAlt2.Size = new System.Drawing.Size(127, 23);
            this.lblTagNameAlt2.TabIndex = 4;
            this.lblTagNameAlt2.Text = "Tag Name Cht";
            // 
            // lblTagNameAlt1
            // 
            this.lblTagNameAlt1.Location = new System.Drawing.Point(29, 86);
            this.lblTagNameAlt1.Name = "lblTagNameAlt1";
            this.lblTagNameAlt1.Size = new System.Drawing.Size(127, 23);
            this.lblTagNameAlt1.TabIndex = 3;
            this.lblTagNameAlt1.Text = "Tag Name Chs:";
            // 
            // lblTagName
            // 
            this.lblTagName.Location = new System.Drawing.Point(16, 63);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(100, 23);
            this.lblTagName.TabIndex = 2;
            this.lblTagName.Text = "Tag Name:";
            // 
            // txtTagCode
            // 
            this.txtTagCode.Location = new System.Drawing.Point(164, 37);
            this.txtTagCode.MaxLength = 10;
            this.txtTagCode.Name = "txtTagCode";
            this.txtTagCode.Size = new System.Drawing.Size(120, 20);
            this.txtTagCode.TabIndex = 1;
            // 
            // lblTagCode
            // 
            this.lblTagCode.Location = new System.Drawing.Point(16, 40);
            this.lblTagCode.Name = "lblTagCode";
            this.lblTagCode.Size = new System.Drawing.Size(100, 23);
            this.lblTagCode.TabIndex = 0;
            this.lblTagCode.Text = "Tag Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // lnkOptions
            // 
            this.lnkOptions.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lnkOptions.LinkColor = System.Drawing.Color.Blue;
            this.lnkOptions.Location = new System.Drawing.Point(112, 176);
            this.lnkOptions.Name = "lnkOptions";
            this.lnkOptions.Size = new System.Drawing.Size(100, 23);
            this.lnkOptions.TabIndex = 5;
            this.lnkOptions.TabStop = true;
            this.lnkOptions.Text = "Options";
            this.lnkOptions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkOptions.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkOptions_LinkClicked);
            // 
            // SmartTag4MemberWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Member Wizard";
            this.Load += new System.EventHandler(this.SmartTag4MemberWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTagNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTagNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtTagName;
        private Gizmox.WebGUI.Forms.Label lblTagNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblTagNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblTagName;
        private Gizmox.WebGUI.Forms.TextBox txtTagCode;
        private Gizmox.WebGUI.Forms.Label lblTagCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.ColumnHeader colPriority;
        private Gizmox.WebGUI.Forms.LinkLabel lnkOptions;
    }
}