namespace RT2020.Settings
{
    partial class LineOfOperationWizard
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
            this.lvLineOfOperationList = new Gizmox.WebGUI.Forms.ListView();
            this.colLineOfOperationId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLineOfOperationCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLineOfOperationName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLineOfOperationNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLineOfOperationNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.cboParentLine = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentLine = new Gizmox.WebGUI.Forms.Label();
            this.lblPrimaryLine = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryLine = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtLineOfOperationNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLineOfOperationNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLineOfOperationName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLineOfOperationNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblLineOfOperationNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblLineOfOperationName = new Gizmox.WebGUI.Forms.Label();
            this.txtLineOfOperationCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLineOfOperationCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvLineOfOperationList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboParentLine);
            this.splitContainer.Panel2.Controls.Add(this.lblParentLine);
            this.splitContainer.Panel2.Controls.Add(this.lblPrimaryLine);
            this.splitContainer.Panel2.Controls.Add(this.chkPrimaryLine);
            this.splitContainer.Panel2.Controls.Add(this.cboCurrency);
            this.splitContainer.Panel2.Controls.Add(this.lblCurrency);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationName);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationName);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationCode);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvLineOfOperationList
            // 
            this.lvLineOfOperationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colLineOfOperationId,
            this.colLN,
            this.colLineOfOperationCode,
            this.colLineOfOperationName,
            this.colLineOfOperationNameAlt1,
            this.colLineOfOperationNameAlt2});
            this.lvLineOfOperationList.DataMember = null;
            this.lvLineOfOperationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvLineOfOperationList.Location = new System.Drawing.Point(0, 0);
            this.lvLineOfOperationList.Name = "lvLineOfOperationList";
            this.lvLineOfOperationList.Size = new System.Drawing.Size(499, 506);
            this.lvLineOfOperationList.TabIndex = 0;
            this.lvLineOfOperationList.UseInternalPaging = true;
            this.lvLineOfOperationList.SelectedIndexChanged += new System.EventHandler(this.lvLineOfOperationList_SelectedIndexChanged);
            // 
            // colLineOfOperationId
            // 
            this.colLineOfOperationId.Text = "LOOId";
            this.colLineOfOperationId.Visible = false;
            this.colLineOfOperationId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colLineOfOperationCode
            // 
            this.colLineOfOperationCode.Text = "LOO Code";
            this.colLineOfOperationCode.Width = 80;
            // 
            // colLineOfOperationName
            // 
            this.colLineOfOperationName.Text = "LOO Name";
            this.colLineOfOperationName.Width = 120;
            // 
            // colLineOfOperationNameAlt1
            // 
            this.colLineOfOperationNameAlt1.Text = "LOO Name Chs";
            this.colLineOfOperationNameAlt1.Width = 120;
            // 
            // colLineOfOperationNameAlt2
            // 
            this.colLineOfOperationNameAlt2.Text = "LOO Name Cht";
            this.colLineOfOperationNameAlt2.Width = 120;
            // 
            // cboParentLine
            // 
            this.cboParentLine.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentLine.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentLine.DropDownWidth = 142;
            this.cboParentLine.Location = new System.Drawing.Point(157, 175);
            this.cboParentLine.Name = "cboParentLine";
            this.cboParentLine.Size = new System.Drawing.Size(133, 21);
            this.cboParentLine.TabIndex = 7;
            // 
            // lblParentLine
            // 
            this.lblParentLine.Location = new System.Drawing.Point(16, 178);
            this.lblParentLine.Name = "lblParentLine";
            this.lblParentLine.Size = new System.Drawing.Size(138, 23);
            this.lblParentLine.TabIndex = 13;
            this.lblParentLine.Text = "Attached To:";
            // 
            // lblPrimaryLine
            // 
            this.lblPrimaryLine.Location = new System.Drawing.Point(16, 155);
            this.lblPrimaryLine.Name = "lblPrimaryLine";
            this.lblPrimaryLine.Size = new System.Drawing.Size(138, 23);
            this.lblPrimaryLine.TabIndex = 12;
            this.lblPrimaryLine.Text = "Primary Line:";
            // 
            // chkPrimaryLine
            // 
            this.chkPrimaryLine.Location = new System.Drawing.Point(157, 154);
            this.chkPrimaryLine.Name = "chkPrimaryLine";
            this.chkPrimaryLine.Size = new System.Drawing.Size(22, 24);
            this.chkPrimaryLine.TabIndex = 6;
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(157, 129);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(133, 21);
            this.cboCurrency.TabIndex = 5;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(16, 132);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(138, 23);
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
            // txtLineOfOperationNameAlt2
            // 
            this.txtLineOfOperationNameAlt2.Location = new System.Drawing.Point(157, 106);
            this.txtLineOfOperationNameAlt2.Name = "txtLineOfOperationNameAlt2";
            this.txtLineOfOperationNameAlt2.Size = new System.Drawing.Size(133, 20);
            this.txtLineOfOperationNameAlt2.TabIndex = 4;
            // 
            // txtLineOfOperationNameAlt1
            // 
            this.txtLineOfOperationNameAlt1.Location = new System.Drawing.Point(157, 83);
            this.txtLineOfOperationNameAlt1.Name = "txtLineOfOperationNameAlt1";
            this.txtLineOfOperationNameAlt1.Size = new System.Drawing.Size(133, 20);
            this.txtLineOfOperationNameAlt1.TabIndex = 3;
            // 
            // txtLineOfOperationName
            // 
            this.txtLineOfOperationName.Location = new System.Drawing.Point(157, 60);
            this.txtLineOfOperationName.Name = "txtLineOfOperationName";
            this.txtLineOfOperationName.Size = new System.Drawing.Size(133, 20);
            this.txtLineOfOperationName.TabIndex = 2;
            // 
            // lblLineOfOperationNameAlt2
            // 
            this.lblLineOfOperationNameAlt2.Location = new System.Drawing.Point(30, 109);
            this.lblLineOfOperationNameAlt2.Name = "lblLineOfOperationNameAlt2";
            this.lblLineOfOperationNameAlt2.Size = new System.Drawing.Size(124, 23);
            this.lblLineOfOperationNameAlt2.TabIndex = 4;
            this.lblLineOfOperationNameAlt2.Text = "LOO Name Cht";
            // 
            // lblLineOfOperationNameAlt1
            // 
            this.lblLineOfOperationNameAlt1.Location = new System.Drawing.Point(30, 86);
            this.lblLineOfOperationNameAlt1.Name = "lblLineOfOperationNameAlt1";
            this.lblLineOfOperationNameAlt1.Size = new System.Drawing.Size(124, 23);
            this.lblLineOfOperationNameAlt1.TabIndex = 3;
            this.lblLineOfOperationNameAlt1.Text = "LOO Name Chs:";
            // 
            // lblLineOfOperationName
            // 
            this.lblLineOfOperationName.Location = new System.Drawing.Point(16, 63);
            this.lblLineOfOperationName.Name = "lblLineOfOperationName";
            this.lblLineOfOperationName.Size = new System.Drawing.Size(138, 23);
            this.lblLineOfOperationName.TabIndex = 2;
            this.lblLineOfOperationName.Text = "LOO Name:";
            // 
            // txtLineOfOperationCode
            // 
            this.txtLineOfOperationCode.Location = new System.Drawing.Point(157, 37);
            this.txtLineOfOperationCode.MaxLength = 10;
            this.txtLineOfOperationCode.Name = "txtLineOfOperationCode";
            this.txtLineOfOperationCode.Size = new System.Drawing.Size(133, 20);
            this.txtLineOfOperationCode.TabIndex = 1;
            // 
            // lblLineOfOperationCode
            // 
            this.lblLineOfOperationCode.Location = new System.Drawing.Point(16, 40);
            this.lblLineOfOperationCode.Name = "lblLineOfOperationCode";
            this.lblLineOfOperationCode.Size = new System.Drawing.Size(138, 23);
            this.lblLineOfOperationCode.TabIndex = 0;
            this.lblLineOfOperationCode.Text = "LOO Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // LineOfOperationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "LineOfOperation Wizard";
            this.Load += new System.EventHandler(this.LineOfOperationWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvLineOfOperationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationName;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationName;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationName;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationCode;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboParentLine;
        private Gizmox.WebGUI.Forms.Label lblParentLine;
        private Gizmox.WebGUI.Forms.Label lblPrimaryLine;
        private Gizmox.WebGUI.Forms.CheckBox chkPrimaryLine;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.Label lblCurrency;


    }
}