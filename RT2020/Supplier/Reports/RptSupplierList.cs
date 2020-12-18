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
using RT2020.Helper;


#endregion

namespace RT2020.Supplier.Reports
{
    //public partial class RptSupplierList : Form, IGatewayControl
    public partial class RptSupplierList : Form
    {
        public RptSupplierList()
        {
            InitializeComponent();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            ModelEx.SupplierEx.LoadCombo(ref cmbFrom, "SupplierCode", false);
            ModelEx.SupplierEx.LoadCombo(ref cmbTo, "SupplierCode", false);
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
            cmd.CommandText = "apSupplierList";
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterValues);

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }

        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void RptSupplierList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text.CompareTo(cmbTo.Text) <= 0)
            {
                string[,] param = {
            {"FromSupplierList",this.cmbFrom.Text.Trim()},
            {"ToSupplierList",this.cmbTo.Text.Trim()},
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
            {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apSupplierList";
                view.ReportName = "RT2020.Supplier.Reports.SupplierListRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
            else
            {
                MessageBox.Show("Out of range! ", "ATTENTION");
            }
        }
    }
}
