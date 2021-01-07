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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvTermsList = new Gizmox.WebGUI.Forms.ListView();
            this.colTermsId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTermsCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colParent = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTermsName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTermsNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTermsNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentTerms = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentTerms = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtTermsNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTermsNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTermsName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTermsNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblTermsNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTermsName = new Gizmox.WebGUI.Forms.Label();
            this.txtTermsCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTermsCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvTermsList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentTerms);
            this.splitContainer.Panel2.Controls.Add(this.lblParentTerms);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtTermsNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtTermsNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtTermsName);
            this.splitContainer.Panel2.Controls.Add(this.lblTermsNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblTermsNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblTermsName);
            this.splitContainer.Panel2.Controls.Add(this.txtTermsCode);
            this.splitContainer.Panel2.Controls.Add(this.lblTermsCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvTermsList
            // 
            this.lvTermsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTermsId,
            this.colLN,
            this.colTermsCode,
            this.colParent,
            this.colTermsName,
            this.colTermsNameAlt1,
            this.colTermsNameAlt2});
            this.lvTermsList.DataMember = null;
            this.lvTermsList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTermsList.Location = new System.Drawing.Point(0, 0);
            this.lvTermsList.Name = "lvTermsList";
            this.lvTermsList.Size = new System.Drawing.Size(499, 506);
            this.lvTermsList.TabIndex = 0;
            this.lvTermsList.UseInternalPaging = true;
            this.lvTermsList.SelectedIndexChanged += new System.EventHandler(this.lvSupplierTermsList_SelectedIndexChanged);
            // 
            // colTermsId
            // 
            this.colTermsId.Text = "SupplierTermsId";
            this.colTermsId.Visible = false;
            this.colTermsId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTermsCode
            // 
            this.colTermsCode.Text = "Terms Code";
            this.colTermsCode.Width = 80;
            // 
            // colParent
            // 
            this.colParent.Text = "";
            this.colParent.Width = 80;
            // 
            // colTermsName
            // 
            this.colTermsName.Text = "Terms Name";
            this.colTermsName.Width = 120;
            // 
            // colTermsNameAlt1
            // 
            this.colTermsNameAlt1.Text = "Terms Name Chs";
            this.colTermsNameAlt1.Width = 120;
            // 
            // colTermsNameAlt2
            // 
            this.colTermsNameAlt2.Text = "Terms Name Cht";
            this.colTermsNameAlt2.Width = 120;
            // 
            // cboParentTerms
            // 
            this.cboParentTerms.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentTerms.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentTerms.DropDownWidth = 142;
            this.cboParentTerms.Location = new System.Drawing.Point(160, 129);
            this.cboParentTerms.Name = "cboParentTerms";
            this.cboParentTerms.Size = new System.Drawing.Size(130, 21);
            this.cboParentTerms.TabIndex = 5;
            // 
            // lblParentTerms
            // 
            this.lblParentTerms.Location = new System.Drawing.Point(16, 132);
            this.lblParentTerms.Name = "lblParentTerms";
            this.lblParentTerms.Size = new System.Drawing.Size(100, 23);
            this.lblParentTerms.TabIndex = 9;
            this.lblParentTerms.Text = "Attached To:";
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
            // txtTermsNameAlt2
            // 
            this.txtTermsNameAlt2.Location = new System.Drawing.Point(160, 106);
            this.txtTermsNameAlt2.Name = "txtTermsNameAlt2";
            this.txtTermsNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtTermsNameAlt2.TabIndex = 4;
            // 
            // txtTermsNameAlt1
            // 
            this.txtTermsNameAlt1.Location = new System.Drawing.Point(160, 83);
            this.txtTermsNameAlt1.Name = "txtTermsNameAlt1";
            this.txtTermsNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtTermsNameAlt1.TabIndex = 3;
            // 
            // txtTermsName
            // 
            this.txtTermsName.Location = new System.Drawing.Point(160, 60);
            this.txtTermsName.Name = "txtTermsName";
            this.txtTermsName.Size = new System.Drawing.Size(130, 20);
            this.txtTermsName.TabIndex = 2;
            // 
            // lblTermsNameAlt2
            // 
            this.lblTermsNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblTermsNameAlt2.Name = "lblTermsNameAlt2";
            this.lblTermsNameAlt2.Size = new System.Drawing.Size(129, 23);
            this.lblTermsNameAlt2.TabIndex = 4;
            this.lblTermsNameAlt2.Text = "Terms Name Cht";
            // 
            // lblTermsNameAlt1
            // 
            this.lblTermsNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblTermsNameAlt1.Name = "lblTermsNameAlt1";
            this.lblTermsNameAlt1.Size = new System.Drawing.Size(129, 23);
            this.lblTermsNameAlt1.TabIndex = 3;
            this.lblTermsNameAlt1.Text = "Terms Name Chs:";
            // 
            // lblTermsName
            // 
            this.lblTermsName.Location = new System.Drawing.Point(16, 63);
            this.lblTermsName.Name = "lblTermsName";
            this.lblTermsName.Size = new System.Drawing.Size(100, 23);
            this.lblTermsName.TabIndex = 2;
            this.lblTermsName.Text = "Terms Name:";
            // 
            // txtTermsCode
            // 
            this.txtTermsCode.Location = new System.Drawing.Point(160, 37);
            this.txtTermsCode.MaxLength = 10;
            this.txtTermsCode.Name = "txtTermsCode";
            this.txtTermsCode.Size = new System.Drawing.Size(130, 20);
            this.txtTermsCode.TabIndex = 1;
            // 
            // lblTermsCode
            // 
            this.lblTermsCode.Location = new System.Drawing.Point(16, 40);
            this.lblTermsCode.Name = "lblTermsCode";
            this.lblTermsCode.Size = new System.Drawing.Size(100, 23);
            this.lblTermsCode.TabIndex = 0;
            this.lblTermsCode.Text = "Terms Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // SupplierTermsWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "SupplierTerms Wizard";
            this.Load += new System.EventHandler(this.SupplierTermsWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTermsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTermsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTermsCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colTermsName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTermsNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colTermsNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTermsNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTermsNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtTermsName;
        private Gizmox.WebGUI.Forms.Label lblTermsNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblTermsNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblTermsName;
        private Gizmox.WebGUI.Forms.TextBox txtTermsCode;
        private Gizmox.WebGUI.Forms.Label lblTermsCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentTerms;
        private Gizmox.WebGUI.Forms.Label lblParentTerms;
        private Gizmox.WebGUI.Forms.ColumnHeader colParent;
    }
}