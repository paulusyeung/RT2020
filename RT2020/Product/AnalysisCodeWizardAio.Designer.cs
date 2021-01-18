namespace RT2020.Product
{
    partial class AnalysisCodeWizardAio
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
            this.lvList = new Gizmox.WebGUI.Forms.ListView();
            this.colCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCodeId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colType = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colInitial = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentAnalysisCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblParentAnalysisCode = new Gizmox.WebGUI.Forms.Label();
            this.lblNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblName = new Gizmox.WebGUI.Forms.Label();
            this.lblInitial = new Gizmox.WebGUI.Forms.Label();
            this.lblCode = new Gizmox.WebGUI.Forms.Label();
            this.lblType = new Gizmox.WebGUI.Forms.Label();
            this.txtType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMandatory = new Gizmox.WebGUI.Forms.Label();
            this.lblDownloadToPOS = new Gizmox.WebGUI.Forms.Label();
            this.chkMandatory = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkDownloadToPoS = new Gizmox.WebGUI.Forms.CheckBox();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
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
            this.splitContainer.Panel1.Controls.Add(this.lvList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentAnalysisCode);
            this.splitContainer.Panel2.Controls.Add(this.txtNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtName);
            this.splitContainer.Panel2.Controls.Add(this.txtInitial);
            this.splitContainer.Panel2.Controls.Add(this.txtCode);
            this.splitContainer.Panel2.Controls.Add(this.lblParentAnalysisCode);
            this.splitContainer.Panel2.Controls.Add(this.lblNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblName);
            this.splitContainer.Panel2.Controls.Add(this.lblInitial);
            this.splitContainer.Panel2.Controls.Add(this.lblCode);
            this.splitContainer.Panel2.Controls.Add(this.lblType);
            this.splitContainer.Panel2.Controls.Add(this.txtType);
            this.splitContainer.Panel2.Controls.Add(this.lblMandatory);
            this.splitContainer.Panel2.Controls.Add(this.lblDownloadToPOS);
            this.splitContainer.Panel2.Controls.Add(this.chkMandatory);
            this.splitContainer.Panel2.Controls.Add(this.chkDownloadToPoS);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 534;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // lvList
            // 
            this.lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCode,
            this.colCodeId,
            this.colLN,
            this.colType,
            this.colInitial,
            this.colName,
            this.colNameAlt1,
            this.colNameAlt2});
            this.lvList.DataMember = null;
            this.lvList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvList.Location = new System.Drawing.Point(0, 0);
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(534, 506);
            this.lvList.TabIndex = 0;
            this.lvList.UseInternalPaging = true;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 60;
            // 
            // colCodeId
            // 
            this.colCodeId.Text = "Code Id";
            this.colCodeId.Visible = false;
            this.colCodeId.Width = 100;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 60;
            // 
            // colInitial
            // 
            this.colInitial.Tag = "";
            this.colInitial.Text = "Initial";
            this.colInitial.Width = 80;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colNameAlt1
            // 
            this.colNameAlt1.Text = "Name Alt1";
            this.colNameAlt1.Width = 100;
            // 
            // colNameAlt2
            // 
            this.colNameAlt2.Text = "Name Alt2";
            this.colNameAlt2.Width = 100;
            // 
            // cboParentAnalysisCode
            // 
            this.cboParentAnalysisCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentAnalysisCode.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentAnalysisCode.DropDownWidth = 121;
            this.cboParentAnalysisCode.Location = new System.Drawing.Point(128, 167);
            this.cboParentAnalysisCode.Name = "cboParentAnalysisCode";
            this.cboParentAnalysisCode.Size = new System.Drawing.Size(130, 21);
            this.cboParentAnalysisCode.TabIndex = 7;
            // 
            // txtNameAlt2
            // 
            this.txtNameAlt2.Location = new System.Drawing.Point(128, 144);
            this.txtNameAlt2.Name = "txtNameAlt2";
            this.txtNameAlt2.Size = new System.Drawing.Size(130, 20);
            this.txtNameAlt2.TabIndex = 6;
            // 
            // txtNameAlt1
            // 
            this.txtNameAlt1.Location = new System.Drawing.Point(128, 121);
            this.txtNameAlt1.Name = "txtNameAlt1";
            this.txtNameAlt1.Size = new System.Drawing.Size(130, 20);
            this.txtNameAlt1.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 98);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(128, 75);
            this.txtInitial.MaxLength = 20;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(130, 20);
            this.txtInitial.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(128, 29);
            this.txtCode.MaxLength = 2;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(130, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblParentAnalysisCode
            // 
            this.lblParentAnalysisCode.Location = new System.Drawing.Point(11, 170);
            this.lblParentAnalysisCode.Name = "lblParentAnalysisCode";
            this.lblParentAnalysisCode.Size = new System.Drawing.Size(114, 23);
            this.lblParentAnalysisCode.TabIndex = 6;
            this.lblParentAnalysisCode.Text = "Attached To:";
            // 
            // lblNameAlt2
            // 
            this.lblNameAlt2.Location = new System.Drawing.Point(25, 147);
            this.lblNameAlt2.Name = "lblNameAlt2";
            this.lblNameAlt2.Size = new System.Drawing.Size(100, 23);
            this.lblNameAlt2.TabIndex = 5;
            this.lblNameAlt2.Text = "Name Cht:";
            // 
            // lblNameAlt1
            // 
            this.lblNameAlt1.Location = new System.Drawing.Point(25, 124);
            this.lblNameAlt1.Name = "lblNameAlt1";
            this.lblNameAlt1.Size = new System.Drawing.Size(100, 23);
            this.lblNameAlt1.TabIndex = 4;
            this.lblNameAlt1.Text = "Name Chs:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(11, 101);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(114, 23);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblInitial
            // 
            this.lblInitial.Location = new System.Drawing.Point(11, 78);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(114, 23);
            this.lblInitial.TabIndex = 2;
            this.lblInitial.Text = "Initial:";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(11, 32);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(114, 23);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(11, 55);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(114, 23);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(128, 52);
            this.txtType.MaxLength = 2;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(130, 20);
            this.txtType.TabIndex = 2;
            // 
            // lblMandatory
            // 
            this.lblMandatory.Location = new System.Drawing.Point(11, 193);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(114, 23);
            this.lblMandatory.TabIndex = 14;
            this.lblMandatory.Text = "Mandatory:";
            // 
            // lblDownloadToPOS
            // 
            this.lblDownloadToPOS.Location = new System.Drawing.Point(11, 216);
            this.lblDownloadToPOS.Name = "lblDownloadToPOS";
            this.lblDownloadToPOS.Size = new System.Drawing.Size(114, 23);
            this.lblDownloadToPOS.TabIndex = 15;
            this.lblDownloadToPOS.Text = "D.L. To PoS:";
            // 
            // chkMandatory
            // 
            this.chkMandatory.Location = new System.Drawing.Point(128, 192);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(104, 24);
            this.chkMandatory.TabIndex = 8;
            // 
            // chkDownloadToPoS
            // 
            this.chkDownloadToPoS.Enabled = false;
            this.chkDownloadToPoS.Location = new System.Drawing.Point(128, 215);
            this.chkDownloadToPoS.Name = "chkDownloadToPoS";
            this.chkDownloadToPoS.Size = new System.Drawing.Size(104, 24);
            this.chkDownloadToPoS.TabIndex = 9;
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
            this.tbWizardAction.Size = new System.Drawing.Size(270, 26);
            this.tbWizardAction.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // AnalysisCodeWizardAio
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Tag for Workplace Wizard";
            this.Load += new System.EventHandler(this.AnalysisCodeWizardAio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCodeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colName;
        private Gizmox.WebGUI.Forms.ColumnHeader colNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colNameAlt2;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ColumnHeader colInitial;
        private Gizmox.WebGUI.Forms.ComboBox cboParentAnalysisCode;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtName;
        private Gizmox.WebGUI.Forms.TextBox txtInitial;
        private Gizmox.WebGUI.Forms.TextBox txtCode;
        private Gizmox.WebGUI.Forms.Label lblParentAnalysisCode;
        private Gizmox.WebGUI.Forms.Label lblNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblName;
        private Gizmox.WebGUI.Forms.Label lblInitial;
        private Gizmox.WebGUI.Forms.Label lblCode;
        private Gizmox.WebGUI.Forms.Label lblType;
        private Gizmox.WebGUI.Forms.TextBox txtType;
        private Gizmox.WebGUI.Forms.Label lblMandatory;
        private Gizmox.WebGUI.Forms.Label lblDownloadToPOS;
        private Gizmox.WebGUI.Forms.CheckBox chkMandatory;
        private Gizmox.WebGUI.Forms.CheckBox chkDownloadToPoS;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;
    }
}