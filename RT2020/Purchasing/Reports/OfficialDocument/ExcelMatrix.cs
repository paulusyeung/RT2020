////RT2020.Purchasing.Reports.OfficialDocument
namespace RT2020.Purchasing.Reports.OfficialDocument
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
    /// ExcelMatrix class
    /// </summary>
    public partial class ExcelMatrix : Form, IGatewayComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelMatrix"/> class.
        /// </summary>
        public ExcelMatrix()
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

            string[] orderBy = { "OrderNumber" };
            string sql = " Retired = 0 ";

            ModelEx.PurchaseOrderHeaderEx.LoadCombo(ref cboFrom, "OrderNumber", false, true, "", sql, orderBy);
            if (cboFrom.Items.Count == 1)
            {
                // cboFrom.Text = "** No Record **";
                cmdExcel.Enabled = false;
                cmdPDF.Enabled = false;
                cmdPreview.Enabled = false;
            }
        }

        /// <summary>
        /// Fills OrderNumber To
        /// </summary>
        private void FillToList()
        {
            cboTo.Items.Clear();

            string[] orderBy = { "OrderNumber" };
            string sql = " Retired = 0 ";

            //PurchaseOrderHeaderCollection purchaseOrderList = PurchaseOrderHeader.LoadCollection(sql, orderBy, true);
            ModelEx.PurchaseOrderHeaderEx.LoadCombo(ref cboTo, "OrderNumber", false, true, "", sql, orderBy);
            if (cboTo.Items.Count > 1)
            {
                cboTo.SelectedIndex = cboTo.Items.Count - 1;
            }
            else
            {
                //cboTo.Text = "** No Record **";
                cmdExcel.Enabled = false;
                cmdPDF.Enabled = false;
                cmdPreview.Enabled = false;
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
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "CompanyName", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test data
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
             };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();

            if (rdoActive.Checked)
            {
                rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixRdl.rdlc";
            }
            else
            {
                rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixRdl.rdlc";
            } 
            
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderDocument";
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
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "CompanyName", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test data
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();

            if (rdoActive.Checked)
            {
                rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixRdl.rdlc";
            }
            else
            {
                rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixRdl.rdlc";
            } 
            
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderDocument";
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
FROM vwRptPurchaseOrderDocument
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
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "CompanyName", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test data
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindData();

                if (rdoActive.Checked)
                {
                    rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixRdl.rdlc";
                }
                else
                {
                    rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixRdl.rdlc";
                }

                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrderDocument";
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