namespace RT2020.Settings
{
    partial class PaymentFactor
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
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.cboWorkplace = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblWorkplace = new Gizmox.WebGUI.Forms.Label();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.lblCurrency = new Gizmox.WebGUI.Forms.Label();
            this.lblStartDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpStartDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblEndDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpEndDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFactorRate = new Gizmox.WebGUI.Forms.Label();
            this.txtFactorRate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFactorRatePcn = new Gizmox.WebGUI.Forms.Label();
            this.lblLastUpdated = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUpdatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdatedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboCurrency = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboEventCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblEventCode = new Gizmox.WebGUI.Forms.Label();
            this.splitContainerMain = new Gizmox.WebGUI.Forms.SplitContainer();
            this.lvPaymentFactor = new Gizmox.WebGUI.Forms.ListView();
            this.colPaymentFactorId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colWorkplaceId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colWorkplace = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCurrencyAndEventCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStartDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colEndDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colFactor = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCreatedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colModifiedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            this.tbWizardAction.Size = new System.Drawing.Size(312, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboWorkplace.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboWorkplace.DropDownWidth = 121;
            this.cboWorkplace.Location = new System.Drawing.Point(126, 62);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(121, 21);
            this.cboWorkplace.TabIndex = 1;
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.Location = new System.Drawing.Point(20, 65);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplace.TabIndex = 2;
            this.lblWorkplace.Text = "Workplace:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(20, 88);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(100, 23);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(20, 111);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(100, 23);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(126, 108);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(20, 134);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(100, 23);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(126, 131);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblFactorRate
            // 
            this.lblFactorRate.Location = new System.Drawing.Point(20, 157);
            this.lblFactorRate.Name = "lblFactorRate";
            this.lblFactorRate.Size = new System.Drawing.Size(100, 23);
            this.lblFactorRate.TabIndex = 6;
            this.lblFactorRate.Text = "Factor Rate:";
            // 
            // txtFactorRate
            // 
            this.txtFactorRate.Location = new System.Drawing.Point(126, 154);
            this.txtFactorRate.Name = "txtFactorRate";
            this.txtFactorRate.Size = new System.Drawing.Size(121, 20);
            this.txtFactorRate.TabIndex = 7;
            this.txtFactorRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblFactorRatePcn
            // 
            this.lblFactorRatePcn.Location = new System.Drawing.Point(253, 157);
            this.lblFactorRatePcn.Name = "lblFactorRatePcn";
            this.lblFactorRatePcn.Size = new System.Drawing.Size(42, 23);
            this.lblFactorRatePcn.TabIndex = 8;
            this.lblFactorRatePcn.Text = "%";
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Location = new System.Drawing.Point(20, 211);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpdated.TabIndex = 9;
            this.lblLastUpdated.Text = "Last Updated:";
            // 
            // txtLastUpdatedOn
            // 
            this.txtLastUpdatedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdatedOn.Location = new System.Drawing.Point(126, 208);
            this.txtLastUpdatedOn.Name = "txtLastUpdatedOn";
            this.txtLastUpdatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdatedOn.TabIndex = 10;
            // 
            // txtLastUpdatedBy
            // 
            this.txtLastUpdatedBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdatedBy.Location = new System.Drawing.Point(232, 208);
            this.txtLastUpdatedBy.Name = "txtLastUpdatedBy";
            this.txtLastUpdatedBy.Size = new System.Drawing.Size(58, 20);
            this.txtLastUpdatedBy.TabIndex = 11;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Location = new System.Drawing.Point(20, 234);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedOn.TabIndex = 12;
            this.lblCreatedOn.Text = "Creation Date:";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtCreatedOn.Location = new System.Drawing.Point(126, 231);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtCreatedOn.TabIndex = 13;
            // 
            // cboCurrency
            // 
            this.cboCurrency.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboCurrency.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCurrency.DropDownWidth = 121;
            this.cboCurrency.Location = new System.Drawing.Point(126, 85);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(121, 21);
            this.cboCurrency.TabIndex = 15;
            // 
            // cboEventCode
            // 
            this.cboEventCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboEventCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboEventCode.DropDownWidth = 116;
            this.cboEventCode.Location = new System.Drawing.Point(126, 281);
            this.cboEventCode.Name = "cboEventCode";
            this.cboEventCode.Size = new System.Drawing.Size(121, 21);
            this.cboEventCode.TabIndex = 15;
            this.cboEventCode.Visible = false;
            // 
            // lblEventCode
            // 
            this.lblEventCode.Location = new System.Drawing.Point(20, 284);
            this.lblEventCode.Name = "lblEventCode";
            this.lblEventCode.Size = new System.Drawing.Size(100, 23);
            this.lblEventCode.TabIndex = 0;
            this.lblEventCode.Text = "Event Code:";
            this.lblEventCode.Visible = false;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainerMain.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainerMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.splitContainerMain.Location = new System.Drawing.Point(-34, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lvPaymentFactor);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.lblWorkplace);
            this.splitContainerMain.Panel2.Controls.Add(this.tbWizardAction);
            this.splitContainerMain.Panel2.Controls.Add(this.lblEventCode);
            this.splitContainerMain.Panel2.Controls.Add(this.dtpEndDate);
            this.splitContainerMain.Panel2.Controls.Add(this.cboCurrency);
            this.splitContainerMain.Panel2.Controls.Add(this.lblFactorRate);
            this.splitContainerMain.Panel2.Controls.Add(this.txtCreatedOn);
            this.splitContainerMain.Panel2.Controls.Add(this.lblEndDate);
            this.splitContainerMain.Panel2.Controls.Add(this.txtFactorRate);
            this.splitContainerMain.Panel2.Controls.Add(this.lblCreatedOn);
            this.splitContainerMain.Panel2.Controls.Add(this.dtpStartDate);
            this.splitContainerMain.Panel2.Controls.Add(this.cboWorkplace);
            this.splitContainerMain.Panel2.Controls.Add(this.lblFactorRatePcn);
            this.splitContainerMain.Panel2.Controls.Add(this.txtLastUpdatedBy);
            this.splitContainerMain.Panel2.Controls.Add(this.cboEventCode);
            this.splitContainerMain.Panel2.Controls.Add(this.lblStartDate);
            this.splitContainerMain.Panel2.Controls.Add(this.txtLastUpdatedOn);
            this.splitContainerMain.Panel2.Controls.Add(this.lblLastUpdated);
            this.splitContainerMain.Panel2.Controls.Add(this.lblCurrency);
            this.splitContainerMain.Size = new System.Drawing.Size(840, 506);
            this.splitContainerMain.SplitterDistance = 526;
            this.splitContainerMain.SplitterWidth = 2;
            this.splitContainerMain.TabIndex = 16;
            // 
            // lvPaymentFactor
            // 
            this.lvPaymentFactor.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPaymentFactorId,
            this.colWorkplaceId,
            this.colLN,
            this.colWorkplace,
            this.colCurrencyAndEventCode,
            this.colStartDate,
            this.colEndDate,
            this.colFactor,
            this.colCreatedOn,
            this.colModifiedOn});
            this.lvPaymentFactor.DataMember = null;
            this.lvPaymentFactor.ItemsPerPage = 25;
            this.lvPaymentFactor.Location = new System.Drawing.Point(75, 131);
            this.lvPaymentFactor.Name = "lvPaymentFactor";
            this.lvPaymentFactor.Size = new System.Drawing.Size(346, 211);
            this.lvPaymentFactor.TabIndex = 0;
            this.lvPaymentFactor.UseInternalPaging = true;
            this.lvPaymentFactor.SelectedIndexChanged += new System.EventHandler(this.lvPaymentFactor_SelectedIndexChanged);
            // 
            // colPaymentFactorId
            // 
            this.colPaymentFactorId.Text = "PaymentFactorId";
            this.colPaymentFactorId.Visible = false;
            this.colPaymentFactorId.Width = 150;
            // 
            // colWorkplaceId
            // 
            this.colWorkplaceId.Text = "WorkplaceId";
            this.colWorkplaceId.Visible = false;
            this.colWorkplaceId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Text = "LN";
            this.colLN.Width = 50;
            // 
            // colWorkplace
            // 
            this.colWorkplace.Text = "Workplace";
            this.colWorkplace.Width = 80;
            // 
            // colCurrencyAndEventCode
            // 
            this.colCurrencyAndEventCode.Text = "{0}";
            this.colCurrencyAndEventCode.Width = 80;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "Start Date";
            this.colStartDate.Width = 80;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 80;
            // 
            // colFactor
            // 
            this.colFactor.Text = "Factor Rate(%)";
            this.colFactor.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colFactor.Width = 80;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.Text = "Created On";
            this.colCreatedOn.Width = 100;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.Text = "Modified On";
            this.colModifiedOn.Width = 100;
            // 
            // PaymentFactor
            // 
            this.Controls.Add(this.splitContainerMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 506);
            this.Text = "Payment Factor";
            this.Load += new System.EventHandler(this.PaymentFactor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.Label lblWorkplace;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboCurrency;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedOn;
        private Gizmox.WebGUI.Forms.Label lblCreatedOn;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdatedBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdatedOn;
        private Gizmox.WebGUI.Forms.Label lblLastUpdated;
        private Gizmox.WebGUI.Forms.Label lblFactorRatePcn;
        private Gizmox.WebGUI.Forms.TextBox txtFactorRate;
        private Gizmox.WebGUI.Forms.Label lblFactorRate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpEndDate;
        private Gizmox.WebGUI.Forms.Label lblEndDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpStartDate;
        private Gizmox.WebGUI.Forms.Label lblStartDate;
        private Gizmox.WebGUI.Forms.Label lblCurrency;
        private Gizmox.WebGUI.Forms.Label lblEventCode;
        private Gizmox.WebGUI.Forms.ComboBox cboEventCode;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainerMain;
        private Gizmox.WebGUI.Forms.ListView lvPaymentFactor;
        private Gizmox.WebGUI.Forms.ColumnHeader colPaymentFactorId;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colCurrencyAndEventCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colStartDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colEndDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colFactor;
        private Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId;


    }
}