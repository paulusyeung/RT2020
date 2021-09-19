using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using FileHelpers.DataLink;
using FileHelpers.MasterDetail;


using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

namespace RT2020.Inventory.Transfer.Reports
{
    //public partial class WorksheetWizard : Form, IGatewayControl
    public partial class WorksheetWizard : Form
    {
        //MasterDetails[] md;

        public WorksheetWizard()
        {
            InitializeComponent();
            FillComboList();

            dtpTxDateFrom.Value = Convert.ToDateTime(SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-01"));
            dtpTxDateTo.Value = DateTime.Now;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            FillFromList();
            FillToList();
        }

        private void FillFromList()
        {
            InvtBatchTXF_HeaderEx.LoadCombo(ref cboFrom, "TxNumber", false);
            /**
            cboFrom.Items.Clear();

            string[] orderBy = { "TxNumber" };
            //string sql = "TxType = '" + EnumHelper.TxType.TXF.ToString() + "'";

            //InvtBatchTXF_HeaderCollection headerList = InvtBatchTXF_Header.LoadCollection(sql, orderBy, true);
            InvtBatchTXF_HeaderCollection headerList = InvtBatchTXF_Header.LoadCollection(orderBy, true);
            cboFrom.DataSource = headerList;
            cboFrom.DisplayMember = "TxNumber";
            cboFrom.ValueMember = "HeaderId";
            */
        }

        private void FillToList()
        {
            InvtBatchTXF_HeaderEx.LoadCombo(ref cboTo, "TxNumber", false);
            /**
            cboTo.Items.Clear();

            string[] orderBy = { "TxNumber" };
            //string sql = "TxType = '" + EnumHelper.TxType.TXF.ToString() + "'";

            //InvtBatchTXF_HeaderCollection headerList = InvtBatchTXF_Header.LoadCollection(sql, orderBy, true);
            InvtBatchTXF_HeaderCollection headerList = InvtBatchTXF_Header.LoadCollection(orderBy, true);
            cboTo.DataSource = headerList;
            cboTo.DisplayMember = "TxNumber";
            cboTo.ValueMember = "HeaderId";
            */
            cboTo.SelectedIndex = cboTo.Items.Count - 1;
        }
        #endregion

        #region IGatewayControl Members
        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    DataTable dt = Reports.DataSource.Worksheet(this.cboFrom.Text, this.cboTo.Text, this.dtpTxDateFrom.Value, this.dtpTxDateTo.Value);

        //    string filename = cboFrom.Text.Trim() + ".pdf";

        //    RT2020.Inventory.Transfer.Reports.WorksheetRpt report = new RT2020.Inventory.Transfer.Reports.WorksheetRpt();
        //    report.DataSource = dt;
        //    report.TxNumberFrom = this.cboFrom.Text.Trim();
        //    report.TxNumberTo = this.cboTo.Text.Trim();
        //    report.TxDateFrom = this.dtpTxDateFrom.Value;
        //    report.TxDateTo = this.dtpTxDateTo.Value;
        //    HttpResponse objResponse = this.Context.HttpContext.Response;

        //    System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //    objResponse.Clear();
        //    objResponse.ClearHeaders();

        //    report.ExportToPdf(memStream);
        //    objResponse.ContentType = "application/pdf";
        //    objResponse.AddHeader("content-disposition", "attachment; filename=" + filename);
        //    objResponse.BinaryWrite(memStream.ToArray());
        //    objResponse.Flush();
        //    objResponse.End();

        //    return null;
        //}
        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;

            if (String.Compare(cboTo.Text.Trim(), cboFrom.Text.Trim()) < 0)     // cboTo < cboFrom
            {
                result = false;
                MessageBox.Show("Range Error: Tx Number", "Message");
            }
            else if (dtpTxDateTo.Value < dtpTxDateFrom.Value)                   // dtpTxDateTo < dtpTxDateFrom
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            //if (IsSelValid())
            //{
            //    Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
            //}
        }

        #region BindData
        private DataTable BindData()
        {
            string sql = @"SELECT TOP 100 PERCENT *
                          FROM vwRptBatchTXF
                          WHERE	TxNumber BETWEEN '" + this.cboFrom.Text.Trim() + @"' AND '" + this.cboTo.Text.Trim() + @"' 
                          AND CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") + @"' 
                                                                        AND '" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd") + @"'
                          ORDER BY STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                RT2020.Controls.Reporting.Viewer viewer = new RT2020.Controls.Reporting.Viewer();

                string[,] param = {
                    {"FromToTxNumber",this.cboFrom.Text.Trim()},
                    {"ToTxNumber",this.cboTo.Text.Trim()},
                    {"FromTxDate",this.dtpTxDateFrom.Value.ToString(DateTimeHelper.GetDateFormat())},
                    {"ToTxDate",this.dtpTxDateTo.Value.ToString(DateTimeHelper.GetDateFormat())},
                    {"PrintedBy",StaffEx.GetStaffNameById(ConfigHelper.CurrentUserId) },
                    {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateFormat())},
                    {"DateFormat",DateTimeHelper.GetDateFormat()},
                    {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName},
                    { "StockCode", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                    { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

                viewer.Datasource = BindData();
                viewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptBatchTXF";
                viewer.ReportName = "RT2020.Inventory.Transfer.Reports.WorksheetRdl.rdlc";
                viewer.Parameters = param;
                viewer.Show();
            }
        }

    }
}