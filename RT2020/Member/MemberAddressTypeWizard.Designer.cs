namespace RT2020.Member
{
    partial class MemberAddressTypeWizard
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
            this.lvAddressTypeList = new Gizmox.WebGUI.Forms.ListView();
            this.colAddressTypeId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAddressTypeCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPriority = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAddressTypeName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAddressTypeNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAddressTypeNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtAddressTypeNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAddressTypeNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAddressTypeName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAddressTypeNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblAddressTypeNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblAddressTypeName = new Gizmox.WebGUI.Forms.Label();
            this.txtAddressTypeCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAddressTypeCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvAddressTypeList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeName);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeName);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeCode);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvAddressTypeList
            // 
            this.lvAddressTypeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colAddressTypeId,
            this.colLN,
            this.colAddressTypeCode,
            this.colPriority,
            this.colAddressTypeName,
            this.colAddressTypeNameAlt1,
            this.colAddressTypeNameAlt2});
            this.lvAddressTypeList.DataMember = null;
            this.lvAddressTypeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvAddressTypeList.Location = new System.Drawing.Point(0, 0);
            this.lvAddressTypeList.Name = "lvAddressTypeList";
            this.lvAddressTypeList.Size = new System.Drawing.Size(499, 506);
            this.lvAddressTypeList.TabIndex = 0;
            this.lvAddressTypeList.UseInternalPaging = true;
            this.lvAddressTypeList.SelectedIndexChanged += new System.EventHandler(this.lvAddressTypeList_SelectedIndexChanged);
            this.lvAddressTypeList.ColumnClick += new Gizmox.WebGUI.Forms.ColumnClickEventHandler(this.lvAddressTypeList_ColumnClick);
            // 
            // colAddressTypeId
            // 
            this.colAddressTypeId.Text = "AddressTypeId";
            this.colAddressTypeId.Visible = false;
            this.colAddressTypeId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colAddressTypeCode
            // 
            this.colAddressTypeCode.Text = "Type Code";
            this.colAddressTypeCode.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.Tag = "Numeric";
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 60;
            // 
            // colAddressTypeName
            // 
            this.colAddressTypeName.Text = "Type Name";
            this.colAddressTypeName.Width = 120;
            // 
            // colAddressTypeNameAlt1
            // 
            this.colAddressTypeNameAlt1.Text = "Type Name Chs";
            this.colAddressTypeNameAlt1.Width = 120;
            // 
            // colAddressTypeNameAlt2
            // 
            this.colAddressTypeNameAlt2.Text = "Type Name Cht";
            this.colAddressTypeNameAlt2.Width = 120;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(166, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(124, 20);
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
            this.tbWizardAction.Size = new System.Drawing.Size(302, 26);
            this.tbWizardAction.TabIndex = 6;
            // 
            // txtAddressTypeNameAlt2
            // 
            this.txtAddressTypeNameAlt2.Location = new System.Drawing.Point(166, 106);
            this.txtAddressTypeNameAlt2.Name = "txtAddressTypeNameAlt2";
            this.txtAddressTypeNameAlt2.Size = new System.Drawing.Size(124, 20);
            this.txtAddressTypeNameAlt2.TabIndex = 4;
            // 
            // txtAddressTypeNameAlt1
            // 
            this.txtAddressTypeNameAlt1.Location = new System.Drawing.Point(166, 83);
            this.txtAddressTypeNameAlt1.Name = "txtAddressTypeNameAlt1";
            this.txtAddressTypeNameAlt1.Size = new System.Drawing.Size(124, 20);
            this.txtAddressTypeNameAlt1.TabIndex = 3;
            // 
            // txtAddressTypeName
            // 
            this.txtAddressTypeName.Location = new System.Drawing.Point(166, 60);
            this.txtAddressTypeName.Name = "txtAddressTypeName";
            this.txtAddressTypeName.Size = new System.Drawing.Size(124, 20);
            this.txtAddressTypeName.TabIndex = 2;
            // 
            // lblAddressTypeNameAlt2
            // 
            this.lblAddressTypeNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblAddressTypeNameAlt2.Name = "lblAddressTypeNameAlt2";
            this.lblAddressTypeNameAlt2.Size = new System.Drawing.Size(135, 23);
            this.lblAddressTypeNameAlt2.TabIndex = 4;
            this.lblAddressTypeNameAlt2.Text = "Type Name Cht";
            // 
            // lblAddressTypeNameAlt1
            // 
            this.lblAddressTypeNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblAddressTypeNameAlt1.Name = "lblAddressTypeNameAlt1";
            this.lblAddressTypeNameAlt1.Size = new System.Drawing.Size(135, 23);
            this.lblAddressTypeNameAlt1.TabIndex = 3;
            this.lblAddressTypeNameAlt1.Text = "Type Name Chs:";
            // 
            // lblAddressTypeName
            // 
            this.lblAddressTypeName.Location = new System.Drawing.Point(16, 63);
            this.lblAddressTypeName.Name = "lblAddressTypeName";
            this.lblAddressTypeName.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeName.TabIndex = 2;
            this.lblAddressTypeName.Text = "Type Name:";
            // 
            // txtAddressTypeCode
            // 
            this.txtAddressTypeCode.Location = new System.Drawing.Point(166, 37);
            this.txtAddressTypeCode.MaxLength = 10;
            this.txtAddressTypeCode.Name = "txtAddressTypeCode";
            this.txtAddressTypeCode.Size = new System.Drawing.Size(124, 20);
            this.txtAddressTypeCode.TabIndex = 1;
            // 
            // lblAddressTypeCode
            // 
            this.lblAddressTypeCode.Location = new System.Drawing.Point(16, 40);
            this.lblAddressTypeCode.Name = "lblAddressTypeCode";
            this.lblAddressTypeCode.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeCode.TabIndex = 0;
            this.lblAddressTypeCode.Text = "Type Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // MemberAddressTypeWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberAddressType Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvAddressTypeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeName;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeName;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeName;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeCode;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.ColumnHeader colPriority;
    }
}