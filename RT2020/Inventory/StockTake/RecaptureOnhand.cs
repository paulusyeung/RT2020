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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Inventory.StockTake
{
    public partial class RecaptureOnhand : Form
    {
        public RecaptureOnhand()
        {
            InitializeComponent();
            FillListBox();
        }

        #region Fill ListBox
        private void FillListBox()
        {
            lbStockTakeList.Items.Clear();

            using (var ctx = new EF6.RT2020Entities())
            {
                string[] orderBy = new string[] { "TxNumber" };
                string sql = " YEAR(PostedOn) = 1900 AND LEN(ADJNUM) = 0 ";
                var stkHeaderList = ctx.StockTakeHeader.Where(x => x.PostedOn.Value.Year == 1900 && x.ADJNUM.Length == 0).OrderBy(x => x.TxNumber).AsNoTracking().ToList();
                foreach (var stkHeader in stkHeaderList)
                {
                    StringBuilder stk = new StringBuilder();
                    stk.Append(stkHeader.TxNumber);
                    stk.Append(" - ");
                    stk.Append(ModelEx.WorkplaceEx.GetWorkplaceCodeById(stkHeader.WorkplaceId.Value));
                    lbStockTakeList.Items.Add(stk.ToString());
                }
            }
        }
        #endregion

        #region Recapture Procedure
        private int Recapture()
        {
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = lbStockTakeList.CheckedItems.Count - 1;

            int iCount = 0;

            for (int i = 0; i < lbStockTakeList.CheckedItems.Count; i++)
            {
                string checkedStr = lbStockTakeList.CheckedItems[i].ToString();
                string txNumber = checkedStr.Remove(checkedStr.IndexOf('-')).Trim();
                System.Guid stkHeaderId = RecaptureSTK(txNumber);

                SetProgress(i, "");
                if (stkHeaderId != System.Guid.Empty)
                {
                    iCount++;
                }
            }

            return iCount;
        }

        private Guid RecaptureSTK(string txNumber)
        {
            Guid stkHeaderId = Guid.Empty;

            var stkHeader = ModelEx.StockTakeHeaderEx.GetByTxNumber(txNumber);
            if (stkHeader != null)
            {
                stkHeaderId = stkHeader.HeaderId;
                RecaptureStkDetails(stkHeaderId);
            }
            return stkHeaderId;
        }

        private void RecaptureStkDetails(System.Guid stkheaderId)
        {
            decimal qty = 0, amount = 0, totalQty = 0, totalAmt = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //string sql = "HeaderId = '" + stkheaderId.ToString() + "'";
                        var stkDetailsList = ctx.StockTakeDetails.Where(x => x.HeaderId == stkheaderId);
                        foreach (var stkDetail in stkDetailsList)
                        {
                            //sql = "ProductId = '" + stkDetail.ProductId.ToString() + "'";
                            var currSum = ctx.ProductCurrentSummary.Where(x => x.ProductId == stkDetail.ProductId).FirstOrDefault();
                            if (currSum != null)
                            {
                                stkDetail.AverageCost = currSum.AverageCost;
                            }

                            //sql += " AND WorkplaceId = '" + stkDetail.WorkplaceId.ToString() + "'";
                            var wpProd = ctx.ProductWorkplace.Where(x => x.ProductId == stkDetail.ProductId && x.WorkplaceId == stkDetail.WorkplaceId).FirstOrDefault();
                            if (wpProd != null)
                            {
                                stkDetail.CapturedQty = wpProd.CDQTY;
                            }
                            else
                            {
                                stkDetail.CapturedQty = 0;
                            }

                            stkDetail.ModifiedBy = Common.Config.CurrentUserId;
                            stkDetail.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();

                            #region 累計 Qty Amount TotalQty TotalAmt
                            qty += stkDetail.CapturedQty.Value;
                            amount += stkDetail.CapturedQty.Value * stkDetail.AverageCost.Value;

                            decimal tempQty = stkDetail.HHTQty.Value + stkDetail.Book1Qty.Value + stkDetail.Book2Qty.Value + stkDetail.Book3Qty.Value + stkDetail.Book4Qty.Value + stkDetail.Book5Qty.Value;
                            totalQty += tempQty;
                            totalAmt += tempQty * stkDetail.AverageCost.Value;
                            #endregion
                        }

                        var stkHeader = ctx.StockTakeHeader.Find(stkheaderId);
                        if (stkHeader != null)
                        {
                            stkHeader.CapturedOn = DateTime.Now;
                            stkHeader.CapturedAmount = amount;
                            stkHeader.CapturedQty = qty;
                            stkHeader.TotalQty = totalQty;
                            stkHeader.TotalAmount = totalAmt;
                            stkHeader.ModifiedBy = Common.Config.CurrentUserId;
                            stkHeader.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }

        private void SetProgress(int value, string message)
        {
            progressBar1.Visible = true;
            progressBar1.Value = value;
            progressBar1.Text = message;

            progressBar1.Show();
        }
        #endregion

        private void btnRecapture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Re-Capture?", "Recapture Confirmation", MessageBoxButtons.YesNo, new EventHandler(ConfirmationMessageHandler));
        }

        private void ConfirmationMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                int result = Recapture();
                if (result > 0)
                {
                    MessageBox.Show(result.ToString() + " Transaction(s) Creation Complete !", "Creation Succeed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, new EventHandler(RecaptureMessageHandler));
                }
                else
                {
                    MessageBox.Show("Error Occurred, Creation Aborted!", "Creation Failed");
                }
            }
        }

        private void RecaptureMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                FillListBox();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}