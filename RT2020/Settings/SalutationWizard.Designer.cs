namespace RT2020.Settings
{
    partial class SalutationWizard
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
            this.lvSalutationList = new Gizmox.WebGUI.Forms.ListView();
            this.colSalutationId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSalutationCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSalutationName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSalutationNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSalutationNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentSalutation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentSalutation = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtSalutationNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSalutationNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSalutationName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSalutationNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblSalutationNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblSalutationName = new Gizmox.WebGUI.Forms.Label();
            this.txtSalutationCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSalutationCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.colParent = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
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
            this.splitContainer.Panel1.Controls.Add(this.lvSalutationList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentSalutation);
            this.splitContainer.Panel2.Controls.Add(this.lblParentSalutation);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationName);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationName);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationCode);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvSalutationList
            // 
            this.lvSalutationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colSalutationId,
            this.colLN,
            this.colSalutationCode,
            this.colSalutationName,
            this.colSalutationNameAlt1,
            this.colSalutationNameAlt2,
            this.colParent});
            this.lvSalutationList.DataMember = null;
            this.lvSalutationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvSalutationList.Location = new System.Drawing.Point(0, 0);
            this.lvSalutationList.Name = "lvSalutationList";
            this.lvSalutationList.Size = new System.Drawing.Size(499, 506);
            this.lvSalutationList.TabIndex = 0;
            this.lvSalutationList.UseInternalPaging = true;
            this.lvSalutationList.SelectedIndexChanged += new System.EventHandler(this.lvSalutationList_SelectedIndexChanged);
            // 
            // colSalutationId
            // 
            this.colSalutationId.Text = "SalutationId";
            this.colSalutationId.Visible = false;
            this.colSalutationId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colSalutationCode
            // 
            this.colSalutationCode.Text = "Code";
            this.colSalutationCode.Width = 80;
            // 
            // colSalutationName
            // 
            this.colSalutationName.Text = "Name";
            this.colSalutationName.Width = 120;
            // 
            // colSalutationNameAlt1
            // 
            this.colSalutationNameAlt1.Text = "Name Chs";
            this.colSalutationNameAlt1.Width = 120;
            // 
            // colSalutationNameAlt2
            // 
            this.colSalutationNameAlt2.Text = "Name Cht";
            this.colSalutationNameAlt2.Width = 120;
            // 
            // cboParentSalutation
            // 
            this.cboParentSalutation.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentSalutation.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentSalutation.DropDownWidth = 142;
            this.cboParentSalutation.Location = new System.Drawing.Point(152, 129);
            this.cboParentSalutation.Name = "cboParentSalutation";
            this.cboParentSalutation.Size = new System.Drawing.Size(135, 21);
            this.cboParentSalutation.TabIndex = 5;
            // 
            // lblParentSalutation
            // 
            this.lblParentSalutation.Location = new System.Drawing.Point(16, 132);
            this.lblParentSalutation.Name = "lblParentSalutation";
            this.lblParentSalutation.Size = new System.Drawing.Size(100, 23);
            this.lblParentSalutation.TabIndex = 9;
            this.lblParentSalutation.Text = "Attached To:";
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
            // txtSalutationNameAlt2
            // 
            this.txtSalutationNameAlt2.Location = new System.Drawing.Point(152, 106);
            this.txtSalutationNameAlt2.Name = "txtSalutationNameAlt2";
            this.txtSalutationNameAlt2.Size = new System.Drawing.Size(135, 20);
            this.txtSalutationNameAlt2.TabIndex = 4;
            // 
            // txtSalutationNameAlt1
            // 
            this.txtSalutationNameAlt1.Location = new System.Drawing.Point(152, 83);
            this.txtSalutationNameAlt1.Name = "txtSalutationNameAlt1";
            this.txtSalutationNameAlt1.Size = new System.Drawing.Size(135, 20);
            this.txtSalutationNameAlt1.TabIndex = 3;
            // 
            // txtSalutationName
            // 
            this.txtSalutationName.Location = new System.Drawing.Point(152, 60);
            this.txtSalutationName.Name = "txtSalutationName";
            this.txtSalutationName.Size = new System.Drawing.Size(135, 20);
            this.txtSalutationName.TabIndex = 2;
            // 
            // lblSalutationNameAlt2
            // 
            this.lblSalutationNameAlt2.Location = new System.Drawing.Point(29, 109);
            this.lblSalutationNameAlt2.Name = "lblSalutationNameAlt2";
            this.lblSalutationNameAlt2.Size = new System.Drawing.Size(120, 23);
            this.lblSalutationNameAlt2.TabIndex = 4;
            this.lblSalutationNameAlt2.Text = "Name Cht";
            // 
            // lblSalutationNameAlt1
            // 
            this.lblSalutationNameAlt1.Location = new System.Drawing.Point(29, 86);
            this.lblSalutationNameAlt1.Name = "lblSalutationNameAlt1";
            this.lblSalutationNameAlt1.Size = new System.Drawing.Size(120, 23);
            this.lblSalutationNameAlt1.TabIndex = 3;
            this.lblSalutationNameAlt1.Text = "Name Chs:";
            // 
            // lblSalutationName
            // 
            this.lblSalutationName.Location = new System.Drawing.Point(16, 63);
            this.lblSalutationName.Name = "lblSalutationName";
            this.lblSalutationName.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationName.TabIndex = 2;
            this.lblSalutationName.Text = "Name:";
            // 
            // txtSalutationCode
            // 
            this.txtSalutationCode.Location = new System.Drawing.Point(152, 37);
            this.txtSalutationCode.MaxLength = 10;
            this.txtSalutationCode.Name = "txtSalutationCode";
            this.txtSalutationCode.Size = new System.Drawing.Size(135, 20);
            this.txtSalutationCode.TabIndex = 1;
            // 
            // lblSalutationCode
            // 
            this.lblSalutationCode.Location = new System.Drawing.Point(16, 40);
            this.lblSalutationCode.Name = "lblSalutationCode";
            this.lblSalutationCode.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationCode.TabIndex = 0;
            this.lblSalutationCode.Text = "Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // colParent
            // 
            this.colParent.Text = "Parent";
            this.colParent.Width = 100;
            // 
            // SalutationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Salutation Wizard";
            this.Load += new System.EventHandler(this.SalutationWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvSalutationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationName;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationName;
        private Gizmox.WebGUI.Forms.Label lblSalutationNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblSalutationNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblSalutationName;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationCode;
        private Gizmox.WebGUI.Forms.Label lblSalutationCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentSalutation;
        private Gizmox.WebGUI.Forms.Label lblParentSalutation;
        private Gizmox.WebGUI.Forms.ColumnHeader colParent;
    }
}