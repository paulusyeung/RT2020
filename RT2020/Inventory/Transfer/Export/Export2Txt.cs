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
using Gizmox.WebGUI.Common.Interfaces;
using System.IO;
using FileHelpers.DataLink;
using FileHelpers.MasterDetail;
using System.Web;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;

#endregion

namespace RT2020.Inventory.Transfer.Export
{
    public partial class Export2Txt : Form, IGatewayComponent
    {
        MasterDetails[] md;

        public Export2Txt()
        {
            InitializeComponent();
            FillComboList();

            txtFileName.Text = Path.Combine(Context.Config.GetDirectory("Download"), "Transfer");
        }

        #region Fill Combo List
        private void FillComboList()
        {
            FillFromList();
            FillToList();
        }

        private void FillFromList()
        {
            cboFrom.DataSource = null;
            cboFrom.Items.Clear();

            string[] orderBy = { "TxNumber" };

            using (var ctx = new EF6.RT2020Entities())
            {
                if (rbtnUnposted.Checked)
                {
                    var headerList = ctx.InvtBatchTXF_Header.OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                    cboFrom.DataSource = headerList;
                    cboFrom.DisplayMember = "TxNumber";
                    cboFrom.ValueMember = "HeaderId";
                }
                else
                {
                    var headerList = ctx.InvtSubLedgerTXF_Header.OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                    cboFrom.DataSource = headerList;
                    cboFrom.DisplayMember = "TxNumber";
                    cboFrom.ValueMember = "HeaderId";
                }
            }
        }

        private void FillToList()
        {
            cboTo.DataSource = null;
            cboTo.Items.Clear();

            string[] orderBy = { "TxNumber" };

            using (var ctx = new EF6.RT2020Entities())
            {
                if (rbtnUnposted.Checked)
                {
                    var headerList = ctx.InvtBatchTXF_Header.OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                    cboTo.DataSource = headerList;
                    cboTo.DisplayMember = "TxNumber";
                    cboTo.ValueMember = "HeaderId";
                }
                else
                {
                    var headerList = ctx.InvtSubLedgerTXF_Header.OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                    cboTo.DataSource = headerList;
                    cboTo.DisplayMember = "TxNumber";
                    cboTo.ValueMember = "HeaderId";
                }

                cboTo.SelectedIndex = cboTo.Items.Count - 1;
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            LoadData();
            if (md.Length > 0)
            {
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
            }
            else
            {
                MessageBox.Show("No record found!");
            }
        }

        #region IGatewayComponent Members

        private RecordAction RecSelector(string record)
        {
            string rec = record[0].ToString() + record[1].ToString();
            if (rec == "HH")
            {
                return RecordAction.Master;
            }
            else if (rec == "DD")
            {
                return RecordAction.Detail;
            }
            else
            {
                return RecordAction.Skip;
            }
        }

        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            MasterDetailEngine engine = new MasterDetailEngine(typeof(TxferTxtIEMaster), typeof(TxferTxtIEDetails), new MasterDetailSelector(RecSelector));

            string path = txtFileName.Text.Trim();

            if (path.Length > 0)
            {
                string fileName = "TxferExportList_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fullName = Path.Combine(path, fileName);

                engine.WriteFile(fullName, md);

                HttpResponse objResponse = this.Context.HttpContext.Response;

                objResponse.Clear();
                objResponse.ClearHeaders();

                objResponse.ContentType = "application/txt";
                objResponse.AddHeader("content-disposition", "attachment; filename=" + fileName);
                objResponse.BinaryWrite(File.ReadAllBytes(fullName));
                objResponse.Flush();
                objResponse.End();

                MessageBox.Show("Successful!\n " + fullName, "Message");
            }
            else
            {
                MessageBox.Show("Please input the file location!", "Warning");
            }
        }

        #endregion

        private void LoadData()
        {
            string sql = string.Empty;
            if (rbtnPosted.Checked)
            {
                sql = "SELECT * FROM vwDraftTxferList WHERE (POSTNEG = 1) AND (ReadOnly = 1) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "');";
                sql += "SELECT * FROM vwTxferDetailsList WHERE HeaderId IN (SELECT HeaderId FROM vwDraftTxferList WHERE (POSTNEG = 1) AND (ReadOnly = 1) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "'))";
            }
            else
            {
                sql = "SELECT * FROM vwDraftTxferList WHERE (POSTNEG = 0) AND (ReadOnly = 0) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "');";
                sql += "SELECT * FROM vwTxferDetailsList WHERE HeaderId IN (SELECT HeaderId FROM vwDraftTxferList WHERE (POSTNEG = 0) AND (ReadOnly = 0) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "'))";
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                FillMaster(dataset.Tables[0], dataset.Tables[1]);
            }
        }

