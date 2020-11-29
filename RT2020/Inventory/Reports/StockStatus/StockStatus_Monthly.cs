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
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Inventory.Reports.StockStatus
{
    public partial class StockStatus_Monthly : Form
    {
        string currentYeaar = string.Empty;
        string currentMonth = string.Empty;
        String[] _StockCodeList = null;

        public StockStatus_Monthly()
        {
            InitializeComponent();

            SetAttributes();
            FillComboList();
        }

        private void SetAttributes()
        {
            currentYeaar = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear;
            currentMonth = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth;

            this.txtYear.Text = currentYeaar;
            this.txtMonth.Text = currentMonth;
            this.txtMonth.Focus();

            cboFrom.DropDownStyle = ComboBoxStyle.DropDown;
            cboFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTo.DropDownStyle = ComboBoxStyle.DropDown;
            cboTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboLocationFrom.DropDownStyle = ComboBoxStyle.DropDown;
            cboLocationFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboLocationTo.DropDownStyle = ComboBoxStyle.DropDown;
            cboLocationTo.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            SetStockCodeList();
            FillStockCodeFromList();
            FillStockCodeToList();
            FillLocationList();
        }

        private void SetStockCodeList()
        {
            string sql = " SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet ds = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
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
            string sql = " SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
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

        private void FillLocationList()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                if (list.Count > 0)
                {
                    foreach (var oWorkplace in list)
                    {
                        System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(oWorkplace.WorkplaceCode, oWorkplace.WorkplaceId.ToString());
                        cboLocationTo.Items.Add(item);
                        cboLocationFrom.Items.Add(item);
                    }

                    cboLocationFrom.SelectedIndex = 0;

                    cboLocationTo.SelectedIndex = list.Count - 1;
                }
            }
        }

        #endregion

        #region Validate Section
        private bool IsSelValid()
        {
            bool result = true;
            int year = 0;
            int month = 0;

            if (int.TryParse(this.txtYear.Text.Trim(), out year) && int.TryParse(this.txtMonth.Text.Trim(), out month))
            {
                if (month > 13 || month < 1)
                {
                    result = false;
                    MessageBox.Show("Format Error: Month Error", "Message");
                }
                else if (year > 9999 || year < 0)
                {
                    result = false;
                    MessageBox.Show("Format Error: Year Error", "Message");
                }
                else if (string.Compare(this.cboLocationFrom.Text.Trim(), this.cboLocationTo.Text.Trim()) > 0)
                {
                    result = false;
                    MessageBox.Show("Range Error: Location Error ", "Message");
                }
                else if (string.Compare(this.cboFrom.Text.Trim(), this.cboTo.Text.Trim()) > 0)
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

        #region ReportDatasourceName
        private string ReportDataSourceName()
        {
            string reportDatasourceName = string.Empty;
            if (FromYear < int.Parse(currentYeaar))
            {
                reportDatasourceName = "vwRptStockStatus_Monthly_Period";
            }
            else
            {
                if (FromMonth >= int.Parse(currentMonth))
                {
                    reportDatasourceName = "vwRptStockStatus_Monthly";
                }
                else
                {
                    reportDatasourceName = "vwRptStockStatus_Monthly_Period";
                }
            }
            return reportDatasourceName;
        }
        #endregion

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP(100) PERCENT * 
FROM " + ReportDataSourceName() + @"
WHERE STKCODE BETWEEN '" + this.cboFrom.Text.Trim() + "' AND '" + this.cboTo.Text.Trim() + @"'
AND Location BETWEEN '" + this.cboLocationFrom.Text.Trim() + "' AND '" + this.cboLocationTo.Text.Trim() + @"'       
";

            if (FromYear < int.Parse(currentYeaar) || (FromYear == int.Parse(currentYeaar) && FromMonth < int.Parse(currentMonth)))
            {
                sql = sql + " AND FiscalYear = " + FromYear + " AND Period = " + FromMonth;
            }

            sql = sql + " ORDER BY STKCODE";

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {

                string[,] param = {
                {"STKFrom",this.cboFrom.Text.Trim()},
                {"STKTo",this.cboTo.Text.Trim()},
                {"CurrentYear",currentYeaar},
                {"CurrentMonth",currentMonth},
                {"FromYear",this.txtYear.Text.Trim().ToString()},
                {"FromMonth",this.txtMonth.Text.Trim().ToString()},
                {"PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"DateFormat", RT2020.SystemInfo.Settings.GetDateFormat()},
                {"STKLabel",RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6")},
                {"FromLocation",this.cboLocationFrom.Text.Trim().ToString()},
                {"ToLocation",this.cboLocationTo.Text.Trim().ToString()},
                {"CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_" + ReportDataSourceName() + "";

                #region ReportName
                if (ReportDataSourceName() == "vwRptStockStatus_Monthly")
                {
                    if (this.cboStkRemark.Text.Trim() == "Class 1 - 6")
                    {
                        view.ReportName = "RT2020.Inventory.Reports.StockStatus.StockStatus_MonthlyWithClassRdl.rdlc";
                    }
                    else if (this.cboStkRemark.Text.Trim() == "Description")
                    {
                        view.ReportName = "RT2020.Inventory.Reports.StockStatus.StockStatus_MonthlyWithDescRdl.rdlc";
                    }
                }
                else
                {
                    if (this.cboStkRemark.Text.Trim() == "Class 1 - 6")
                    {
                        view.ReportName = "RT2020.Inventory.Reports.StockStatus.StockStatus_MonthlyPeriodWithClassRdl.rdlc";
                    }
                    else if (this.cboStkRemark.Text.Trim() == "Description")
                    {
                        view.ReportName = "RT2020.Inventory.Reports.StockStatus.StockStatus_MonthlyPeriodWithDescRdl.rdlc";
                    }
                }
                #endregion

                view.Parameters = param;

                view.Show();
            }
        }
    }
}