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
using System.Collections;
using RT2020.Helper;
using RT2020.ModelEx;

#endregion

namespace RT2020.Inventory.Reports.History
{
    public partial class InOutHistory_Monthly : Form
    {
        String[] _StockCodeList = null;

        public InOutHistory_Monthly()
        {
            InitializeComponent();

            SetAttributes();
            FillComboList();
        }

        private void SetAttributes()
        {
            this.txtYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
            this.txtMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            this.cboFrom.Focus();

            cboFrom.DropDownStyle = ComboBoxStyle.DropDown;
            cboFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTo.DropDownStyle = ComboBoxStyle.DropDown;
            cboTo.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            SetStockCodeList();
            FillStockCodeFromList();
            FillStockCodeToList();
        }

        private void SetStockCodeList()
        {
            string sql = " SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SortedList sList = new SortedList(ds.Tables[0].Rows.Count);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sList.Add(row["STKCODE"], null);
                    }
                    ArrayList aList = new ArrayList(sList.Keys);
                    _StockCodeList = (string[])aList.ToArray(typeof(string));
                }
            }
        }

        //2013.12.08 paulus: too slow, deprecated
        private DataTable StockCodeList()
        {
            string sql = "SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private void FillStockCodeFromList()
        {
            cboFrom.Items.Clear();

            //if (StockCodeList().Rows.Count > 0)
            //{
            //    cboFrom.DataSource = StockCodeList();
            //    cboFrom.DisplayMember = "STKCODE";
            //    cboFrom.SelectedIndex = 0;
            //}
            cboFrom.Items.AddRange(_StockCodeList);
            cboFrom.SelectedIndex = 0;
        }

        private void FillStockCodeToList()
        {
            cboTo.Items.Clear();

            //if (StockCodeList().Rows.Count > 0)
            //{
            //    cboTo.DataSource = StockCodeList();
            //    cboTo.DisplayMember = "STKCODE";
            //    cboTo.SelectedIndex = StockCodeList().Rows.Count - 1;
            //}
            cboTo.Items.AddRange(_StockCodeList);
            cboTo.SelectedIndex = _StockCodeList.Length - 1;
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
                if (month < 1 || month > 12)
                {
                    result = false;
                    MessageBox.Show("Format Error: Month Error", "Message");
                }
                else if (year < 0 || year > 9999)
                {
                    result = false;
                    MessageBox.Show("Format Error: Year Error", "Message");
                }
                else if (String.Compare(this.cboFrom.Text.Trim(), this.cboTo.Text.Trim()) > 0)
                {
                    result = false;
                    MessageBox.Show("Range Error: STKCODE Error ", "Message");
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

        #region Bind Data To Report
        private DataTable BindData()
        {
            string sql = @"
        SELECT TOP(100) PERCENT * FROM dbo.vwInOutHistory
        WHERE STKCODE BETWEEN '" + this.cboFrom.Text.Trim() + "' AND '" + this.cboTo.Text.Trim() + @"'
        AND DATEPART(Year,TxDate) = '" + FromYear + @"'
        AND DATEPART(Month,TxDate) = '" + FromMonth + @"'
        ORDER BY STKCODE";

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

        #region Properties
        private int FromYear
        {
            get
            {
                return int.Parse(this.txtYear.Text.Trim());
            }
        }

        private int FromMonth
        {
            get
            {
                return int.Parse(this.txtMonth.Text.Trim());
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                DateTime FromDate = new DateTime(FromYear, FromMonth, 1);
                DateTime ToDate = new DateTime(FromYear, FromMonth, DateTime.DaysInMonth(FromYear, FromMonth));

                string[,] param = {
                {"STKFrom",this.cboFrom.Text.Trim()},
                {"STKTo",this.cboTo.Text.Trim()},
                {"FromDate",FromDate.ToString("dd/MM/yyyy")},
                {"ToDate",ToDate.ToString("dd/MM/yyyy")},
                {"PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                {"DateFormat", DateTimeHelper.GetDateFormat()},
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
                {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
                };

                #region ProcParameter
                //SqlParameter[] obj = { 
                //                         new SqlParameter("@STKFrom",this.cboFrom.Text.Trim()),
                //                         new SqlParameter("@STKTo",this.cboTo.Text.Trim()),
                //                         new SqlParameter("@Year",this.FromYear),
                //                         new SqlParameter("@Month",this.FromMonth)
                //                     };
                #endregion

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                //view.Datasource = SqlHelper.ExecuteDataSet("spInOutMonthlyHistory", obj).Tables[0];
                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwInOutHistory";
                view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_MonthlyRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
        }
    }
}