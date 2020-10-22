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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvMemberClassList = new Gizmox.WebGUI.Forms.ListView();
            this.colMemberClassId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberClassCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberClassName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberClassNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colMemberClassNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentClass = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentClass = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtMemberClassNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMemberClassNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMemberClassName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMemberClassNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblMemberClassNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblMemberClassName = new Gizmox.WebGUI.Forms.Label();
            this.txtMemberClassCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMemberClassCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvMemberClassList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentClass);
            this.splitContainer.Panel2.Controls.Add(this.lblParentClass);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberClassNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberClassNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberClassName);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberClassNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberClassNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberClassName);
            this.splitContainer.Panel2.Controls.Add(this.txtMemberClassCode);
            this.splitContainer.Panel2.Controls.Add(this.lblMemberClassCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvMemberClassList
            // 
            this.lvMemberClassList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvMemberClassList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colMemberClassId,
            this.colLN,
            this.colMemberClassCode,
            this.colMemberClassName,
            this.colMemberClassNameChs,
            this.colMemberClassNameCht});
            this.lvMemberClassList.DataMember = null;
            this.lvMemberClassList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvMemberClassList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvMemberClassList.ItemsPerPage = 20;
            this.lvMemberClassList.Location = new System.Drawing.Point(0, 0);
            this.lvMemberClassList.Name = "lvMemberClassList";
            this.lvMemberClassList.Size = new System.Drawing.Size(499, 506);
            this.lvMemberClassList.TabIndex = 0;
            this.lvMemberClassList.UseInternalPaging = true;
            this.lvMemberClassList.SelectedIndexChanged += new System.EventHandler(this.lvMemberClassList_SelectedIndexChanged);
            // 
            // colMemberClassId
            // 
            this.colMemberClassId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberClassId.Image = null;
            this.colMemberClassId.Text = "MemberClassId";
            this.colMemberClassId.Visible = false;
            this.colMemberClassId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colMemberClassCode
            // 
            this.colMemberClassCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberClassCode.Image = null;
            this.colMemberClassCode.Text = "Class Code";
            this.colMemberClassCode.Width = 80;
            // 
            // colMemberClassName
            // 
            this.colMemberClassName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberClassName.Image = null;
            this.colMemberClassName.Text = "Class Name";
            this.colMemberClassName.Width = 120;
            // 
            // colMemberClassNameChs
            // 
            this.colMemberClassNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberClassNameChs.Image = null;
            this.colMemberClassNameChs.Text = "Class Name Chs";
            this.colMemberClassNameChs.Width = 120;
            // 
            // colMemberClassNameCht
            // 
            this.colMemberClassNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colMemberClassNameCht.Image = null;
            this.colMemberClassNameCht.Text = "Class Name Cht";
            this.colMemberClassNameCht.Width = 120;
            // 
            // cboParentClass
            // 
            this.cboParentClass.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentClass.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentClass.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentClass.DropDownWidth = 142;
            this.cboParentClass.Location = new System.Drawing.Point(122, 129);
            this.cboParentClass.Name = "cboParentClass";
            this.cboParentClass.Size = new System.Drawing.Size(142, 21);
            this.cboParentClass.TabIndex = 5;
            // 
            // lblParentClass
            // 
            this.lblParentClass.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentClass.Location = new System.Drawing.Point(16, 132);
            this.lblParentClass.Name = "lblParentClass";
            this.lblParentClass.Size = new System.Drawing.Size(100, 23);
            this.lblParentClass.TabIndex = 9;
            this.lblParentClass.Text = "Attached To:";
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
            // txtMemberClassNameCht
            // 
            this.txtMemberClassNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberClassNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtMemberClassNameCht.Name = "txtMemberClassNameCht";
            this.txtMemberClassNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtMemberClassNameCht.TabIndex = 4;
            // 
            // txtMemberClassNameChs
            // 
            this.txtMemberClassNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberClassNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtMemberClassNameChs.Name = "txtMemberClassNameChs";
            this.txtMemberClassNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtMemberClassNameChs.TabIndex = 3;
            // 
            // txtMemberClassName
            // 
            this.txtMemberClassName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberClassName.Location = new System.Drawing.Point(122, 60);
            this.txtMemberClassName.Name = "txtMemberClassName";
            this.txtMemberClassName.Size = new System.Drawing.Size(142, 20);
            this.txtMemberClassName.TabIndex = 2;
            // 
            // lblMemberClassNameCht
            // 
            this.lblMemberClassNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberClassNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblMemberClassNameCht.Name = "lblMemberClassNameCht";
            this.lblMemberClassNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblMemberClassNameCht.TabIndex = 4;
            this.lblMemberClassNameCht.Text = "Class Name Cht";
            // 
            // lblMemberClassNameChs
            // 
            this.lblMemberClassNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberClassNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblMemberClassNameChs.Name = "lblMemberClassNameChs";
            this.lblMemberClassNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblMemberClassNameChs.TabIndex = 3;
            this.lblMemberClassNameChs.Text = "Class Name Chs:";
            // 
            // lblMemberClassName
            // 
            this.lblMemberClassName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberClassName.Location = new System.Drawing.Point(16, 63);
            this.lblMemberClassName.Name = "lblMemberClassName";
            this.lblMemberClassName.Size = new System.Drawing.Size(100, 23);
            this.lblMemberClassName.TabIndex = 2;
            this.lblMemberClassName.Text = "Class Name:";
            // 
            // txtMemberClassCode
            // 
            this.txtMemberClassCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMemberClassCode.Location = new System.Drawing.Point(122, 37);
            this.txtMemberClassCode.MaxLength = 10;
            this.txtMemberClassCode.Name = "txtMemberClassCode";
            this.txtMemberClassCode.Size = new System.Drawing.Size(142, 20);
            this.txtMemberClassCode.TabIndex = 1;
            // 
            // lblMemberClassCode
            // 
            this.lblMemberClassCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMemberClassCode.Location = new System.Drawing.Point(16, 40);
            this.lblMemberClassCode.Name = "lblMemberClassCode";
            this.lblMemberClassCode.Size = new System.Drawing.Size(100, 23);
            this.lblMemberClassCode.TabIndex = 0;
            this.lblMemberClassCode.Text = "Class Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // MemberClassWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberClass Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvMemberClassList;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberClassId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberClassCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberClassName;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberClassNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colMemberClassNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMemberClassNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtMemberClassNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtMemberClassName;
        private Gizmox.WebGUI.Forms.Label lblMemberClassNameCht;
        private Gizmox.WebGUI.Forms.Label lblMemberClassNameChs;
        private Gizmox.WebGUI.Forms.Label lblMemberClassName;
        private Gizmox.WebGUI.Forms.TextBox txtMemberClassCode;
        private Gizmox.WebGUI.Forms.Label lblMemberClassCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentClass;
        private Gizmox.WebGUI.Forms.Label lblParentClass;


    }
}