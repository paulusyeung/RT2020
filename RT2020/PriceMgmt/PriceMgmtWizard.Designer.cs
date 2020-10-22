namespace RT2020.PriceMgmt
{
    partial class PriceMgmtWizard
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
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.tbPriceMgmt = new Gizmox.WebGUI.Forms.TabControl();
            this.tpMain = new Gizmox.WebGUI.Forms.TabPage();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtModifiedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtModifiedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.cboReasonCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.dtpEffectiveDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.lblModified = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblReasonCode = new Gizmox.WebGUI.Forms.Label();
            this.lblEffectiveDate = new Gizmox.WebGUI.Forms.Label();
            this.tpDetails = new Gizmox.WebGUI.Forms.TabPage();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.tbPriceMgmt);
            this.mainPane.Controls.Add(this.txtTxNumber);
            this.mainPane.Controls.Add(this.lblTxNumber);
            this.mainPane.Controls.Add(this.txtTxType);
            this.mainPane.Controls.Add(this.lblTxType);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 28);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(798, 472);
            this.mainPane.TabIndex = 1;
            // 
            // tbPriceMgmt
            // 
            this.tbPriceMgmt.Controls.Add(this.tpMain);
            this.tbPriceMgmt.Controls.Add(this.tpDetails);
            this.tbPriceMgmt.Location = new System.Drawing.Point(12, 59);
            this.tbPriceMgmt.Multiline = false;
            this.tbPriceMgmt.Name = "tbPriceMgmt";
            this.tbPriceMgmt.SelectedIndex = 0;
            this.tbPriceMgmt.Size = new System.Drawing.Size(777, 401);
            this.tbPriceMgmt.TabIndex = 4;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.txtCreatedOn);
            this.tpMain.Controls.Add(this.txtModifiedBy);
            this.tpMain.Controls.Add(this.txtModifiedOn);
            this.tpMain.Controls.Add(this.txtRemarks);
            this.tpMain.Controls.Add(this.cboReasonCode);
            this.tpMain.Controls.Add(this.dtpEffectiveDate);
            this.tpMain.Controls.Add(this.lblCreatedOn);
            this.tpMain.Controls.Add(this.lblModified);
            this.tpMain.Controls.Add(this.lblRemarks);
            this.tpMain.Controls.Add(this.lblReasonCode);
            this.tpMain.Controls.Add(this.lblEffectiveDate);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(769, 375);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.Location = new System.Drawing.Point(122, 122);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(103, 20);
            this.txtCreatedOn.TabIndex = 10;
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.Location = new System.Drawing.Point(231, 96);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(66, 20);
            this.txtModifiedBy.TabIndex = 9;
            // 
            // txtModifiedOn
            // 
            this.txtModifiedOn.Location = new System.Drawing.Point(122, 96);
            this.txtModifiedOn.Name = "txtModifiedOn";
            this.txtModifiedOn.Size = new System.Drawing.Size(103, 20);
            this.txtModifiedOn.TabIndex = 8;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(122, 70);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(209, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // cboReasonCode
            // 
            this.cboReasonCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboReasonCode.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboReasonCode.Location = new System.Drawing.Point(122, 43);
            this.cboReasonCode.Name = "cboReasonCode";
            this.cboReasonCode.Size = new System.Drawing.Size(209, 21);
            this.cboReasonCode.TabIndex = 6;
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpEffectiveDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEffectiveDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(122, 17);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(103, 20);
            this.dtpEffectiveDate.TabIndex = 5;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Location = new System.Drawing.Point(16, 125);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedOn.TabIndex = 4;
            this.lblCreatedOn.Text = "Create Date: ";
            // 
            // lblModified
            // 
            this.lblModified.Location = new System.Drawing.Point(16, 99);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(100, 23);
            this.lblModified.TabIndex = 3;
            this.lblModified.Text = "Last Updated: ";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(16, 73);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 2;
            this.lblRemarks.Text = "Remarks: ";
            // 
            // lblReasonCode
            // 
            this.lblReasonCode.Location = new System.Drawing.Point(16, 46);
            this.lblReasonCode.Name = "lblReasonCode";
            this.lblReasonCode.Size = new System.Drawing.Size(100, 23);
            this.lblReasonCode.TabIndex = 1;
            this.lblReasonCode.Text = "Reason Code: ";
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.Location = new System.Drawing.Point(16, 19);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(100, 23);
            this.lblEffectiveDate.TabIndex = 0;
            this.lblEffectiveDate.Text = "Effective Date: ";
            // 
            // tpDetails
            // 
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Size = new System.Drawing.Size(769, 375);
            this.tpDetails.TabIndex = 0;
            this.tpDetails.Text = "Detail";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Enabled = false;
            this.txtTxNumber.Location = new System.Drawing.Point(247, 19);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 3;
            this.txtTxNumber.Text = "Auto-Generated";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(174, 22);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(67, 23);
            this.lblTxNumber.TabIndex = 2;
            this.lblTxNumber.Text = "TxNumber: ";
            // 
            // txtTxType
            // 
            this.txtTxType.Location = new System.Drawing.Point(80, 19);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.ReadOnly = true;
            this.txtTxType.Size = new System.Drawing.Size(36, 20);
            this.txtTxType.TabIndex = 1;
            this.txtTxType.Text = "PMC";
            // 
            // lblTxType
            // 
            this.lblTxType.Location = new System.Drawing.Point(32, 22);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(42, 23);
            this.lblTxType.TabIndex = 0;
            this.lblTxType.Text = "Type: ";
            // 
            // PriceMgmtWizard
            // 
            this.Controls.Add(this.mainPane);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(798, 500);
            this.Text = "PriceMgmtWizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TabControl tbPriceMgmt;
        private Gizmox.WebGUI.Forms.TabPage tpMain;
        private Gizmox.WebGUI.Forms.TabPage tpDetails;
        private Gizmox.WebGUI.Forms.Label lblCreatedOn;
        private Gizmox.WebGUI.Forms.Label lblModified;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.Label lblReasonCode;
        private Gizmox.WebGUI.Forms.Label lblEffectiveDate;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedOn;
        private Gizmox.WebGUI.Forms.TextBox txtModifiedBy;
        private Gizmox.WebGUI.Forms.TextBox txtModifiedOn;
        private Gizmox.WebGUI.Forms.TextBox txtRemarks;
        private Gizmox.WebGUI.Forms.ComboBox cboReasonCode;
        private Gizmox.WebGUI.Forms.DateTimePicker dtpEffectiveDate;


    }
}