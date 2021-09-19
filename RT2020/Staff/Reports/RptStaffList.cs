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
using System.Configuration;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;
#endregion

namespace RT2020.Staff.Reports
{
    //public partial class RptStaffList : Form, IGatewayControl
    public partial class RptStaffList : Form
    {
        public RptStaffList()
        {
            InitializeComponent();
        }

        #region FillComboBox
        private void FillComboBox()
        {
            StaffEx.LoadCombo(ref cmbFrmStaffCode, "StaffNumber", false);

            StaffEx.LoadCombo(ref cmbToStaffCode, "StaffNumber", false);

            cmbToStaffCode.SelectedIndex = cmbToStaffCode.Items.Count - 1;
        }

        #endregion

        #region Data Binds

        private DataTable BindData()
        {
            string frmStaffCode = cmbFrmStaffCode.Text.Trim().Substring(0, 4);
            string toStaffCode = cmbToStaffCode.Text.Trim().Substring(0, 4);
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@frmStaff", frmStaffCode), new SqlParameter("@toStaff", toStaffCode) };

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "apStaffList";
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
            // Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void frmStaffList_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (cmbFrmStaffCode.Text.CompareTo(cmbToStaffCode.Text) <= 0)
            {
                string[,] param = {
            {"FromStaffCode",this.cmbFrmStaffCode.Text.Trim().Substring(0,4)},
            {"ToStaffCode",this.cmbToStaffCode.Text.Trim().Substring(0,4)},
            {"PrintedOn",DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
            {"DateFormat",DateTimeHelper.GetDateTimeFormat()},
            {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName}
            };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_apStaffList";
                view.ReportName = "RT2020.Staff.Reports.StaffListRdl.rdlc";
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