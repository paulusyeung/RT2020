namespace RT2020.Member
{
    partial class MemberClassWizard
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
            this.lvClassList = new Gizmox.WebGUI.Forms.ListView();
            this.colClassId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentClass = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentClass = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtClassNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClassNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClassName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblClassNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblClassNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblClassName = new Gizmox.WebGUI.Forms.Label();
            this.txtClassCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblClassCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.colParentClass = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
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
            this.splitContainer.Panel1.Controls.Add(this.lvClassList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentClass);
            this.splitContainer.Panel2.Controls.Add(this.lblParentClass);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtClassNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtClassNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtClassName);
            this.splitContainer.Panel2.Controls.Add(this.lblClassNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblClassNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblClassName);
            this.splitContainer.Panel2.Controls.Add(this.txtClassCode);
            this.splitContainer.Panel2.Controls.Add(this.lblClassCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvClassList
            // 
            this.lvClassList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colClassId,
            this.colLN,
            this.colClassCode,
            this.colClassName,
            this.colClassNameAlt1,
            this.colClassNameAlt2,
            this.colParentClass});
            this.lvClassList.DataMember = null;
            this.lvClassList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvClassList.Location = new System.Drawing.Point(0, 0);
            this.lvClassList.Name = "lvClassList";
            this.lvClassList.Size = new System.Drawing.Size(499, 506);
            this.lvClassList.TabIndex = 0;
            this.lvClassList.UseInternalPaging = true;
            this.lvClassList.SelectedIndexChanged += new System.EventHandler(this.lvMemberClassList_SelectedIndexChanged);
            // 
            // colClassId
            // 
            this.colClassId.Text = "MemberClassId";
            this.colClassId.Visible = false;
            this.colClassId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colClassCode
            // 
            this.colClassCode.Text = "Class Code";
            this.colClassCode.Width = 80;
            // 
            // colClassName
            // 
            this.colClassName.Text = "Class Name";
            this.colClassName.Width = 120;
            // 
            // colClassNameAlt1
            // 
            this.colClassNameAlt1.Text = "Class Name Chs";
            this.colClassNameAlt1.Width = 120;
            // 
            // colClassNameAlt2
            // 
            this.colClassNameAlt2.Text = "Class Name Cht";
            this.colClassNameAlt2.Width = 120;
            // 
            // cboParentClass
            // 
            this.cboParentClass.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentClass.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentClass.DropDownWidth = 142;
            this.cboParentClass.Location = new System.Drawing.Point(152, 129);
            this.cboParentClass.Name = "cboParentClass";
            this.cboParentClass.Size = new System.Drawing.Size(138, 21);
            this.cboParentClass.TabIndex = 5;
            // 
            // lblParentClass
            // 
            this.lblParentClass.Location = new System.Drawing.Point(16, 132);
            this.lblParentClass.Name = "lblParentClass";
            this.lblParentClass.Size = new System.Drawing.Size(100, 23);
            this.lblParentClass.TabIndex = 9;
            this.lblParentClass.Text = "Attached To:";
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
            // txtClassNameAlt2
            // 
            this.txtClassNameAlt2.Location = new System.Drawing.Point(152, 106);
            this.txtClassNameAlt2.Name = "txtClassNameAlt2";
            this.txtClassNameAlt2.Size = new System.Drawing.Size(138, 20);
            this.txtClassNameAlt2.TabIndex = 4;
            // 
            // txtClassNameAlt1
            // 
            this.txtClassNameAlt1.Location = new System.Drawing.Point(152, 83);
            this.txtClassNameAlt1.Name = "txtClassNameAlt1";
            this.txtClassNameAlt1.Size = new System.Drawing.Size(138, 20);
            this.txtClassNameAlt1.TabIndex = 3;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(152, 60);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(138, 20);
            this.txtClassName.TabIndex = 2;
            // 
            // lblClassNameAlt2
            // 
            this.lblClassNameAlt2.Location = new System.Drawing.Point(25, 109);
            this.lblClassNameAlt2.Name = "lblClassNameAlt2";
            this.lblClassNameAlt2.Size = new System.Drawing.Size(124, 23);
            this.lblClassNameAlt2.TabIndex = 4;
            this.lblClassNameAlt2.Text = "Class Name Cht";
            // 
            // lblClassNameAlt1
            // 
            this.lblClassNameAlt1.Location = new System.Drawing.Point(25, 86);
            this.lblClassNameAlt1.Name = "lblClassNameAlt1";
            this.lblClassNameAlt1.Size = new System.Drawing.Size(124, 23);
            this.lblClassNameAlt1.TabIndex = 3;
            this.lblClassNameAlt1.Text = "Class Name Chs:";
            // 
            // lblClassName
            // 
            this.lblClassName.Location = new System.Drawing.Point(16, 63);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(100, 23);
            this.lblClassName.TabIndex = 2;
            this.lblClassName.Text = "Class Name:";
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(152, 37);
            this.txtClassCode.MaxLength = 10;
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(138, 20);
            this.txtClassCode.TabIndex = 1;
            // 
            // lblClassCode
            // 
            this.lblClassCode.Location = new System.Drawing.Point(16, 40);
            this.lblClassCode.Name = "lblClassCode";
            this.lblClassCode.Size = new System.Drawing.Size(100, 23);
            this.lblClassCode.TabIndex = 0;
            this.lblClassCode.Text = "Class Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // colParentClass
            // 
            this.colParentClass.Text = "Parent Class";
            this.colParentClass.Width = 100;
            // 
            // MemberClassWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberClass Wizard";
            this.Load += new System.EventHandler(this.MemberClassWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvClassList;
        private Gizmox.WebGUI.Forms.ColumnHeader colClassId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colClassCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colClassName;
        private Gizmox.WebGUI.Forms.ColumnHeader colClassNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colClassNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtClassNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtClassNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtClassName;
        private Gizmox.WebGUI.Forms.Label lblClassNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblClassNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblClassName;
        private Gizmox.WebGUI.Forms.TextBox txtClassCode;
        private Gizmox.WebGUI.Forms.Label lblClassCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentClass;
        private Gizmox.WebGUI.Forms.Label lblParentClass;
        private Gizmox.WebGUI.Forms.ColumnHeader colParentClass;
    }
}