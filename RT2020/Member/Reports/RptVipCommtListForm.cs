#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using RT2020.DAL;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Member.Reports
{
    //public partial class RptVipCommtListForm : Form, IGatewayControl
    public partial class RptVipCommtListForm : Form
    {
        public RptVipCommtListForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FillComboBox();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Member.OrderBy(x => x.MemberNumber).AsNoTracking().ToList();
                if (list.Count > 0)
                {
                    foreach (var oMember in list)
                    {
                        string item = oMember.MemberNumber + " - " + oMember.FullName;
                        cmbFrom.Items.Add(item);
                        cmbTo.Items.Add(item);
                    }
                    cmbFrom.SelectedIndex = 0;

                    cmbTo.SelectedIndex = list.Count - 1;
                }
            }
        }
        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string from = cmbFrom.Text.Remove(cmbFrom.Text.IndexOf("-")).Trim();
            string to = cmbTo.Text.Remove(cmbTo.Text.IndexOf("-")).Trim() + "z";

            string sql = @"
SELECT *, FirstName + ',' + LastName AS FullName
 FROM dbo.vwVIP_MemberList 
WHERE VipNumber BETWEEN '" + from + @"' AND '" + to + @"'
 AND CONVERT(DateTime, [Date Commence], 103) >= CONVERT(DateTime, '" + dtpFromCommencementDate.Value.ToString("dd/MM/yyyy") + @"', 103)
 AND CONVERT(DateTime, [Date Commence], 103) < CONVERT(DateTime, '" + dtpToCommencementDate.Value.AddDays(1).ToString("dd/MM/yyyy") + @"', 103) 
 ORDER BY [Date Commence]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        //#region IGatewayControl Members

        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    if (rbnPDF.Checked)
        //    {
        //        VipCommencementListRpt_Pdf report = new VipCommencementListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromCommencementDate.Value.Date.ToString("dd/MM/yyyy");
        //        report.ToDate = dtpToCommencementDate.Value.Date.ToString("dd/MM/yyyy");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP CommencementDate List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        VipCommencementListRpt_Xls report = new VipCommencementListRpt_Xls();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromCommencementDate.Value.Date.ToString("dd/MM/yyyy");
        //        report.ToDate = dtpToCommencementDate.Value.Date.ToString("dd/MM/yyyy");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP CommencementDate List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        VipCommencementListRpt_Pdf rpt = new VipCommencementListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FromCode = cmbFrom.Text.Trim();
        //            rpt.ToCode = cmbTo.Text.Trim();
        //            rpt.FromDate = dtpFromCommencementDate.Value.Date.ToString("dd/MM/yyyy");
        //            rpt.ToDate = dtpToCommencementDate.Value.Date.ToString("dd/MM/yyyy");
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
            string[,] param = {
            {"FromVIPNO",this.cmbFrom.Text.Trim()},
            {"ToVIPNO",this.cmbTo.Text.Trim()},
            {"FromCommencementDate",this.dtpFromCommencementDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
            {"ToCommencementDate",this.dtpToCommencementDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_MemberList";
            view.ReportName = "RT2020.Member.Reports.VipCommencementListRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }
    }
}