#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using DevExpress.Web.ASPxPivotGrid;
using System.IO;
using DevExpress.Utils;
using System.Collections;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Inventory.Olap
{
    public partial class StockInOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InitialPageValue();
            }
        }

        /// <summary>
        /// Initial page value.
        /// </summary>
        private void InitialPageValue()
        {
            if (System.Web.HttpContext.Current.Session["StockIOHistory"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["StockIOHistory"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtStockCode_From.Text = parameterTable["FromStockCode"].ToString();
                    this.txtStockCode_To.Text = parameterTable["ToStockCode"].ToString();
                    this.txtFromDate.Text = parameterTable["FromDate"].ToString();
                    this.txtToDate.Text = parameterTable["ToDate"].ToString();
                    this.txtFromShop.Text = parameterTable["FromWorkplace"].ToString();
                    this.txtToShop.Text = parameterTable["ToWorkplace"].ToString();

                    //GetShopCode();

                    //this.txtFromDate.Text = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day).ToString("dd/MM/yyyy");
                    //this.txtToDate.Text = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day).ToString("dd/MM/yyyy");

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    this.BindData();
                }
            }
        }

        /// <summary>
        /// Gets the Shop code
        /// </summary>
        private void GetShopCode()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oShopList = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                if (oShopList.Count > 0)
                {
                    this.txtFromShop.Text = oShopList[0].WorkplaceCode;
                    this.txtToShop.Text = oShopList[oShopList.Count - 1].WorkplaceCode;
                }
            }
        }

        /// <summary>
        /// Sets the name of the fields.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string SetFieldsName(string key)
        {
            return SystemInfoHelper.Settings.GetSystemLabelByKey(key);
        }

        #region Validation Selections
        private bool IsSelDateValid()
        {
            bool result = true;

            DateTime dtFrom;
            DateTime dtTo;

            if (DateTime.TryParseExact(this.txtFromDate.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out  dtFrom)
                && DateTime.TryParseExact(this.txtToDate.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtTo))
            {
                if (string.Compare(dtFrom.ToString("yyyyMMdd"), dtTo.ToString("yyyyMMdd")) > 0)
                {
                    result = false;
                    //Response.Write("<Script Language=JavaScript>alert('DateTime Range Error.')</Script>");
                    lblDateError.Text = "*DateTime Range Error!";
                }
            }
            else
            {
                result = false;
                //Response.Write("<Script Language=JavaScript>alert('DateTime Format Error!')</Script>");
                lblDateError.Text = "*DateTime Format Error!";
            }
            return result;
        }

        private bool IsSelShopValid()
        {
            bool result = true;
            if (string.Compare(this.txtFromShop.Text.Trim(), this.txtToShop.Text.Trim()) > 0)
            {
                result = false;
                //Response.Write("<Script Language=JavaScript>alert('Shop Range Error.')</Script>");
                lblShopError.Text = "*Shop Range Error!";
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Binds the data.
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
        /// Builds the Field.
        /// </summary>
        private void BuildFields()
        {
            this.olapStockInOut.Fields.Clear();

            #region Row Area
            //SHOP
            PivotGridField shopField = new PivotGridField("SHOP", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            shopField.Caption = "SHOP";
            shopField.AreaIndex = 0;

            if (!olapStockInOut.Fields.Contains(shopField))
            {
                olapStockInOut.Fields.Add(shopField);
            }

            //STKCODE
            PivotGridField stkcodeField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            stkcodeField.Caption = SetFieldsName("STKCODE");
            stkcodeField.AreaIndex = 1;

            if (!olapStockInOut.Fields.Contains(stkcodeField))
            {
                olapStockInOut.Fields.Add(stkcodeField);
            }

            //APPENDIX 1-3
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appendixField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.RowArea);
                appendixField.Caption = SetFieldsName("APPENDIX" + i.ToString());
                appendixField.AreaIndex = olapStockInOut.Fields.Count;

                if (!olapStockInOut.Fields.Contains(appendixField))
                {
                    olapStockInOut.Fields.Add(appendixField);
                }
            }
            #endregion

            #region Column Area
            //YEAR
            PivotGridField yearField = new PivotGridField("YEAR", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            yearField.Caption = "YEAR";
            yearField.AreaIndex = 0;

            if (!olapStockInOut.Fields.Contains(yearField))
            {
                olapStockInOut.Fields.Add(yearField);
            }

            //MONTH
            PivotGridField monthField = new PivotGridField("MONTH", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            monthField.Caption = "MONTH";
            monthField.AreaIndex = 1;

            if (!olapStockInOut.Fields.Contains(monthField))
            {
                olapStockInOut.Fields.Add(monthField);
            }

            //WEEK
            PivotGridField weekField = new PivotGridField("WEEK", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            weekField.Caption = "WEEK";
            weekField.AreaIndex = 2;

            if (!olapStockInOut.Fields.Contains(weekField))
            {
                olapStockInOut.Fields.Add(weekField);
            }

            //DAY
            PivotGridField dayField = new PivotGridField("DAY", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            dayField.Caption = "DAY";
            dayField.AreaIndex = 3;

            if (!olapStockInOut.Fields.Contains(dayField))
            {
                olapStockInOut.Fields.Add(dayField);
            }
            #endregion

            #region Data Area
            //QTY
            PivotGridField qtyField = new PivotGridField("QTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyField.Caption = "QTY";
            qtyField.AreaIndex = 0;
            qtyField.CellFormat.FormatString = "{0:n0}";
            qtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockInOut.Fields.Contains(qtyField))
            {
                olapStockInOut.Fields.Add(qtyField);
            }

            //AMOUNT
            PivotGridField amountField = new PivotGridField("AMOUNT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            amountField.Caption = "AMOUNT";
            amountField.AreaIndex = 1;
            amountField.CellFormat.FormatString = "{0:C}";
            amountField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockInOut.Fields.Contains(amountField))
            {
                olapStockInOut.Fields.Add(amountField);
            }

            //COST
            PivotGridField costField = new PivotGridField("COST", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            costField.Caption = "COST";
            costField.AreaIndex = 2;
            costField.CellFormat.FormatString = "{0:C}";
            costField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockInOut.Fields.Contains(costField))
            {
                olapStockInOut.Fields.Add(costField);
            }
            #endregion

            #region Filter Area
            for (int i = 1; i <= 6; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!olapStockInOut.Fields.Contains(classField))
                {
                    olapStockInOut.Fields.AddField(classField);
                }
            }

            PivotGridField descField = new PivotGridField("DESCRIPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "DESCRIPTION";

            if (!olapStockInOut.Fields.Contains(descField))
            {
                olapStockInOut.Fields.AddField(descField);
            }

            PivotGridField typeField = new PivotGridField("TYPE", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            typeField.Caption = "TYPE";

            if (!olapStockInOut.Fields.Contains(typeField))
            {
                olapStockInOut.Fields.Add(typeField);
            }

            PivotGridField trnnoField = new PivotGridField("TRNNO", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            trnnoField.Caption = "TRN#";

            if (!olapStockInOut.Fields.Contains(trnnoField))
            {
                olapStockInOut.Fields.Add(trnnoField);
            }

            PivotGridField ftshopField = new PivotGridField("FTSHOP", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            ftshopField.Caption = "F/T SHOP";

            if (!olapStockInOut.Fields.Contains(ftshopField))
            {
                olapStockInOut.Fields.Add(ftshopField);
            }

            PivotGridField refField = new PivotGridField("REF", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            refField.Caption = "REF";

            if (!olapStockInOut.Fields.Contains(refField))
            {
                olapStockInOut.Fields.Add(refField);
            }

            PivotGridField remarkField = new PivotGridField("REMARKS", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            remarkField.Caption = "REMARK";

            if (!olapStockInOut.Fields.Contains(remarkField))
            {
                olapStockInOut.Fields.Add(remarkField);
            }

            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                olapStockInOutExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                olapStockInOutExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapStockInOutExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapStockInOutExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapStockInOutExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = string.Empty;
                string fileName = string.Empty;
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapStockInOutExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapStockInOutExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapStockInOutExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapStockInOutExporter.ExportToText(stream);
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

        protected void btnSaveAs_Click(object sender, ImageClickEventArgs e)
        {
            Export(true);
        }

        protected void btOpen_Click(object sender, ImageClickEventArgs e)
        {
            Export(false);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (IsSelDateValid() && IsSelShopValid())
            {
                BindData();
            }
        }

        #region Properties
        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>From date.</value>
        private DateTime FromDate
        {
            get
            {
                return DateTime.ParseExact(this.txtFromDate.Text.Trim(), "yyyy-MM-dd", null);
            }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>To date.</value>
        private DateTime ToDate
        {
            get
            {
                return DateTime.ParseExact(this.txtToDate.Text.Trim(), "yyyy-MM-dd", null);
            }
        }
        #endregion

        protected void txtFromShop_TextChanged(object sender, EventArgs e)
        {
            if (IsSelShopValid())
            {
                lblShopError.Text = "";
            }
        }

        protected void txtToShop_TextChanged(object sender, EventArgs e)
        {
            if (IsSelShopValid())
            {
                lblShopError.Text = "";
            }
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (IsSelDateValid())
            {
                lblDateError.Text = "";
            }
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            if (IsSelDateValid())
            {
                lblDateError.Text = "";
            }
        }

        protected void olapSQLSource_OnSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = ConfigHelper.CommandTimeout;
        }
    }
}
