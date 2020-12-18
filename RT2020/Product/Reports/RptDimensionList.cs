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
using RT2020.Helper;

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
            ModelEx.ProductDimEx.LoadCombo(ref cmbFrom, "DimCode", false);
            ModelEx.ProductDimEx.LoadCombo(ref cmbTo, "DimCode", false);

            if (cmbTo.Items.Count > 1) cmbTo.SelectedIndex = cmbTo.Items.Count - 1;
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