namespace RT2020.Settings
{
    partial class PosTenderTypeWizard
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
            this.lvPosTenderTypeList = new Gizmox.WebGUI.Forms.ListView();
            this.colPosTenderTypeId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPosTenderTypeCode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPosTenderTypeName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPosTenderTypeNameChs = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPosTenderTypeNameCht = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.lblMonthly = new Gizmox.WebGUI.Forms.Label();
            this.txtMinimumMonthlyCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMinimumMonthlyCharge = new Gizmox.WebGUI.Forms.Label();
            this.txtAdditionalMonthlyCharge = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAdditionalMonthlyCharge = new Gizmox.WebGUI.Forms.Label();
            this.txtChargeAmount = new Gizmox.WebGUI.Forms.TextBox();
            this.lblChargeAmount = new Gizmox.WebGUI.Forms.Label();
            this.txtChargeRate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblChargeRate = new Gizmox.WebGUI.Forms.Label();
            this.chkDownloadToPoS = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblDownloadToPoS = new Gizmox.WebGUI.Forms.Label();
            this.txtExchangeRate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblExchangeRate = new Gizmox.WebGUI.Forms.Label();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.txtPriority = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPriority = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtPosTenderTypeNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPosTenderTypeNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPosTenderTypeName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPosTenderTypeNameCht = new Gizmox.WebGUI.Forms.Label();
            this.lblPosTenderTypeNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblPosTenderTypeName = new Gizmox.WebGUI.Forms.Label();
            this.txtPosTenderTypeCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPosTenderTypeCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvPosTenderTypeList);
            this.splitContainer.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblMonthly);
            this.splitContainer.Panel2.Controls.Add(this.txtMinimumMonthlyCharge);
            this.splitContainer.Panel2.Controls.Add(this.lblMinimumMonthlyCharge);
            this.splitContainer.Panel2.Controls.Add(this.txtAdditionalMonthlyCharge);
            this.splitContainer.Panel2.Controls.Add(this.lblAdditionalMonthlyCharge);
            this.splitContainer.Panel2.Controls.Add(this.txtChargeAmount);
            this.splitContainer.Panel2.Controls.Add(this.lblChargeAmount);
            this.splitContainer.Panel2.Controls.Add(this.txtChargeRate);
            this.splitContainer.Panel2.Controls.Add(this.lblChargeRate);
            this.splitContainer.Panel2.Controls.Add(this.chkDownloadToPoS);
            this.splitContainer.Panel2.Controls.Add(this.lblDownloadToPoS);
            this.splitContainer.Panel2.Controls.Add(this.txtExchangeRate);
            this.splitContainer.Panel2.Controls.Add(this.lblExchangeRate);
            this.splitContainer.Panel2.Controls.Add(this.cboCurrency);
            this.splitContainer.Panel2.Controls.Add(this.lblCurrency);
            this.splitContainer.Panel2.Controls.Add(this.txtPriority);
            this.splitContainer.Panel2.Controls.Add(this.lblPriority);
            this.splitContainer.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainer.Panel2.Controls.Add(this.txtPosTenderTypeNameCht);
            this.splitContainer.Panel2.Controls.Add(this.txtPosTenderTypeNameChs);
            this.splitContainer.Panel2.Controls.Add(this.txtPosTenderTypeName);
            this.splitContainer.Panel2.Controls.Add(this.lblPosTenderTypeNameCht);
            this.splitContainer.Panel2.Controls.Add(this.lblPosTenderTypeNameChs);
            this.splitContainer.Panel2.Controls.Add(this.lblPosTenderTypeName);
            this.splitContainer.Panel2.Controls.Add(this.txtPosTenderTypeCode);
            this.splitContainer.Panel2.Controls.Add(this.lblPosTenderTypeCode);
            this.splitContainer.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.splitContainer.Size = new System.Drawing.Size(806, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // lvPosTenderTypeList
            // 
            this.lvPosTenderTypeList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvPosTenderTypeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPosTenderTypeId,
            this.colLN,
            this.colPosTenderTypeCode,
            this.colPosTenderTypeName,
            this.colPosTenderTypeNameChs,
            this.colPosTenderTypeNameCht});
            this.lvPosTenderTypeList.DataMember = null;
            this.lvPosTenderTypeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPosTenderTypeList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lvPosTenderTypeList.ItemsPerPage = 20;
            this.lvPosTenderTypeList.Location = new System.Drawing.Point(0, 0);
            this.lvPosTenderTypeList.Name = "lvPosTenderTypeList";
            this.lvPosTenderTypeList.Size = new System.Drawing.Size(499, 506);
            this.lvPosTenderTypeList.TabIndex = 0;
            this.lvPosTenderTypeList.UseInternalPaging = true;
            this.lvPosTenderTypeList.SelectedIndexChanged += new System.EventHandler(this.lvPosTenderTypeList_SelectedIndexChanged);
            // 
            // colPosTenderTypeId
            // 
            this.colPosTenderTypeId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPosTenderTypeId.Image = null;
            this.colPosTenderTypeId.Text = "TypeId";
            this.colPosTenderTypeId.Visible = false;
            this.colPosTenderTypeId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colPosTenderTypeCode
            // 
            this.colPosTenderTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPosTenderTypeCode.Image = null;
            this.colPosTenderTypeCode.Text = "Type Code";
            this.colPosTenderTypeCode.Width = 80;
            // 
            // colPosTenderTypeName
            // 
            this.colPosTenderTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPosTenderTypeName.Image = null;
            this.colPosTenderTypeName.Text = "Type Name";
            this.colPosTenderTypeName.Width = 120;
            // 
            // colPosTenderTypeNameChs
            // 
            this.colPosTenderTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPosTenderTypeNameChs.Image = null;
            this.colPosTenderTypeNameChs.Text = "Type Name Chs";
            this.colPosTenderTypeNameChs.Width = 120;
            // 
            // colPosTenderTypeNameCht
            // 
            this.colPosTenderTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPosTenderTypeNameCht.Image = null;
            this.colPosTenderTypeNameCht.Text = "Type Name Cht";
            this.colPosTenderTypeNameCht.Width = 120;
            // 
            // lblMonthly
            // 
            this.lblMonthly.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonthly.Location = new System.Drawing.Point(16, 270);
            this.lblMonthly.Name = "lblMonthly";
            this.lblMonthly.Size = new System.Drawing.Size(100, 23);
            this.lblMonthly.TabIndex = 25;
            this.lblMonthly.Text = "Monthly:";
            // 
            // txtMinimumMonthlyCharge
            // 
            this.txtMinimumMonthlyCharge.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtMinimumMonthlyCharge.Location = new System.Drawing.Point(122, 313);
            this.txtMinimumMonthlyCharge.Name = "txtMinimumMonthlyCharge";
            this.txtMinimumMonthlyCharge.Size = new System.Drawing.Size(142, 20);
            this.txtMinimumMonthlyCharge.TabIndex = 24;
            this.txtMinimumMonthlyCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblMinimumMonthlyCharge
            // 
            this.lblMinimumMonthlyCharge.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblMinimumMonthlyCharge.Location = new System.Drawing.Point(16, 316);
            this.lblMinimumMonthlyCharge.Name = "lblMinimumMonthlyCharge";
            this.lblMinimumMonthlyCharge.Size = new System.Drawing.Size(100, 23);
            this.lblMinimumMonthlyCharge.TabIndex = 23;
            this.lblMinimumMonthlyCharge.Text = "Minimum Charge:";
            // 
            // txtAdditionalMonthlyCharge
            // 
            this.txtAdditionalMonthlyCharge.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtAdditionalMonthlyCharge.Location = new System.Drawing.Point(122, 290);
            this.txtAdditionalMonthlyCharge.Name = "txtAdditionalMonthlyCharge";
            this.txtAdditionalMonthlyCharge.Size = new System.Drawing.Size(142, 20);
            this.txtAdditionalMonthlyCharge.TabIndex = 22;
            this.txtAdditionalMonthlyCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblAdditionalMonthlyCharge
            // 
            this.lblAdditionalMonthlyCharge.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblAdditionalMonthlyCharge.Location = new System.Drawing.Point(16, 293);
            this.lblAdditionalMonthlyCharge.Name = "lblAdditionalMonthlyCharge";
            this.lblAdditionalMonthlyCharge.Size = new System.Drawing.Size(100, 23);
            this.lblAdditionalMonthlyCharge.TabIndex = 21;
            this.lblAdditionalMonthlyCharge.Text = "Additional Charge:";
            // 
            // txtChargeAmount
            // 
            this.txtChargeAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtChargeAmount.Location = new System.Drawing.Point(122, 244);
            this.txtChargeAmount.Name = "txtChargeAmount";
            this.txtChargeAmount.Size = new System.Drawing.Size(142, 20);
            this.txtChargeAmount.TabIndex = 20;
            this.txtChargeAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblChargeAmount
            // 
            this.lblChargeAmount.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblChargeAmount.Location = new System.Drawing.Point(16, 247);
            this.lblChargeAmount.Name = "lblChargeAmount";
            this.lblChargeAmount.Size = new System.Drawing.Size(100, 23);
            this.lblChargeAmount.TabIndex = 19;
            this.lblChargeAmount.Text = "Charge Amount:";
            // 
            // txtChargeRate
            // 
            this.txtChargeRate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtChargeRate.Location = new System.Drawing.Point(122, 221);
            this.txtChargeRate.Name = "txtChargeRate";
            this.txtChargeRate.Size = new System.Drawing.Size(142, 20);
            this.txtChargeRate.TabIndex = 18;
            this.txtChargeRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblChargeRate
            // 
            this.lblChargeRate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblChargeRate.Location = new System.Drawing.Point(16, 224);
            this.lblChargeRate.Name = "lblChargeRate";
            this.lblChargeRate.Size = new System.Drawing.Size(100, 23);
            this.lblChargeRate.TabIndex = 17;
            this.lblChargeRate.Text = "Charge Rate:";
            // 
            // chkDownloadToPoS
            // 
            this.chkDownloadToPoS.Checked = false;
            this.chkDownloadToPoS.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkDownloadToPoS.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkDownloadToPoS.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkDownloadToPoS.Location = new System.Drawing.Point(122, 200);
            this.chkDownloadToPoS.Name = "chkDownloadToPoS";
            this.chkDownloadToPoS.Size = new System.Drawing.Size(104, 24);
            this.chkDownloadToPoS.TabIndex = 16;
            this.chkDownloadToPoS.ThreeState = false;
            // 
            // lblDownloadToPoS
            // 
            this.lblDownloadToPoS.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblDownloadToPoS.Location = new System.Drawing.Point(16, 201);
            this.lblDownloadToPoS.Name = "lblDownloadToPoS";
            this.lblDownloadToPoS.Size = new System.Drawing.Size(100, 23);
            this.lblDownloadToPoS.TabIndex = 15;
            this.lblDownloadToPoS.Text = "PoS:";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtExchangeRate.Location = new System.Drawing.Point(122, 175);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(142, 20);
            this.txtExchangeRate.TabIndex = 14;
            this.txtExchangeRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblExchangeRate.Location = new System.Drawing.Point(16, 178);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(100, 23);
            this.lblExchangeRate.TabIndex = 13;
            this.lblExchangeRate.Text = "Exchange Rate:";
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(122, 152);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(142, 21);
            this.cboCurrency.TabIndex = 12;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblCurrency.Location = new System.Drawing.Point(16, 155);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(100, 23);
            this.lblCurrency.TabIndex = 11;
            this.lblCurrency.Text = "Currency:";
            // 
            // txtPriority
            // 
            this.txtPriority.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPriority.Location = new System.Drawing.Point(122, 129);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(142, 20);
            this.txtPriority.TabIndex = 10;
            // 
            // lblPriority
            // 
            this.lblPriority.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPriority.Location = new System.Drawing.Point(16, 132);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(100, 23);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "Priority:";
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
            // txtPosTenderTypeNameCht
            // 
            this.txtPosTenderTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPosTenderTypeNameCht.Location = new System.Drawing.Point(122, 106);
            this.txtPosTenderTypeNameCht.Name = "txtPosTenderTypeNameCht";
            this.txtPosTenderTypeNameCht.Size = new System.Drawing.Size(142, 20);
            this.txtPosTenderTypeNameCht.TabIndex = 4;
            // 
            // txtPosTenderTypeNameChs
            // 
            this.txtPosTenderTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPosTenderTypeNameChs.Location = new System.Drawing.Point(122, 83);
            this.txtPosTenderTypeNameChs.Name = "txtPosTenderTypeNameChs";
            this.txtPosTenderTypeNameChs.Size = new System.Drawing.Size(142, 20);
            this.txtPosTenderTypeNameChs.TabIndex = 3;
            // 
            // txtPosTenderTypeName
            // 
            this.txtPosTenderTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPosTenderTypeName.Location = new System.Drawing.Point(122, 60);
            this.txtPosTenderTypeName.Name = "txtPosTenderTypeName";
            this.txtPosTenderTypeName.Size = new System.Drawing.Size(142, 20);
            this.txtPosTenderTypeName.TabIndex = 2;
            // 
            // lblPosTenderTypeNameCht
            // 
            this.lblPosTenderTypeNameCht.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPosTenderTypeNameCht.Location = new System.Drawing.Point(16, 109);
            this.lblPosTenderTypeNameCht.Name = "lblPosTenderTypeNameCht";
            this.lblPosTenderTypeNameCht.Size = new System.Drawing.Size(100, 23);
            this.lblPosTenderTypeNameCht.TabIndex = 4;
            this.lblPosTenderTypeNameCht.Text = "Type Name Cht";
            // 
            // lblPosTenderTypeNameChs
            // 
            this.lblPosTenderTypeNameChs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPosTenderTypeNameChs.Location = new System.Drawing.Point(16, 86);
            this.lblPosTenderTypeNameChs.Name = "lblPosTenderTypeNameChs";
            this.lblPosTenderTypeNameChs.Size = new System.Drawing.Size(100, 23);
            this.lblPosTenderTypeNameChs.TabIndex = 3;
            this.lblPosTenderTypeNameChs.Text = "Type Name Chs:";
            // 
            // lblPosTenderTypeName
            // 
            this.lblPosTenderTypeName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPosTenderTypeName.Location = new System.Drawing.Point(16, 63);
            this.lblPosTenderTypeName.Name = "lblPosTenderTypeName";
            this.lblPosTenderTypeName.Size = new System.Drawing.Size(100, 23);
            this.lblPosTenderTypeName.TabIndex = 2;
            this.lblPosTenderTypeName.Text = "Type Name:";
            // 
            // txtPosTenderTypeCode
            // 
            this.txtPosTenderTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPosTenderTypeCode.Location = new System.Drawing.Point(122, 37);
            this.txtPosTenderTypeCode.MaxLength = 10;
            this.txtPosTenderTypeCode.Name = "txtPosTenderTypeCode";
            this.txtPosTenderTypeCode.Size = new System.Drawing.Size(142, 20);
            this.txtPosTenderTypeCode.TabIndex = 1;
            // 
            // lblPosTenderTypeCode
            // 
            this.lblPosTenderTypeCode.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPosTenderTypeCode.Location = new System.Drawing.Point(16, 40);
            this.lblPosTenderTypeCode.Name = "lblPosTenderTypeCode";
            this.lblPosTenderTypeCode.Size = new System.Drawing.Size(100, 23);
            this.lblPosTenderTypeCode.TabIndex = 0;
            this.lblPosTenderTypeCode.Text = "Type Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = "";
            this.errorProvider.DataSource = "";
            // 
            // PosTenderTypeWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "PosTenderType Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvPosTenderTypeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosTenderTypeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosTenderTypeCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosTenderTypeName;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosTenderTypeNameChs;
        private Gizmox.WebGUI.Forms.ColumnHeader colPosTenderTypeNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtPosTenderTypeNameCht;
        private Gizmox.WebGUI.Forms.TextBox txtPosTenderTypeNameChs;
        private Gizmox.WebGUI.Forms.TextBox txtPosTenderTypeName;
        private Gizmox.WebGUI.Forms.Label lblPosTenderTypeNameCht;
        private Gizmox.WebGUI.Forms.Label lblPosTenderTypeNameChs;
        private Gizmox.WebGUI.Forms.Label lblPosTenderTypeName;
        private Gizmox.WebGUI.Forms.TextBox txtPosTenderTypeCode;
        private Gizmox.WebGUI.Forms.Label lblPosTenderTypeCode;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.Label lblPriority;
        private Gizmox.WebGUI.Forms.TextBox txtPriority;
        private Gizmox.WebGUI.Forms.TextBox txtMinimumMonthlyCharge;
        private Gizmox.WebGUI.Forms.Label lblMinimumMonthlyCharge;
        private Gizmox.WebGUI.Forms.TextBox txtAdditionalMonthlyCharge;
        private Gizmox.WebGUI.Forms.Label lblAdditionalMonthlyCharge;
        private Gizmox.WebGUI.Forms.TextBox txtChargeAmount;
        private Gizmox.WebGUI.Forms.Label lblChargeAmount;
        private Gizmox.WebGUI.Forms.TextBox txtChargeRate;
        private Gizmox.WebGUI.Forms.Label lblChargeRate;
        private Gizmox.WebGUI.Forms.CheckBox chkDownloadToPoS;
        private Gizmox.WebGUI.Forms.Label lblDownloadToPoS;
        private Gizmox.WebGUI.Forms.TextBox txtExchangeRate;
        private Gizmox.WebGUI.Forms.Label lblExchangeRate;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblMonthly;


    }
}