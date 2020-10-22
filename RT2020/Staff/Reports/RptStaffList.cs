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
using System.Configuration;
#endregion

namespace RT2020.Staff.Reports
{
    //public partial class RptStaffList : Form, IGatewayControl
    public partial class RptStaffList : Form
    {
        public RptStaffList()
        {
            InitializeComponent();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            RT2020.DAL.Staff.LoadCombo(ref cmbFrmStaffCode, new string[] { "StaffNumber", "FullName" }, "{0} - {1}", false, false, string.Empty, string.Empty, null);

            RT2020.DAL.Staff.LoadCombo(ref cmbToStaffCode, new string[] { "StaffNumber", "FullName" }, "{0} - {1}", false, false, string.Empty, string.Empty, null);

            cmbToStaffCode.SelectedIndex = cmbToStaffCode.Items.Count - 1;
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmStaffCode = cmbFrmStaffCode.Text.Trim().Substring(0, 4);
            string toStaffCode = cmbToStaffCode.Text.Trim().Substring(0, 4);
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmStaff", frmStaffCode), new SqlParameter("@toStaff", toStaffCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apStaffList";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }

        }
        #endregion

        //#region IGatewayControl Members

        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    // Create a report instance.
        //    if (rbnPDF.Checked == true)
        //    {
        //        RT2020.Staff.Reports.StaffListRpt_Pdf report = new StaffListRpt_Pdf();
        //        report.DataSource = BindData();
        //        report.FrmCode = cmbFrmStaffCode.Text.Remove(cmbFrmStaffCode.Text.IndexOf('-')).Trim();
        //        report.toCode = cmbToStaffCode.Text.Remove(cmbToStaffCode.Text.IndexOf('-')).Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=Staff List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Staff.Reports.StaffListRpt_Xls reportc = new StaffListRpt_Xls();
        //        reportc.DataSource = BindData();
        //        reportc.FrmCode = cmbFrmStaffCode.Text.Trim();
        //        reportc.toCode = cmbToStaffCode.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        reportc.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=Staff List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Staff.Reports.StaffListRpt_Pdf rpt = new StaffListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FrmCode = cmbFrmStaffCode.Text.Trim();
        //            rpt.toCode = cmbToStaffCode.Text.Trim();
        //            rpt.PrintDialog();
        //            rpt.Print();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //        return null;
        //    }
        //}

        //#endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void frmStaffList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrmStaffCode.Text.CompareTo(cmbToStaffCode.Text) <= 0)
            {
                string[,] param = {
            {"FromStaffCode",this.cmbFrmStaffCode.Text.Trim().Substring(0,4)},
            {"ToStaffCode",this.cmbToStaffCode.Text.Trim().Substring(0,4)},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"DateFormat",RT2020.SystemInfo.Settings.GetDateTimeFormat()},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apStaffList";
                view.ReportName = "RT2020.Staff.Reports.StaffListRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
            else
            {
                MessageBox.Show("Out of range!", "ATTENTION");
            }
        }
    }
}