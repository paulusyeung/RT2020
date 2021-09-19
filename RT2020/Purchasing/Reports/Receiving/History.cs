////RT2020.Purchasing.Reports.Receiving
namespace RT2020.Purchasing.Reports.Receiving
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Web;

    using FileHelpers.DataLink;
    using FileHelpers.MasterDetail;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Forms;


    using System.Linq;
    using System.Data.Entity;
    using RT2020.Common.Helper;
    using RT2020.Common.ModelEx;

    /// <summary>
    /// Receiving History
    /// </summary>
    public partial class History : Form, IGatewayComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class.
        /// </summary>
        public History()
        {
            this.InitializeComponent();
            this.FillComboList();
        }

        #region Fill Combo List
        /// <summary>
        /// Fills the combo list.
        /// </summary>
        private void FillComboList()
        {
            this.FillFromList();
            this.FillToList();
        }

        /// <summary>
        /// Fills OrderNumber From
        /// </summary>
        private void FillFromList()
        {
            cboFrom.Items.Clear();

            //string[] orderBy = { "TxNumber" };
            //string sql = " Retired = 0 ";

            using (var ctx = new EF6.RT2020Entities())
            {
                var purchaseOrderReceiveList = ctx.PurchaseOrderReceiveHeader.Where(x => !x.Retired).OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                //PurchaseOrderReceiveHeaderCollection purchaseOrderReceiveList = PurchaseOrderReceiveHeader.LoadCollection(sql, orderBy, true);
                if (purchaseOrderReceiveList.Count > 0)
                {
                    cboFrom.DataSource = purchaseOrderReceiveList;
                    cboFrom.DisplayMember = "TxNumber";
                    cboFrom.ValueMember = "ReceiveHeaderId";
                }
                else
                {
                    cboFrom.Text = "** No Record **";
                    cmdExcel.Enabled = false;
                    cmdPDF.Enabled = false;
                    cmdPreview.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Fills OrderNumber To
        /// </summary>
        private void FillToList()
        {
            cboTo.Items.Clear();

            //string[] orderBy = { "TxNumber" };
            //string sql = " Retired = 0 ";

            using (var ctx = new EF6.RT2020Entities())
            {
                var purchaseOrderReceiveList = ctx.PurchaseOrderReceiveHeader.Where(x => !x.Retired).OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                //PurchaseOrderReceiveHeaderCollection purchaseOrderReceiveList = PurchaseOrderReceiveHeader.LoadCollection(sql, orderBy, true);
                if (purchaseOrderReceiveList.Count > 0)
                {
                    cboTo.DataSource = purchaseOrderReceiveList;
                    cboTo.DisplayMember = "TxNumber";
                    cboTo.ValueMember = "ReceiveHeaderId";

                    cboTo.SelectedIndex = purchaseOrderReceiveList.Count - 1;
                }
                else
                {
                    cboTo.Text = "** No Record **";
                    cmdExcel.Enabled = false;
                    cmdPDF.Enabled = false;
                    cmdPreview.Enabled = false;
                }
            }
        }

        #endregion


        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            switch (strAction)
            {
                case "rdlExcel":
                    this.RdlToExcel();
                    break;
                case "rdlPDF":
                    this.RdlToPdf();
                    break;
            }
        }

        /// <summary>
        /// RDLs to excel.
        /// </summary>
        private void RdlToExcel()
        {
            string[,] param = 
            {
                { "FromTxNumber", this.cboFrom.Text.Trim() },
                { "ToTxNumber", this.cboTo.Text.Trim() },
                { "FromDate", this.dtpDateFrom.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "ToDate", this.dtpDateTo.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat()) },
                { "PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat()) },
                { "STKCODE", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", SystemInfoHelper.Settings.GetSystemLabelByKey("Company") }, ////test
                { "DateFormat", DateTimeHelper.GetDateFormat() }
             };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.Receiving.Reports.ReceivingHistoryRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderReceive";
            rdlExport.Parameters = param;

            rdlExport.ToExcel();
        }

        /// <summary>
        /// RDLs to PDF.
        /// </summary>
        private void RdlToPdf()
        {
            string[,] param = 
            {
                { "FromTxNumber", this.cboFrom.Text.Trim() },
                { "ToTxNumber", this.cboTo.Text.Trim() },
                { "FromDate", this.dtpDateFrom.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "ToDate", this.dtpDateTo.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat()) },
                { "STKCODE", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", SystemInfoHelper.Settings.GetSystemLabelByKey("Company") }, ////test
                { "DateFormat", DateTimeHelper.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.Receiving.Reports.ReceivingHistoryRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderReceive";
            rdlExport.Parameters = param;

            rdlExport.ToPdf();
        }

        #endregion

        #region Validate Selections
        /// <summary>
        /// Determines whether [is sel valid] [the specified range name].
        /// </summary>
        /// <param name="rangeName">Name of the range.</param>
        /// <returns>
        /// 	<c>true</c> if [is sel valid] [the specified range name]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSelValid(string rangeName)
        {
            bool result = true;

            if (String.Compare(cboTo.Text.Trim(), cboFrom.Text.Trim()) < 0)
            {
                // cboTo < cboFrom
                result = false;
                string errorStr = "Range Error: " + rangeName;
                MessageBox.Show(errorStr, "Message");
            }
            else if (dtpDateTo.Value < dtpDateFrom.Value)
            {
                // dtpTxDateTo < dtpDateFrom
                result = false;
                MessageBox.Show("Range Error: Date", "Message");
            }

            return result;
        }
        #endregion

        #region Bind data to report
        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <returns>A DataTable object</returns>
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptPurchaseOrderReceive
WHERE	TxNumber BETWEEN '" + this.cboFrom.Text.Trim() + @"' AND '" + this.cboTo.Text.Trim() + @"' AND
        TxDate BETWEEN '" + this.dtpDateFrom.Value.ToString("MM/dd/yyyy 00:00:00") + @"' AND '" + this.dtpDateTo.Value.ToString("MM/dd/yyyy 23:23:59") + @"'
 AND PostedOn != '1900-01-01 00:00:00' AND (PostedBy IS NOT NULL OR PostedBy != '00000000-0000-0000-0000-000000000000') ORDER BY TxNumber, TxDate";

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

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        /// <summary>
        /// Handles the Click event of the cmdPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdPreview_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Order Number"))
            {
                string[,] param = 
                {
                    { "FromTxNumber", this.cboFrom.Text.Trim() },
                    { "ToTxNumber", this.cboTo.Text.Trim() },
                    { "FromDate", this.dtpDateFrom.Value.ToString(DateTimeHelper.GetDateFormat()) },
                    { "ToDate", this.dtpDateTo.Value.ToString(DateTimeHelper.GetDateFormat()) },
                    { "PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat()) },
                    { "STKCODE", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                    { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "Company", SystemInfoEx.CurrentInfo.Default.CompanyName }, 
                    { "DateFormat", DateTimeHelper.GetDateFormat() }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindData();
                rptViewer.ReportName = "RT2020.Purchasing.Reports.Receiving.Reports.ReceivingHistoryRdl.rdlc";
                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderReceive";
                rptViewer.Parameters = param;

                rptViewer.Show();
            }
        }
       
        /// <summary>
        /// Handles the Click event of the cmdExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Order Number"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlExcel"));
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdPDF control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdPDF_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Order Number"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlPDF"));
            }
        }
    }
}