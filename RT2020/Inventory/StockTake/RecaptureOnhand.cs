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

            string[] orderBy = new string[] { "TxNumber" };
            string sql = " YEAR(PostedOn) = 1900 AND LEN(ADJNUM) = 0 ";
            StockTakeHeaderCollection stkHeaderList = StockTakeHeader.LoadCollection(sql, orderBy, true);
            foreach (StockTakeHeader stkHeader in stkHeaderList)
            {
                StringBuilder stk = new StringBuilder();
                stk.Append(stkHeader.TxNumber);
                stk.Append(" - ");
                stk.Append(GetWorkplaceCode(stkHeader.WorkplaceId));
                lbStockTakeList.Items.Add(stk.ToString());
            }
        }

        private string GetWorkplaceCode(Guid wpId)
        {
            RT2020.DAL.Workplace wp = RT2020.DAL.Workplace.Load(wpId);
            if (wp != null)
            {
                return wp.WorkplaceCode;
            }
            else
            {
                return string.Empty;
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
            System.Guid stkHeaderId = System.Guid.Empty;
            string sql = "TxNumber = '" + txNumber + "'";
            StockTakeHeader stkHeader = StockTakeHeader.LoadWhere(sql);
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
            string sql = "HeaderId = '" + stkheaderId.ToString() + "'";
            StockTakeDetailsCollection stkDetailsList = StockTakeDetails.LoadCollection(sql);
            foreach (StockTakeDetails stkDetail in stkDetailsList)
            {
                sql = "ProductId = '" + stkDetail.ProductId.ToString() + "'";
                ProductCurrentSummary currSum = ProductCurrentSummary.LoadWhere(sql);
                if (currSum != null)
                {
                    stkDetail.AverageCost = currSum.AverageCost;
                }

                sql += " AND WorkplaceId = '" + stkDetail.WorkplaceId.ToString() + "'";
                ProductWorkplace wpProd = ProductWorkplace.LoadWhere(sql);
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
                stkDetail.Save();

                qty += stkDetail.CapturedQty;
                amount += stkDetail.CapturedQty * stkDetail.AverageCost;

                decimal tempQty = stkDetail.HHTQty + stkDetail.Book1Qty + stkDetail.Book2Qty + stkDetail.Book3Qty + stkDetail.Book4Qty + stkDetail.Book5Qty;
                totalQty += tempQty;
                totalAmt += tempQty * stkDetail.AverageCost;
            }

            StockTakeHeader stkHeader = StockTakeHeader.Load(stkheaderId);
            if (stkHeader != null)
            {
                stkHeader.CapturedOn = DateTime.Now;
                stkHeader.CapturedAmount = amount;
                stkHeader.CapturedQty = qty;
                stkHeader.TotalQty = totalQty;
                stkHeader.TotalAmount = totalAmt;
                stkHeader.ModifiedBy = Common.Config.CurrentUserId;
                stkHeader.ModifiedOn = DateTime.Now;
                stkHeader.Save();
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