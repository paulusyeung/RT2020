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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvProvinceList = new Gizmox.WebGUI.Forms.ListView();
            this.colProvinceId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProvinceCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProvinceName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProvinceNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colProvinceNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboCountry = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCountry = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtProvinceNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProvinceNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProvinceName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvinceNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblProvinceNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblProvinceName = new Gizmox.WebGUI.Forms.Label();
            this.txtProvinceCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvinceCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvProvinceList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboCountry);
            this.splitContainer.Panel2.Controls.Add(this.lblCountry);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceName);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceName);
            this.splitContainer.Panel2.Controls.Add(this.txtProvinceCode);
            this.splitContainer.Panel2.Controls.Add(this.lblProvinceCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvProvinceList
            // 
            this.lvProvinceList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvProvinceList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colProvinceId,
            this.colLN,
            this.colProvinceCode,
            this.colProvinceName,
            this.colProvinceNameChs,
            this.colProvinceNameCht});
            this.lvProvinceList.DataMember = null;
            this.lvProvinceList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvProvinceList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvProvinceList.ItemsPerPage = 20;
            this.lvProvinceList.Location = new System.Drawing.Point(0, 0);
            this.lvProvinceList.Name = "lvProvinceList";
            this.lvProvinceList.Size = new System.Drawing.Size(499, 506);
            this.lvProvinceList.TabIndex = 0;
            this.lvProvinceList.UseInternalPaging = true;
            this.lvProvinceList.SelectedIndexChanged += new System.EventHandler(this.lvProvinceList_SelectedIndexChanged);
            // 
            // colProvinceId
            // 
            this.colProvinceId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProvinceId.Image = null;
            this.colProvinceId.Text = "ProvinceId";
            this.colProvinceId.Visible = false;
            this.colProvinceId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colProvinceCode
            // 
            this.colProvinceCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProvinceCode.Image = null;
            this.colProvinceCode.Text = "Province Code";
            this.colProvinceCode.Width = 80;
            // 
            // colProvinceName
            // 
            this.colProvinceName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProvinceName.Image = null;
            this.colProvinceName.Text = "Province Name";
            this.colProvinceName.Width = 120;
            // 
            // colProvinceNameChs
            // 
            this.colProvinceNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProvinceNameChs.Image = null;
            this.colProvinceNameChs.Text = "Province Name Chs";
            this.colProvinceNameChs.Width = 120;
            // 
            // colProvinceNameCht
            // 
            this.colProvinceNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colProvinceNameCht.Image = null;
            this.colProvinceNameCht.Text = "Province Name Cht";
            this.colProvinceNameCht.Width = 120;
            // 
            // cboCountry
            // 
            this.cboCountry.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCountry.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCountry.DropDownWidth = 121;
            this.cboCountry.Location = new System.Drawing.Point(122, 129);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(142, 21);
            this.cboCountry.TabIndex = 5;
            // 
            // lblCountry
            // 
            this.lblCountry.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCountry.Location = new System.Drawing.Point(16, 132);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(100, 23);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "Country:";
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
            // txtProvinceNameCht
            // 
            this.txtProvinceNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProvinceNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtProvinceNameCht.Name = "txtProvinceNameCht";
            this.txtProvinceNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceNameCht.TabIndex = 4;
            // 
            // txtProvinceNameChs
            // 
            this.txtProvinceNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProvinceNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtProvinceNameChs.Name = "txtProvinceNameChs";
            this.txtProvinceNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceNameChs.TabIndex = 3;
            // 
            // txtProvinceName
            // 
            this.txtProvinceName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProvinceName.Location = new System.Drawing.Point(122, 60);
            this.txtProvinceName.Name = "txtProvinceName";
            this.txtProvinceName.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceName.TabIndex = 2;
            // 
            // lblProvinceNameCht
            // 
            this.lblProvinceNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvinceNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblProvinceNameCht.Name = "lblProvinceNameCht";
            this.lblProvinceNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblProvinceNameCht.TabIndex = 4;
            this.lblProvinceNameCht.Text = "Province Name Cht";
            // 
            // lblProvinceNameChs
            // 
            this.lblProvinceNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvinceNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblProvinceNameChs.Name = "lblProvinceNameChs";
            this.lblProvinceNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblProvinceNameChs.TabIndex = 3;
            this.lblProvinceNameChs.Text = "Province Name Chs:";
            // 
            // lblProvinceName
            // 
            this.lblProvinceName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvinceName.Location = new System.Drawing.Point(16, 63);
            this.lblProvinceName.Name = "lblProvinceName";
            this.lblProvinceName.Size = new System.Drawing.Size(100, 23);
            this.lblProvinceName.TabIndex = 2;
            this.lblProvinceName.Text = "Province Name:";
            // 
            // txtProvinceCode
            // 
            this.txtProvinceCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtProvinceCode.Location = new System.Drawing.Point(122, 37);
            this.txtProvinceCode.MaxLength = 10;
            this.txtProvinceCode.Name = "txtProvinceCode";
            this.txtProvinceCode.Size = new System.Drawing.Size(142, 20);
            this.txtProvinceCode.TabIndex = 1;
            // 
            // lblProvinceCode
            // 
            this.lblProvinceCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblProvinceCode.Location = new System.Drawing.Point(16, 40);
            this.lblProvinceCode.Name = "lblProvinceCode";
            this.lblProvinceCode.Size = new System.Drawing.Size(100, 23);
            this.lblProvinceCode.TabIndex = 0;
            this.lblProvinceCode.Text = "Province Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // ProvinceWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Province Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvProvinceList;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceName;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colProvinceNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceName;
        private Gizmox.WebGUI.Forms.Label lblProvinceNameCht;
        private Gizmox.WebGUI.Forms.Label lblProvinceNameChs;
        private Gizmox.WebGUI.Forms.Label lblProvinceName;
        private Gizmox.WebGUI.Forms.TextBox txtProvinceCode;
        private Gizmox.WebGUI.Forms.Label lblProvinceCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblCountry;
        private Gizmox.WebGUI.Forms.ComboBox cboCountry;


    }
}