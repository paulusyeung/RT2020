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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvJobTitleList = new Gizmox.WebGUI.Forms.ListView();
            this.colJobTitleId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colJobTitleCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colJobTitleName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colJobTitleNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colJobTitleNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtJobTitleNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtJobTitleNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtJobTitleName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblJobTitleNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblJobTitleNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblJobTitleName = new Gizmox.WebGUI.Forms.Label();
            this.txtJobTitleCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblJobTitleCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvJobTitleList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleName);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleName);
            this.splitContainer.Panel2.Controls.Add(this.txtJobTitleCode);
            this.splitContainer.Panel2.Controls.Add(this.lblJobTitleCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvJobTitleList
            // 
            this.lvJobTitleList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colJobTitleId,
            this.colLN,
            this.colJobTitleCode,
            this.colJobTitleName,
            this.colJobTitleNameAlt1,
            this.colJobTitleNameAlt2});
            this.lvJobTitleList.DataMember = null;
            this.lvJobTitleList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvJobTitleList.Location = new System.Drawing.Point(0, 0);
            this.lvJobTitleList.Name = "lvJobTitleList";
            this.lvJobTitleList.Size = new System.Drawing.Size(499, 506);
            this.lvJobTitleList.TabIndex = 0;
            this.lvJobTitleList.UseInternalPaging = true;
            this.lvJobTitleList.SelectedIndexChanged += new System.EventHandler(this.lvJobTitleList_SelectedIndexChanged);
            // 
            // colJobTitleId
            // 
            this.colJobTitleId.Text = "JobTitleId";
            this.colJobTitleId.Visible = false;
            this.colJobTitleId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colJobTitleCode
            // 
            this.colJobTitleCode.Text = "JobTitle Code";
            this.colJobTitleCode.Width = 80;
            // 
            // colJobTitleName
            // 
            this.colJobTitleName.Text = "JobTitle Name";
            this.colJobTitleName.Width = 120;
            // 
            // colJobTitleNameAlt1
            // 
            this.colJobTitleNameAlt1.Text = "JobTitle Name Chs";
            this.colJobTitleNameAlt1.Width = 120;
            // 
            // colJobTitleNameAlt2
            // 
            this.colJobTitleNameAlt2.Text = "JobTitle Name Cht";
            this.colJobTitleNameAlt2.Width = 120;
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
            // txtJobTitleNameAlt2
            // 
            this.txtJobTitleNameAlt2.Location = new System.Drawing.Point(155, 106);
            this.txtJobTitleNameAlt2.Name = "txtJobTitleNameAlt2";
            this.txtJobTitleNameAlt2.Size = new System.Drawing.Size(135, 20);
            this.txtJobTitleNameAlt2.TabIndex = 4;
            // 
            // txtJobTitleNameAlt1
            // 
            this.txtJobTitleNameAlt1.Location = new System.Drawing.Point(155, 83);
            this.txtJobTitleNameAlt1.Name = "txtJobTitleNameAlt1";
            this.txtJobTitleNameAlt1.Size = new System.Drawing.Size(135, 20);
            this.txtJobTitleNameAlt1.TabIndex = 3;
            // 
            // txtJobTitleName
            // 
            this.txtJobTitleName.Location = new System.Drawing.Point(155, 60);
            this.txtJobTitleName.Name = "txtJobTitleName";
            this.txtJobTitleName.Size = new System.Drawing.Size(135, 20);
            this.txtJobTitleName.TabIndex = 2;
            // 
            // lblJobTitleNameAlt2
            // 
            this.lblJobTitleNameAlt2.Location = new System.Drawing.Point(27, 109);
            this.lblJobTitleNameAlt2.Name = "lblJobTitleNameAlt2";
            this.lblJobTitleNameAlt2.Size = new System.Drawing.Size(125, 23);
            this.lblJobTitleNameAlt2.TabIndex = 4;
            this.lblJobTitleNameAlt2.Text = "JobTitle Name Cht";
            // 
            // lblJobTitleNameAlt1
            // 
            this.lblJobTitleNameAlt1.Location = new System.Drawing.Point(27, 86);
            this.lblJobTitleNameAlt1.Name = "lblJobTitleNameAlt1";
            this.lblJobTitleNameAlt1.Size = new System.Drawing.Size(125, 23);
            this.lblJobTitleNameAlt1.TabIndex = 3;
            this.lblJobTitleNameAlt1.Text = "JobTitle Name Chs:";
            // 
            // lblJobTitleName
            // 
            this.lblJobTitleName.Location = new System.Drawing.Point(16, 63);
            this.lblJobTitleName.Name = "lblJobTitleName";
            this.lblJobTitleName.Size = new System.Drawing.Size(136, 23);
            this.lblJobTitleName.TabIndex = 2;
            this.lblJobTitleName.Text = "JobTitle Name:";
            // 
            // txtJobTitleCode
            // 
            this.txtJobTitleCode.Location = new System.Drawing.Point(155, 37);
            this.txtJobTitleCode.MaxLength = 10;
            this.txtJobTitleCode.Name = "txtJobTitleCode";
            this.txtJobTitleCode.Size = new System.Drawing.Size(135, 20);
            this.txtJobTitleCode.TabIndex = 1;
            // 
            // lblJobTitleCode
            // 
            this.lblJobTitleCode.Location = new System.Drawing.Point(16, 40);
            this.lblJobTitleCode.Name = "lblJobTitleCode";
            this.lblJobTitleCode.Size = new System.Drawing.Size(136, 23);
            this.lblJobTitleCode.TabIndex = 0;
            this.lblJobTitleCode.Text = "JobTitle Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // StaffJobTitleWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "JobTitle Wizard";
            this.Load += new System.EventHandler(this.StaffJobTitleWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvJobTitleList;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleName;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colJobTitleNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleName;
        private Gizmox.WebGUI.Forms.Label lblJobTitleNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblJobTitleNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblJobTitleName;
        private Gizmox.WebGUI.Forms.TextBox txtJobTitleCode;
        private Gizmox.WebGUI.Forms.Label lblJobTitleCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}