////RT2020.Purchasing.Reports.PurchaseOrder
namespace RT2020.Purchasing.Reports.PurchaseOrder
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

    
    using Helper;

    /// <summary>
    /// Purchase Order Worksheet
    /// </summary>
    public partial class Worksheet : Form, IGatewayComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Worksheet"/> class.
        /// </summary>
        public Worksheet()
        {
            this.InitializeComponent();
            this.FillComboList();
        }

        /// <summary>
        /// Handles the Load event of the Worksheet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Worksheet_Load(object sender, EventArgs e)
        {
            this.mainPanel.Padding = new Padding(6);
        }

        #region Fill Combo List
        /// <summary>
        /// Fills the combo list.
        /// </summary>
        private void FillComboList()
        {
            this.FillSuppFromList();
            this.FillSuppToList();
            this.FillLocFromList();
            this.FillLocToList();
            this.FillFromList();
            this.FillToList();
        }

        /// <summary>
        /// Fills OrderNumber From
        /// </summary>
        private void FillFromList()
        {
            cboFrom.Items.Clear();

            string[] orderBy = { "OrderNumber" };
            string sql = " Retired = 0 ";

            ModelEx.PurchaseOrderHeaderEx.LoadCombo(ref cboFrom, "OrderNumber", false, false, "", sql, orderBy);
        }

        /// <summary>
        /// Fills OrderNumber To
        /// </summary>
        private void FillToList()
        {
            cboTo.Items.Clear();

            string[] orderBy = { "OrderNumber" };
            string sql = " Retired = 0 ";

            ModelEx.PurchaseOrderHeaderEx.LoadCombo(ref cboTo, "OrderNumber", false, false, "", sql, orderBy);

            cboTo.SelectedIndex = cboTo.Items.Count - 1;
        }

        /// <summary>
        /// Fills SupplierCode From
        /// </summary>
        private void FillSuppFromList()
        {
            string[] orderBy = { "SupplierCode" };
            string sql = " Retired = 0";
            ModelEx.SupplierEx.LoadCombo(ref cboSuppFrom, "SupplierCode", false, false, "", sql, orderBy);
        }

        /// <summary>
        /// Fills SupplierNumber To
        /// </summary>
        private void FillSuppToList()
        {
            string[] orderBy = { "SupplierCode" };
            string sql = " Retired = 0";
            ModelEx.SupplierEx.LoadCombo(ref cboSuppTo, "SupplierCode", false, false, "", sql, orderBy);

            cboSuppTo.SelectedIndex = cboSuppTo.Items.Count - 1;
        }

        /// <summary>
        /// Fills Workplace From
        /// </summary>
        private void FillLocFromList()
        {
            string[] orderBy = { "WorkplaceCode" };
            string sql = " Retired = 0";
            ModelEx.WorkplaceEx.LoadCombo(ref cboLocFrom, "WorkplaceCode", false, false, "", sql, orderBy);
        }

        /// <summary>
        /// Fills Workplace To
        /// </summary>
        private void FillLocToList()
        {
            string[] orderBy = { "WorkplaceCode" };
            string sql = " Retired = 0";
            ModelEx.WorkplaceEx.LoadCombo(ref cboLocTo, "WorkplaceCode", false, false, "", sql, orderBy);
            cboLocTo.SelectedIndex = cboLocTo.Items.Count - 1;
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
                case "rdlSuppExcel":
                    this.RdlToSuppExcel();
                    break;
                case "rdlSuppPDF":
                    this.RdlToSuppPdf();
                    break;
                case "rdlLocExcel":
                    this.RdlToLocExcel();
                    break;
                case "rdlLocPDF":
                    this.RdlToLocPdf();
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
                { "FromOrderNumber", this.cboFrom.Text.Trim() },
                { "ToOrderNumber", this.cboTo.Text.Trim() },
                { "FromSelectDate", this.dtpDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToSelectDate", this.dtpDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
             };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
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
                { "FromOrderNumber", this.cboFrom.Text.Trim() },
                { "ToOrderNumber", this.cboTo.Text.Trim() },
                { "FromSelectDate", this.dtpDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToSelectDate", this.dtpDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            rdlExport.Parameters = param;

            rdlExport.ToPdf();
        }

        /// <summary>
        /// RDLs to Supplier excel.
        /// </summary>
        private void RdlToSuppExcel()
        {
            string[,] param = 
            {
                { "FromSupplierCode", this.cboSuppFrom.Text.Trim() },
                { "ToSupplierCode", this.cboSuppTo.Text.Trim() },
                { "FromDate", this.dtpSuppDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToDate", this.dtpSuppDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName },
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindDataSupp();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetSuppRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            rdlExport.Parameters = param;

            rdlExport.ToExcel();
        }

        /// <summary>
        /// RDLs to Supplier PDF.
        /// </summary>
        private void RdlToSuppPdf()
        {
            string[,] param = 
            {
                { "FromSupplierCode", this.cboSuppFrom.Text.Trim() },
                { "ToSupplierCode", this.cboSuppTo.Text.Trim() },
                { "FromDate", this.dtpSuppDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToDate", this.dtpSuppDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindDataSupp();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetSuppRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            rdlExport.Parameters = param;

            rdlExport.ToPdf();
        }

        /// <summary>
        /// RDLs to Location excel.
        /// </summary>
        private void RdlToLocExcel()
        {
            string[,] param = 
            {
                { "FromLocationCode", this.cboLocFrom.Text.Trim() },
                { "ToLocationCode", this.cboLocTo.Text.Trim() },
                { "FromDate", this.dtpLocDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToDate", this.dtpLocDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName},
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindDataLoc();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetLocRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            rdlExport.Parameters = param;

            rdlExport.ToExcel();
        }

        /// <summary>
        /// RDLs to Location PDF.
        /// </summary>
        private void RdlToLocPdf()
        {
            string[,] param = 
            {
                { "FromLocationCode", this.cboLocFrom.Text.Trim() },
                { "ToLocationCode", this.cboLocTo.Text.Trim() },
                { "FromDate", this.dtpLocDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToDate", this.dtpLocDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName },
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindDataLoc();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetLocRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
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
FROM vwRptPurchaseOrder
WHERE	OrderNumber BETWEEN '" + this.cboFrom.Text.Trim() + @"' AND '" + this.cboTo.Text.Trim() + @"' AND
        OrderOn BETWEEN '" + this.dtpDateFrom.Value.ToString("MM/dd/yyyy 00:00:00") + @"' AND '" + this.dtpDateTo.Value.ToString("MM/dd/yyyy 23:23:59") + @"'
ORDER BY OrderNumber, OrderOn
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

        /// <summary>
        /// Binds the data Supplier.
        /// </summary>
        /// <returns>A DataTable object</returns>
        private DataTable BindDataSupp()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptPurchaseOrder
WHERE	SupplierCode BETWEEN '" + this.cboSuppFrom.Text.Trim() + @"' AND '" + this.cboSuppTo.Text.Trim() + @"' AND
        OrderOn BETWEEN '" + this.dtpSuppDateFrom.Value.ToString("MM/dd/yyyy 00:00:00") + @"' AND '" + this.dtpSuppDateTo.Value.ToString("MM/dd/yyyy 23:23:59") + @"'
ORDER BY OrderNumber, OrderOn
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

        /// <summary>
        /// Binds the data Location.
        /// </summary>
        /// <returns>A DataTable object</returns>
        private DataTable BindDataLoc()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptPurchaseOrder
WHERE	WorkplaceCode BETWEEN '" + this.cboLocFrom.Text.Trim() + @"' AND '" + this.cboLocTo.Text.Trim() + @"' AND
        OrderOn BETWEEN '" + this.dtpLocDateFrom.Value.ToString("MM/dd/yyyy 00:00:00") + @"' AND '" + this.dtpLocDateTo.Value.ToString("MM/dd/yyyy 23:23:59") + @"'
ORDER BY OrderNumber, OrderOn
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
        /// Handles the Click event of the btnSuppExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdSuppExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the cmdLocExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdLocExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Preview
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
                    { "FromOrderNumber", this.cboFrom.Text.Trim() },
                    { "ToOrderNumber", this.cboTo.Text.Trim() },
                    { "FromSelectDate", this.dtpDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "ToSelectDate", this.dtpDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindData();
                rptViewer.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetRdl.rdlc";
                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
                rptViewer.Parameters = param;

                rptViewer.Show();
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdSuppPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdSuppPreview_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Supplier Number"))
            {
                string[,] param = 
                {
                    { "FromSupplierCode", this.cboSuppFrom.Text.Trim() },
                    { "ToSupplierCode", this.cboSuppTo.Text.Trim() },
                    { "FromDate", this.dtpSuppDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "ToDate", this.dtpSuppDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindDataSupp();
                rptViewer.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetSuppRdl.rdlc";
                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
                rptViewer.Parameters = param;

                rptViewer.Show();
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdLocPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdLocPreview_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Location Number"))
            {
                string[,] param = 
                {
                    { "FromLocationCode", this.cboLocFrom.Text.Trim() },
                    { "ToLocationCode", this.cboLocTo.Text.Trim() },
                    { "FromDate", this.dtpLocDateFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "ToDate", this.dtpLocDateTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }, 
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindDataLoc();
                rptViewer.ReportName = "RT2020.Purchasing.Reports.PurchaseOrder.Reports.WorksheetLocRdl.rdlc";
                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
                rptViewer.Parameters = param;

                rptViewer.Show();
            }
        }
        #endregion

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

        /// <summary>
        /// Handles the Click event of the cmdSuppExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdSuppExcel_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Supplier Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlSuppExcel"));
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdSuppPDF control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdSuppPDF_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Supplier Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlSuppPDF"));
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdLocExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdLocExcel_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Location Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlLocExcel"));
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdLocPDF control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmdLocPDF_Click(object sender, EventArgs e)
        {
            if (this.IsSelValid("Location Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlLocPDF"));
            }
        }
    }
}