using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Utils;
using DevExpress.Web.ASPxPivotGrid;
using System.Collections;
using RT2020.Common.Helper;

namespace RT2020.Inventory.Olap
{
    public partial class StockTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialPageValue();
            }
        }

        /// <summary>
        /// Initial Page Values
        /// </summary>
        private void InitialPageValue()
        {
            if (System.Web.HttpContext.Current.Session["StockTransfer"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["StockTransfer"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtFromStk.Text = parameterTable["FromStockCode"].ToString();
                    this.txtToStk.Text = parameterTable["ToStockCode"].ToString();
                    this.txtFromTRN.Text = parameterTable["FromTxNumber"].ToString();
                    this.txtToTRN.Text = parameterTable["ToTxNumber"].ToString();
                    this.txtFromDate.Text = parameterTable["FromDate"].ToString();
                    this.txtToDate.Text = parameterTable["ToDate"].ToString();
                    this.chkcompleted.Checked = Convert.ToBoolean(parameterTable["CompletedStatus"].ToString());
                    this.chkInCompleted.Checked = Convert.ToBoolean(parameterTable["InCompletedStatus"].ToString());
                    this.chkUnprocessed.Checked = Convert.ToBoolean(parameterTable["UnprocessedStatus"].ToString());
                    this.chkPost.Checked = Convert.ToBoolean(parameterTable["PostedRecord"].ToString());
                    this.chkUnPost.Checked = Convert.ToBoolean(parameterTable["UnPostRecord"].ToString());

                    //this.txtFromData.Text = new DateTime(int.Parse(SystemInfoEx.CurrentInfo.Default.CurrentSystemYear),
                    //    int.Parse(SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth), 1).ToString("dd/MM/yyyy");
                    //this.txtToData.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("dd/MM/yyyy");

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    this.BindData();
                }
            }
        }

        /// <summary>
        /// Set the name of the fields
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string SetFieldsName(string key)
        {
            return SystemInfoHelper.Settings.GetSystemLabelByKey(key);
        }

        /// <summary>
        /// Bind the Data
        /// </summary>
        private void BindData()
        {
            this.olapSQLSource.SelectParameters["fromDate"] = new Parameter("fromDate", TypeCode.DateTime, this.FromDate.ToString("yyyy-MM-dd"));
            this.olapSQLSource.SelectParameters["toDate"] = new Parameter("toDate", TypeCode.DateTime, this.ToDate.ToString("yyyy-MM-dd"));

            BuildFields();

            this.divOptions.Visible = false;
            this.divPivotGrid.Visible = true;
        }

        /// <summary>
        /// Build the Fields
        /// </summary>
        private void BuildFields()
        {
            this.olapStockTransfer.Fields.Clear();

            #region Row Area
            //STKCODE
            PivotGridField stkField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            stkField.Caption = SetFieldsName("STKCODE");
            stkField.AreaIndex = 0;

            if (!olapStockTransfer.Fields.Contains(stkField))
            {
                olapStockTransfer.Fields.Add(stkField);
            }

            //APPENDIX 1-3
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appendixField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.RowArea);
                appendixField.AreaIndex = i;

                if (!olapStockTransfer.Fields.Contains(appendixField))
                {
                    olapStockTransfer.Fields.Add(appendixField);
                }
            }
            #endregion

            #region Column Area
            //Confirmation Status
            PivotGridField statusField = new PivotGridField("CONFIRM_TRF", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            statusField.Caption = "CONFIRMATION STATUS";

            if (!olapStockTransfer.Fields.Contains(statusField))
            {
                olapStockTransfer.Fields.Add(statusField);
            }
            #endregion

            #region Data Area
            //QTY[IN LEDGER]
            PivotGridField qtyLedgerField = new PivotGridField("QTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyLedgerField.Caption = "QTY[IN LEDGER]";
            qtyLedgerField.AreaIndex = 0;
            qtyLedgerField.CellFormat.FormatString = "{0:n0}";
            qtyLedgerField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockTransfer.Fields.Contains(qtyLedgerField))
            {
                olapStockTransfer.Fields.Add(qtyLedgerField);
            }

            //QTY[CONFIRMED]
            PivotGridField qtyConfirmedField = new PivotGridField("CONFIRM_TRF_QTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyConfirmedField.Caption = "QTY[CONFIRMED]";
            qtyConfirmedField.AreaIndex = 1;
            qtyConfirmedField.CellFormat.FormatString = "{0:n0}";
            qtyConfirmedField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockTransfer.Fields.Contains(qtyConfirmedField))
            {
                olapStockTransfer.Fields.Add(qtyConfirmedField);
            }
            #endregion

            #region Filter Area
            //STK DESC
            PivotGridField descField = new PivotGridField("DESCRIPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "STK DESC";

            if (!olapStockTransfer.Fields.Contains(descField))
            {
                olapStockTransfer.Fields.Add(descField);
            }

            //TYPE
            PivotGridField typeField = new PivotGridField("TYPE", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            typeField.Caption = "TYPE";

            if (!olapStockTransfer.Fields.Contains(typeField))
            {
                olapStockTransfer.Fields.Add(typeField);
            }

            //TRN#
            PivotGridField trnField = new PivotGridField("TRNNO", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            trnField.Caption = "TRN#";

            if (!olapStockTransfer.Fields.Contains(trnField))
            {
                olapStockTransfer.Fields.Add(trnField);
            }

            //SHOP
            PivotGridField shopField = new PivotGridField("SHOP", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            shopField.Caption = "SHOP";

            if (!olapStockTransfer.Fields.Contains(shopField))
            {
                olapStockTransfer.Fields.Add(shopField);
            }

            //F/T SHOP
            PivotGridField ftshopField = new PivotGridField("FTSHOP", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            ftshopField.Caption = "F/T SHOP";

            if (!olapStockTransfer.Fields.Contains(ftshopField))
            {
                olapStockTransfer.Fields.Add(ftshopField);
            }

            //LATEST CONFIRMATION[DATE]
            PivotGridField lastdateField = new PivotGridField("CONFIRM_TRF_LASTUPDATE", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            lastdateField.Caption = "LATEST CONFIRMATION[DATE]";

            if (!olapStockTransfer.Fields.Contains(lastdateField))
            {
                olapStockTransfer.Fields.Add(lastdateField);
            }

            //LATEST CONFIRMATION[USER]
            PivotGridField lastuserField = new PivotGridField("CONFIRM_TRF_LASTUSER", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            lastdateField.Caption = "LATEST CONFIRMATION[USER]";

            if (!olapStockTransfer.Fields.Contains(lastdateField))
            {
                olapStockTransfer.Fields.Add(lastdateField);
            }

            //YEAR
            PivotGridField yearField = new PivotGridField("YEAR", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            yearField.Caption = "YEAR";

            if (!olapStockTransfer.Fields.Contains(yearField))
            {
                olapStockTransfer.Fields.Add(yearField);
            }

            //MONTH
            PivotGridField monthField = new PivotGridField("MONTH", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            monthField.Caption = "MONTH";

            if (!olapStockTransfer.Fields.Contains(monthField))
            {
                olapStockTransfer.Fields.Add(monthField);
            }

            //WEEK
            PivotGridField weekField = new PivotGridField("WEEK", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            weekField.Caption = "WEEK";

            if (!olapStockTransfer.Fields.Contains(weekField))
            {
                olapStockTransfer.Fields.Add(weekField);
            }

            //DAY
            PivotGridField dayField = new PivotGridField("DAY", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            dayField.Caption = "DAY";

            if (!olapStockTransfer.Fields.Contains(dayField))
            {
                olapStockTransfer.Fields.Add(dayField);
            }
            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                this.olapStockTransferExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                this.olapStockTransferExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapStockTransferExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapStockTransferExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapStockTransferExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string fileName = string.Empty;
                string contentType = string.Empty;

                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapStockTransferExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapStockTransferExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapStockTransferExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapStockTransferExporter.ExportToText(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + ";filename=" + fileName);
                Response.BinaryWrite(buffer);

                Response.End();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSaveAs_Click(object sender, ImageClickEventArgs e)
        {
            Export(true);
        }

        protected void btOpen_Click(object sender, ImageClickEventArgs e)
        {
            Export(false);
        }

        protected void olapSQLSource_OnSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = ConfigHelper.CommandTimeout;
        }

        #region Properties
        private DateTime FromDate
        {
            get
            {
                return DateTime.ParseExact(this.txtFromDate.Text.Trim(), "yyyy-MM-dd", null);
            }
        }

        private DateTime ToDate
        {
            get
            {
                return DateTime.ParseExact(this.txtToDate.Text.Trim(), "yyyy-MM-dd", null);
            }
        }
        #endregion
    }
}
