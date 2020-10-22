#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class StockInOutHistory : Controls.WizardBase
    {
        string year = Common.Utility.CurrentSystemInfo.Default.CurrentSystemYear;
        string month = Common.Utility.CurrentSystemInfo.Default.CurrentSystemMonth;

        public StockInOutHistory()
        {
            InitializeComponent();
            this.txtFromSTK.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #region Valiated
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

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = sqlString();

            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC"; // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
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

            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC"; // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Bind Data to Report(History Monthly)
        private DataTable BindDataHistory()
        {
            string sql = sqlString();

            sql += " AND TxDate <'" + year + "-" + month + "-01 00:00:00'";

            sql += " ORDER BY [FromLocation] ASC, [TxDate] DESC, [STKCODE] ASC, [APPENDIX1] ASC, [APPENDIX2] ASC, [APPENDIX3] ASC, [TxType] ASC, [TxNumber] ASC"; // 18/01/2010 David: Shop# (Asc), Transaction Date (Desc), STK (Asc), A1 (Asc), A2 (Asc), A3 (Asc), Type (Asc), Trn#  (Asc)

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                if (txtFromSTK.Text.Length > 0 && txtSTK.Text.Length > 0)
                {
                    List<ReportParameter> rptParam = new List<ReportParameter>();
                    rptParam.Add(new ReportParameter("STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE")));
                    rptParam.Add(new ReportParameter("APPENDIX1", Common.Utility.GetSystemLabelByKey("APPENDIX1")));
                    rptParam.Add(new ReportParameter("APPENDIX2", Common.Utility.GetSystemLabelByKey("APPENDIX2")));
                    rptParam.Add(new ReportParameter("APPENDIX3", Common.Utility.GetSystemLabelByKey("APPENDIX3")));
                    rptParam.Add(new ReportParameter("Year", year));
                    rptParam.Add(new ReportParameter("Month", month));

                    DataTable table = BindData();
                    if (table.Rows.Count > 0)
                    {
                        this.rptViewer.Datasource = table;

                        Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
                        subSource.Add("DataSource_vwStockInOutHistory", BindDataCurrent());
                        subSource.Add("DataSource_vwStockInOutHistory2", BindDataCurrent());
                        subSource.Add("DataSource_vwStockInOutHistory3", BindDataHistory());
                        subSource.Add("DataSource_vwStockInOutHistory4", BindDataHistory());
                        this.rptViewer.SubReportDataSourceList = subSource;

                        this.rptViewer.ReportDatasourceName = "DataSource_vwStockInOutHistory";
                        this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.StockInOutHistoryRdl.rdlc";
                        this.rptViewer.Parameters = rptParam;

                        this.rptViewer.PreviewReport();

                        this.txtFromSTK.Focus();
                    }
                    else
                    {
                        MessageBox.Show("no record found.", "Message");
                    }

                }
                else
                {
                    MessageBox.Show("STYLE Are Required!", "Message");
                }
            }
        }
    }
}