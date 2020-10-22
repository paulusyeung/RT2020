namespace RT2020.Inventory.Replenishment.Reports
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
            this.txtOperatorName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFmLocationName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtToLocationName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtToLocationCode = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFmLocationCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDate = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOperator = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTransferredOn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCompletedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.lblModifiedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.lblToLocation = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFmLocation = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.txtModifiedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.txtModifiedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtRemarks = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCompletedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTransferredOn = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOperatorCode = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.pnlPageInfo = new DevExpress.XtraReports.UI.XRPanel();
            this.phPageNumber = new DevExpress.XtraReports.UI.XRPageInfo();
            this.phDateTime = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblPage = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrCompName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.phWarehouse = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDateFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxDateTo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDateTo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxDateFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.phStkCode = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix3 = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix2 = new DevExpress.XtraReports.UI.XRLabel();
            this.phAppendix1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblQtyReceived = new DevExpress.XtraReports.UI.XRLabel();
            this.lblQtyRequested = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDescription = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumberFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumberFrom = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTxNumberTo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTxNumberTo = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rptDetails});
            this.Detail.Height = 17;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // rptDetails
            // 
            this.rptDetails.Location = new System.Drawing.Point(0, 0);
            this.rptDetails.Name = "rptDetails";
            this.rptDetails.Size = new System.Drawing.Size(1009, 17);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtHeaderId,
            this.txtOperatorName,
            this.txtFmLocationName,
            this.txtToLocationName,
            this.txtToLocationCode,
            this.txtFmLocationCode,
            this.lblTxDate,
            this.txtTxDate,
            this.lblRemarks,
            this.lblOperator,
            this.lblTransferredOn,
            this.lblCompletedOn,
            this.lblStatus,
            this.lblModifiedOn,
            this.lblToLocation,
            this.lblFmLocation,
            this.lblTxNumber,
            this.txtModifiedOn,
            this.txtModifiedBy,
            this.txtStatus,
            this.txtRemarks,
            this.txtCompletedOn,
            this.txtTransferredOn,
            this.txtOperatorCode,
            this.txtTxNumber});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TRNNO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 110;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // txtHeaderId
            // 
            this.txtHeaderId.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtHeaderId.Location = new System.Drawing.Point(842, 83);
            this.txtHeaderId.Name = "txtHeaderId";
            this.txtHeaderId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeaderId.ParentStyleUsing.UseFont = false;
            this.txtHeaderId.Size = new System.Drawing.Size(108, 14);
            this.txtHeaderId.Text = "txtHeaderId";
            this.txtHeaderId.Visible = false;
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.BackColor = System.Drawing.Color.White;
            this.txtOperatorName.BorderColor = System.Drawing.Color.Black;
            this.txtOperatorName.CanGrow = false;
            this.txtOperatorName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtOperatorName.ForeColor = System.Drawing.Color.Black;
            this.txtOperatorName.Location = new System.Drawing.Point(216, 33);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOperatorName.ParentStyleUsing.UseBackColor = false;
            this.txtOperatorName.ParentStyleUsing.UseBorderColor = false;
            this.txtOperatorName.ParentStyleUsing.UseBorders = false;
            this.txtOperatorName.ParentStyleUsing.UseBorderWidth = false;
            this.txtOperatorName.ParentStyleUsing.UseFont = false;
            this.txtOperatorName.ParentStyleUsing.UseForeColor = false;
            this.txtOperatorName.Size = new System.Drawing.Size(191, 14);
            this.txtOperatorName.Text = "txtOperatorName";
            // 
            // txtFmLocationName
            // 
            this.txtFmLocationName.BackColor = System.Drawing.Color.White;
            this.txtFmLocationName.BorderColor = System.Drawing.Color.Black;
            this.txtFmLocationName.CanGrow = false;
            this.txtFmLocationName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtFmLocationName.ForeColor = System.Drawing.Color.Black;
            this.txtFmLocationName.Location = new System.Drawing.Point(216, 50);
            this.txtFmLocationName.Name = "txtFmLocationName";
            this.txtFmLocationName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFmLocationName.ParentStyleUsing.UseBackColor = false;
            this.txtFmLocationName.ParentStyleUsing.UseBorderColor = false;
            this.txtFmLocationName.ParentStyleUsing.UseBorders = false;
            this.txtFmLocationName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFmLocationName.ParentStyleUsing.UseFont = false;
            this.txtFmLocationName.ParentStyleUsing.UseForeColor = false;
            this.txtFmLocationName.Size = new System.Drawing.Size(191, 14);
            this.txtFmLocationName.Text = "txtFmLocationName";
            // 
            // txtToLocationName
            // 
            this.txtToLocationName.BackColor = System.Drawing.Color.White;
            this.txtToLocationName.BorderColor = System.Drawing.Color.Black;
            this.txtToLocationName.CanGrow = false;
            this.txtToLocationName.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtToLocationName.ForeColor = System.Drawing.Color.Black;
            this.txtToLocationName.Location = new System.Drawing.Point(591, 50);
            this.txtToLocationName.Name = "txtToLocationName";
            this.txtToLocationName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtToLocationName.ParentStyleUsing.UseBackColor = false;
            this.txtToLocationName.ParentStyleUsing.UseBorderColor = false;
            this.txtToLocationName.ParentStyleUsing.UseBorders = false;
            this.txtToLocationName.ParentStyleUsing.UseBorderWidth = false;
            this.txtToLocationName.ParentStyleUsing.UseFont = false;
            this.txtToLocationName.ParentStyleUsing.UseForeColor = false;
            this.txtToLocationName.Size = new System.Drawing.Size(191, 14);
            this.txtToLocationName.Text = "txtToLocationName";
            // 
            // txtToLocationCode
            // 
            this.txtToLocationCode.BackColor = System.Drawing.Color.White;
            this.txtToLocationCode.BorderColor = System.Drawing.Color.Black;
            this.txtToLocationCode.CanGrow = false;
            this.txtToLocationCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtToLocationCode.ForeColor = System.Drawing.Color.Black;
            this.txtToLocationCode.Location = new System.Drawing.Point(541, 50);
            this.txtToLocationCode.Name = "txtToLocationCode";
            this.txtToLocationCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtToLocationCode.ParentStyleUsing.UseBackColor = false;
            this.txtToLocationCode.ParentStyleUsing.UseBorderColor = false;
            this.txtToLocationCode.ParentStyleUsing.UseBorders = false;
            this.txtToLocationCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtToLocationCode.ParentStyleUsing.UseFont = false;
            this.txtToLocationCode.ParentStyleUsing.UseForeColor = false;
            this.txtToLocationCode.Size = new System.Drawing.Size(50, 14);
            this.txtToLocationCode.Text = "txtToLocationCode";
            // 
            // txtFmLocationCode
            // 
            this.txtFmLocationCode.BackColor = System.Drawing.Color.White;
            this.txtFmLocationCode.BorderColor = System.Drawing.Color.Black;
            this.txtFmLocationCode.CanGrow = false;
            this.txtFmLocationCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtFmLocationCode.ForeColor = System.Drawing.Color.Black;
            this.txtFmLocationCode.Location = new System.Drawing.Point(133, 50);
            this.txtFmLocationCode.Name = "txtFmLocationCode";
            this.txtFmLocationCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFmLocationCode.ParentStyleUsing.UseBackColor = false;
            this.txtFmLocationCode.ParentStyleUsing.UseBorderColor = false;
            this.txtFmLocationCode.ParentStyleUsing.UseBorders = false;
            this.txtFmLocationCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtFmLocationCode.ParentStyleUsing.UseFont = false;
            this.txtFmLocationCode.ParentStyleUsing.UseForeColor = false;
            this.txtFmLocationCode.Size = new System.Drawing.Size(50, 14);
            this.txtFmLocationCode.Text = "txtFmLocationCode";
            // 
            // lblTxDate
            // 
            this.lblTxDate.BackColor = System.Drawing.Color.White;
            this.lblTxDate.BorderColor = System.Drawing.Color.Black;
            this.lblTxDate.CanGrow = false;
            this.lblTxDate.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxDate.ForeColor = System.Drawing.Color.Black;
            this.lblTxDate.Location = new System.Drawing.Point(8, 16);
            this.lblTxDate.Name = "lblTxDate";
            this.lblTxDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDate.ParentStyleUsing.UseBackColor = false;
            this.lblTxDate.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDate.ParentStyleUsing.UseBorders = false;
            this.lblTxDate.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDate.ParentStyleUsing.UseFont = false;
            this.lblTxDate.ParentStyleUsing.UseForeColor = false;
            this.lblTxDate.Size = new System.Drawing.Size(125, 14);
            this.lblTxDate.Text = "Transaction Date :";
            // 
            // txtTxDate
            // 
            this.txtTxDate.BackColor = System.Drawing.Color.White;
            this.txtTxDate.BorderColor = System.Drawing.Color.Black;
            this.txtTxDate.CanGrow = false;
            this.txtTxDate.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDate.ForeColor = System.Drawing.Color.Black;
            this.txtTxDate.Location = new System.Drawing.Point(133, 16);
            this.txtTxDate.Name = "txtTxDate";
            this.txtTxDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDate.ParentStyleUsing.UseBackColor = false;
            this.txtTxDate.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDate.ParentStyleUsing.UseBorders = false;
            this.txtTxDate.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDate.ParentStyleUsing.UseFont = false;
            this.txtTxDate.ParentStyleUsing.UseForeColor = false;
            this.txtTxDate.Size = new System.Drawing.Size(77, 14);
            this.txtTxDate.Text = "txtTxDate";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.White;
            this.lblRemarks.BorderColor = System.Drawing.Color.Black;
            this.lblRemarks.CanGrow = false;
            this.lblRemarks.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(8, 83);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRemarks.ParentStyleUsing.UseBackColor = false;
            this.lblRemarks.ParentStyleUsing.UseBorderColor = false;
            this.lblRemarks.ParentStyleUsing.UseBorders = false;
            this.lblRemarks.ParentStyleUsing.UseBorderWidth = false;
            this.lblRemarks.ParentStyleUsing.UseFont = false;
            this.lblRemarks.ParentStyleUsing.UseForeColor = false;
            this.lblRemarks.Size = new System.Drawing.Size(125, 14);
            this.lblRemarks.Text = "Remarks :";
            // 
            // lblOperator
            // 
            this.lblOperator.BackColor = System.Drawing.Color.White;
            this.lblOperator.BorderColor = System.Drawing.Color.Black;
            this.lblOperator.CanGrow = false;
            this.lblOperator.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblOperator.ForeColor = System.Drawing.Color.Black;
            this.lblOperator.Location = new System.Drawing.Point(8, 33);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOperator.ParentStyleUsing.UseBackColor = false;
            this.lblOperator.ParentStyleUsing.UseBorderColor = false;
            this.lblOperator.ParentStyleUsing.UseBorders = false;
            this.lblOperator.ParentStyleUsing.UseBorderWidth = false;
            this.lblOperator.ParentStyleUsing.UseFont = false;
            this.lblOperator.ParentStyleUsing.UseForeColor = false;
            this.lblOperator.Size = new System.Drawing.Size(125, 14);
            this.lblOperator.Text = "Operator :";
            // 
            // lblTransferredOn
            // 
            this.lblTransferredOn.BackColor = System.Drawing.Color.White;
            this.lblTransferredOn.BorderColor = System.Drawing.Color.Black;
            this.lblTransferredOn.CanGrow = false;
            this.lblTransferredOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTransferredOn.ForeColor = System.Drawing.Color.Black;
            this.lblTransferredOn.Location = new System.Drawing.Point(8, 66);
            this.lblTransferredOn.Name = "lblTransferredOn";
            this.lblTransferredOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTransferredOn.ParentStyleUsing.UseBackColor = false;
            this.lblTransferredOn.ParentStyleUsing.UseBorderColor = false;
            this.lblTransferredOn.ParentStyleUsing.UseBorders = false;
            this.lblTransferredOn.ParentStyleUsing.UseBorderWidth = false;
            this.lblTransferredOn.ParentStyleUsing.UseFont = false;
            this.lblTransferredOn.ParentStyleUsing.UseForeColor = false;
            this.lblTransferredOn.Size = new System.Drawing.Size(125, 14);
            this.lblTransferredOn.Text = "Transfer Date :";
            // 
            // lblCompletedOn
            // 
            this.lblCompletedOn.BackColor = System.Drawing.Color.White;
            this.lblCompletedOn.BorderColor = System.Drawing.Color.Black;
            this.lblCompletedOn.CanGrow = false;
            this.lblCompletedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblCompletedOn.ForeColor = System.Drawing.Color.Black;
            this.lblCompletedOn.Location = new System.Drawing.Point(416, 66);
            this.lblCompletedOn.Name = "lblCompletedOn";
            this.lblCompletedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCompletedOn.ParentStyleUsing.UseBackColor = false;
            this.lblCompletedOn.ParentStyleUsing.UseBorderColor = false;
            this.lblCompletedOn.ParentStyleUsing.UseBorders = false;
            this.lblCompletedOn.ParentStyleUsing.UseBorderWidth = false;
            this.lblCompletedOn.ParentStyleUsing.UseFont = false;
            this.lblCompletedOn.ParentStyleUsing.UseForeColor = false;
            this.lblCompletedOn.Size = new System.Drawing.Size(125, 14);
            this.lblCompletedOn.Text = "Completion Date :";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.BorderColor = System.Drawing.Color.Black;
            this.lblStatus.CanGrow = false;
            this.lblStatus.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(833, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStatus.ParentStyleUsing.UseBackColor = false;
            this.lblStatus.ParentStyleUsing.UseBorderColor = false;
            this.lblStatus.ParentStyleUsing.UseBorders = false;
            this.lblStatus.ParentStyleUsing.UseBorderWidth = false;
            this.lblStatus.ParentStyleUsing.UseFont = false;
            this.lblStatus.ParentStyleUsing.UseForeColor = false;
            this.lblStatus.Size = new System.Drawing.Size(100, 14);
            this.lblStatus.Text = "Status :";
            // 
            // lblModifiedOn
            // 
            this.lblModifiedOn.BackColor = System.Drawing.Color.White;
            this.lblModifiedOn.BorderColor = System.Drawing.Color.Black;
            this.lblModifiedOn.CanGrow = false;
            this.lblModifiedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblModifiedOn.ForeColor = System.Drawing.Color.Black;
            this.lblModifiedOn.Location = new System.Drawing.Point(833, 16);
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
            // lblToLocation
            // 
            this.lblToLocation.BackColor = System.Drawing.Color.White;
            this.lblToLocation.BorderColor = System.Drawing.Color.Black;
            this.lblToLocation.CanGrow = false;
            this.lblToLocation.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblToLocation.ForeColor = System.Drawing.Color.Black;
            this.lblToLocation.Location = new System.Drawing.Point(416, 50);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblToLocation.ParentStyleUsing.UseBackColor = false;
            this.lblToLocation.ParentStyleUsing.UseBorderColor = false;
            this.lblToLocation.ParentStyleUsing.UseBorders = false;
            this.lblToLocation.ParentStyleUsing.UseBorderWidth = false;
            this.lblToLocation.ParentStyleUsing.UseFont = false;
            this.lblToLocation.ParentStyleUsing.UseForeColor = false;
            this.lblToLocation.Size = new System.Drawing.Size(125, 14);
            this.lblToLocation.Text = "To Location :";
            // 
            // lblFmLocation
            // 
            this.lblFmLocation.BackColor = System.Drawing.Color.White;
            this.lblFmLocation.BorderColor = System.Drawing.Color.Black;
            this.lblFmLocation.CanGrow = false;
            this.lblFmLocation.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblFmLocation.ForeColor = System.Drawing.Color.Black;
            this.lblFmLocation.Location = new System.Drawing.Point(8, 50);
            this.lblFmLocation.Name = "lblFmLocation";
            this.lblFmLocation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFmLocation.ParentStyleUsing.UseBackColor = false;
            this.lblFmLocation.ParentStyleUsing.UseBorderColor = false;
            this.lblFmLocation.ParentStyleUsing.UseBorders = false;
            this.lblFmLocation.ParentStyleUsing.UseBorderWidth = false;
            this.lblFmLocation.ParentStyleUsing.UseFont = false;
            this.lblFmLocation.ParentStyleUsing.UseForeColor = false;
            this.lblFmLocation.Size = new System.Drawing.Size(125, 14);
            this.lblFmLocation.Text = "From Location :";
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.BackColor = System.Drawing.Color.White;
            this.lblTxNumber.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumber.CanGrow = false;
            this.lblTxNumber.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxNumber.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumber.Location = new System.Drawing.Point(8, 0);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumber.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumber.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumber.ParentStyleUsing.UseBorders = false;
            this.lblTxNumber.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumber.ParentStyleUsing.UseFont = false;
            this.lblTxNumber.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumber.Size = new System.Drawing.Size(125, 14);
            this.lblTxNumber.Text = "Transaction# : ";
            // 
            // txtModifiedOn
            // 
            this.txtModifiedOn.BackColor = System.Drawing.Color.White;
            this.txtModifiedOn.BorderColor = System.Drawing.Color.Black;
            this.txtModifiedOn.CanGrow = false;
            this.txtModifiedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtModifiedOn.ForeColor = System.Drawing.Color.Black;
            this.txtModifiedOn.Location = new System.Drawing.Point(933, 16);
            this.txtModifiedOn.Name = "txtModifiedOn";
            this.txtModifiedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtModifiedOn.ParentStyleUsing.UseBackColor = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorderColor = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorders = false;
            this.txtModifiedOn.ParentStyleUsing.UseBorderWidth = false;
            this.txtModifiedOn.ParentStyleUsing.UseFont = false;
            this.txtModifiedOn.ParentStyleUsing.UseForeColor = false;
            this.txtModifiedOn.Size = new System.Drawing.Size(75, 14);
            this.txtModifiedOn.Text = "txtModifiedOn";
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.BackColor = System.Drawing.Color.White;
            this.txtModifiedBy.BorderColor = System.Drawing.Color.Black;
            this.txtModifiedBy.CanGrow = false;
            this.txtModifiedBy.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtModifiedBy.ForeColor = System.Drawing.Color.Black;
            this.txtModifiedBy.Location = new System.Drawing.Point(933, 33);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtModifiedBy.ParentStyleUsing.UseBackColor = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorderColor = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorders = false;
            this.txtModifiedBy.ParentStyleUsing.UseBorderWidth = false;
            this.txtModifiedBy.ParentStyleUsing.UseFont = false;
            this.txtModifiedBy.ParentStyleUsing.UseForeColor = false;
            this.txtModifiedBy.Size = new System.Drawing.Size(75, 14);
            this.txtModifiedBy.Text = "txtModifiedBy";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.BorderColor = System.Drawing.Color.Black;
            this.txtStatus.CanGrow = false;
            this.txtStatus.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(933, 0);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStatus.ParentStyleUsing.UseBackColor = false;
            this.txtStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtStatus.ParentStyleUsing.UseBorders = false;
            this.txtStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtStatus.ParentStyleUsing.UseFont = false;
            this.txtStatus.ParentStyleUsing.UseForeColor = false;
            this.txtStatus.Size = new System.Drawing.Size(33, 14);
            this.txtStatus.Text = "txtStatus";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderColor = System.Drawing.Color.Black;
            this.txtRemarks.CanGrow = false;
            this.txtRemarks.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(133, 83);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtRemarks.ParentStyleUsing.UseBackColor = false;
            this.txtRemarks.ParentStyleUsing.UseBorderColor = false;
            this.txtRemarks.ParentStyleUsing.UseBorders = false;
            this.txtRemarks.ParentStyleUsing.UseBorderWidth = false;
            this.txtRemarks.ParentStyleUsing.UseFont = false;
            this.txtRemarks.ParentStyleUsing.UseForeColor = false;
            this.txtRemarks.Size = new System.Drawing.Size(208, 14);
            this.txtRemarks.Text = "txtRemarks";
            // 
            // txtCompletedOn
            // 
            this.txtCompletedOn.BackColor = System.Drawing.Color.White;
            this.txtCompletedOn.BorderColor = System.Drawing.Color.Black;
            this.txtCompletedOn.CanGrow = false;
            this.txtCompletedOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtCompletedOn.ForeColor = System.Drawing.Color.Black;
            this.txtCompletedOn.Location = new System.Drawing.Point(541, 66);
            this.txtCompletedOn.Name = "txtCompletedOn";
            this.txtCompletedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCompletedOn.ParentStyleUsing.UseBackColor = false;
            this.txtCompletedOn.ParentStyleUsing.UseBorderColor = false;
            this.txtCompletedOn.ParentStyleUsing.UseBorders = false;
            this.txtCompletedOn.ParentStyleUsing.UseBorderWidth = false;
            this.txtCompletedOn.ParentStyleUsing.UseFont = false;
            this.txtCompletedOn.ParentStyleUsing.UseForeColor = false;
            this.txtCompletedOn.Size = new System.Drawing.Size(72, 14);
            this.txtCompletedOn.Text = "txtCompletedOn";
            // 
            // txtTransferredOn
            // 
            this.txtTransferredOn.BackColor = System.Drawing.Color.White;
            this.txtTransferredOn.BorderColor = System.Drawing.Color.Black;
            this.txtTransferredOn.CanGrow = false;
            this.txtTransferredOn.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTransferredOn.ForeColor = System.Drawing.Color.Black;
            this.txtTransferredOn.Location = new System.Drawing.Point(133, 66);
            this.txtTransferredOn.Name = "txtTransferredOn";
            this.txtTransferredOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTransferredOn.ParentStyleUsing.UseBackColor = false;
            this.txtTransferredOn.ParentStyleUsing.UseBorderColor = false;
            this.txtTransferredOn.ParentStyleUsing.UseBorders = false;
            this.txtTransferredOn.ParentStyleUsing.UseBorderWidth = false;
            this.txtTransferredOn.ParentStyleUsing.UseFont = false;
            this.txtTransferredOn.ParentStyleUsing.UseForeColor = false;
            this.txtTransferredOn.Size = new System.Drawing.Size(77, 14);
            this.txtTransferredOn.Text = "txtTransferredOn";
            // 
            // txtOperatorCode
            // 
            this.txtOperatorCode.BackColor = System.Drawing.Color.White;
            this.txtOperatorCode.BorderColor = System.Drawing.Color.Black;
            this.txtOperatorCode.CanGrow = false;
            this.txtOperatorCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtOperatorCode.ForeColor = System.Drawing.Color.Black;
            this.txtOperatorCode.Location = new System.Drawing.Point(133, 33);
            this.txtOperatorCode.Name = "txtOperatorCode";
            this.txtOperatorCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOperatorCode.ParentStyleUsing.UseBackColor = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorderColor = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorders = false;
            this.txtOperatorCode.ParentStyleUsing.UseBorderWidth = false;
            this.txtOperatorCode.ParentStyleUsing.UseFont = false;
            this.txtOperatorCode.ParentStyleUsing.UseForeColor = false;
            this.txtOperatorCode.Size = new System.Drawing.Size(83, 14);
            this.txtOperatorCode.Text = "txtOperatorCode";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.BackColor = System.Drawing.Color.White;
            this.txtTxNumber.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumber.CanGrow = false;
            this.txtTxNumber.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxNumber.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumber.Location = new System.Drawing.Point(133, 0);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumber.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumber.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumber.ParentStyleUsing.UseBorders = false;
            this.txtTxNumber.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumber.ParentStyleUsing.UseFont = false;
            this.txtTxNumber.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumber.Size = new System.Drawing.Size(83, 14);
            this.txtTxNumber.Text = "txtTxNumber";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 46;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pnlPageInfo,
            this.hdrCompName1,
            this.phWarehouse,
            this.Text13,
            this.txtTxDateFrom,
            this.txtTxDateTo,
            this.lblTxDateTo,
            this.lblTxDateFrom,
            this.phStkCode,
            this.phAppendix3,
            this.phAppendix2,
            this.phAppendix1,
            this.lblQtyReceived,
            this.lblQtyRequested,
            this.lblDescription,
            this.Text7,
            this.txtTxNumberFrom,
            this.lblTxNumberFrom,
            this.txtTxNumberTo,
            this.lblTxNumberTo,
            this.Text4,
            this.hdrType1});
            this.PageHeader.Height = 133;
            this.PageHeader.Name = "PageHeader";
            // 
            // pnlPageInfo
            // 
            this.pnlPageInfo.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.phPageNumber,
            this.phDateTime,
            this.lblPage,
            this.lblPrintedOn});
            this.pnlPageInfo.Location = new System.Drawing.Point(833, 50);
            this.pnlPageInfo.Name = "pnlPageInfo";
            this.pnlPageInfo.Size = new System.Drawing.Size(166, 28);
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
            // hdrCompName1
            // 
            this.hdrCompName1.BackColor = System.Drawing.Color.White;
            this.hdrCompName1.BorderColor = System.Drawing.Color.Black;
            this.hdrCompName1.CanGrow = false;
            this.hdrCompName1.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold);
            this.hdrCompName1.ForeColor = System.Drawing.Color.Black;
            this.hdrCompName1.Location = new System.Drawing.Point(8, 0);
            this.hdrCompName1.Name = "hdrCompName1";
            this.hdrCompName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdrCompName1.ParentStyleUsing.UseBackColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorders = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderWidth = false;
            this.hdrCompName1.ParentStyleUsing.UseFont = false;
            this.hdrCompName1.ParentStyleUsing.UseForeColor = false;
            this.hdrCompName1.Size = new System.Drawing.Size(850, 17);
            this.hdrCompName1.Text = "Untranslated";
            // 
            // phWarehouse
            // 
            this.phWarehouse.BackColor = System.Drawing.Color.White;
            this.phWarehouse.BorderColor = System.Drawing.Color.Black;
            this.phWarehouse.CanGrow = false;
            this.phWarehouse.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phWarehouse.ForeColor = System.Drawing.Color.Black;
            this.phWarehouse.Location = new System.Drawing.Point(880, 100);
            this.phWarehouse.Name = "phWarehouse";
            this.phWarehouse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phWarehouse.ParentStyleUsing.UseBackColor = false;
            this.phWarehouse.ParentStyleUsing.UseBorderColor = false;
            this.phWarehouse.ParentStyleUsing.UseBorders = false;
            this.phWarehouse.ParentStyleUsing.UseBorderWidth = false;
            this.phWarehouse.ParentStyleUsing.UseFont = false;
            this.phWarehouse.ParentStyleUsing.UseForeColor = false;
            this.phWarehouse.Size = new System.Drawing.Size(86, 16);
            this.phWarehouse.Text = "phWarehouse";
            this.phWarehouse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text13
            // 
            this.Text13.BackColor = System.Drawing.Color.White;
            this.Text13.BorderColor = System.Drawing.Color.Black;
            this.Text13.CanGrow = false;
            this.Text13.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.Text13.ForeColor = System.Drawing.Color.Black;
            this.Text13.Location = new System.Drawing.Point(880, 116);
            this.Text13.Name = "Text13";
            this.Text13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text13.ParentStyleUsing.UseBackColor = false;
            this.Text13.ParentStyleUsing.UseBorderColor = false;
            this.Text13.ParentStyleUsing.UseBorders = false;
            this.Text13.ParentStyleUsing.UseBorderWidth = false;
            this.Text13.ParentStyleUsing.UseFont = false;
            this.Text13.ParentStyleUsing.UseForeColor = false;
            this.Text13.Size = new System.Drawing.Size(86, 16);
            this.Text13.Text = "On Hand Qty";
            this.Text13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTxDateFrom
            // 
            this.txtTxDateFrom.BackColor = System.Drawing.Color.White;
            this.txtTxDateFrom.BorderColor = System.Drawing.Color.Black;
            this.txtTxDateFrom.CanGrow = false;
            this.txtTxDateFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDateFrom.ForeColor = System.Drawing.Color.Black;
            this.txtTxDateFrom.Location = new System.Drawing.Point(483, 50);
            this.txtTxDateFrom.Name = "txtTxDateFrom";
            this.txtTxDateFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDateFrom.ParentStyleUsing.UseBackColor = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorders = false;
            this.txtTxDateFrom.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDateFrom.ParentStyleUsing.UseFont = false;
            this.txtTxDateFrom.ParentStyleUsing.UseForeColor = false;
            this.txtTxDateFrom.Size = new System.Drawing.Size(250, 14);
            this.txtTxDateFrom.Text = "txtTxDateFrom";
            // 
            // txtTxDateTo
            // 
            this.txtTxDateTo.BackColor = System.Drawing.Color.White;
            this.txtTxDateTo.BorderColor = System.Drawing.Color.Black;
            this.txtTxDateTo.CanGrow = false;
            this.txtTxDateTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxDateTo.ForeColor = System.Drawing.Color.Black;
            this.txtTxDateTo.Location = new System.Drawing.Point(483, 66);
            this.txtTxDateTo.Name = "txtTxDateTo";
            this.txtTxDateTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxDateTo.ParentStyleUsing.UseBackColor = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorderColor = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorders = false;
            this.txtTxDateTo.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxDateTo.ParentStyleUsing.UseFont = false;
            this.txtTxDateTo.ParentStyleUsing.UseForeColor = false;
            this.txtTxDateTo.Size = new System.Drawing.Size(250, 14);
            this.txtTxDateTo.Text = "txtTxDateTo";
            // 
            // lblTxDateTo
            // 
            this.lblTxDateTo.BackColor = System.Drawing.Color.White;
            this.lblTxDateTo.BorderColor = System.Drawing.Color.Black;
            this.lblTxDateTo.CanGrow = false;
            this.lblTxDateTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxDateTo.ForeColor = System.Drawing.Color.Black;
            this.lblTxDateTo.Location = new System.Drawing.Point(391, 66);
            this.lblTxDateTo.Name = "lblTxDateTo";
            this.lblTxDateTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDateTo.ParentStyleUsing.UseBackColor = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorders = false;
            this.lblTxDateTo.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDateTo.ParentStyleUsing.UseFont = false;
            this.lblTxDateTo.ParentStyleUsing.UseForeColor = false;
            this.lblTxDateTo.Size = new System.Drawing.Size(91, 14);
            this.lblTxDateTo.Text = "To Date :";
            // 
            // lblTxDateFrom
            // 
            this.lblTxDateFrom.BackColor = System.Drawing.Color.White;
            this.lblTxDateFrom.BorderColor = System.Drawing.Color.Black;
            this.lblTxDateFrom.CanGrow = false;
            this.lblTxDateFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxDateFrom.ForeColor = System.Drawing.Color.Black;
            this.lblTxDateFrom.Location = new System.Drawing.Point(391, 50);
            this.lblTxDateFrom.Name = "lblTxDateFrom";
            this.lblTxDateFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxDateFrom.ParentStyleUsing.UseBackColor = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorderColor = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorders = false;
            this.lblTxDateFrom.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxDateFrom.ParentStyleUsing.UseFont = false;
            this.lblTxDateFrom.ParentStyleUsing.UseForeColor = false;
            this.lblTxDateFrom.Size = new System.Drawing.Size(91, 14);
            this.lblTxDateFrom.Text = "From Date : ";
            // 
            // phStkCode
            // 
            this.phStkCode.BackColor = System.Drawing.Color.White;
            this.phStkCode.BorderColor = System.Drawing.Color.Black;
            this.phStkCode.CanGrow = false;
            this.phStkCode.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phStkCode.ForeColor = System.Drawing.Color.Black;
            this.phStkCode.Location = new System.Drawing.Point(8, 116);
            this.phStkCode.Name = "phStkCode";
            this.phStkCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phStkCode.ParentStyleUsing.UseBackColor = false;
            this.phStkCode.ParentStyleUsing.UseBorderColor = false;
            this.phStkCode.ParentStyleUsing.UseBorders = false;
            this.phStkCode.ParentStyleUsing.UseBorderWidth = false;
            this.phStkCode.ParentStyleUsing.UseFont = false;
            this.phStkCode.ParentStyleUsing.UseForeColor = false;
            this.phStkCode.Size = new System.Drawing.Size(75, 14);
            this.phStkCode.Text = "phStkCode";
            // 
            // phAppendix3
            // 
            this.phAppendix3.BackColor = System.Drawing.Color.White;
            this.phAppendix3.BorderColor = System.Drawing.Color.Black;
            this.phAppendix3.CanGrow = false;
            this.phAppendix3.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phAppendix3.ForeColor = System.Drawing.Color.Black;
            this.phAppendix3.Location = new System.Drawing.Point(291, 116);
            this.phAppendix3.Name = "phAppendix3";
            this.phAppendix3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix3.ParentStyleUsing.UseBackColor = false;
            this.phAppendix3.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix3.ParentStyleUsing.UseBorders = false;
            this.phAppendix3.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix3.ParentStyleUsing.UseFont = false;
            this.phAppendix3.ParentStyleUsing.UseForeColor = false;
            this.phAppendix3.Size = new System.Drawing.Size(83, 14);
            this.phAppendix3.Text = "phAppendix3";
            // 
            // phAppendix2
            // 
            this.phAppendix2.BackColor = System.Drawing.Color.White;
            this.phAppendix2.BorderColor = System.Drawing.Color.Black;
            this.phAppendix2.CanGrow = false;
            this.phAppendix2.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phAppendix2.ForeColor = System.Drawing.Color.Black;
            this.phAppendix2.Location = new System.Drawing.Point(191, 116);
            this.phAppendix2.Name = "phAppendix2";
            this.phAppendix2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix2.ParentStyleUsing.UseBackColor = false;
            this.phAppendix2.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix2.ParentStyleUsing.UseBorders = false;
            this.phAppendix2.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix2.ParentStyleUsing.UseFont = false;
            this.phAppendix2.ParentStyleUsing.UseForeColor = false;
            this.phAppendix2.Size = new System.Drawing.Size(83, 14);
            this.phAppendix2.Text = "phAppendix1";
            // 
            // phAppendix1
            // 
            this.phAppendix1.BackColor = System.Drawing.Color.White;
            this.phAppendix1.BorderColor = System.Drawing.Color.Black;
            this.phAppendix1.CanGrow = false;
            this.phAppendix1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.phAppendix1.ForeColor = System.Drawing.Color.Black;
            this.phAppendix1.Location = new System.Drawing.Point(100, 116);
            this.phAppendix1.Name = "phAppendix1";
            this.phAppendix1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.phAppendix1.ParentStyleUsing.UseBackColor = false;
            this.phAppendix1.ParentStyleUsing.UseBorderColor = false;
            this.phAppendix1.ParentStyleUsing.UseBorders = false;
            this.phAppendix1.ParentStyleUsing.UseBorderWidth = false;
            this.phAppendix1.ParentStyleUsing.UseFont = false;
            this.phAppendix1.ParentStyleUsing.UseForeColor = false;
            this.phAppendix1.Size = new System.Drawing.Size(75, 14);
            this.phAppendix1.Text = "phAppendix1";
            // 
            // lblQtyReceived
            // 
            this.lblQtyReceived.BackColor = System.Drawing.Color.White;
            this.lblQtyReceived.BorderColor = System.Drawing.Color.Black;
            this.lblQtyReceived.CanGrow = false;
            this.lblQtyReceived.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblQtyReceived.ForeColor = System.Drawing.Color.Black;
            this.lblQtyReceived.Location = new System.Drawing.Point(766, 116);
            this.lblQtyReceived.Name = "lblQtyReceived";
            this.lblQtyReceived.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblQtyReceived.ParentStyleUsing.UseBackColor = false;
            this.lblQtyReceived.ParentStyleUsing.UseBorderColor = false;
            this.lblQtyReceived.ParentStyleUsing.UseBorders = false;
            this.lblQtyReceived.ParentStyleUsing.UseBorderWidth = false;
            this.lblQtyReceived.ParentStyleUsing.UseFont = false;
            this.lblQtyReceived.ParentStyleUsing.UseForeColor = false;
            this.lblQtyReceived.Size = new System.Drawing.Size(91, 14);
            this.lblQtyReceived.Text = "Actual Qty";
            this.lblQtyReceived.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblQtyRequested
            // 
            this.lblQtyRequested.BackColor = System.Drawing.Color.White;
            this.lblQtyRequested.BorderColor = System.Drawing.Color.Black;
            this.lblQtyRequested.CanGrow = false;
            this.lblQtyRequested.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblQtyRequested.ForeColor = System.Drawing.Color.Black;
            this.lblQtyRequested.Location = new System.Drawing.Point(650, 116);
            this.lblQtyRequested.Name = "lblQtyRequested";
            this.lblQtyRequested.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblQtyRequested.ParentStyleUsing.UseBackColor = false;
            this.lblQtyRequested.ParentStyleUsing.UseBorderColor = false;
            this.lblQtyRequested.ParentStyleUsing.UseBorders = false;
            this.lblQtyRequested.ParentStyleUsing.UseBorderWidth = false;
            this.lblQtyRequested.ParentStyleUsing.UseFont = false;
            this.lblQtyRequested.ParentStyleUsing.UseForeColor = false;
            this.lblQtyRequested.Size = new System.Drawing.Size(91, 14);
            this.lblQtyRequested.Text = "Replenish Qty";
            this.lblQtyRequested.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.BorderColor = System.Drawing.Color.Black;
            this.lblDescription.CanGrow = false;
            this.lblDescription.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(391, 116);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDescription.ParentStyleUsing.UseBackColor = false;
            this.lblDescription.ParentStyleUsing.UseBorderColor = false;
            this.lblDescription.ParentStyleUsing.UseBorders = false;
            this.lblDescription.ParentStyleUsing.UseBorderWidth = false;
            this.lblDescription.ParentStyleUsing.UseFont = false;
            this.lblDescription.ParentStyleUsing.UseForeColor = false;
            this.lblDescription.Size = new System.Drawing.Size(258, 14);
            this.lblDescription.Text = "Description";
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.White;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.CanGrow = false;
            this.Text7.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.Location = new System.Drawing.Point(8, 17);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.ParentStyleUsing.UseBackColor = false;
            this.Text7.ParentStyleUsing.UseBorderColor = false;
            this.Text7.ParentStyleUsing.UseBorders = false;
            this.Text7.ParentStyleUsing.UseBorderWidth = false;
            this.Text7.ParentStyleUsing.UseFont = false;
            this.Text7.ParentStyleUsing.UseForeColor = false;
            this.Text7.Size = new System.Drawing.Size(850, 19);
            this.Text7.Text = "RPL5100A - Replenishment History";
            // 
            // txtTxNumberFrom
            // 
            this.txtTxNumberFrom.BackColor = System.Drawing.Color.White;
            this.txtTxNumberFrom.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumberFrom.CanGrow = false;
            this.txtTxNumberFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumberFrom.Location = new System.Drawing.Point(100, 50);
            this.txtTxNumberFrom.Name = "txtTxNumberFrom";
            this.txtTxNumberFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumberFrom.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorders = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseFont = false;
            this.txtTxNumberFrom.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumberFrom.Size = new System.Drawing.Size(266, 14);
            this.txtTxNumberFrom.Text = "txtTxNumberFrom";
            // 
            // lblTxNumberFrom
            // 
            this.lblTxNumberFrom.BackColor = System.Drawing.Color.White;
            this.lblTxNumberFrom.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumberFrom.CanGrow = false;
            this.lblTxNumberFrom.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumberFrom.Location = new System.Drawing.Point(8, 50);
            this.lblTxNumberFrom.Name = "lblTxNumberFrom";
            this.lblTxNumberFrom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumberFrom.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorders = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseFont = false;
            this.lblTxNumberFrom.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumberFrom.Size = new System.Drawing.Size(91, 14);
            this.lblTxNumberFrom.Text = "From Trn# : ";
            // 
            // txtTxNumberTo
            // 
            this.txtTxNumberTo.BackColor = System.Drawing.Color.White;
            this.txtTxNumberTo.BorderColor = System.Drawing.Color.Black;
            this.txtTxNumberTo.CanGrow = false;
            this.txtTxNumberTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.txtTxNumberTo.ForeColor = System.Drawing.Color.Black;
            this.txtTxNumberTo.Location = new System.Drawing.Point(100, 66);
            this.txtTxNumberTo.Name = "txtTxNumberTo";
            this.txtTxNumberTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTxNumberTo.ParentStyleUsing.UseBackColor = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorderColor = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorders = false;
            this.txtTxNumberTo.ParentStyleUsing.UseBorderWidth = false;
            this.txtTxNumberTo.ParentStyleUsing.UseFont = false;
            this.txtTxNumberTo.ParentStyleUsing.UseForeColor = false;
            this.txtTxNumberTo.Size = new System.Drawing.Size(266, 14);
            this.txtTxNumberTo.Text = "txtTxNumberTo";
            // 
            // lblTxNumberTo
            // 
            this.lblTxNumberTo.BackColor = System.Drawing.Color.White;
            this.lblTxNumberTo.BorderColor = System.Drawing.Color.Black;
            this.lblTxNumberTo.CanGrow = false;
            this.lblTxNumberTo.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.lblTxNumberTo.ForeColor = System.Drawing.Color.Black;
            this.lblTxNumberTo.Location = new System.Drawing.Point(8, 66);
            this.lblTxNumberTo.Name = "lblTxNumberTo";
            this.lblTxNumberTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTxNumberTo.ParentStyleUsing.UseBackColor = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorderColor = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorders = false;
            this.lblTxNumberTo.ParentStyleUsing.UseBorderWidth = false;
            this.lblTxNumberTo.ParentStyleUsing.UseFont = false;
            this.lblTxNumberTo.ParentStyleUsing.UseForeColor = false;
            this.lblTxNumberTo.Size = new System.Drawing.Size(91, 14);
            this.lblTxNumberTo.Text = "To Trn# :";
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.White;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.Location = new System.Drawing.Point(8, 83);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.ParentStyleUsing.UseBackColor = false;
            this.Text4.ParentStyleUsing.UseBorderColor = false;
            this.Text4.ParentStyleUsing.UseBorders = false;
            this.Text4.ParentStyleUsing.UseBorderWidth = false;
            this.Text4.ParentStyleUsing.UseFont = false;
            this.Text4.ParentStyleUsing.UseForeColor = false;
            this.Text4.Size = new System.Drawing.Size(91, 14);
            this.Text4.Text = "Type :";
            // 
            // hdrType1
            // 
            this.hdrType1.BackColor = System.Drawing.Color.White;
            this.hdrType1.BorderColor = System.Drawing.Color.Black;
            this.hdrType1.CanGrow = false;
            this.hdrType1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.hdrType1.ForeColor = System.Drawing.Color.Black;
            this.hdrType1.Location = new System.Drawing.Point(100, 83);
            this.hdrType1.Name = "hdrType1";
            this.hdrType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdrType1.ParentStyleUsing.UseBackColor = false;
            this.hdrType1.ParentStyleUsing.UseBorderColor = false;
            this.hdrType1.ParentStyleUsing.UseBorders = false;
            this.hdrType1.ParentStyleUsing.UseBorderWidth = false;
            this.hdrType1.ParentStyleUsing.UseFont = false;
            this.hdrType1.ParentStyleUsing.UseForeColor = false;
            this.hdrType1.Size = new System.Drawing.Size(266, 14);
            this.hdrType1.Text = "Untranslated";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            // 
            // HistoryRpt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 25, 25);
            this.PageHeight = 826;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.HistoryRpt_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtOperatorName;
        private DevExpress.XtraReports.UI.XRLabel txtFmLocationName;
        private DevExpress.XtraReports.UI.XRLabel txtToLocationName;
        private DevExpress.XtraReports.UI.XRLabel txtToLocationCode;
        private DevExpress.XtraReports.UI.XRLabel txtFmLocationCode;
        private DevExpress.XtraReports.UI.XRLabel lblTxDate;
        private DevExpress.XtraReports.UI.XRLabel txtTxDate;
        private DevExpress.XtraReports.UI.XRLabel lblRemarks;
        private DevExpress.XtraReports.UI.XRLabel lblOperator;
        private DevExpress.XtraReports.UI.XRLabel lblTransferredOn;
        private DevExpress.XtraReports.UI.XRLabel lblCompletedOn;
        private DevExpress.XtraReports.UI.XRLabel lblStatus;
        private DevExpress.XtraReports.UI.XRLabel lblModifiedOn;
        private DevExpress.XtraReports.UI.XRLabel lblToLocation;
        private DevExpress.XtraReports.UI.XRLabel lblFmLocation;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumber;
        private DevExpress.XtraReports.UI.XRLabel txtModifiedOn;
        private DevExpress.XtraReports.UI.XRLabel txtModifiedBy;
        private DevExpress.XtraReports.UI.XRLabel txtStatus;
        private DevExpress.XtraReports.UI.XRLabel txtRemarks;
        private DevExpress.XtraReports.UI.XRLabel txtCompletedOn;
        private DevExpress.XtraReports.UI.XRLabel txtTransferredOn;
        private DevExpress.XtraReports.UI.XRLabel txtOperatorCode;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumber;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel hdrCompName1;
        private DevExpress.XtraReports.UI.XRLabel phWarehouse;
        private DevExpress.XtraReports.UI.XRLabel Text13;
        private DevExpress.XtraReports.UI.XRLabel txtTxDateFrom;
        private DevExpress.XtraReports.UI.XRLabel txtTxDateTo;
        private DevExpress.XtraReports.UI.XRLabel lblTxDateTo;
        private DevExpress.XtraReports.UI.XRLabel lblTxDateFrom;
        private DevExpress.XtraReports.UI.XRLabel phStkCode;
        private DevExpress.XtraReports.UI.XRLabel phAppendix3;
        private DevExpress.XtraReports.UI.XRLabel phAppendix2;
        private DevExpress.XtraReports.UI.XRLabel phAppendix1;
        private DevExpress.XtraReports.UI.XRLabel lblQtyReceived;
        private DevExpress.XtraReports.UI.XRLabel lblQtyRequested;
        private DevExpress.XtraReports.UI.XRLabel lblDescription;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumberFrom;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumberFrom;
        private DevExpress.XtraReports.UI.XRLabel txtTxNumberTo;
        private DevExpress.XtraReports.UI.XRLabel lblTxNumberTo;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel hdrType1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPanel pnlPageInfo;
        private DevExpress.XtraReports.UI.XRPageInfo phPageNumber;
        private DevExpress.XtraReports.UI.XRPageInfo phDateTime;
        private DevExpress.XtraReports.UI.XRLabel lblPage;
        private DevExpress.XtraReports.UI.XRLabel lblPrintedOn;
        private DevExpress.XtraReports.UI.XRSubreport rptDetails;
        private DevExpress.XtraReports.UI.XRLabel txtHeaderId;

    }
}
