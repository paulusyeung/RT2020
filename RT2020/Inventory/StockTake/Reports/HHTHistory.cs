#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.StockTake.Reports
{
    public partial class HHTHistory : Form
    {
        public HHTHistory()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindComboList();
        }

        private void BindComboList()
        {
            StocktakeHeader_HHTEx.LoadCombo(
                ref cboTxNumber,
                new string[] { "TxNumber", "HHTId", "UploadedOn" },
                "{0}\t{1}\t{2}",
                false, false, string.Empty,
                "YEAR(PostedOn) > 1900 AND Retired = 0",
                new string[] { "TxNumber", "HHTId", "UploadedOn" }
                );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cboTxNumber.SelectedValue != null)
            {
                string txNumber = this.cboTxNumber.Text.Trim().Length > 12 ? this.cboTxNumber.Text.Trim().Substring(0, 12) : string.Empty;
                string[,] param = {
                { "FromTxNumber",txNumber},
                { "ToTxNumber",txNumber},
                { "PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                { "DateFormat",DateTimeHelper.GetDateFormat()},
                { "DateFormatWithTime",DateTimeHelper.GetDateTimeFormat()},
                { "CompanyName", SystemInfoEx.CurrentInfo.Default.CompanyName},
                { "DataType", rbtnAllData.Checked.ToString()},
                { "StockCode", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptStkTkHHTList";
                view.ReportName = "RT2020.Inventory.StockTake.Reports.HHTHistoryRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
            else
            {
                MessageBox.Show("No record found!", "ATTENTION");
            }
        }

        #region Bind date to report

        private DataTable BindData()
        {
            string sql = @"
                          SELECT TOP 100 PERCENT *
                          FROM vwRptStkTkHHTList
                          WHERE	HeaderId = '" + this.cboTxNumber.SelectedValue.ToString() + @"' AND YEAR(PostedOn) > 1900
                          ORDER BY TxNumber
                          ";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        #endregion
    }
}