        protected void FillMaster(DataTable masterTable, DataTable detailTable)
        {
            md = new MasterDetails[masterTable.Rows.Count];
            for (int i = 0; i < masterTable.Rows.Count; i++)
            {
                md[i] = new MasterDetails();
                DataRow row = masterTable.Rows[i];

                TxferTxtIEMaster oMaster = new TxferTxtIEMaster();

                oMaster.RecType = "HH";
                oMaster.FromLocation = row["FromLocation"].ToString();
                oMaster.ToLocation = row["ToLocation"].ToString();
                oMaster.Operator = row["StaffNumber"].ToString();
                oMaster.TxDate = Convert.ToDateTime(row["TxDate"]);
                oMaster.TxferDate = Convert.ToDateTime(row["TransferredOn"]);
                oMaster.CompletionDate = Convert.ToDateTime(row["CompletedOn"]);
                oMaster.RefNumber = row["Reference"].ToString();
                oMaster.Remarks = row["Remarks"].ToString();

                md[i].Master = oMaster;

                FillDetails(detailTable, row["HeaderId"].ToString(), ref md[i]);
            }
        }

        protected void FillDetails(DataTable detailTable, string headerId, ref MasterDetails mDetail)
        {
            DataRow[] rows = detailTable.Select("HeaderId = '" + headerId + "'");
            mDetail.Details = new object[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = rows[i];

                TxferTxtIEDetails oDetail = new TxferTxtIEDetails();

                oDetail.RecType = "DD";
                oDetail.StockCode = row["STKCODE"].ToString();
                oDetail.Appendix1 = row["APPENDIX1"].ToString();
                oDetail.Appendix2 = row["APPENDIX2"].ToString();
                oDetail.Appendix3 = row["APPENDIX3"].ToString();
                oDetail.RequiredQty = Convert.ToInt32(((decimal)row["QtyRequested"]).ToString("n0"));
                oDetail.TxferQty = Convert.ToInt32(((decimal)row["QtyReceived"]).ToString("n0"));
                oDetail.Remarks = row["Remarks"].ToString();

                mDetail.Details[i] = oDetail;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {

        }

        private void rbtnUnposted_CheckedChanged(object sender, EventArgs e)
        {
            FillComboList();
        }

        private void rbtnPosted_CheckedChanged(object sender, EventArgs e)
        {
            FillComboList();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();
            info.Append("File Structure").Append(" - Transfer").Append("\n\r").Append("\n\r");
            info.Append("The record content is listed as follows : ").Append("\n\r");
            info.Append("** Each field in a line is separated by a <TAB>. **").Append("\n\r").Append("\n\r");
            info.Append("Start (Row)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Transaction Type        - (TRF) ").Append("\n\r").Append("\n\r");
            info.Append("Header (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type        - (HH)").Append("\n\r");
            info.Append("2 -     From Location Code").Append("\n\r");
            info.Append("3 -     To Location Code").Append("\n\r");
            info.Append("4 -     Operator Code").Append("\n\r");
            info.Append("5 -     Transaction Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("6 -     Transfer Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("7 -     Completion Date        - (DDMMYYYY)").Append("\n\r");
            info.Append("8 -     Reference").Append("\n\r");
            info.Append("9 -     Remark(s)").Append("\n\r").Append("\n\r");
            info.Append("Detail (Column)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Record Type    - (DD)").Append("\n\r");
            info.Append("2 -     Stock Code").Append("\n\r");
            info.Append("3 -     Appendix1").Append("\n\r");
            info.Append("4 -     Appendix2").Append("\n\r");
            info.Append("5 -     Appendix3").Append("\n\r");
            info.Append("6 -     Required Qty").Append("\n\r");
            info.Append("7 -     Transfer Qty").Append("\n\r");
            info.Append("8 -     Remark(s)").Append("\n\r").Append("\n\r");
            info.Append("Footer (Row)").Append("\n\r");
            info.Append("----------------------------------------------------------------------------------------").Append("\n\r");
            info.Append("1 -     Total Header     - (TH + <TAB> + Number of Header)").Append("\n\r");
            info.Append("2 -     Total Detail     - (TD + <TAB> + Number of Detail)").Append("\n\r");
            info.Append("3 -     Record End     - (EE)").Append("\n\r");

            MessageBox.Show(info.ToString(), "Information for Transfer Import Txt file Structure");
        }
    }
}