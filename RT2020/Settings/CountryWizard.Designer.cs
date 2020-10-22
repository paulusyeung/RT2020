namespace RT2020.Settings
{
    partial class CountryWizard
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
            this.lvCountryList = new Gizmox.WebGUI.Forms.ListView();
            this.colCountryId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCountryCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCountryName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCountryNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCountryNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lnkAddCity = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkAddProvince = new Gizmox.WebGUI.Forms.LinkLabel();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtCountryNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCountryNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCountryName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCountryNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblCountryNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblCountryName = new Gizmox.WebGUI.Forms.Label();
            this.txtCountryCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCountryCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvCountryList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lnkAddCity);
            this.splitContainer.Panel2.Controls.Add(this.lnkAddProvince);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryName);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryName);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryCode);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvCountryList
            // 
            this.lvCountryList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvCountryList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCountryId,
            this.colLN,
            this.colCountryCode,
            this.colCountryName,
            this.colCountryNameChs,
            this.colCountryNameCht});
            this.lvCountryList.DataMember = null;
            this.lvCountryList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvCountryList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvCountryList.ItemsPerPage = 20;
            this.lvCountryList.Location = new System.Drawing.Point(0, 0);
            this.lvCountryList.Name = "lvCountryList";
            this.lvCountryList.Size = new System.Drawing.Size(499, 506);
            this.lvCountryList.TabIndex = 0;
            this.lvCountryList.UseInternalPaging = true;
            this.lvCountryList.SelectedIndexChanged += new System.EventHandler(this.lvCountryList_SelectedIndexChanged);
            // 
            // colCountryId
            // 
            this.colCountryId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCountryId.Image = null;
            this.colCountryId.Text = "CountryId";
            this.colCountryId.Visible = false;
            this.colCountryId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colCountryCode
            // 
            this.colCountryCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCountryCode.Image = null;
            this.colCountryCode.Text = "Country Code";
            this.colCountryCode.Width = 80;
            // 
            // colCountryName
            // 
            this.colCountryName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCountryName.Image = null;
            this.colCountryName.Text = "Country Name";
            this.colCountryName.Width = 120;
            // 
            // colCountryNameChs
            // 
            this.colCountryNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCountryNameChs.Image = null;
            this.colCountryNameChs.Text = "Country Name Chs";
            this.colCountryNameChs.Width = 120;
            // 
            // colCountryNameCht
            // 
            this.colCountryNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCountryNameCht.Image = null;
            this.colCountryNameCht.Text = "Country Name Cht";
            this.colCountryNameCht.Width = 120;
            // 
            // lnkAddCity
            // 
            this.lnkAddCity.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lnkAddCity.Location = new System.Drawing.Point(180, 465);
            this.lnkAddCity.Name = "lnkAddCity";
            this.lnkAddCity.Size = new System.Drawing.Size(100, 23);
            this.lnkAddCity.TabIndex = 6;
            this.lnkAddCity.Text = "Add City";
            this.lnkAddCity.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCity_LinkClicked);
            // 
            // lnkAddProvince
            // 
            this.lnkAddProvince.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lnkAddProvince.Location = new System.Drawing.Point(74, 465);
            this.lnkAddProvince.Name = "lnkAddProvince";
            this.lnkAddProvince.Size = new System.Drawing.Size(100, 23);
            this.lnkAddProvince.TabIndex = 5;
            this.lnkAddProvince.Text = "Add Province";
            this.lnkAddProvince.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddProvince_LinkClicked);
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
            this.tbWizardAction.TabIndex = 7;
            // 
            // txtCountryNameCht
            // 
            this.txtCountryNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCountryNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtCountryNameCht.Name = "txtCountryNameCht";
            this.txtCountryNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtCountryNameCht.TabIndex = 4;
            // 
            // txtCountryNameChs
            // 
            this.txtCountryNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCountryNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtCountryNameChs.Name = "txtCountryNameChs";
            this.txtCountryNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtCountryNameChs.TabIndex = 3;
            // 
            // txtCountryName
            // 
            this.txtCountryName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCountryName.Location = new System.Drawing.Point(122, 60);
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(142, 20);
            this.txtCountryName.TabIndex = 2;
            // 
            // lblCountryNameCht
            // 
            this.lblCountryNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountryNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblCountryNameCht.Name = "lblCountryNameCht";
            this.lblCountryNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblCountryNameCht.TabIndex = 4;
            this.lblCountryNameCht.Text = "Country Name Cht";
            // 
            // lblCountryNameChs
            // 
            this.lblCountryNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountryNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblCountryNameChs.Name = "lblCountryNameChs";
            this.lblCountryNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblCountryNameChs.TabIndex = 3;
            this.lblCountryNameChs.Text = "Country Name Chs:";
            // 
            // lblCountryName
            // 
            this.lblCountryName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountryName.Location = new System.Drawing.Point(16, 63);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(100, 23);
            this.lblCountryName.TabIndex = 2;
            this.lblCountryName.Text = "Country Name:";
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCountryCode.Location = new System.Drawing.Point(122, 37);
            this.txtCountryCode.MaxLength = 10;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(142, 20);
            this.txtCountryCode.TabIndex = 1;
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountryCode.Location = new System.Drawing.Point(16, 40);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(100, 23);
            this.lblCountryCode.TabIndex = 0;
            this.lblCountryCode.Text = "Country Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // CountryWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Country Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvCountryList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryName;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtCountryNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtCountryNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtCountryName;
        private Gizmox.WebGUI.Forms.Label lblCountryNameCht;
        private Gizmox.WebGUI.Forms.Label lblCountryNameChs;
        private Gizmox.WebGUI.Forms.Label lblCountryName;
        private Gizmox.WebGUI.Forms.TextBox txtCountryCode;
        private Gizmox.WebGUI.Forms.Label lblCountryCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAddCity;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAddProvince;


    }
}