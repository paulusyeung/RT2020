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
using RT2020.DAL;

#endregion

namespace RT2020.Inventory.StockTake.Reports
{
    public partial class VarianceList : Form
    {
        private string whereClause = string.Empty;
        private string reportName = string.Empty;
        public VarianceReportType ReportType { get; set; }

        public VarianceList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Init();

            dtpFromDate.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-01"));
            dtpToDate.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-" + DateTime.Now.ToString("dd")));
        }

        private void Init()
        {
            switch (this.ReportType)
            {
                case VarianceReportType.Worksheet:
                    this.Text = "Stock Take Variance List";
                    whereClause = "YEAR(PostedOn) = 1900";
                    reportName = "RT2020.Inventory.StockTake.Reports.VarianceListWorksheetRdl.rdlc";
                    break;
                case VarianceReportType.History:
                    this.Text = "Stock Take Variance List History";
                    whereClause = "YEAR(PostedOn) > 1900";
                    reportName = "RT2020.Inventory.StockTake.Reports.VarianceListHistoryRdl.rdlc";
                    break;
                case VarianceReportType.WorksheetWithoutCost:
                    this.Text = "Stock Take Variance List (Without COST)";
                    whereClause = "YEAR(PostedOn) = 1900";
                    reportName = "RT2020.Inventory.StockTake.Reports.VarianceListWorksheetWitoutCostRdl.rdlc";
                    break;
                case VarianceReportType.HistoryWithoutCost:
                    this.Text = "Stock Take Variance List History (Without COST)";
                    whereClause = "YEAR(PostedOn) > 1900";
                    reportName = "RT2020.Inventory.StockTake.Reports.VarianceListHistoryWitoutCostRdl.rdlc";
                    break;
            }

            FillComboList(whereClause);
        }

        #region Load Combo List

        private void FillComboList(string whereClause)
        {
            if (whereClause.Trim().Length > 0)
            {
                whereClause += " AND ";
            }

            whereClause += " Retired = 0 ";

            FillFromList(whereClause);
            FillToList(whereClause);
        }

        private void FillFromList(string whereClause)
        {
            cboFromTxNumber.Items.Clear();

            ModelEx.StockTakeHeaderEx.LoadCombo(ref cboFromTxNumber, "TxNumber", false);
        }

        private void FillToList(string whereClause)
        {
            cboToTxNumber.Items.Clear();

            ModelEx.StockTakeHeaderEx.LoadCombo(ref cboToTxNumber, "TxNumber", false, false, string.Empty, whereClause);

            cboToTxNumber.SelectedIndex = cboToTxNumber.Items.Count - 1;
        }

        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;

            if (String.Compare(cboToTxNumber.Text.Trim(), cboFromTxNumber.Text.Trim()) < 0)        //cboTo < cboFrom
            {
                result = false;
                MessageBox.Show("Range Error: Tx Number", "Message");
            }
            else if (String.Compare(dtpToDate.Value.ToString("yyyy-MM-dd"), dtpFromDate.Value.ToString("yyyy-MM-dd")) < 0)                     //dtpTxDateTo<dtpTxDateFrom
            {
                result = false;
                MessageBox.Show("Range Error: Tx Date", "Message");
            }
            return result;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid() && reportName.Trim().Length > 0)
            {
                string[,] param = {
                { "FromTxNumber",this.cboFromTxNumber.Text.Trim()},
                { "ToTxNumber",this.cboToTxNumber.Text.Trim()},
                { "FromTxDate",this.dtpFromDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                { "ToTxDate",this.dtpToDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                { "PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                { "IgnoreZeroDiff",chkIgnoreDiffZeroRecord.Checked.ToString()},
                { "DateFormat",RT2020.SystemInfo.Settings.GetDateFormat()},
                { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName},
                { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptStkTkList";
                view.ReportName = reportName;
                view.Parameters = param;

                view.Show();
            }
        }

        #region Bind date to report
        private DataTable BindData()
        {
            string sql = @"
                          SELECT TOP 100 PERCENT *
                          FROM vwRptStkTkList
                          WHERE	TxNumber >= '" + this.cboFromTxNumber.Text.Trim() + @"' AND TxNumber <= '" + this.cboToTxNumber.Text.Trim() + @"' 
                          AND CONVERT(VARCHAR(10), TxDate, 126) >= '" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + @"' 
                          AND CONVERT(VARCHAR(10), TxDate, 126) <= '" + this.dtpToDate.Value.ToString("yyyy-MM-dd") + @"'
                          AND " + ((whereClause.Trim().Length > 0) ? whereClause : " 1 = 1 ") +
                                ((chkIgnoreDiffZeroRecord.Checked) ? " AND ((HHTQty + Book1Qty + Book2Qty + Book3Qty + Book4Qty + Book5Qty) - (CapturedQty)) <> 0" : "") + @"
                          ORDER BY TxNumber, TxDate";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Enums

        public enum VarianceReportType
        {
            Worksheet,
            History,
            WorksheetWithoutCost,
            HistoryWithoutCost
        }

        #endregion
    }
}