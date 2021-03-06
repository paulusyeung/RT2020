#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Microsoft.Reporting.WebForms;
#endregion

namespace RT2008.Web.Reports.Forms
{
    public partial class StockInOutHistory_Inline : UserControl
    {
        string year = Common.Utility.CurrentSystemInfo.Default.CurrentSystemYear;
        string month = Common.Utility.CurrentSystemInfo.Default.CurrentSystemMonth;
        private DataTable _DataSource;
        private String DATASOURCE_XSD_NAME = "DataSource_vwStockInOutHistory";
        private String REPORT_RDLC_NAME = "RT2008.Web.Reports.Rdlc.StockInOutHistoryRdl_List.rdlc";
        private String REPORT_FILENAME = "Stock In Out History.PDF";

        public StockInOutHistory_Inline()
        {
            InitializeComponent();
            txtFromSTK.Focus();
        }

        #region Validated
        private bool IsSelValid()
        {

            bool result = true;

            if (String.Compare(this.txtSTK.Text.Trim(), this.txtFromSTK.Text.Trim()) < 0)
            {
                result = false;
                MessageBox.Show("Range Error: STYLE", "Message");
            }
            else if (this.dtDateTo.Value < this.dtDateFrom.Value)
            {
                result = false;
                MessageBox.Show("Range Error: Tx Date", "Message");
            }

            return result;
        }
        #endregion

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = sqlString();

            // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)
            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2008.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Bind Data to Report(Current Monthly)
        private DataTable BindDataCurrent()
        {
            string sql = sqlString();

            sql += " AND TxDate >='" + year + "-" + month + "-01 00:00:00'";

            // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)
            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC"; 

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2008.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private DataTable BindDataHistory()
        {
            string sql = sqlString();

            sql += " AND TxDate <'" + year + "-" + month + "-01 00:00:00'";

            // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)
            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC"; 

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2008.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private string sqlString()
        {
            string sql = @"
SELECT TOP 1000 [STKCODE],[APPENDIX1],[APPENDIX2],[APPENDIX3],[TxDate]
      ,(CASE [TxType]
			WHEN 'CAP' THEN 'Cash Purchase'
			WHEN 'REC' THEN 'PO Purchase'
			WHEN 'REJ' THEN 'Reject To Supplier'
			WHEN 'ADJ' THEN 'Adjustment'
			WHEN 'CAS' THEN 'Cash Sales'
			WHEN 'CRT' THEN 'Cash Return'
			WHEN 'VOD' THEN 'Void'
			WHEN 'SAL' THEN 'Wholesales Sales'
			WHEN 'SRT' THEN 'Wholesales Sales Return'
			WHEN 'TXO' THEN 'Transfer Out'
			WHEN 'TRO' THEN 'Transfer Out'
			WHEN 'TXI' THEN 'Transfer In'
			WHEN 'TRI' THEN 'Transfer In'
			ELSE TxType END) AS [TxType]
      ,[TxNumber],[FromLocation],[ToLocation],[Qty],[Amount],[ProductName],[STATUS] 
FROM [vwStockInOutHistory]
WHERE STKCODE BETWEEN '" + txtFromSTK.Text.Trim() + @"' AND '" + txtSTK.Text.Trim() + @"'
AND TxDate >= '" + dtDateFrom.Value.ToString("yyyy-MM-dd 00:00:00") + @"' AND TxDate <= '" + dtDateTo.Value.ToString("yyyy-MM-dd 23:59:59") + @"'
";
            if (chkUnPosted.Checked)
            {
                sql = sql + " AND (STATUS IS NULL OR STATUS NOT IN ('P'))";
            }
            else
            {
                sql += " AND STATUS = 'P'";
            }

            return sql;
        }
        #endregion

        private void DoSearch()
        {
            if (txtFromSTK.Text.Length > 0 || txtSTK.Text.Length > 0)
            {
                _DataSource = BindData();
                ShowReport();
            }
            else
            {
                MessageBox.Show("STYLE range is required!", "Message");
            }
            this.txtFromSTK.Focus();
        }

        private void ShowReport()
        {
            if (_DataSource.Rows.Count > 0)
            {
                // 有 data 就顯示隻 report
                String userAgent = VWGContext.Current.HttpContext.Request.UserAgent.ToLower();
                if (userAgent.Contains("msie")) // || userAgent.Contains("chrome") || userAgent.Contains("safari"))
                {
                    ShowReportInHTML();
                }
                else
                {
                    ShowReportInPDF();
                }
            }
            else
            {
                MessageBox.Show("no record found.", "Message");
            }
        }

        private void ShowReportInHTML()
        {
            this.rptViewer.Datasource = _DataSource;

            Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
            subSource.Add(DATASOURCE_XSD_NAME, BindDataCurrent());
            subSource.Add("DataSource_vwStockInOutHistory2", BindDataCurrent());
            subSource.Add("DataSource_vwStockInOutHistory3", BindDataHistory());
            subSource.Add("DataSource_vwStockInOutHistory4", BindDataHistory());
            this.rptViewer.SubReportDataSourceList = subSource;

            this.rptViewer.ReportDatasourceName = DATASOURCE_XSD_NAME;
            this.rptViewer.ReportName = REPORT_RDLC_NAME;
            this.rptViewer.Parameters = GetSelParams();

            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 150;

            this.rptViewer.PreviewReport();
        }

        private void ShowReportInPDF()
        {
            this.splitContainer1.Panel2.Controls.Clear();
            Gizmox.WebGUI.Forms.HtmlBox htmlBox = new HtmlBox();

            htmlBox.Dock = DockStyle.Fill;

            this.splitContainer1.Panel2.Controls.Add(htmlBox);

            Gizmox.WebGUI.Common.Gateways.GatewayReference gw = new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "LoadPDF", false);
            htmlBox.Url = gw.ToString();
        }

        protected override Gizmox.WebGUI.Common.Interfaces.IGatewayHandler ProcessGatewayRequest(System.Web.HttpContext objHttpContext, String strAction)
        {
            if ((strAction != null) && (strAction == "LoadPDF"))
            {
                // Variables
                Warning[] warnings;
                String[] streamIds;
                String mimeType = String.Empty, encoding = String.Empty, extension = String.Empty;

                // Setup the report viewer object and get the array of bytes
                ReportDataSource ds = new ReportDataSource(DATASOURCE_XSD_NAME, _DataSource);
                ReportViewer viewer = new ReportViewer();

                viewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(RptSubreportProcessingEventHandler);

                viewer.ProcessingMode = ProcessingMode.Local;

                //Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
                //subSource.Add(DATASOURCE_XSD_NAME, BindDataCurrent());
                //subSource.Add("DataSource_vwStockInOutHistory2", BindDataCurrent());
                //subSource.Add("DataSource_vwStockInOutHistory3", BindDataHistory());
                //subSource.Add("DataSource_vwStockInOutHistory4", BindDataHistory());

                //viewer.LocalReport.ReportPath = "RT2008.Web.Reports.Rdlc.StockQtyStatusRdl.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.EnableHyperlinks = true;
                viewer.LocalReport.ReportEmbeddedResource = REPORT_RDLC_NAME;
                viewer.LocalReport.DataSources.Add(ds);
                viewer.LocalReport.SetParameters(GetSelParams());

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                System.Web.HttpResponse response = objHttpContext.Response;
                response.Buffer = true;
                response.Clear();
                response.ContentType = mimeType;
                response.AddHeader("content-disposition", "inline; filename=" + REPORT_FILENAME + "." + extension);
                response.BinaryWrite(bytes);    // create the file
                response.Flush();               // send it to the client to download

                return null;
            }
            else
            {
                return this.ProcessGatewayRequest(objHttpContext, strAction);
            }
        }

        void RptSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {

            Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
            subSource.Add(DATASOURCE_XSD_NAME, BindDataCurrent());
            subSource.Add("DataSource_vwStockInOutHistory2", BindDataCurrent());
            subSource.Add("DataSource_vwStockInOutHistory3", BindDataHistory());
            subSource.Add("DataSource_vwStockInOutHistory4", BindDataHistory());

            if (subSource != null)
            {
                DataTable subDataSource;
                String subDataSourceName;
                foreach (KeyValuePair<string, DataTable> kvp in subSource)
                {
                    subDataSource = kvp.Value;
                    subDataSourceName = kvp.Key;

                    e.DataSources.Add(new ReportDataSource(subDataSourceName, subDataSource));
                }
            }
        }

        /// <summary>
        /// 準備 selection criteria
        /// </summary>
        /// <returns></returns>
        private List<ReportParameter> GetSelParams()
        {
            List<ReportParameter> rptParam = new List<ReportParameter>();

            rptParam.Add(new ReportParameter("STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE")));
            rptParam.Add(new ReportParameter("APPENDIX1", Common.Utility.GetSystemLabelByKey("APPENDIX1")));
            rptParam.Add(new ReportParameter("APPENDIX2", Common.Utility.GetSystemLabelByKey("APPENDIX2")));
            rptParam.Add(new ReportParameter("APPENDIX3", Common.Utility.GetSystemLabelByKey("APPENDIX3")));
            rptParam.Add(new ReportParameter("Year", year));
            rptParam.Add(new ReportParameter("Month", month));

            return rptParam;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
    }
}