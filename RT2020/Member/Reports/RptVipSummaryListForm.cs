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
    public partial class RptVipSummaryListForm : Form
    {
        string Appendix1 = "Sel1";
        string Appendix2 = "Sel2";
        string Appendix3 = "Sel3";
        string SubTotal = "SelTrn";

        public RptVipSummaryListForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillComboBox();
            InitLabelType();
        }

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            if (string.Compare(cmbFrom.Text.Trim(), cmbTo.Text.Trim()) > 0)
            {
                result = false;
                string errorStr = "Range Error: Vip Code!";
                MessageBox.Show(errorStr, "Message");    //cmbFrom > cmbTo
            }
            else if (string.Compare(cboFromGroup.Text.Trim(), cboToGroup.Text.Trim()) > 0)
            {
                result = false;
                MessageBox.Show("Range Error: Group!", "Message");   //cboFromGroup > cboToGroup
            }
            else if (dtpSpecifiedRangeFrom.Value > dtpSpecifiedRangeTo.Value)
            {
                result = false;
                MessageBox.Show("Range Error: Date", "Message");      //dtpSpecifiedRangeFrom > dtpSpecifiedRangeTo
            }
            return result;
        }
        #endregion

        #region Fill ComboBox
        private void FillComboBox()
        {
            FillMemberNumber();
            FillComboBoxGroup();
        }
        private void FillMemberNumber()
        {
            MemberCollection collection = RT2020.DAL.Member.LoadCollection(new string[] { "MemberNumber" }, true);
            if (collection.Count > 0)
            {
                foreach (RT2020.DAL.Member oItem in collection)
                {
                    string item = oItem.MemberNumber;
                    cmbFrom.Items.Add(item);
                    cmbTo.Items.Add(item);
                }
                cmbFrom.SelectedIndex = 0;
                cmbTo.SelectedIndex = collection.Count - 1;
            }

        }
        private void FillComboBoxGroup()
        {
            ModelEx.MemberGroupEx.LoadCombo(ref cboFromGroup, "GroupName", true);
            ModelEx.MemberGroupEx.LoadCombo(ref cboToGroup, "GroupName", true);
            /**
            MemberGroupCollection collection = RT2020.DAL.MemberGroup.LoadCollection(new string[] { "GroupName" }, true);
            if (collection.Count > 0)
            {
                foreach (RT2020.DAL.MemberGroup oItemGroup in collection)
                {
                    string item = oItemGroup.GroupName.Substring(0, 4);
                    cboFromGroup.Items.Add(item);
                    cboToGroup.Items.Add(item);
                }
                cboFromGroup.SelectedIndex = 0;
                cboToGroup.SelectedIndex = collection.Count - 1;
            }
            */
            cboToGroup.SelectedIndex = cboToGroup.Items.Count - 1;
        }
        #endregion

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwVIP_SalesSummary 
WHERE VipNumber BETWEEN '" + this.cmbFrom.Text.Trim() + "' AND '" + this.cmbTo.Text.Trim() + @"'
AND LEN(TxDate)<>0
OR ([Group] BETWEEN '" + cboFromGroup.Text.Trim()+"' AND '"+this.cboToGroup.Text.Trim()+@"'
AND LEN(STKCODE)<>0)";

            if (this.rbtnSpecifiedRange.Checked)
            {
                sql += " AND TxDate BETWEEN '" + dtpSpecifiedRangeFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpSpecifiedRangeTo.Value.ToString("yyyy-MM-dd") + "'";
            }
            sql += " ORDER BY VipNumber";

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

        #region CheckedChanged Event
        private void chkAppendix1_CheckedChanged(object sender, EventArgs e)
        {
            Appendix1 = string.Empty;
            if (chkAppendix1.Checked)
            {
                Appendix1 = "Sel1";
            }
        }

        private void chkAppendix2_CheckedChanged(object sender, EventArgs e)
        {
            Appendix2 = string.Empty;
            if (chkAppendix2.Checked)
            {
                Appendix2 = "Sel2";
            }
        }

        private void chkAppendix3_CheckedChanged(object sender, EventArgs e)
        {
            Appendix3 = string.Empty;
            if (chkAppendix3.Checked)
            {
                Appendix3 = "Sel3";
            }
        }
        private void rbnTransaction_CheckedChanged(object sender, EventArgs e)
        {
            SubTotal = string.Empty;
            if (rbnTransaction.Checked)
            {
                SubTotal = "SelTrn";
            }
        }

        private void rbnMonth_CheckedChanged(object sender, EventArgs e)
        {
            SubTotal = string.Empty;
            if (rbnMonth.Checked)
            {
                SubTotal = "SelMon";
            }
        }

        private void rbnYear_CheckedChanged(object sender, EventArgs e)
        {
            SubTotal = string.Empty;
            if (rbnYear.Checked)
            {
                SubTotal = "SelYear";
            }
        }
        #endregion

        #region Init Method
        private void InitLabelType()
        {
            if (rbtPDF.Checked)
            {
                gbAppendix.Visible = false;
                gbSubTotal.Visible = false;
            }

            if (rbtXLS.Checked)
            {
                gbAppendix.Visible = true;
                gbSubTotal.Visible = true;
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnVIP_L_CheckedChanged(object sender, EventArgs e)
        {
            InitLabelType();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string DateRange = string.Empty;
                if (rbtnAllToDate.Checked)
                {
                    DateRange = "ALL TO DATE";
                }
                else if (rbtnSpecifiedRange.Checked)
                {
                    DateRange = this.dtpSpecifiedRangeFrom.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) + "-" +
                                this.dtpSpecifiedRangeTo.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat());
                }

                string[,] param = {
                {"FromVipNumber",this.cmbFrom.Text.Trim()},
                {"ToVipNumber",this.cmbTo.Text.Trim()},
                {"DateRange",DateRange},
                {"Appendix1",Appendix1},
                {"Appendix2",Appendix2},
                {"Appendix3",Appendix3},
                {"Appendix1Name",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix1")},
                {"Appendix2Name",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix2")},
                {"Appendix3Name",RT2020.SystemInfo.Settings.GetSystemLabelByKey("Appendix3")},
                {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"SubTotal",SubTotal},
                {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();
                view.Datasource = BindData();

                #region ReportName
                if (rbtPDF.Checked)
                {
                    view.ReportName = "RT2020.Member.Reports.VipSummaryListFormRdl.rdlc";

                }
                else if (rbtXLS.Checked)
                {
                    view.ReportName = "RT2020.Member.Reports.VipSummaryListFormAppendix1..3Rdl.rdlc";
                }
                #endregion

                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_SalesSummary";
                view.Parameters = param;

                view.Show();
            }
        }
    }
}