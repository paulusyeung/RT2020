using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxPivotGrid;
using System.IO;
using DevExpress.Utils;
using System.Collections;
using RT2020.Common.Helper;

namespace RT2020.Inventory.Olap
{
    public partial class InvtOpeningClosing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialPageValue();
            }
        }

        /// <summary>
        /// Initial Page Value 
        /// </summary>
        private void InitialPageValue()
        {
            if (System.Web.HttpContext.Current.Session["OCInventory"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["OCInventory"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtStockCode_From.Text = parameterTable["FromStockCode"].ToString();
                    this.txtStockCode_To.Text = parameterTable["ToStockCode"].ToString();
                    this.txtFromDate.Text = parameterTable["FromMonth"].ToString();
                    this.txtToDate.Text = parameterTable["ToMonth"].ToString();

                    //string currentYear = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
                    //string currentMonth = (int.Parse(SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth) - 1).ToString("00");

                    //this.txtFromDate.Text = currentYear + currentMonth;
                    //this.txtToDate.Text = currentYear + currentMonth;

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    this.BindData();
                }
            }
        }

        /// <summary>
        /// Set the name of Fields
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string SetFieldsName(string key)
        {
            return SystemInfoHelper.Settings.GetSystemLabelByKey(key);
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// Bind the data
        /// </summary>
        private void BindData()
        {
            BuildFields();

            this.divOptions.Visible = false;
            this.divPivotGrid.Visible = true;
        }

        /// <summary>
        /// Build the Fields
        /// </summary>
        private void BuildFields()
        {
            this.olapInvtOpeningClosing.Fields.Clear();

            #region Row Area
            //C1
            PivotGridField c1Field = new PivotGridField("C1", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            c1Field.Caption = SetFieldsName("CLASS1");
            c1Field.AreaIndex = 0;

            if (!this.olapInvtOpeningClosing.Fields.Contains(c1Field))
            {
                olapInvtOpeningClosing.Fields.Add(c1Field);
            }

            //C2
            PivotGridField c2Field = new PivotGridField("C2", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            c2Field.Caption = SetFieldsName("CLASS2");
            c2Field.AreaIndex = 1;

            if (!this.olapInvtOpeningClosing.Fields.Contains(c2Field))
            {
                olapInvtOpeningClosing.Fields.Add(c2Field);
            }
            
            //MONTH
            PivotGridField monthField = new PivotGridField("YRMONTH", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            monthField.Caption = "MONTH";
            monthField.AreaIndex = 2;

            if (!olapInvtOpeningClosing.Fields.Contains(monthField))
            {
                olapInvtOpeningClosing.Fields.Add(monthField);
            }
            #endregion

            #region Data Area
            //B/F QTY
            PivotGridField bfqtyField = new PivotGridField("BFQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            bfqtyField.Caption = "B/F QTY";
            bfqtyField.AreaIndex = 0;
            bfqtyField.CellFormat.FormatString = "{0:n0}";
            bfqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapInvtOpeningClosing.Fields.Contains(bfqtyField))
            {
                olapInvtOpeningClosing.Fields.Add(bfqtyField);
            }

            //B/F $
            PivotGridField bfamtField = new PivotGridField("BFAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            bfamtField.Caption = "B/F $";
            bfamtField.AreaIndex = 1;
            bfamtField.CellFormat.FormatString = "{0:C}";
            bfamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!this.olapInvtOpeningClosing.Fields.Contains(bfamtField))
            {
                olapInvtOpeningClosing.Fields.Add(bfamtField);
            }

            //C/D QTY
            PivotGridField cdqtyField = new PivotGridField("CDQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cdqtyField.Caption = "C/D QTY";
            cdqtyField.AreaIndex = 2;
            cdqtyField.CellFormat.FormatString = "{0:n0}";
            cdqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!this.olapInvtOpeningClosing.Fields.Contains(cdqtyField))
            {
                olapInvtOpeningClosing.Fields.Add(cdqtyField);
            }

            //C/D $
            PivotGridField cdamtField = new PivotGridField("CDAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cdamtField.Caption = "C/D $";
            cdamtField.AreaIndex = 3;
            cdamtField.CellFormat.FormatString = "{0:C}";
            cdamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!this.olapInvtOpeningClosing.Fields.Contains(cdamtField))
            {
                olapInvtOpeningClosing.Fields.Add(cdamtField);
            }
            #endregion

            #region Filter Area
            //STK
            PivotGridField stkField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            stkField.Caption = SetFieldsName("STKCODE");

            if (!this.olapInvtOpeningClosing.Fields.Contains(stkField))
            {
                olapInvtOpeningClosing.Fields.Add(stkField);
            }

            //APPENDIX 1-3
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                appField.Caption = SetFieldsName("APPENDIX" + i.ToString());

                if (!this.olapInvtOpeningClosing.Fields.Contains(appField))
                {
                    olapInvtOpeningClosing.Fields.Add(appField);
                }
            }

            //STK DESC
            PivotGridField descField = new PivotGridField("DESCRIPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "STK DESC";

            if (!this.olapInvtOpeningClosing.Fields.Contains(descField))
            {
                olapInvtOpeningClosing.Fields.Add(descField);
            }

            //CLASS3-CLASS6
            for (int i = 3; i <= 6; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!this.olapInvtOpeningClosing.Fields.Contains(classField))
                {
                    olapInvtOpeningClosing.Fields.Add(classField);
                }
            }
            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                olapInvtOpeningClosingExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintColumnHeaders.Checked;
                olapInvtOpeningClosingExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapInvtOpeningClosingExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapInvtOpeningClosingExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapInvtOpeningClosingExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapInvtOpeningClosingExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapInvtOpeningClosingExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapInvtOpeningClosingExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapInvtOpeningClosingExporter.ExportToText(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + ";fileName=" + fileName);
                Response.BinaryWrite(buffer);

                Response.End();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                BindData();
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

        protected void olapSQLSource_OnSelecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = ConfigHelper.CommandTimeout;
        }
    }
}
