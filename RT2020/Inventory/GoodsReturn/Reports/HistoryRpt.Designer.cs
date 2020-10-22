namespace RT2020.Inventory.GoodsReturn.Reports
{
    partial class HistoryRpt
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.rptDetails = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.txtHeaderId = new DevExpress.XtraReports.UI.XRLabel();
            this.txtModifiedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblModifiedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.txtModifiedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.lblModifiedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.txtRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.txtLocationName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtLocationCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblLocation = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOperatorName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOperatorCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOperator = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSupplierName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSupplierCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSupplier = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDate = new DevExpress.XtraReports.UI.XRLabel();
            this.txtReference = new DevExpress.XtraReports.UI.XRLabel();
            this.lblReference = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.Text23 = new DevExpress.XtraReports.UI.XRLabel();
            this.gfTotalAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.gfTotalQty = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.pnlPageInfo = new DevExpress.XtraReports.UI.XRPanel();
            this.lblPrintedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.phPageNumber = new DevExpress.XtraReports.UI.XRPageInfo();
            this.phDateTime = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblPage = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix3 = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix2 = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix1 = new DevExpress.XtraReports.UI.XRLabel();
            this.phStkCode = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.hdrCompName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDateTo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDateFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDateTo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDateFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.lblQty = new DevExpress.XtraReports.UI.XRLabel();
            this.lblUnitAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDescription = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumberTo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumberFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumberTo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumberFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rptDetails});
            this.Detail.Height = 15;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // rptDetails
            // 
            this.rptDetails.Location = new System.Drawing.Point(15, 0);
            this.rptDetails.Name = "rptDetails";
            this.rptDetails.Size = new System.Drawing.Size(758, 14);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtHeaderId,
            this.txtModifiedOn,
            this.lblModifiedOn,
            this.txtModifiedBy,
            this.lblModifiedBy,
            this.txtRemarks,
            this.lblRemarks,
            this.txtLocationName,
            this.txtLocationCode,
            this.lblLocation,
            this.txtOperatorName,
            this.txtOperatorCode,
            this.lblOperator,
            this.txtSupplierName,
            this.txtSupplierCode,
            this.lblSupplier,
            this.txtTxDate,
            this.lblTxDate,
            this.txtReference,
            this.lblReference,
            this.txtTxNumber,
            this.lblTxNumber});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("REJNO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 77;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // txtHeaderId
            // 
            this.txtHeaderId.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtHeaderId.Location = new System.Drawing.Point(642, 58);
            this.txtHeaderId.Name = "txtHeaderId";
            this.txtHeaderId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeaderId.ParentStyleUsing.UseFont = false;
            this.txtHeaderId.Size = new System.Drawing.Size(108, 14);
            this.txtHeaderId.Text = "txtHeaderId";
            this.txtHeaderId.Visible = false;
            // 
            // txtModifiedOn
            // 
            this.txtModifiedOn.BackColor = System.Drawing.Color.White;
            this.txtModifiedOn.BorderColor = System.Drawing.Color.Black;
            this.txtModifiedOn.CanGrow = false;
            this.txtModifiedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtModifiedOn.ForeColor = System.Drawing.Color.Black;
            this.txtModifiedOn.Location = new System.Drawing.Point(690, 25);
            this.txtModifiedOn.Name = "txtModifiedOn";
            this.txtModifiedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtModifiedOn.ParentStyleUsing.UseBackColor = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorderColor = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorders = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorderWidth = false;
            this.txtModifiedOn.ParentStyleUsing.UseFont = false;
            this.txtModifiedOn.ParentStyleUsing.UseForeColor = false;
            this.txtModifiedOn.Size = new System.Drawing.Size(81, 12);
            this.txtModifiedOn.Text = "txtModifiedOn";
            // 
            // lblModifiedOn
            // 
            this.lblModifiedOn.BackColor = System.Drawing.Color.White;
            this.lblModifiedOn.BorderColor = System.Drawing.Color.Black;
            this.lblModifiedOn.CanGrow = false;
            this.lblModifiedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblModifiedOn.ForeColor = System.Drawing.Color.Black;
            this.lblModifiedOn.Location = new System.Drawing.Point(590, 25);
            this.lblModifiedOn.Name = "lblModifiedOn";
            this.lblModifiedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblModifiedOn.ParentStyleUsing.UseBackColor = false;
            this.lblModifiedOn.ParentStyleUsing.UseBorderColor = false;
            this.lblModifiedOn.ParentStyleUsing.UseBorders = false;
            this.lblModifiedOn.ParentStyleUsing.UseBorderWidth = false;
            this.lblModifiedOn.ParentStyleUsing.UseFont = false;
            this.lblModifiedOn.ParentStyleUsing.UseForeColor = false;
            this.lblModifiedOn.Size = new System.Drawing.Size(100, 14);
            this.lblModifiedOn.Text = "Last Update :";
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.BackColor = System.Drawing.Color.White;
            this.txtModifiedBy.BorderColor = System.Drawing.Color.Black;
            this.txtModifiedBy.CanGrow = false;
            this.txtModifiedBy.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtModifiedBy.ForeColor = System.Drawing.Color.Black;
            this.txtModifiedBy.Location = new System.Drawing.Point(690, 10);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtModifiedBy.ParentStyleUsing.UseBackColor = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorderColor = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorders = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorderWidth = false;
            this.txtModifiedBy.ParentStyleUsing.UseFont = false;
            this.txtModifiedBy.ParentStyleUsing.UseForeColor = false;
            this.txtModifiedBy.Size = new System.Drawing.Size(81, 14);
            this.txtModifiedBy.Text = "txtModifiedBy";
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.BackColor = System.Drawing.Color.White;
            this.lblModifiedBy.BorderColor = System.Drawing.Color.Black;
            this.lblModifiedBy.CanGrow = false;
            this.lblModifiedBy.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblModifiedBy.ForeColor = System.Drawing.Color.Black;
            this.lblModifiedBy.Location = new System.Drawing.Point(590, 10);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblModifiedBy.ParentStyleUsing.UseBackColor = false;
            this.lblModifiedBy.ParentStyleUsing.UseBorderColor = false;
            this.lblModifiedBy.ParentStyleUsing.UseBorders = false;
            this.lblModifiedBy.ParentStyleUsing.UseBorderWidth = false;
            this.lblModifiedBy.ParentStyleUsing.UseFont = false;
            this.lblModifiedBy.ParentStyleUsing.UseForeColor = false;
            this.lblModifiedBy.Size = new System.Drawing.Size(100, 14);
            this.lblModifiedBy.Text = "Last User   :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderColor = System.Drawing.Color.Black;
            this.txtRemarks.CanGrow = false;
            this.txtRemarks.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(310, 60);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtRemarks.ParentStyleUsing.UseBackColor = false;
            this.txtRemarks.ParentStyleUsing.UseBorderColor = false;
            this.txtRemarks.ParentStyleUsing.UseBorders = false;
            this.txtRemarks.ParentStyleUsing.UseBorderWidth = false;
            this.txtRemarks.ParentStyleUsing.UseFont = false;
            this.txtRemarks.ParentStyleUsing.UseForeColor = false;
            this.txtRemarks.Size = new System.Drawing.Size(275, 15);
            this.txtRemarks.Text = "txtRemarks";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.White;
            this.lblRemarks.BorderColor = System.Drawing.Color.Black;
            this.lblRemarks.CanGrow = false;
            this.lblRemarks.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(225, 60);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRemarks.ParentStyleUsing.UseBackColor = false;
            this.lblRemarks.ParentStyleUsing.UseBorderColor = false;
            this.lblRemarks.ParentStyleUsing.UseBorders = false;
            this.lblRemarks.ParentStyleUsing.UseBorderWidth = false;
            this.lblRemarks.ParentStyleUsing.UseFont = false;
            this.lblRemarks.ParentStyleUsing.UseForeColor = false;
            this.lblRemarks.Size = new System.Drawing.Size(75, 15);
            this.lblRemarks.Text = "Remarks  :";
            // 
            // txtLocationName
            // 
            this.txtLocationName.BackColor = System.Drawing.Color.White;
            this.txtLocationName.BorderColor = System.Drawing.Color.Black;
            this.txtLocationName.CanGrow = false;
            this.txtLocationName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtLocationName.ForeColor = System.Drawing.Color.Black;
            this.txtLocationName.Location = new System.Drawing.Point(365, 25);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLocationName.ParentStyleUsing.UseBackColor = false;
            this.txtLocationName.ParentStyleUsing.UseBorderColor = false;
            this.txtLocationName.ParentStyleUsing.UseBorders = false;
            this.txtLocationName.ParentStyleUsing.UseBorderWidth = false;
            this.txtLocationName.ParentStyleUsing.UseFont = false;
            this.txtLocationName.ParentStyleUsing.UseForeColor = false;
            this.txtLocationName.Size = new System.Drawing.Size(216, 15);
            this.txtLocationName.Text = "txtLocationName";
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.BackColor = System.Drawing.Color.White;
            this.txtLocationCode.BorderColor = System.Drawing.Color.Black;
            this.txtLocationCode.CanGrow = false;
            this.txtLocationCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtLocationCode.ForeColor = System.Drawing.Color.Black;
            this.txtLocationCode.Location = new System.Drawing.Point(310, 25);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLocationCode.ParentStyleUsing.UseBackColor = false;
            this.txtLocationCode.ParentStyleUsing.UseBorderColor = false;
            this.txtLocationCode.ParentStyleUsing.UseBorders = false;
            this.txtLocationCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtLocationCode.ParentStyleUsing.UseFont = false;
            this.txtLocationCode.ParentStyleUsing.UseForeColor = false;
            this.txtLocationCode.Size = new System.Drawing.Size(50, 15);
            this.txtLocationCode.Text = "txtLocationCode";
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.White;
            this.lblLocation.BorderColor = System.Drawing.Color.Black;
            this.lblLocation.CanGrow = false;
            this.lblLocation.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(225, 25);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblLocation.ParentStyleUsing.UseBackColor = false;
            this.lblLocation.ParentStyleUsing.UseBorderColor = false;
            this.lblLocation.ParentStyleUsing.UseBorders = false;
            this.lblLocation.ParentStyleUsing.UseBorderWidth = false;
            this.lblLocation.ParentStyleUsing.UseFont = false;
            this.lblLocation.ParentStyleUsing.UseForeColor = false;
            this.lblLocation.Size = new System.Drawing.Size(75, 15);
            this.lblLocation.Text = "Location :";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.BackColor = System.Drawing.Color.White;
            this.txtOperatorName.BorderColor = System.Drawing.Color.Black;
            this.txtOperatorName.CanGrow = false;
            this.txtOperatorName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtOperatorName.ForeColor = System.Drawing.Color.Black;
            this.txtOperatorName.Location = new System.Drawing.Point(365, 10);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOperatorName.ParentStyleUsing.UseBackColor = false;
            this.txtOperatorName.ParentStyleUsing.UseBorderColor = false;
            this.txtOperatorName.ParentStyleUsing.UseBorders = false;
            this.txtOperatorName.ParentStyleUsing.UseBorderWidth = false;
            this.txtOperatorName.ParentStyleUsing.UseFont = false;
            this.txtOperatorName.ParentStyleUsing.UseForeColor = false;
            this.txtOperatorName.Size = new System.Drawing.Size(216, 15);
            this.txtOperatorName.Text = "txtOperatorName";
            // 
            // txtOperatorCode
            // 
            this.txtOperatorCode.BackColor = System.Drawing.Color.White;
            this.txtOperatorCode.BorderColor = System.Drawing.Color.Black;
            this.txtOperatorCode.CanGrow = false;
            this.txtOperatorCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtOperatorCode.ForeColor = System.Drawing.Color.Black;
            this.txtOperatorCode.Location = new System.Drawing.Point(310, 10);
            this.txtOperatorCode.Name = "txtOperatorCode";
            this.txtOperatorCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOperatorCode.ParentStyleUsing.UseBackColor = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorderColor = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorders = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtOperatorCode.ParentStyleUsing.UseFont = false;
            this.txtOperatorCode.ParentStyleUsing.UseForeColor = false;
            this.txtOperatorCode.Size = new System.Drawing.Size(50, 15);
            this.txtOperatorCode.Text = "txtOperatorCode";
            // 
            // lblOperator
            // 
            this.lblOperator.BackColor = System.Drawing.Color.White;
            this.lblOperator.BorderColor = System.Drawing.Color.Black;
            this.lblOperator.CanGrow = false;
            this.lblOperator.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblOperator.ForeColor = System.Drawing.Color.Black;
            this.lblOperator.Location = new System.Drawing.Point(225, 10);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOperator.ParentStyleUsing.UseBackColor = false;
            this.lblOperator.ParentStyleUsing.UseBorderColor = false;
            this.lblOperator.ParentStyleUsing.UseBorders = false;
            this.lblOperator.ParentStyleUsing.UseBorderWidth = false;
            this.lblOperator.ParentStyleUsing.UseFont = false;
            this.lblOperator.ParentStyleUsing.UseForeColor = false;
            this.lblOperator.Size = new System.Drawing.Size(75, 15);
            this.lblOperator.Text = "Operator :";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.White;
            this.txtSupplierName.BorderColor = System.Drawing.Color.Black;
            this.txtSupplierName.CanGrow = false;
            this.txtSupplierName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtSupplierName.ForeColor = System.Drawing.Color.Black;
            this.txtSupplierName.Location = new System.Drawing.Point(365, 40);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSupplierName.ParentStyleUsing.UseBackColor = false;
            this.txtSupplierName.ParentStyleUsing.UseBorderColor = false;
            this.txtSupplierName.ParentStyleUsing.UseBorders = false;
            this.txtSupplierName.ParentStyleUsing.UseBorderWidth = false;
            this.txtSupplierName.ParentStyleUsing.UseFont = false;
            this.txtSupplierName.ParentStyleUsing.UseForeColor = false;
            this.txtSupplierName.Size = new System.Drawing.Size(216, 15);
            this.txtSupplierName.Text = "txtSupplierName";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.Color.White;
            this.txtSupplierCode.BorderColor = System.Drawing.Color.Black;
            this.txtSupplierCode.CanGrow = false;
            this.txtSupplierCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtSupplierCode.ForeColor = System.Drawing.Color.Black;
            this.txtSupplierCode.Location = new System.Drawing.Point(310, 40);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSupplierCode.ParentStyleUsing.UseBackColor = false;
            this.txtSupplierCode.ParentStyleUsing.UseBorderColor = false;
            this.txtSupplierCode.ParentStyleUsing.UseBorders = false;
            this.txtSupplierCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtSupplierCode.ParentStyleUsing.UseFont = false;
            this.txtSupplierCode.ParentStyleUsing.UseForeColor = false;
            this.txtSupplierCode.Size = new System.Drawing.Size(50, 15);
            this.txtSupplierCode.Text = "txtSupplierCode";
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.White;
            this.lblSupplier.BorderColor = System.Drawing.Color.Black;
            this.lblSupplier.CanGrow = false;
            this.lblSupplier.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblSupplier.ForeColor = System.Drawing.Color.Black;
            this.lblSupplier.Location = new System.Drawing.Point(225, 40);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSupplier.ParentStyleUsing.UseBackColor = false;
            this.lblSupplier.ParentStyleUsing.UseBorderColor = false;
            this.lblSupplier.ParentStyleUsing.UseBorders = false;
            this.lblSupplier.ParentStyleUsing.UseBorderWidth = false;
            this.lblSupplier.ParentStyleUsing.UseFont = false;
            this.lblSupplier.ParentStyleUsing.UseForeColor = false;
            this.lblSupplier.Size = new System.Drawing.Size(75, 15);
            this.lblSupplier.Text = "Supplier :";
            // 
            // txtTxDate
            // 
            this.txtTxDate.BackColor = System.Drawing.Color.White;
            this.txtTxDate.BorderColor = System.Drawing.Color.Black;
            this.txtTxDate.CanGrow = false;
            this.txtTxDate.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDate.ForeColor = System.Drawing.Color.Black;
            this.txtTxDate.Location = new System.Drawing.Point(135, 60);
            this.txtTxDate.Name = "txtTxDate";
            this.txtTxDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDate.ParentStyleUsing.UseBackColor = false;
            this.txtTxDate.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDate.ParentStyleUsing.UseBorders = false;
            this.txtTxDate.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDate.ParentStyleUsing.UseFont = false;
            this.txtTxDate.ParentStyleUsing.UseForeColor = false;
            this.txtTxDate.Size = new System.Drawing.Size(59, 12);
            this.txtTxDate.Text = "txtTxDate";
            // 
            // lblTxDate
            // 
            this.lblTxDate.BackColor = System.Drawing.Color.White;
            this.lblTxDate.BorderColor = System.Drawing.Color.Black;
            this.lblTxDate.CanGrow = false;
            this.lblTxDate.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblTxDate.ForeColor = System.Drawing.Color.Black;
            this.lblTxDate.Location = new System.Drawing.Point(15, 60);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDate.ParentStyleUsing.UseBackColor = false;
            this.lblTxDate.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDate.ParentStyleUsing.UseBorders = false;
            this.lblTxDate.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDate.ParentStyleUsing.UseFont = false;
            this.lblTxDate.ParentStyleUsing.UseForeColor = false;
            this.lblTxDate.Size = new System.Drawing.Size(116, 15);
            this.lblTxDate.Text = "Receive Date   :";
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.Color.White;
            this.txtReference.BorderColor = System.Drawing.Color.Black;
            this.txtReference.CanGrow = false;
            this.txtReference.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtReference.ForeColor = System.Drawing.Color.Black;
            this.txtReference.Location = new System.Drawing.Point(135, 25);
            this.txtReference.Name = "txtReference";
            this.txtReference.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtReference.ParentStyleUsing.UseBackColor = false;
            this.txtReference.ParentStyleUsing.UseBorderColor = false;
            this.txtReference.ParentStyleUsing.UseBorders = false;
            this.txtReference.ParentStyleUsing.UseBorderWidth = false;
            this.txtReference.ParentStyleUsing.UseFont = false;
            this.txtReference.ParentStyleUsing.UseForeColor = false;
            this.txtReference.Size = new System.Drawing.Size(90, 15);
            this.txtReference.Text = "txtReference";
            // 
            // lblReference
            // 
            this.lblReference.BackColor = System.Drawing.Color.White;
            this.lblReference.BorderColor = System.Drawing.Color.Black;
            this.lblReference.CanGrow = false;
            this.lblReference.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblReference.ForeColor = System.Drawing.Color.Black;
            this.lblReference.Location = new System.Drawing.Point(15, 25);
            this.lblReference.Name = "lblReference";
            this.lblReference.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReference.ParentStyleUsing.UseBackColor = false;
            this.lblReference.ParentStyleUsing.UseBorderColor = false;
            this.lblReference.ParentStyleUsing.UseBorders = false;
            this.lblReference.ParentStyleUsing.UseBorderWidth = false;
            this.lblReference.ParentStyleUsing.UseFont = false;
            this.lblReference.ParentStyleUsing.UseForeColor = false;
            this.lblReference.Size = new System.Drawing.Size(116, 15);
            this.lblReference.Text = "Reference No.  :";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.White;
            this.txtTxNumber.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumber.CanGrow = false;
            this.txtTxNumber.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.txtTxNumber.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumber.Location = new System.Drawing.Point(135, 10);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumber.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumber.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumber.ParentStyleUsing.UseBorders = false;
            this.txtTxNumber.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumber.ParentStyleUsing.UseFont = false;
            this.txtTxNumber.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumber.Size = new System.Drawing.Size(90, 15);
            this.txtTxNumber.Text = "txtTxNumber";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.BackColor = System.Drawing.Color.White;
            this.lblTxNumber.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumber.CanGrow = false;
            this.lblTxNumber.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxNumber.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumber.Location = new System.Drawing.Point(15, 10);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumber.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumber.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumber.ParentStyleUsing.UseBorders = false;
            this.lblTxNumber.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumber.ParentStyleUsing.UseFont = false;
            this.lblTxNumber.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumber.Size = new System.Drawing.Size(116, 15);
            this.lblTxNumber.Text = "Reject No.     :";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("STKCODE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 0;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("APPENDIX1", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.Height = 0;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("APPENDIX2", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.Height = 0;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("APPENDIX3", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader5.Height = 0;
            this.GroupHeader5.Level = 4;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text23,
            this.gfTotalAmount,
            this.gfTotalQty});
            this.GroupFooter1.Height = 23;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // Text23
            // 
            this.Text23.BackColor = System.Drawing.Color.White;
            this.Text23.BorderColor = System.Drawing.Color.Black;
            this.Text23.Font = new System.Drawing.Font("Arial Unicode MS", 8F);
            this.Text23.ForeColor = System.Drawing.Color.Black;
            this.Text23.Location = new System.Drawing.Point(375, 0);
            this.Text23.Name = "Text23";
            this.Text23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text23.ParentStyleUsing.UseBackColor = false;
            this.Text23.ParentStyleUsing.UseBorderColor = false;
            this.Text23.ParentStyleUsing.UseBorders = false;
            this.Text23.ParentStyleUsing.UseBorderWidth = false;
            this.Text23.ParentStyleUsing.UseFont = false;
            this.Text23.ParentStyleUsing.UseForeColor = false;
            this.Text23.Size = new System.Drawing.Size(125, 13);
            this.Text23.Text = "Sub Total :";
            this.Text23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // gfTotalAmount
            // 
            this.gfTotalAmount.BackColor = System.Drawing.Color.White;
            this.gfTotalAmount.BorderColor = System.Drawing.Color.Black;
            this.gfTotalAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.gfTotalAmount.CanGrow = false;
            this.gfTotalAmount.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.gfTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.gfTotalAmount.Location = new System.Drawing.Point(683, 0);
            this.gfTotalAmount.Name = "gfTotalAmount";
            this.gfTotalAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gfTotalAmount.ParentStyleUsing.UseBackColor = false;
            this.gfTotalAmount.ParentStyleUsing.UseBorderColor = false;
            this.gfTotalAmount.ParentStyleUsing.UseBorders = false;
            this.gfTotalAmount.ParentStyleUsing.UseBorderWidth = false;
            this.gfTotalAmount.ParentStyleUsing.UseFont = false;
            this.gfTotalAmount.ParentStyleUsing.UseForeColor = false;
            this.gfTotalAmount.Size = new System.Drawing.Size(86, 12);
            this.gfTotalAmount.Text = "gfTotalAmount";
            this.gfTotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // gfTotalQty
            // 
            this.gfTotalQty.BackColor = System.Drawing.Color.White;
            this.gfTotalQty.BorderColor = System.Drawing.Color.Black;
            this.gfTotalQty.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.gfTotalQty.CanGrow = false;
            this.gfTotalQty.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.gfTotalQty.ForeColor = System.Drawing.Color.Black;
            this.gfTotalQty.Location = new System.Drawing.Point(508, 0);
            this.gfTotalQty.Name = "gfTotalQty";
            this.gfTotalQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gfTotalQty.ParentStyleUsing.UseBackColor = false;
            this.gfTotalQty.ParentStyleUsing.UseBorderColor = false;
            this.gfTotalQty.ParentStyleUsing.UseBorders = false;
            this.gfTotalQty.ParentStyleUsing.UseBorderWidth = false;
            this.gfTotalQty.ParentStyleUsing.UseFont = false;
            this.gfTotalQty.ParentStyleUsing.UseForeColor = false;
            this.gfTotalQty.Size = new System.Drawing.Size(66, 12);
            this.gfTotalQty.Text = "gfTotalQty";
            this.gfTotalQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Height = 0;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Height = 0;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Height = 0;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Height = 0;
            this.GroupFooter5.Level = 4;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 16;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pnlPageInfo,
            this.phAppendix3,
            this.phAppendix2,
            this.phAppendix1,
            this.phStkCode,
            this.Line1,
            this.hdrCompName1,
            this.txtTxDateTo,
            this.txtTxDateFrom,
            this.lblTxDateTo,
            this.lblTxDateFrom,
            this.lblQty,
            this.lblUnitAmount,
            this.lblDescription,
            this.lblAmount,
            this.txtTxNumberTo,
            this.txtTxNumberFrom,
            this.lblTxNumberTo,
            this.lblTxNumberFrom,
            this.Text3});
            this.PageHeader.Height = 118;
            this.PageHeader.Name = "PageHeader";
            // 
            // pnlPageInfo
            // 
            this.pnlPageInfo.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblPrintedOn,
            this.phPageNumber,
            this.phDateTime,
            this.lblPage});
            this.pnlPageInfo.Location = new System.Drawing.Point(608, 42);
            this.pnlPageInfo.Name = "pnlPageInfo";
            this.pnlPageInfo.Size = new System.Drawing.Size(166, 28);
            // 
            // lblPrintedOn
            // 
            this.lblPrintedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblPrintedOn.Location = new System.Drawing.Point(0, 0);
            this.lblPrintedOn.Name = "lblPrintedOn";
            this.lblPrintedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintedOn.ParentStyleUsing.UseFont = false;
            this.lblPrintedOn.Size = new System.Drawing.Size(58, 14);
            this.lblPrintedOn.Text = "Printed On:";
            // 
            // phPageNumber
            // 
            this.phPageNumber.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phPageNumber.Location = new System.Drawing.Point(58, 14);
            this.phPageNumber.Name = "phPageNumber";
            this.phPageNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phPageNumber.ParentStyleUsing.UseFont = false;
            this.phPageNumber.Size = new System.Drawing.Size(100, 14);
            // 
            // phDateTime
            // 
            this.phDateTime.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phDateTime.Format = "{0:dd/MM/yyyy HH:mm:ss}";
            this.phDateTime.Location = new System.Drawing.Point(58, 0);
            this.phDateTime.Name = "phDateTime";
            this.phDateTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phDateTime.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.phDateTime.ParentStyleUsing.UseFont = false;
            this.phDateTime.Size = new System.Drawing.Size(100, 14);
            // 
            // lblPage
            // 
            this.lblPage.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblPage.Location = new System.Drawing.Point(0, 14);
            this.lblPage.Name = "lblPage";
            this.lblPage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPage.ParentStyleUsing.UseFont = false;
            this.lblPage.Size = new System.Drawing.Size(58, 14);
            this.lblPage.Text = "Page:";
            // 
            // phAppendix3
            // 
            this.phAppendix3.BackColor = System.Drawing.Color.White;
            this.phAppendix3.BorderColor = System.Drawing.Color.Black;
            this.phAppendix3.CanGrow = false;
            this.phAppendix3.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.phAppendix3.ForeColor = System.Drawing.Color.Black;
            this.phAppendix3.Location = new System.Drawing.Point(175, 102);
            this.phAppendix3.Name = "phAppendix3";
            this.phAppendix3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix3.ParentStyleUsing.UseBackColor = false;
            this.phAppendix3.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix3.ParentStyleUsing.UseBorders = false;
            this.phAppendix3.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix3.ParentStyleUsing.UseFont = false;
            this.phAppendix3.ParentStyleUsing.UseForeColor = false;
            this.phAppendix3.Size = new System.Drawing.Size(40, 13);
            this.phAppendix3.Text = "phAppendix3";
            // 
            // phAppendix2
            // 
            this.phAppendix2.BackColor = System.Drawing.Color.White;
            this.phAppendix2.BorderColor = System.Drawing.Color.Black;
            this.phAppendix2.CanGrow = false;
            this.phAppendix2.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.phAppendix2.ForeColor = System.Drawing.Color.Black;
            this.phAppendix2.Location = new System.Drawing.Point(134, 102);
            this.phAppendix2.Name = "phAppendix2";
            this.phAppendix2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix2.ParentStyleUsing.UseBackColor = false;
            this.phAppendix2.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix2.ParentStyleUsing.UseBorders = false;
            this.phAppendix2.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix2.ParentStyleUsing.UseFont = false;
            this.phAppendix2.ParentStyleUsing.UseForeColor = false;
            this.phAppendix2.Size = new System.Drawing.Size(40, 13);
            this.phAppendix2.Text = "phAppendix2";
            // 
            // phAppendix1
            // 
            this.phAppendix1.BackColor = System.Drawing.Color.White;
            this.phAppendix1.BorderColor = System.Drawing.Color.Black;
            this.phAppendix1.CanGrow = false;
            this.phAppendix1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.phAppendix1.ForeColor = System.Drawing.Color.Black;
            this.phAppendix1.Location = new System.Drawing.Point(90, 102);
            this.phAppendix1.Name = "phAppendix1";
            this.phAppendix1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix1.ParentStyleUsing.UseBackColor = false;
            this.phAppendix1.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix1.ParentStyleUsing.UseBorders = false;
            this.phAppendix1.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix1.ParentStyleUsing.UseFont = false;
            this.phAppendix1.ParentStyleUsing.UseForeColor = false;
            this.phAppendix1.Size = new System.Drawing.Size(43, 13);
            this.phAppendix1.Text = "phAppendix1";
            // 
            // phStkCode
            // 
            this.phStkCode.BackColor = System.Drawing.Color.White;
            this.phStkCode.BorderColor = System.Drawing.Color.Black;
            this.phStkCode.CanGrow = false;
            this.phStkCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.phStkCode.ForeColor = System.Drawing.Color.Black;
            this.phStkCode.Location = new System.Drawing.Point(15, 102);
            this.phStkCode.Name = "phStkCode";
            this.phStkCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phStkCode.ParentStyleUsing.UseBackColor = false;
            this.phStkCode.ParentStyleUsing.UseBorderColor = false;
            this.phStkCode.ParentStyleUsing.UseBorders = false;
            this.phStkCode.ParentStyleUsing.UseBorderWidth = false;
            this.phStkCode.ParentStyleUsing.UseFont = false;
            this.phStkCode.ParentStyleUsing.UseForeColor = false;
            this.phStkCode.Size = new System.Drawing.Size(75, 13);
            this.phStkCode.Text = "phStkCode";
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.White;
            this.Line1.BorderColor = System.Drawing.Color.Black;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.CanGrow = false;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(15, 116);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(759, 2);
            // 
            // hdrCompName1
            // 
            this.hdrCompName1.BackColor = System.Drawing.Color.White;
            this.hdrCompName1.BorderColor = System.Drawing.Color.Black;
            this.hdrCompName1.CanGrow = false;
            this.hdrCompName1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.hdrCompName1.ForeColor = System.Drawing.Color.Black;
            this.hdrCompName1.Location = new System.Drawing.Point(15, 0);
            this.hdrCompName1.Name = "hdrCompName1";
            this.hdrCompName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdrCompName1.ParentStyleUsing.UseBackColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorders = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderWidth = false;
            this.hdrCompName1.ParentStyleUsing.UseFont = false;
            this.hdrCompName1.ParentStyleUsing.UseForeColor = false;
            this.hdrCompName1.Size = new System.Drawing.Size(585, 11);
            // 
            // txtTxDateTo
            // 
            this.txtTxDateTo.BackColor = System.Drawing.Color.White;
            this.txtTxDateTo.BorderColor = System.Drawing.Color.Black;
            this.txtTxDateTo.CanGrow = false;
            this.txtTxDateTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDateTo.ForeColor = System.Drawing.Color.Black;
            this.txtTxDateTo.Location = new System.Drawing.Point(375, 59);
            this.txtTxDateTo.Name = "txtTxDateTo";
            this.txtTxDateTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDateTo.ParentStyleUsing.UseBackColor = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorders = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDateTo.ParentStyleUsing.UseFont = false;
            this.txtTxDateTo.ParentStyleUsing.UseForeColor = false;
            this.txtTxDateTo.Size = new System.Drawing.Size(141, 11);
            this.txtTxDateTo.Text = "txtTxDateTo";
            // 
            // txtTxDateFrom
            // 
            this.txtTxDateFrom.BackColor = System.Drawing.Color.White;
            this.txtTxDateFrom.BorderColor = System.Drawing.Color.Black;
            this.txtTxDateFrom.CanGrow = false;
            this.txtTxDateFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDateFrom.ForeColor = System.Drawing.Color.Black;
            this.txtTxDateFrom.Location = new System.Drawing.Point(375, 43);
            this.txtTxDateFrom.Name = "txtTxDateFrom";
            this.txtTxDateFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDateFrom.ParentStyleUsing.UseBackColor = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorders = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDateFrom.ParentStyleUsing.UseFont = false;
            this.txtTxDateFrom.ParentStyleUsing.UseForeColor = false;
            this.txtTxDateFrom.Size = new System.Drawing.Size(141, 11);
            this.txtTxDateFrom.Text = "txtTxDateFrom";
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.BackColor = System.Drawing.Color.White;
            this.lblTxDateTo.BorderColor = System.Drawing.Color.Black;
            this.lblTxDateTo.CanGrow = false;
            this.lblTxDateTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblTxDateTo.ForeColor = System.Drawing.Color.Black;
            this.lblTxDateTo.Location = new System.Drawing.Point(283, 59);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDateTo.ParentStyleUsing.UseBackColor = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorders = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDateTo.ParentStyleUsing.UseFont = false;
            this.lblTxDateTo.ParentStyleUsing.UseForeColor = false;
            this.lblTxDateTo.Size = new System.Drawing.Size(91, 13);
            this.lblTxDateTo.Text = "To Date :";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.BackColor = System.Drawing.Color.White;
            this.lblTxDateFrom.BorderColor = System.Drawing.Color.Black;
            this.lblTxDateFrom.CanGrow = false;
            this.lblTxDateFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblTxDateFrom.ForeColor = System.Drawing.Color.Black;
            this.lblTxDateFrom.Location = new System.Drawing.Point(283, 43);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDateFrom.ParentStyleUsing.UseBackColor = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorders = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDateFrom.ParentStyleUsing.UseFont = false;
            this.lblTxDateFrom.ParentStyleUsing.UseForeColor = false;
            this.lblTxDateFrom.Size = new System.Drawing.Size(91, 15);
            this.lblTxDateFrom.Text = "From Date :";
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.White;
            this.lblQty.BorderColor = System.Drawing.Color.Black;
            this.lblQty.CanGrow = false;
            this.lblQty.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(508, 102);
            this.lblQty.Name = "lblQty";
            this.lblQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblQty.ParentStyleUsing.UseBackColor = false;
            this.lblQty.ParentStyleUsing.UseBorderColor = false;
            this.lblQty.ParentStyleUsing.UseBorders = false;
            this.lblQty.ParentStyleUsing.UseBorderWidth = false;
            this.lblQty.ParentStyleUsing.UseFont = false;
            this.lblQty.ParentStyleUsing.UseForeColor = false;
            this.lblQty.Size = new System.Drawing.Size(66, 14);
            this.lblQty.Text = "Qty";
            this.lblQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblUnitAmount
            // 
            this.lblUnitAmount.BackColor = System.Drawing.Color.White;
            this.lblUnitAmount.BorderColor = System.Drawing.Color.Black;
            this.lblUnitAmount.CanGrow = false;
            this.lblUnitAmount.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblUnitAmount.ForeColor = System.Drawing.Color.Black;
            this.lblUnitAmount.Location = new System.Drawing.Point(583, 102);
            this.lblUnitAmount.Name = "lblUnitAmount";
            this.lblUnitAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblUnitAmount.ParentStyleUsing.UseBackColor = false;
            this.lblUnitAmount.ParentStyleUsing.UseBorderColor = false;
            this.lblUnitAmount.ParentStyleUsing.UseBorders = false;
            this.lblUnitAmount.ParentStyleUsing.UseBorderWidth = false;
            this.lblUnitAmount.ParentStyleUsing.UseFont = false;
            this.lblUnitAmount.ParentStyleUsing.UseForeColor = false;
            this.lblUnitAmount.Size = new System.Drawing.Size(85, 14);
            this.lblUnitAmount.Text = "Unit Amount";
            this.lblUnitAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.BorderColor = System.Drawing.Color.Black;
            this.lblDescription.CanGrow = false;
            this.lblDescription.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(216, 102);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDescription.ParentStyleUsing.UseBackColor = false;
            this.lblDescription.ParentStyleUsing.UseBorderColor = false;
            this.lblDescription.ParentStyleUsing.UseBorders = false;
            this.lblDescription.ParentStyleUsing.UseBorderWidth = false;
            this.lblDescription.ParentStyleUsing.UseFont = false;
            this.lblDescription.ParentStyleUsing.UseForeColor = false;
            this.lblDescription.Size = new System.Drawing.Size(120, 14);
            this.lblDescription.Text = "Description ";
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.White;
            this.lblAmount.BorderColor = System.Drawing.Color.Black;
            this.lblAmount.CanGrow = false;
            this.lblAmount.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(685, 102);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAmount.ParentStyleUsing.UseBackColor = false;
            this.lblAmount.ParentStyleUsing.UseBorderColor = false;
            this.lblAmount.ParentStyleUsing.UseBorders = false;
            this.lblAmount.ParentStyleUsing.UseBorderWidth = false;
            this.lblAmount.ParentStyleUsing.UseFont = false;
            this.lblAmount.ParentStyleUsing.UseForeColor = false;
            this.lblAmount.Size = new System.Drawing.Size(86, 14);
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTxNumberTo
            // 
            this.txtTxNumberTo.BackColor = System.Drawing.Color.White;
            this.txtTxNumberTo.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumberTo.CanGrow = false;
            this.txtTxNumberTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxNumberTo.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumberTo.Location = new System.Drawing.Point(141, 59);
            this.txtTxNumberTo.Name = "txtTxNumberTo";
            this.txtTxNumberTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumberTo.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorders = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumberTo.ParentStyleUsing.UseFont = false;
            this.txtTxNumberTo.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumberTo.Size = new System.Drawing.Size(133, 13);
            this.txtTxNumberTo.Text = "txtTxNumberTo";
            // 
            // txtTxNumberFrom
            // 
            this.txtTxNumberFrom.BackColor = System.Drawing.Color.White;
            this.txtTxNumberFrom.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumberFrom.CanGrow = false;
            this.txtTxNumberFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumberFrom.Location = new System.Drawing.Point(141, 43);
            this.txtTxNumberFrom.Name = "txtTxNumberFrom";
            this.txtTxNumberFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumberFrom.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorders = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseFont = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumberFrom.Size = new System.Drawing.Size(133, 16);
            this.txtTxNumberFrom.Text = "txtTxNumberFrom";
            // 
            // lblTxNumberTo
            // 
            this.lblTxNumberTo.BackColor = System.Drawing.Color.White;
            this.lblTxNumberTo.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumberTo.CanGrow = false;
            this.lblTxNumberTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblTxNumberTo.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumberTo.Location = new System.Drawing.Point(15, 59);
            this.lblTxNumberTo.Name = "lblTxNumberTo";
            this.lblTxNumberTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumberTo.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorders = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumberTo.ParentStyleUsing.UseFont = false;
            this.lblTxNumberTo.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumberTo.Size = new System.Drawing.Size(125, 13);
            this.lblTxNumberTo.Text = "To Reject No   :";
            // 
            // lblTxNumberFrom
            // 
            this.lblTxNumberFrom.BackColor = System.Drawing.Color.White;
            this.lblTxNumberFrom.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumberFrom.CanGrow = false;
            this.lblTxNumberFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblTxNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumberFrom.Location = new System.Drawing.Point(15, 43);
            this.lblTxNumberFrom.Name = "lblTxNumberFrom";
            this.lblTxNumberFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumberFrom.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorders = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseFont = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumberFrom.Size = new System.Drawing.Size(125, 15);
            this.lblTxNumberFrom.Text = "From Reject No : ";
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.White;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.Location = new System.Drawing.Point(15, 11);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.ParentStyleUsing.UseBackColor = false;
            this.Text3.ParentStyleUsing.UseBorderColor = false;
            this.Text3.ParentStyleUsing.UseBorders = false;
            this.Text3.ParentStyleUsing.UseBorderWidth = false;
            this.Text3.ParentStyleUsing.UseFont = false;
            this.Text3.ParentStyleUsing.UseForeColor = false;
            this.Text3.Size = new System.Drawing.Size(585, 15);
            this.Text3.Text = "RJ5100A - Stock Reject History";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Visible = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Visible = false;
            // 
            // HistoryRpt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupHeader5,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupFooter4,
            this.GroupFooter5,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.HistoryRpt_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtModifiedOn;
        private DevExpress.XtraReports.UI.XRLabel lblModifiedOn;
        private DevExpress.XtraReports.UI.XRLabel txtModifiedBy;
        private DevExpress.XtraReports.UI.XRLabel lblModifiedBy;
        private DevExpress.XtraReports.UI.XRLabel txtRemarks;
        private DevExpress.XtraReports.UI.XRLabel lblRemarks;
        private DevExpress.XtraReports.UI.XRLabel txtLocationName;
        private DevExpress.XtraReports.UI.XRLabel txtLocationCode;
        private DevExpress.XtraReports.UI.XRLabel lblLocation;
        private DevExpress.XtraReports.UI.XRLabel txtOperatorName;
        private DevExpress.XtraReports.UI.XRLabel txtOperatorCode;
        private DevExpress.XtraReports.UI.XRLabel lblOperator;
        private DevExpress.XtraReports.UI.XRLabel txtSupplierName;
        private DevExpress.XtraReports.UI.XRLabel txtSupplierCode;
        private DevExpress.XtraReports.UI.XRLabel lblSupplier;
        private DevExpress.XtraReports.UI.XRLabel txtTxDate;
        private DevExpress.XtraReports.UI.XRLabel lblTxDate;
        private DevExpress.XtraReports.UI.XRLabel txtReference;
        private DevExpress.XtraReports.UI.XRLabel lblReference;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumber;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumber;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader5;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter5;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel phAppendix3;
        private DevExpress.XtraReports.UI.XRLabel phAppendix2;
        private DevExpress.XtraReports.UI.XRLabel phAppendix1;
        private DevExpress.XtraReports.UI.XRLabel phStkCode;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel hdrCompName1;
        private DevExpress.XtraReports.UI.XRLabel txtTxDateTo;
        private DevExpress.XtraReports.UI.XRLabel txtTxDateFrom;
        private DevExpress.XtraReports.UI.XRLabel lblTxDateTo;
        private DevExpress.XtraReports.UI.XRLabel lblTxDateFrom;
        private DevExpress.XtraReports.UI.XRLabel lblQty;
        private DevExpress.XtraReports.UI.XRLabel lblUnitAmount;
        private DevExpress.XtraReports.UI.XRLabel lblDescription;
        private DevExpress.XtraReports.UI.XRLabel lblAmount;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumberTo;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumberFrom;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumberTo;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumberFrom;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPanel pnlPageInfo;
        private DevExpress.XtraReports.UI.XRLabel lblPrintedOn;
        private DevExpress.XtraReports.UI.XRPageInfo phPageNumber;
        private DevExpress.XtraReports.UI.XRPageInfo phDateTime;
        private DevExpress.XtraReports.UI.XRLabel lblPage;
        private DevExpress.XtraReports.UI.XRLabel Text23;
        private DevExpress.XtraReports.UI.XRLabel gfTotalAmount;
        private DevExpress.XtraReports.UI.XRLabel gfTotalQty;
        private DevExpress.XtraReports.UI.XRSubreport rptDetails;
        private DevExpress.XtraReports.UI.XRLabel txtHeaderId;

    }
}
