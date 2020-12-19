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

#endregion

namespace RT2020.Inventory.Reports.History
{
    public partial class InOutHistory_List : Form
    {
        String[] _StockCodeList = null;

        public InOutHistory_List()
        {
            InitializeComponent();

            SetAttributes();
            FillComboList();
        }

        private void SetAttributes()
        {
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

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            return ds.Tables[0];
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

            if (String.Compare(this.cboFrom.Text.Trim(), this.cboTo.Text.Trim()) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: STKCODE Error ", "Message");
            }
            else if (dtpTxDateFrom.Value.ToString("dd/MM/yyyy").CompareTo(dtpTxDateTo.Value.ToString("dd/MM/yyyy")) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: Tx Date", "Message");
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
AND CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") + @"' 
                                       AND '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + @"'
ORDER BY STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, TxDate, TxType, TxNumber";
            
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = {
                {"STKFrom",this.cboFrom.Text.Trim()},
                {"STKTo",this.cboTo.Text.Trim()},
                {"FromDate",this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"ToDate",this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
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
                {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwInOutHistory";
                view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_ListRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
        }
    }
}