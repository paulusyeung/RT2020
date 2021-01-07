namespace RT2020.Supplier
{
    partial class SupplierAddressTypeWizard
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
            this.colAddressTypeName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtTypeNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTypeNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTypeName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTypeNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblTypeNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTypeName = new Gizmox.WebGUI.Forms.Label();
            this.txtTypeCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTypeCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.colPriority = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
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
            this.splitContainer.Panel2.Controls.Add(this.txtTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeName);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeName);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeCode);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeCode);
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
            this.colTypeNameAlt1,
            this.colTypeNameAlt2});
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
            this.colAddressTypeId.Width = 100;
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
            // colAddressTypeName
            // 
            this.colAddressTypeName.Text = "Type Name";
            this.colAddressTypeName.Width = 120;
            // 
            // colTypeNameAlt1
            // 
            this.colTypeNameAlt1.Text = "Type Name Chs";
            this.colTypeNameAlt1.Width = 120;
            // 
            // colTypeNameAlt2
            // 
            this.colTypeNameAlt2.Text = "Type Name Cht";
            this.colTypeNameAlt2.Width = 120;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(156, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(130, 20);
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
            // txtTypeNameAlt2
            // 
            this.txtTypeNameAlt2.Location = new System.Drawing.Point(156, 106);
            this.txtTypeNameAlt2.Name = "txtTypeNameAlt2";
            this.txtTypeNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtTypeNameAlt2.TabIndex = 4;
            // 
            // txtTypeNameAlt1
            // 
            this.txtTypeNameAlt1.Location = new System.Drawing.Point(156, 83);
            this.txtTypeNameAlt1.Name = "txtTypeNameAlt1";
            this.txtTypeNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtTypeNameAlt1.TabIndex = 3;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(156, 60);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(130, 20);
            this.txtTypeName.TabIndex = 2;
            // 
            // lblTypeNameAlt2
            // 
            this.lblTypeNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblTypeNameAlt2.Name = "lblTypeNameAlt2";
            this.lblTypeNameAlt2.Size = new System.Drawing.Size(125, 23);
            this.lblTypeNameAlt2.TabIndex = 4;
            this.lblTypeNameAlt2.Text = "Type Name Cht";
            // 
            // lblTypeNameAlt1
            // 
            this.lblTypeNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblTypeNameAlt1.Name = "lblTypeNameAlt1";
            this.lblTypeNameAlt1.Size = new System.Drawing.Size(125, 23);
            this.lblTypeNameAlt1.TabIndex = 3;
            this.lblTypeNameAlt1.Text = "Type Name Chs:";
            // 
            // lblTypeName
            // 
            this.lblTypeName.Location = new System.Drawing.Point(16, 63);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(100, 23);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "Type Name:";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.Location = new System.Drawing.Point(156, 37);
            this.txtTypeCode.MaxLength = 10;
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.Size = new System.Drawing.Size(130, 20);
            this.txtTypeCode.TabIndex = 1;
            // 
            // lblTypeCode
            // 
            this.lblTypeCode.Location = new System.Drawing.Point(16, 40);
            this.lblTypeCode.Name = "lblTypeCode";
            this.lblTypeCode.Size = new System.Drawing.Size(100, 23);
            this.lblTypeCode.TabIndex = 0;
            this.lblTypeCode.Text = "Type Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // colPriority
            // 
            this.colPriority.Tag = "Numeric";
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 60;
            // 
            // SupplierAddressTypeWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "SupplierAddressType Wizard";
            this.Load += new System.EventHandler(this.SupplierAddressTypeWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvAddressTypeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTypeNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtTypeName;
        private Gizmox.WebGUI.Forms.Label lblTypeNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblTypeNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblTypeName;
        private Gizmox.WebGUI.Forms.TextBox txtTypeCode;
        private Gizmox.WebGUI.Forms.Label lblTypeCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.ColumnHeader colPriority;
    }
}