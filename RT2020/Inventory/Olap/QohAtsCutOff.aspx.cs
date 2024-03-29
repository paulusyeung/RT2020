﻿using System;
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
using RT2020.Common.Helper;

namespace RT2020.Inventory.Olap
{
    /// <summary>
    /// 
    /// </summary>
    public partial class QohAtsCutOff : System.Web.UI.Page
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
                this.InitalPageValue();
            }
        }

        /// <summary>
        /// Initals the page value.
        /// </summary>
        private void InitalPageValue()
        {
            if (System.Web.HttpContext.Current.Session["Qoh_Ats"] != null)
            {
                object objTable = System.Web.HttpContext.Current.Session["Qoh_Ats"];
                if (objTable is Hashtable)
                {
                    Hashtable parameterTable = objTable as Hashtable;
                    this.txtSTKCODE_From.Text = parameterTable["FromStockCode"].ToString();
                    this.txtSTKCODE_To.Text = parameterTable["ToStockCode"].ToString();
                    this.txtDateFrom.Text = parameterTable["FromDate"].ToString();
                    this.txtDateTo.Text = parameterTable["ToDate"].ToString();
                    this.chkShowPO.Checked = Convert.ToBoolean(parameterTable["ShowPOQty"].ToString());
                    this.chkShowAts.Checked = Convert.ToBoolean(parameterTable["ShowATSQty"].ToString());
                    this.chkShowOLN.Checked = Convert.ToBoolean(parameterTable["ShowOSTQty"].ToString());
                    this.chkShowRtlAmt.Checked = Convert.ToBoolean(parameterTable["ShowRetailAmount"].ToString());
                    //this.chkShowRemarks.Checked = Convert.ToBoolean(parameterTable["ShowRemarks"].ToString());
                    this.chkSkipZeroQty.Checked = Convert.ToBoolean(parameterTable["SkipZeroQty"].ToString());

                    //this.GetProductCode();

                    //this.txtDateFrom.Text = this.FromDate.ToString("dd/MM/yyyy");
                    //this.txtDateTo.Text = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)).ToString("dd/MM/yyyy");

                    //this.olapSQLSource.SelectParameters["fromDate"] = new Parameter("fromDate", TypeCode.DateTime, this.FromDate.ToString("yyyy-MM-dd"));
                    // this.olapSQLSource.SelectParameters["toDate"] = new Parameter("toDate", TypeCode.DateTime, this.ToDate.ToString("yyyy-MM-dd"));

                    this.divOptions.Visible = false;
                    this.divPivotGrid.Visible = true;

                    BindData();
                }
            }
        }

        /// <summary>
        /// Gets the product code.
        /// </summary>
        private void GetProductCode()
        {
            /**
            RT2020.DAL.ProductCollection oProdList = RT2020.DAL.Product.LoadCollection(new string[] { "STKCODE" }, true);
            if (oProdList.Count > 0)
            {
                this.txtSTKCODE_From.Text = oProdList[0].STKCODE;
                this.txtSTKCODE_To.Text = oProdList[oProdList.Count - 1].STKCODE;
            }
            */
        }

        #region APSxPivotGrid
        /// <summary>
        /// Sets the name of the fields.
        /// </summary>
        public string SetFieldsName(string key)
        {
            return SystemInfoHelper.Settings.GetSystemLabelByKey(key);
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            //SqlParameter[] parameterValues = new SqlParameter[] {
            //    new SqlParameter("@fromSTKCODE", this.txtSTKCODE_From.Text.Trim()),
            //    new SqlParameter("@toSTKCODE", this.txtSTKCODE_To.Text.Trim()),
            //    new SqlParameter("@fromDate", this.FromDate),
            //    new SqlParameter("@toDate", this.ToDate),
            //    new SqlParameter("@ShowPOQty", chkShowPO.Checked),
            //    new SqlParameter("@ShowATSQty", chkShowAts.Checked),
            //    new SqlParameter("@ShowOSTOnLoanQty", chkShowOLN.Checked),
            //    new SqlParameter("@ShowRetailAmount", chkShowRtlAmt.Checked),
            //    new SqlParameter("@ShowRemarks1To6", chkShowRemarks.Checked),
            //    new SqlParameter("@SkipZeroQty", chkSkipZeroQty.Checked) };


            //DataSet dataset = SqlHelper.ExecuteDataSet("apOlapQohAtsNormal", parameterValues);

            //this.olapQohAtsNormal.DataSource = dataset.Tables[0];
            //this.olapQohAtsNormal.DataBind();

            this.olapSQLSource.SelectParameters["fromDate"] = new Parameter("fromDate", TypeCode.DateTime, this.FromDate.ToString("yyyy-MM-dd"));
            this.olapSQLSource.SelectParameters["toDate"] = new Parameter("toDate", TypeCode.DateTime, this.ToDate.ToString("yyyy-MM-dd"));

            BuildFields();

            this.divOptions.Visible = false;
            this.divPivotGrid.Visible = true;
        }

        /// <summary>
        /// Builds the fields.
        /// </summary>
        private void BuildFields()
        {
            olapQohAtsNormal.Fields.Clear();

            #region Row Area
            // STKCODE
            PivotGridField stkcodeField = new PivotGridField("STKCODE", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            stkcodeField.Caption = SetFieldsName("STKCODE");
            stkcodeField.AreaIndex = 0;

            if (!olapQohAtsNormal.Fields.Contains(stkcodeField))
            {
                olapQohAtsNormal.Fields.AddField(stkcodeField);
            }

            // Location #
            PivotGridField locnoField = new PivotGridField("LOCNO", DevExpress.XtraPivotGrid.PivotArea.RowArea);
            locnoField.Caption = "LOCNO";
            locnoField.AreaIndex = 1;

            if (!olapQohAtsNormal.Fields.Contains(locnoField))
            {
                olapQohAtsNormal.Fields.AddField(locnoField);
            }
            #endregion

            #region Data Area
            // B/F Qty & Amt
            PivotGridField bfqtyField = new PivotGridField("BFQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            bfqtyField.Caption = "BFQTY";
            bfqtyField.AreaIndex = 0;
            bfqtyField.CellFormat.FormatString = "{0:n0}";
            bfqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapQohAtsNormal.Fields.Contains(bfqtyField))
            {
                olapQohAtsNormal.Fields.AddField(bfqtyField);
            }

            PivotGridField bfamtField = new PivotGridField("BFAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            bfamtField.Caption = "BFAMT";
            bfamtField.AreaIndex = 1;
            bfamtField.CellFormat.FormatString = "{0:C}";
            bfamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapQohAtsNormal.Fields.Contains(bfamtField))
            {
                olapQohAtsNormal.Fields.AddField(bfamtField);
            }

            // C/D Qty & Amt
            PivotGridField cdqtyField = new PivotGridField("CDQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cdqtyField.Caption = "CDQTY";
            cdqtyField.AreaIndex = 3;
            cdqtyField.CellFormat.FormatString = "{0:n0}";
            cdqtyField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapQohAtsNormal.Fields.Contains(cdqtyField))
            {
                olapQohAtsNormal.Fields.AddField(cdqtyField);
            }

            PivotGridField cdamtField = new PivotGridField("CDAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
            cdamtField.Caption = "CDAMT";
            cdamtField.AreaIndex = 4;
            cdamtField.CellFormat.FormatString = "{0:C}";
            cdamtField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            if (!olapQohAtsNormal.Fields.Contains(cdamtField))
            {
                olapQohAtsNormal.Fields.AddField(cdamtField);
            }

            // Retail Amount
            if (chkShowRtlAmt.Checked)
            {
                PivotGridField bfrtlField = new PivotGridField("RTLAMT_BF", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                bfrtlField.Caption = "Retail$(B/F)";
                bfrtlField.AreaIndex = 2;
                bfrtlField.CellFormat.FormatString = "{0:C}";
                bfrtlField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapQohAtsNormal.Fields.Contains(bfrtlField))
                {
                    olapQohAtsNormal.Fields.AddField(bfrtlField);
                }

                PivotGridField cdrtlField = new PivotGridField("RTLAMT_CD", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                cdrtlField.Caption = "Retail$(C/D)";
                cdrtlField.AreaIndex = 5;
                cdrtlField.CellFormat.FormatString = "{0:C}";
                cdrtlField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                if (!olapQohAtsNormal.Fields.Contains(cdrtlField))
                {
                    olapQohAtsNormal.Fields.AddField(cdrtlField);
                }
            }

            if (chkShowPO.Checked)
            {
                PivotGridField poqField = new PivotGridField("POQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                poqField.CellFormat.FormatString = "{0:n0}";
                poqField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                poqField.AreaIndex = 6;

                if (!olapQohAtsNormal.Fields.Contains(poqField))
                {
                    olapQohAtsNormal.Fields.AddField(poqField);
                }


                PivotGridField poaField = new PivotGridField("POAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                poaField.CellFormat.FormatString = "{0:C}";
                poaField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                poaField.AreaIndex = 7;

                if (!olapQohAtsNormal.Fields.Contains(poaField))
                {
                    olapQohAtsNormal.Fields.AddField(poaField);
                }

                // Retail Amount
                if (chkShowRtlAmt.Checked)
                {
                    PivotGridField portlField = new PivotGridField("RTLAMT_PO", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                    portlField.Caption = "Retail$(PO)";
                    portlField.CellFormat.FormatString = "{0:C}";
                    portlField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    portlField.AreaIndex = 8;

                    if (!olapQohAtsNormal.Fields.Contains(portlField))
                    {
                        olapQohAtsNormal.Fields.AddField(portlField);
                    }
                }
            }

            if (chkShowAts.Checked)
            {
                PivotGridField atsqField = new PivotGridField("ATSQTY", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                atsqField.CellFormat.FormatString = "{0:n0}";
                atsqField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                atsqField.AreaIndex = 9;

                if (!olapQohAtsNormal.Fields.Contains(atsqField))
                {
                    olapQohAtsNormal.Fields.AddField(atsqField);
                }


                PivotGridField atsaField = new PivotGridField("ATSAMT", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                atsaField.CellFormat.FormatString = "{0:C}";
                atsaField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                atsaField.AreaIndex = 10;

                if (!olapQohAtsNormal.Fields.Contains(atsaField))
                {
                    olapQohAtsNormal.Fields.AddField(atsaField);
                }

                // Retail Amount
                if (chkShowRtlAmt.Checked)
                {
                    PivotGridField atsrtlField = new PivotGridField("RTLAMT_ATS", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                    atsrtlField.Caption = "Retail$(ATS)";
                    atsrtlField.CellFormat.FormatString = "{0:C}";
                    atsrtlField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    atsrtlField.AreaIndex = 11;

                    if (!olapQohAtsNormal.Fields.Contains(atsrtlField))
                    {
                        olapQohAtsNormal.Fields.AddField(atsrtlField);
                    }
                }
            }

            if (chkShowOLN.Checked)
            {
            }
            #endregion

            #region Filter Area
            for (int i = 1; i <= 3; i++)
            {
                PivotGridField appendixField = new PivotGridField("APPENDIX" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                appendixField.Caption = SetFieldsName("APPENDIX" + i.ToString());

                if (!olapQohAtsNormal.Fields.Contains(appendixField))
                {
                    olapQohAtsNormal.Fields.AddField(appendixField);
                }
            }

            for (int i = 1; i <= 6; i++)
            {
                PivotGridField classField = new PivotGridField("CLASS" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                classField.Caption = SetFieldsName("CLASS" + i.ToString());

                if (!olapQohAtsNormal.Fields.Contains(classField))
                {
                    olapQohAtsNormal.Fields.AddField(classField);
                }
            }

            PivotGridField descField = new PivotGridField("DESCRIPTION", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            descField.Caption = "DESCRIPTION";

            if (!olapQohAtsNormal.Fields.Contains(descField))
            {
                olapQohAtsNormal.Fields.AddField(descField);
            }

            PivotGridField reatailprcField = new PivotGridField("BASPRC", DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            reatailprcField.Caption = "Retail Price";
            olapQohAtsNormal.Fields.AddField(reatailprcField);

            //if (chkShowRemarks.Checked)
            //{
            //    for (int i = 1; i <= 6; i++)
            //    {
            //        PivotGridField remarkField = new PivotGridField("REMARK" + i.ToString(), DevExpress.XtraPivotGrid.PivotArea.FilterArea);
            //        remarkField.Caption = SetFieldsName("REMARK" + i.ToString());

            //        if (!olapQohAtsNormal.Fields.Contains(remarkField))
            //        {
            //            olapQohAtsNormal.Fields.AddField(remarkField);
            //        }
            //    }
            //}
            #endregion
        }

        private void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                this.olapQohAtsNormalExporter.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                this.olapQohAtsNormalExporter.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapQohAtsNormalExporter.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapQohAtsNormalExporter.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                this.olapQohAtsNormalExporter.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.olapQohAtsNormalExporter.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.olapQohAtsNormalExporter.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.olapQohAtsNormalExporter.ExportToRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.olapQohAtsNormalExporter.ExportToText(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();
            }
        }
        #endregion

        /// <summary>
        /// Handles the CheckChanged event of the chkShowPO control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void chkShowPO_CheckChanged(object sender, EventArgs e)
        {
            chkShowAts.Enabled = !chkShowPO.Checked;
            chkShowAts.Checked = chkShowAts.Checked ? chkShowAts.Checked : chkShowPO.Checked;
        }

        /// <summary>
        /// Handles the Click event of the btnShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// Handles the Click event of the btnSaveAs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        /// <summary>
        /// Handles the Click event of the btOpen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btOpen_Click(object sender, EventArgs e)
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
        /// <value>From date.</value>
        private DateTime FromDate
        {
            get
            {
                return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
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
                //return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                return DateTime.ParseExact(this.txtDateTo.Text.Trim(), "yyyy-MM-dd", null);
            }
        }
        #endregion

    }
}
