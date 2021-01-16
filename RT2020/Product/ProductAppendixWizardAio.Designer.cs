namespace RT2020.Product
{
    partial class ProductAppendixWizardAio
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
            this.colId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInitial = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInitial = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblName = new Gizmox.WebGUI.Forms.Label();
            this.txtCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel2.Controls.Add(this.txtNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtName);
            this.splitContainer.Panel2.Controls.Add(this.lblNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblName);
            this.splitContainer.Panel2.Controls.Add(this.txtCode);
            this.splitContainer.Panel2.Controls.Add(this.lblCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colId,
            this.colLN,
            this.colCode,
            this.colInitial,
            this.colName,
            this.colNameAlt1,
            this.colNameAlt2});
            this.lvTagList.DataMember = null;
            this.lvTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTagList.Location = new System.Drawing.Point(0, 0);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(499, 506);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseInternalPaging = true;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // colId
            // 
            this.colId.Text = "Id";
            this.colId.Visible = false;
            this.colId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 60;
            // 
            // colInitial
            // 
            this.colInitial.Tag = "";
            this.colInitial.Text = "Initial";
            this.colInitial.Width = 80;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colNameAlt1
            // 
            this.colNameAlt1.Text = "Name Chs";
            this.colNameAlt1.Width = 100;
            // 
            // colNameAlt2
            // 
            this.colNameAlt2.Text = "Name Cht";
            this.colNameAlt2.Width = 120;
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
            // txtNameAlt2
            // 
            this.txtNameAlt2.Location = new System.Drawing.Point(160, 131);
            this.txtNameAlt2.Name = "txtNameAlt2";
            this.txtNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtNameAlt2.TabIndex = 4;
            // 
            // txtNameAlt1
            // 
            this.txtNameAlt1.Location = new System.Drawing.Point(160, 108);
            this.txtNameAlt1.Name = "txtNameAlt1";
            this.txtNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtNameAlt1.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblNameAlt2
            // 
            this.lblNameAlt2.Location = new System.Drawing.Point(29, 134);
            this.lblNameAlt2.Name = "lblNameAlt2";
            this.lblNameAlt2.Size = new System.Drawing.Size(128, 20);
            this.lblNameAlt2.TabIndex = 4;
            this.lblNameAlt2.Text = "Name Cht";
            // 
            // lblNameAlt1
            // 
            this.lblNameAlt1.Location = new System.Drawing.Point(29, 111);
            this.lblNameAlt1.Name = "lblNameAlt1";
            this.lblNameAlt1.Size = new System.Drawing.Size(128, 20);
            this.lblNameAlt1.TabIndex = 3;
            this.lblNameAlt1.Text = "Name Chs:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(16, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(160, 37);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(130, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(16, 40);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // ProductAppendixWizardAio
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Workplace Wizard";
            this.Load += new System.EventHandler(this.ProductAppendixWizardAio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colName;
        private Gizmox.WebGUI.Forms.ColumnHeader colNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtName;
        private Gizmox.WebGUI.Forms.Label lblNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblName;
        private Gizmox.WebGUI.Forms.TextBox txtCode;
        private Gizmox.WebGUI.Forms.Label lblCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblInitial;
        private Gizmox.WebGUI.Forms.TextBox txtInitial;
        private Gizmox.WebGUI.Forms.ColumnHeader colInitial;
    }
}