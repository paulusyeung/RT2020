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
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
#endregion

namespace RT2020.Purchasing.Reports.Receiving
{
    public partial class WeeklyExpectedSummary : Form
    {
        public WeeklyExpectedSummary()
        {
            InitializeComponent();
        }

        #region Fill Combo List
        /// <summary>
        /// Fills the combo list.
        /// </summary>
        private void FillComboList()
        {
            this.FillSuppFromList();
            this.FillSuppToList();
            this.FillStockCodeFromList();
            this.FillStockCodeToList();
            this.FillWorkplaceList();
        }

        /// <summary>
        /// Fills SupplierCode From
        /// </summary>
        private void FillSuppFromList()
        {
            RT2020.DAL.Supplier.LoadCombo(ref cboSupplierFrom, "SupplierCode", false, false, string.Empty, " Retired = 0");
        }

        /// <summary>
        /// Fills SupplierNumber To
        /// </summary>
        private void FillSuppToList()
        {
            RT2020.DAL.Supplier.LoadCombo(ref cboSupplierTo, "SupplierCode", false, false, string.Empty, " Retired = 0");

            if (cboSupplierTo.Items.Count > 0)
            {
                cboSupplierTo.SelectedIndex = cboSupplierTo.Items.Count - 1;
            }
        }

        private DataTable StockCodeList()
        {
            string sql = "SELECT DISTINCT STKCODE FROM Product ORDER BY STKCODE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        /// <summary>
        /// Fills Product From
        /// </summary>
        private void FillStockCodeFromList()
        {
            cboStockCodeFrom.Items.Clear();

            cboStockCodeFrom.DataSource = StockCodeList();
            cboStockCodeFrom.DisplayMember = "STKCODE";
        }

        /// <summary>
        /// Fills Product To
        /// </summary>
        private void FillStockCodeToList()
        {
            cboStockCodeTo.Items.Clear();

            cboStockCodeTo.DataSource = StockCodeList();
            cboStockCodeTo.DisplayMember = "STKCODE";

            if (cboStockCodeTo.Items.Count > 0)
            {
                cboStockCodeTo.SelectedIndex = cboStockCodeTo.Items.Count - 1;
            }
        }

        /// <summary>
        /// Fills the workplace list.
        /// </summary>
        private void FillWorkplaceList()
        {
            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var wpList = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                foreach (var wp in wpList)
                {
                    ListViewItem listItem = lvLocationList.Items.Add(wp.WorkplaceId.ToString());
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(wp.WorkplaceCode);
                    listItem.SubItems.Add(wp.WorkplaceInitial);

                    iCount++;
                }
            }
        }
        #endregion

        private void WeeklyExpectedSummary_Load(object sender, EventArgs e)
        {
            FillComboList();
        }

        #region List View Events

