namespace RT2020.Settings
{
    partial class CampaignWizard
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
            this.lblTender = new Gizmox.WebGUI.Forms.Label();
            this.lblStartDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpStartDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblEndDate = new Gizmox.WebGUI.Forms.Label();
            this.dtpEndDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblFactorRate = new Gizmox.WebGUI.Forms.Label();
            this.txtFactorRate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLastUpdated = new Gizmox.WebGUI.Forms.Label();
            this.txtLastUpdatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdatedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.cboTender = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblEventCode = new Gizmox.WebGUI.Forms.Label();
            this.lvList = new Gizmox.WebGUI.Forms.ListView();
            this.colPaymentFactorId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colWorkplaceId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colWorkplace = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colTenderType = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colEventCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStartDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colEndDate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colFactor = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCreatedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colModifiedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.cbxWorkplace = new RT2020.Components.CheckedComboBox();
            this.txtEventCode = new Gizmox.WebGUI.Forms.TextBox();
            this.gbxCampaign = new Gizmox.WebGUI.Forms.GroupBox();
            this.radEvent = new Gizmox.WebGUI.Forms.RadioButton();
            this.radTender = new Gizmox.WebGUI.Forms.RadioButton();
            this.gbxStatus = new Gizmox.WebGUI.Forms.GroupBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.gbxCampaign.SuspendLayout();
            this.gbxStatus.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tbWizardAction.Size = new System.Drawing.Size(253, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // cboWorkplace
            // 
            this.cboWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboWorkplace.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboWorkplace.DropDownWidth = 121;
            this.cboWorkplace.Location = new System.Drawing.Point(120, 87);
            this.cboWorkplace.Name = "cboWorkplace";
            this.cboWorkplace.Size = new System.Drawing.Size(120, 21);
            this.cboWorkplace.TabIndex = 3;
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.Location = new System.Drawing.Point(14, 87);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(106, 20);
            this.lblWorkplace.TabIndex = 2;
            this.lblWorkplace.Text = "Workplace:";
            this.lblWorkplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // lblTender
            // 
            this.lblTender.Location = new System.Drawing.Point(14, 112);
            this.lblTender.Name = "lblTender";
            this.lblTender.Size = new System.Drawing.Size(106, 20);
            this.lblTender.TabIndex = 4;
            this.lblTender.Text = "Tender:";
            this.lblTender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(14, 137);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(106, 20);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 137);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 21);
            this.dtpStartDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(14, 162);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(106, 20);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(120, 162);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 21);
            this.dtpEndDate.TabIndex = 11;
            // 
            // lblFactorRate
            // 
            this.lblFactorRate.Location = new System.Drawing.Point(14, 187);
            this.lblFactorRate.Name = "lblFactorRate";
            this.lblFactorRate.Size = new System.Drawing.Size(106, 20);
            this.lblFactorRate.TabIndex = 12;
            this.lblFactorRate.Text = "Factor Rate (%):";
            this.lblFactorRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFactorRate
            // 
            this.txtFactorRate.Location = new System.Drawing.Point(120, 187);
            this.txtFactorRate.Name = "txtFactorRate";
            this.txtFactorRate.Size = new System.Drawing.Size(120, 20);
            this.txtFactorRate.TabIndex = 13;
            this.txtFactorRate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Location = new System.Drawing.Point(15, 20);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(82, 20);
            this.lblLastUpdated.TabIndex = 0;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastUpdatedOn
            // 
            this.txtLastUpdatedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdatedOn.Location = new System.Drawing.Point(103, 20);
            this.txtLastUpdatedOn.Name = "txtLastUpdatedOn";
            this.txtLastUpdatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtLastUpdatedOn.TabIndex = 1;
            // 
            // txtLastUpdatedBy
            // 
            this.txtLastUpdatedBy.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdatedBy.Location = new System.Drawing.Point(103, 44);
            this.txtLastUpdatedBy.Name = "txtLastUpdatedBy";
            this.txtLastUpdatedBy.Size = new System.Drawing.Size(47, 20);
            this.txtLastUpdatedBy.TabIndex = 2;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Location = new System.Drawing.Point(15, 68);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(82, 20);
            this.lblCreatedOn.TabIndex = 3;
            this.lblCreatedOn.Text = "Creation Date:";
            this.lblCreatedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.BackColor = System.Drawing.Color.LightYellow;
            this.txtCreatedOn.Location = new System.Drawing.Point(103, 68);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtCreatedOn.TabIndex = 4;
            // 
            // cboTender
            // 
            this.cboTender.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboTender.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboTender.DropDownWidth = 121;
            this.cboTender.Location = new System.Drawing.Point(120, 112);
            this.cboTender.Name = "cboTender";
            this.cboTender.Size = new System.Drawing.Size(120, 21);
            this.cboTender.TabIndex = 5;
            // 
            // lblEventCode
            // 
            this.lblEventCode.Location = new System.Drawing.Point(14, 211);
            this.lblEventCode.Name = "lblEventCode";
            this.lblEventCode.Size = new System.Drawing.Size(106, 20);
            this.lblEventCode.TabIndex = 6;
            this.lblEventCode.Text = "Event Code:";
            this.lblEventCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEventCode.Visible = false;
            // 
            // lvList
            // 
            this.lvList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.lvList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPaymentFactorId,
            this.colWorkplaceId,
            this.colLN,
            this.colWorkplace,
            this.colTenderType,
            this.colEventCode,
            this.colStartDate,
            this.colEndDate,
            this.colFactor,
            this.colCreatedOn,
            this.colModifiedOn});
            this.lvList.DataMember = null;
            this.lvList.ItemsPerPage = 25;
            this.lvList.Location = new System.Drawing.Point(40, 46);
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(346, 211);
            this.lvList.TabIndex = 0;
            this.lvList.UseInternalPaging = true;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvPaymentFactor_SelectedIndexChanged);
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
            this.colLN.Width = 35;
            // 
            // colWorkplace
            // 
            this.colWorkplace.Text = "Workplace";
            this.colWorkplace.Width = 80;
            // 
            // colTenderType
            // 
            this.colTenderType.Text = "Currency";
            this.colTenderType.Width = 80;
            // 
            // colEventCode
            // 
            this.colEventCode.Text = "Event Code";
            this.colEventCode.Width = 80;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxWorkplace);
            this.panel1.Controls.Add(this.txtEventCode);
            this.panel1.Controls.Add(this.gbxCampaign);
            this.panel1.Controls.Add(this.gbxStatus);
            this.panel1.Controls.Add(this.lblWorkplace);
            this.panel1.Controls.Add(this.tbWizardAction);
            this.panel1.Controls.Add(this.lblEventCode);
            this.panel1.Controls.Add(this.cboWorkplace);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.lblTender);
            this.panel1.Controls.Add(this.cboTender);
            this.panel1.Controls.Add(this.lblFactorRate);
            this.panel1.Controls.Add(this.lblStartDate);
            this.panel1.Controls.Add(this.lblEndDate);
            this.panel1.Controls.Add(this.txtFactorRate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(553, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 450);
            this.panel1.TabIndex = 17;
            // 
            // cbxWorkplace
            // 
            this.cbxWorkplace.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cbxWorkplace.FormattingEnabled = true;
            this.cbxWorkplace.Location = new System.Drawing.Point(120, 263);
            this.cbxWorkplace.Name = "cbxWorkplace";
            this.cbxWorkplace.Size = new System.Drawing.Size(120, 21);
            this.cbxWorkplace.TabIndex = 15;
            // 
            // txtEventCode
            // 
            this.txtEventCode.Location = new System.Drawing.Point(120, 211);
            this.txtEventCode.Name = "txtEventCode";
            this.txtEventCode.Size = new System.Drawing.Size(120, 20);
            this.txtEventCode.TabIndex = 7;
            // 
            // gbxCampaign
            // 
            this.gbxCampaign.Controls.Add(this.radEvent);
            this.gbxCampaign.Controls.Add(this.radTender);
            this.gbxCampaign.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxCampaign.Location = new System.Drawing.Point(14, 28);
            this.gbxCampaign.Name = "gbxCampaign";
            this.gbxCampaign.Size = new System.Drawing.Size(226, 53);
            this.gbxCampaign.TabIndex = 1;
            this.gbxCampaign.TabStop = false;
            this.gbxCampaign.Text = "Campaign";
            // 
            // radEvent
            // 
            this.radEvent.AutoSize = true;
            this.radEvent.Location = new System.Drawing.Point(116, 23);
            this.radEvent.Name = "radEvent";
            this.radEvent.Size = new System.Drawing.Size(53, 17);
            this.radEvent.TabIndex = 1;
            this.radEvent.Text = "Event";
            this.radEvent.CheckedChanged += new System.EventHandler(this.compaign_OnChanged);
            // 
            // radTender
            // 
            this.radTender.AutoSize = true;
            this.radTender.Location = new System.Drawing.Point(18, 23);
            this.radTender.Name = "radTender";
            this.radTender.Size = new System.Drawing.Size(59, 17);
            this.radTender.TabIndex = 0;
            this.radTender.Text = "Tender";
            this.radTender.CheckedChanged += new System.EventHandler(this.compaign_OnChanged);
            // 
            // gbxStatus
            // 
            this.gbxStatus.Controls.Add(this.txtLastUpdatedOn);
            this.gbxStatus.Controls.Add(this.lblCreatedOn);
            this.gbxStatus.Controls.Add(this.txtLastUpdatedBy);
            this.gbxStatus.Controls.Add(this.txtCreatedOn);
            this.gbxStatus.Controls.Add(this.lblLastUpdated);
            this.gbxStatus.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxStatus.Location = new System.Drawing.Point(14, 333);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(226, 105);
            this.gbxStatus.TabIndex = 14;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvList);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 450);
            this.panel2.TabIndex = 0;
            // 
            // CampaignWizard
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 450);
            this.Text = "Payment Factor";
            this.Load += new System.EventHandler(this.CampaignWizard_Load);
            this.panel1.ResumeLayout(false);
            this.gbxCampaign.ResumeLayout(false);
            this.gbxStatus.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.ComboBox cboWorkplace;
        private Gizmox.WebGUI.Forms.Label lblWorkplace;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ComboBox cboTender;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedOn;
        private Gizmox.WebGUI.Forms.Label lblCreatedOn;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdatedBy;
        private Gizmox.WebGUI.Forms.TextBox txtLastUpdatedOn;
        private Gizmox.WebGUI.Forms.Label lblLastUpdated;
        private Gizmox.WebGUI.Forms.TextBox txtFactorRate;
        private Gizmox.WebGUI.Forms.Label lblFactorRate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpEndDate;
        private Gizmox.WebGUI.Forms.Label lblEndDate;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpStartDate;
        private Gizmox.WebGUI.Forms.Label lblStartDate;
        private Gizmox.WebGUI.Forms.Label lblTender;
        private Gizmox.WebGUI.Forms.Label lblEventCode;
        private Gizmox.WebGUI.Forms.ListView lvList;
        private Gizmox.WebGUI.Forms.ColumnHeader colPaymentFactorId;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colTenderType;
        private Gizmox.WebGUI.Forms.ColumnHeader colStartDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colEndDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colFactor;
        private Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colWorkplaceId;
        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.Panel panel2;
        private Gizmox.WebGUI.Forms.ColumnHeader colEventCode;
        private Gizmox.WebGUI.Forms.GroupBox gbxStatus;
        private Gizmox.WebGUI.Forms.GroupBox gbxCampaign;
        private Gizmox.WebGUI.Forms.RadioButton radEvent;
        private Gizmox.WebGUI.Forms.RadioButton radTender;
        private Gizmox.WebGUI.Forms.TextBox txtEventCode;
        private Components.CheckedComboBox cbxWorkplace;
    }
}