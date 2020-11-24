namespace RT2020.Settings
{
    partial class ProvinceWizard
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
            this.tbrListView = new Gizmox.WebGUI.Forms.ToolBar();
            this.lvProvinceList = new Gizmox.WebGUI.Forms.ListView();
            this.colProvinceId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colProvinceCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colProvinceName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colProvinceNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colProvinceNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboCountry = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCountry = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtProvinceNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProvinceNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProvinceName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvinceNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblProvinceNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblProvinceName = new Gizmox.WebGUI.Forms.Label();
            this.txtProvinceCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvinceCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.colCountry = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.tbrListView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboCountry);
            this.splitContainer.Panel2.Controls.Add(this.lblCountry);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceName);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceName);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceCode);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // tbrListView
            // 
            this.tbrListView.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbrListView.DragHandle = true;
            this.tbrListView.DropDownArrows = true;
            this.tbrListView.ImageSize = new System.Drawing.Size(16, 16);
            this.tbrListView.Location = new System.Drawing.Point(0, 0);
            this.tbrListView.MenuHandle = true;
            this.tbrListView.Name = "tbrListView";
            this.tbrListView.ShowToolTips = true;
            this.tbrListView.Size = new System.Drawing.Size(500, 26);
            this.tbrListView.TabIndex = 1;
            // 
            // lvProvinceList
            // 
            this.lvProvinceList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colProvinceId,
            this.colLN,
            this.colCountry,
            this.colProvinceCode,
            this.colProvinceName,
            this.colProvinceNameAlt1,
            this.colProvinceNameAlt2});
            this.lvProvinceList.DataMember = null;
            this.lvProvinceList.Location = new System.Drawing.Point(36, 32);
            this.lvProvinceList.Name = "lvProvinceList";
            this.lvProvinceList.Size = new System.Drawing.Size(266, 121);
            this.lvProvinceList.TabIndex = 0;
            this.lvProvinceList.UseInternalPaging = true;
            this.lvProvinceList.SelectedIndexChanged += new System.EventHandler(this.lvProvinceList_SelectedIndexChanged);
            // 
            // colProvinceId
            // 
            this.colProvinceId.Text = "ProvinceId";
            this.colProvinceId.Visible = false;
            this.colProvinceId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colProvinceCode
            // 
            this.colProvinceCode.Text = "Province Code";
            this.colProvinceCode.Width = 80;
            // 
            // colProvinceName
            // 
            this.colProvinceName.Text = "Province Name";
            this.colProvinceName.Width = 120;
            // 
            // colProvinceNameAlt1
            // 
            this.colProvinceNameAlt1.Text = "Province Name Chs";
            this.colProvinceNameAlt1.Width = 120;
            // 
            // colProvinceNameAlt2
            // 
            this.colProvinceNameAlt2.Text = "Province Name Cht";
            this.colProvinceNameAlt2.Width = 120;
            // 
            // cboCountry
            // 
            this.cboCountry.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCountry.DropDownWidth = 121;
            this.cboCountry.Location = new System.Drawing.Point(148, 129);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(142, 21);
            this.cboCountry.TabIndex = 5;
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(16, 132);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(129, 23);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "Country:";
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
            // txtProvinceNameAlt2
            // 
            this.txtProvinceNameAlt2.Location = new System.Drawing.Point(148, 106);
            this.txtProvinceNameAlt2.Name = "txtProvinceNameAlt2";
            this.txtProvinceNameAlt2.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceNameAlt2.TabIndex = 4;
            // 
            // txtProvinceNameAlt1
            // 
            this.txtProvinceNameAlt1.Location = new System.Drawing.Point(148, 83);
            this.txtProvinceNameAlt1.Name = "txtProvinceNameAlt1";
            this.txtProvinceNameAlt1.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceNameAlt1.TabIndex = 3;
            // 
            // txtProvinceName
            // 
            this.txtProvinceName.Location = new System.Drawing.Point(148, 60);
            this.txtProvinceName.Name = "txtProvinceName";
            this.txtProvinceName.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceName.TabIndex = 2;
            // 
            // lblProvinceNameAlt2
            // 
            this.lblProvinceNameAlt2.Location = new System.Drawing.Point(26, 109);
            this.lblProvinceNameAlt2.Name = "lblProvinceNameAlt2";
            this.lblProvinceNameAlt2.Size = new System.Drawing.Size(119, 23);
            this.lblProvinceNameAlt2.TabIndex = 4;
            this.lblProvinceNameAlt2.Text = "Province Name Cht";
            // 
            // lblProvinceNameAlt1
            // 
            this.lblProvinceNameAlt1.Location = new System.Drawing.Point(26, 86);
            this.lblProvinceNameAlt1.Name = "lblProvinceNameAlt1";
            this.lblProvinceNameAlt1.Size = new System.Drawing.Size(119, 23);
            this.lblProvinceNameAlt1.TabIndex = 3;
            this.lblProvinceNameAlt1.Text = "Province Name Chs:";
            // 
            // lblProvinceName
            // 
            this.lblProvinceName.Location = new System.Drawing.Point(16, 63);
            this.lblProvinceName.Name = "lblProvinceName";
            this.lblProvinceName.Size = new System.Drawing.Size(129, 23);
            this.lblProvinceName.TabIndex = 2;
            this.lblProvinceName.Text = "Province Name:";
            // 
            // txtProvinceCode
            // 
            this.txtProvinceCode.Location = new System.Drawing.Point(148, 37);
            this.txtProvinceCode.MaxLength = 10;
            this.txtProvinceCode.Name = "txtProvinceCode";
            this.txtProvinceCode.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceCode.TabIndex = 1;
            // 
            // lblProvinceCode
            // 
            this.lblProvinceCode.Location = new System.Drawing.Point(16, 40);
            this.lblProvinceCode.Name = "lblProvinceCode";
            this.lblProvinceCode.Size = new System.Drawing.Size(129, 23);
            this.lblProvinceCode.TabIndex = 0;
            this.lblProvinceCode.Text = "Province Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvProvinceList);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 480);
            this.panel1.TabIndex = 2;
            // 
            // colCountry
            // 
            this.colCountry.Text = "Country";
            this.colCountry.Width = 100;
            // 
            // ProvinceWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Province Wizard";
            this.Load += new System.EventHandler(this.ProvinceWizard_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvProvinceList;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceName;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceName;
        private Gizmox.WebGUI.Forms.Label lblProvinceNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblProvinceNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblProvinceName;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceCode;
        private Gizmox.WebGUI.Forms.Label lblProvinceCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblCountry;
        private Gizmox.WebGUI.Forms.ComboBox cboCountry;
        private Gizmox.WebGUI.Forms.ToolBar tbrListView;
        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountry;
    }
}