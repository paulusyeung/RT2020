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

#endregion

namespace RT2020.Inventory.GoodsReceive.Export
{
    public partial class Export2Txt : Form, IGatewayComponent
    {
        MasterDetails[] md;
        int headerCount = 0;
        int detailsCount = 0;

        public Export2Txt()
        {
            InitializeComponent();
            FillComboList();
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

            if (rbtnPosted.Checked)
            {
                ModelEx.InvtSubLedgerCAP_HeaderEx.LoadCombo(ref cboFrom, "TxNumber", false, false, string.Empty, "TxType = 'CAP'");
            }
            else
            {
                InvtBatchCAP_Header.LoadCombo(ref cboFrom, "TxNumber", false, false, string.Empty, "TxType = 'CAP'");
            }
        }

        private void FillToList()
        {
            cboTo.DataSource = null;

            cboTo.Items.Clear();

            if (rbtnPosted.Checked)
            {
                ModelEx.InvtSubLedgerCAP_HeaderEx.LoadCombo(ref cboTo, "TxNumber", false, false, string.Empty, "TxType = 'CAP'");
            }
            else
            {
                InvtBatchCAP_Header.LoadCombo(ref cboTo, "TxNumber", false, false, string.Empty, "TxType = 'CAP'");
            }

            if (cboTo.Items.Count > 0)
            {
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
            Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
        }

        private void rbtnUnposted_CheckedChanged(object sender, EventArgs e)
        {
            FillComboList();
        }

        private void rbtnPosted_CheckedChanged(object sender, EventArgs e)
        {
            FillComboList();
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

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {

            MasterDetailEngine engine = new MasterDetailEngine(typeof(CAPTxtIEMaster), typeof(CAPTxtIEDetails), new MasterDetailSelector(RecSelector));

            LoadData();

            string path = Path.Combine(Context.Config.GetDirectory("Upload"), "Member");
            string fileName = "CAPExportList_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullName = Path.Combine(path, fileName);

            // Header
            FileStream stream = File.Open(fullName, FileMode.CreateNew, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("CAP");
            writer.Flush();
            writer.Close();

            // Details
            engine.AppendToFile(fullName, md);

            // Footer            
            writer = File.AppendText(fullName);
            writer.WriteLine("TH\t" + headerCount.ToString());
            writer.WriteLine("TD\t" + detailsCount.ToString());
            writer.WriteLine("EE");
            writer.Flush();
            writer.Close();


            HttpResponse objResponse = this.Context.HttpContext.Response;

            objResponse.Clear();
            objResponse.ClearHeaders();

            objResponse.ContentType = "application/txt";
            objResponse.AddHeader("content-disposition", "attachment; filename=" + fileName);
            objResponse.BinaryWrite(File.ReadAllBytes(fullName));
            objResponse.Flush();
            objResponse.End();

        }

        #endregion

        private void LoadData()
        {
            string sql = string.Empty;
            if (rbtnPosted.Checked)
            {
                sql = "SELECT DISTINCT HeaderId, TxNumber, LocationCode AS Location, OperatorCode AS StaffNumber, TxDate, SupplierCode, Reference, Remarks FROM [vwRptSubLedgerCAP] WHERE (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "');";
                sql += "SELECT HeaderId, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ISNULL(Qty, 0) AS Qty, ISNULL(UnitAmount, 0) AS UnitAmount FROM [vwRptSubLedgerCAP] WHERE (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "')";
            }
            else
            {
                sql = "SELECT * FROM vwDraftCAPList WHERE (ReadOnly = 0) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "');";
                sql += "SELECT * FROM vwCAPDetailsList WHERE HeaderId IN (SELECT HeaderId FROM vwDraftCAPList WHERE (ReadOnly = 0) AND (TxNumber >= '" + cboFrom.Text + "') AND (TxNumber <= '" + cboTo.Text + "'))";
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

                CAPTxtIEMaster oMaster = new CAPTxtIEMaster();

                oMaster.RecType = "HH";
                oMaster.Location = row["Location"].ToString();
                oMaster.Operator = row["StaffNumber"].ToString();
                oMaster.RecvDate = Convert.ToDateTime(row["TxDate"]);
                oMaster.Supplier = row["SupplierCode"].ToString();
                oMaster.RefNumber = row["Reference"].ToString();
                oMaster.Remarks = row["Remarks"].ToString();
                oMaster.TxNumber = row["TxNumber"].ToString();

                md[i].Master = oMaster;

                headerCount++;

                FillDetails(detailTable, row["HeaderId"].ToString(), ref md[i]);
            }
        }

        protected void FillDetails(DataTable detailTable, string headerId, ref MasterDetails mDetail)
        {
            DataRow[] rows = detailTable.Select("HeaderId = '" + headerId + "'");

            if (rows.Length > 0)
            {
                mDetail.Details = new object[rows.Length];

                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rows[i];

                    CAPTxtIEDetails oDetail = new CAPTxtIEDetails();

                    oDetail.RecType = "DD";
                    oDetail.StockCode = row["STKCODE"].ToString();
                    oDetail.Appendix1 = row["APPENDIX1"].ToString();
                    oDetail.Appendix2 = row["APPENDIX2"].ToString();
                    oDetail.Appendix3 = row["APPENDIX3"].ToString();
                    //oDetail.ReceivedQty = Convert.ToInt32(((decimal)row["Qty"]).ToString("n0"));
                    oDetail.ReceivedQty = Convert.ToInt32((decimal)row["Qty"]);
                    oDetail.ReceivedUnitAmount = (decimal)row["UnitAmount"];

                    mDetail.Details[i] = oDetail;

                    detailsCount++;
                }
            }
        }
    }
}