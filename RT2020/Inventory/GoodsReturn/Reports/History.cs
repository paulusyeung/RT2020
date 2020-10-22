using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
using System.Web;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using FileHelpers.DataLink;
using FileHelpers.MasterDetail;

using RT2020.DAL;
using System.Configuration;

namespace RT2020.Inventory.GoodsReturn.Reports
{
    // Carrie 29-09-2008 : Remove IGatewayControl
    //public partial class HistoryWizard : Form, IGatewayControl
    public partial class HistoryWizard : Form
    {
        private string _TxNumberFrom = "00";
        private string _TxNumberTo = "zz";

        public HistoryWizard()
        {
            InitializeComponent();

            dtpTxDateFrom.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.LastMonthEnd.Insert(4, "-") + "-01");
            dtpTxDateTo.Value = DateTime.Now;

            RT2020.Controls.InvtUtility.ShowCriteria(ref txtTxNumberFrom, ref txtTxNumberTo, "vwRptSubLedgerCAP", Common.Enums.TxType.REJ, dtpTxDateFrom.Value, dtpTxDateTo.Value);
        }

        #region IGatewayControl Members // Carrie 29-09-2008 : Buttom removed (Function is not available)
        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    switch (strAction)
        //    {
        //        case "xPdf":
        //            XtraReportToPdf();
        //            break;
        //        case "rdlExcel":
        //            RdlToExcel();
        //            break;
        //        case "rdlPDF":
        //            RdlToPdf();
        //            break;
        //    }

        //    return null;
        //}

        //private void XtraReportToPdf()
        //{
        //    DataTable dt = Reports.DataSource.History(_TxNumberFrom, _TxNumberTo, this.dtpTxDateFrom.Value, this.dtpTxDateTo.Value);

        //    string filename = _TxNumberFrom + ".pdf";

        //    RT2020.Inventory.GoodsReturn.Reports.HistoryRpt report = new RT2020.Inventory.GoodsReturn.Reports.HistoryRpt();
        //    report.DataSource = dt;
        //    report.TxNumberFrom = this._TxNumberFrom;
        //    report.TxNumberTo = this._TxNumberTo;
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
        //}

        //private void RdlToExcel()
        //{
        //    RT2020.DAL.Staff curUser = RT2020.DAL.Staff.Load(Common.Config.CurrentUserId);
        //    string[,] param = {
        //        { "FromTxNumber", this.txtTxNumberFrom.Text.Trim() },
        //        { "ToTxNumber", this.txtTxNumberTo.Text.Trim() },
        //        { "FromTxDate", this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
        //        { "ToTxDate", this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
        //        { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
        //        { "PrintedBy", curUser.FullName },
        //        { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
        //        { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
        //        { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
        //        { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
        //        { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
        //        };

        //    RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

        //    rdlExport.Datasource = BindData();
        //    rdlExport.ReportName = "RT2020.Inventory.GoodsReturn.Reports.HistoryRdl.rdlc";
        //    rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptSubLedgerCAP";
        //    rdlExport.Parameters = param;

        //    rdlExport.ToExcel();
        //}

        //private void RdlToPdf()
        //{
        //    RT2020.DAL.Staff curUser = RT2020.DAL.Staff.Load(Common.Config.CurrentUserId);
        //    string[,] param = {
        //        { "FromTxNumber", this.txtTxNumberFrom.Text.Trim() },
        //        { "ToTxNumber", this.txtTxNumberTo.Text.Trim() },
        //        { "FromTxDate", this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
        //        { "ToTxDate", this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
        //        { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
        //        { "PrintedBy", curUser.FullName },
        //        { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
        //        { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
        //        { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
        //        { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
        //        { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
        //        };

        //    RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

        //    rdlExport.Datasource = BindData();
        //    rdlExport.ReportName = "RT2020.Inventory.GoodsReturn.Reports.HistoryRdl.rdlc";
        //    rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptSubLedgerCAP";
        //    rdlExport.Parameters = param;

        //    rdlExport.ToPdf();
        //}
        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;

