namespace RT2020.Settings
{
    partial class CityWizard
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
            this.ansListView = new Gizmox.WebGUI.Forms.ToolBar();
            this.lvCityList = new Gizmox.WebGUI.Forms.ListView();
            this.colCityId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCityCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCityName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCityNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCityNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lblProvince = new Gizmox.WebGUI.Forms.Label();
            this.cboProvince = new Gizmox.WebGUI.Forms.ComboBox();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtCityNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCityNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCityName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCityNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblCityNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblCityName = new Gizmox.WebGUI.Forms.Label();
            this.txtCityCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCityCode = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
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
            this.splitContainer.Panel1.Controls.Add(this.ansListView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblProvince);
            this.splitContainer.Panel2.Controls.Add(this.cboProvince);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtCityNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtCityNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtCityName);
            this.splitContainer.Panel2.Controls.Add(this.lblCityNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblCityNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblCityName);
            this.splitContainer.Panel2.Controls.Add(this.txtCityCode);
            this.splitContainer.Panel2.Controls.Add(this.lblCityCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // ansListView
            // 
            this.ansListView.ButtonSize = new System.Drawing.Size(20, 20);
            this.ansListView.DragHandle = true;
            this.ansListView.DropDownArrows = true;
            this.ansListView.ImageSize = new System.Drawing.Size(16, 16);
            this.ansListView.Location = new System.Drawing.Point(0, 0);
            this.ansListView.MenuHandle = true;
            this.ansListView.Name = "ansListView";
            this.ansListView.ShowToolTips = true;
            this.ansListView.Size = new System.Drawing.Size(500, 26);
            this.ansListView.TabIndex = 1;
            // 
            // lvCityList
            // 
            this.lvCityList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCityId,
            this.colLN,
            this.colCityCode,
            this.colCityName,
            this.colCityNameAlt1,
            this.colCityNameAlt2});
            this.lvCityList.DataMember = null;
            this.lvCityList.Location = new System.Drawing.Point(43, 30);
            this.lvCityList.Name = "lvCityList";
            this.lvCityList.Size = new System.Drawing.Size(241, 110);
            this.lvCityList.TabIndex = 0;
            this.lvCityList.UseInternalPaging = true;
            this.lvCityList.SelectedIndexChanged += new System.EventHandler(this.lvCityList_SelectedIndexChanged);
            // 
            // colCityId
            // 
            this.colCityId.Text = "CityId";
            this.colCityId.Visible = false;
            this.colCityId.Width = 80;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colCityCode
            // 
            this.colCityCode.Text = "City Code";
            this.colCityCode.Width = 80;
            // 
            // colCityName
            // 
            this.colCityName.Text = "City Name";
            this.colCityName.Width = 120;
            // 
            // colCityNameAlt1
            // 
            this.colCityNameAlt1.Text = "City Name Chs";
            this.colCityNameAlt1.Width = 120;
            // 
            // colCityNameAlt2
            // 
            this.colCityNameAlt2.Text = "City Name Cht";
            this.colCityNameAlt2.Width = 120;
            // 
            // lblProvince
            // 
            this.lblProvince.Location = new System.Drawing.Point(16, 132);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(100, 23);
            this.lblProvince.TabIndex = 9;
            this.lblProvince.Text = "Province:";
            // 
            // cboProvince
            // 
            this.cboProvince.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboProvince.DropDownWidth = 121;
            this.cboProvince.Location = new System.Drawing.Point(159, 129);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(131, 21);
            this.cboProvince.TabIndex = 4;
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
            this.tbWizardAction.TabIndex = 5;
            // 
            // txtCityNameAlt2
            // 
            this.txtCityNameAlt2.Location = new System.Drawing.Point(159, 106);
            this.txtCityNameAlt2.Name = "txtCityNameAlt2";
            this.txtCityNameAlt2.Size = new System.Drawing.Size(131, 20);
            this.txtCityNameAlt2.TabIndex = 3;
            // 
            // txtCityNameAlt1
            // 
            this.txtCityNameAlt1.Location = new System.Drawing.Point(159, 83);
            this.txtCityNameAlt1.Name = "txtCityNameAlt1";
            this.txtCityNameAlt1.Size = new System.Drawing.Size(131, 20);
            this.txtCityNameAlt1.TabIndex = 2;
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(159, 60);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(131, 20);
            this.txtCityName.TabIndex = 1;
            // 
            // lblCityNameAlt2
            // 
            this.lblCityNameAlt2.Location = new System.Drawing.Point(24, 109);
            this.lblCityNameAlt2.Name = "lblCityNameAlt2";
            this.lblCityNameAlt2.Size = new System.Drawing.Size(132, 23);
            this.lblCityNameAlt2.TabIndex = 4;
            this.lblCityNameAlt2.Text = "City Name Cht";
            // 
            // lblCityNameAlt1
            // 
            this.lblCityNameAlt1.Location = new System.Drawing.Point(24, 86);
            this.lblCityNameAlt1.Name = "lblCityNameAlt1";
            this.lblCityNameAlt1.Size = new System.Drawing.Size(132, 23);
            this.lblCityNameAlt1.TabIndex = 3;
            this.lblCityNameAlt1.Text = "City Name Chs:";
            // 
            // lblCityName
            // 
            this.lblCityName.Location = new System.Drawing.Point(16, 63);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(100, 23);
            this.lblCityName.TabIndex = 2;
            this.lblCityName.Text = "City Name:";
            // 
            // txtCityCode
            // 
            this.txtCityCode.Location = new System.Drawing.Point(159, 37);
            this.txtCityCode.MaxLength = 10;
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(131, 20);
            this.txtCityCode.TabIndex = 0;
            // 
            // lblCityCode
            // 
            this.lblCityCode.Location = new System.Drawing.Point(16, 40);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(100, 23);
            this.lblCityCode.TabIndex = 7;
            this.lblCityCode.Text = "City Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvCityList);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 480);
            this.panel1.TabIndex = 2;
            // 
            // CityWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "City Wizard";
            this.Load += new System.EventHandler(this.CityWizard_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvCityList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityName;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtCityNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtCityNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtCityName;
        private Gizmox.WebGUI.Forms.Label lblCityNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblCityNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblCityName;
        private Gizmox.WebGUI.Forms.TextBox txtCityCode;
        private Gizmox.WebGUI.Forms.Label lblCityCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblProvince;
        private Gizmox.WebGUI.Forms.ComboBox cboProvince;
        private Gizmox.WebGUI.Forms.ToolBar ansListView;
        private Gizmox.WebGUI.Forms.Panel panel1;
    }
}