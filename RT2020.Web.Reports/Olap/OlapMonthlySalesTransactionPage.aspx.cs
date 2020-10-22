using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxPivotGrid;
using System.IO;
using DevExpress.Utils;

namespace RT2020.Web.Reports.Olap
{
    public partial class OlapMonthlySalesTransactionPage : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillYears();
                FillMonths();

                this.divPivotGrid.Visible = false;

                // 2013.12.30 paulus: 當 user click 第一次就 disable 粒 button
                btnView.Attributes.Add("onclick", "javascript:" + btnView.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(btnView, ""));
            }
        }

        /// <summary>
        /// Fills the years.
        /// </summary>
        private void FillYears()
        {
            ddlYear.Items.Clear();

            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                ListItem oListItem = new ListItem();
                oListItem.Text = i.ToString();
                oListItem.Selected = false;

                if (i == DateTime.Now.Year)
                {
                    oListItem.Selected = true;
                }

                ddlYear.Items.Add(oListItem);
            }
        }

        /// <summary>
        /// Fills the months.
        /// </summary>
        private void FillMonths()
        {
            ddlMonth.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                ListItem oListItem = new ListItem();
                oListItem.Text = i.ToString().PadLeft(2, '0');
                oListItem.Selected = false;

                if (i == DateTime.Now.Month)
                {
                    oListItem.Selected = true;
                }

                ddlMonth.Items.Add(oListItem);
            }
        }

        /// <summary>
        /// Binds a data source to the invoked server control and all its child controls.
        /// </summary>
        private void BindData()
        {
//            string start = ddlYear.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text.PadLeft(2, '0') + "-01 00:00:00";
//            string end = ddlYear.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text.PadLeft(2, '0') + "-" + DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedItem.Text), Convert.ToInt32(ddlMonth.SelectedItem.Text)) + " 23:59:59";
//            string query = @"
//SELECT TOP 100 PERCENT [STATUS],[TxDate],[TxType],[SHOP],[STKCODE],[APPENDIX1],[APPENDIX2],[APPENDIX3]
//      ,[CLASS1],[CLASS2],[CLASS3],[CLASS4],[CLASS5],[CLASS6],[AMOUNT],[QTY]
//  FROM [dbo].[vwWebReport_OlapSales]";
//            query += " WHERE [TxDate] BETWEEN CAST('" + start + "' AS DATETIME) AND CAST('" + end + "' AS DATETIME)";
        }

        /// <summary>
        /// Sets the name of the fields
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string SetFieldsName(string key)
        {
            return Common.Utility.GetSystemLabelByKey(key);
        }

        /// <summary>
        ///  Builds the Field
        /// </summary>
        private void BuildFields()
        {
            this.olapMonSalesTra.Fields.Clear();

            #region Row Area
            //STATUS
            PivotGridField statusField = new PivotGridField("STATUS", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            statusField.Caption = "POST_STATUS";
            statusField.AreaIndex = 0;

            if (!olapMonSalesTra.Fields.Contains(statusField))
            {
                olapMonSalesTra.Fields.Add(statusField);
            }

            //DAY
            PivotGridField dayField = new PivotGridField("DAY", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            dayField.Caption = "DAY";
            dayField.AreaIndex = 1;

            if (!olapMonSalesTra.Fields.Contains(dayField))
            {
                olapMonSalesTra.Fields.Add(dayField);
            }

            //TxType
            PivotGridField typeField = new PivotGridField("TxType", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            typeField.Caption = "TYPE";
            typeField.AreaIndex = 2;

            if (!olapMonSalesTra.Fields.Contains(typeField))
            {
                olapMonSalesTra.Fields.Add(typeField);
            }
            #endregion

            #region Column Area
            //Shop
            PivotGridField shopField = new PivotGridField("SHOP", DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
            shopField.Caption = "Loc#";
            shopField.AreaIndex = 0;

            if (!olapMonSalesTra.Fields.Contains(shopField))
            {
                olapMonSalesTra.Fields.Add(shopField);
            }
            #endregion

            #region Data Area
            //Amount
            PivotGridField amountField = new PivotGridField("AMOUNT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            amountField.Caption = "Sales Amount";
            amountField.AreaIndex = 0;
            amountField.CellFormat.FormatString = "{0:$#,###0.00}";
            amountField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapMonSalesTra.Fields.Contains(amountField))
            {
                olapMonSalesTra.Fields.Add(amountField);
            }

            //Qty
            PivotGridField qtyField = new PivotGridField("QTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            qtyField.Caption = "";
            qtyField.AreaIndex = 1;
            qtyField.CellFormat.FormatString = "{0:n0}";
            qtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapMonSalesTra.Fields.Contains(qtyField))
            {
                olapMonSalesTra.Fields.Add(qtyField);
            }
            #endregion

            #region Filter Area
            //Class 1 - Class 6
            for (int i = 1; i <= 6; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!olapMonSalesTra.Fields.Contains(classField))
                {
                    olapMonSalesTra.Fields.Add(classField);
                }
            }

            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                olapMonSalesTraExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                olapMonSalesTraExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapMonSalesTraExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapMonSalesTraExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                olapMonSalesTraExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                
                string contentType = string.Empty;
                string fileName = string.Empty;
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapMonSalesTraExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapMonSalesTraExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapMonSalesTraExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapMonSalesTraExporter.ExportToText(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + ";filename=" + fileName);
                Response.BinaryWrite(buffer);

                Response.End();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnView_Click(object sender, EventArgs e)
        {
            this.divPivotGrid.Visible = true;
            this.divTable.Visible = false ;
            //BindData();
            BuildFields();
        }

        protected void btnSaveAs_Click(object sender, ImageClickEventArgs e)
        {
            Export(true);
        }

        protected void btOpen_Click(object sender, ImageClickEventArgs e)
        {
            Export(false);
        }
    }
}
