namespace RT2020.Supplier
{
    partial class SupplierTermsWizard
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
            this.lvSupplierTermsList = new Gizmox.WebGUI.Forms.ListView();
            this.colSupplierTermsId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSupplierTermsCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSupplierTermsName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSupplierTermsNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSupplierTermsNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentTerms = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentTerms = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtSupplierTermsNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSupplierTermsNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSupplierTermsName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSupplierTermsNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplierTermsNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplierTermsName = new Gizmox.WebGUI.Forms.Label();
            this.txtSupplierTermsCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSupplierTermsCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvSupplierTermsList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentTerms);
            this.splitContainer.Panel2.Controls.Add(this.lblParentTerms);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtSupplierTermsNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtSupplierTermsNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtSupplierTermsName);
            this.splitContainer.Panel2.Controls.Add(this.lblSupplierTermsNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblSupplierTermsNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblSupplierTermsName);
            this.splitContainer.Panel2.Controls.Add(this.txtSupplierTermsCode);
            this.splitContainer.Panel2.Controls.Add(this.lblSupplierTermsCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvSupplierTermsList
            // 
            this.lvSupplierTermsList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvSupplierTermsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colSupplierTermsId,
            this.colLN,
            this.colSupplierTermsCode,
            this.colSupplierTermsName,
            this.colSupplierTermsNameChs,
            this.colSupplierTermsNameCht});
            this.lvSupplierTermsList.DataMember = null;
            this.lvSupplierTermsList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvSupplierTermsList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvSupplierTermsList.ItemsPerPage = 20;
            this.lvSupplierTermsList.Location = new System.Drawing.Point(0, 0);
            this.lvSupplierTermsList.Name = "lvSupplierTermsList";
            this.lvSupplierTermsList.Size = new System.Drawing.Size(499, 506);
            this.lvSupplierTermsList.TabIndex = 0;
            this.lvSupplierTermsList.UseInternalPaging = true;
            this.lvSupplierTermsList.SelectedIndexChanged += new System.EventHandler(this.lvSupplierTermsList_SelectedIndexChanged);
            // 
            // colSupplierTermsId
            // 
            this.colSupplierTermsId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSupplierTermsId.Image = null;
            this.colSupplierTermsId.Text = "SupplierTermsId";
            this.colSupplierTermsId.Visible = false;
            this.colSupplierTermsId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colSupplierTermsCode
            // 
            this.colSupplierTermsCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSupplierTermsCode.Image = null;
            this.colSupplierTermsCode.Text = "Terms Code";
            this.colSupplierTermsCode.Width = 80;
            // 
            // colSupplierTermsName
            // 
            this.colSupplierTermsName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSupplierTermsName.Image = null;
            this.colSupplierTermsName.Text = "Terms Name";
            this.colSupplierTermsName.Width = 120;
            // 
            // colSupplierTermsNameChs
            // 
            this.colSupplierTermsNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSupplierTermsNameChs.Image = null;
            this.colSupplierTermsNameChs.Text = "Terms Name Chs";
            this.colSupplierTermsNameChs.Width = 120;
            // 
            // colSupplierTermsNameCht
            // 
            this.colSupplierTermsNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSupplierTermsNameCht.Image = null;
            this.colSupplierTermsNameCht.Text = "Terms Name Cht";
            this.colSupplierTermsNameCht.Width = 120;
            // 
            // cboParentTerms
            // 
            this.cboParentTerms.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentTerms.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentTerms.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentTerms.DropDownWidth = 142;
            this.cboParentTerms.Location = new System.Drawing.Point(122, 129);
            this.cboParentTerms.Name = "cboParentTerms";
            this.cboParentTerms.Size = new System.Drawing.Size(142, 21);
            this.cboParentTerms.TabIndex = 5;
            // 
            // lblParentTerms
            // 
            this.lblParentTerms.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentTerms.Location = new System.Drawing.Point(16, 132);
            this.lblParentTerms.Name = "lblParentTerms";
            this.lblParentTerms.Size = new System.Drawing.Size(100, 23);
            this.lblParentTerms.TabIndex = 9;
            this.lblParentTerms.Text = "Attached To:";
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
            // txtSupplierTermsNameCht
            // 
            this.txtSupplierTermsNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSupplierTermsNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtSupplierTermsNameCht.Name = "txtSupplierTermsNameCht";
            this.txtSupplierTermsNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtSupplierTermsNameCht.TabIndex = 4;
            // 
            // txtSupplierTermsNameChs
            // 
            this.txtSupplierTermsNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSupplierTermsNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtSupplierTermsNameChs.Name = "txtSupplierTermsNameChs";
            this.txtSupplierTermsNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtSupplierTermsNameChs.TabIndex = 3;
            // 
            // txtSupplierTermsName
            // 
            this.txtSupplierTermsName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSupplierTermsName.Location = new System.Drawing.Point(122, 60);
            this.txtSupplierTermsName.Name = "txtSupplierTermsName";
            this.txtSupplierTermsName.Size = new System.Drawing.Size(142, 20);
            this.txtSupplierTermsName.TabIndex = 2;
            // 
            // lblSupplierTermsNameCht
            // 
            this.lblSupplierTermsNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplierTermsNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblSupplierTermsNameCht.Name = "lblSupplierTermsNameCht";
            this.lblSupplierTermsNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierTermsNameCht.TabIndex = 4;
            this.lblSupplierTermsNameCht.Text = "Terms Name Cht";
            // 
            // lblSupplierTermsNameChs
            // 
            this.lblSupplierTermsNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplierTermsNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblSupplierTermsNameChs.Name = "lblSupplierTermsNameChs";
            this.lblSupplierTermsNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierTermsNameChs.TabIndex = 3;
            this.lblSupplierTermsNameChs.Text = "Terms Name Chs:";
            // 
            // lblSupplierTermsName
            // 
            this.lblSupplierTermsName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplierTermsName.Location = new System.Drawing.Point(16, 63);
            this.lblSupplierTermsName.Name = "lblSupplierTermsName";
            this.lblSupplierTermsName.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierTermsName.TabIndex = 2;
            this.lblSupplierTermsName.Text = "Terms Name:";
            // 
            // txtSupplierTermsCode
            // 
            this.txtSupplierTermsCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSupplierTermsCode.Location = new System.Drawing.Point(122, 37);
            this.txtSupplierTermsCode.MaxLength = 10;
            this.txtSupplierTermsCode.Name = "txtSupplierTermsCode";
            this.txtSupplierTermsCode.Size = new System.Drawing.Size(142, 20);
            this.txtSupplierTermsCode.TabIndex = 1;
            // 
            // lblSupplierTermsCode
            // 
            this.lblSupplierTermsCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSupplierTermsCode.Location = new System.Drawing.Point(16, 40);
            this.lblSupplierTermsCode.Name = "lblSupplierTermsCode";
            this.lblSupplierTermsCode.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierTermsCode.TabIndex = 0;
            this.lblSupplierTermsCode.Text = "Terms Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // SupplierTermsWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "SupplierTerms Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvSupplierTermsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierTermsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierTermsCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierTermsName;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierTermsNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colSupplierTermsNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtSupplierTermsNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtSupplierTermsNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtSupplierTermsName;
        private Gizmox.WebGUI.Forms.Label lblSupplierTermsNameCht;
        private Gizmox.WebGUI.Forms.Label lblSupplierTermsNameChs;
        private Gizmox.WebGUI.Forms.Label lblSupplierTermsName;
        private Gizmox.WebGUI.Forms.TextBox txtSupplierTermsCode;
        private Gizmox.WebGUI.Forms.Label lblSupplierTermsCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentTerms;
        private Gizmox.WebGUI.Forms.Label lblParentTerms;


    }
}