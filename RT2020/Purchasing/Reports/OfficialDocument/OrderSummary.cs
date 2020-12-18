////RT2020.Purchasing.Reports.OfficialDocument
namespace RT2020.Purchasing.Reports.OfficialDocument
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
    using System.Collections;
    using System.IO;
    using System.Configuration;
    using Helper;

    /// <summary>
    /// OrderSummary class
    /// </summary>
    public partial class OrderSummary : Form, IGatewayComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSummary"/> class.
        /// </summary>
        public OrderSummary()
        {
            InitializeComponent();

            this.FillCboList();
            this.BindingList(Common.Enums.Status.Draft); //// Holding
        }

        #region Fill Combo List
        /// <summary>
        /// Fills the cbo list.
        /// </summary>
        private void FillCboList()
        {
            this.FillFromList();
            this.FillToList();
            this.cboSortedBy.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the supplier from list.
        /// </summary>
        private void FillFromList()
        {
            string[] orderBy = { "SupplierCode" };
            string sql = " Retired = 0 ";
            ModelEx.SupplierEx.LoadCombo(ref cboFrom, "SupplierCode", false, false, "", sql, orderBy);
        }

        /// <summary>
        /// Fills the supplier to list.
        /// </summary>
        private void FillToList()
        {
            string[] orderBy = { "SupplierCode" };
            string sql = " Retired = 0 ";
            ModelEx.SupplierEx.LoadCombo(ref cboTo, "SupplierCode", false, false, "", sql, orderBy);
            cboTo.SelectedIndex = cboTo.Items.Count - 1;
        }

        #endregion

        #region Bind Methods
        /// <summary>
        /// Datas the source.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="conditions">if set to <c>true</c> [conditions].</param>
        /// <returns>The source</returns>
        private SqlDataReader DataSource(string status, bool conditions)
        {
            string sql = this.BuildSqlQueryString(status, conditions);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            return SqlHelper.Default.ExecuteReader(cmd);
        }

        /// <summary>
        /// Bindings the list.
        /// </summary>
        /// <param name="status">The status.</param>
        private void BindingList(Common.Enums.Status status)
        {
            SqlDataReader reader;
            reader = this.DataSource(Common.Enums.Status.Draft.ToString("d"), false);
            this.BindingHoldingList(reader);
        }

        /// <summary>
        /// Bindings the holding list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingHoldingList(SqlDataReader reader)
        {
            this.lvLocationsList.Items.Clear();

            int iCount = 0;

            while (reader.Read())
            {
                ListViewItem objItem = this.lvLocationsList.Items.Add(reader.GetGuid(0).ToString()); // WorkplaceId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add((iCount + 1).ToString()); //// Line Number
                objItem.SubItems.Add(reader.GetString(1)); //// WorkplaceCode
                objItem.SubItems.Add(reader.GetString(2)); //// WorkplaceInitial

                iCount++;
            }

            if (!reader.IsClosed)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="withConditions">if set to <c>true</c> [with conditions].</param>
        /// <returns>the SQL query string.</returns>
        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT WorkplaceId, WorkplaceCode, WorkplaceInitial ");
            sql.Append(" FROM vwWorkplaceList ");
            ////sql.Append(" WHERE STATUS = ").Append(status);
            sql.Append(" ORDER BY WorkplaceCode");

            return sql.ToString();
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
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") }
             };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();

            if (cboSortedBy.SelectedIndex == 0)
            {
                // SortedBy = Stock Code
                if (cboType.SelectedIndex == 0)
                {
                    ////Type = Active
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActivePhotoMatrixByStockCodeRdl.rdlc";
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixByStockCodeRdl.rdlc";
                    }
                    else
                    {
                    }
                }
                else
                {
                    ////Type = Batch
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchPhotoMatrixByStockCodeRdl.rdlc";
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixByStockCodeRdl.rdlc";
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                // SortedBy = Supplier Number
                if (cboType.SelectedIndex == 0)
                {
                    ////Type = Active
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                    }
                    else
                    {
                    }
                }
                else
                {
                    ////Type = Batch
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                    }
                    else
                    {
                    }
                }
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
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();

            if (cboSortedBy.SelectedIndex == 0)
            {
                // SortedBy = Stock Code
                if (cboType.SelectedIndex == 0)
                {
                    ////Type = Active
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActivePhotoMatrixByStockCodeRdl.rdlc";
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixByStockCodeRdl.rdlc";
                    }
                    else
                    {
                    }
                }
                else
                {
                    ////Type = Batch
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchPhotoMatrixByStockCodeRdl.rdlc";
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                        rdlExport.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixByStockCodeRdl.rdlc";
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                // SortedBy = Supplier Number
                if (cboType.SelectedIndex == 0)
                {
                    ////Type = Active
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                    }
                    else
                    {
                    }
                }
                else
                {
                    ////Type = Batch
                    if (chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo AND Hide APPENDIX2
                    }
                    else if (chkPrintPhoto.Checked && !chkHideAPPENDIX3.Checked)
                    {
                        ////Print out Item Photo
                    }
                    else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                    {
                        ////Hide APPENDIX2
                    }
                    else
                    {
                    }
                }
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
            string locations = string.Empty;
            foreach (ListViewItem objItem in this.lvLocationsList.Items)
            {
                if (objItem.SubItems[1].Text.Contains("*"))
                {
                    if (locations.Length > 0)
                    {
                        locations = locations + "," + "'" + objItem.SubItems[0].Text.ToString() + "'";
                    }
                    else
                    {
                        locations = "'" + objItem.SubItems[0].Text.ToString() + "'";
                    }
                }
            }

            if (locations.Length == 0)
            {
                locations = "'" + System.Guid.Empty.ToString() + "'";
            }

            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptPurchaseOrderDocument
