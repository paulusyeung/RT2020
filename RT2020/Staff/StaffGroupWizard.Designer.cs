namespace RT2020.Staff
{
    partial class StaffGroupWizard
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
            this.lvStaffGroupList = new Gizmox.WebGUI.Forms.ListView();
            this.colStaffGroupId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffGroupCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffGroupName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffGroupNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colStaffGroupNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chkCanWrite = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanRead = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboParentGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentGrade = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtStaffGroupNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffGroupNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffGroupName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffGroupNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffGroupNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffGroupName = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffGroupCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffGroupCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.chkCanDelete = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanPost = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvStaffGroupList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chkCanPost);
            this.splitContainer.Panel2.Controls.Add(this.chkCanDelete);
            this.splitContainer.Panel2.Controls.Add(this.chkCanWrite);
            this.splitContainer.Panel2.Controls.Add(this.chkCanRead);
            this.splitContainer.Panel2.Controls.Add(this.cboParentGrade);
            this.splitContainer.Panel2.Controls.Add(this.lblParentGrade);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupName);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupName);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupCode);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvStaffGroupList
            // 
            this.lvStaffGroupList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvStaffGroupList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colStaffGroupId,
            this.colLN,
            this.colStaffGroupCode,
            this.colStaffGroupName,
            this.colStaffGroupNameChs,
            this.colStaffGroupNameCht});
            this.lvStaffGroupList.DataMember = null;
            this.lvStaffGroupList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvStaffGroupList.ItemsPerPage = 20;
            this.lvStaffGroupList.Location = new System.Drawing.Point(0, 0);
            this.lvStaffGroupList.Name = "lvStaffGroupList";
            this.lvStaffGroupList.Size = new System.Drawing.Size(499, 506);
            this.lvStaffGroupList.TabIndex = 0;
            this.lvStaffGroupList.UseInternalPaging = true;
            this.lvStaffGroupList.SelectedIndexChanged += new System.EventHandler(this.lvStaffGroupList_SelectedIndexChanged);
            // 
            // colStaffGroupId
            // 
            this.colStaffGroupId.Image = null;
            this.colStaffGroupId.Text = "StaffGroupId";
            this.colStaffGroupId.Visible = false;
            this.colStaffGroupId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStaffGroupCode
            // 
            this.colStaffGroupCode.Image = null;
            this.colStaffGroupCode.Text = "Grade Code";
            this.colStaffGroupCode.Width = 80;
            // 
            // colStaffGroupName
            // 
            this.colStaffGroupName.Image = null;
            this.colStaffGroupName.Text = "Grade Name";
            this.colStaffGroupName.Width = 120;
            // 
            // colStaffGroupNameChs
            // 
            this.colStaffGroupNameChs.Image = null;
            this.colStaffGroupNameChs.Text = "Grade Name Chs";
            this.colStaffGroupNameChs.Width = 120;
            // 
            // colStaffGroupNameCht
            // 
            this.colStaffGroupNameCht.Image = null;
            this.colStaffGroupNameCht.Text = "Grade Name Cht";
            this.colStaffGroupNameCht.Width = 120;
            // 
            // chkCanWrite
            // 
            this.chkCanWrite.Checked = false;
            this.chkCanWrite.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanWrite.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanWrite.Location = new System.Drawing.Point(87, 173);
            this.chkCanWrite.Name = "chkCanWrite";
            this.chkCanWrite.Size = new System.Drawing.Size(62, 24);
            this.chkCanWrite.TabIndex = 11;
            this.chkCanWrite.Text = "Write";
            this.chkCanWrite.ThreeState = false;
            // 
            // chkCanRead
            // 
            this.chkCanRead.Checked = false;
            this.chkCanRead.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanRead.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanRead.Location = new System.Drawing.Point(19, 173);
            this.chkCanRead.Name = "chkCanRead";
            this.chkCanRead.Size = new System.Drawing.Size(62, 24);
            this.chkCanRead.TabIndex = 10;
            this.chkCanRead.Text = "Read";
            this.chkCanRead.ThreeState = false;
            // 
            // cboParentGrade
            // 
            this.cboParentGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentGrade.DropDownWidth = 142;
            this.cboParentGrade.Location = new System.Drawing.Point(122, 129);
            this.cboParentGrade.Name = "cboParentGrade";
            this.cboParentGrade.Size = new System.Drawing.Size(142, 21);
            this.cboParentGrade.TabIndex = 5;
            // 
            // lblParentGrade
            // 
            this.lblParentGrade.Location = new System.Drawing.Point(16, 132);
            this.lblParentGrade.Name = "lblParentGrade";
            this.lblParentGrade.Size = new System.Drawing.Size(100, 23);
            this.lblParentGrade.TabIndex = 9;
            this.lblParentGrade.Text = "Attached To:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtStaffGroupNameCht
            // 
            this.txtStaffGroupNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtStaffGroupNameCht.Name = "txtStaffGroupNameCht";
            this.txtStaffGroupNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtStaffGroupNameCht.TabIndex = 4;
            // 
            // txtStaffGroupNameChs
            // 
            this.txtStaffGroupNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtStaffGroupNameChs.Name = "txtStaffGroupNameChs";
            this.txtStaffGroupNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtStaffGroupNameChs.TabIndex = 3;
            // 
            // txtStaffGroupName
            // 
            this.txtStaffGroupName.Location = new System.Drawing.Point(122, 60);
            this.txtStaffGroupName.Name = "txtStaffGroupName";
            this.txtStaffGroupName.Size = new System.Drawing.Size(142, 20);
            this.txtStaffGroupName.TabIndex = 2;
            // 
            // lblStaffGroupNameCht
            // 
            this.lblStaffGroupNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblStaffGroupNameCht.Name = "lblStaffGroupNameCht";
            this.lblStaffGroupNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblStaffGroupNameCht.TabIndex = 4;
            this.lblStaffGroupNameCht.Text = "Grade Name Cht";
            // 
            // lblStaffGroupNameChs
            // 
            this.lblStaffGroupNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblStaffGroupNameChs.Name = "lblStaffGroupNameChs";
            this.lblStaffGroupNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblStaffGroupNameChs.TabIndex = 3;
            this.lblStaffGroupNameChs.Text = "Grade Name Chs:";
            // 
            // lblStaffGroupName
            // 
            this.lblStaffGroupName.Location = new System.Drawing.Point(16, 63);
            this.lblStaffGroupName.Name = "lblStaffGroupName";
            this.lblStaffGroupName.Size = new System.Drawing.Size(100, 23);
            this.lblStaffGroupName.TabIndex = 2;
            this.lblStaffGroupName.Text = "Grade Name:";
            // 
            // txtStaffGroupCode
            // 
            this.txtStaffGroupCode.Location = new System.Drawing.Point(122, 37);
            this.txtStaffGroupCode.MaxLength = 10;
            this.txtStaffGroupCode.Name = "txtStaffGroupCode";
            this.txtStaffGroupCode.Size = new System.Drawing.Size(142, 20);
            this.txtStaffGroupCode.TabIndex = 1;
            // 
            // lblStaffGroupCode
            // 
            this.lblStaffGroupCode.Location = new System.Drawing.Point(16, 40);
            this.lblStaffGroupCode.Name = "lblStaffGroupCode";
            this.lblStaffGroupCode.Size = new System.Drawing.Size(100, 23);
            this.lblStaffGroupCode.TabIndex = 0;
            this.lblStaffGroupCode.Text = "Grade Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
            this.errorProvider.Icon = null;
            // 
            // chkCanDelete
            // 
            this.chkCanDelete.Checked = false;
            this.chkCanDelete.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanDelete.Location = new System.Drawing.Point(155, 173);
            this.chkCanDelete.Name = "chkCanDelete";
            this.chkCanDelete.Size = new System.Drawing.Size(62, 24);
            this.chkCanDelete.TabIndex = 12;
            this.chkCanDelete.Text = "Delete";
            this.chkCanDelete.ThreeState = false;
            // 
            // chkCanPost
            // 
            this.chkCanPost.Checked = false;
            this.chkCanPost.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkCanPost.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkCanPost.Location = new System.Drawing.Point(223, 173);
            this.chkCanPost.Name = "chkCanPost";
            this.chkCanPost.Size = new System.Drawing.Size(62, 24);
            this.chkCanPost.TabIndex = 13;
            this.chkCanPost.Text = "Post";
            this.chkCanPost.ThreeState = false;
            // 
            // StaffGroupWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "StaffGroup Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvStaffGroupList;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupName;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupName;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupNameCht;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupNameChs;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupName;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupCode;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentGrade;
        private Gizmox.WebGUI.Forms.Label lblParentGrade;
        private Gizmox.WebGUI.Forms.CheckBox chkCanWrite;
        private Gizmox.WebGUI.Forms.CheckBox chkCanRead;
        private Gizmox.WebGUI.Forms.CheckBox chkCanPost;
        private Gizmox.WebGUI.Forms.CheckBox chkCanDelete;


    }
}