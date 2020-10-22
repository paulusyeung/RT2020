#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;

#endregion

namespace RT2020.Member.Reports
{
    public partial class RptVipMLblBirthdayAtdForm : Form
    {
        public RptVipMLblBirthdayAtdForm()
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
            MemberCollection collection = RT2020.DAL.Member.LoadCollection(new string[] { "MemberNumber" }, true);
            if (collection.Count > 0)
            {
                foreach (RT2020.DAL.Member oMember in collection)
                {
                    string item = oMember.MemberNumber + " - " + oMember.FullName;
                    cmbFrom.Items.Add(item);
                    cmbTo.Items.Add(item);
                }
                cmbFrom.SelectedIndex = 0;

                cmbTo.SelectedIndex = collection.Count - 1;
            }
        }
        #endregion

        #region Init Method
        private void FillPositionList(int positionCount)
        {
            cboFromPosition.Items.Clear();
            cboToPosition.Items.Clear();

            for (int i = 1; i <= positionCount; i++)
            {
                cboFromPosition.Items.Add(i.ToString());
                cboToPosition.Items.Add(i.ToString());
            }

            cboFromPosition.SelectedIndex = 0;
            cboToPosition.SelectedIndex = positionCount - 1;
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

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
        #endregion

        private void RptVipMLblBirthdayAtdForm_Load(object sender, EventArgs e)
        {
            FillPositionList(14);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            string[,] param = {
            {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())}
            };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            #region ReportName
            if (this.rbtnLayout_1.Checked)
            {
                view.ReportName = "RT2020.Member.Reports.VipMLblBirthdayAtdForm_001ADCRdl.rdlc";
            }
            else
            {
                view.ReportName = "RT2020.Member.Reports.VipMLblBirthdayAtdForm_001CDARdl.rdlc";
            }
            #endregion

            view.Datasource = BindData();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_MemberList";
            view.Parameters = param;

            view.Show();
        }
    }
}