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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvMemberGroupList = new Gizmox.WebGUI.Forms.ListView();
            this.colGroupId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colGroupCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colGroupName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colGroupNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colGroupNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentGroup = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentGroup = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtGroupNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtGroupNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtGroupName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblGroupNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblGroupNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblGroupName = new Gizmox.WebGUI.Forms.Label();
            this.txtGroupCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblGroupCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
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
            this.splitContainer.Panel1.Controls.Add(this.lvMemberGroupList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentGroup);
            this.splitContainer.Panel2.Controls.Add(this.lblParentGroup);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtGroupNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtGroupNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtGroupName);
            this.splitContainer.Panel2.Controls.Add(this.lblGroupNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblGroupNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblGroupName);
            this.splitContainer.Panel2.Controls.Add(this.txtGroupCode);
            this.splitContainer.Panel2.Controls.Add(this.lblGroupCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvMemberGroupList
            // 
            this.lvMemberGroupList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colGroupId,
            this.colLN,
            this.colGroupCode,
            this.colGroupName,
            this.colGroupNameAlt1,
            this.colGroupNameAlt2});
            this.lvMemberGroupList.DataMember = null;
            this.lvMemberGroupList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvMemberGroupList.Location = new System.Drawing.Point(0, 0);
            this.lvMemberGroupList.Name = "lvMemberGroupList";
            this.lvMemberGroupList.Size = new System.Drawing.Size(499, 506);
            this.lvMemberGroupList.TabIndex = 0;
            this.lvMemberGroupList.UseInternalPaging = true;
            this.lvMemberGroupList.SelectedIndexChanged += new System.EventHandler(this.lvMemberGroupList_SelectedIndexChanged);
            // 
            // colGroupId
            // 
            this.colGroupId.Text = "MemberGroupId";
            this.colGroupId.Visible = false;
            this.colGroupId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colGroupCode
            // 
            this.colGroupCode.Text = "Group Code";
            this.colGroupCode.Width = 80;
            // 
            // colGroupName
            // 
            this.colGroupName.Text = "Group Name";
            this.colGroupName.Width = 120;
            // 
            // colGroupNameAlt1
            // 
            this.colGroupNameAlt1.Text = "Group Name Chs";
            this.colGroupNameAlt1.Width = 120;
            // 
            // colGroupNameAlt2
            // 
            this.colGroupNameAlt2.Text = "Group Name Cht";
            this.colGroupNameAlt2.Width = 120;
            // 
            // cboParentGroup
            // 
            this.cboParentGroup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentGroup.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentGroup.DropDownWidth = 142;
            this.cboParentGroup.Location = new System.Drawing.Point(155, 129);
            this.cboParentGroup.Name = "cboParentGroup";
            this.cboParentGroup.Size = new System.Drawing.Size(132, 21);
            this.cboParentGroup.TabIndex = 5;
            // 
            // lblParentGroup
            // 
            this.lblParentGroup.Location = new System.Drawing.Point(16, 132);
            this.lblParentGroup.Name = "lblParentGroup";
            this.lblParentGroup.Size = new System.Drawing.Size(100, 23);
            this.lblParentGroup.TabIndex = 9;
            this.lblParentGroup.Text = "Attached To:";
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
            this.tbWizardAction.Size = new System.Drawing.Size(302, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtGroupNameAlt2
            // 
            this.txtGroupNameAlt2.Location = new System.Drawing.Point(155, 106);
            this.txtGroupNameAlt2.Name = "txtGroupNameAlt2";
            this.txtGroupNameAlt2.Size = new System.Drawing.Size(132, 20);
            this.txtGroupNameAlt2.TabIndex = 4;
            // 
            // txtGroupNameAlt1
            // 
            this.txtGroupNameAlt1.Location = new System.Drawing.Point(155, 83);
            this.txtGroupNameAlt1.Name = "txtGroupNameAlt1";
            this.txtGroupNameAlt1.Size = new System.Drawing.Size(132, 20);
            this.txtGroupNameAlt1.TabIndex = 3;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(155, 60);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(132, 20);
            this.txtGroupName.TabIndex = 2;
            // 
            // lblGroupNameAlt2
            // 
            this.lblGroupNameAlt2.Location = new System.Drawing.Point(26, 109);
            this.lblGroupNameAlt2.Name = "lblGroupNameAlt2";
            this.lblGroupNameAlt2.Size = new System.Drawing.Size(126, 23);
            this.lblGroupNameAlt2.TabIndex = 4;
            this.lblGroupNameAlt2.Text = "Group Name Cht";
            // 
            // lblGroupNameAlt1
            // 
            this.lblGroupNameAlt1.Location = new System.Drawing.Point(26, 86);
            this.lblGroupNameAlt1.Name = "lblGroupNameAlt1";
            this.lblGroupNameAlt1.Size = new System.Drawing.Size(126, 23);
            this.lblGroupNameAlt1.TabIndex = 3;
            this.lblGroupNameAlt1.Text = "Group Name Chs:";
            // 
            // lblGroupName
            // 
            this.lblGroupName.Location = new System.Drawing.Point(16, 63);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(100, 23);
            this.lblGroupName.TabIndex = 2;
            this.lblGroupName.Text = "Group Name:";
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(155, 37);
            this.txtGroupCode.MaxLength = 10;
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(132, 20);
            this.txtGroupCode.TabIndex = 1;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.Location = new System.Drawing.Point(16, 40);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(100, 23);
            this.lblGroupCode.TabIndex = 0;
            this.lblGroupCode.Text = "Group Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // MemberGroupWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberGroup Wizard";
            this.Load += new System.EventHandler(this.MemberGroupWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvMemberGroupList;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroupId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroupCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroupName;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroupNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colGroupNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtGroupNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtGroupNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtGroupName;
        private Gizmox.WebGUI.Forms.Label lblGroupNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblGroupNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblGroupName;
        private Gizmox.WebGUI.Forms.TextBox txtGroupCode;
        private Gizmox.WebGUI.Forms.Label lblGroupCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentGroup;
        private Gizmox.WebGUI.Forms.Label lblParentGroup;


    }
}