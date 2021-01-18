namespace RT2020.Product
{
    partial class AnalysisCodeWizard
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
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.lblType = new Gizmox.WebGUI.Forms.Label();
            this.txtType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMandatory = new Gizmox.WebGUI.Forms.Label();
            this.lblDownloadToPOS = new Gizmox.WebGUI.Forms.Label();
            this.chkMandatory = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkDownloadToPoS = new Gizmox.WebGUI.Forms.CheckBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // cboParentAnalysisCode
            // 
            this.cboParentAnalysisCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentAnalysisCode.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentAnalysisCode.DropDownWidth = 121;
            this.cboParentAnalysisCode.Location = new System.Drawing.Point(128, 175);
            this.cboParentAnalysisCode.Name = "cboParentAnalysisCode";
            this.cboParentAnalysisCode.Size = new System.Drawing.Size(121, 21);
            this.cboParentAnalysisCode.TabIndex = 7;
            // 
            // txtNameAlt2
            // 
            this.txtNameAlt2.Location = new System.Drawing.Point(128, 152);
            this.txtNameAlt2.Name = "txtNameAlt2";
            this.txtNameAlt2.Size = new System.Drawing.Size(279, 20);
            this.txtNameAlt2.TabIndex = 6;
            // 
            // txtNameAlt1
            // 
            this.txtNameAlt1.Location = new System.Drawing.Point(128, 129);
            this.txtNameAlt1.Name = "txtNameAlt1";
            this.txtNameAlt1.Size = new System.Drawing.Size(279, 20);
            this.txtNameAlt1.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 106);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(128, 83);
            this.txtInitial.MaxLength = 20;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(121, 20);
            this.txtInitial.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(128, 37);
            this.txtCode.MaxLength = 2;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(121, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblParentAnalysisCode
            // 
            this.lblParentAnalysisCode.Location = new System.Drawing.Point(12, 178);
            this.lblParentAnalysisCode.Name = "lblParentAnalysisCode";
            this.lblParentAnalysisCode.Size = new System.Drawing.Size(70, 23);
            this.lblParentAnalysisCode.TabIndex = 6;
            this.lblParentAnalysisCode.Text = "Attached To:";
            // 
            // lblNameAlt2
            // 
            this.lblNameAlt2.Location = new System.Drawing.Point(24, 155);
            this.lblNameAlt2.Name = "lblNameAlt2";
            this.lblNameAlt2.Size = new System.Drawing.Size(101, 23);
            this.lblNameAlt2.TabIndex = 5;
            this.lblNameAlt2.Text = "Name Cht:";
            // 
            // lblNameAlt1
            // 
            this.lblNameAlt1.Location = new System.Drawing.Point(24, 132);
            this.lblNameAlt1.Name = "lblNameAlt1";
            this.lblNameAlt1.Size = new System.Drawing.Size(101, 23);
            this.lblNameAlt1.TabIndex = 4;
            this.lblNameAlt1.Text = "Name Chs:";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 109);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 23);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblInitial
            // 
            this.lblInitial.Location = new System.Drawing.Point(12, 86);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(70, 23);
            this.lblInitial.TabIndex = 2;
            this.lblInitial.Text = "Initial:";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(12, 40);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(70, 23);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code:";
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
            this.tbWizardAction.Size = new System.Drawing.Size(419, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(70, 23);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(128, 60);
            this.txtType.MaxLength = 2;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(121, 20);
            this.txtType.TabIndex = 2;
            // 
            // lblMandatory
            // 
            this.lblMandatory.Location = new System.Drawing.Point(12, 201);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(70, 23);
            this.lblMandatory.TabIndex = 14;
            this.lblMandatory.Text = "Mandatory:";
            // 
            // lblDownloadToPOS
            // 
            this.lblDownloadToPOS.Location = new System.Drawing.Point(12, 224);
            this.lblDownloadToPOS.Name = "lblDownloadToPOS";
            this.lblDownloadToPOS.Size = new System.Drawing.Size(70, 23);
            this.lblDownloadToPOS.TabIndex = 15;
            this.lblDownloadToPOS.Text = "D.L. To PoS:";
            // 
            // chkMandatory
            // 
            this.chkMandatory.Location = new System.Drawing.Point(128, 200);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(104, 24);
            this.chkMandatory.TabIndex = 8;
            // 
            // chkDownloadToPoS
            // 
            this.chkDownloadToPoS.Enabled = false;
            this.chkDownloadToPoS.Location = new System.Drawing.Point(128, 223);
            this.chkDownloadToPoS.Name = "chkDownloadToPoS";
            this.chkDownloadToPoS.Size = new System.Drawing.Size(104, 24);
            this.chkDownloadToPoS.TabIndex = 9;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // AnalysisCodeWizard
            // 
            this.Controls.Add(this.chkDownloadToPoS);
            this.Controls.Add(this.chkMandatory);
            this.Controls.Add(this.lblDownloadToPOS);
            this.Controls.Add(this.lblMandatory);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNameAlt1);
            this.Controls.Add(this.lblNameAlt2);
            this.Controls.Add(this.lblParentAnalysisCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNameAlt1);
            this.Controls.Add(this.txtNameAlt2);
            this.Controls.Add(this.cboParentAnalysisCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "AnalysisCodeWizard";
            this.Load += new System.EventHandler(this.AnalysisCodeWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

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
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Label lblType;
        private Gizmox.WebGUI.Forms.TextBox txtType;
        private Gizmox.WebGUI.Forms.Label lblMandatory;
        private Gizmox.WebGUI.Forms.Label lblDownloadToPOS;
        private Gizmox.WebGUI.Forms.CheckBox chkMandatory;
        private Gizmox.WebGUI.Forms.CheckBox chkDownloadToPoS;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}