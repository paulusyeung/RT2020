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
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.PriceMgmt.Reports
{
    public partial class History : Form
    {
        public History()
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

            PriceManagementActiveHeaderEx.LoadCombo(ref cboFrom, "TxNumber", false, false, string.Empty, "PM_TYPE ='" + type + "'");
        }

        private void FillToList()
        {
            string type = this.ReportType.ToString().Substring(0, 1);

            PriceManagementActiveHeaderEx.LoadCombo(ref cboTo, "TxNumber", false, false, string.Empty, "PM_TYPE ='" + type + "'");

            this.cboTo.SelectedIndex = cboTo.Items.Count - 1;
        }
        #endregion

        #region BindData To Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT * 
FROM vwRptActivePriceMgmt
WHERE TxNumber BETWEEN '" + this.cboFrom.Text.Trim() + "' AND '" + this.cboTo.Text.Trim() + @"'
AND CONVERT(NVARCHAR(10),EffectDate,126) BETWEEN '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") + @"'
                                             AND '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + @"'
";
            if (this.ReportType.ToString().Substring(0, 1) == "P")
            {
                sql += " AND PM_TYPE = 'P'";
            }
            else if (this.ReportType.ToString().Substring(0, 1) == "D")
            {
                sql += " AND PM_TYPE = 'D'";
            }
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

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

        private EnumHelper.PriceMgmtPMType reportType = EnumHelper.PriceMgmtPMType.Price;
        public EnumHelper.PriceMgmtPMType ReportType
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

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = { 
                {"FromTxNumber",this.cboFrom.Text.Trim()},
                {"ToTxNumber",this.cboTo.Text.Trim()},
                {"FromTxDate", this.dtpTxDateFrom.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"ToTxDate", this.dtpTxDateTo.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                {"DateFormat", DateTimeHelper.GetDateFormat()},
                {"STKCODE",SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6")},
                {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource4PriceMgmt_vwRptActivePriceMgmt";

                if (this.ReportType.ToString().Substring(0, 1) == "P")
                {
                    view.ReportName = "RT2020.PriceMgmt.Reports.PriceHistoryRdl.rdlc";
                }
                else if (this.ReportType.ToString().Substring(0, 1) == "D")
                {
                    view.ReportName = "RT2020.PriceMgmt.Reports.DiscountHistoryRdl.rdlc";
                }

                view.Parameters = param;

                view.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}