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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvCountryList = new Gizmox.WebGUI.Forms.ListView();
            this.colCountryId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCountryCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCountryName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCountryNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCountryNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lnkAddCity = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkAddProvince = new Gizmox.WebGUI.Forms.LinkLabel();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtCountryNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCountryNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCountryName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCountryNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblCountryNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblCountryName = new Gizmox.WebGUI.Forms.Label();
            this.txtCountryCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCountryCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvCountryList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lnkAddCity);
            this.splitContainer.Panel2.Controls.Add(this.lnkAddProvince);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryName);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryName);
            this.splitContainer.Panel2.Controls.Add(this.txtCountryCode);
            this.splitContainer.Panel2.Controls.Add(this.lblCountryCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvCountryList
            // 
            this.lvCountryList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCountryId,
            this.colLN,
            this.colCountryCode,
            this.colCountryName,
            this.colCountryNameAlt1,
            this.colCountryNameAlt2});
            this.lvCountryList.DataMember = null;
            this.lvCountryList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvCountryList.Location = new System.Drawing.Point(0, 0);
            this.lvCountryList.Name = "lvCountryList";
            this.lvCountryList.Size = new System.Drawing.Size(499, 506);
            this.lvCountryList.TabIndex = 0;
            this.lvCountryList.UseInternalPaging = true;
            this.lvCountryList.SelectedIndexChanged += new System.EventHandler(this.lvCountryList_SelectedIndexChanged);
            // 
            // colCountryId
            // 
            this.colCountryId.Text = "CountryId";
            this.colCountryId.Visible = false;
            this.colCountryId.Width = 80;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colCountryCode
            // 
            this.colCountryCode.Text = "Country Code";
            this.colCountryCode.Width = 80;
            // 
            // colCountryName
            // 
            this.colCountryName.Text = "Country Name";
            this.colCountryName.Width = 120;
            // 
            // colCountryNameAlt1
            // 
            this.colCountryNameAlt1.Text = "Country Name Chs";
            this.colCountryNameAlt1.Width = 120;
            // 
            // colCountryNameAlt2
            // 
            this.colCountryNameAlt2.Text = "Country Name Cht";
            this.colCountryNameAlt2.Width = 120;
            // 
            // lnkAddCity
            // 
            this.lnkAddCity.LinkColor = System.Drawing.Color.Blue;
            this.lnkAddCity.Location = new System.Drawing.Point(180, 465);
            this.lnkAddCity.Name = "lnkAddCity";
            this.lnkAddCity.Size = new System.Drawing.Size(100, 23);
            this.lnkAddCity.TabIndex = 6;
            this.lnkAddCity.TabStop = true;
            this.lnkAddCity.Text = "Add City";
            this.lnkAddCity.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCity_LinkClicked);
            // 
            // lnkAddProvince
            // 
            this.lnkAddProvince.LinkColor = System.Drawing.Color.Blue;
            this.lnkAddProvince.Location = new System.Drawing.Point(74, 465);
            this.lnkAddProvince.Name = "lnkAddProvince";
            this.lnkAddProvince.Size = new System.Drawing.Size(100, 23);
            this.lnkAddProvince.TabIndex = 5;
            this.lnkAddProvince.TabStop = true;
            this.lnkAddProvince.Text = "Add Province";
            this.lnkAddProvince.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddProvince_LinkClicked);
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
            this.tbWizardAction.TabIndex = 7;
            // 
            // txtCountryNameAlt2
            // 
            this.txtCountryNameAlt2.Location = new System.Drawing.Point(167, 106);
            this.txtCountryNameAlt2.Name = "txtCountryNameAlt2";
            this.txtCountryNameAlt2.Size = new System.Drawing.Size(123, 20);
            this.txtCountryNameAlt2.TabIndex = 4;
            // 
            // txtCountryNameAlt1
            // 
            this.txtCountryNameAlt1.Location = new System.Drawing.Point(167, 83);
            this.txtCountryNameAlt1.Name = "txtCountryNameAlt1";
            this.txtCountryNameAlt1.Size = new System.Drawing.Size(123, 20);
            this.txtCountryNameAlt1.TabIndex = 3;
            // 
            // txtCountryName
            // 
            this.txtCountryName.Location = new System.Drawing.Point(167, 60);
            this.txtCountryName.Name = "txtCountryName";
            this.txtCountryName.Size = new System.Drawing.Size(123, 20);
            this.txtCountryName.TabIndex = 2;
            // 
            // lblCountryNameAlt2
            // 
            this.lblCountryNameAlt2.Location = new System.Drawing.Point(28, 109);
            this.lblCountryNameAlt2.Name = "lblCountryNameAlt2";
            this.lblCountryNameAlt2.Size = new System.Drawing.Size(136, 23);
            this.lblCountryNameAlt2.TabIndex = 4;
            this.lblCountryNameAlt2.Text = "Country Name Cht";
            // 
            // lblCountryNameAlt1
            // 
            this.lblCountryNameAlt1.Location = new System.Drawing.Point(28, 86);
            this.lblCountryNameAlt1.Name = "lblCountryNameAlt1";
            this.lblCountryNameAlt1.Size = new System.Drawing.Size(136, 23);
            this.lblCountryNameAlt1.TabIndex = 3;
            this.lblCountryNameAlt1.Text = "Country Name Chs:";
            // 
            // lblCountryName
            // 
            this.lblCountryName.Location = new System.Drawing.Point(16, 63);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(148, 23);
            this.lblCountryName.TabIndex = 2;
            this.lblCountryName.Text = "Country Name:";
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Location = new System.Drawing.Point(167, 37);
            this.txtCountryCode.MaxLength = 10;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(123, 20);
            this.txtCountryCode.TabIndex = 1;
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.Location = new System.Drawing.Point(16, 40);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(148, 23);
            this.lblCountryCode.TabIndex = 0;
            this.lblCountryCode.Text = "Country Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
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
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtCountryNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtCountryNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtCountryName;
        private Gizmox.WebGUI.Forms.Label lblCountryNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblCountryNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblCountryName;
        private Gizmox.WebGUI.Forms.TextBox txtCountryCode;
        private Gizmox.WebGUI.Forms.Label lblCountryCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAddCity;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAddProvince;


    }
}