namespace RT2020.Product
{
    partial class ProductClassWizardAio
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
            this.colClassId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInitial = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClassNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInitial = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel2.Controls.Add(this.txtInitial);
            this.splitContainer.Panel2.Controls.Add(this.lblInitial);
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
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colClassId,
            this.colLN,
            this.colClassCode,
            this.colInitial,
            this.colClassName,
            this.colClassNameAlt1,
            this.colClassNameAlt2});
            this.lvTagList.DataMember = null;
            this.lvTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTagList.Location = new System.Drawing.Point(0, 0);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(499, 506);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseInternalPaging = true;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // colClassId
            // 
            this.colClassId.Text = "ClassId";
            this.colClassId.Visible = false;
            this.colClassId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colClassCode
            // 
            this.colClassCode.Text = "Class Code";
            this.colClassCode.Width = 60;
            // 
            // colInitial
            // 
            this.colInitial.Tag = "";
            this.colInitial.Text = "Initial";
            this.colInitial.Width = 80;
            // 
            // colClassName
            // 
            this.colClassName.Text = "Class Name";
            this.colClassName.Width = 100;
            // 
            // colClassNameAlt1
            // 
            this.colClassNameAlt1.Text = "Tag Name Chs";
            this.colClassNameAlt1.Width = 100;
            // 
            // colClassNameAlt2
            // 
            this.colClassNameAlt2.Text = "Class Name Cht";
            this.colClassNameAlt2.Width = 120;
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(160, 61);
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(130, 20);
            this.txtInitial.TabIndex = 5;
            // 
            // lblInitial
            // 
            this.lblInitial.Location = new System.Drawing.Point(16, 64);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(100, 23);
            this.lblInitial.TabIndex = 9;
            this.lblInitial.Text = "Initial:";
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
            this.tbWizardAction.TabIndex = 6;
            // 
            // txtClassNameAlt2
            // 
            this.txtClassNameAlt2.Location = new System.Drawing.Point(160, 131);
            this.txtClassNameAlt2.Name = "txtClassNameAlt2";
            this.txtClassNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtClassNameAlt2.TabIndex = 4;
            // 
            // txtClassNameAlt1
            // 
            this.txtClassNameAlt1.Location = new System.Drawing.Point(160, 108);
            this.txtClassNameAlt1.Name = "txtClassNameAlt1";
            this.txtClassNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtClassNameAlt1.TabIndex = 3;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(160, 85);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(130, 20);
            this.txtClassName.TabIndex = 2;
            // 
            // lblClassNameAlt2
            // 
            this.lblClassNameAlt2.Location = new System.Drawing.Point(29, 134);
            this.lblClassNameAlt2.Name = "lblClassNameAlt2";
            this.lblClassNameAlt2.Size = new System.Drawing.Size(128, 20);
            this.lblClassNameAlt2.TabIndex = 4;
            this.lblClassNameAlt2.Text = "Class Name Cht";
            // 
            // lblClassNameAlt1
            // 
            this.lblClassNameAlt1.Location = new System.Drawing.Point(29, 111);
            this.lblClassNameAlt1.Name = "lblClassNameAlt1";
            this.lblClassNameAlt1.Size = new System.Drawing.Size(128, 20);
            this.lblClassNameAlt1.TabIndex = 3;
            this.lblClassNameAlt1.Text = "Class Name Chs:";
            // 
            // lblClassName
            // 
            this.lblClassName.Location = new System.Drawing.Point(16, 88);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(100, 23);
            this.lblClassName.TabIndex = 2;
            this.lblClassName.Text = "Class Name:";
            // 
            // txtClassCode
            // 
            this.txtClassCode.Location = new System.Drawing.Point(160, 37);
            this.txtClassCode.MaxLength = 10;
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new System.Drawing.Size(130, 20);
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
            // ProductClassWizardAio
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Workplace Wizard";
            this.Load += new System.EventHandler(this.ProductClassWizardAio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTagList;
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
        private Gizmox.WebGUI.Forms.Label lblInitial;
        private Gizmox.WebGUI.Forms.TextBox txtInitial;
        private Gizmox.WebGUI.Forms.ColumnHeader colInitial;
    }
}