namespace RT2020.Settings
{
    partial class ZoneWizard
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
            this.lvZoneList = new Gizmox.WebGUI.Forms.ListView();
            this.colZoneId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colParent = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colZoneCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colZoneName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colZoneNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colZoneNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneInitial = new Gizmox.WebGUI.Forms.Label();
            this.txtZoneInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.cboParent = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentZone = new Gizmox.WebGUI.Forms.Label();
            this.lblPrimaryZone = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryZone = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtZoneNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtZoneNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtZoneName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblZoneNameAtl2 = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneName = new Gizmox.WebGUI.Forms.Label();
            this.txtZoneCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblZoneCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvZoneList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtRemarks);
            this.splitContainer.Panel2.Controls.Add(this.lblRemarks);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneInitial);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneInitial);
            this.splitContainer.Panel2.Controls.Add(this.cboParent);
            this.splitContainer.Panel2.Controls.Add(this.lblParentZone);
            this.splitContainer.Panel2.Controls.Add(this.lblPrimaryZone);
            this.splitContainer.Panel2.Controls.Add(this.chkPrimaryZone);
            this.splitContainer.Panel2.Controls.Add(this.cboCurrency);
            this.splitContainer.Panel2.Controls.Add(this.lblCurrency);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneName);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneNameAtl2);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneName);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneCode);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvZoneList
            // 
            this.lvZoneList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colZoneId,
            this.colLN,
            this.colParent,
            this.colZoneCode,
            this.colZoneName,
            this.colZoneNameAlt1,
            this.colZoneNameAlt2});
            this.lvZoneList.DataMember = null;
            this.lvZoneList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvZoneList.Location = new System.Drawing.Point(0, 0);
            this.lvZoneList.Name = "lvZoneList";
            this.lvZoneList.Size = new System.Drawing.Size(499, 506);
            this.lvZoneList.TabIndex = 0;
            this.lvZoneList.UseInternalPaging = true;
            this.lvZoneList.SelectedIndexChanged += new System.EventHandler(this.lvZoneList_SelectedIndexChanged);
            // 
            // colZoneId
            // 
            this.colZoneId.Text = "ZoneId";
            this.colZoneId.Visible = false;
            this.colZoneId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colParent
            // 
            this.colParent.Text = "Parent";
            this.colParent.Width = 80;
            // 
            // colZoneCode
            // 
            this.colZoneCode.Text = "Zone Code";
            this.colZoneCode.Width = 80;
            // 
            // colZoneName
            // 
            this.colZoneName.Text = "Zone Name";
            this.colZoneName.Width = 120;
            // 
            // colZoneNameAlt1
            // 
            this.colZoneNameAlt1.Text = "Zone Name Chs";
            this.colZoneNameAlt1.Width = 120;
            // 
            // colZoneNameAlt2
            // 
            this.colZoneNameAlt2.Text = "Zone Name Cht";
            this.colZoneNameAlt2.Width = 120;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(16, 241);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(274, 57);
            this.txtRemarks.TabIndex = 9;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(16, 224);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 14;
            this.lblRemarks.Text = "Remarks:";
            // 
            // lblZoneInitial
            // 
            this.lblZoneInitial.Location = new System.Drawing.Point(16, 63);
            this.lblZoneInitial.Name = "lblZoneInitial";
            this.lblZoneInitial.Size = new System.Drawing.Size(140, 23);
            this.lblZoneInitial.TabIndex = 0;
            this.lblZoneInitial.Text = "Zone Initial:";
            // 
            // txtZoneInitial
            // 
            this.txtZoneInitial.Location = new System.Drawing.Point(159, 60);
            this.txtZoneInitial.MaxLength = 10;
            this.txtZoneInitial.Name = "txtZoneInitial";
            this.txtZoneInitial.Size = new System.Drawing.Size(131, 20);
            this.txtZoneInitial.TabIndex = 2;
            // 
            // cboParent
            // 
            this.cboParent.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParent.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.DropDownWidth = 142;
            this.cboParent.Location = new System.Drawing.Point(159, 198);
            this.cboParent.Name = "cboParent";
            this.cboParent.Size = new System.Drawing.Size(131, 21);
            this.cboParent.TabIndex = 8;
            // 
            // lblParentZone
            // 
            this.lblParentZone.Location = new System.Drawing.Point(16, 201);
            this.lblParentZone.Name = "lblParentZone";
            this.lblParentZone.Size = new System.Drawing.Size(140, 23);
            this.lblParentZone.TabIndex = 13;
            this.lblParentZone.Text = "Attached To:";
            // 
            // lblPrimaryZone
            // 
            this.lblPrimaryZone.Location = new System.Drawing.Point(16, 178);
            this.lblPrimaryZone.Name = "lblPrimaryZone";
            this.lblPrimaryZone.Size = new System.Drawing.Size(140, 23);
            this.lblPrimaryZone.TabIndex = 12;
            this.lblPrimaryZone.Text = "Primary Zone:";
            // 
            // chkPrimaryZone
            // 
            this.chkPrimaryZone.Location = new System.Drawing.Point(159, 174);
            this.chkPrimaryZone.Name = "chkPrimaryZone";
            this.chkPrimaryZone.Size = new System.Drawing.Size(131, 24);
            this.chkPrimaryZone.TabIndex = 7;
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(159, 152);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(131, 21);
            this.cboCurrency.TabIndex = 6;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(16, 155);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(140, 23);
            this.lblCurrency.TabIndex = 9;
            this.lblCurrency.Text = "Currency Code:";
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
            // txtZoneNameAlt2
            // 
            this.txtZoneNameAlt2.Location = new System.Drawing.Point(159, 129);
            this.txtZoneNameAlt2.Name = "txtZoneNameAlt2";
            this.txtZoneNameAlt2.Size = new System.Drawing.Size(131, 20);
            this.txtZoneNameAlt2.TabIndex = 5;
            // 
            // txtZoneNameAlt1
            // 
            this.txtZoneNameAlt1.Location = new System.Drawing.Point(159, 106);
            this.txtZoneNameAlt1.Name = "txtZoneNameAlt1";
            this.txtZoneNameAlt1.Size = new System.Drawing.Size(131, 20);
            this.txtZoneNameAlt1.TabIndex = 4;
            // 
            // txtZoneName
            // 
            this.txtZoneName.Location = new System.Drawing.Point(159, 83);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(131, 20);
            this.txtZoneName.TabIndex = 3;
            // 
            // lblZoneNameAtl2
            // 
            this.lblZoneNameAtl2.Location = new System.Drawing.Point(29, 132);
            this.lblZoneNameAtl2.Name = "lblZoneNameAtl2";
            this.lblZoneNameAtl2.Size = new System.Drawing.Size(127, 23);
            this.lblZoneNameAtl2.TabIndex = 4;
            this.lblZoneNameAtl2.Text = "Zone Name Cht";
            // 
            // lblZoneNameAlt1
            // 
            this.lblZoneNameAlt1.Location = new System.Drawing.Point(29, 109);
            this.lblZoneNameAlt1.Name = "lblZoneNameAlt1";
            this.lblZoneNameAlt1.Size = new System.Drawing.Size(127, 23);
            this.lblZoneNameAlt1.TabIndex = 3;
            this.lblZoneNameAlt1.Text = "Zone Name Chs:";
            // 
            // lblZoneName
            // 
            this.lblZoneName.Location = new System.Drawing.Point(16, 86);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(140, 23);
            this.lblZoneName.TabIndex = 2;
            this.lblZoneName.Text = "Zone Name:";
            // 
            // txtZoneCode
            // 
            this.txtZoneCode.Location = new System.Drawing.Point(159, 37);
            this.txtZoneCode.MaxLength = 4;
            this.txtZoneCode.Name = "txtZoneCode";
            this.txtZoneCode.Size = new System.Drawing.Size(131, 20);
            this.txtZoneCode.TabIndex = 1;
            // 
            // lblZoneCode
            // 
            this.lblZoneCode.Location = new System.Drawing.Point(16, 40);
            this.lblZoneCode.Name = "lblZoneCode";
            this.lblZoneCode.Size = new System.Drawing.Size(140, 23);
            this.lblZoneCode.TabIndex = 0;
            this.lblZoneCode.Text = "Zone Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // ZoneWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Zone Wizard";
            this.Load += new System.EventHandler(this.ZoneWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvZoneList;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneName;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtZoneNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtZoneNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtZoneName;
        private Gizmox.WebGUI.Forms.Label lblZoneNameAtl2;
        private Gizmox.WebGUI.Forms.Label lblZoneNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblZoneName;
        private Gizmox.WebGUI.Forms.TextBox txtZoneCode;
        private Gizmox.WebGUI.Forms.Label lblZoneCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParent;
        private Gizmox.WebGUI.Forms.Label lblParentZone;
        private Gizmox.WebGUI.Forms.Label lblPrimaryZone;
        private Gizmox.WebGUI.Forms.CheckBox chkPrimaryZone;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblZoneInitial;
        private Gizmox.WebGUI.Forms.TextBox txtZoneInitial;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.ColumnHeader colParent;
    }
}