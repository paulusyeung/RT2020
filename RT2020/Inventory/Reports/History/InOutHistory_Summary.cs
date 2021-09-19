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
using System.Linq;
using System.Data.Entity;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.Reports.History
{
    public partial class InOutHistory_Summary : Form
    {
        String[] _StockCodeList = null;
        string currentDate = string.Empty;

        public InOutHistory_Summary()
        {
            InitializeComponent();

            SetAttributes();
            FillComboList();
        }

        private void SetAttributes()
        {
            currentDate = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear +
                SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            txtForMonth.Text = currentDate;

            cboSTKCodeFrom.DropDownStyle = ComboBoxStyle.DropDown;
            cboSTKCodeFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboSTKCodeTo.DropDownStyle = ComboBoxStyle.DropDown;
            cboSTKCodeTo.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            SetStockCodeList();
            FillComboListFrom();
            FillComboListTo();
            FillLocationList();
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

        private void FillComboListFrom()
        {
            cboSTKCodeFrom.Items.Clear();
            //cboSTKCodeFrom.DataSource = StockCodeList();
            //cboSTKCodeFrom.DisplayMember = "STKCODE";
            cboSTKCodeFrom.Items.AddRange(_StockCodeList);
            cboSTKCodeFrom.SelectedIndex = 0;
        }

        private void FillComboListTo()
        {
            cboSTKCodeTo.Items.Clear();
            //cboSTKCodeTo.DataSource = StockCodeList();
            //cboSTKCodeTo.DisplayMember = "STKCODE";

            //if (cboSTKCodeTo.Items.Count > 0)
            //{
            //    cboSTKCodeTo.SelectedIndex = cboSTKCodeTo.Items.Count - 1;
            //}
            cboSTKCodeTo.Items.AddRange(_StockCodeList);
            cboSTKCodeTo.SelectedIndex = _StockCodeList.Length - 1;
        }
        #endregion

        #region Fill ListView Location
        private void FillLocationList()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                foreach (var wk in list)
                {
                    ListViewItem listItem = lvLocationList.Items.Add(wk.WorkplaceId.ToString());
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(wk.WorkplaceCode + " - " + wk.WorkplaceInitial);
                }
            }
        }
        #endregion

        #region ListView Event
        private string SelectedWorkplaceCodeList()
        {
            StringBuilder selectList = new StringBuilder();
            for (int i = 0; i < lvLocationList.Items.Count - 1; i++)
            {
                ListViewItem oItem = lvLocationList.Items[i];
                if (oItem.SubItems[1].Text == "*")
                {
                    selectList.Append("'" + oItem.SubItems[2].Text.Substring(0,4) + "'" + ",");
                }
            }
            return selectList.ToString().Trim(',');
        }

        private void lvLocationList_Click(object sender, EventArgs e)
        {
            if (lvLocationList.Items != null && lvLocationList.SelectedIndex >= 0)
            {
                int index = lvLocationList.SelectedIndex;
                lvLocationList.Items[index].SubItems[1].Text = (lvLocationList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= lvLocationList.Items.Count - 1; i++)
            {
                ListViewItem oItem = lvLocationList.Items[i];
                if (oItem.SubItems[1].Text == "*")
                {
                    oItem.SubItems[1].Text = string.Empty;
                }
                else
                {
                    oItem.SubItems[1].Text = "*";
                }
            }
        }

        private void btNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= lvLocationList.Items.Count - 1; i++)
            {
                ListViewItem oItem = lvLocationList.Items[i];
                oItem.SubItems[1].Text = string.Empty;
            }
        }
        #endregion

        #region Select Data Column(Type)
        private string SelectedDataType()
        {
            StringBuilder selectType = new StringBuilder();

            if (chkREC.Checked)
            {
                selectType.Append("REC" + ",");
            }
            if (chkCAP.Checked)
            {
                selectType.Append("CAP" + ",");
            }
            if (chkREJ.Checked)
            {
                selectType.Append("REJ" + ",");
            }
            if (chkSAL.Checked)
            {
                selectType.Append("SAL,SRT" + ",");
            }
            if (chkADJ.Checked)
            {
                selectType.Append("ADJ" + ",");
            }
            if (chkRetail.Checked)
            {
                selectType.Append("CRT,CAS,VOD" + ",");
            }
            if (chkTXI.Checked)
            {
                selectType.Append("TXI,TRI" + ",");
            }
            if (chkTXO.Checked)
            {
                selectType.Append("TXO,TRO" + ",");
            }

            return selectType.ToString().Trim(',');
        }
        #endregion

        #region Properties
        private int ForYear
        {
            get
            {
                return int.Parse(txtForMonth.Text.Substring(0, 4));
            }
        }

        private int ForMonth
        {
            get
            {
                return int.Parse(txtForMonth.Text.Substring(4, 2));
            }
        }
        #endregion

        private void txtForMonth_TextChanged(object sender, EventArgs e)
        {
            dtDateFrom.Value = new DateTime(ForYear, ForMonth, 1);
            dtDateTo.Value = new DateTime(ForYear, ForMonth, DateTime.DaysInMonth(ForYear, ForMonth));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            #region Procedure Parameters
            SqlParameter[] obj = {
             new SqlParameter("@fromSTKCODE",cboSTKCodeFrom.Text.Trim()),
             new SqlParameter("@toSTKCODE",cboSTKCodeTo.Text.Trim()),
             new SqlParameter("@fromDate",dtDateFrom.Value),
             new SqlParameter("@toDate",dtDateTo.Value),
             new SqlParameter("@SelectedWorkplaceCode",SelectedWorkplaceCodeList().Replace("'","")),
             new SqlParameter("@SelectedTYPE",SelectedDataType()),
             new SqlParameter("@ShowSkipZeroQty",chkSkipZeroQty.Checked),
             new SqlParameter("@ShowReCalculatedCD",chkReCalulated.Checked)
            };
            #endregion

            RT2020.Controls.Reporting.Viewer view=new RT2020.Controls.Reporting.Viewer();

            if (String.Compare(txtForMonth.Text, currentDate) >= 0)
            {
                view.Datasource = SqlHelper.Default.ExecuteDataSet("apStockInOutSummary_CurrentMonth", obj).Tables[0];
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apStockInOutSummary_CurrentMonth";


                if (rbStkAndLoc.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_SummaryStkAndLocRdl.rdlc";
                }
                else if (rbStk.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_SummaryStkRdl.rdlc";
                }
                else if (rbLoction.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_SummaryLocRdl.rdlc";
                }

            }
            else
            {
                view.Datasource = SqlHelper.Default.ExecuteDataSet("apStockInOutSummary_HistoryMonth", obj).Tables[0];
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apStockInOutSummary_HistoryMonth";

                if (rbStkAndLoc.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_HisSummaryStkAndLocRdl.rdlc";
                }
                else if (rbStk.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_HisSummaryStkRdl.rdlc";
                }
                else if (rbLoction.Checked)
                {
                    view.ReportName = "RT2020.Inventory.Reports.History.InOutHistory_HisSummaryLocRdl.rdlc";
                }

            }

            string[,] param = {
            {"STKCODEFrom",this.cboSTKCodeFrom.Text.Trim()},
            {"STKCODETo",this.cboSTKCodeTo.Text.Trim()},
            {"FromDate",dtDateFrom.Value.ToString(DateTimeHelper.GetDateFormat())},
            {"ToDate",dtDateTo.Value.ToString(DateTimeHelper.GetDateFormat())},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {"CalculatedCD",chkReCalulated.Checked.ToString()},
            {"Locations",this.SelectedWorkplaceCodeList()},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

            view.Parameters = param;

            view.Show();
        }
    }
}