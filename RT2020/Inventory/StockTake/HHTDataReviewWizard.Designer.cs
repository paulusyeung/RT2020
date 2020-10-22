namespace RT2020.Inventory.StockTake
{
    partial class HHTDataReviewWizard
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle3 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle4 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle5 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.tbControl = new Gizmox.WebGUI.Forms.ToolBar();
            this.cmdSave = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.cmdSaveAndNew = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.cmdSaveAndClose = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.cmdSeparator = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.cmdPrint = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.cmdDelete = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblWorkplace = new Gizmox.WebGUI.Forms.Label();
            this.lblHHTId = new Gizmox.WebGUI.Forms.Label();
            this.lblUploadedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtWorkplace = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHHTId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUploadedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTotalLine = new Gizmox.WebGUI.Forms.Label();
            this.lblTotalQty = new Gizmox.WebGUI.Forms.Label();
            this.lblHHTData = new Gizmox.WebGUI.Forms.Label();
            this.lblStockTake = new Gizmox.WebGUI.Forms.Label();
            this.lblMissingBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalLine_HHTData = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalQty_HHTData = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalLine_StockTake = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalQty_StockTake = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalLine_MissingBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotalQty_MissingBarcode = new Gizmox.WebGUI.Forms.TextBox();
            this.gbDetails = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblCreatedOn = new Gizmox.WebGUI.Forms.Label();
            this.txtCreatedOn = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCreatedBy = new Gizmox.WebGUI.Forms.TextBox();
            this.lvDetailsList = new Gizmox.WebGUI.Forms.ListView();
            this.colDetailsId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colBarcode = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colHHTQty = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSTKCODE = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAPPENDIX1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAPPENDIX2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colAPPENDIX3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // tbControl
            // 
            this.tbControl.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbControl.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbControl.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.cmdSave,
            this.cmdSaveAndNew,
            this.cmdSaveAndClose,
            this.cmdSeparator,
            this.cmdPrint,
            this.cmdDelete});
            this.tbControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbControl.DragHandle = true;
            this.tbControl.DropDownArrows = false;
            this.tbControl.ImageList = null;
            this.tbControl.Location = new System.Drawing.Point(0, 0);
            this.tbControl.MenuHandle = true;
            this.tbControl.Name = "tbControl";
            //this.tbControl.RightToLeft = false;
            this.tbControl.ShowToolTips = true;
            this.tbControl.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.cmdSave.Enabled = false;
            iconResourceHandle1.File = "16x16.16_L_save.gif";
            this.cmdSave.Image = iconResourceHandle1;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Pushed = true;
            this.cmdSave.Size = 24;
            this.cmdSave.Text = "Save";
            this.cmdSave.ToolTipText = "Save";
            // 
            // cmdSaveAndNew
            // 
            this.cmdSaveAndNew.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.cmdSaveAndNew.Enabled = false;
            iconResourceHandle2.File = "16x16.16_L_saveOpen.gif";
            this.cmdSaveAndNew.Image = iconResourceHandle2;
            this.cmdSaveAndNew.Name = "cmdSaveAndNew";
            this.cmdSaveAndNew.Pushed = true;
            this.cmdSaveAndNew.Size = 24;
            this.cmdSaveAndNew.Text = "Save and New";
            this.cmdSaveAndNew.ToolTipText = "Save and New";
            // 
            // cmdSaveAndClose
            // 
            this.cmdSaveAndClose.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.cmdSaveAndClose.Enabled = false;
            iconResourceHandle3.File = "16x16.16_saveClose.gif";
            this.cmdSaveAndClose.Image = iconResourceHandle3;
            this.cmdSaveAndClose.Name = "cmdSaveAndClose";
            this.cmdSaveAndClose.Pushed = true;
            this.cmdSaveAndClose.Size = 24;
            this.cmdSaveAndClose.Text = "Save and Close";
            this.cmdSaveAndClose.ToolTipText = "Save and Close";
            // 
            // cmdSeparator
            // 
            this.cmdSeparator.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.cmdSeparator.Name = "cmdSeparator";
            this.cmdSeparator.Pushed = true;
            this.cmdSeparator.Size = 24;
            this.cmdSeparator.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.cmdSeparator.ToolTipText = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            // 
            // cmdPrint
            // 
            this.cmdPrint.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            iconResourceHandle4.File = "16x16.16_print.gif";
            this.cmdPrint.Image = iconResourceHandle4;
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Pushed = true;
            this.cmdPrint.Size = 24;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.ToolTipText = "Print";
            // 
            // cmdDelete
            // 
            this.cmdDelete.CustomStyle = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.cmdDelete.Enabled = false;
            iconResourceHandle5.File = "16x16.16_L_remove.gif";
            this.cmdDelete.Image = iconResourceHandle5;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Pushed = true;
            this.cmdDelete.Size = 24;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.ToolTipText = "Delete";
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.txtCreatedBy);
            this.mainPane.Controls.Add(this.txtCreatedOn);
            this.mainPane.Controls.Add(this.lblCreatedOn);
            this.mainPane.Controls.Add(this.gbDetails);
            this.mainPane.Controls.Add(this.txtTotalQty_MissingBarcode);
            this.mainPane.Controls.Add(this.txtTotalLine_MissingBarcode);
            this.mainPane.Controls.Add(this.txtTotalQty_StockTake);
            this.mainPane.Controls.Add(this.txtTotalLine_StockTake);
            this.mainPane.Controls.Add(this.txtTotalQty_HHTData);
            this.mainPane.Controls.Add(this.txtTotalLine_HHTData);
            this.mainPane.Controls.Add(this.lblMissingBarcode);
            this.mainPane.Controls.Add(this.lblStockTake);
            this.mainPane.Controls.Add(this.lblHHTData);
            this.mainPane.Controls.Add(this.lblTotalQty);
            this.mainPane.Controls.Add(this.lblTotalLine);
            this.mainPane.Controls.Add(this.txtUploadedOn);
            this.mainPane.Controls.Add(this.txtHHTId);
            this.mainPane.Controls.Add(this.txtWorkplace);
            this.mainPane.Controls.Add(this.txtTxNumber);
            this.mainPane.Controls.Add(this.lblUploadedOn);
            this.mainPane.Controls.Add(this.lblHHTId);
            this.mainPane.Controls.Add(this.lblWorkplace);
            this.mainPane.Controls.Add(this.lblTxNumber);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 3;
            this.mainPane.Location = new System.Drawing.Point(0, 28);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(753, 514);
            this.mainPane.TabIndex = 1;
            this.mainPane.TabStop = false;
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.AutoSize = true;
            this.lblTxNumber.Location = new System.Drawing.Point(21, 18);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Trn#";
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.AutoSize = true;
            this.lblWorkplace.Location = new System.Drawing.Point(21, 44);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(100, 23);
            this.lblWorkplace.TabIndex = 1;
            this.lblWorkplace.Text = "Location";
            // 
            // lblHHTId
            // 
            this.lblHHTId.AutoSize = true;
            this.lblHHTId.Location = new System.Drawing.Point(21, 70);
            this.lblHHTId.Name = "lblHHTId";
            this.lblHHTId.Size = new System.Drawing.Size(100, 23);
            this.lblHHTId.TabIndex = 2;
            this.lblHHTId.Text = "HHT ID";
            // 
            // lblUploadedOn
            // 
            this.lblUploadedOn.AutoSize = true;
            this.lblUploadedOn.Location = new System.Drawing.Point(21, 96);
            this.lblUploadedOn.Name = "lblUploadedOn";
            this.lblUploadedOn.Size = new System.Drawing.Size(100, 23);
            this.lblUploadedOn.TabIndex = 3;
            this.lblUploadedOn.Text = "Upload Time";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(114, 15);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.ReadOnly = true;
            this.txtTxNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTxNumber.TabIndex = 4;
            this.txtTxNumber.TabStop = false;
            // 
            // txtWorkplace
            // 
            this.txtWorkplace.Location = new System.Drawing.Point(114, 41);
            this.txtWorkplace.Name = "txtWorkplace";
            this.txtWorkplace.ReadOnly = true;
            this.txtWorkplace.Size = new System.Drawing.Size(100, 20);
            this.txtWorkplace.TabIndex = 5;
            this.txtWorkplace.TabStop = false;
            // 
            // txtHHTId
            // 
            this.txtHHTId.Location = new System.Drawing.Point(114, 67);
            this.txtHHTId.Name = "txtHHTId";
            this.txtHHTId.ReadOnly = true;
            this.txtHHTId.Size = new System.Drawing.Size(100, 20);
            this.txtHHTId.TabIndex = 6;
            this.txtHHTId.TabStop = false;
            // 
            // txtUploadedOn
            // 
            this.txtUploadedOn.Location = new System.Drawing.Point(114, 93);
            this.txtUploadedOn.Name = "txtUploadedOn";
            this.txtUploadedOn.ReadOnly = true;
            this.txtUploadedOn.Size = new System.Drawing.Size(153, 20);
            this.txtUploadedOn.TabIndex = 7;
            this.txtUploadedOn.TabStop = false;
            // 
            // lblTotalLine
            // 
            this.lblTotalLine.AutoSize = true;
            this.lblTotalLine.Location = new System.Drawing.Point(306, 44);
            this.lblTotalLine.Name = "lblTotalLine";
            this.lblTotalLine.Size = new System.Drawing.Size(100, 23);
            this.lblTotalLine.TabIndex = 8;
            this.lblTotalLine.Text = "Total Line";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(306, 70);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(100, 23);
            this.lblTotalQty.TabIndex = 9;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // lblHHTData
            // 
            this.lblHHTData.AutoSize = true;
            this.lblHHTData.Location = new System.Drawing.Point(403, 18);
            this.lblHHTData.Name = "lblHHTData";
            this.lblHHTData.Size = new System.Drawing.Size(100, 23);
            this.lblHHTData.TabIndex = 10;
            this.lblHHTData.Text = "HHT Data";
            // 
            // lblStockTake
            // 
            this.lblStockTake.AutoSize = true;
            this.lblStockTake.Location = new System.Drawing.Point(488, 18);
            this.lblStockTake.Name = "lblStockTake";
            this.lblStockTake.Size = new System.Drawing.Size(100, 23);
            this.lblStockTake.TabIndex = 11;
            this.lblStockTake.Text = "Stock Take";
            // 
            // lblMissingBarcode
            // 
            this.lblMissingBarcode.AutoSize = true;
            this.lblMissingBarcode.Location = new System.Drawing.Point(562, 18);
            this.lblMissingBarcode.Name = "lblMissingBarcode";
            this.lblMissingBarcode.Size = new System.Drawing.Size(100, 23);
            this.lblMissingBarcode.TabIndex = 12;
            this.lblMissingBarcode.Text = "Barcode Missing";
            // 
            // txtTotalLine_HHTData
            // 
            this.txtTotalLine_HHTData.Location = new System.Drawing.Point(391, 41);
            this.txtTotalLine_HHTData.Name = "txtTotalLine_HHTData";
            this.txtTotalLine_HHTData.ReadOnly = true;
            this.txtTotalLine_HHTData.Size = new System.Drawing.Size(77, 20);
            this.txtTotalLine_HHTData.TabIndex = 13;
            this.txtTotalLine_HHTData.TabStop = false;
            this.txtTotalLine_HHTData.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalQty_HHTData
            // 
            this.txtTotalQty_HHTData.Location = new System.Drawing.Point(391, 67);
            this.txtTotalQty_HHTData.Name = "txtTotalQty_HHTData";
            this.txtTotalQty_HHTData.ReadOnly = true;
            this.txtTotalQty_HHTData.Size = new System.Drawing.Size(77, 20);
            this.txtTotalQty_HHTData.TabIndex = 14;
            this.txtTotalQty_HHTData.TabStop = false;
            this.txtTotalQty_HHTData.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalLine_StockTake
            // 
            this.txtTotalLine_StockTake.Location = new System.Drawing.Point(479, 41);
            this.txtTotalLine_StockTake.Name = "txtTotalLine_StockTake";
            this.txtTotalLine_StockTake.ReadOnly = true;
            this.txtTotalLine_StockTake.Size = new System.Drawing.Size(77, 20);
            this.txtTotalLine_StockTake.TabIndex = 15;
            this.txtTotalLine_StockTake.TabStop = false;
            this.txtTotalLine_StockTake.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalQty_StockTake
            // 
            this.txtTotalQty_StockTake.Location = new System.Drawing.Point(479, 67);
            this.txtTotalQty_StockTake.Name = "txtTotalQty_StockTake";
            this.txtTotalQty_StockTake.ReadOnly = true;
            this.txtTotalQty_StockTake.Size = new System.Drawing.Size(77, 20);
            this.txtTotalQty_StockTake.TabIndex = 16;
            this.txtTotalQty_StockTake.TabStop = false;
            this.txtTotalQty_StockTake.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalLine_MissingBarcode
            // 
            this.txtTotalLine_MissingBarcode.ForeColor = System.Drawing.Color.Red;
            this.txtTotalLine_MissingBarcode.Location = new System.Drawing.Point(565, 41);
            this.txtTotalLine_MissingBarcode.Name = "txtTotalLine_MissingBarcode";
            this.txtTotalLine_MissingBarcode.ReadOnly = true;
            this.txtTotalLine_MissingBarcode.Size = new System.Drawing.Size(77, 20);
            this.txtTotalLine_MissingBarcode.TabIndex = 17;
            this.txtTotalLine_MissingBarcode.TabStop = false;
            this.txtTotalLine_MissingBarcode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalQty_MissingBarcode
            // 
            this.txtTotalQty_MissingBarcode.ForeColor = System.Drawing.Color.Red;
            this.txtTotalQty_MissingBarcode.Location = new System.Drawing.Point(565, 67);
            this.txtTotalQty_MissingBarcode.Name = "txtTotalQty_MissingBarcode";
            this.txtTotalQty_MissingBarcode.ReadOnly = true;
            this.txtTotalQty_MissingBarcode.Size = new System.Drawing.Size(77, 20);
            this.txtTotalQty_MissingBarcode.TabIndex = 18;
            this.txtTotalQty_MissingBarcode.TabStop = false;
            this.txtTotalQty_MissingBarcode.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lvDetailsList);
            this.gbDetails.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbDetails.Location = new System.Drawing.Point(12, 119);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(729, 352);
            this.gbDetails.TabIndex = 19;
            this.gbDetails.Text = "Details";
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Location = new System.Drawing.Point(21, 483);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedOn.TabIndex = 20;
            this.lblCreatedOn.Text = "Created Date";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.Location = new System.Drawing.Point(114, 480);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(153, 20);
            this.txtCreatedOn.TabIndex = 21;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(273, 480);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(60, 20);
            this.txtCreatedBy.TabIndex = 22;
            // 
            // lvDetailsList
            // 
            this.lvDetailsList.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lvDetailsList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colDetailsId,
            this.colBarcode,
            this.colHHTQty,
            this.colSTKCODE,
            this.colAPPENDIX1,
            this.colAPPENDIX2,
            this.colAPPENDIX3});
            this.lvDetailsList.DataMember = null;
            this.lvDetailsList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lvDetailsList.ItemsPerPage = 20;
            this.lvDetailsList.Location = new System.Drawing.Point(3, 16);
            this.lvDetailsList.Name = "lvDetailsList";
            this.lvDetailsList.Size = new System.Drawing.Size(723, 333);
            this.lvDetailsList.TabIndex = 0;
            // 
            // colDetailsId
            // 
            this.colDetailsId.Image = null;
            this.colDetailsId.Text = "DetailsId";
            this.colDetailsId.Visible = false;
            this.colDetailsId.Width = 150;
            // 
            // colBarcode
            // 
            this.colBarcode.Image = null;
            this.colBarcode.Text = "Barcode";
            this.colBarcode.Width = 120;
            // 
            // colHHTQty
            // 
            this.colHHTQty.Image = null;
            this.colHHTQty.Text = "HHT Qty";
            this.colHHTQty.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.colHHTQty.Width = 60;
            // 
            // colSTKCODE
            // 
            this.colSTKCODE.Image = null;
            this.colSTKCODE.Text = "STKCODE";
            this.colSTKCODE.Width = 80;
            // 
            // colAPPENDIX1
            // 
            this.colAPPENDIX1.Image = null;
            this.colAPPENDIX1.Text = "APPENDIX1";
            this.colAPPENDIX1.Width = 60;
            // 
            // colAPPENDIX2
            // 
            this.colAPPENDIX2.Image = null;
            this.colAPPENDIX2.Text = "APPENDIX2";
            this.colAPPENDIX2.Width = 60;
            // 
            // colAPPENDIX3
            // 
            this.colAPPENDIX3.Image = null;
            this.colAPPENDIX3.Text = "APPENDIX3";
            this.colAPPENDIX3.Width = 60;
            // 
            // HHTDataReviewWizard
            // 
            this.Controls.Add(this.mainPane);
            this.Controls.Add(this.tbControl);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(753, 542);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "HHT Data Review Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbControl;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdSave;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdSaveAndNew;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdSaveAndClose;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdSeparator;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdPrint;
        private Gizmox.WebGUI.Forms.ToolBarButton cmdDelete;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty_MissingBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtTotalLine_MissingBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty_StockTake;
        private Gizmox.WebGUI.Forms.TextBox txtTotalLine_StockTake;
        private Gizmox.WebGUI.Forms.TextBox txtTotalQty_HHTData;
        private Gizmox.WebGUI.Forms.TextBox txtTotalLine_HHTData;
        private Gizmox.WebGUI.Forms.Label lblMissingBarcode;
        private Gizmox.WebGUI.Forms.Label lblStockTake;
        private Gizmox.WebGUI.Forms.Label lblHHTData;
        private Gizmox.WebGUI.Forms.Label lblTotalQty;
        private Gizmox.WebGUI.Forms.Label lblTotalLine;
        private Gizmox.WebGUI.Forms.TextBox txtUploadedOn;
        private Gizmox.WebGUI.Forms.TextBox txtHHTId;
        private Gizmox.WebGUI.Forms.TextBox txtWorkplace;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblUploadedOn;
        private Gizmox.WebGUI.Forms.Label lblHHTId;
        private Gizmox.WebGUI.Forms.Label lblWorkplace;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedBy;
        private Gizmox.WebGUI.Forms.TextBox txtCreatedOn;
        private Gizmox.WebGUI.Forms.Label lblCreatedOn;
        private Gizmox.WebGUI.Forms.GroupBox gbDetails;
        private Gizmox.WebGUI.Forms.ListView lvDetailsList;
        private Gizmox.WebGUI.Forms.ColumnHeader colDetailsId;
        private Gizmox.WebGUI.Forms.ColumnHeader colBarcode;
        private Gizmox.WebGUI.Forms.ColumnHeader colHHTQty;
        private Gizmox.WebGUI.Forms.ColumnHeader colSTKCODE;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX1;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX2;
        private Gizmox.WebGUI.Forms.ColumnHeader colAPPENDIX3;


    }
}