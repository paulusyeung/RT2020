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
using System.Data.SqlClient;
using RT2020.Helper;
#endregion

namespace RT2020.Inventory.StockTake.Reports
{
    public partial class History : Form
    {
        private string _TxNumberFrom = "00";
        private string _TxNumberTo = "zz";

        private DateTime FromDate;

        public History()
        {
            InitializeComponent();
        }

        #region Validate Seletions
        private bool IsSelValid()
        {
            bool result = true;

            if (this.txtTxNumberFrom.Text.Trim() != string.Empty)
            {
                _TxNumberFrom = this.txtTxNumberFrom.Text.Trim();
            }

            if (this.txtTxNumberTo.Text.Trim() != string.Empty)
            {
                _TxNumberTo = this.txtTxNumberTo.Text.Trim();
            }

            if (string.Compare(_TxNumberTo, _TxNumberFrom) < 0)      // _TxNumberTo < _TxNumberFrom
            {
                result = false;
                MessageBox.Show("Range Error: Tx Number", "Message");
            }
            else if (dtpTxDateFrom.Value > dtpTxDateTo.Value)        // dtpTxDateTo < dtpTxDateFrom
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
            FromDate = new DateTime(Convert.ToInt32(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear),
                Convert.ToInt32(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth), 1);

            string sql = @"
                      SELECT TOP 100 PERCENT *
                      FROM vwRptStkTkList
                      WHERE TxNumber >= '" + this.txtTxNumberFrom.Text.Trim() + @"' AND TxNumber <= '" + this.txtTxNumberTo.Text.Trim() + @"'
                      AND CONVERT(NVARCHAR(10),TxDate,126) >= '" + this.FromDate.ToString("yyyy-MM-dd") + @"'
                      AND CONVERT(NVARCHAR(10),TxDate,126) <= '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + @"'
                      AND YEAR(PostedOn) > 1900
                      ORDER BY TxNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3  
                      ";
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = {
                {"FromTxNumber",this.txtTxNumberFrom.Text.Trim()},
                {"ToTxNumber",this.txtTxNumberTo.Text.Trim()},
                {"FromTxDate",this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"ToTxDate",this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"PrintedBy", ModelEx.StaffEx.GetStaffNameById(Common.Config.CurrentUserId) },
                {"DateFormat",RT2020.SystemInfo.Settings.GetDateFormat()},
                { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName},
                { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName="RT2020_Controls_Reporting_DataSource_vwRptStkTkList";
                view.ReportName= "RT2020.Inventory.StockTake.Reports.HistoryRdl.rdlc";
                view.Parameters=param;

                view.Show();
            }
        }
    }
}