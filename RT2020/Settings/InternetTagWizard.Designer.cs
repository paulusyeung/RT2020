namespace RT2020.Settings
{
    partial class InternetTagWizard
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
            this.lvInternetTagList = new Gizmox.WebGUI.Forms.ListView();
            this.colInternetTagId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colInternetTagCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colInternetTagName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colInternetTagNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colInternetTagNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtInternetTagNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInternetTagNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInternetTagName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInternetTagNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblInternetTagNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblInternetTagName = new Gizmox.WebGUI.Forms.Label();
            this.txtInternetTagCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInternetTagCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvInternetTagList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagName);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagName);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagCode);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvInternetTagList
            // 
            this.lvInternetTagList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvInternetTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colInternetTagId,
            this.colLN,
            this.colInternetTagCode,
            this.colInternetTagName,
            this.colInternetTagNameChs,
            this.colInternetTagNameCht});
            this.lvInternetTagList.DataMember = null;
            this.lvInternetTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvInternetTagList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvInternetTagList.ItemsPerPage = 20;
            this.lvInternetTagList.Location = new System.Drawing.Point(0, 0);
            this.lvInternetTagList.Name = "lvInternetTagList";
            this.lvInternetTagList.Size = new System.Drawing.Size(499, 506);
            this.lvInternetTagList.TabIndex = 0;
            this.lvInternetTagList.UseInternalPaging = true;
            this.lvInternetTagList.SelectedIndexChanged += new System.EventHandler(this.lvInternetTagList_SelectedIndexChanged);
            // 
            // colInternetTagId
            // 
            this.colInternetTagId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colInternetTagId.Image = null;
            this.colInternetTagId.Text = "InternetTagId";
            this.colInternetTagId.Visible = false;
            this.colInternetTagId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colInternetTagCode
            // 
            this.colInternetTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colInternetTagCode.Image = null;
            this.colInternetTagCode.Text = "Tag Code";
            this.colInternetTagCode.Width = 80;
            // 
            // colInternetTagName
            // 
            this.colInternetTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colInternetTagName.Image = null;
            this.colInternetTagName.Text = "Tag Name";
            this.colInternetTagName.Width = 120;
            // 
            // colInternetTagNameChs
            // 
            this.colInternetTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colInternetTagNameChs.Image = null;
            this.colInternetTagNameChs.Text = "Tag Name Chs";
            this.colInternetTagNameChs.Width = 120;
            // 
            // colInternetTagNameCht
            // 
            this.colInternetTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colInternetTagNameCht.Image = null;
            this.colInternetTagNameCht.Text = "Tag Name Cht";
            this.colInternetTagNameCht.Width = 120;
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
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtInternetTagNameCht
            // 
            this.txtInternetTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtInternetTagNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtInternetTagNameCht.Name = "txtInternetTagNameCht";
            this.txtInternetTagNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtInternetTagNameCht.TabIndex = 4;
            // 
            // txtInternetTagNameChs
            // 
            this.txtInternetTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtInternetTagNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtInternetTagNameChs.Name = "txtInternetTagNameChs";
            this.txtInternetTagNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtInternetTagNameChs.TabIndex = 3;
            // 
            // txtInternetTagName
            // 
            this.txtInternetTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtInternetTagName.Location = new System.Drawing.Point(122, 60);
            this.txtInternetTagName.Name = "txtInternetTagName";
            this.txtInternetTagName.Size = new System.Drawing.Size(142, 20);
            this.txtInternetTagName.TabIndex = 2;
            // 
            // lblInternetTagNameCht
            // 
            this.lblInternetTagNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblInternetTagNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblInternetTagNameCht.Name = "lblInternetTagNameCht";
            this.lblInternetTagNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblInternetTagNameCht.TabIndex = 4;
            this.lblInternetTagNameCht.Text = "Tag Name Cht";
            // 
            // lblInternetTagNameChs
            // 
            this.lblInternetTagNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblInternetTagNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblInternetTagNameChs.Name = "lblInternetTagNameChs";
            this.lblInternetTagNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblInternetTagNameChs.TabIndex = 3;
            this.lblInternetTagNameChs.Text = "Tag Name Chs:";
            // 
            // lblInternetTagName
            // 
            this.lblInternetTagName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblInternetTagName.Location = new System.Drawing.Point(16, 63);
            this.lblInternetTagName.Name = "lblInternetTagName";
            this.lblInternetTagName.Size = new System.Drawing.Size(100, 23);
            this.lblInternetTagName.TabIndex = 2;
            this.lblInternetTagName.Text = "Tag Name:";
            // 
            // txtInternetTagCode
            // 
            this.txtInternetTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtInternetTagCode.Location = new System.Drawing.Point(122, 37);
            this.txtInternetTagCode.MaxLength = 10;
            this.txtInternetTagCode.Name = "txtInternetTagCode";
            this.txtInternetTagCode.Size = new System.Drawing.Size(142, 20);
            this.txtInternetTagCode.TabIndex = 1;
            // 
            // lblInternetTagCode
            // 
            this.lblInternetTagCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblInternetTagCode.Location = new System.Drawing.Point(16, 40);
            this.lblInternetTagCode.Name = "lblInternetTagCode";
            this.lblInternetTagCode.Size = new System.Drawing.Size(100, 23);
            this.lblInternetTagCode.TabIndex = 0;
            this.lblInternetTagCode.Text = "Tag Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // InternetTagWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "InternetTag Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvInternetTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagName;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagName;
        private Gizmox.WebGUI.Forms.Label lblInternetTagNameCht;
        private Gizmox.WebGUI.Forms.Label lblInternetTagNameChs;
        private Gizmox.WebGUI.Forms.Label lblInternetTagName;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagCode;
        private Gizmox.WebGUI.Forms.Label lblInternetTagCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;


    }
}