        private void lvLocationList_Click(object sender, EventArgs e)
        {
            if (lvLocationList.Items != null && lvLocationList.SelectedIndex >= 0)
            {
                int index = lvLocationList.SelectedIndex;
                this.lvLocationList.Items[index].SubItems[1].Text = (this.lvLocationList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvLocationList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvLocationList.Items[i];

                if (i < 10)
                {
                    if (oItem.SubItems[1].Text == string.Empty)
                    {
                        oItem.SubItems[1].Text = "*";
                    }
                }
                else
                {
                    oItem.SubItems[1].Text = string.Empty;
                }
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvLocationList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvLocationList.Items[i];

                oItem.SubItems[1].Text = string.Empty;
            }
        }

        private string SelectedWorkplaceList()
        {
            StringBuilder selectList = new StringBuilder();
            // ArrayList arr = new ArrayList();
            for (int i = 0; i < this.lvLocationList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvLocationList.Items[i];

                if (oItem.SubItems[1].Text == "*")
                {
                    //arr.Add(oItem.SubItems[2].Text);
                    selectList.Append("'" + oItem.SubItems[2].Text + "'" + ",");
                }
            }
            return selectList.ToString().Trim(',');
            //return arr.ToArray(typeof(String)) as string[];
        }

        #endregion

        #region Bind Data to report
        private DataTable BindData()
        {
            string orderlist = string.Empty;
            string WhereCause = string.Empty;
            string viewSource = string.Empty;

            if (this.cboSortBy.Text.Trim() == "Stock Code")
            {
                orderlist = "STKCODE";
            }
            else
            {
                orderlist = "SupplierCode";
            }

            if (rbSunday.Checked)
            {
                viewSource = "vwRptPurchaseWeeklyExpectedReceivingSummaryStartOnSunday";
            }
            else if (rbMonday.Checked)
            {
                viewSource = "vwRptPurchaseWeeklyExpectedReceivingSummaryStartOnMonday";
            }

            WhereCause = @"
WHERE SupplierCode BETWEEN '" + this.cboSupplierFrom.Text.Trim() + @"' AND '" + this.cboSupplierTo.Text.Trim() + @"' 
AND STKCODE BETWEEN '" + this.cboStockCodeFrom.Text.Trim() + @"'  AND '" + this.cboStockCodeTo.Text.Trim() + @"'                                            
AND DeliverOn BETWEEN '" + this.dtDateFrom.Value.ToString("yyyy-MM-dd") + @"' AND '" + this.dtDateTo.Value.ToString("yyyy-MM-dd") + @"'
AND WorkplaceCode IN(" + SelectedWorkplaceList() + ")";

            #region SQL
            string sql = @"
SELECT RowNum.OrderOn,WeeklySunday.* FROM
(
	SELECT CLASS1,CLASS2,CLASS3,CLASS4,CLASS5,CLASS6,APPENDIX1,APPENDIX2,APPENDIX3,STKCODE,SupplierCode,
	WorkplaceCode,ProductName,DeliverOn,OrderedQty,RetailValue,StockValue,WeekNumber,WeekStartOn,WeekEndOn
	FROM " + viewSource + " " + WhereCause + @"
	GROUP BY CLASS1,CLASS2,CLASS3,CLASS4,CLASS5,CLASS6,APPENDIX1,APPENDIX2,APPENDIX3,STKCODE,SupplierCode,
	WorkplaceCode,ProductName,DeliverOn,OrderedQty,RetailValue,StockValue,WeekNumber,WeekStartOn,WeekEndOn
) AS WeeklySunday
INNER JOIN
(
	SELECT ROW_NUMBER() OVER(ORDER BY " + orderlist + @") OrderOn ,CLASS1,CLASS2,CLASS3,CLASS4,CLASS5,CLASS6,
	APPENDIX1,APPENDIX2,APPENDIX3,STKCODE,SupplierCode,WorkplaceCode
	FROM " + viewSource + " " + WhereCause + @"
	GROUP BY CLASS1,CLASS2,CLASS3,CLASS4,CLASS5,CLASS6,
	APPENDIX1,APPENDIX2,APPENDIX3,STKCODE,SupplierCode,WorkplaceCode
) AS RowNum
ON WeeklySunday.CLASS1=RowNum.CLASS1 AND WeeklySunday.CLASS2=RowNum.CLASS2 AND WeeklySunday.CLASS3=RowNum.CLASS3 
AND WeeklySunday.CLASS4=RowNum.CLASS4 AND WeeklySunday.CLASS5=RowNum.CLASS5 AND WeeklySunday.CLASS6=RowNum.CLASS6 
AND WeeklySunday.STKCODE=RowNum.STKCODE AND WeeklySunday.SupplierCode=RowNum.SupplierCode 
AND WeeklySunday.WorkplaceCode=RowNum.WorkplaceCode	AND WeeklySunday.APPENDIX1=RowNum.APPENDIX1 
AND WeeklySunday.APPENDIX2=RowNum.APPENDIX2 AND WeeklySunday.APPENDIX3=RowNum.APPENDIX3
ORDER BY " + orderlist + "";

            #endregion

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

        private bool VerifySelections()
        {
            bool result = true;

            if (lvLocationList.SelectedItems.Count == 0)
            {
                result = false;
                MessageBox.Show("Please select Location");
            }
            return result;
        }

        private void DoPreview()
        {
            string DatasourceName = string.Empty;
            string reportName = string.Empty;
            string StartOn = string.Empty;

            if (rbSunday.Checked)
            {
                //StartOn = "SU";
                DatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseWeeklyExpectedReceivingSummaryStartOnSunday";
                reportName = "RT2020.Purchasing.Reports.Receiving.Reports.WeeklyExpectedReceivingSummary_SundayRdl.rdlc";
            }
            else if (rbMonday.Checked)
            {
                //StartOn = "MO";
                DatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseWeeklyExpectedReceivingSummaryStartOnMonday";
                reportName = "RT2020.Purchasing.Reports.Receiving.Reports.WeeklyExpectedReceivingSummary_MondayRdl.rdlc";
            }
            string[,] param ={
            {"DateBegin",this.dtDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
            {"DateEnd",this.dtDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
            {"SupplierCodeFrom",this.cboSupplierFrom.Text.Trim()},
            {"SupplierCodeTo",this.cboSupplierTo.Text.Trim()},
            {"STKCODEFrom",this.cboStockCodeFrom.Text.Trim()},
            {"STKCODETo",this.cboStockCodeTo.Text.Trim()},
            {"StartOn",StartOn.ToString()},
            {"SelectedWorkplaceCode",this.SelectedWorkplaceList().ToString().Trim(',')},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer viewer = new RT2020.Controls.Reporting.Viewer();

            //viewer.Datasource = SqlHelper.ExecuteDataSet("apRptPurchaseWeeklyExpectedReceivingSummary",obj).Tables[0];
            viewer.Datasource = BindData();
            viewer.ReportDatasourceName = DatasourceName;
            viewer.ReportName = reportName;
            viewer.Parameters = param;

            if ((SelectedWorkplaceList().Length != 0) && (rbMonday.Checked || rbSunday.Checked))
            {
                viewer.Show();
            }
            else
            {
                MessageBox.Show("Location和WeekdayStart中任何一项不能为空!", "请选值！");
                viewer.Close();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (VerifySelections())
            {
                DoPreview();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}