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
            this.pnlDetails = new Gizmox.WebGUI.Forms.Panel();
            this.tbrDetails = new Gizmox.WebGUI.Forms.ToolBar();
            this.gbxStatus = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtModifiedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblModified = new Gizmox.WebGUI.Forms.Label();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtModifiedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.cboReasonCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.dtpEffectiveDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblEffectiveDate = new Gizmox.WebGUI.Forms.Label();
            this.lblReasonCode = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.colDetailId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStatus = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colSTKCODE = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAPPENDIX1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAPPENDIX2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAPPENDIX3 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colAverageCost = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOldPrice = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOldMarkUp = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNewPrice = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNewMarkUp = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDiff = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colOldDiscount = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colNewDiscount = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDescription = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass3 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass4 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass5 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colClass6 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colUpdateVipDiscount = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colFixedPriceItem = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDiscountForFixedPriceItem = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDiscountForDiscountItem = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colDiscountForNoDiscountItem = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colStaffDiscount = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colProductId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvItemList = new Gizmox.WebGUI.Forms.ListView();
            this.mainPane.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.gbxStatus.SuspendLayout();
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
            this.tbWizardAction.Size = new System.Drawing.Size(784, 26);
            this.tbWizardAction.TabIndex = 0;
            // 
            // mainPane
            // 
            this.mainPane.Controls.Add(this.pnlDetails);
            this.mainPane.Controls.Add(this.gbxStatus);
            this.mainPane.Controls.Add(this.txtTxNumber);
            this.mainPane.Controls.Add(this.lblTxNumber);
            this.mainPane.Controls.Add(this.txtRemarks);
            this.mainPane.Controls.Add(this.txtTxType);
            this.mainPane.Controls.Add(this.cboReasonCode);
            this.mainPane.Controls.Add(this.lblTxType);
            this.mainPane.Controls.Add(this.dtpEffectiveDate);
            this.mainPane.Controls.Add(this.lblEffectiveDate);
            this.mainPane.Controls.Add(this.lblReasonCode);
            this.mainPane.Controls.Add(this.lblRemarks);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(0, 26);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(784, 504);
            this.mainPane.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.lvItemList);
            this.pnlDetails.Controls.Add(this.tbrDetails);
            this.pnlDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.pnlDetails.Location = new System.Drawing.Point(0, 104);
            this.pnlDetails.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(784, 400);
            this.pnlDetails.TabIndex = 12;
            // 
            // tbrDetails
            // 
            this.tbrDetails.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbrDetails.DragHandle = true;
            this.tbrDetails.DropDownArrows = true;
            this.tbrDetails.ImageSize = new System.Drawing.Size(16, 16);
            this.tbrDetails.Location = new System.Drawing.Point(0, 0);
            this.tbrDetails.MenuHandle = true;
            this.tbrDetails.Name = "tbrDetails";
            this.tbrDetails.ShowToolTips = true;
            this.tbrDetails.Size = new System.Drawing.Size(782, 26);
            this.tbrDetails.TabIndex = 0;
            // 
            // gbxStatus
            // 
            this.gbxStatus.Controls.Add(this.txtModifiedOn);
            this.gbxStatus.Controls.Add(this.txtCreatedOn);
            this.gbxStatus.Controls.Add(this.lblModified);
            this.gbxStatus.Controls.Add(this.lblCreatedOn);
            this.gbxStatus.Controls.Add(this.txtModifiedBy);
            this.gbxStatus.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxStatus.Location = new System.Drawing.Point(523, 5);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(250, 80);
            this.gbxStatus.TabIndex = 11;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // txtModifiedOn
            // 
            this.txtModifiedOn.Location = new System.Drawing.Point(94, 20);
            this.txtModifiedOn.Name = "txtModifiedOn";
            this.txtModifiedOn.Size = new System.Drawing.Size(100, 20);
            this.txtModifiedOn.TabIndex = 8;
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.Location = new System.Drawing.Point(94, 45);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(100, 20);
            this.txtCreatedOn.TabIndex = 10;
            // 
            // lblModified
            // 
            this.lblModified.Location = new System.Drawing.Point(14, 20);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(80, 20);
            this.lblModified.TabIndex = 3;
            this.lblModified.Text = "Last Updated: ";
            this.lblModified.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.Location = new System.Drawing.Point(14, 46);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(80, 20);
            this.lblCreatedOn.TabIndex = 4;
            this.lblCreatedOn.Text = "Create Date: ";
            this.lblCreatedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.Location = new System.Drawing.Point(198, 20);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(40, 20);
            this.txtModifiedBy.TabIndex = 9;
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Enabled = false;
            this.txtTxNumber.Location = new System.Drawing.Point(90, 37);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 3;
            this.txtTxNumber.Text = "Auto-Generated";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(10, 37);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(80, 20);
            this.lblTxNumber.TabIndex = 2;
            this.lblTxNumber.Text = "TxNumber: ";
            this.lblTxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(302, 63);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(209, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // txtTxType
            // 
            this.txtTxType.Location = new System.Drawing.Point(90, 11);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.ReadOnly = true;
            this.txtTxType.Size = new System.Drawing.Size(36, 20);
            this.txtTxType.TabIndex = 1;
            this.txtTxType.Text = "PMC";
            // 
            // cboReasonCode
            // 
            this.cboReasonCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboReasonCode.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboReasonCode.Location = new System.Drawing.Point(302, 37);
            this.cboReasonCode.Name = "cboReasonCode";
            this.cboReasonCode.Size = new System.Drawing.Size(100, 21);
            this.cboReasonCode.TabIndex = 6;
            // 
            // lblTxType
            // 
            this.lblTxType.Location = new System.Drawing.Point(10, 11);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(80, 20);
            this.lblTxType.TabIndex = 0;
            this.lblTxType.Text = "Type: ";
            this.lblTxType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEffectiveDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(302, 11);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(100, 21);
            this.dtpEffectiveDate.TabIndex = 5;
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.Location = new System.Drawing.Point(202, 11);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(100, 20);
            this.lblEffectiveDate.TabIndex = 0;
            this.lblEffectiveDate.Text = "Effective Date: ";
            this.lblEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReasonCode
            // 
            this.lblReasonCode.Location = new System.Drawing.Point(202, 37);
            this.lblReasonCode.Name = "lblReasonCode";
            this.lblReasonCode.Size = new System.Drawing.Size(100, 20);
            this.lblReasonCode.TabIndex = 1;
            this.lblReasonCode.Text = "Reason Code: ";
            this.lblReasonCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(202, 63);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 20);
            this.lblRemarks.TabIndex = 2;
            this.lblRemarks.Text = "Remarks: ";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colDetailId
            // 
            this.colDetailId.Text = "DetailsId";
            this.colDetailId.Visible = false;
            this.colDetailId.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 50;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.Text = "STKCODE";
            this.colSTKCODE.Width = 90;
            // 
            // colAPPENDIX1
            // 
            this.colAPPENDIX1.Text = "APPENDIX1";
            this.colAPPENDIX1.Width = 60;
            // 
            // colAPPENDIX2
            // 
            this.colAPPENDIX2.Text = "APPENDIX2";
            this.colAPPENDIX2.Width = 60;
            // 
            // colAPPENDIX3
            // 
            this.colAPPENDIX3.Text = "APPENDIX3";
            this.colAPPENDIX3.Width = 60;
            // 
            // colAverageCost
            // 
            this.colAverageCost.Text = "Avg. Cost";
            this.colAverageCost.Width = 80;
            // 
            // colOldPrice
            // 
            this.colOldPrice.Text = "Old Price";
            this.colOldPrice.Width = 80;
            // 
            // colOldMarkUp
            // 
            this.colOldMarkUp.Text = "Old MU%";
            this.colOldMarkUp.Width = 80;
            // 
            // colNewPrice
            // 
            this.colNewPrice.Text = "New Price";
            this.colNewPrice.Width = 80;
            // 
            // colNewMarkUp
            // 
            this.colNewMarkUp.Text = "New MU%";
            this.colNewMarkUp.Width = 80;
            // 
            // colDiff
            // 
            this.colDiff.Text = "Diff.%";
            this.colDiff.Width = 80;
            // 
            // colOldDiscount
            // 
            this.colOldDiscount.Text = "Old Disc. %";
            this.colOldDiscount.Width = 80;
            // 
            // colNewDiscount
            // 
            this.colNewDiscount.Text = "New Disc. %";
            this.colNewDiscount.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 90;
            // 
            // colClass1
            // 
            this.colClass1.Text = "Class1";
            this.colClass1.Width = 50;
            // 
            // colClass2
            // 
            this.colClass2.Text = "Class2";
            this.colClass2.Width = 50;
            // 
            // colClass3
            // 
            this.colClass3.Text = "Class3";
            this.colClass3.Width = 50;
            // 
            // colClass4
            // 
            this.colClass4.Text = "Class4";
            this.colClass4.Width = 50;
            // 
            // colClass5
            // 
            this.colClass5.Text = "Class5";
            this.colClass5.Width = 50;
            // 
            // colClass6
            // 
            this.colClass6.Text = "Class6";
            this.colClass6.Width = 50;
            // 
            // colUpdateVipDiscount
            // 
            this.colUpdateVipDiscount.Text = "Update Vip Discount";
            this.colUpdateVipDiscount.Width = 50;
            // 
            // colFixedPriceItem
            // 
            this.colFixedPriceItem.Text = "Fixed Price Item";
            this.colFixedPriceItem.Width = 50;
            // 
            // colDiscountForFixedPriceItem
            // 
            this.colDiscountForFixedPriceItem.Text = "Disc. For Fixed Price item";
            this.colDiscountForFixedPriceItem.Width = 50;
            // 
            // colDiscountForDiscountItem
            // 
            this.colDiscountForDiscountItem.Text = "Disc. for Discount Item";
            this.colDiscountForDiscountItem.Width = 50;
            // 
            // colDiscountForNoDiscountItem
            // 
            this.colDiscountForNoDiscountItem.Text = "Disc. for No Discount item";
            this.colDiscountForNoDiscountItem.Width = 50;
            // 
            // colStaffDiscount
            // 
            this.colStaffDiscount.Text = "Staff Discount";
            this.colStaffDiscount.Width = 50;
            // 
            // colProductId
            // 
            this.colProductId.Text = "ProductId";
            this.colProductId.Visible = false;
            this.colProductId.Width = 150;
            // 
            // lvItemList
            // 
            this.lvItemList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.lvItemList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailId,
            this.colStatus,
            this.colSTKCODE,
            this.colAPPENDIX1,
            this.colAPPENDIX2,
            this.colAPPENDIX3,
            this.colAverageCost,
            this.colOldPrice,
            this.colOldMarkUp,
            this.colNewPrice,
            this.colNewMarkUp,
            this.colDiff,
            this.colOldDiscount,
            this.colNewDiscount,
            this.colDescription,
            this.colClass1,
            this.colClass2,
            this.colClass3,
            this.colClass4,
            this.colClass5,
            this.colClass6,
            this.colUpdateVipDiscount,
            this.colFixedPriceItem,
            this.colDiscountForFixedPriceItem,
            this.colDiscountForDiscountItem,
            this.colDiscountForNoDiscountItem,
            this.colStaffDiscount,
            this.colProductId});
            this.lvItemList.DataMember = null;
            this.lvItemList.Location = new System.Drawing.Point(21, 113);
            this.lvItemList.Name = "lvItemList";
            this.lvItemList.Size = new System.Drawing.Size(743, 175);
            this.lvItemList.TabIndex = 22;
            // 
            // PriceMgmtWizard
            // 
            this.Controls.Add(this.mainPane);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(784, 530);
            this.Text = "PriceMgmtWizard";
            this.Load += new System.EventHandler(this.PriceMgmtWizard_Load);
            this.mainPane.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.gbxStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
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
        private Gizmox.WebGUI.Forms.GroupBox gbxStatus;
        private Gizmox.WebGUI.Forms.Panel pnlDetails;
        private Gizmox.WebGUI.Forms.ToolBar tbrDetails;
        private Gizmox.WebGUI.Forms.ToolTip toolTip1;
        public Gizmox.WebGUI.Forms.ListView lvItemList;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailId;
        private Gizmox.WebGUI.Forms.ColumnHeader colStatus;
        private Gizmox.WebGUI.Forms.ColumnHeader colSTKCODE;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX3;
        private Gizmox.WebGUI.Forms.ColumnHeader colAverageCost;
        private Gizmox.WebGUI.Forms.ColumnHeader colOldPrice;
        private Gizmox.WebGUI.Forms.ColumnHeader colOldMarkUp;
        private Gizmox.WebGUI.Forms.ColumnHeader colNewPrice;
        private Gizmox.WebGUI.Forms.ColumnHeader colNewMarkUp;
        private Gizmox.WebGUI.Forms.ColumnHeader colDiff;
        private Gizmox.WebGUI.Forms.ColumnHeader colOldDiscount;
        private Gizmox.WebGUI.Forms.ColumnHeader colNewDiscount;
        private Gizmox.WebGUI.Forms.ColumnHeader colDescription;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass1;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass2;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass3;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass4;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass5;
        private Gizmox.WebGUI.Forms.ColumnHeader colClass6;
        private Gizmox.WebGUI.Forms.ColumnHeader colUpdateVipDiscount;
        private Gizmox.WebGUI.Forms.ColumnHeader colFixedPriceItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDiscountForFixedPriceItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDiscountForDiscountItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colDiscountForNoDiscountItem;
        private Gizmox.WebGUI.Forms.ColumnHeader colStaffDiscount;
        private Gizmox.WebGUI.Forms.ColumnHeader colProductId;
    }
}