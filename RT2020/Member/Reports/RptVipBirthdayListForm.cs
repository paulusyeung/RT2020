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
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Member.Reports
{
    //public partial class RptVipBirthdayListForm : Form, IGatewayControl
    public partial class RptVipBirthdayListForm : Form
    {
        public RptVipBirthdayListForm()
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

            string fromDay = dtpFromBirthday.Value.Day.ToString();
            string fromMonth = dtpFromBirthday.Value.Month.ToString();
            string toDay = dtpToBirthday.Value.Day.ToString();
            string toMonth = dtpToBirthday.Value.Month.ToString();

            string sql = @"
SELECT *, SUBSTRING(DateOfBirth, 6, LEN(DateOfBirth) - 4) AS Birthday, FirstName + ',' + LastName AS FullName
 FROM dbo.vwVIP_MemberList 
WHERE VipNumber BETWEEN '" + from + @"' AND '" + to + @"'
 AND DatePart(MM, DateOfBirth) >= " + fromMonth + @" AND  DatePart(MM, DateOfBirth) <= " + toMonth + @" 
 ORDER BY Birthday";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

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
        //        VipBirthdayListRpt_Pdf report = new VipBirthdayListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromBirthday.Value.Date.ToString("dd/MM");
        //        report.ToDate = dtpToBirthday.Value.Date.ToString("dd/MM");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP Birthday List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        VipBirthdayListRpt_Xls report = new VipBirthdayListRpt_Xls();

        //        report.DataSource = BindData();
        //        report.FromCode = cmbFrom.Text.Trim();
        //        report.ToCode = cmbTo.Text.Trim();
        //        report.FromDate = dtpFromBirthday.Value.Date.ToString("dd/MM");
        //        report.ToDate = dtpToBirthday.Value.Date.ToString("dd/MM");

        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=VIP Birthday List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        VipBirthdayListRpt_Pdf rpt = new VipBirthdayListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FromCode = cmbFrom.Text.Trim();
        //            rpt.ToCode = cmbTo.Text.Trim();
        //            rpt.FromDate = dtpFromBirthday.Value.Date.ToString("dd/MM");
        //            rpt.ToDate = dtpToBirthday.Value.Date.ToString("dd/MM");
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
            {"FromBirthday",this.dtpFromBirthday.Value.ToString("dd/MM")},
            {"ToBirthday",this.dtpToBirthday.Value.ToString("dd/MM")},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_MemberList";
            view.ReportName = "RT2020.Member.Reports.VipBirthdayListRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }
    }
}