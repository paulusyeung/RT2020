#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.DAL;
using Microsoft.Reporting.WebForms;

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class VIPSalesAnalysis : Controls.WizardBase
    {
        public VIPSalesAnalysis()
        {
            InitializeComponent();
            this.txtNumber.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.rptViewer.AutoSize = true;
            this.rptViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        #region Validate View VIP Detail
        private bool IsValidateVIP()
        {
            bool vip = false;

            string sql = @"
SELECT  Salute,FullName,WorkTel,HomeTel,ISNULL(PagerTel,''),Email,Birthday,[Profile],Remarks,
        DateOfRegister,ExpiryDate,VipNumber,CodeNumber,LoyaltyNum,
        SUM(TxCount) AS AccumulativeTranscations, SUM(TxAmount) AS AccumulativeSpending,
        CONVERT(VARCHAR(10),TxDate,126) AS TxDate
FROM (SELECT Salute,FullName,WorkTel,HomeTel,PagerTel,Email,CAST(Birthday AS DateTime) AS Birthday,[Profile],Remarks,
            CAST(DateOfRegister AS DateTime) AS DateOfRegister,ExpiryDate,HKID,VipNumber,CodeNumber,LoyaltyNum,
            MemberNumber, TxDate,TxNumber, TxType, 1 AS TxCount, SUM((CASE TxType WHEN 'CAS' THEN 1 ELSE -1 END) * Amount) AS TxAmount 
      FROM dbo.vwVIPSalesAnalysis
      GROUP BY Salute,FullName,WorkTel,HomeTel,PagerTel,Email,Birthday,[Profile],Remarks,
             DateOfRegister,ExpiryDate,HKID,VipNumber,CodeNumber,LoyaltyNum,MemberNumber,TxDate,TxNumber,TxType) lst ";

            string whereCaluse = string.Empty;
            if (this.txtNumber.Text.Trim().Length > 0)
            {
                whereCaluse = " lst.MemberNumber ='" + this.txtNumber.Text.Trim() + "'";
            }

            if (this.txtHKID.Text.Trim().Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " lst.HKID ='" + this.txtHKID.Text.Trim() + "'";
            }

            if (this.txtLoyalty.Text.Trim().Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " lst.LoyaltyNum ='" + this.txtLoyalty.Text.Trim() + "'";
            }

            if (this.txtCode.Text.Trim().Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " lst.CodeNumber ='" + this.txtCode.Text.Trim() + "'";
            }

            whereCaluse += " AND (CONVERT(NVARCHAR(10),TxDate,126) BETWEEN '" + this.dtDateFrom.Value.ToString("yyyy-MM-dd")
                                                   + "' AND '" + this.dtDateTo.Value.ToString("yyyy-MM-dd") + "')";

            whereCaluse += "GROUP BY CONVERT(VARCHAR(10),TxDate,126),Salute,FullName,WorkTel,HomeTel,PagerTel,Email,Birthday,[Profile],Remarks,DateOfRegister,ExpiryDate,VipNumber,CodeNumber,LoyaltyNum";

            sql = sql + string.Format(" WHERE {0}", whereCaluse);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["CommandTimedOut"]);
            cmd.CommandType = CommandType.Text;

            using (System.Data.SqlClient.SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                decimal spending = 0;
                int trnNo = 0;
                while (reader.Read())
                {
                    vip = true;

                    txtSalute.Text = ": " + reader.GetString(0);
                    txtVipName.Text = ": " + reader.GetString(1);
                    txtContactNumber.Text = ": " + reader.GetString(2) + "\t";
                    txtContactNumber.Text += "/" + reader.GetString(3) + "\t";
                    txtContactNumber.Text += "/" + reader.GetString(4);
                    txtEmail.Text = ": " + reader.GetString(5);
                    txtBirthday.Text = ": " + reader.GetDateTime(6).ToString("dd/MM/yyyy").Replace("01/01/1900", "");
                    txtProfile.Text = ": " + reader.GetString(7);
                    txtRemarks.Text = ": " + reader.GetString(8);
                    txtRegDate.Text = ": " + reader.GetDateTime(9).ToString("dd/MM/yyyy").Replace("01/01/1900", "");
                    txtExpiryDate.Text = ": " + reader.GetDateTime(10).ToString("dd/MM/yyyy").Replace("01/01/1900", "");
                    txtTypeAndNumber.Text = ": " + "EXVIP \t" + reader.GetString(11) + "\t";
                    txtTypeAndNumber.Text += "/" + reader.GetString(12) + "\t";
                    txtTypeAndNumber.Text += "/" + reader.GetString(13);

                    spending += reader.GetDecimal(15);
                    txtAccumulativeSpending.Text = ": " + spending.ToString("C");

                    trnNo += reader.GetInt32(14);
                    txtAccumulativeTransactionNumber.Text = ": " + trnNo.ToString("n0");
                }
            }

            return vip;
        }
        #endregion

        #region Bind Data to Report
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwVIPSalesAnalysis ";

            string whereCaluse = string.Empty;

            if (txtNumber.Text.Length > 0)
            {
                whereCaluse = " MemberNumber LIKE '" + txtNumber.Text.Trim() + "%'";
            }

            if (txtHKID.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " HKID ='" + txtHKID.Text.Trim() + "'";
            }

            if (txtCode.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " CodeNumber ='" + txtCode.Text.Trim() + "'";
            }

            if (txtLoyalty.Text.Length > 0)
            {
                whereCaluse += (whereCaluse.Length > 0 ? " OR " : "") + " LoyaltyNum ='" + txtLoyalty.Text.Trim() + "'";
            }

            if (txtLayout.Text.Trim() == "6")
            {
                whereCaluse += " AND (CLASS1='CRM')";
            }

            whereCaluse += " AND (CONVERT(NVARCHAR(10),TxDate,126) BETWEEN '" + this.dtDateFrom.Value.ToString("yyyy-MM-dd")
                                                    + "' AND '" + this.dtDateTo.Value.ToString("yyyy-MM-dd") + "')";
            whereCaluse = string.Format(" WHERE {0}", whereCaluse);

            sql += whereCaluse;

            if (txtLayout.Text.Trim() == "2")
            {
                sql = @"SELECT TOP 100 PERCENT * FROM vwVIPSalesAnalysis 
                            WHERE TxDate =(SELECT MAX(TxDate) FROM vwVIPSalesAnalysis " + whereCaluse + ")";
            }

            #region Order by Fields
            switch (txtLayout.Text.Trim())
            {
                case "1":
                case "2":
                    sql += " ORDER BY TxDate Desc,TxType,TxNumber,APPENDIX1,APPENDIX2,APPENDIX3";
                    break;
                case "3":
                    sql += " ORDER BY CLASS1,CLASS2";
                    break;
                case "4":
                    sql += " ORDER BY TxDate Desc";
                    break;
                case "5":
                    sql += " ORDER BY CLASS5,CLASS1";
                    break;
                case "6":
                    sql += " ORDER BY STKCODE,APPENDIX1,APPENDIX2,APPENDIX3,TxType,TxNumber,TxDate";
                    break;
                default:
                    sql += " ORDER BY TxDate Desc,TxType,TxNumber,APPENDIX1,APPENDIX2,APPENDIX3";
                    break;
            }
            #endregion

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
            if (txtNumber.Text.Trim().Length > 0 || txtHKID.Text.Trim().Length > 0
                || txtCode.Text.Trim().Length > 0 || txtLoyalty.Text.Trim().Length > 0)
            {
                List<ReportParameter> rptParam = new List<ReportParameter>();
                rptParam.Add(new ReportParameter("STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE")));
                rptParam.Add(new ReportParameter("APPENDIX1", Common.Utility.GetSystemLabelByKey("APPENDIX1")));
                rptParam.Add(new ReportParameter("APPENDIX2", Common.Utility.GetSystemLabelByKey("APPENDIX2")));
                rptParam.Add(new ReportParameter("APPENDIX3", Common.Utility.GetSystemLabelByKey("APPENDIX3")));
                rptParam.Add(new ReportParameter("CLASS1", Common.Utility.GetSystemLabelByKey("CLASS1")));
                rptParam.Add(new ReportParameter("CLASS2", Common.Utility.GetSystemLabelByKey("CLASS2")));
                rptParam.Add(new ReportParameter("CLASS3", Common.Utility.GetSystemLabelByKey("CLASS3")));
                rptParam.Add(new ReportParameter("CLASS4", Common.Utility.GetSystemLabelByKey("CLASS4")));
                rptParam.Add(new ReportParameter("CLASS5", Common.Utility.GetSystemLabelByKey("CLASS5")));
                rptParam.Add(new ReportParameter("CLASS6", Common.Utility.GetSystemLabelByKey("CLASS6")));

                DataTable table = BindData();

                if (table.Rows.Count > 0)
                {
                    gbInfo.Visible = IsValidateVIP();

                    this.rptViewer.Datasource = BindData();
                    this.rptViewer.ReportDatasourceName = "DataSource_vwVIPSalesAnalysis";

                    #region ReportName
                    switch (txtLayout.Text.Trim())
                    {
                        case "1":
                        case "2":
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisFullList.rdlc";
                            break;
                        case "3":
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisByClass2.rdlc";
                            break;
                        case "4":
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisNoOfVisits.rdlc";
                            break;
                        case "5":
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisByClass5.rdlc";
                            break;
                        case "6":
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisFullListByClass.rdlc";
                            break;
                        default:
                            this.rptViewer.ReportName = "RT2020.Web.Reports.Rdlc.VIPSalesAnalysisFullList.rdlc";
                            break;
                    }
                    #endregion

                    this.rptViewer.Parameters = rptParam;

                    this.rptViewer.PreviewReport();
                }
                else
                {
                    MessageBox.Show("no record found.", "Message");
                }
            }
            else
            {
                MessageBox.Show("VIP# or HKID# or Code# or Loyalty# Are Required!", "Message");
            }

            this.txtNumber.Focus();
        }
    }
}