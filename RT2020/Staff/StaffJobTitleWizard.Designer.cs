namespace RT2020.Staff
{
    partial class StaffJobTitleWizard
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
            this.lvJobTitleList = new Gizmox.WebGUI.Forms.ListView();
            this.colJobTitleId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colJobTitleCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colJobTitleName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colJobTitleNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colJobTitleNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtJobTitleNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtJobTitleNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtJobTitleName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblJobTitleNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblJobTitleNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblJobTitleName = new Gizmox.WebGUI.Forms.Label();
            this.txtJobTitleCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblJobTitleCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvJobTitleList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleName);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleName);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleCode);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvJobTitleList
            // 
            this.lvJobTitleList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvJobTitleList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colJobTitleId,
            this.colLN,
            this.colJobTitleCode,
            this.colJobTitleName,
            this.colJobTitleNameChs,
            this.colJobTitleNameCht});
            this.lvJobTitleList.DataMember = null;
            this.lvJobTitleList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvJobTitleList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvJobTitleList.ItemsPerPage = 20;
            this.lvJobTitleList.Location = new System.Drawing.Point(0, 0);
            this.lvJobTitleList.Name = "lvJobTitleList";
            this.lvJobTitleList.Size = new System.Drawing.Size(499, 506);
            this.lvJobTitleList.TabIndex = 0;
            this.lvJobTitleList.UseInternalPaging = true;
            this.lvJobTitleList.SelectedIndexChanged += new System.EventHandler(this.lvJobTitleList_SelectedIndexChanged);
            // 
            // colJobTitleId
            // 
            this.colJobTitleId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colJobTitleId.Image = null;
            this.colJobTitleId.Text = "JobTitleId";
            this.colJobTitleId.Visible = false;
            this.colJobTitleId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colJobTitleCode
            // 
            this.colJobTitleCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colJobTitleCode.Image = null;
            this.colJobTitleCode.Text = "JobTitle Code";
            this.colJobTitleCode.Width = 80;
            // 
            // colJobTitleName
            // 
            this.colJobTitleName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colJobTitleName.Image = null;
            this.colJobTitleName.Text = "JobTitle Name";
            this.colJobTitleName.Width = 120;
            // 
            // colJobTitleNameChs
            // 
            this.colJobTitleNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colJobTitleNameChs.Image = null;
            this.colJobTitleNameChs.Text = "JobTitle Name Chs";
            this.colJobTitleNameChs.Width = 120;
            // 
            // colJobTitleNameCht
            // 
            this.colJobTitleNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colJobTitleNameCht.Image = null;
            this.colJobTitleNameCht.Text = "JobTitle Name Cht";
            this.colJobTitleNameCht.Width = 120;
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
            // txtJobTitleNameCht
            // 
            this.txtJobTitleNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtJobTitleNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtJobTitleNameCht.Name = "txtJobTitleNameCht";
            this.txtJobTitleNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtJobTitleNameCht.TabIndex = 4;
            // 
            // txtJobTitleNameChs
            // 
            this.txtJobTitleNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtJobTitleNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtJobTitleNameChs.Name = "txtJobTitleNameChs";
            this.txtJobTitleNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtJobTitleNameChs.TabIndex = 3;
            // 
            // txtJobTitleName
            // 
            this.txtJobTitleName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtJobTitleName.Location = new System.Drawing.Point(122, 60);
            this.txtJobTitleName.Name = "txtJobTitleName";
            this.txtJobTitleName.Size = new System.Drawing.Size(142, 20);
            this.txtJobTitleName.TabIndex = 2;
            // 
            // lblJobTitleNameCht
            // 
            this.lblJobTitleNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblJobTitleNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblJobTitleNameCht.Name = "lblJobTitleNameCht";
            this.lblJobTitleNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblJobTitleNameCht.TabIndex = 4;
            this.lblJobTitleNameCht.Text = "JobTitle Name Cht";
            // 
            // lblJobTitleNameChs
            // 
            this.lblJobTitleNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblJobTitleNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblJobTitleNameChs.Name = "lblJobTitleNameChs";
            this.lblJobTitleNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblJobTitleNameChs.TabIndex = 3;
            this.lblJobTitleNameChs.Text = "JobTitle Name Chs:";
            // 
            // lblJobTitleName
            // 
            this.lblJobTitleName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblJobTitleName.Location = new System.Drawing.Point(16, 63);
            this.lblJobTitleName.Name = "lblJobTitleName";
            this.lblJobTitleName.Size = new System.Drawing.Size(100, 23);
            this.lblJobTitleName.TabIndex = 2;
            this.lblJobTitleName.Text = "JobTitle Name:";
            // 
            // txtJobTitleCode
            // 
            this.txtJobTitleCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtJobTitleCode.Location = new System.Drawing.Point(122, 37);
            this.txtJobTitleCode.MaxLength = 10;
            this.txtJobTitleCode.Name = "txtJobTitleCode";
            this.txtJobTitleCode.Size = new System.Drawing.Size(142, 20);
            this.txtJobTitleCode.TabIndex = 1;
            // 
            // lblJobTitleCode
            // 
            this.lblJobTitleCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblJobTitleCode.Location = new System.Drawing.Point(16, 40);
            this.lblJobTitleCode.Name = "lblJobTitleCode";
            this.lblJobTitleCode.Size = new System.Drawing.Size(100, 23);
            this.lblJobTitleCode.TabIndex = 0;
            this.lblJobTitleCode.Text = "JobTitle Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // StaffJobTitleWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "JobTitle Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvJobTitleList;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleName;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleName;
        private Gizmox.WebGUI.Forms.Label lblJobTitleNameCht;
        private Gizmox.WebGUI.Forms.Label lblJobTitleNameChs;
        private Gizmox.WebGUI.Forms.Label lblJobTitleName;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleCode;
        private Gizmox.WebGUI.Forms.Label lblJobTitleCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}