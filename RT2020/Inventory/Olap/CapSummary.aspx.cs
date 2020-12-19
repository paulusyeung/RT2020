using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using DevExpress.Web.ASPxPivotGrid;
using System.IO;
using DevExpress.Utils;
using RT2020.Helper;

namespace RT2020.Inventory.Olap
{
    public partial class CapSummary : System.Web.UI.Page
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
            if (System.Web.HttpContext.Current.Session["CapSummary"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["CapSummary"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtFromSupplier.Text = parameterTable["FromSupplierCode"].ToString();
                    this.txtToSupplier.Text = parameterTable["ToSupplierCode"].ToString();
                    this.txtFromLocation.Text = parameterTable["FromWorkplaceCode"].ToString();
                    this.txtToLocation.Text = parameterTable["ToWorkplaceCode"].ToString();
                    this.txtFromTRN.Text = parameterTable["FromTxNumber"].ToString();
                    this.txtToTRN.Text = parameterTable["ToTxNumber"].ToString();
                    this.txtFromDate.Text = parameterTable["FromDate"].ToString();
                    this.txtToDate.Text = parameterTable["ToDate"].ToString();
                    this.chkPost.Checked = Convert.ToBoolean(parameterTable["PostedRecord"].ToString());
                    this.chkUnPost.Checked = Convert.ToBoolean(parameterTable["UnPostRecord"].ToString());
                    this.chkShowRemarks.Checked = Convert.ToBoolean(parameterTable["ShowRemarks"].ToString());

                    //this.txtFromData.Text = new DateTime(int.Parse(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear),
                    //    int.Parse(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth), 1).ToString("dd/MM/yyyy");
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
            return RT2020.SystemInfo.Settings.GetSystemLabelByKey(key);
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
            this.olapCAPSummay.Fields.Clear();

            #region Row Area
            // Posted or not
            PivotGridField postedField = new PivotGridField("POSTEDFLAG", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            postedField.AreaIndex = 0;
            postedField.Caption = "Posted";

            if (!olapCAPSummay.Fields.Contains(postedField))
            {
                olapCAPSummay.Fields.Add(postedField);
            }

            //TRN#
            PivotGridField trnField = new PivotGridField("CAPNO", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            postedField.AreaIndex = 1;
            trnField.Caption = "CAP#";

            if (!olapCAPSummay.Fields.Contains(trnField))
            {
                olapCAPSummay.Fields.Add(trnField);
            }

            //STKCODE
            PivotGridField stkField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            stkField.Caption = SetFieldsName("ITEM#");
            stkField.AreaIndex = 2;

            if (!olapCAPSummay.Fields.Contains(stkField))
            {
                olapCAPSummay.Fields.Add(stkField);
            }
            #endregion

            #region Column Area
            // Year
            PivotGridField yearField = new PivotGridField("YEAR", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            yearField.Caption = "Year";

            if (!olapCAPSummay.Fields.Contains(yearField))
            {
                olapCAPSummay.Fields.Add(yearField);
            }

            // Month
            PivotGridField monthField = new PivotGridField("MONTH", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            monthField.Caption = "Month";

            if (!olapCAPSummay.Fields.Contains(monthField))
            {
                olapCAPSummay.Fields.Add(monthField);
            }

            // Day
            PivotGridField dayField = new PivotGridField("DAY", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            dayField.Caption = "Day";

            if (!olapCAPSummay.Fields.Contains(dayField))
            {
                olapCAPSummay.Fields.Add(dayField);
            }
            #endregion

            #region Data Area
            // QTY
            PivotGridField qtyField = new PivotGridField("RECQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyField.Caption = "Rec Qty";
            qtyField.AreaIndex = 0;
            qtyField.CellFormat.FormatString = "{0:n0}";
            qtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapCAPSummay.Fields.Contains(qtyField))
            {
                olapCAPSummay.Fields.Add(qtyField);
            }

            // Amount
            PivotGridField qtyConfirmedField = new PivotGridField("TAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyConfirmedField.Caption = "Total Amount(HKD)";
            qtyConfirmedField.AreaIndex = 1;
            qtyConfirmedField.CellFormat.FormatString = "{0:n2}";
            qtyConfirmedField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapCAPSummay.Fields.Contains(qtyConfirmedField))
            {
                olapCAPSummay.Fields.Add(qtyConfirmedField);
            }
            #endregion

            #region Filter Area

            // Location
            PivotGridField locationField = new PivotGridField("LOC", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            locationField.Caption = "Loc#";

            if (!olapCAPSummay.Fields.Contains(locationField))
            {
                olapCAPSummay.Fields.Add(locationField);
            }

            // Location Initial
            PivotGridField locInitialField = new PivotGridField("LOCINITIAL", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            locInitialField.Caption = "Loc Initial";

            if (!olapCAPSummay.Fields.Contains(locInitialField))
            {
                olapCAPSummay.Fields.Add(locInitialField);
            }

            // Supplier
            PivotGridField supplierField = new PivotGridField("SUPPNUM", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            supplierField.Caption = "Supp#";

            if (!olapCAPSummay.Fields.Contains(supplierField))
            {
                olapCAPSummay.Fields.Add(supplierField);
            }

            // Supplier Initial
            PivotGridField suppInitialField = new PivotGridField("SUPPINITIAL", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            suppInitialField.Caption = "Supplier Initial";

            if (!olapCAPSummay.Fields.Contains(suppInitialField))
            {
                olapCAPSummay.Fields.Add(suppInitialField);
            }

            // Staff
            PivotGridField staffField = new PivotGridField("OPERATOR", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            staffField.Caption = "Staff#";

            if (!olapCAPSummay.Fields.Contains(staffField))
            {
                olapCAPSummay.Fields.Add(staffField);
            }

            // Staff Initial
            PivotGridField staffInitialField = new PivotGridField("STAFFINITIAL", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            staffInitialField.Caption = "Staff Initial";

            if (!olapCAPSummay.Fields.Contains(staffInitialField))
            {
                olapCAPSummay.Fields.Add(staffInitialField);
            }

            // Supplier Invoice
            PivotGridField suppInvField = new PivotGridField("SUPPINVNUM", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            suppInvField.Caption = "Supplier Inv#";

            if (!olapCAPSummay.Fields.Contains(suppInvField))
            {
                olapCAPSummay.Fields.Add(suppInvField);
            }

            //APPENDIX 1-3
            for (int i = 1; i <= 3; i++)
            {
                string fieldName = "APPENDIX" + i.ToString();
                PivotGridField appendixField = new PivotGridField(fieldName, DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                appendixField.Caption = SetFieldsName(fieldName);

                if (!olapCAPSummay.Fields.Contains(appendixField))
                {
                    olapCAPSummay.Fields.Add(appendixField);
                }
            }

            //STK DESC
            PivotGridField descField = new PivotGridField("ProductName", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "Description";

            if (!olapCAPSummay.Fields.Contains(descField))
            {
                olapCAPSummay.Fields.Add(descField);
            }

            // Alternate Item
            PivotGridField altItemField = new PivotGridField("AlternateItem", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "Alt. Item";

            if (!olapCAPSummay.Fields.Contains(altItemField))
            {
                olapCAPSummay.Fields.Add(altItemField);
            }

            // Class 1-6
            for (int i = 1; i <= 6; i++)
            {
                string fieldName = "CLASS" + i.ToString();
                PivotGridField classField = new PivotGridField(fieldName, DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName(fieldName);

                if (!olapCAPSummay.Fields.Contains(classField))
                {
                    olapCAPSummay.Fields.Add(classField);
                }
            }

            if (chkShowRemarks.Checked)
            {
                // Remarks 1-6
                for (int i = 1; i <= 6; i++)
                {
                    string fieldName = "REMARK" + i.ToString();
                    PivotGridField remarkField = new PivotGridField(fieldName, DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                    remarkField.Caption = SetFieldsName(fieldName);

                    if (!olapCAPSummay.Fields.Contains(remarkField))
                    {
                        olapCAPSummay.Fields.Add(remarkField);
                    }
                }
            }

            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                this.olapCAPSummayExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                this.olapCAPSummayExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapCAPSummayExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapCAPSummayExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapCAPSummayExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string fileName = string.Empty;
                string contentType = string.Empty;

                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapCAPSummayExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapCAPSummayExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapCAPSummayExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapCAPSummayExporter.ExportToText(stream);
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
