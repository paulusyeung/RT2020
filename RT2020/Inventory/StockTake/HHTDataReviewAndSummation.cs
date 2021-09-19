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

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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
            Guid headerId = Guid.Empty;
            if (Guid.TryParse(dgvDataList.Rows[e.RowIndex].Cells[0].Value.ToString(), out headerId))
            {
                HHTDataReviewWizard wizReviewData = new HHTDataReviewWizard();
                wizReviewData.HHTHeaderId = headerId;
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
                Guid headerId = Guid.Empty;

                if (Guid.TryParse(row.Cells[0].Value.ToString(), out headerId))
                {
                    if (canPost)
                    {
                        PostHHTRecord(headerId);
                    }
                    else if (canDelete)
                    {
                        DeleteHHTRecord(headerId);
                    }
                }
            }
        }

        #region Post

        private void PostHHTRecord(Guid headerId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtHeader = ctx.StocktakeHeader_HHT.Find(headerId);
                if (hhtHeader != null)
                {
                    //string sql = "TxNumber = '" + hhtHeader.TxNumber + "'";
                    var stkHeader = StockTakeHeaderEx.GetByTxNumber(hhtHeader.TxNumber);
                    if (stkHeader != null)
                    {
                        if (!string.IsNullOrEmpty(stkHeader.ADJNUM) && stkHeader.PostedOn.Value.Year > 1900)
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
                        //string sql = "TxNumber = '" + txNumber + "'";

                        using (var ctx = new EF6.RT2020Entities())
                        {
                            var hhtHeader = ctx.StocktakeHeader_HHT
                                .Where(x => x.TxNumber == txNumber)
                                .FirstOrDefault();
                            if (hhtHeader != null)
                            {
                                var stkHeader = new EF6.StockTakeHeader();

                                stkHeader.HeaderId = Guid.NewGuid();
                                stkHeader.TxNumber = hhtHeader.TxNumber;
                                stkHeader.TxDate = DateTime.Now;
                                stkHeader.WorkplaceId = hhtHeader.WorkplaceId.Value;
                                stkHeader.Status = (int)EnumHelper.Status.Draft;
                                stkHeader.CreatedBy = ConfigHelper.CurrentUserId;
                                stkHeader.CreatedOn = DateTime.Now;
                                stkHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                stkHeader.ModifiedOn = DateTime.Now;

                                ctx.StockTakeHeader.Add(stkHeader);
                                ctx.SaveChanges();

                                Posting(hhtHeader.HeaderId, stkHeader.HeaderId);
                            }
                        }
                    }
                }
            }
        }

        private void Posting(Guid hhtHeaderId, Guid stkHeaderId)
        {
            if (hhtHeaderId != System.Guid.Empty && stkHeaderId != System.Guid.Empty)
            {

                using (var ctx = new EF6.RT2020Entities())
                {
                    var hhtHeader = ctx.StocktakeHeader_HHT.Find(hhtHeaderId);
                    if (hhtHeader != null)
                    {
                        hhtHeader.PostedOn = DateTime.Now;
                        hhtHeader.Status = (int)EnumHelper.Status.Active;
                        ctx.SaveChanges();

                        CheckDetails(hhtHeaderId, stkHeaderId, hhtHeader.WorkplaceId.Value);

                        var stkHeader = ctx.StockTakeHeader.Find(stkHeaderId);
                        if (stkHeader != null)
                        {
                            decimal totalCurQty = 0, totalStkQty = 0, totalCurAmt = 0, totalStkAmt = 0;

                            var stkDetailList = ctx.StockTakeDetails.Where(x => x.HeaderId == stkHeaderId);
                            foreach (var stkDetail in stkDetailList)
                            {
                                totalCurQty += stkDetail.CapturedQty.Value;
                                totalCurAmt += stkDetail.CapturedQty.Value * stkDetail.AverageCost.Value;
                                totalStkQty += stkDetail.HHTQty.Value + stkDetail.Book1Qty.Value + stkDetail.Book2Qty.Value + stkDetail.Book3Qty.Value + stkDetail.Book4Qty.Value + stkDetail.Book5Qty.Value;
                                totalStkAmt += (stkDetail.HHTQty.Value + stkDetail.Book1Qty.Value + stkDetail.Book2Qty.Value + stkDetail.Book3Qty.Value + stkDetail.Book4Qty.Value + stkDetail.Book5Qty.Value) * stkDetail.AverageCost.Value;
                            }

                            stkHeader.TotalQty = totalStkQty;
                            stkHeader.TotalAmount = totalStkAmt;
                            stkHeader.CapturedQty = totalCurQty;
                            stkHeader.CapturedAmount = totalCurAmt;
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }

        private void CheckDetails(Guid hhtHeaderId, Guid stkHeaderId, Guid workplaceId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtDetailList = ctx.StockTakeDetails_HHT.Where(x => x.HeaderId == hhtHeaderId).OrderBy(x => x.LineNumber);
                foreach (var hhtDetail in hhtDetailList)
                {
                    //sql = "HeaderId = '" + stkHeaderId + "' AND ProductId = '" + hhtDetail.ProductId.ToString() + "'";
                    var stkDetail = ctx.StockTakeDetails.Where(x => x.HeaderId == stkHeaderId && x.ProductId == hhtDetail.ProductId).FirstOrDefault();
                    //StockTakeDetails stkDetail = StockTakeDetails.LoadWhere(sql);
                    if (stkDetail == null)
                    {
                        stkDetail = new EF6.StockTakeDetails();
                        stkDetail.DetailsId = Guid.NewGuid();
                        stkDetail.HeaderId = stkHeaderId;
                        stkDetail.ProductId = hhtDetail.ProductId;
                        stkDetail.TxNumber = hhtDetail.TxNumber;
                        stkDetail.WorkplaceId = workplaceId;

                        stkDetail.HHTQty = hhtDetail.Qty;
                    }
                    stkDetail.AverageCost = ProductCurrentSummaryEx.GetAverageCode(stkDetail.ProductId.Value);
                    stkDetail.HHTQty = (stkDetail.HHTQty == null ? 0 : stkDetail.HHTQty) + hhtDetail.Qty;
                    ctx.SaveChanges();
                }
            }
        }

        #endregion

        #region Delete

        private void DeleteHHTRecord(Guid headerId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hhtHeader = ctx.StocktakeHeader_HHT.Find(headerId);
                //StocktakeHeader_HHT hhtHeader = StocktakeHeader_HHT.Load(headerId);
                if (hhtHeader != null)
                {
                    hhtHeader.PostedOn = DateTime.Now;
                    hhtHeader.Status = (int)EnumHelper.Status.Draft;
                    hhtHeader.Retired = true;
                    hhtHeader.RetiredBy = ConfigHelper.CurrentUserId;
                    hhtHeader.RetiredOn = DateTime.Now;

                    ctx.SaveChanges();
                }
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