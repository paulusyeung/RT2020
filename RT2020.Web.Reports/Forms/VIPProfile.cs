#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class VIPProfile : Controls.WizardBase
    {
        public VIPProfile()
        {
            InitializeComponent();
            this.txtVip.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwVIPProfile";

            StringBuilder whereCaluse = new StringBuilder();

            if (txtVip.Text.Trim().Length > 0 && txtVip.Text.Trim() != "*")
            {
                whereCaluse.Append(" MemberNumber LIKE '" + txtVip.Text.Trim() + "%'");
            }
            if (txtNickName.Text.Trim().Length > 0 && txtNickName.Text.Trim() != "*")
            {
                whereCaluse.Append((whereCaluse.Length > 0 ? " AND " : "") + " FullName='" + txtNickName.Text.Trim() + "'");
            }
            if (txtFirstName.Text.Trim().Length > 0 && txtFirstName.Text.Trim() != "*")
            {
                whereCaluse.Append((whereCaluse.Length > 0 ? " AND " : "") + " FirstName='" + txtFirstName.Text.Trim() + "'");
            }
            if (txtLastName.Text.Trim().Length > 0 && txtLastName.Text.Trim() != "*")
            {
                whereCaluse.Append((whereCaluse.Length > 0 ? " AND " : "") + " LastName='" + txtLastName.Text.Trim() + "'");
            }
            if (txtPhone.Text.Trim().Length > 0 && txtPhone.Text.Trim() != "*")
            {
                whereCaluse.Append((whereCaluse.Length > 0 ? " AND " : "") + " ContectNumber LIKE '%" + txtPhone.Text.Trim() + "%'");
            }
            if (txtID.Text.Trim().Length > 0 && txtID.Text.Trim() != "*")
            {
                whereCaluse.Append((whereCaluse.Length > 0 ? " AND " : "") + " ID='" + txtID.Text.Trim() + "'");
            }

            sql += whereCaluse.Length > 0 ? string.Format(" Where {0}", whereCaluse.ToString()) : "";
            sql += " ORDER BY MemberNumber";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = RT2020.DAL.SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtVip.Text.Trim().Length > 0 || txtNickName.Text.Trim().Length > 0 || txtFirstName.Text.Trim().Length > 0
                || txtLastName.Text.Trim().Length > 0 || txtPhone.Text.Trim().Length > 0 || txtID.Text.Trim().Length > 0)
            {
                DataTable table = BindData();
                if (table.Rows.Count > 0)
                {
                    List<ReportParameter> rptParm = new List<ReportParameter>();
                    rptParm.Add(new ReportParameter("STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE")));

                    this.rptViewer.Datasource = BindData();
                    this.rptViewer.ReportDatasourceName = "DataSource_vwVIPProfile";
                    this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPProfileRdl.rdlc";
                    this.rptViewer.Parameters = rptParm;

                    this.rptViewer.PreviewReport();

                    this.txtVip.Focus();
                }
                else
                {
                    MessageBox.Show("no record found.", "Message");
                }
            }
            else
            {
                MessageBox.Show("Select at least one Criteria.", "Message");
            }
        }
    }
}