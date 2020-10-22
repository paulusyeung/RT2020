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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvSalutationList = new Gizmox.WebGUI.Forms.ListView();
            this.colSalutationId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSalutationCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSalutationName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSalutationNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSalutationNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentSalutation = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentSalutation = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtSalutationNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSalutationNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSalutationName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSalutationNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblSalutationNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblSalutationName = new Gizmox.WebGUI.Forms.Label();
            this.txtSalutationCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSalutationCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvSalutationList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentSalutation);
            this.splitContainer.Panel2.Controls.Add(this.lblParentSalutation);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationName);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationName);
            this.splitContainer.Panel2.Controls.Add(this.txtSalutationCode);
            this.splitContainer.Panel2.Controls.Add(this.lblSalutationCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvSalutationList
            // 
            this.lvSalutationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvSalutationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colSalutationId,
            this.colLN,
            this.colSalutationCode,
            this.colSalutationName,
            this.colSalutationNameChs,
            this.colSalutationNameCht});
            this.lvSalutationList.DataMember = null;
            this.lvSalutationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvSalutationList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvSalutationList.ItemsPerPage = 20;
            this.lvSalutationList.Location = new System.Drawing.Point(0, 0);
            this.lvSalutationList.Name = "lvSalutationList";
            this.lvSalutationList.Size = new System.Drawing.Size(499, 506);
            this.lvSalutationList.TabIndex = 0;
            this.lvSalutationList.UseInternalPaging = true;
            this.lvSalutationList.SelectedIndexChanged += new System.EventHandler(this.lvSalutationList_SelectedIndexChanged);
            // 
            // colSalutationId
            // 
            this.colSalutationId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSalutationId.Image = null;
            this.colSalutationId.Text = "SalutationId";
            this.colSalutationId.Visible = false;
            this.colSalutationId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colSalutationCode
            // 
            this.colSalutationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSalutationCode.Image = null;
            this.colSalutationCode.Text = "Code";
            this.colSalutationCode.Width = 80;
            // 
            // colSalutationName
            // 
            this.colSalutationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSalutationName.Image = null;
            this.colSalutationName.Text = "Name";
            this.colSalutationName.Width = 120;
            // 
            // colSalutationNameChs
            // 
            this.colSalutationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSalutationNameChs.Image = null;
            this.colSalutationNameChs.Text = "Name Chs";
            this.colSalutationNameChs.Width = 120;
            // 
            // colSalutationNameCht
            // 
            this.colSalutationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colSalutationNameCht.Image = null;
            this.colSalutationNameCht.Text = "Name Cht";
            this.colSalutationNameCht.Width = 120;
            // 
            // cboParentSalutation
            // 
            this.cboParentSalutation.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentSalutation.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentSalutation.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentSalutation.DropDownWidth = 142;
            this.cboParentSalutation.Location = new System.Drawing.Point(122, 129);
            this.cboParentSalutation.Name = "cboParentSalutation";
            this.cboParentSalutation.Size = new System.Drawing.Size(142, 21);
            this.cboParentSalutation.TabIndex = 5;
            // 
            // lblParentSalutation
            // 
            this.lblParentSalutation.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentSalutation.Location = new System.Drawing.Point(16, 132);
            this.lblParentSalutation.Name = "lblParentSalutation";
            this.lblParentSalutation.Size = new System.Drawing.Size(100, 23);
            this.lblParentSalutation.TabIndex = 9;
            this.lblParentSalutation.Text = "Attached To:";
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
            // txtSalutationNameCht
            // 
            this.txtSalutationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSalutationNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtSalutationNameCht.Name = "txtSalutationNameCht";
            this.txtSalutationNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtSalutationNameCht.TabIndex = 4;
            // 
            // txtSalutationNameChs
            // 
            this.txtSalutationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSalutationNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtSalutationNameChs.Name = "txtSalutationNameChs";
            this.txtSalutationNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtSalutationNameChs.TabIndex = 3;
            // 
            // txtSalutationName
            // 
            this.txtSalutationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSalutationName.Location = new System.Drawing.Point(122, 60);
            this.txtSalutationName.Name = "txtSalutationName";
            this.txtSalutationName.Size = new System.Drawing.Size(142, 20);
            this.txtSalutationName.TabIndex = 2;
            // 
            // lblSalutationNameCht
            // 
            this.lblSalutationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSalutationNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblSalutationNameCht.Name = "lblSalutationNameCht";
            this.lblSalutationNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationNameCht.TabIndex = 4;
            this.lblSalutationNameCht.Text = "Name Cht";
            // 
            // lblSalutationNameChs
            // 
            this.lblSalutationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSalutationNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblSalutationNameChs.Name = "lblSalutationNameChs";
            this.lblSalutationNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationNameChs.TabIndex = 3;
            this.lblSalutationNameChs.Text = "Name Chs:";
            // 
            // lblSalutationName
            // 
            this.lblSalutationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSalutationName.Location = new System.Drawing.Point(16, 63);
            this.lblSalutationName.Name = "lblSalutationName";
            this.lblSalutationName.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationName.TabIndex = 2;
            this.lblSalutationName.Text = "Name:";
            // 
            // txtSalutationCode
            // 
            this.txtSalutationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSalutationCode.Location = new System.Drawing.Point(122, 37);
            this.txtSalutationCode.MaxLength = 10;
            this.txtSalutationCode.Name = "txtSalutationCode";
            this.txtSalutationCode.Size = new System.Drawing.Size(142, 20);
            this.txtSalutationCode.TabIndex = 1;
            // 
            // lblSalutationCode
            // 
            this.lblSalutationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblSalutationCode.Location = new System.Drawing.Point(16, 40);
            this.lblSalutationCode.Name = "lblSalutationCode";
            this.lblSalutationCode.Size = new System.Drawing.Size(100, 23);
            this.lblSalutationCode.TabIndex = 0;
            this.lblSalutationCode.Text = "Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // SalutationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Salutation Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvSalutationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationName;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colSalutationNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationName;
        private Gizmox.WebGUI.Forms.Label lblSalutationNameCht;
        private Gizmox.WebGUI.Forms.Label lblSalutationNameChs;
        private Gizmox.WebGUI.Forms.Label lblSalutationName;
        private Gizmox.WebGUI.Forms.TextBox txtSalutationCode;
        private Gizmox.WebGUI.Forms.Label lblSalutationCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentSalutation;
        private Gizmox.WebGUI.Forms.Label lblParentSalutation;


    }
}