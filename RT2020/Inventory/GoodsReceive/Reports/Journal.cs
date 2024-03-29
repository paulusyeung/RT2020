#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Gizmox.WebGUI.Common.Interfaces;
using System.IO;
using FileHelpers.DataLink;
using FileHelpers.MasterDetail;
using System.Web;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Inventory.GoodsReceive.Reports
{
    //public partial class JournalWizard : Form, IGatewayControl
    public partial class JournalWizard : Form
    {
        // MasterDetails[] md;

        public JournalWizard()
        {
            InitializeComponent();
            FillComboList();

            this.txtMonth.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth;
            this.txtYear.Text = SystemInfoEx.CurrentInfo.Default.CurrentSystemYear;
        }

        #region Fill Combo List
        private void FillComboList()
        {
            FillLocation();
            FillVsLocation();
            FillRemarks();
        }

        private void FillLocation()
        {
            WorkplaceEx.LoadCombo(ref cboLocation, "WorkplaceCode",false);
        }

        private void FillVsLocation()
        {
            WorkplaceEx.LoadCombo(ref cboVsLocation, "WorkplaceCode", false);
        }

        private void FillRemarks()
        {
            string[] oItems = { "Class 1 - 6", "Description" };
            this.cboRemarks.Items.Clear();
            this.cboRemarks.Items.AddRange(oItems);
            this.cboRemarks.SelectedIndex = 0;
        }
        #endregion

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;
            int year = 0;
            int month = 0;
            if (int.TryParse(this.txtYear.Text.Trim(), out year) && int.TryParse(this.txtMonth.Text.Trim(), out month))
            {
                if (year <= 0 || year > 9999)
                {
                    result = false;
                    MessageBox.Show("Range Error: Year Error", "Message");
                }
                else if (month < 1 || month > 12)
                {
                    result = false;
                    MessageBox.Show("Range Error: Month Error", "Message");
                }
                else if (dtpTxDateTo.Value < dtpTxDateFrom.Value)                   // dtpTxDateTo < dtpTxDateFrom
                {
                    result = false;
                    MessageBox.Show("Range Error: Tx Date", "Message");
                }
            }
            else
            {
                result = false;
                MessageBox.Show("Format Error:Year and Month Must be a number of", "Message");
            }
            return result;
        }
        #endregion

        #region Bind data
        private DataTable BindData()
        {
            string Shop = string.Empty;
            Shop = this.cboLocation.Text.Trim().Substring(0, this.cboLocation.Text.Trim().IndexOf(' '));

            string sql = @"
SELECT * FROM dbo.vwJournalCAPList 
WHERE (STKCODE >= '" + txtFromStockCode.Text.Trim() + "') AND (STKCODE <= '" + txtToStockCode.Text.Trim() + @"') AND 
        TxDate >= CAST('" + this.dtpTxDateFrom.Value.ToString("yyyy-MM-dd 00:00:00") + @"' AS Datetime) AND 
        TxDate <= CAST('" + this.dtpTxDateTo.Value.ToString("yyyy-MM-dd 23:59:59") + @"' AS Datetime) AND 
        TxType ='" + EnumHelper.TxType.CAP + "' AND LocationCode = '" + Shop + "'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

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

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        //#region IGatewayControl Members

        //private RecordAction RecSelector(string record)
        //{
        //    string rec = record[0].ToString() + record[1].ToString();
        //    if (rec == "HH")
        //    {
        //        return RecordAction.Master;
        //    }
        //    else if (rec == "DD")
        //    {
        //        return RecordAction.Detail;
        //    }
        //    else
        //    {
        //        return RecordAction.Skip;
        //    }
        //}

        //public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        //{
        //    MasterDetailEngine engine = new MasterDetailEngine(typeof(CAPTxtIEMaster), typeof(CAPTxtIEDetails), new MasterDetailSelector(RecSelector));

        //    LoadData();

        //    string path = Path.Combine(Context.Config.GetDirectory("Upload"), "Member");
        //    string fileName = "CAPExportList_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    string fullName = Path.Combine(path, fileName);

        //    engine.WriteFile(fullName, md);

        //    HttpResponse objResponse = this.Context.HttpContext.Response;

        //    objResponse.Clear();
        //    objResponse.ClearHeaders();

        //    objResponse.ContentType = "application/txt";
        //    objResponse.AddHeader("content-disposition", "attachment; filename=" + fileName);
        //    objResponse.BinaryWrite(File.ReadAllBytes(fullName));
        //    objResponse.Flush();
        //    objResponse.End();

        //    return null;
        //}

        //#endregion

        //private void LoadData()
        //{
        //    string sql = string.Empty;
        //    //if (rbtnPosted.Checked)
        //    //{
        //    //    sql = "SELECT * FROM vwDraftCAPList WHERE (ReadOnly = 1) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "');";
        //    //    sql += "SELECT * FROM vwCAPDetailsList WHERE HeaderId IN (SELECT HeaderId FROM vwDraftCAPList WHERE (ReadOnly = 1) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "'))";
        //    //}
        //    //else
        //    //{
        //    sql = "SELECT * FROM vwDraftCAPList WHERE (ReadOnly = 0) AND (TxNumber >= '" + cboFromProduct.Text + "') AND (TxNumber <= '" + cboToProduct.Text + "');";
        //    sql += "SELECT * FROM vwCAPDetailsList WHERE HeaderId IN (SELECT HeaderId FROM vwDraftCAPList WHERE (ReadOnly = 0) AND (TxNumber >= '" + cboFromProduct.Text + "') AND (TxNumber <= '" + cboToProduct.Text + "'))";
        //    //}

        //    DataSet ds = SqlHelper.ExecuteDataSet(CommandType.Text, sql);
        //    FillMaster(ds.Tables[0], ds.Tables[1]);
        //}

        //protected void FillMaster(DataTable masterTable, DataTable detailTable)
        //{
        //    md = new MasterDetails[masterTable.Rows.Count];
        //    for (int i = 0; i < masterTable.Rows.Count; i++)
        //    {
        //        md[i] = new MasterDetails();
        //        DataRow row = masterTable.Rows[i];

        //        CAPTxtIEMaster oMaster = new CAPTxtIEMaster();

        //        oMaster.RecType = "HH";
        //        oMaster.Location = row["Location"].ToString();
        //        oMaster.Operator = row["StaffNumber"].ToString();
        //        oMaster.RecvDate = Convert.ToDateTime(row["TxDate"]);
        //        oMaster.Supplier = row["SupplierCode"].ToString();
        //        oMaster.RefNumber = row["Reference"].ToString();
        //        oMaster.Remarks = row["Remarks"].ToString();

        //        md[i].Master = oMaster;

        //        FillDetails(detailTable, row["HeaderId"].ToString(), ref md[i]);
        //    }
        //}

        //protected void FillDetails(DataTable detailTable, string headerId, ref MasterDetails mDetail)
        //{
        //    DataRow[] rows = detailTable.Select("HeaderId = '" + headerId + "'");
        //    mDetail.Details = new object[rows.Length];

        //    for (int i = 0; i < rows.Length; i++)
        //    {
        //        DataRow row = rows[i];

        //        CAPTxtIEDetails oDetail = new CAPTxtIEDetails();

        //        oDetail.RecType = "DD";
        //        oDetail.StockCode = row["STKCODE"].ToString();
        //        oDetail.Appendix1 = row["APPENDIX1"].ToString();
        //        oDetail.Appendix2 = row["APPENDIX2"].ToString();
        //        oDetail.Appendix3 = row["APPENDIX3"].ToString();
        //        oDetail.ReceivedQty = Convert.ToInt32(((decimal)row["Qty"]).ToString("n0"));
        //        oDetail.ReceivedUnitAmount = (decimal)row["UnitAmount"];

        //        mDetail.Details[i] = oDetail;
        //    }
        //}

        private void JournalWizard_Load(object sender, EventArgs e)
        {
            cboLocation.Focus();
        }

        private void chkVsLocation_Click(object sender, EventArgs e)
        {
            this.cboVsLocation.Enabled = this.chkVsLocation.Checked;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = { 
                {"FromTxNumber",this.txtFromStockCode.Text.Trim()},
                {"ToTxNumber",this.txtToStockCode.Text.Trim()},
                {"FromTxDate", this.dtpTxDateFrom.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"ToTxDate", this.dtpTxDateTo.Value.ToString(DateTimeHelper.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat())},
                {"DateFormat", DateTimeHelper.GetDateFormat()},
                {"LocationFrom",txtFromStockCode.Text},
                {"LocationTo",txtToStockCode.Text},
                {"STKLabel",SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6")},  
                {"Locations",this.cboLocation.Text.Substring(0,cboLocation.Text.IndexOf(' '))},
                {"CompanyName",SystemInfoEx.CurrentInfo.Default.CompanyName},
                {"IsCurrentSystemMonth", (SystemInfoEx.CurrentInfo.Default.CurrentSystemMonth == txtMonth.Text).ToString()}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwJournalCAPList";
                view.ReportName = "RT2020.Inventory.GoodsReceive.Reports.JournalRdl.rdlc";
                view.Parameters = param;

                view.Show();
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                LoadDateToDateTimePicker();
            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                LoadDateToDateTimePicker();
            }
        }

        #region LoadDateTime
        private void LoadDateToDateTimePicker()
        {
            dtpTxDateFrom.Value = new DateTime(ForYear, ForMonth, 1);
            dtpTxDateTo.Value = new DateTime(ForYear, ForMonth, DateTime.DaysInMonth(ForYear, ForMonth));
        }

        private int ForMonth
        {
            get
            {
                return int.Parse(this.txtMonth.Text.Trim());
            }
        }

        private int ForYear
        {
            get
            {
                return int.Parse(this.txtYear.Text.Trim());
            }
        }
        #endregion
    }
}