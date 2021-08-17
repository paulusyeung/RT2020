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
using RT2020.Helper;
using RT2020.ModelEx;

namespace RT2020.Inventory.Olap
{
    public partial class StockReorder : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref=" System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitalPageValue();
            }
        }

        /// <summary>
        /// Initals the page value
        /// </summary>
        private void InitalPageValue()
        {
            if (System.Web.HttpContext.Current.Session["StockReorder"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["StockReorder"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtSTKCODE_From.Text = parameterTable["FromStockCode"].ToString();
                    this.txtSTKCODE_To.Text = parameterTable["ToStockCode"].ToString();
                    this.txtDateFrom.Text = parameterTable["FromDate"].ToString();
                    this.txtDateTo.Text = parameterTable["ToDate"].ToString();
                    this.chkShowPO.Checked = Convert.ToBoolean(parameterTable["ShowPOQty"].ToString());
                    this.chkShowBF.Checked = Convert.ToBoolean(parameterTable["ShowBFQty"].ToString());
                    this.chkShowCD.Checked = Convert.ToBoolean(parameterTable["ShowCDQty"].ToString());
                    this.chkShowATS.Checked = Convert.ToBoolean(parameterTable["ShowATSQty"].ToString());

                    //this.txtDateFrom.Text = this.FromDate.ToString("dd/MM/yyyy");
                    //this.txtDateTo.Text = this.ToDate.ToString("dd/MM/yyyy");

                    this.olapSQLSource.SelectParameters["fromDate"] = new Parameter("fromDate", TypeCode.DateTime, this.FromDate.ToString("yyyy-MM-dd"));
                    this.olapSQLSource.SelectParameters["toDate"] = new Parameter("toDate", TypeCode.DateTime, this.ToDate.ToString("yyyy-MM-dd"));

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    this.BindData();
                }
            }
        }

        #region ASPxPivotGrid
        /// <summary>
        /// set the names of field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string SetFieldsName(string key)
        {
            return SystemInfoHelper.Settings.GetSystemLabelByKey(key);
        }

        /// <summary>
        /// binds the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindData()
        {
            BuildField();

            this.divOptions.Visible = false;
            this.divPivotGrid.Visible = true;

        }

        /// <summary>
        /// builds the fields.
        /// </summary>
        private void BuildField()
        {
            olapStockReorder.Fields.Clear();

            #region Row Area
            //STKCODE
            PivotGridField stkcodeField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            stkcodeField.Caption = SetFieldsName("STKCODE");
            stkcodeField.AreaIndex = 0;

            if (!olapStockReorder.Fields.Contains(stkcodeField))
            {
                olapStockReorder.Fields.Add(stkcodeField);
            }

            //APPENDIX1
            PivotGridField appendix1 = new PivotGridField("APPENDIX1", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            appendix1.Caption = SetFieldsName("APPENDIX1");
            appendix1.AreaIndex = 1;

            if (!olapStockReorder.Fields.Contains(appendix1))
            {
                olapStockReorder.Fields.Add(appendix1);
            }

            //APPENDIX2
            PivotGridField appendix2 = new PivotGridField("APPENDIX2", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            appendix2.Caption = SetFieldsName("APPENDIX2");
            appendix2.AreaIndex = 2;

            if (!olapStockReorder.Fields.Contains(appendix2))
            {
                olapStockReorder.Fields.Add(appendix2);
            }

            //APPENDIX3
            PivotGridField appendix3 = new PivotGridField("APPENDIX3", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            appendix3.Caption = SetFieldsName("APPENDIX3");
            appendix3.AreaIndex = 3;

            if (!olapStockReorder.Fields.Contains(appendix3))
            {
                olapStockReorder.Fields.Add(appendix3);
            }
            #endregion

            #region Data Area
            //REORDERQTY & REORDERLEVEL
            PivotGridField reorderqtyField = new PivotGridField("REORDERQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            reorderqtyField.Caption = "REORDERQTY";
            reorderqtyField.AreaIndex = 0;
            reorderqtyField.CellFormat.FormatString = "{0:n0}";
            reorderqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockReorder.Fields.Contains(reorderqtyField))
            {
                olapStockReorder.Fields.Add(reorderqtyField);
            }

            PivotGridField reorderlevelField = new PivotGridField("REORDERLEVEL", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            reorderlevelField.Caption = "REORDERLEVEL";
            reorderlevelField.AreaIndex = 1;
            reorderlevelField.CellFormat.FormatString = "{0:n0}";
            reorderlevelField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapStockReorder.Fields.Contains(reorderlevelField))
            {
                olapStockReorder.Fields.Add(reorderlevelField);
            }

            //B/F Qty & Amt
            if (chkShowBF.Checked)
            {
                PivotGridField bfqtyField = new PivotGridField("BFQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                bfqtyField.Caption = "BFQTY";
                bfqtyField.AreaIndex = 2;
                bfqtyField.CellFormat.FormatString = "{0:n0}";
                bfqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(bfqtyField))
                {
                    olapStockReorder.Fields.Add(bfqtyField);
                }

                PivotGridField bfamtField = new PivotGridField("BFAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                bfamtField.Caption = "BFAMT";
                bfamtField.AreaIndex = 3;
                bfamtField.CellFormat.FormatString = "{0:C}";
                bfamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(bfamtField))
                {
                    olapStockReorder.Fields.Add(bfamtField);
                }
            }

            //C/D Qty & Amt
            if (chkShowCD.Checked)
            {
                PivotGridField cdqtyField = new PivotGridField("CDQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                cdqtyField.Caption = "CDQTY";
                cdqtyField.AreaIndex = 4;
                cdqtyField.CellFormat.FormatString = "{0:n0}";
                cdqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(cdqtyField))
                {
                    olapStockReorder.Fields.Add(cdqtyField);
                }

                PivotGridField cdamtField = new PivotGridField("CDAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                cdamtField.Caption = "CDAMT";
                cdamtField.AreaIndex = 5;
                cdamtField.CellFormat.FormatString = "{0:C}";
                cdamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(cdamtField))
                {
                    olapStockReorder.Fields.Add(cdamtField);
                }
            }

            //PO Qty & Amt
            if (chkShowPO.Checked)
            {
                PivotGridField poqtyField = new PivotGridField("POQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                poqtyField.Caption = "POQTY";
                poqtyField.AreaIndex = 6;
                poqtyField.CellFormat.FormatString = "{0:n0}";
                poqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(poqtyField))
                {
                    olapStockReorder.Fields.Add(poqtyField);
                }

                PivotGridField poamtField = new PivotGridField("POAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                poamtField.Caption = "POAMT";
                poamtField.AreaIndex = 7;
                poamtField.CellFormat.FormatString = "{0:C}";
                poamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(poamtField))
                {
                    olapStockReorder.Fields.Add(poamtField);
                }
            }

            //Ats Qty & Amt
            if (chkShowATS.Checked)
            {
                PivotGridField atsqtyField = new PivotGridField("ATSQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                atsqtyField.Caption = "ATSQTY";
                atsqtyField.AreaIndex = 8;
                atsqtyField.CellFormat.FormatString = "{0:n0}";
                atsqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(atsqtyField))
                {
                    olapStockReorder.Fields.Add(atsqtyField);
                }

                PivotGridField atsamtField = new PivotGridField("ATSAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                atsamtField.Caption = "ATSAMT";
                atsamtField.AreaIndex = 9;
                atsamtField.CellFormat.FormatString = "{0:C}";
                atsamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapStockReorder.Fields.Contains(atsamtField))
                {
                    olapStockReorder.Fields.Add(atsamtField);
                }
            }
            #endregion

            #region Filter Area
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appendixField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                appendixField.Caption = SetFieldsName("APPENDIX" + i.ToString());

                if (!olapStockReorder.Fields.Contains(appendixField))
                {
                    olapStockReorder.Fields.Add(appendixField);
                }
            }

            for (int i = 1; i <= 6; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!olapStockReorder.Fields.Contains(classField))
                {
                    olapStockReorder.Fields.Add(classField);
                }
            }

            PivotGridField descField = new PivotGridField("DESCRIPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "DESCRIPTION";

            if (!olapStockReorder.Fields.Contains(descField))
            {
                olapStockReorder.Fields.Add(descField);
            }
            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream=new MemoryStream())
            {
                this.StockReorderExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                this.StockReorderExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockReorderExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockReorderExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.StockReorderExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.StockReorderExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.StockReorderExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.StockReorderExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.StockReorderExporter.ExportToText(stream);
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

        #endregion

        protected void chkShowPO_CheckChanged(object sender, EventArgs e)
        {
            //this.chkShowATS.Enabled = !chkShowPO.Checked;
            //chkShowATS.Checked = chkShowATS.Checked ? chkShowATS.Checked : chkShowPO.Checked;

        }

        /// <summary>
        /// Handles the Click event of the btnShow control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// Handles the Click event of the btnSaveAs control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Gets from date.
        /// </summary>
        private DateTime FromDate
        {
            get
            {
                return new DateTime(Convert.ToInt32(SystemInfoEx.CurrentInfo.Default.CurrentSystemYear),
                    Convert.ToInt32(SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth), 1);
            }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        private DateTime ToDate
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }
        }
        #endregion
    }
}
