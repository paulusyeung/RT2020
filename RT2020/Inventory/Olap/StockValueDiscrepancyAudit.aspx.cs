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
using RT2020.Helper;

namespace RT2020.Inventory.Olap
{
    public partial class StockValueDiscrepancyAudit : System.Web.UI.Page
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
            if (System.Web.HttpContext.Current.Session["DiscrepancyAudit"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["DiscrepancyAudit"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtStkCodeFrom.Text = parameterTable["FromStockCode"].ToString();
                    this.txtStkCodeTo.Text = parameterTable["ToStockCode"].ToString();
                    this.txtFromDate.Text = parameterTable["FromDate"].ToString();
                    this.txtToDate.Text = parameterTable["ToDate"].ToString();
                    this.txtForMonth.Text = parameterTable["Month"].ToString();
                    this.chkDIFFNoZERO.Checked = Convert.ToBoolean(parameterTable["ShowDiff"].ToString());

                    //this.txtForMonth.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear +
                    //    int.Parse(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth).ToString("00");

                    //this.txtFromDate.Text = FromDate.ToString("dd/MM/yyyy");
                    //this.txtToDate.Text = ToDate.ToString("dd/MM/yyyy");

                    this.olapSQLSource.SelectParameters["fromDate"] = new Parameter("fromDate", TypeCode.DateTime, FromDate.ToString("yyyy-MM-dd"));
                    this.olapSQLSource.SelectParameters["toDate"] = new Parameter("toDate", TypeCode.DateTime, ToDate.ToString("yyyy-MM-dd"));

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    this.BindData();
                }
            }
        }

        /// <summary>
        /// Validation Selections
        /// </summary>
        /// <returns></returns>
        private bool IsSelValid()
        {
            bool result = true;
            if (string.Compare(this.txtFromDate.Text.Trim(), this.txtToDate.Text.Trim()) > 0)
            {
                result = false;
            }
            return result;
        }

        #region APSxPivotGrid
        /// <summary>
        /// Set the name of Fields
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string SetFieldsName(string key)
        {
            return RT2020.SystemInfo.Settings.GetSystemLabelByKey(key);
        }

        /// <summary>
        /// Bind the Datas
        /// </summary>
        private void BindData()
        {
            BuildField();

            this.divOptions.Visible = false;
            this.divPivotGrid.Visible = true;

        }

        /// <summary>
        /// Build the Fields
        /// </summary>
        private void BuildField()
        {
            this.olapStockValueDiscrepancyAu.Fields.Clear();

            #region Row Area
            //Class1-Class2
            for (int i = 1; i <= 2; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.RowArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());
                classField.AreaIndex = i - 1;

                if (!this.olapStockValueDiscrepancyAu.Fields.Contains(classField))
                {
                    olapStockValueDiscrepancyAu.Fields.Add(classField);
                }
            }
            #endregion

