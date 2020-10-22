#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using Microsoft.Reporting.WebForms;

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class StockDiscountStatus : Controls.WizardBase
    {
        public StockDiscountStatus()
        {
            InitializeComponent();
            this.txtSTYLE.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private DataTable Binding(string whereCaluse)
        {
            string tableName = (txtBarcode.Text.Trim().Length > 0) ? " vwStockDiscountStatusWithBarcode" : " vwStockDiscountStatus";

            string sql = @"
SELECT TOP 100 PERCENT *
FROM " + tableName + "";

            sql += string.Format(" WHERE {0}", whereCaluse);

            if (txtFABRICS.Text.Length > 0)
            {
                sql += " AND APPENDIX1='" + txtFABRICS.Text.Trim() + "'";
            }

            if (txtCOLOR.Text.Length > 0)
            {
                sql += " AND APPENDIX2='" + txtCOLOR.Text.Trim() + "'";
            }

            if (txtSIZE.Text.Length > 0)
            {
                sql += " AND APPENDIX3='" + txtSIZE.Text.Trim() + "'";
            }

            sql += " ORDER BY STKCODE,APPENDIX1,APPENDIX2,APPENDIX3";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        #region Bind Data to Report(Search)
        private DataTable BindData()
        {
            string whereCaluse = string.Empty;

            if (this.txtSTYLE.Text.Trim().Length > 0)
            {
                whereCaluse = " STKCODE LIKE '" + txtSTYLE.Text.Trim() + "%'";
            }

            if (txtBarcode.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " AND " : "") + " Barcode = '" + txtBarcode.Text.Trim() + "'";
            }

            return Binding(whereCaluse);
        }
        #endregion

        #region Bind Data to Report(Lookup)
        private DataTable BindBarcodeDataToReport()
        {
            string whereCaluse = string.Empty;

            if (this.txtSTYLE.Text.Trim().Length > 0)
            {
                whereCaluse = " STKCODE LIKE '" + txtSTYLE.Text.Trim() + "%'";
            }

            if (txtBarcode.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " AND " : "")
                    + " STKCODE IN ( SELECT STKCODE FROM vwStockDiscountStatusWithBarcode WHERE Barcode = '" + txtBarcode.Text.Trim() + "')";
            }

            return Binding(whereCaluse);
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSTYLE.Text.Length > 0 || txtBarcode.Text.Length > 0)
            {
                DataTable table = BindData();
                OnClick(table);
            }
            else
            {
                MessageBox.Show("STYLE or Barcode Are Required!", "Message");
            }
            this.txtSTYLE.Focus();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (txtSTYLE.Text.Length > 0 || txtBarcode.Text.Length > 0)
            {
                DataTable table = BindBarcodeDataToReport();
                OnClick(table);
            }
            else
            {
                MessageBox.Show("STYLE or Barcode Are Required!", "Message");
            }
            this.txtSTYLE.Focus();
        }

        private void OnClick(DataTable table)
        {
            List<ReportParameter> rptParam = new List<ReportParameter>();
            rptParam.Add(new ReportParameter("STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE")));
            rptParam.Add(new ReportParameter("APPENDIX1", Common.Utility.GetSystemLabelByKey("APPENDIX1")));
            rptParam.Add(new ReportParameter("APPENDIX2", Common.Utility.GetSystemLabelByKey("APPENDIX2")));
            rptParam.Add(new ReportParameter("APPENDIX3", Common.Utility.GetSystemLabelByKey("APPENDIX3")));
            rptParam.Add(new ReportParameter("CLASS1", Common.Utility.GetSystemLabelByKey("CLASS1")));
            rptParam.Add(new ReportParameter("CLASS2", Common.Utility.GetSystemLabelByKey("CLASS2")));
            rptParam.Add(new ReportParameter("CLASS3", Common.Utility.GetSystemLabelByKey("CLASS3")));
            rptParam.Add(new ReportParameter("CLASS4", Common.Utility.GetSystemLabelByKey("CLASS4")));
            rptParam.Add(new ReportParameter("CLASS5", Common.Utility.GetSystemLabelByKey("CLASS5")));
            rptParam.Add(new ReportParameter("CLASS6", Common.Utility.GetSystemLabelByKey("CLASS6")));

            if (table.Rows.Count > 0)
            {
                this.rptViewer.Datasource = table;

                Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
                subSource.Add("DataSource_vwStockDiscountStatus", table);
                this.rptViewer.SubReportDataSourceList = subSource;

                this.rptViewer.ReportDatasourceName = "DataSource_vwStockDiscountStatus";
                this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.StockDiscountStatusRdl.rdlc";
                this.rptViewer.Parameters = rptParam;

                this.rptViewer.PreviewReport();
            }
            else
            {
                MessageBox.Show("no record found.", "Message");
            }
        }
    }
}