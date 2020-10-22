#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.DAL;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class HHTDataReviewAndSummation : Form
    {
        int postColumnIndex = 1, deleteColumnIndex = 2;

        public HHTDataReviewAndSummation()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindList();

            postColumnIndex = colPost.Index;
            deleteColumnIndex = colDelete.Index;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Bind List

        private void BindList()
        {
            dgvDataList.AutoGenerateColumns = false;

            string sql = @"SELECT [HeaderId],[TxNumber],[WorkplaceId],[WorkplaceCode],[HHTId],[TotalRows],[TOTALQTY],[UploadedOn],[Status],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy]
                            FROM [dbo].[vwDraftSTKHHTList]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dgvDataList.DataSource = dataset.Tables[0];
            }
        }

        void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void dgvDataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isChecked = false;

            if (e.ColumnIndex == postColumnIndex)
            {
                isChecked = Convert.ToBoolean(dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                if (isChecked)
                {
                    dgvDataList.Rows[e.RowIndex].Cells[deleteColumnIndex].Value = !isChecked;
                }
            }
            else if (e.ColumnIndex == deleteColumnIndex)
            {
                isChecked = Convert.ToBoolean(dgvDataList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                if (isChecked)
                {
                    dgvDataList.Rows[e.RowIndex].Cells[postColumnIndex].Value = !isChecked;
                }
            }
        }

        private void dgvDataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string headerId = dgvDataList.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (RT2020.DAL.Common.Utility.IsGUID(headerId))
            {
                HHTDataReviewWizard wizReviewData = new HHTDataReviewWizard();
                wizReviewData.HHTHeaderId = new Guid(headerId);
                wizReviewData.ShowDialog();
            }
        }

        #region Summation

        private void btnSummation_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDataList.Rows)
            {
                bool canPost = Convert.ToBoolean(row.Cells[postColumnIndex].Value);
                bool canDelete = Convert.ToBoolean(row.Cells[deleteColumnIndex].Value);
                string headerId = row.Cells[0].Value.ToString();

                if (RT2020.DAL.Common.Utility.IsGUID(headerId))
                {
                    if (canPost)
                    {
                        PostHHTRecord(new Guid(headerId));
                    }
                    else if (canDelete)
                    {
                        DeleteHHTRecord(new Guid(headerId));
                    }
                }
            }
        }

        #region Post

        private void PostHHTRecord(Guid headerId)
        {
            StocktakeHeader_HHT hhtHeader = StocktakeHeader_HHT.Load(headerId);
            if (hhtHeader != null)
            {
                string sql = "TxNumber = '" + hhtHeader.TxNumber + "'";
                StockTakeHeader stkHeader = StockTakeHeader.LoadWhere(sql);
                if (stkHeader != null)
                {
                    if (!string.IsNullOrEmpty(stkHeader.ADJNUM) && stkHeader.PostedOn.Year > 1900)
                    {
                        MessageBox.Show("Stock Take# [" + hhtHeader.TxNumber + "] had been posted!", "ATTENTION");
                    }
                    else
                    {
                        Posting(hhtHeader.HeaderId, stkHeader.HeaderId);
                    }
                }
                else
                {
                    MessageBox.Show("Stock Take# [" + hhtHeader.TxNumber + "] worksheet does not exist! Create new one?", "ATTENTION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, new EventHandler(CreateNewWorksheet));
                }
            }
        }

        private void CreateNewWorksheet(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                string message = ((Form)sender).Controls[0].Text;
                if (!string.IsNullOrEmpty(message))
                {
                    int index = message.IndexOf('[');
                    if (index >= 0)
                    {
                        string txNumber = message.Substring(index + 1, 12);
                        string sql = "TxNumber = '" + txNumber + "'";
                        StocktakeHeader_HHT hhtHeader = StocktakeHeader_HHT.LoadWhere(sql);
                        if (hhtHeader != null)
                        {
                            StockTakeHeader stkHeader = new StockTakeHeader();
                            stkHeader.TxNumber = hhtHeader.TxNumber;
                            stkHeader.TxDate = DateTime.Now;
                            stkHeader.WorkplaceId = hhtHeader.WorkplaceId;
                            stkHeader.Status = (int)Common.Enums.Status.Draft;
                            stkHeader.CreatedBy = Common.Config.CurrentUserId;
                            stkHeader.CreatedOn = DateTime.Now;
                            stkHeader.ModifiedBy = Common.Config.CurrentUserId;
                            stkHeader.ModifiedOn = DateTime.Now;
                            stkHeader.Save();

                            Posting(hhtHeader.HeaderId, stkHeader.HeaderId);
                        }
                    }
                }
            }
        }

        private void Posting(Guid hhtHeaderId, Guid stkHeaderId)
        {
            if (hhtHeaderId != System.Guid.Empty && stkHeaderId != System.Guid.Empty)
            {
                StocktakeHeader_HHT hhtHeader = StocktakeHeader_HHT.Load(hhtHeaderId);
                if (hhtHeader != null)
                {
                    hhtHeader.PostedOn = DateTime.Now;
                    hhtHeader.Status = (int)Common.Enums.Status.Active;
                    hhtHeader.Save();

                    CheckDetails(hhtHeaderId, stkHeaderId, hhtHeader.WorkplaceId);

                    StockTakeHeader stkHeader = StockTakeHeader.Load(stkHeaderId);
                    if (stkHeader != null)
                    {
                        decimal totalCurQty = 0, totalStkQty = 0, totalCurAmt = 0, totalStkAmt = 0;
                        string sql = "HeaderId = '" + stkHeaderId + "'";
                        StockTakeDetailsCollection stkDetailList = StockTakeDetails.LoadCollection(sql);
                        foreach (StockTakeDetails stkDetail in stkDetailList)
                        {
                            totalCurQty += stkDetail.CapturedQty;
                            totalCurAmt += stkDetail.CapturedQty * stkDetail.AverageCost;
                            totalStkQty += stkDetail.HHTQty + stkDetail.Book1Qty + stkDetail.Book2Qty + stkDetail.Book3Qty + stkDetail.Book4Qty + stkDetail.Book5Qty;
                            totalStkAmt += (stkDetail.HHTQty + stkDetail.Book1Qty + stkDetail.Book2Qty + stkDetail.Book3Qty + stkDetail.Book4Qty + stkDetail.Book5Qty) * stkDetail.AverageCost;
                        }

                        stkHeader.TotalQty = totalStkQty;
                        stkHeader.TotalAmount = totalStkAmt;
                        stkHeader.CapturedQty = totalCurQty;
                        stkHeader.CapturedAmount = totalCurAmt;
                        stkHeader.Save();
                    }
                }
            }
        }

        private void CheckDetails(Guid hhtHeaderId, Guid stkHeaderId, Guid workplaceId)
        {
            string sql = "HeaderId = '" + hhtHeaderId + "'";
            StockTakeDetails_HHTCollection hhtDetailList = StockTakeDetails_HHT.LoadCollection(sql, new string[] { "LineNumber" }, true);
            foreach (StockTakeDetails_HHT hhtDetail in hhtDetailList)
            {
                sql = "HeaderId = '" + stkHeaderId + "' AND ProductId = '" + hhtDetail.ProductId.ToString() + "'";
                StockTakeDetails stkDetail = StockTakeDetails.LoadWhere(sql);
                if (stkDetail == null)
                {
                    stkDetail = new StockTakeDetails();
                    stkDetail.HeaderId = stkHeaderId;
                    stkDetail.ProductId = hhtDetail.ProductId;
                    stkDetail.TxNumber = hhtDetail.TxNumber;
                    stkDetail.WorkplaceId = workplaceId;

                    stkDetail.HHTQty = hhtDetail.Qty;
                }
                stkDetail.AverageCost = GetAverageCost(stkDetail.ProductId);
                stkDetail.HHTQty = (stkDetail.HHTQty == null ? 0 : stkDetail.HHTQty) + hhtDetail.Qty;
                stkDetail.Save();
            }
        }

        private decimal GetAverageCost(Guid productId)
        {
            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary currSummary = ProductCurrentSummary.LoadWhere(sql);
            if (currSummary != null)
            {
                return currSummary.AverageCost;
            }

            return 0;
        }

        #endregion

        #region Delete

        private void DeleteHHTRecord(Guid headerId)
        {
            StocktakeHeader_HHT hhtHeader = StocktakeHeader_HHT.Load(headerId);
            if (hhtHeader != null)
            {
                hhtHeader.PostedOn = DateTime.Now;
                hhtHeader.Status = (int)Common.Enums.Status.Draft;
                hhtHeader.Retired = true;
                hhtHeader.RetiredBy = Common.Config.CurrentUserId;
                hhtHeader.RetiredOn = DateTime.Now;

                hhtHeader.Save();
            }
        }

        #endregion

        #endregion

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDataList.Rows)
            {
                row.Cells[postColumnIndex].Value = btnMarkAll.Text.Contains("Mark");
            }

            btnMarkAll.Text = btnMarkAll.Text.Contains("Mark") ? "Unmark All" : "Mark All";
        }
    }
}