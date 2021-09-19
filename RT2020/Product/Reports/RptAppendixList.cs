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
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Product.Reports
{
    //public partial class RptAppendix1List : Form, IGatewayControl
    public partial class RptAppendixList : Form
    {
        public RptAppendixList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetSystemLabels();
        }

        private string appendixType = "Appendix1";
        /// <summary>
        /// Gets or sets the type of the appendix.
        /// </summary>
        /// <value>The type of the appendix.</value>
        public string AppendixType
        {
            get
            {
                return appendixType;
            }
            set
            {
                appendixType = value;
            }
        }

        #region Set System Labels
        private void SetSystemLabels()
        {
            string syslbl = SystemInfoHelper.Settings.GetSystemLabelByKey(this.AppendixType.Trim().ToUpper());
            this.Text = syslbl + " List Printing Wizard";

            this.lblFrom.Text = "From " + syslbl;
            this.lblTo.Text = "To " + syslbl;
        }
        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            string textField = this.AppendixType.Trim() + "Code";

            switch (this.AppendixType.Trim().ToUpper())
            {
                case "APPENDIX1":
                    ProductAppendix1Ex.LoadCombo(ref cmbFrom, textField, false);
                    ProductAppendix1Ex.LoadCombo(ref cmbTo, textField, false);
                    break;
                case "APPENDIX2":
                    ProductAppendix2Ex.LoadCombo(ref cmbFrom, textField, false);
                    ProductAppendix2Ex.LoadCombo(ref cmbTo, textField, false);
                    break;
                case "APPENDIX3":
                    ProductAppendix3Ex.LoadCombo(ref cmbFrom, textField, false);
                    ProductAppendix3Ex.LoadCombo(ref cmbTo, textField, false);
                    break;
            }

            cmbTo.SelectedIndex = cmbTo.Items.Count - 1;
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = cmbFrom.Text.Trim();
            string toCode = cmbTo.Text.Trim();

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frm" + this.AppendixType.Trim() + "Code", frmCode), new SqlParameter("@to" + this.AppendixType.Trim() + "Code", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ap" + this.AppendixType.Trim() + "List";
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
        //    string syslbl = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");

        //    // Create a report instance.
        //    if (rbnPDF.Checked == true)
        //    {
        //        RT2020.Product.Reports.Appendix1ListRpt_Pdf report = new Appendix1ListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FrmCode = cmbFrom.Text.Trim();
        //        report.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        report.ExportToPdf(memStream);
        //        objResponse.ContentType = "application/pdf";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=" + syslbl + " List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Product.Reports.Appendix1ListRpt_Xls reportc = new Appendix1ListRpt_Xls();

        //        reportc.DataSource = BindData();
        //        reportc.FrmCode = cmbFrom.Text.Trim();
        //        reportc.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //        reportc.ExportToXls(memStream);
        //        objResponse.ContentType = "application/xls";
        //        objResponse.AddHeader("content-disposition", "attachment; filename=" + syslbl + " List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Product.Reports.Appendix1ListRpt_Pdf rpt = new Appendix1ListRpt_Pdf();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void RptSeasonList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text.CompareTo(cmbTo.Text) <= 0)
            {
                string[,] param = {
            {"FromAppendix",this.cmbFrom.Text.Trim()},
            {"ToAppendix",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {this.AppendixType.Trim(),SystemInfoHelper.Settings.GetSystemLabelByKey(this.AppendixType.Trim().ToUpper())},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_ap" + this.AppendixType.Trim() + "List";
                view.ReportName = "RT2020.Product.Reports." + this.AppendixType.Trim() + "ListRdl.rdlc";
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