namespace RT2020.Settings
{
    partial class SmartTag4WorkplaceWizard
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
            this.lvTagList = new Gizmox.WebGUI.Forms.ListView();
            this.colTagId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTagCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTagName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTagNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTagNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtTagNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTagNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTagName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTagNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblTagNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblTagName = new Gizmox.WebGUI.Forms.Label();
            this.txtTagCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTagCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvTagList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtTagNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtTagNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtTagName);
            this.splitContainer.Panel2.Controls.Add(this.lblTagNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblTagNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblTagName);
            this.splitContainer.Panel2.Controls.Add(this.txtTagCode);
            this.splitContainer.Panel2.Controls.Add(this.lblTagCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvTagList
            // 
            this.lvTagList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTagId,
            this.colLN,
            this.colTagCode,
            this.colTagName,
            this.colTagNameChs,
            this.colTagNameCht});
            this.lvTagList.DataMember = null;
            this.lvTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTagList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvTagList.ItemsPerPage = 20;
            this.lvTagList.Location = new System.Drawing.Point(0, 0);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(499, 506);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseInternalPaging = true;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // colTagId
            // 
            this.colTagId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTagId.Image = null;
            this.colTagId.Text = "TagId";
            this.colTagId.Visible = false;
            this.colTagId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTagCode
            // 
            this.colTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTagCode.Image = null;
            this.colTagCode.Text = "Tag Code";
            this.colTagCode.Width = 80;
            // 
            // colTagName
            // 
            this.colTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTagName.Image = null;
            this.colTagName.Text = "Tag Name";
            this.colTagName.Width = 120;
            // 
            // colTagNameChs
            // 
            this.colTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTagNameChs.Image = null;
            this.colTagNameChs.Text = "Tag Name Chs";
            this.colTagNameChs.Width = 120;
            // 
            // colTagNameCht
            // 
            this.colTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colTagNameCht.Image = null;
            this.colTagNameCht.Text = "Tag Name Cht";
            this.colTagNameCht.Width = 120;
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
            // txtTagNameCht
            // 
            this.txtTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTagNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtTagNameCht.Name = "txtTagNameCht";
            this.txtTagNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtTagNameCht.TabIndex = 4;
            // 
            // txtTagNameChs
            // 
            this.txtTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTagNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtTagNameChs.Name = "txtTagNameChs";
            this.txtTagNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtTagNameChs.TabIndex = 3;
            // 
            // txtTagName
            // 
            this.txtTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTagName.Location = new System.Drawing.Point(122, 60);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(142, 20);
            this.txtTagName.TabIndex = 2;
            // 
            // lblTagNameCht
            // 
            this.lblTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTagNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblTagNameCht.Name = "lblTagNameCht";
            this.lblTagNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblTagNameCht.TabIndex = 4;
            this.lblTagNameCht.Text = "Tag Name Cht";
            // 
            // lblTagNameChs
            // 
            this.lblTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTagNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblTagNameChs.Name = "lblTagNameChs";
            this.lblTagNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblTagNameChs.TabIndex = 3;
            this.lblTagNameChs.Text = "Tag Name Chs:";
            // 
            // lblTagName
            // 
            this.lblTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTagName.Location = new System.Drawing.Point(16, 63);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(100, 23);
            this.lblTagName.TabIndex = 2;
            this.lblTagName.Text = "Tag Name:";
            // 
            // txtTagCode
            // 
            this.txtTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTagCode.Location = new System.Drawing.Point(122, 37);
            this.txtTagCode.MaxLength = 10;
            this.txtTagCode.Name = "txtTagCode";
            this.txtTagCode.Size = new System.Drawing.Size(142, 20);
            this.txtTagCode.TabIndex = 1;
            // 
            // lblTagCode
            // 
            this.lblTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblTagCode.Location = new System.Drawing.Point(16, 40);
            this.lblTagCode.Name = "lblTagCode";
            this.lblTagCode.Size = new System.Drawing.Size(100, 23);
            this.lblTagCode.TabIndex = 0;
            this.lblTagCode.Text = "Tag Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // SmartTag4WorkplaceWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Workplace Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colTagNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtTagNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtTagNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtTagName;
        private Gizmox.WebGUI.Forms.Label lblTagNameCht;
        private Gizmox.WebGUI.Forms.Label lblTagNameChs;
        private Gizmox.WebGUI.Forms.Label lblTagName;
        private Gizmox.WebGUI.Forms.TextBox txtTagCode;
        private Gizmox.WebGUI.Forms.Label lblTagCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;


    }
}