WHERE	SupplierCode BETWEEN '" + this.cboFrom.Text.Trim() + @"' AND '" + this.cboTo.Text.Trim() + @"' AND
        DeliverOn BETWEEN '" + this.dtpDateFrom.Value.ToString("MM/dd/yyyy 00:00:00") + @"' AND '" + this.dtpDateTo.Value.ToString("MM/dd/yyyy 23:23:59") + @"' AND 
WorkplaceId IN (" + locations + ") ";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                DataTable dtblPurchaseOrder = dataset.Tables[0];
                foreach (DataRow row in dtblPurchaseOrder.Rows)
                {
                    //row["POTxType"] = Enum.GetName(typeof(RT2020.DAL.Common.Enums.POType), Convert.ToInt32(row["OrderType"].ToString())).ToString();
                    if (row["Photo"].ToString().Length != 0 && !string.IsNullOrEmpty(Context.Config.GetDirectory("RTImages")))
                    {
                        row["Photo"] = "file:///" + Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), row["Photo"].ToString());
                    }
                    else
                    {
                        //row["Photo"] = "file:///"+Path.Combine(Context.Config.GetDirectory("Images"),"no_Photo.JPG") ;
                        row["Photo"] = "";

                    }
                }

                return dtblPurchaseOrder;
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
            if (this.IsSelValid("Supplier Code"))
            {
                DataTable dt = this.BindData();
                List<string> st = new List<string>();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (!st.Contains(row["OrderNumber"].ToString()))
                    {
                        st.Add(row["OrderNumber"].ToString());
                    }
                }
                for (int i = 0; i < st.Count; i++)
                {
                    sb.Append(st[i].ToString()).Append(",");
                }

                string[,] param = 
                {
                    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                    { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName}, 
                    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                    { "DeliverOn",this.dtpDateFrom.Value.ToString("dd/MM/yyyy")+"-"+this.dtpDateTo.Value.ToString("dd/MM/yyyy")},
                    { "OrderNumber",sb.ToString().Trim(',')}
                };

                RT2020.Controls.Reporting.Viewer rptViewer = new RT2020.Controls.Reporting.Viewer();


                rptViewer.Datasource = this.BindData();

                #region ReportName
                if (cboSortedBy.SelectedIndex == 0)
                {
                    // SortedBy = Stock Code

                    if (cboType.SelectedIndex == 0)
                    {
                        ////Type = Active
                        if (chkPrintPhoto.Checked && (chkHideAPPENDIX3.Checked || !chkHideAPPENDIX3.Checked))
                        {
                            ////Print out Item Photo AND Hide APPENDIX3 
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActivePhotoMatrixByStockCodeRdl.rdlc";
                        }
                        else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                        {
                            ////Hide APPENDIX3
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderActiveMatrixByStockCodeRdl.rdlc";
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        ////Type = Batch
                        if (chkPrintPhoto.Checked && (chkHideAPPENDIX3.Checked || !chkHideAPPENDIX3.Checked))
                        {
                            ////Print out Item Photo AND Hide APPENDIX3
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchPhotoMatrixByStockCodeRdl.rdlc";
                        }

                        else if (!chkPrintPhoto.Checked && chkHideAPPENDIX3.Checked)
                        {
                            ////Hide APPENDIX3
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPurchaseOrderBatchMatrixByStockCodeRdl.rdlc";
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    // SortedBy = Supplier Number


                    if (cboType.SelectedIndex == 0)
                    {
                        ////Type = Active
                        if (chkPrintPhoto.Checked)
                        {
                            ////Print out Item Photo 
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPOSummaryActivePhotoRdl.rdlc";
                        }
                        else
                        {
                            ////Hide Photo
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPOSummaryActiveRdl.rdlc";
                        }

                    }
                    else
                    {
                        ////Type = Batch
                        if (chkPrintPhoto.Checked)
                        {
                            ////Print out Item Photo 
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPOSummaryBatchPhotoRdl.rdlc";
                        }
                        else
                        {
                            ////Hide Photo
                            rptViewer.ReportName = "RT2020.Purchasing.Reports.OfficialDocument.Reports.OfficialPOSummaryBatchRdl.rdlc";
                        }
                    }
                }
                #endregion

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
            if (this.IsSelValid("Supplier Code"))
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
            if (this.IsSelValid("Supplier Code"))
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlPDF"));
            }
        }

        /// <summary>
        /// Handles the Click event of the btnMarkAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            foreach (ListViewItem objItem in this.lvLocationsList.Items)
            {
                if (this.btnMarkAll.Text.Contains("Mark") && !objItem.SubItems[1].Text.Contains("*"))
                {
                    objItem.SubItems[1].Text = "*";
                    iCount++;
                    if (iCount >= 10)
                    {
                        break;
                    }
                }
                else if (this.btnMarkAll.Text.Contains("Unmark"))
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }

            this.Update();

            this.btnMarkAll.Text = (this.btnMarkAll.Text == "Mark All") ? "Unmark All" : "Mark All";
        }

        /// <summary>
        /// Handles the Click event of the lvLocationsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LvLocationsList_Click(object sender, EventArgs e)
        {
            if (this.lvLocationsList.Items != null && this.lvLocationsList.SelectedIndex >= 0)
            {
                int index = this.lvLocationsList.SelectedIndex;
                int iCount = 0;
                bool isSelected = true;

                if (this.lvLocationsList.Items[index].SubItems[1].Text.Length > 0)
                {
                    this.lvLocationsList.Items[index].SubItems[1].Text = string.Empty;
                    isSelected = false;
                }

                foreach (ListViewItem objItem in this.lvLocationsList.Items)
                {
                    if (objItem.SubItems[1].Text.Contains("*"))
                    {
                        this.btnMarkAll.Text = "Unmark All";
                        iCount++;
                    }
                }

                if (iCount == 0)
                {
                    this.btnMarkAll.Text = "Mark All";
                }

                if (isSelected && iCount < 10)
                {
                    this.lvLocationsList.Items[index].SubItems[1].Text = "*";
                    this.btnMarkAll.Text = "Unmark All";
                }

                this.Update();
            }
        }

        private void cboSortedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSortedBy.SelectedIndex == 0)
            {
                chkHideAPPENDIX3.Enabled = true;
            }
            else
            {
                chkHideAPPENDIX3.Enabled = false;
                chkHideAPPENDIX3.Checked = false;
            }
        }
    }

}