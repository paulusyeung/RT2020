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
    //public partial class RptAppendix2CombinList : Form, IGatewayControl
    public partial class RptAppendix2CombinList : Form
    {
        public RptAppendix2CombinList()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        #region Set System Labels
        private void SetSystemLabels()
        {
            string syslbl = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            this.Text = syslbl + " Combin List Printing Wizard";
            this.lblFrom.Text = string.Format("From {0} Combin#", syslbl);
            this.lblTo.Text = string.Format("To {0} Combin#", syslbl);
        }
        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            string sql = "DimType = 'A2'";

            var orderBy = new string[] { "DimCode" };

            ModelEx.ProductDimEx.LoadCombo(ref cmbFrom, "DimCode", false, false, "", sql, orderBy);
            ModelEx.ProductDimEx.LoadCombo(ref cmbTo, "DimCode", false, false, "", sql, orderBy);

            if (cmbTo.Items.Count > 1) cmbTo.SelectedIndex = cmbTo.Items.Count - 1;
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmCode = cmbFrom.Text.Trim();
            string toCode = cmbTo.Text.Trim();

            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmDimCode", frmCode), new SqlParameter("@toDimCode", toCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apProductDimAPP2List";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }

        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RptColorCombinList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"FromCombin",this.cmbFrom.Text.Trim()},
            {"ToCombin",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"Appendix2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix2")},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apProductDimAPP2List";
            view.ReportName = "RT2020.Product.Reports.Appendix2CombinRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }

    }
}