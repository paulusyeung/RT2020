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
            this.colStaffGroupId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffGroupCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffGroupName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffGroupNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffGroupNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.chkCanPost = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanDelete = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanWrite = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkCanRead = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboParentGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentGrade = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtStaffGroupNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffGroupNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStaffGroupName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffGroupNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffGroupNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblStaffGroupName = new Gizmox.WebGUI.Forms.Label();
            this.txtStaffGroupCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStaffGroupCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupName);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupName);
            this.splitContainer.Panel2.Controls.Add(this.txtStaffGroupCode);
            this.splitContainer.Panel2.Controls.Add(this.lblStaffGroupCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // lvStaffGroupList
            // 
            this.lvStaffGroupList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colStaffGroupId,
            this.colLN,
            this.colStaffGroupCode,
            this.colStaffGroupName,
            this.colStaffGroupNameAlt1,
            this.colStaffGroupNameAlt2});
            this.lvStaffGroupList.DataMember = null;
            this.lvStaffGroupList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvStaffGroupList.Location = new System.Drawing.Point(0, 0);
            this.lvStaffGroupList.Name = "lvStaffGroupList";
            this.lvStaffGroupList.Size = new System.Drawing.Size(499, 506);
            this.lvStaffGroupList.TabIndex = 0;
            this.lvStaffGroupList.UseInternalPaging = true;
            this.lvStaffGroupList.SelectedIndexChanged += new System.EventHandler(this.lvStaffGroupList_SelectedIndexChanged);
            // 
            // colStaffGroupId
            // 
            this.colStaffGroupId.Text = "StaffGroupId";
            this.colStaffGroupId.Visible = false;
            this.colStaffGroupId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colStaffGroupCode
            // 
            this.colStaffGroupCode.Text = "Grade Code";
            this.colStaffGroupCode.Width = 80;
            // 
            // colStaffGroupName
            // 
            this.colStaffGroupName.Text = "Grade Name";
            this.colStaffGroupName.Width = 120;
            // 
            // colStaffGroupNameAlt1
            // 
            this.colStaffGroupNameAlt1.Text = "Grade Name Chs";
            this.colStaffGroupNameAlt1.Width = 120;
            // 
            // colStaffGroupNameAlt2
            // 
            this.colStaffGroupNameAlt2.Text = "Grade Name Cht";
            this.colStaffGroupNameAlt2.Width = 120;
            // 
            // chkCanPost
            // 
            this.chkCanPost.Location = new System.Drawing.Point(223, 173);
            this.chkCanPost.Name = "chkCanPost";
            this.chkCanPost.Size = new System.Drawing.Size(70, 24);
            this.chkCanPost.TabIndex = 13;
            this.chkCanPost.Text = "Post";
            // 
            // chkCanDelete
            // 
            this.chkCanDelete.Location = new System.Drawing.Point(155, 173);
            this.chkCanDelete.Name = "chkCanDelete";
            this.chkCanDelete.Size = new System.Drawing.Size(68, 24);
            this.chkCanDelete.TabIndex = 12;
            this.chkCanDelete.Text = "Delete";
            // 
            // chkCanWrite
            // 
            this.chkCanWrite.Location = new System.Drawing.Point(87, 173);
            this.chkCanWrite.Name = "chkCanWrite";
            this.chkCanWrite.Size = new System.Drawing.Size(62, 24);
            this.chkCanWrite.TabIndex = 11;
            this.chkCanWrite.Text = "Write";
            // 
            // chkCanRead
            // 
            this.chkCanRead.Location = new System.Drawing.Point(19, 173);
            this.chkCanRead.Name = "chkCanRead";
            this.chkCanRead.Size = new System.Drawing.Size(62, 24);
            this.chkCanRead.TabIndex = 10;
            this.chkCanRead.Text = "Read";
            // 
            // cboParentGrade
            // 
            this.cboParentGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentGrade.DropDownWidth = 142;
            this.cboParentGrade.Location = new System.Drawing.Point(155, 129);
            this.cboParentGrade.Name = "cboParentGrade";
            this.cboParentGrade.Size = new System.Drawing.Size(135, 21);
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
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(304, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtStaffGroupNameAlt2
            // 
            this.txtStaffGroupNameAlt2.Location = new System.Drawing.Point(155, 106);
            this.txtStaffGroupNameAlt2.Name = "txtStaffGroupNameAlt2";
            this.txtStaffGroupNameAlt2.Size = new System.Drawing.Size(135, 20);
            this.txtStaffGroupNameAlt2.TabIndex = 4;
            // 
            // txtStaffGroupNameAlt1
            // 
            this.txtStaffGroupNameAlt1.Location = new System.Drawing.Point(155, 83);
            this.txtStaffGroupNameAlt1.Name = "txtStaffGroupNameAlt1";
            this.txtStaffGroupNameAlt1.Size = new System.Drawing.Size(135, 20);
            this.txtStaffGroupNameAlt1.TabIndex = 3;
            // 
            // txtStaffGroupName
            // 
            this.txtStaffGroupName.Location = new System.Drawing.Point(155, 60);
            this.txtStaffGroupName.Name = "txtStaffGroupName";
            this.txtStaffGroupName.Size = new System.Drawing.Size(135, 20);
            this.txtStaffGroupName.TabIndex = 2;
            // 
            // lblStaffGroupNameAlt2
            // 
            this.lblStaffGroupNameAlt2.Location = new System.Drawing.Point(27, 109);
            this.lblStaffGroupNameAlt2.Name = "lblStaffGroupNameAlt2";
            this.lblStaffGroupNameAlt2.Size = new System.Drawing.Size(125, 23);
            this.lblStaffGroupNameAlt2.TabIndex = 4;
            this.lblStaffGroupNameAlt2.Text = "Grade Name Cht";
            // 
            // lblStaffGroupNameAlt1
            // 
            this.lblStaffGroupNameAlt1.Location = new System.Drawing.Point(27, 86);
            this.lblStaffGroupNameAlt1.Name = "lblStaffGroupNameAlt1";
            this.lblStaffGroupNameAlt1.Size = new System.Drawing.Size(125, 23);
            this.lblStaffGroupNameAlt1.TabIndex = 3;
            this.lblStaffGroupNameAlt1.Text = "Grade Name Chs:";
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
            this.txtStaffGroupCode.Location = new System.Drawing.Point(155, 37);
            this.txtStaffGroupCode.MaxLength = 10;
            this.txtStaffGroupCode.Name = "txtStaffGroupCode";
            this.txtStaffGroupCode.Size = new System.Drawing.Size(135, 20);
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
            this.errorProvider.DataMember = " ";
            this.errorProvider.DataSource = " ";
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
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffGroupNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtStaffGroupName;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblStaffGroupNameAlt1;
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