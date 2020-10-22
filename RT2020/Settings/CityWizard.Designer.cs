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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvCityList = new Gizmox.WebGUI.Forms.ListView();
            this.colCityId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCityCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCityName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCityNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCityNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblProvince = new Gizmox.WebGUI.Forms.Label();
            this.cboProvince = new Gizmox.WebGUI.Forms.ComboBox();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtCityNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCityNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCityName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCityNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblCityNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblCityName = new Gizmox.WebGUI.Forms.Label();
            this.txtCityCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCityCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvCityList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblProvince);
            this.splitContainer.Panel2.Controls.Add(this.cboProvince);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtCityNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtCityNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtCityName);
            this.splitContainer.Panel2.Controls.Add(this.lblCityNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblCityNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblCityName);
            this.splitContainer.Panel2.Controls.Add(this.txtCityCode);
            this.splitContainer.Panel2.Controls.Add(this.lblCityCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvCityList
            // 
            this.lvCityList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvCityList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCityId,
            this.colLN,
            this.colCityCode,
            this.colCityName,
            this.colCityNameChs,
            this.colCityNameCht});
            this.lvCityList.DataMember = null;
            this.lvCityList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvCityList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvCityList.ItemsPerPage = 20;
            this.lvCityList.Location = new System.Drawing.Point(0, 0);
            this.lvCityList.Name = "lvCityList";
            this.lvCityList.Size = new System.Drawing.Size(499, 506);
            this.lvCityList.TabIndex = 0;
            this.lvCityList.UseInternalPaging = true;
            this.lvCityList.SelectedIndexChanged += new System.EventHandler(this.lvCityList_SelectedIndexChanged);
            // 
            // colCityId
            // 
            this.colCityId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCityId.Image = null;
            this.colCityId.Text = "CityId";
            this.colCityId.Visible = false;
            this.colCityId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colCityCode
            // 
            this.colCityCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCityCode.Image = null;
            this.colCityCode.Text = "City Code";
            this.colCityCode.Width = 80;
            // 
            // colCityName
            // 
            this.colCityName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCityName.Image = null;
            this.colCityName.Text = "City Name";
            this.colCityName.Width = 120;
            // 
            // colCityNameChs
            // 
            this.colCityNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCityNameChs.Image = null;
            this.colCityNameChs.Text = "City Name Chs";
            this.colCityNameChs.Width = 120;
            // 
            // colCityNameCht
            // 
            this.colCityNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colCityNameCht.Image = null;
            this.colCityNameCht.Text = "City Name Cht";
            this.colCityNameCht.Width = 120;
            // 
            // lblProvince
            // 
            this.lblProvince.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvince.Location = new System.Drawing.Point(16, 132);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(100, 23);
            this.lblProvince.TabIndex = 9;
            this.lblProvince.Text = "Province:";
            // 
            // cboProvince
            // 
            this.cboProvince.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboProvince.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboProvince.DropDownWidth = 121;
            this.cboProvince.Location = new System.Drawing.Point(122, 129);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(142, 21);
            this.cboProvince.TabIndex = 4;
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
            this.tbWizardAction.TabIndex = 5;
            // 
            // txtCityNameCht
            // 
            this.txtCityNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCityNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtCityNameCht.Name = "txtCityNameCht";
            this.txtCityNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtCityNameCht.TabIndex = 3;
            // 
            // txtCityNameChs
            // 
            this.txtCityNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCityNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtCityNameChs.Name = "txtCityNameChs";
            this.txtCityNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtCityNameChs.TabIndex = 2;
            // 
            // txtCityName
            // 
            this.txtCityName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCityName.Location = new System.Drawing.Point(122, 60);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(142, 20);
            this.txtCityName.TabIndex = 1;
            // 
            // lblCityNameCht
            // 
            this.lblCityNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCityNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblCityNameCht.Name = "lblCityNameCht";
            this.lblCityNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblCityNameCht.TabIndex = 4;
            this.lblCityNameCht.Text = "City Name Cht";
            // 
            // lblCityNameChs
            // 
            this.lblCityNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCityNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblCityNameChs.Name = "lblCityNameChs";
            this.lblCityNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblCityNameChs.TabIndex = 3;
            this.lblCityNameChs.Text = "City Name Chs:";
            // 
            // lblCityName
            // 
            this.lblCityName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCityName.Location = new System.Drawing.Point(16, 63);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(100, 23);
            this.lblCityName.TabIndex = 2;
            this.lblCityName.Text = "City Name:";
            // 
            // txtCityCode
            // 
            this.txtCityCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtCityCode.Location = new System.Drawing.Point(122, 37);
            this.txtCityCode.MaxLength = 10;
            this.txtCityCode.Name = "txtCityCode";
            this.txtCityCode.Size = new System.Drawing.Size(142, 20);
            this.txtCityCode.TabIndex = 0;
            // 
            // lblCityCode
            // 
            this.lblCityCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCityCode.Location = new System.Drawing.Point(16, 40);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(100, 23);
            this.lblCityCode.TabIndex = 7;
            this.lblCityCode.Text = "City Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // CityWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "City Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvCityList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityName;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colCityNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtCityNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtCityNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtCityName;
        private Gizmox.WebGUI.Forms.Label lblCityNameCht;
        private Gizmox.WebGUI.Forms.Label lblCityNameChs;
        private Gizmox.WebGUI.Forms.Label lblCityName;
        private Gizmox.WebGUI.Forms.TextBox txtCityCode;
        private Gizmox.WebGUI.Forms.Label lblCityCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblProvince;
        private Gizmox.WebGUI.Forms.ComboBox cboProvince;


    }
}