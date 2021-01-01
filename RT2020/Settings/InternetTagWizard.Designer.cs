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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvInternetTagList = new Gizmox.WebGUI.Forms.ListView();
            this.colInternetTagId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInternetTagCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPriority = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInternetTagName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInternetTagNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInternetTagNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtInternetTagNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInternetTagNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInternetTagName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInternetTagNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblInternetTagNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblInternetTagName = new Gizmox.WebGUI.Forms.Label();
            this.txtInternetTagCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblInternetTagCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvInternetTagList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagName);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagName);
            this.splitContainer.Panel2.Controls.Add(this.txtInternetTagCode);
            this.splitContainer.Panel2.Controls.Add(this.lblInternetTagCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // lvInternetTagList
            // 
            this.lvInternetTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colInternetTagId,
            this.colLN,
            this.colInternetTagCode,
            this.colPriority,
            this.colInternetTagName,
            this.colInternetTagNameAlt1,
            this.colInternetTagNameAlt2});
            this.lvInternetTagList.DataMember = null;
            this.lvInternetTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvInternetTagList.Location = new System.Drawing.Point(0, 0);
            this.lvInternetTagList.Name = "lvInternetTagList";
            this.lvInternetTagList.Size = new System.Drawing.Size(499, 506);
            this.lvInternetTagList.TabIndex = 0;
            this.lvInternetTagList.UseInternalPaging = true;
            this.lvInternetTagList.SelectedIndexChanged += new System.EventHandler(this.lvInternetTagList_SelectedIndexChanged);
            this.lvInternetTagList.ColumnClick += new Gizmox.WebGUI.Forms.ColumnClickEventHandler(this.lvInternetTagList_ColumnClick);
            // 
            // colInternetTagId
            // 
            this.colInternetTagId.Text = "InternetTagId";
            this.colInternetTagId.Visible = false;
            this.colInternetTagId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colInternetTagCode
            // 
            this.colInternetTagCode.Text = "Tag Code";
            this.colInternetTagCode.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.Tag = "Numeric";
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 60;
            // 
            // colInternetTagName
            // 
            this.colInternetTagName.Text = "Tag Name";
            this.colInternetTagName.Width = 120;
            // 
            // colInternetTagNameAlt1
            // 
            this.colInternetTagNameAlt1.Text = "Tag Name Chs";
            this.colInternetTagNameAlt1.Width = 120;
            // 
            // colInternetTagNameAlt2
            // 
            this.colInternetTagNameAlt2.Text = "Tag Name Cht";
            this.colInternetTagNameAlt2.Width = 120;
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
            this.lblPriority.Size = new System.Drawing.Size(147, 23);
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
            this.tbWizardAction.Size = new System.Drawing.Size(304, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtInternetTagNameAlt2
            // 
            this.txtInternetTagNameAlt2.Location = new System.Drawing.Point(166, 106);
            this.txtInternetTagNameAlt2.Name = "txtInternetTagNameAlt2";
            this.txtInternetTagNameAlt2.Size = new System.Drawing.Size(124, 20);
            this.txtInternetTagNameAlt2.TabIndex = 4;
            // 
            // txtInternetTagNameAlt1
            // 
            this.txtInternetTagNameAlt1.Location = new System.Drawing.Point(166, 83);
            this.txtInternetTagNameAlt1.Name = "txtInternetTagNameAlt1";
            this.txtInternetTagNameAlt1.Size = new System.Drawing.Size(124, 20);
            this.txtInternetTagNameAlt1.TabIndex = 3;
            // 
            // txtInternetTagName
            // 
            this.txtInternetTagName.Location = new System.Drawing.Point(166, 60);
            this.txtInternetTagName.Name = "txtInternetTagName";
            this.txtInternetTagName.Size = new System.Drawing.Size(124, 20);
            this.txtInternetTagName.TabIndex = 2;
            // 
            // lblInternetTagNameAlt2
            // 
            this.lblInternetTagNameAlt2.Location = new System.Drawing.Point(29, 109);
            this.lblInternetTagNameAlt2.Name = "lblInternetTagNameAlt2";
            this.lblInternetTagNameAlt2.Size = new System.Drawing.Size(134, 23);
            this.lblInternetTagNameAlt2.TabIndex = 4;
            this.lblInternetTagNameAlt2.Text = "Tag Name Cht";
            // 
            // lblInternetTagNameAlt1
            // 
            this.lblInternetTagNameAlt1.Location = new System.Drawing.Point(29, 86);
            this.lblInternetTagNameAlt1.Name = "lblInternetTagNameAlt1";
            this.lblInternetTagNameAlt1.Size = new System.Drawing.Size(134, 23);
            this.lblInternetTagNameAlt1.TabIndex = 3;
            this.lblInternetTagNameAlt1.Text = "Tag Name Chs:";
            // 
            // lblInternetTagName
            // 
            this.lblInternetTagName.Location = new System.Drawing.Point(16, 63);
            this.lblInternetTagName.Name = "lblInternetTagName";
            this.lblInternetTagName.Size = new System.Drawing.Size(147, 23);
            this.lblInternetTagName.TabIndex = 2;
            this.lblInternetTagName.Text = "Tag Name:";
            // 
            // txtInternetTagCode
            // 
            this.txtInternetTagCode.Location = new System.Drawing.Point(166, 37);
            this.txtInternetTagCode.MaxLength = 10;
            this.txtInternetTagCode.Name = "txtInternetTagCode";
            this.txtInternetTagCode.Size = new System.Drawing.Size(124, 20);
            this.txtInternetTagCode.TabIndex = 1;
            // 
            // lblInternetTagCode
            // 
            this.lblInternetTagCode.Location = new System.Drawing.Point(16, 40);
            this.lblInternetTagCode.Name = "lblInternetTagCode";
            this.lblInternetTagCode.Size = new System.Drawing.Size(147, 23);
            this.lblInternetTagCode.TabIndex = 0;
            this.lblInternetTagCode.Text = "Tag Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // InternetTagWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "InternetTag Wizard";
            this.Load += new System.EventHandler(this.InternetTagWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvInternetTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagName;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colInternetTagNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagName;
        private Gizmox.WebGUI.Forms.Label lblInternetTagNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblInternetTagNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblInternetTagName;
        private Gizmox.WebGUI.Forms.TextBox txtInternetTagCode;
        private Gizmox.WebGUI.Forms.Label lblInternetTagCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.ColumnHeader colPriority;
    }
}