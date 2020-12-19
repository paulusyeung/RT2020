#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Data.SqlClient;
using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.PriceMgmt.Reports
{
    public partial class Worksheet : Form
    {
        public Worksheet()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Text += " Reports [ " + ReportType.ToString() + " ]";

            FillComboList();
        }
     
        #region Fill Combo List
        private void FillComboList()
        {
            FillFromList();
            FillToList();
        }

        private void FillFromList()
        {
            string type = this.ReportType.ToString().Substring(0, 1);

            ModelEx.PriceManagementBatchHeaderEx.LoadCombo(ref cboFrom, "TxNumber", false, false, string.Empty, "PM_TYPE ='" + type + "'");

        }

        private void FillToList()
        {
            string type = this.ReportType.ToString().Substring(0, 1);

            ModelEx.PriceManagementBatchHeaderEx.LoadCombo(ref cboTo, "TxNumber", false, false, string.Empty, "PM_TYPE ='" + type + "'");

            this.cboTo.SelectedIndex = cboTo.Items.Count - 1;
        }
        #endregion

        #region BindData To Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT * 
FROM vwRptBatchPriceMgmt
WHERE TxNumber BETWEEN '" + this.cboFrom.Text.Trim() + "' AND '" + this.cboTo.Text.Trim() + @"'
AND CONVERT(NVARCHAR(10),EffectDate,126) BETWEEN '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") + @"'
                                             AND '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + @"'
";
            sql += " AND PM_TYPE = '" + this.ReportType.ToString().Substring(0, 1) + "'";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            if (string.Compare(this.cboFrom.Text.Trim(), this.cboTo.Text.Trim()) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: Tx Number", "Message");
            }
            else if (this.dtpTxDateFrom.Value > this.dtpTxDateTo.Value)
            {
                result = false;
                MessageBox.Show("Range Error: Tx Date", "Message");
            }
            return result;
        }
        #endregion

        private PriceUtility.PriceMgmtType reportType = PriceUtility.PriceMgmtType.Price;
        public PriceUtility.PriceMgmtType ReportType
        {
            get
            {
                return reportType;
            }
            set
            {
                reportType = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = { 
                {"FromTxNumber",this.cboFrom.Text.Trim()},
                {"ToTxNumber",this.cboTo.Text.Trim()},
                {"FromTxDate", this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"ToTxDate", this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"DateFormat", RT2020.SystemInfo.Settings.GetDateFormat()},
                {"STKCODE",RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6")},
                {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource4PriceMgmt_vwRptBatchPriceMgmt";

                if (this.ReportType.ToString().Substring(0, 1) == "P")
                {
                    view.ReportName = "RT2020.PriceMgmt.Reports.PriceWorksheetRdl.rdlc";
                }
                else if (this.ReportType.ToString().Substring(0, 1) == "D")
                {
                    view.ReportName = "RT2020.PriceMgmt.Reports.DiscountWorksheetRdl.rdlc";
                }

                view.Parameters = param;

                view.Show();
            }
        }
    }
}