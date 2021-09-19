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

using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Member.Reports
{
    //public partial class RptVipExpireListForm : Form, IGatewayControl
    public partial class RptVipExpireListForm : Form
    {
        public RptVipExpireListForm()
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
 AND CONVERT(DateTime, CARD_EXPIRE, 103) >= CONVERT(DateTime, '" + dtpFromExpiryDate.Value.ToString("dd/MM/yyyy") + @"', 103)
 AND CONVERT(DateTime, CARD_EXPIRE, 103) < CONVERT(DateTime, '" + dtpToExpiryDate.Value.AddDays(1).ToString("dd/MM/yyyy") + @"', 103) 
 ORDER BY CARD_EXPIRE";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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
        //        VipExpireListRpt_Pdf report = new VipExpireListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromExpiryDate.Value.Date.ToString("dd/MM/yyyy");
        //        report.ToDate = dtpToExpiryDate.Value.Date.ToString("dd/MM/yyyy");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP Expiry List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        VipExpireListRpt_Xls report = new VipExpireListRpt_Xls();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromExpiryDate.Value.Date.ToString("dd/MM/yyyy");
        //        report.ToDate = dtpToExpiryDate.Value.Date.ToString("dd/MM/yyyy");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP Expiry List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        VipExpireListRpt_Pdf rpt = new VipExpireListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FromCode = cmbFrom.Text.Trim();
        //            rpt.ToCode = cmbTo.Text.Trim();
        //            rpt.FromDate = dtpFromExpiryDate.Value.Date.ToString("dd/MM/yyyy");
        //            rpt.ToDate = dtpToExpiryDate.Value.Date.ToString("dd/MM/yyyy");
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
            //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"FromVIPNO",this.cmbFrom.Text.Trim()},
            {"ToVIPNO",this.cmbTo.Text.Trim()},
            {"FromExpiryDate",this.dtpFromExpiryDate.Value.ToString(DateTimeHelper.GetDateFormat())},
            {"ToExpiryDate",this.dtpToExpiryDate.Value.ToString(DateTimeHelper.GetDateFormat())},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_MemberList";
            view.ReportName = "RT2020.Member.Reports.VipExpireListRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }
    }
}