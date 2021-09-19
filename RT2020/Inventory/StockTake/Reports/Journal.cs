#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Gizmox.WebGUI.Common.Interfaces;
using System.IO;
using FileHelpers.DataLink;
using FileHelpers.MasterDetail;
using System.Web;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;
#endregion

namespace RT2020.Inventory.StockTake.Reports
{
    public partial class JournalWizard : Form
    {
        public JournalWizard()
        {
            InitializeComponent();
            FillComboList();

            this.txtMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            this.txtYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            FillLocation();
            FillVsLocation();
            FillRemarks();
        }

        private void FillLocation()
        {
            WorkplaceEx.LoadCombo(ref cboLocation, "WorkplaceCode", false);
        }

        private void FillVsLocation()
        {
            WorkplaceEx.LoadCombo(ref cboVsLocation, "WorkplaceCode", false);
        }

        private void FillRemarks()
        {
            string[] oItems = { "Class 1 - 6", "Description" };
            this.cboRemarks.Items.Clear();
            this.cboRemarks.Items.AddRange(oItems);
            this.cboRemarks.SelectedIndex = 0;
        }

        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            int year = 0;
            int month = 0;
            if (int.TryParse(this.txtMonth.Text.Trim(), out month) && int.TryParse(this.txtYear.Text.Trim(), out year))
            {
                if (year <= 0 || year > 9999)
                {
                    result = false;
                    MessageBox.Show("Range Error: Year Error", "Message");
                }
                else if (month < 1 || month > 12)
                {
                    result = false;
                    MessageBox.Show("Range Error: Month Error", "Message");
                }
                else if (dtpTxDateTo.Value < dtpTxDateFrom.Value)                   // dtpTxDateTo < dtpTxDateFrom
                {
                    result = false;
                    MessageBox.Show("Range Error: Tx Date", "Message");
                }
            }
            else
            {
                result = false;
                MessageBox.Show("Format Error:Year and Month Must be a number of", "Message");
            }
            return result;
        }
        #endregion

        #region Bind data
        private DataTable BindData()
        {
            string Shop = string.Empty;
            Shop = this.cboLocation.Text.Trim().Substring(0, this.cboLocation.Text.Trim().IndexOf(' '));

            string sql = @"
            SELECT * FROM dbo.vwJournalStkTKList WHERE (STKCODE >= '" + txtFromStockCode.Text.Trim() + "') AND (STKCODE <= '" + txtToStockCode.Text.Trim() + @"')
                            AND CONVERT(VARCHAR(10),TxDate,126) BETWEEN '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") + @"'
                            AND '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + "' AND Workplace = '" + Shop + @"'
                            ORDER BY STKCODE, TxNumber";
            
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

        #region LoadDateTime
        private void LoadDateToDateTimePicker()
        {
            dtpTxDateFrom.Value = new DateTime(ForYear, ForMonth, 1);
            dtpTxDateTo.Value = new DateTime(ForYear, ForMonth, DateTime.DaysInMonth(ForYear, ForMonth));
        }

        private int ForMonth
        {
            get
            {
                return int.Parse(this.txtMonth.Text.Trim());
            }
        }

        private int ForYear
        {
            get
            {
                return int.Parse(this.txtYear.Text.Trim());
            }
        }
        #endregion

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                LoadDateToDateTimePicker();
            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                LoadDateToDateTimePicker();
            }
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = { 
                {"FromTxDate", this.dtpTxDateFrom.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"ToTxDate", this.dtpTxDateTo.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                {"DateFormat", DateTimeHelper.GetDateFormat()},
                {"LocationFrom",txtFromStockCode.Text},
                {"LocationTo",txtToStockCode.Text},
                {"STKLabel",SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6")},  
                {"Locations",this.cboLocation.Text.Substring(0,cboLocation.Text.IndexOf(' '))},
                {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwJournalStkTKList";
                view.ReportName = "RT2020.Inventory.StockTake.Reports.JournalRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}