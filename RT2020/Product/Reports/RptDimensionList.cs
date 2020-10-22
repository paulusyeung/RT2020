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

#endregion

namespace RT2020.Product.Reports
{
    //public partial class RptDimensionList : Form, IGatewayControl
    public partial class RptDimensionList : Form
    {
        public RptDimensionList()
        {
            InitializeComponent();
            FillComboBox();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();

            string[] orderBy = new string[] { "DimCode" };
            ProductDimCollection oDimList = ProductDim.LoadCollection(orderBy, true);
            if (oDimList.Count > 0)
            {
                foreach (RT2020.DAL.ProductDim oProductDim in oDimList)
                {
                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(oProductDim.DimCode, oProductDim.DimensionId.ToString());
                    cmbFrom.Items.Add(item);
                    cmbTo.Items.Add(item);
                }
                cmbFrom.SelectedIndex = 0;
               // cmbFrom.DropDownStyle = ComboBoxStyle.DropDownList;

                cmbTo.SelectedIndex = oDimList.Count - 1;
                //cmbTo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = cmbFrom.Text.Trim();
            string toCode = cmbTo.Text.Trim();

            string sql = "SELECT DimCode, Appendix1, Appendix2, Appendix3 FROM vwDimensionList Where DimCode >= '" + frmCode + "' AND DimCode <= '" + toCode + "'";

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
        //    // Create a report instance.
        //    if (rbnPDF.Checked == true)
        //    {
        //        RT2020.Product.Reports.DimensionListRpt_Pdf report = new DimensionListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FromDimCode = cmbFrom.Text.Trim();
        //        report.ToDimCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            report.ExportToPdf(memStream);
        //            objResponse.ContentType = "application/pdf";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=Dimension List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Product.Reports.DimensionListRpt_Xls reportc = new DimensionListRpt_Xls();

        //        reportc.DataSource = BindData();
        //        reportc.FromDimCode = cmbFrom.Text.Trim();
        //        reportc.ToDimCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            reportc.ExportToXls(memStream);
        //            objResponse.ContentType = "application/xls";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=DimensionListc.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Product.Reports.DimensionListRpt_Pdf rpt = new DimensionListRpt_Pdf();
        //        try
        //        {
        //            rpt.DataSource = BindData();
        //            rpt.FromDimCode = cmbFrom.Text.Trim();
        //            rpt.ToDimCode = cmbTo.Text.Trim();
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
           // Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"FromCombin",this.cmbFrom.Text.Trim()},
            {"ToCombin",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"Appendix1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix1")},
            {"Appendix2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix2")},
            {"Appendix3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix3")},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwDimensionList";
            view.ReportName = "RT2020.Product.Reports.DimensionListRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }
    }
}