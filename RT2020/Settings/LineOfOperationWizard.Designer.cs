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
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvLineOfOperationList = new Gizmox.WebGUI.Forms.ListView();
            this.colLineOfOperationId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineOfOperationCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineOfOperationName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineOfOperationNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLineOfOperationNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.cboParentLine = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblParentLine = new Gizmox.WebGUI.Forms.Label();
            this.lblPrimaryLine = new Gizmox.WebGUI.Forms.Label();
            this.chkPrimaryLine = new Gizmox.WebGUI.Forms.CheckBox();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtLineOfOperationNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLineOfOperationNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLineOfOperationName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLineOfOperationNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblLineOfOperationNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblLineOfOperationName = new Gizmox.WebGUI.Forms.Label();
            this.txtLineOfOperationCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLineOfOperationCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvLineOfOperationList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
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
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationName);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationName);
            this.splitContainer.Panel2.Controls.Add(this.txtLineOfOperationCode);
            this.splitContainer.Panel2.Controls.Add(this.lblLineOfOperationCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvLineOfOperationList
            // 
            this.lvLineOfOperationList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvLineOfOperationList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colLineOfOperationId,
            this.colLN,
            this.colLineOfOperationCode,
            this.colLineOfOperationName,
            this.colLineOfOperationNameChs,
            this.colLineOfOperationNameCht});
            this.lvLineOfOperationList.DataMember = null;
            this.lvLineOfOperationList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvLineOfOperationList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvLineOfOperationList.ItemsPerPage = 20;
            this.lvLineOfOperationList.Location = new System.Drawing.Point(0, 0);
            this.lvLineOfOperationList.Name = "lvLineOfOperationList";
            this.lvLineOfOperationList.Size = new System.Drawing.Size(499, 506);
            this.lvLineOfOperationList.TabIndex = 0;
            this.lvLineOfOperationList.UseInternalPaging = true;
            this.lvLineOfOperationList.SelectedIndexChanged += new System.EventHandler(this.lvLineOfOperationList_SelectedIndexChanged);
            // 
            // colLineOfOperationId
            // 
            this.colLineOfOperationId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLineOfOperationId.Image = null;
            this.colLineOfOperationId.Text = "LOOId";
            this.colLineOfOperationId.Visible = false;
            this.colLineOfOperationId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colLineOfOperationCode
            // 
            this.colLineOfOperationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLineOfOperationCode.Image = null;
            this.colLineOfOperationCode.Text = "LOO Code";
            this.colLineOfOperationCode.Width = 80;
            // 
            // colLineOfOperationName
            // 
            this.colLineOfOperationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLineOfOperationName.Image = null;
            this.colLineOfOperationName.Text = "LOO Name";
            this.colLineOfOperationName.Width = 120;
            // 
            // colLineOfOperationNameChs
            // 
            this.colLineOfOperationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLineOfOperationNameChs.Image = null;
            this.colLineOfOperationNameChs.Text = "LOO Name Chs";
            this.colLineOfOperationNameChs.Width = 120;
            // 
            // colLineOfOperationNameCht
            // 
            this.colLineOfOperationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLineOfOperationNameCht.Image = null;
            this.colLineOfOperationNameCht.Text = "LOO Name Cht";
            this.colLineOfOperationNameCht.Width = 120;
            // 
            // cboParentLine
            // 
            this.cboParentLine.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboParentLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboParentLine.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboParentLine.DropDownWidth = 142;
            this.cboParentLine.Location = new System.Drawing.Point(122, 175);
            this.cboParentLine.Name = "cboParentLine";
            this.cboParentLine.Size = new System.Drawing.Size(142, 21);
            this.cboParentLine.TabIndex = 7;
            // 
            // lblParentLine
            // 
            this.lblParentLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblParentLine.Location = new System.Drawing.Point(16, 178);
            this.lblParentLine.Name = "lblParentLine";
            this.lblParentLine.Size = new System.Drawing.Size(100, 23);
            this.lblParentLine.TabIndex = 13;
            this.lblParentLine.Text = "Attached To:";
            // 
            // lblPrimaryLine
            // 
            this.lblPrimaryLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPrimaryLine.Location = new System.Drawing.Point(16, 155);
            this.lblPrimaryLine.Name = "lblPrimaryLine";
            this.lblPrimaryLine.Size = new System.Drawing.Size(100, 23);
            this.lblPrimaryLine.TabIndex = 12;
            this.lblPrimaryLine.Text = "Primary Line:";
            // 
            // chkPrimaryLine
            // 
            this.chkPrimaryLine.Checked = false;
            this.chkPrimaryLine.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkPrimaryLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkPrimaryLine.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkPrimaryLine.Location = new System.Drawing.Point(122, 154);
            this.chkPrimaryLine.Name = "chkPrimaryLine";
            this.chkPrimaryLine.Size = new System.Drawing.Size(22, 24);
            this.chkPrimaryLine.TabIndex = 6;
            this.chkPrimaryLine.ThreeState = false;
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(122, 129);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(142, 21);
            this.cboCurrency.TabIndex = 5;
            // 
            // lblCurrency
            // 
            this.lblCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCurrency.Location = new System.Drawing.Point(16, 132);
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
            // txtLineOfOperationNameCht
            // 
            this.txtLineOfOperationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLineOfOperationNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtLineOfOperationNameCht.Name = "txtLineOfOperationNameCht";
            this.txtLineOfOperationNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtLineOfOperationNameCht.TabIndex = 4;
            // 
            // txtLineOfOperationNameChs
            // 
            this.txtLineOfOperationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLineOfOperationNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtLineOfOperationNameChs.Name = "txtLineOfOperationNameChs";
            this.txtLineOfOperationNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtLineOfOperationNameChs.TabIndex = 3;
            // 
            // txtLineOfOperationName
            // 
            this.txtLineOfOperationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLineOfOperationName.Location = new System.Drawing.Point(122, 60);
            this.txtLineOfOperationName.Name = "txtLineOfOperationName";
            this.txtLineOfOperationName.Size = new System.Drawing.Size(142, 20);
            this.txtLineOfOperationName.TabIndex = 2;
            // 
            // lblLineOfOperationNameCht
            // 
            this.lblLineOfOperationNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLineOfOperationNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblLineOfOperationNameCht.Name = "lblLineOfOperationNameCht";
            this.lblLineOfOperationNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblLineOfOperationNameCht.TabIndex = 4;
            this.lblLineOfOperationNameCht.Text = "LOO Name Cht";
            // 
            // lblLineOfOperationNameChs
            // 
            this.lblLineOfOperationNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLineOfOperationNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblLineOfOperationNameChs.Name = "lblLineOfOperationNameChs";
            this.lblLineOfOperationNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblLineOfOperationNameChs.TabIndex = 3;
            this.lblLineOfOperationNameChs.Text = "LOO Name Chs:";
            // 
            // lblLineOfOperationName
            // 
            this.lblLineOfOperationName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLineOfOperationName.Location = new System.Drawing.Point(16, 63);
            this.lblLineOfOperationName.Name = "lblLineOfOperationName";
            this.lblLineOfOperationName.Size = new System.Drawing.Size(100, 23);
            this.lblLineOfOperationName.TabIndex = 2;
            this.lblLineOfOperationName.Text = "LOO Name:";
            // 
            // txtLineOfOperationCode
            // 
            this.txtLineOfOperationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtLineOfOperationCode.Location = new System.Drawing.Point(122, 37);
            this.txtLineOfOperationCode.MaxLength = 10;
            this.txtLineOfOperationCode.Name = "txtLineOfOperationCode";
            this.txtLineOfOperationCode.Size = new System.Drawing.Size(142, 20);
            this.txtLineOfOperationCode.TabIndex = 1;
            // 
            // lblLineOfOperationCode
            // 
            this.lblLineOfOperationCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblLineOfOperationCode.Location = new System.Drawing.Point(16, 40);
            this.lblLineOfOperationCode.Name = "lblLineOfOperationCode";
            this.lblLineOfOperationCode.Size = new System.Drawing.Size(100, 23);
            this.lblLineOfOperationCode.TabIndex = 0;
            this.lblLineOfOperationCode.Text = "LOO Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // LineOfOperationWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "LineOfOperation Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvLineOfOperationList;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationName;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colLineOfOperationNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtLineOfOperationName;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationNameCht;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperationNameChs;
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