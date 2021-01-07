namespace RT2020.Supplier
{
    partial class SmartTag4Supplier_OptionsWizard
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
            this.lvTagList = new Gizmox.WebGUI.Forms.ListView();
            this.colOptionId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOptionCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOptionName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOptionNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOptionNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtOptionNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtOptionNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtOptionName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblOptionNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblOptionNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblOptionName = new Gizmox.WebGUI.Forms.Label();
            this.txtOptionCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblOptionCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvTagList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtOptionNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtOptionNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtOptionName);
            this.splitContainer.Panel2.Controls.Add(this.lblOptionNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblOptionNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblOptionName);
            this.splitContainer.Panel2.Controls.Add(this.txtOptionCode);
            this.splitContainer.Panel2.Controls.Add(this.lblOptionCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colOptionId,
            this.colLN,
            this.colOptionCode,
            this.colOptionName,
            this.colOptionNameAlt1,
            this.colOptionNameAlt2});
            this.lvTagList.DataMember = null;
            this.lvTagList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvTagList.Location = new System.Drawing.Point(0, 0);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(499, 506);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseInternalPaging = true;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // colOptionId
            // 
            this.colOptionId.Text = "OptionId";
            this.colOptionId.Visible = false;
            this.colOptionId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colOptionCode
            // 
            this.colOptionCode.Text = "Option Code";
            this.colOptionCode.Width = 80;
            // 
            // colOptionName
            // 
            this.colOptionName.Text = "Option Name";
            this.colOptionName.Width = 120;
            // 
            // colOptionNameAlt1
            // 
            this.colOptionNameAlt1.Text = "Option Name Chs";
            this.colOptionNameAlt1.Width = 120;
            // 
            // colOptionNameAlt2
            // 
            this.colOptionNameAlt2.Text = "Option Name Cht";
            this.colOptionNameAlt2.Width = 120;
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
            this.tbWizardAction.Size = new System.Drawing.Size(302, 20);
            this.tbWizardAction.TabIndex = 6;
            // 
            // txtOptionNameAlt2
            // 
            this.txtOptionNameAlt2.Location = new System.Drawing.Point(164, 106);
            this.txtOptionNameAlt2.Name = "txtOptionNameAlt2";
            this.txtOptionNameAlt2.Size = new System.Drawing.Size(120, 20);
            this.txtOptionNameAlt2.TabIndex = 4;
            // 
            // txtOptionNameAlt1
            // 
            this.txtOptionNameAlt1.Location = new System.Drawing.Point(164, 83);
            this.txtOptionNameAlt1.Name = "txtOptionNameAlt1";
            this.txtOptionNameAlt1.Size = new System.Drawing.Size(120, 20);
            this.txtOptionNameAlt1.TabIndex = 3;
            // 
            // txtOptionName
            // 
            this.txtOptionName.Location = new System.Drawing.Point(164, 60);
            this.txtOptionName.Name = "txtOptionName";
            this.txtOptionName.Size = new System.Drawing.Size(120, 20);
            this.txtOptionName.TabIndex = 2;
            // 
            // lblOptionNameAlt2
            // 
            this.lblOptionNameAlt2.Location = new System.Drawing.Point(29, 109);
            this.lblOptionNameAlt2.Name = "lblOptionNameAlt2";
            this.lblOptionNameAlt2.Size = new System.Drawing.Size(127, 23);
            this.lblOptionNameAlt2.TabIndex = 4;
            this.lblOptionNameAlt2.Text = "Tag Name Cht";
            // 
            // lblOptionNameAlt1
            // 
            this.lblOptionNameAlt1.Location = new System.Drawing.Point(29, 86);
            this.lblOptionNameAlt1.Name = "lblOptionNameAlt1";
            this.lblOptionNameAlt1.Size = new System.Drawing.Size(127, 23);
            this.lblOptionNameAlt1.TabIndex = 3;
            this.lblOptionNameAlt1.Text = "Tag Name Chs:";
            // 
            // lblOptionName
            // 
            this.lblOptionName.Location = new System.Drawing.Point(16, 63);
            this.lblOptionName.Name = "lblOptionName";
            this.lblOptionName.Size = new System.Drawing.Size(100, 23);
            this.lblOptionName.TabIndex = 2;
            this.lblOptionName.Text = "Tag Name:";
            // 
            // txtOptionCode
            // 
            this.txtOptionCode.Location = new System.Drawing.Point(164, 37);
            this.txtOptionCode.MaxLength = 10;
            this.txtOptionCode.Name = "txtOptionCode";
            this.txtOptionCode.Size = new System.Drawing.Size(120, 20);
            this.txtOptionCode.TabIndex = 1;
            // 
            // lblOptionCode
            // 
            this.lblOptionCode.Location = new System.Drawing.Point(16, 40);
            this.lblOptionCode.Name = "lblOptionCode";
            this.lblOptionCode.Size = new System.Drawing.Size(100, 23);
            this.lblOptionCode.TabIndex = 0;
            this.lblOptionCode.Text = "Option Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // SmartTag4Member_OptionsWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Member Wizard";
            this.Load += new System.EventHandler(this.SmartTag4StaffWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvTagList;
        private Gizmox.WebGUI.Forms.ColumnHeader colOptionId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colOptionCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colOptionName;
        private Gizmox.WebGUI.Forms.ColumnHeader colOptionNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colOptionNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtOptionNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtOptionNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtOptionName;
        private Gizmox.WebGUI.Forms.Label lblOptionNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblOptionNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblOptionName;
        private Gizmox.WebGUI.Forms.TextBox txtOptionCode;
        private Gizmox.WebGUI.Forms.Label lblOptionCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
    }
}