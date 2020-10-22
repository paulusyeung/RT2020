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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvAddressTypeList = new Gizmox.WebGUI.Forms.ListView();
            this.colAddressTypeId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddressTypeCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddressTypeName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddressTypeNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAddressTypeNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtAddressTypeNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAddressTypeNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAddressTypeName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAddressTypeNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblAddressTypeNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblAddressTypeName = new Gizmox.WebGUI.Forms.Label();
            this.txtAddressTypeCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAddressTypeCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvAddressTypeList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeName);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeName);
            this.splitContainer.Panel2.Controls.Add(this.txtAddressTypeCode);
            this.splitContainer.Panel2.Controls.Add(this.lblAddressTypeCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvAddressTypeList
            // 
            this.lvAddressTypeList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvAddressTypeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colAddressTypeId,
            this.colLN,
            this.colAddressTypeCode,
            this.colAddressTypeName,
            this.colAddressTypeNameChs,
            this.colAddressTypeNameCht});
            this.lvAddressTypeList.DataMember = null;
            this.lvAddressTypeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvAddressTypeList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvAddressTypeList.ItemsPerPage = 20;
            this.lvAddressTypeList.Location = new System.Drawing.Point(0, 0);
            this.lvAddressTypeList.Name = "lvAddressTypeList";
            this.lvAddressTypeList.Size = new System.Drawing.Size(499, 506);
            this.lvAddressTypeList.TabIndex = 0;
            this.lvAddressTypeList.UseInternalPaging = true;
            this.lvAddressTypeList.SelectedIndexChanged += new System.EventHandler(this.lvAddressTypeList_SelectedIndexChanged);
            // 
            // colAddressTypeId
            // 
            this.colAddressTypeId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAddressTypeId.Image = null;
            this.colAddressTypeId.Text = "AddressTypeId";
            this.colAddressTypeId.Visible = false;
            this.colAddressTypeId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colAddressTypeCode
            // 
            this.colAddressTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAddressTypeCode.Image = null;
            this.colAddressTypeCode.Text = "Type Code";
            this.colAddressTypeCode.Width = 80;
            // 
            // colAddressTypeName
            // 
            this.colAddressTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAddressTypeName.Image = null;
            this.colAddressTypeName.Text = "Type Name";
            this.colAddressTypeName.Width = 120;
            // 
            // colAddressTypeNameChs
            // 
            this.colAddressTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAddressTypeNameChs.Image = null;
            this.colAddressTypeNameChs.Text = "Type Name Chs";
            this.colAddressTypeNameChs.Width = 120;
            // 
            // colAddressTypeNameCht
            // 
            this.colAddressTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colAddressTypeNameCht.Image = null;
            this.colAddressTypeNameCht.Text = "Type Name Cht";
            this.colAddressTypeNameCht.Width = 120;
            // 
            // txtPriority
            // 
            this.txtPriority.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPriority.Location = new System.Drawing.Point(122, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(142, 20);
            this.txtPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPriority.Location = new System.Drawing.Point(16, 132);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(100, 23);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "Priority:";
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
            this.tbWizardAction.TabIndex = 6;
            // 
            // txtAddressTypeNameCht
            // 
            this.txtAddressTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAddressTypeNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtAddressTypeNameCht.Name = "txtAddressTypeNameCht";
            this.txtAddressTypeNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtAddressTypeNameCht.TabIndex = 4;
            // 
            // txtAddressTypeNameChs
            // 
            this.txtAddressTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAddressTypeNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtAddressTypeNameChs.Name = "txtAddressTypeNameChs";
            this.txtAddressTypeNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtAddressTypeNameChs.TabIndex = 3;
            // 
            // txtAddressTypeName
            // 
            this.txtAddressTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAddressTypeName.Location = new System.Drawing.Point(122, 60);
            this.txtAddressTypeName.Name = "txtAddressTypeName";
            this.txtAddressTypeName.Size = new System.Drawing.Size(142, 20);
            this.txtAddressTypeName.TabIndex = 2;
            // 
            // lblAddressTypeNameCht
            // 
            this.lblAddressTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddressTypeNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblAddressTypeNameCht.Name = "lblAddressTypeNameCht";
            this.lblAddressTypeNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeNameCht.TabIndex = 4;
            this.lblAddressTypeNameCht.Text = "Type Name Cht";
            // 
            // lblAddressTypeNameChs
            // 
            this.lblAddressTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddressTypeNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblAddressTypeNameChs.Name = "lblAddressTypeNameChs";
            this.lblAddressTypeNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeNameChs.TabIndex = 3;
            this.lblAddressTypeNameChs.Text = "Type Name Chs:";
            // 
            // lblAddressTypeName
            // 
            this.lblAddressTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddressTypeName.Location = new System.Drawing.Point(16, 63);
            this.lblAddressTypeName.Name = "lblAddressTypeName";
            this.lblAddressTypeName.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeName.TabIndex = 2;
            this.lblAddressTypeName.Text = "Type Name:";
            // 
            // txtAddressTypeCode
            // 
            this.txtAddressTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAddressTypeCode.Location = new System.Drawing.Point(122, 37);
            this.txtAddressTypeCode.MaxLength = 10;
            this.txtAddressTypeCode.Name = "txtAddressTypeCode";
            this.txtAddressTypeCode.Size = new System.Drawing.Size(142, 20);
            this.txtAddressTypeCode.TabIndex = 1;
            // 
            // lblAddressTypeCode
            // 
            this.lblAddressTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAddressTypeCode.Location = new System.Drawing.Point(16, 40);
            this.lblAddressTypeCode.Name = "lblAddressTypeCode";
            this.lblAddressTypeCode.Size = new System.Drawing.Size(100, 23);
            this.lblAddressTypeCode.TabIndex = 0;
            this.lblAddressTypeCode.Text = "Type Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // SupplierAddressTypeWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "SupplierAddressType Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvAddressTypeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeName;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colAddressTypeNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeName;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeNameCht;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeNameChs;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeName;
        private Gizmox.WebGUI.Forms.TextBox txtAddressTypeCode;
        private Gizmox.WebGUI.Forms.Label lblAddressTypeCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;


    }
}