            #region Data Area
            //B/F $
            PivotGridField bfField = new PivotGridField("BFAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            bfField.Caption = "B/F($)";
            bfField.AreaIndex = 0;
            bfField.CellFormat.FormatString = "{0:n2}";
            bfField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(bfField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(bfField);
            }

            //COGS($)-RETAIL
            PivotGridField cogsrField = new PivotGridField("COGS_R_AMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cogsrField.Caption = "COGS($)-RETAIL";
            cogsrField.AreaIndex = 1;
            cogsrField.CellFormat.FormatString = "{0:n2}";
            cogsrField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(cogsrField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(cogsrField);
            }

            //COGS($)-WHOLESALE
            PivotGridField cogswField = new PivotGridField("COGS_W_AMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cogswField.Caption = "COGS($)-WHOLESALE";
            cogswField.AreaIndex = 2;
            cogswField.CellFormat.FormatString = "{0:n2}";
            cogswField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(cogswField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(cogswField);
            }

            //PUR($)
            PivotGridField puramtField = new PivotGridField("PUR_AMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            puramtField.Caption = "PUR($)";
            puramtField.AreaIndex = 3;
            puramtField.CellFormat.FormatString = "{0:n2}";
            puramtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(puramtField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(puramtField);
            }

            //ADJ($)
            PivotGridField adjamtField = new PivotGridField("ADJ_AMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            adjamtField.Caption = "ADJ($)";
            adjamtField.AreaIndex = 4;
            adjamtField.CellFormat.FormatString = "{0:n2}";
            adjamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(adjamtField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(adjamtField);
            }


            //C/D($)
            PivotGridField cdamtField = new PivotGridField("CDAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cdamtField.Caption = "C/D($)";
            cdamtField.AreaIndex = 5;
            cdamtField.CellFormat.FormatString = "{0:n2}";
            cdamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(cdamtField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(cdamtField);
            }

            //AUDIT C/D($)
            PivotGridField auditcdField = new PivotGridField("CALC_CDAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            auditcdField.Caption = "AUDIT C/D($)";
            auditcdField.AreaIndex = 6;
            auditcdField.CellFormat.FormatString = "{0:n2}";
            auditcdField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(auditcdField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(auditcdField);
            }

            //DIFF($)
            PivotGridField diffField = new PivotGridField("DIFF_AMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            diffField.Caption = "DIFF($)";
            diffField.AreaIndex = 7;
            diffField.CellFormat.FormatString = "{0:n2}";
            diffField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockValueDiscrepancyAu.Fields.Contains(diffField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(diffField);
            }

            #endregion

            #region Filter Area
            //STKCODE
            PivotGridField stkField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            stkField.Caption = SetFieldsName("STKCODE");

            if (!olapStockValueDiscrepancyAu.Fields.Contains(stkField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(stkField);
            }

            //APPENDIX 1-3
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appendixField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                appendixField.Caption = SetFieldsName("APPENDIX" + i.ToString());

                if (!olapStockValueDiscrepancyAu.Fields.Contains(appendixField))
                {
                    olapStockValueDiscrepancyAu.Fields.Add(appendixField);
                }
            }

            //STK DESC
            PivotGridField descField = new PivotGridField("DESCROPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "STK DESC";

            if (!olapStockValueDiscrepancyAu.Fields.Contains(descField))
            {
                olapStockValueDiscrepancyAu.Fields.Add(descField);
            }

            //CLASS 3-6
            for (int i = 3; i <= 6; i++)
            {
                PivotGridField clField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                clField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!olapStockValueDiscrepancyAu.Fields.Contains(clField))
                {
                    olapStockValueDiscrepancyAu.Fields.Add(clField);
                }
            }
            
            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                this.StockValueDiscrepancyAuExport.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                this.StockValueDiscrepancyAuExport.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockValueDiscrepancyAuExport.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockValueDiscrepancyAuExport.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockValueDiscrepancyAuExport.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = string.Empty;
                string fileName = string.Empty;

                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.StockValueDiscrepancyAuExport.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.StockValueDiscrepancyAuExport.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.StockValueDiscrepancyAuExport.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.StockValueDiscrepancyAuExport.ExportToText(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposiition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposiition + ";filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();
            }
        }

        #endregion

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
            if (IsSelValid())
            {
                BindData();
            }
        }

        protected void olapSQLSource_OnSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = ConfigHelper.CommandTimeout;
        }

        #region Properties
        /// <summary>
        /// Get From Date
        /// </summary>
        private DateTime FromDate
        {
            get
            {
                return new DateTime(Year, Month, 1);
            }
        }

        /// <summary>
        /// Get To Date
        /// </summary>
        private DateTime ToDate
        {
            get
            {
                return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            }
        }

        private int Year
        {
            get
            {
                return int.Parse(this.txtForMonth.Text.Trim().Substring(0, 4));
            }
        }

        private int Month
        {
            get
            {
                return int.Parse(this.txtForMonth.Text.Trim().Substring(4, 2));
            }
        }
        #endregion

        protected void txtForMonth_TextChanged(object sender, EventArgs e)
        {
            this.txtFromDate.Text = FromDate.ToString("dd/MM/yyyy");
            this.txtToDate.Text = ToDate.ToString("dd/MM/yyyy");
        }
    }
}
