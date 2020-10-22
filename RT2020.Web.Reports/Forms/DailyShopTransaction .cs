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
    public partial class DailyShopTransaction : Controls.WizardBase
    {
        public DailyShopTransaction()
        {
            InitializeComponent();
            this.txtShop.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwDailyShopTransaction
WHERE SHOP ='" + txtShop.Text.Trim() + @"'
AND YEAR(TxDate)='" + txtYear.Text.Trim() + @"'
AND MONTH(TxDate)='" + txtMonth.Text.Trim() + @"'
AND DAY(TxDate)='" + txtDate.Text.Trim() + @"'
";
            if (txtType.Text.Trim().Length > 0)
            {
                sql += " AND TxType='" + txtType.Text.Trim() + "'";
            }
            if (txtTxNumber.Text.Trim().Length > 0)
            {
                sql += " AND TxNumber='" + txtTxNumber.Text.Trim() + "'";
            }

            sql = sql + " ORDER BY TxType, TxNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ASC"; // 18/01/2010 David: Order by Type, TRN#, STK, A1, A2, A3 
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtShop.Text.Length > 0 && 
                (txtDate.Text.Trim().Length > 0 && txtMonth.Text.Trim().Length>0 && 
                    txtYear.Text.Trim().Length>0))
            {
                List<ReportParameter> rptParam = new List<ReportParameter>();
                rptParam.Add(new ReportParameter("STKCODE",Common.Utility.GetSystemLabelByKey("STKCODE")));
                rptParam.Add(new ReportParameter("APPENDIX1",Common.Utility.GetSystemLabelByKey("APPENDIX1")));
                rptParam.Add(new ReportParameter("APPENDIX2",Common.Utility.GetSystemLabelByKey("APPENDIX2")));
                rptParam.Add(new ReportParameter("APPENDIX3",Common.Utility.GetSystemLabelByKey("APPENDIX3")));

                DataTable table = BindData();
                if (table.Rows.Count > 0)
                {
                    this.rptViewer.Datasource = table;

                    Dictionary<string, DataTable> subSource = new Dictionary<string, DataTable>();
                    subSource.Add("DataSource_vwDailyShopTransaction", table);

                    this.rptViewer.SubReportDataSourceList=subSource;

                    this.rptViewer.ReportDatasourceName = "DataSource_vwDailyShopTransaction";
                    //this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.DailyShopTransactionRdl.rdlc";
                    this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.DailyShopTransactionMaster.rdlc";
                    this.rptViewer.Parameters = rptParam;

                    this.rptViewer.PreviewReport();
                }
                else
                {
                    MessageBox.Show("no record found.", "Message");
                }
            }
            else
            {
                MessageBox.Show("ShopID AND Sales Are Required!", "Message");
            }
            this.txtShop.Focus();
        }

    }
}