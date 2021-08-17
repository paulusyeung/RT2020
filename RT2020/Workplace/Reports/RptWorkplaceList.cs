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
using System.Data.Common;
using System.Configuration;
using RT2020.Helper;
using RT2020.ModelEx;

#endregion

namespace RT2020.Workplace.Reports
{
    //public partial class RptWorkplaceList : Form, IGatewayControl
      public partial class RptWorkplaceList : Form
      {
        public RptWorkplaceList()
        {
            InitializeComponent();
        }
       
        #region FillComboBox
        private void FillComboBox()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cmbFrom, "WorkplaceCode", false);
            ModelEx.WorkplaceEx.LoadCombo(ref cmbTo, "WorkplaceCode", false);
            cmbTo.SelectedIndex = cmbTo.Items.Count - 1;
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = cmbFrom.Text.Trim();
            string toCode = cmbTo.Text.Trim();

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmCode", frmCode), new SqlParameter("@toCode", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apWorkplaceList";
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
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
        //        RT2020.Workplace.Reports.WorkplaceListRpt_Pdf report = new RT2020.Workplace.Reports.WorkplaceListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FrmCode = cmbFrom.Text.Trim();
        //        report.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            report.ExportToPdf(memStream);
        //            objResponse.ContentType = "application/pdf";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=Workplace List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Workplace.Reports.WorkplaceListRpt_Xls reportc = new RT2020.Workplace.Reports.WorkplaceListRpt_Xls();

        //        reportc.DataSource = BindData();
        //        reportc.FrmCode = cmbFrom.Text.Trim();
        //        reportc.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            reportc.ExportToXls(memStream);
        //            objResponse.ContentType = "application/xls";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=Workplace List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Workplace.Reports.WorkplaceListRpt_Pdf rpt = new WorkplaceListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FrmCode = cmbFrom.Text.Trim();
        //            rpt.toCode = cmbTo.Text.Trim();
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

        private void frmWorkplaceList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text.CompareTo(cmbTo.Text) <= 0)
            {
                string[,] param = {
            {"FromWorkplaceList",this.cmbFrom.Text.Trim()},
            {"ToWorkplaceList",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apWorkplaceList";
                view.ReportName = "RT2020.Workplace.Reports.WorkplaceListRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
            else
            {
                MessageBox.Show("Wrong range! ", "ATTENTION");
            }
        }  
    }
}