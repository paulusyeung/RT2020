////RT2020.Purchasing.Reports.Others
////RT2020.Purchasing.Reports.Others
namespace RT2020.Purchasing.Reports.Others
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;

    /// <summary>
    /// Remarks class
    /// </summary>
    public partial class Remarks : Form, IGatewayComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Remarks"/> class.
        /// </summary>
        public Remarks()
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

            string[] orderBy = { "RemarkCode" };

            RT2020.DAL.RemarksCollection remarksCol = RT2020.DAL.Remarks.LoadCollection(orderBy, true);
            cboFrom.DataSource = remarksCol;
            cboFrom.DisplayMember = "RemarkCode";
            cboFrom.ValueMember = "RemarkId";
        }

        /// <summary>
        /// Fills OrderNumber To
        /// </summary>
        private void FillToList()
        {
            cboTo.Items.Clear();

            string[] orderBy = { "RemarkCode" };

            RT2020.DAL.RemarksCollection remarksCol = RT2020.DAL.Remarks.LoadCollection(orderBy, true);
            cboTo.DataSource = remarksCol;
            cboTo.DisplayMember = "RemarkCode";
            cboTo.ValueMember = "RemarkId";

            cboTo.SelectedIndex = remarksCol.Count - 1;
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
                { "FromCode", this.cboFrom.Text.Trim() },
                { "ToCode", this.cboTo.Text.Trim() },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") } ////test data
             };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.Others.Reports.PORemarkRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_Remarks";
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
                { "FromCode", this.cboFrom.Text.Trim() },
                { "ToCode", this.cboTo.Text.Trim() },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") } ////test data
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Reports.Others.Reports.PORemarkRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_Remarks";
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
        /// <c>true</c> if [is sel valid] [the specified range name]; otherwise, <c>false</c>.
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
FROM Remarks
WHERE	RemarkCode BETWEEN '" + this.cboFrom.Text.Trim() + @"' AND '" + this.cboTo.Text.Trim() + @"'
ORDER BY RemarkCode
";

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
            if (this.IsSelValid("Remark Code"))
            {
                string[,] param = 
                {
                    { "FromCode", this.cboFrom.Text.Trim() },
                    { "ToCode", this.cboTo.Text.Trim() },
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "Company", RT2020.SystemInfo.CurrentInfo.Default.CompanyName }
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();

                rptViewer.Datasource = this.BindData();
                rptViewer.ReportName = "RT2020.Purchasing.Reports.Others.Reports.PORemarkRdl.rdlc";
                rptViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_Remarks";
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
            if (this.IsSelValid("Remark Code"))
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
            if (this.IsSelValid("Remark Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlPDF"));
            }
        }      
    }
}