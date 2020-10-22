namespace RT2020.Member
{
    partial class MemberGroupWizard
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
            this.lvMemberGroupList = new Gizmox.WebGUI.Forms.ListView();
            this.colMemberGroupId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberGroupCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberGroupName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberGroupNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberGroupNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentGroup = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentGroup = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtMemberGroupNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMemberGroupNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMemberGroupName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMemberGroupNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblMemberGroupNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblMemberGroupName = new Gizmox.WebGUI.Forms.Label();
            this.txtMemberGroupCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMemberGroupCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvMemberGroupList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentGroup);
            this.splitContainer.Panel2.Controls.Add(this.lblParentGroup);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberGroupNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberGroupNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberGroupName);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberGroupNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberGroupNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberGroupName);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberGroupCode);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberGroupCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvMemberGroupList
            // 
            this.lvMemberGroupList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvMemberGroupList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMemberGroupId,
            this.colLN,
            this.colMemberGroupCode,
            this.colMemberGroupName,
            this.colMemberGroupNameChs,
            this.colMemberGroupNameCht});
            this.lvMemberGroupList.DataMember = null;
            this.lvMemberGroupList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvMemberGroupList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvMemberGroupList.ItemsPerPage = 20;
            this.lvMemberGroupList.Location = new System.Drawing.Point(0, 0);
            this.lvMemberGroupList.Name = "lvMemberGroupList";
            this.lvMemberGroupList.Size = new System.Drawing.Size(499, 506);
            this.lvMemberGroupList.TabIndex = 0;
            this.lvMemberGroupList.UseInternalPaging = true;
            this.lvMemberGroupList.SelectedIndexChanged += new System.EventHandler(this.lvMemberGroupList_SelectedIndexChanged);
            // 
            // colMemberGroupId
            // 
            this.colMemberGroupId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberGroupId.Image = null;
            this.colMemberGroupId.Text = "MemberGroupId";
            this.colMemberGroupId.Visible = false;
            this.colMemberGroupId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colMemberGroupCode
            // 
            this.colMemberGroupCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberGroupCode.Image = null;
            this.colMemberGroupCode.Text = "Group Code";
            this.colMemberGroupCode.Width = 80;
            // 
            // colMemberGroupName
            // 
            this.colMemberGroupName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberGroupName.Image = null;
            this.colMemberGroupName.Text = "Group Name";
            this.colMemberGroupName.Width = 120;
            // 
            // colMemberGroupNameChs
            // 
            this.colMemberGroupNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberGroupNameChs.Image = null;
            this.colMemberGroupNameChs.Text = "Group Name Chs";
            this.colMemberGroupNameChs.Width = 120;
            // 
            // colMemberGroupNameCht
            // 
            this.colMemberGroupNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberGroupNameCht.Image = null;
            this.colMemberGroupNameCht.Text = "Group Name Cht";
            this.colMemberGroupNameCht.Width = 120;
            // 
            // cboParentGroup
            // 
            this.cboParentGroup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentGroup.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentGroup.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentGroup.DropDownWidth = 142;
            this.cboParentGroup.Location = new System.Drawing.Point(122, 129);
            this.cboParentGroup.Name = "cboParentGroup";
            this.cboParentGroup.Size = new System.Drawing.Size(142, 21);
            this.cboParentGroup.TabIndex = 5;
            // 
            // lblParentGroup
            // 
            this.lblParentGroup.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentGroup.Location = new System.Drawing.Point(16, 132);
            this.lblParentGroup.Name = "lblParentGroup";
            this.lblParentGroup.Size = new System.Drawing.Size(100, 23);
            this.lblParentGroup.TabIndex = 9;
            this.lblParentGroup.Text = "Attached To:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtMemberGroupNameCht
            // 
            this.txtMemberGroupNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberGroupNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtMemberGroupNameCht.Name = "txtMemberGroupNameCht";
            this.txtMemberGroupNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtMemberGroupNameCht.TabIndex = 4;
            // 
            // txtMemberGroupNameChs
            // 
            this.txtMemberGroupNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberGroupNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtMemberGroupNameChs.Name = "txtMemberGroupNameChs";
            this.txtMemberGroupNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtMemberGroupNameChs.TabIndex = 3;
            // 
            // txtMemberGroupName
            // 
            this.txtMemberGroupName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberGroupName.Location = new System.Drawing.Point(122, 60);
            this.txtMemberGroupName.Name = "txtMemberGroupName";
            this.txtMemberGroupName.Size = new System.Drawing.Size(142, 20);
            this.txtMemberGroupName.TabIndex = 2;
            // 
            // lblMemberGroupNameCht
            // 
            this.lblMemberGroupNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberGroupNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblMemberGroupNameCht.Name = "lblMemberGroupNameCht";
            this.lblMemberGroupNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblMemberGroupNameCht.TabIndex = 4;
            this.lblMemberGroupNameCht.Text = "Group Name Cht";
            // 
            // lblMemberGroupNameChs
            // 
            this.lblMemberGroupNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberGroupNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblMemberGroupNameChs.Name = "lblMemberGroupNameChs";
            this.lblMemberGroupNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblMemberGroupNameChs.TabIndex = 3;
            this.lblMemberGroupNameChs.Text = "Group Name Chs:";
            // 
            // lblMemberGroupName
            // 
            this.lblMemberGroupName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberGroupName.Location = new System.Drawing.Point(16, 63);
            this.lblMemberGroupName.Name = "lblMemberGroupName";
            this.lblMemberGroupName.Size = new System.Drawing.Size(100, 23);
            this.lblMemberGroupName.TabIndex = 2;
            this.lblMemberGroupName.Text = "Group Name:";
            // 
            // txtMemberGroupCode
            // 
            this.txtMemberGroupCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberGroupCode.Location = new System.Drawing.Point(122, 37);
            this.txtMemberGroupCode.MaxLength = 10;
            this.txtMemberGroupCode.Name = "txtMemberGroupCode";
            this.txtMemberGroupCode.Size = new System.Drawing.Size(142, 20);
            this.txtMemberGroupCode.TabIndex = 1;
            // 
            // lblMemberGroupCode
            // 
            this.lblMemberGroupCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberGroupCode.Location = new System.Drawing.Point(16, 40);
            this.lblMemberGroupCode.Name = "lblMemberGroupCode";
            this.lblMemberGroupCode.Size = new System.Drawing.Size(100, 23);
            this.lblMemberGroupCode.TabIndex = 0;
            this.lblMemberGroupCode.Text = "Group Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // MemberGroupWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberGroup Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvMemberGroupList;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberGroupId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberGroupCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberGroupName;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberGroupNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberGroupNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMemberGroupNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMemberGroupNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtMemberGroupName;
        private Gizmox.WebGUI.Forms.Label lblMemberGroupNameCht;
        private Gizmox.WebGUI.Forms.Label lblMemberGroupNameChs;
        private Gizmox.WebGUI.Forms.Label lblMemberGroupName;
        private Gizmox.WebGUI.Forms.TextBox txtMemberGroupCode;
        private Gizmox.WebGUI.Forms.Label lblMemberGroupCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentGroup;
        private Gizmox.WebGUI.Forms.Label lblParentGroup;


    }
}