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
using System.Data.Common;
using System.Configuration;


#endregion

namespace RT2020.Product.Reports
{
    //public partial class RptClass1List : Form, IGatewayControl
    public partial class RptClassList : Form
    {
        public RptClassList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetSystemLabels();
        }

        private string classType = "Class1";
        /// <summary>
        /// Gets or sets the type of the class.
        /// </summary>
        /// <value>The type of the class.</value>
        public string ClassType
        {
            get
            {
                return classType;
            }
            set
            {
                classType = value;
            }
        }

        #region Set System Labels
        private void SetSystemLabels()
        {
            string syslbl = RT2020.SystemInfo.Settings.GetSystemLabelByKey(this.ClassType.Trim().ToUpper());
            this.Text = syslbl + " List Printing Wizard";

            this.lblFrom.Text = "From " + syslbl;
            this.lblTo.Text = "To " + syslbl;
        }
        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            string fieldText = this.ClassType.Trim() + "Code";

            switch (this.ClassType.Trim().ToUpper())
            {
                case "CLASS1":
                    ProductClass1.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass1.LoadCombo(ref cmbTo, fieldText, false);
                    break;
                case "CLASS2":
                    ProductClass2.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass2.LoadCombo(ref cmbTo, fieldText, false);
                    break;
                case "CLASS3":
                    ProductClass3.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass3.LoadCombo(ref cmbTo, fieldText, false);
                    break;
                case "CLASS4":
                    ProductClass4.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass4.LoadCombo(ref cmbTo, fieldText, false);
                    break;
                case "CLASS5":
                    ProductClass5.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass5.LoadCombo(ref cmbTo, fieldText, false);
                    break;
                case "CLASS6":
                    ProductClass6.LoadCombo(ref cmbFrom, fieldText, false);
                    ProductClass6.LoadCombo(ref cmbTo, fieldText, false);
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

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frm" + this.ClassType.Trim() + "Code", frmCode), new SqlParameter("@to" + this.ClassType.Trim() + "Code", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apProduct" + this.ClassType.Trim() + "List";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
        //    string syslbl = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");

        //    // Create a report instance.
        //    if (rbnPDF.Checked == true)
        //    {
        //        RT2020.Product.Reports.Class1ListRpt_Pdf report = new Class1ListRpt_Pdf();

        //        report.DataSource = BindData();
        //        report.FrmCode = cmbFrom.Text.Trim();
        //        report.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            report.ExportToPdf(memStream);
        //            objResponse.ContentType = "application/pdf";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=" + syslbl + " List.pdf");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else if (rbnXLS.Checked)
        //    {
        //        RT2020.Product.Reports.Class1ListRpt_Xls reportc = new Class1ListRpt_Xls();

        //        reportc.DataSource = BindData();
        //        reportc.FrmCode = cmbFrom.Text.Trim();
        //        reportc.toCode = cmbTo.Text.Trim();
        //        HttpResponse objResponse = this.Context.HttpContext.Response;

        //        System.IO.MemoryStream memStream = new System.IO.MemoryStream();

        //        objResponse.Clear();
        //        objResponse.ClearHeaders();
        //            reportc.ExportToXls(memStream);
        //            objResponse.ContentType = "application/xls";
        //            objResponse.AddHeader("content-disposition", "attachment; filename=" + syslbl + " List.xls");
        //        objResponse.BinaryWrite(memStream.ToArray());
        //        objResponse.Flush();
        //        objResponse.End();

        //        return null;
        //    }
        //    else
        //    {
        //        RT2020.Product.Reports.Class1ListRpt_Pdf rpt = new Class1ListRpt_Pdf();
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

        private void RptVendorList_Load(object sender, EventArgs e)
        {

            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text.CompareTo(cmbTo.Text) <= 0)
            {
                string[,] param = {
            {"From" + this.ClassType.Trim(),this.cmbFrom.Text.Trim()},
            {"To" + this.ClassType.Trim(),this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {this.ClassType.Trim(),RT2020.SystemInfo.Settings.GetSystemLabelByKey(this.ClassType.Trim().ToUpper())},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apProduct" + this.ClassType.Trim() + "List";
                view.ReportName = "RT2020.Product.Reports." + this.ClassType.Trim() + "ListRdl.rdlc";
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