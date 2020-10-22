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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvZoneList = new Gizmox.WebGUI.Forms.ListView();
            this.colZoneId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colZoneCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colZoneName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colZoneNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colZoneNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneInitial = new Gizmox.WebGUI.Forms.Label();
            this.txtZoneInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.chkParentZone = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentZone = new Gizmox.WebGUI.Forms.Label();
            this.lblPrimaryZone = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryZone = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtZoneNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtZoneNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtZoneName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblZoneNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblZoneName = new Gizmox.WebGUI.Forms.Label();
            this.txtZoneCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblZoneCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvZoneList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.txtRemarks);
            this.splitContainer.Panel2.Controls.Add(this.lblRemarks);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneInitial);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneInitial);
            this.splitContainer.Panel2.Controls.Add(this.chkParentZone);
            this.splitContainer.Panel2.Controls.Add(this.lblParentZone);
            this.splitContainer.Panel2.Controls.Add(this.lblPrimaryZone);
            this.splitContainer.Panel2.Controls.Add(this.chkPrimaryZone);
            this.splitContainer.Panel2.Controls.Add(this.cboCurrency);
            this.splitContainer.Panel2.Controls.Add(this.lblCurrency);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneName);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneName);
            this.splitContainer.Panel2.Controls.Add(this.txtZoneCode);
            this.splitContainer.Panel2.Controls.Add(this.lblZoneCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvZoneList
            // 
            this.lvZoneList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvZoneList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colZoneId,
            this.colLN,
            this.colZoneCode,
            this.colZoneName,
            this.colZoneNameChs,
            this.colZoneNameCht});
            this.lvZoneList.DataMember = null;
            this.lvZoneList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvZoneList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvZoneList.ItemsPerPage = 20;
            this.lvZoneList.Location = new System.Drawing.Point(0, 0);
            this.lvZoneList.Name = "lvZoneList";
            this.lvZoneList.Size = new System.Drawing.Size(499, 506);
            this.lvZoneList.TabIndex = 0;
            this.lvZoneList.UseInternalPaging = true;
            this.lvZoneList.SelectedIndexChanged += new System.EventHandler(this.lvZoneList_SelectedIndexChanged);
            // 
            // colZoneId
            // 
            this.colZoneId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colZoneId.Image = null;
            this.colZoneId.Text = "ZoneId";
            this.colZoneId.Visible = false;
            this.colZoneId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colZoneCode
            // 
            this.colZoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colZoneCode.Image = null;
            this.colZoneCode.Text = "Zone Code";
            this.colZoneCode.Width = 80;
            // 
            // colZoneName
            // 
            this.colZoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colZoneName.Image = null;
            this.colZoneName.Text = "Zone Name";
            this.colZoneName.Width = 120;
            // 
            // colZoneNameChs
            // 
            this.colZoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colZoneNameChs.Image = null;
            this.colZoneNameChs.Text = "Zone Name Chs";
            this.colZoneNameChs.Width = 120;
            // 
            // colZoneNameCht
            // 
            this.colZoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colZoneNameCht.Image = null;
            this.colZoneNameCht.Text = "Zone Name Cht";
            this.colZoneNameCht.Width = 120;
            // 
            // txtRemarks
            // 
            this.txtRemarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtRemarks.Location = new System.Drawing.Point(19, 241);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(245, 82);
            this.txtRemarks.TabIndex = 9;
            // 
            // lblRemarks
            // 
            this.lblRemarks.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblRemarks.Location = new System.Drawing.Point(16, 224);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 14;
            this.lblRemarks.Text = "Remarks:";
            // 
            // lblZoneInitial
            // 
            this.lblZoneInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblZoneInitial.Location = new System.Drawing.Point(16, 63);
            this.lblZoneInitial.Name = "lblZoneInitial";
            this.lblZoneInitial.Size = new System.Drawing.Size(100, 23);
            this.lblZoneInitial.TabIndex = 0;
            this.lblZoneInitial.Text = "Zone Initial:";
            // 
            // txtZoneInitial
            // 
            this.txtZoneInitial.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtZoneInitial.Location = new System.Drawing.Point(122, 60);
            this.txtZoneInitial.MaxLength = 10;
            this.txtZoneInitial.Name = "txtZoneInitial";
            this.txtZoneInitial.Size = new System.Drawing.Size(142, 20);
            this.txtZoneInitial.TabIndex = 2;
            // 
            // chkParentZone
            // 
            this.chkParentZone.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.chkParentZone.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkParentZone.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.chkParentZone.DropDownWidth = 142;
            this.chkParentZone.Location = new System.Drawing.Point(122, 198);
            this.chkParentZone.Name = "chkParentZone";
            this.chkParentZone.Size = new System.Drawing.Size(142, 21);
            this.chkParentZone.TabIndex = 8;
            // 
            // lblParentZone
            // 
            this.lblParentZone.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentZone.Location = new System.Drawing.Point(16, 201);
            this.lblParentZone.Name = "lblParentZone";
            this.lblParentZone.Size = new System.Drawing.Size(100, 23);
            this.lblParentZone.TabIndex = 13;
            this.lblParentZone.Text = "Attached To:";
            // 
            // lblPrimaryZone
            // 
            this.lblPrimaryZone.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPrimaryZone.Location = new System.Drawing.Point(16, 178);
            this.lblPrimaryZone.Name = "lblPrimaryZone";
            this.lblPrimaryZone.Size = new System.Drawing.Size(100, 23);
            this.lblPrimaryZone.TabIndex = 12;
            this.lblPrimaryZone.Text = "Primary Zone:";
            // 
            // chkPrimaryZone
            // 
            this.chkPrimaryZone.Checked = false;
            this.chkPrimaryZone.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkPrimaryZone.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkPrimaryZone.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPrimaryZone.Location = new System.Drawing.Point(122, 177);
            this.chkPrimaryZone.Name = "chkPrimaryZone";
            this.chkPrimaryZone.Size = new System.Drawing.Size(22, 24);
            this.chkPrimaryZone.TabIndex = 7;
            this.chkPrimaryZone.ThreeState = false;
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(122, 152);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(142, 21);
            this.cboCurrency.TabIndex = 6;
            // 
            // lblCurrency
            // 
            this.lblCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCurrency.Location = new System.Drawing.Point(16, 155);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(100, 23);
            this.lblCurrency.TabIndex = 9;
            this.lblCurrency.Text = "Currency Code:";
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
            // txtZoneNameCht
            // 
            this.txtZoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtZoneNameCht.Location = new System.Drawing.Point(122, 129);
            this.txtZoneNameCht.Name = "txtZoneNameCht";
            this.txtZoneNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtZoneNameCht.TabIndex = 5;
            // 
            // txtZoneNameChs
            // 
            this.txtZoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtZoneNameChs.Location = new System.Drawing.Point(122, 106);
            this.txtZoneNameChs.Name = "txtZoneNameChs";
            this.txtZoneNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtZoneNameChs.TabIndex = 4;
            // 
            // txtZoneName
            // 
            this.txtZoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtZoneName.Location = new System.Drawing.Point(122, 83);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(142, 20);
            this.txtZoneName.TabIndex = 3;
            // 
            // lblZoneNameCht
            // 
            this.lblZoneNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblZoneNameCht.Location = new System.Drawing.Point(16, 132);
            this.lblZoneNameCht.Name = "lblZoneNameCht";
            this.lblZoneNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblZoneNameCht.TabIndex = 4;
            this.lblZoneNameCht.Text = "Zone Name Cht";
            // 
            // lblZoneNameChs
            // 
            this.lblZoneNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblZoneNameChs.Location = new System.Drawing.Point(16, 109);
            this.lblZoneNameChs.Name = "lblZoneNameChs";
            this.lblZoneNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblZoneNameChs.TabIndex = 3;
            this.lblZoneNameChs.Text = "Zone Name Chs:";
            // 
            // lblZoneName
            // 
            this.lblZoneName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblZoneName.Location = new System.Drawing.Point(16, 86);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(100, 23);
            this.lblZoneName.TabIndex = 2;
            this.lblZoneName.Text = "Zone Name:";
            // 
            // txtZoneCode
            // 
            this.txtZoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtZoneCode.Location = new System.Drawing.Point(122, 37);
            this.txtZoneCode.MaxLength = 4;
            this.txtZoneCode.Name = "txtZoneCode";
            this.txtZoneCode.Size = new System.Drawing.Size(142, 20);
            this.txtZoneCode.TabIndex = 1;
            // 
            // lblZoneCode
            // 
            this.lblZoneCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblZoneCode.Location = new System.Drawing.Point(16, 40);
            this.lblZoneCode.Name = "lblZoneCode";
            this.lblZoneCode.Size = new System.Drawing.Size(100, 23);
            this.lblZoneCode.TabIndex = 0;
            this.lblZoneCode.Text = "Zone Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ZoneWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Zone Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvZoneList;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneName;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colZoneNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtZoneNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtZoneNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtZoneName;
        private Gizmox.WebGUI.Forms.Label lblZoneNameCht;
        private Gizmox.WebGUI.Forms.Label lblZoneNameChs;
        private Gizmox.WebGUI.Forms.Label lblZoneName;
        private Gizmox.WebGUI.Forms.TextBox txtZoneCode;
        private Gizmox.WebGUI.Forms.Label lblZoneCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox chkParentZone;
        private Gizmox.WebGUI.Forms.Label lblParentZone;
        private Gizmox.WebGUI.Forms.Label lblPrimaryZone;
        private Gizmox.WebGUI.Forms.CheckBox chkPrimaryZone;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblZoneInitial;
        private Gizmox.WebGUI.Forms.TextBox txtZoneInitial;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.Label lblRemarks;


    }
}