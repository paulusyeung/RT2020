namespace RT2020.Settings
{
    partial class PhoneTagWizard
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
            this.lvPhoneList = new Gizmox.WebGUI.Forms.ListView();
            this.colPhoneId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPhoneCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPhoneName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPhoneNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPhoneNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtPhoneNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneName = new Gizmox.WebGUI.Forms.Label();
            this.txtPhoneCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvPhoneList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneName);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneName);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneCode);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvPhoneList
            // 
            this.lvPhoneList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvPhoneList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPhoneId,
            this.colLN,
            this.colPhoneCode,
            this.colPhoneName,
            this.colPhoneNameChs,
            this.colPhoneNameCht});
            this.lvPhoneList.DataMember = null;
            this.lvPhoneList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPhoneList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvPhoneList.ItemsPerPage = 20;
            this.lvPhoneList.Location = new System.Drawing.Point(0, 0);
            this.lvPhoneList.Name = "lvPhoneList";
            this.lvPhoneList.Size = new System.Drawing.Size(499, 506);
            this.lvPhoneList.TabIndex = 0;
            this.lvPhoneList.UseInternalPaging = true;
            this.lvPhoneList.SelectedIndexChanged += new System.EventHandler(this.lvPhoneList_SelectedIndexChanged);
            // 
            // colPhoneId
            // 
            this.colPhoneId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPhoneId.Image = null;
            this.colPhoneId.Text = "PhoneId";
            this.colPhoneId.Visible = false;
            this.colPhoneId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colPhoneCode
            // 
            this.colPhoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPhoneCode.Image = null;
            this.colPhoneCode.Text = "Phone Code";
            this.colPhoneCode.Width = 80;
            // 
            // colPhoneName
            // 
            this.colPhoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPhoneName.Image = null;
            this.colPhoneName.Text = "Phone Name";
            this.colPhoneName.Width = 120;
            // 
            // colPhoneNameChs
            // 
            this.colPhoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPhoneNameChs.Image = null;
            this.colPhoneNameChs.Text = "Phone Name Chs";
            this.colPhoneNameChs.Width = 120;
            // 
            // colPhoneNameCht
            // 
            this.colPhoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPhoneNameCht.Image = null;
            this.colPhoneNameCht.Text = "Phone Name Cht";
            this.colPhoneNameCht.Width = 120;
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
            // txtPhoneNameCht
            // 
            this.txtPhoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtPhoneNameCht.Name = "txtPhoneNameCht";
            this.txtPhoneNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtPhoneNameCht.TabIndex = 4;
            // 
            // txtPhoneNameChs
            // 
            this.txtPhoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtPhoneNameChs.Name = "txtPhoneNameChs";
            this.txtPhoneNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtPhoneNameChs.TabIndex = 3;
            // 
            // txtPhoneName
            // 
            this.txtPhoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneName.Location = new System.Drawing.Point(122, 60);
            this.txtPhoneName.Name = "txtPhoneName";
            this.txtPhoneName.Size = new System.Drawing.Size(142, 20);
            this.txtPhoneName.TabIndex = 2;
            // 
            // lblPhoneNameCht
            // 
            this.lblPhoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblPhoneNameCht.Name = "lblPhoneNameCht";
            this.lblPhoneNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneNameCht.TabIndex = 4;
            this.lblPhoneNameCht.Text = "Phone Name Cht";
            // 
            // lblPhoneNameChs
            // 
            this.lblPhoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblPhoneNameChs.Name = "lblPhoneNameChs";
            this.lblPhoneNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneNameChs.TabIndex = 3;
            this.lblPhoneNameChs.Text = "Phone Name Chs:";
            // 
            // lblPhoneName
            // 
            this.lblPhoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneName.Location = new System.Drawing.Point(16, 63);
            this.lblPhoneName.Name = "lblPhoneName";
            this.lblPhoneName.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneName.TabIndex = 2;
            this.lblPhoneName.Text = "Phone Name:";
            // 
            // txtPhoneCode
            // 
            this.txtPhoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPhoneCode.Location = new System.Drawing.Point(122, 37);
            this.txtPhoneCode.MaxLength = 10;
            this.txtPhoneCode.Name = "txtPhoneCode";
            this.txtPhoneCode.Size = new System.Drawing.Size(142, 20);
            this.txtPhoneCode.TabIndex = 1;
            // 
            // lblPhoneCode
            // 
            this.lblPhoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPhoneCode.Location = new System.Drawing.Point(16, 40);
            this.lblPhoneCode.Name = "lblPhoneCode";
            this.lblPhoneCode.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneCode.TabIndex = 0;
            this.lblPhoneCode.Text = "Phone Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // PhoneTagWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberPhone Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvPhoneList;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneName;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneName;
        private Gizmox.WebGUI.Forms.Label lblPhoneNameCht;
        private Gizmox.WebGUI.Forms.Label lblPhoneNameChs;
        private Gizmox.WebGUI.Forms.Label lblPhoneName;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneCode;
        private Gizmox.WebGUI.Forms.Label lblPhoneCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;


    }
}