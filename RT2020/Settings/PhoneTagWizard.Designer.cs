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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvPhoneList = new Gizmox.WebGUI.Forms.ListView();
            this.colPhoneId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPhoneCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPhoneName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPhoneNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPhoneNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colPriority = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtPhoneNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPhoneName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblPhoneName = new Gizmox.WebGUI.Forms.Label();
            this.txtPhoneCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPhoneCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvPhoneList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneName);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneName);
            this.splitContainer.Panel2.Controls.Add(this.txtPhoneCode);
            this.splitContainer.Panel2.Controls.Add(this.lblPhoneCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvPhoneList
            // 
            this.lvPhoneList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPhoneId,
            this.colLN,
            this.colPhoneCode,
            this.colPriority,
            this.colPhoneName,
            this.colPhoneNameAlt1,
            this.colPhoneNameAlt2});
            this.lvPhoneList.DataMember = null;
            this.lvPhoneList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPhoneList.Location = new System.Drawing.Point(0, 0);
            this.lvPhoneList.Name = "lvPhoneList";
            this.lvPhoneList.Size = new System.Drawing.Size(499, 506);
            this.lvPhoneList.TabIndex = 0;
            this.lvPhoneList.UseInternalPaging = true;
            this.lvPhoneList.SelectedIndexChanged += new System.EventHandler(this.lvPhoneList_SelectedIndexChanged);
            this.lvPhoneList.ColumnClick += new Gizmox.WebGUI.Forms.ColumnClickEventHandler(this.lvPhoneList_ColumnClick);
            // 
            // colPhoneId
            // 
            this.colPhoneId.Text = "PhoneId";
            this.colPhoneId.Visible = false;
            this.colPhoneId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colPhoneCode
            // 
            this.colPhoneCode.Text = "Phone Code";
            this.colPhoneCode.Width = 80;
            // 
            // colPhoneName
            // 
            this.colPhoneName.Text = "Phone Name";
            this.colPhoneName.Width = 120;
            // 
            // colPhoneNameAlt1
            // 
            this.colPhoneNameAlt1.Text = "Phone Name Chs";
            this.colPhoneNameAlt1.Width = 120;
            // 
            // colPhoneNameAlt2
            // 
            this.colPhoneNameAlt2.Text = "Phone Name Cht";
            this.colPhoneNameAlt2.Width = 120;
            // 
            // colPriority
            // 
            this.colPriority.Tag = "Numeric";
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 60;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(159, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(131, 20);
            this.txtPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(16, 132);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(140, 23);
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
            this.tbWizardAction.Size = new System.Drawing.Size(302, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtPhoneNameAlt2
            // 
            this.txtPhoneNameAlt2.Location = new System.Drawing.Point(159, 106);
            this.txtPhoneNameAlt2.Name = "txtPhoneNameAlt2";
            this.txtPhoneNameAlt2.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneNameAlt2.TabIndex = 4;
            // 
            // txtPhoneNameAlt1
            // 
            this.txtPhoneNameAlt1.Location = new System.Drawing.Point(159, 83);
            this.txtPhoneNameAlt1.Name = "txtPhoneNameAlt1";
            this.txtPhoneNameAlt1.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneNameAlt1.TabIndex = 3;
            // 
            // txtPhoneName
            // 
            this.txtPhoneName.Location = new System.Drawing.Point(159, 60);
            this.txtPhoneName.Name = "txtPhoneName";
            this.txtPhoneName.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneName.TabIndex = 2;
            // 
            // lblPhoneNameAlt2
            // 
            this.lblPhoneNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblPhoneNameAlt2.Name = "lblPhoneNameAlt2";
            this.lblPhoneNameAlt2.Size = new System.Drawing.Size(128, 23);
            this.lblPhoneNameAlt2.TabIndex = 4;
            this.lblPhoneNameAlt2.Text = "Phone Name Cht";
            // 
            // lblPhoneNameAlt1
            // 
            this.lblPhoneNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblPhoneNameAlt1.Name = "lblPhoneNameAlt1";
            this.lblPhoneNameAlt1.Size = new System.Drawing.Size(128, 23);
            this.lblPhoneNameAlt1.TabIndex = 3;
            this.lblPhoneNameAlt1.Text = "Phone Name Chs:";
            // 
            // lblPhoneName
            // 
            this.lblPhoneName.Location = new System.Drawing.Point(16, 63);
            this.lblPhoneName.Name = "lblPhoneName";
            this.lblPhoneName.Size = new System.Drawing.Size(140, 23);
            this.lblPhoneName.TabIndex = 2;
            this.lblPhoneName.Text = "Phone Name:";
            // 
            // txtPhoneCode
            // 
            this.txtPhoneCode.Location = new System.Drawing.Point(159, 37);
            this.txtPhoneCode.MaxLength = 10;
            this.txtPhoneCode.Name = "txtPhoneCode";
            this.txtPhoneCode.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneCode.TabIndex = 1;
            // 
            // lblPhoneCode
            // 
            this.lblPhoneCode.Location = new System.Drawing.Point(16, 40);
            this.lblPhoneCode.Name = "lblPhoneCode";
            this.lblPhoneCode.Size = new System.Drawing.Size(140, 23);
            this.lblPhoneCode.TabIndex = 0;
            this.lblPhoneCode.Text = "Phone Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // PhoneTagWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "MemberPhone Wizard";
            this.Load += new System.EventHandler(this.PhoneTagWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvPhoneList;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneName;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colPhoneNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneName;
        private Gizmox.WebGUI.Forms.Label lblPhoneNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblPhoneNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblPhoneName;
        private Gizmox.WebGUI.Forms.TextBox txtPhoneCode;
        private Gizmox.WebGUI.Forms.Label lblPhoneCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.ColumnHeader colPriority;
    }
}