            if (this.txtTxNumberFrom.Text.Trim() != String.Empty)
            {
                _TxNumberFrom = this.txtTxNumberFrom.Text.Trim();
            }
            if (this.txtTxNumberTo.Text.Trim() != String.Empty)
            {
                _TxNumberTo = this.txtTxNumberTo.Text.Trim();
            }

            if (String.Compare(_TxNumberTo, _TxNumberFrom) < 0)                 // _TxNumberTo < _TxNumberFrom
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

        #region Bind data to report
        private DataTable BindData()
        {
            string sql =  @"SELECT TOP 100 PERCENT * FROM vwRptSubLedgerCAP
                            WHERE TxNumber >= '" + this.txtTxNumberFrom.Text.Trim() + @"' AND TxNumber <= '" + this.txtTxNumberTo.Text.Trim() 
                        + @"' AND TxDate >= '" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd") 
                        + @"' AND TxDate <= '" + this.dtpTxDateTo.Value.AddDays(1).ToString("yyyy-MM-dd") 
                        + @"' AND TxType = '" + Common.Enums.TxType.REJ.ToString()
                        + @"' ORDER BY TxNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ";
            return SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Carrie 29-09-2008 : Buttom removed (Function is not available)
            //if (IsSelValid())
            //{
            //    Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "xPdf"));
            //}
        }

        private void cmdPDF_Click(object sender, EventArgs e)
        {
            // Carrie 29-09-2008 : Buttom removed (Function is not available)
            //if (IsSelValid())
            //{
            //    Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlPDF"));
            //}
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            // Carrie 29-09-2008 : Buttom removed (Function is not available)
            //if (IsSelValid())
            //{
            //    Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlExcel"));
            //}
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                RT2020.DAL.Staff curUser = RT2020.DAL.Staff.Load(Common.Config.CurrentUserId);
                string[,] param = {
                { "FromTxNumber", this.txtTxNumberFrom.Text.Trim() },
                { "ToTxNumber", this.txtTxNumberTo.Text.Trim() },
                { "FromTxDate", this.dtpTxDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToTxDate", this.dtpTxDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "PrintedBy", curUser.FullName },
                { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer oViewer = new RT2020.Controls.Reporting.Viewer();

                oViewer.Datasource = BindData();
                oViewer.ReportName = "RT2020.Inventory.GoodsReturn.Reports.HistoryRdl.rdlc";
                oViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptSubLedgerCAP";
                oViewer.Parameters = param;

                oViewer.Show();
            }
        }

        private void btnFindFromTxNumber_Click(object sender, EventArgs e)
        {
            RT2020.Controls.InvtTxSearcher findFromTxNumber = RT2020.Controls.InvtUtility.ShowTxSearcher("vwRptSubLedgerCAP", Common.Enums.TxType.REJ);
            findFromTxNumber.Closed += new EventHandler(findFromTxNumber_Closed);
            findFromTxNumber.ShowDialog();
        }

        void findFromTxNumber_Closed(object sender, EventArgs e)
        {
            RT2020.Controls.InvtTxSearcher findFromTxNumber = sender as RT2020.Controls.InvtTxSearcher;
            if (findFromTxNumber.SelectedTxNumber.Trim().Length > 0)
            {
                txtTxNumberFrom.Text = findFromTxNumber.SelectedTxNumber;
                dtpTxDateFrom.Value = findFromTxNumber.SelectedTxDate;
            }
        }

        private void btnFindToTxNumber_Click(object sender, EventArgs e)
        {
            RT2020.Controls.InvtTxSearcher findToTxNumber = RT2020.Controls.InvtUtility.ShowTxSearcher("vwRptSubLedgerCAP", Common.Enums.TxType.REJ);
            findToTxNumber.Closed += new EventHandler(findToTxNumber_Closed);
            findToTxNumber.ShowDialog();
        }

        void findToTxNumber_Closed(object sender, EventArgs e)
        {
            RT2020.Controls.InvtTxSearcher findToTxNumber = sender as RT2020.Controls.InvtTxSearcher;
            if (findToTxNumber.SelectedTxNumber.Trim().Length > 0)
            {
                txtTxNumberTo.Text = findToTxNumber.SelectedTxNumber;
                dtpTxDateTo.Value = findToTxNumber.SelectedTxDate;
            }
        }
    }
}