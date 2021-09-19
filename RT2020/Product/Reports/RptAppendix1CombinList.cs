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
    //public partial class RptAppendix1CombinList : Form, IGatewayControl
    public partial class RptAppendix1CombinList : Form
    {
        public RptAppendix1CombinList()
        {
            InitializeComponent();

            SetSystemLabels();
        }

        #region Set System Labels
        private void SetSystemLabels()
        {
            string syslbl = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            this.Text = syslbl + " Combin List Printing Wizard";
            this.lblFrom.Text = string.Format("From {0} Combin#", syslbl);
            this.lblTo.Text = string.Format("To {0} Combin#", syslbl);
        }
        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            string sql = "DimType = 'A1'";
            var orderBy = new string[] { "DimCode" };

            ProductDimEx.LoadCombo(ref cmbFrom, "DimCode", false, false, "", sql, orderBy);
            ProductDimEx.LoadCombo(ref cmbTo, "DimCode", false, false, "", sql, orderBy);

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
            cmd.CommandText = "apProductDimAPP1List";
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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

        private void RptSeasonComBinList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }
        
        private void btnPrview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"FromCombin",this.cmbFrom.Text.Trim()},
            {"ToCombin",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {"Appendix1",SystemInfoHelper.Settings.GetSystemLabelByKey("Appendix1")},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apProductDimAPP1List";
            view.ReportName = "RT2020.Product.Reports.Appendix1CombinRdl.rdlc";
            view.Parameters = param;

            view.Show();
        }              
    }
}