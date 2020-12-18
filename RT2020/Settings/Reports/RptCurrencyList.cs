#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using DevExpress.XtraReports.UI;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;
using RT2020.DAL;
using RT2020.Settings;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;


#endregion

namespace RT2020.Settings.Reports
{
    public partial class RptCurrencyList : Form, IGatewayComponent
    {
        public RptCurrencyList()
        {
            InitializeComponent();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Currency.OrderBy(x => x.CurrencyCode).AsNoTracking().ToList();
                foreach (var cny in list)
                {
                    var item = new System.Web.UI.WebControls.ListItem(cny.CurrencyCode, cny.CurrencyId.ToString());
                    cmbFrmCurrencyCode.Items.Add(item);
                    cmbToCurrencyCode.Items.Add(item);
                }

                cmbFrmCurrencyCode.SelectedIndex = 0;
                cmbToCurrencyCode.SelectedIndex = list.Count - 1;
            }
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = cmbFrmCurrencyCode.Text.Trim();
            string toCode = cmbToCurrencyCode.Text.Trim();

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmCurrencyCode", frmCode), new SqlParameter("@toCurrencyCode", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apCurrencyList";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
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

            // Create a report instance.
            if (rbnPDF.Checked == true)
            {
                RT2020.Settings.Reports.CurrencyListRpt_Pdf report = new RT2020.Settings.Reports.CurrencyListRpt_Pdf();

                report.DataSource = BindData();
                report.FrmCode = cmbFrmCurrencyCode.Text.Trim();
                report.toCode = cmbToCurrencyCode.Text.Trim();
                HttpResponse objResponse = this.Context.HttpContext.Response;

                System.IO.MemoryStream memStream = new System.IO.MemoryStream();

                objResponse.Clear();
                objResponse.ClearHeaders();
                report.ExportToPdf(memStream);
                objResponse.ContentType = "application/pdf";
                objResponse.AddHeader("content-disposition", "attachment; filename=Currency List.pdf");
                objResponse.BinaryWrite(memStream.ToArray());
                objResponse.Flush();
                objResponse.End();

            }
            else if (rbnXLS.Checked)
            {
                RT2020.Settings.Reports.CurrencyListRpt_Xls reportc = new RT2020.Settings.Reports.CurrencyListRpt_Xls();

                reportc.DataSource = BindData();
                reportc.FrmCode = cmbFrmCurrencyCode.Text.Trim();
                reportc.toCode = cmbToCurrencyCode.Text.Trim();
                HttpResponse objResponse = this.Context.HttpContext.Response;

                System.IO.MemoryStream memStream = new System.IO.MemoryStream();

                objResponse.Clear();
                objResponse.ClearHeaders();
                reportc.ExportToXls(memStream);
                objResponse.ContentType = "application/xls";
                objResponse.AddHeader("content-disposition", "attachment; filename=Currency List.xls");
                objResponse.BinaryWrite(memStream.ToArray());
                objResponse.Flush();
                objResponse.End();
            }
            else
            {
                RT2020.Settings.Reports.CurrencyListRpt_Pdf rpt = new CurrencyListRpt_Pdf();
                try
                {
                    rpt.DataSource = BindData();
                    rpt.FrmCode = cmbFrmCurrencyCode.Text.Trim();
                    rpt.toCode = cmbToCurrencyCode.Text.Trim();
                    rpt.PrintDialog();
                    rpt.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void RptCurrencyList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"FromCurrencyCode",this.cmbFrmCurrencyCode.Text.Trim()},
            {"ToCurrencyCode",this.cmbToCurrencyCode.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apCurrencyList";
            view.ReportName = "RT2020.Settings.Reports.CurrencyListRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }

    }
}