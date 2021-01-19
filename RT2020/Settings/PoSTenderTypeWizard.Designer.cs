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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvPosTenderTypeList = new Gizmox.WebGUI.Forms.ListView();
            this.colTypeId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeNameAlt1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTypeNameAlt2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
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
            this.txtTypeNameAlt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTypeNameAlt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTypeName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTypeNameAlt2 = new Gizmox.WebGUI.Forms.Label();
            this.lblTypeNameAlt1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTypeName = new Gizmox.WebGUI.Forms.Label();
            this.txtTypeCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTypeCode = new Gizmox.WebGUI.Forms.Label();
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
            this.splitContainer.Panel1.Controls.Add(this.lvPosTenderTypeList);
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
            this.splitContainer.Panel2.Controls.Add(this.txtTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeName);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeNameAlt2);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeNameAlt1);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeName);
            this.splitContainer.Panel2.Controls.Add(this.txtTypeCode);
            this.splitContainer.Panel2.Controls.Add(this.lblTypeCode);
            this.splitContainer.Size = new System.Drawing.Size(806, 460);
            this.splitContainer.SplitterDistance = 540;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // lvPosTenderTypeList
            // 
            this.lvPosTenderTypeList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTypeId,
            this.colLN,
            this.colTypeCode,
            this.colTypeName,
            this.colTypeNameAlt1,
            this.colTypeNameAlt2});
            this.lvPosTenderTypeList.DataMember = null;
            this.lvPosTenderTypeList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvPosTenderTypeList.Location = new System.Drawing.Point(0, 0);
            this.lvPosTenderTypeList.Name = "lvPosTenderTypeList";
            this.lvPosTenderTypeList.Size = new System.Drawing.Size(540, 450);
            this.lvPosTenderTypeList.TabIndex = 0;
            this.lvPosTenderTypeList.UseInternalPaging = true;
            this.lvPosTenderTypeList.SelectedIndexChanged += new System.EventHandler(this.lvPosTenderTypeList_SelectedIndexChanged);
            // 
            // colTypeId
            // 
            this.colTypeId.Text = "TypeId";
            this.colTypeId.Visible = false;
            this.colTypeId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTypeCode
            // 
            this.colTypeCode.Text = "Type Code";
            this.colTypeCode.Width = 80;
            // 
            // colTypeName
            // 
            this.colTypeName.Text = "Type Name";
            this.colTypeName.Width = 120;
            // 
            // colTypeNameAlt1
            // 
            this.colTypeNameAlt1.Text = "Type Name Chs";
            this.colTypeNameAlt1.Width = 120;
            // 
            // colTypeNameAlt2
            // 
            this.colTypeNameAlt2.Text = "Type Name Cht";
            this.colTypeNameAlt2.Width = 120;
            // 
            // lblMonthly
            // 
            this.lblMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonthly.Location = new System.Drawing.Point(13, 277);
            this.lblMonthly.Name = "lblMonthly";
            this.lblMonthly.Size = new System.Drawing.Size(112, 23);
            this.lblMonthly.TabIndex = 25;
            this.lblMonthly.Text = "Monthly:";
            // 
            // txtMinimumMonthlyCharge
            // 
            this.txtMinimumMonthlyCharge.Location = new System.Drawing.Point(128, 320);
            this.txtMinimumMonthlyCharge.Name = "txtMinimumMonthlyCharge";
            this.txtMinimumMonthlyCharge.Size = new System.Drawing.Size(120, 20);
            this.txtMinimumMonthlyCharge.TabIndex = 24;
            this.txtMinimumMonthlyCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblMinimumMonthlyCharge
            // 
            this.lblMinimumMonthlyCharge.Location = new System.Drawing.Point(25, 323);
            this.lblMinimumMonthlyCharge.Name = "lblMinimumMonthlyCharge";
            this.lblMinimumMonthlyCharge.Size = new System.Drawing.Size(100, 23);
            this.lblMinimumMonthlyCharge.TabIndex = 23;
            this.lblMinimumMonthlyCharge.Text = "Minimum Charge:";
            // 
            // txtAdditionalMonthlyCharge
            // 
            this.txtAdditionalMonthlyCharge.Location = new System.Drawing.Point(128, 297);
            this.txtAdditionalMonthlyCharge.Name = "txtAdditionalMonthlyCharge";
            this.txtAdditionalMonthlyCharge.Size = new System.Drawing.Size(120, 20);
            this.txtAdditionalMonthlyCharge.TabIndex = 22;
            this.txtAdditionalMonthlyCharge.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblAdditionalMonthlyCharge
            // 
            this.lblAdditionalMonthlyCharge.Location = new System.Drawing.Point(25, 300);
            this.lblAdditionalMonthlyCharge.Name = "lblAdditionalMonthlyCharge";
            this.lblAdditionalMonthlyCharge.Size = new System.Drawing.Size(100, 23);
            this.lblAdditionalMonthlyCharge.TabIndex = 21;
            this.lblAdditionalMonthlyCharge.Text = "Additional Charge:";
            // 
            // txtChargeAmount
            // 
            this.txtChargeAmount.Location = new System.Drawing.Point(128, 251);
            this.txtChargeAmount.Name = "txtChargeAmount";
            this.txtChargeAmount.Size = new System.Drawing.Size(120, 20);
            this.txtChargeAmount.TabIndex = 20;
            this.txtChargeAmount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblChargeAmount
            // 
            this.lblChargeAmount.Location = new System.Drawing.Point(13, 254);
            this.lblChargeAmount.Name = "lblChargeAmount";
            this.lblChargeAmount.Size = new System.Drawing.Size(112, 23);
            this.lblChargeAmount.TabIndex = 19;
            this.lblChargeAmount.Text = "Charge Amount:";
            // 
            // txtChargeRate
            // 
            this.txtChargeRate.Location = new System.Drawing.Point(128, 228);
            this.txtChargeRate.Name = "txtChargeRate";
            this.txtChargeRate.Size = new System.Drawing.Size(120, 20);
            this.txtChargeRate.TabIndex = 18;
            this.txtChargeRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblChargeRate
            // 
            this.lblChargeRate.Location = new System.Drawing.Point(13, 231);
            this.lblChargeRate.Name = "lblChargeRate";
            this.lblChargeRate.Size = new System.Drawing.Size(112, 23);
            this.lblChargeRate.TabIndex = 17;
            this.lblChargeRate.Text = "Charge Rate:";
            // 
            // chkDownloadToPoS
            // 
            this.chkDownloadToPoS.Location = new System.Drawing.Point(128, 204);
            this.chkDownloadToPoS.Name = "chkDownloadToPoS";
            this.chkDownloadToPoS.Size = new System.Drawing.Size(104, 20);
            this.chkDownloadToPoS.TabIndex = 16;
            // 
            // lblDownloadToPoS
            // 
            this.lblDownloadToPoS.Location = new System.Drawing.Point(13, 204);
            this.lblDownloadToPoS.Name = "lblDownloadToPoS";
            this.lblDownloadToPoS.Size = new System.Drawing.Size(112, 20);
            this.lblDownloadToPoS.TabIndex = 15;
            this.lblDownloadToPoS.Text = "PoS:";
            this.lblDownloadToPoS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(128, 179);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(120, 20);
            this.txtExchangeRate.TabIndex = 14;
            this.txtExchangeRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.Location = new System.Drawing.Point(13, 182);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(112, 23);
            this.lblExchangeRate.TabIndex = 13;
            this.lblExchangeRate.Text = "Exchange Rate:";
            // 
            // cboCurrency
            // 
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DropDownWidth = 142;
            this.cboCurrency.Location = new System.Drawing.Point(128, 154);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(120, 21);
            this.cboCurrency.TabIndex = 12;
            this.cboCurrency.SelectedIndexChanged += new System.EventHandler(this.cboCurrency_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(13, 157);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(112, 23);
            this.lblCurrency.TabIndex = 11;
            this.lblCurrency.Text = "Currency:";
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(128, 130);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(120, 20);
            this.txtPriority.TabIndex = 10;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(13, 133);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(112, 23);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "Priority:";
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
            this.tbWizardAction.Size = new System.Drawing.Size(264, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // txtTypeNameAlt2
            // 
            this.txtTypeNameAlt2.Location = new System.Drawing.Point(128, 107);
            this.txtTypeNameAlt2.Name = "txtTypeNameAlt2";
            this.txtTypeNameAlt2.Size = new System.Drawing.Size(120, 20);
            this.txtTypeNameAlt2.TabIndex = 4;
            // 
            // txtTypeNameAlt1
            // 
            this.txtTypeNameAlt1.Location = new System.Drawing.Point(128, 84);
            this.txtTypeNameAlt1.Name = "txtTypeNameAlt1";
            this.txtTypeNameAlt1.Size = new System.Drawing.Size(120, 20);
            this.txtTypeNameAlt1.TabIndex = 3;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(128, 61);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(120, 20);
            this.txtTypeName.TabIndex = 2;
            // 
            // lblTypeNameAlt2
            // 
            this.lblTypeNameAlt2.Location = new System.Drawing.Point(25, 110);
            this.lblTypeNameAlt2.Name = "lblTypeNameAlt2";
            this.lblTypeNameAlt2.Size = new System.Drawing.Size(100, 23);
            this.lblTypeNameAlt2.TabIndex = 4;
            this.lblTypeNameAlt2.Text = "Type Name Cht";
            // 
            // lblTypeNameAlt1
            // 
            this.lblTypeNameAlt1.Location = new System.Drawing.Point(25, 87);
            this.lblTypeNameAlt1.Name = "lblTypeNameAlt1";
            this.lblTypeNameAlt1.Size = new System.Drawing.Size(100, 23);
            this.lblTypeNameAlt1.TabIndex = 3;
            this.lblTypeNameAlt1.Text = "Type Name Chs:";
            // 
            // lblTypeName
            // 
            this.lblTypeName.Location = new System.Drawing.Point(13, 64);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(112, 23);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "Type Name:";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.Location = new System.Drawing.Point(128, 38);
            this.txtTypeCode.MaxLength = 10;
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.Size = new System.Drawing.Size(120, 20);
            this.txtTypeCode.TabIndex = 1;
            // 
            // lblTypeCode
            // 
            this.lblTypeCode.Location = new System.Drawing.Point(13, 41);
            this.lblTypeCode.Name = "lblTypeCode";
            this.lblTypeCode.Size = new System.Drawing.Size(112, 23);
            this.lblTypeCode.TabIndex = 0;
            this.lblTypeCode.Text = "Type Code:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // PosTenderTypeWizard
            // 
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 450);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "PosTenderType Wizard";
            this.Load += new System.EventHandler(this.PosTenderTypeWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.ListView lvPosTenderTypeList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeName;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeNameAlt1;
        private Gizmox.WebGUI.Forms.ColumnHeader colTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTypeNameAlt2;
        private Gizmox.WebGUI.Forms.TextBox txtTypeNameAlt1;
        private Gizmox.WebGUI.Forms.TextBox txtTypeName;
        private Gizmox.WebGUI.Forms.Label lblTypeNameAlt2;
        private Gizmox.WebGUI.Forms.Label lblTypeNameAlt1;
        private Gizmox.WebGUI.Forms.Label lblTypeName;
        private Gizmox.WebGUI.Forms.TextBox txtTypeCode;
        private Gizmox.WebGUI.Forms.Label lblTypeCode;
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