using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.DAL;
using RT2020.Controls;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Reset Service Items' Qty
    /// </summary>
    public class Step01 : IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        /// <summary>
        /// Does the action.
        /// </summary>
        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step01 Processing ...", 1, 100));

            this.Reset();
        }

        #endregion

        string txNumber = string.Empty;

        /// <summary>
        /// Resets this instance.
        /// </summary>
        /// <returns></returns>
        private bool Reset()
        {
            string sql = string.Empty;
            DateTime txDate = DateTime.Now;
            Guid headerId = Guid.Empty;
            Guid ledgerId = Guid.Empty;

            // Check service item's CDQty
            sql = @"SELECT   pw.WorkplaceId, pw.ProductId, SUM(pw.CDQty) AS CDQTY
                    FROM         (SELECT     NatureId
                       FROM          dbo.ProductNature
                       WHERE      (NatureCode = 'S')) AS sn INNER JOIN
                      dbo.Product AS p ON sn.NatureId = p.NatureId INNER JOIN
                      dbo.ProductWorkplace AS pw ON p.ProductId = pw.ProductId
                    WHERE     (pw.CDQTY <> 0)
                    GROUP BY pw.WorkplaceId, pw.ProductId
                    ORDER BY pw.WorkplaceId";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    // Transaction Date
                    if (SystemInfo.CurrentInfo.Default.CurrentSystemDate.Month == DateTime.Now.Month &&
                        SystemInfo.CurrentInfo.Default.CurrentSystemDate.Year == DateTime.Now.Year)
                    {
                        txDate = DateTime.Now;
                    }
                    else
                    {
                        txDate = SystemInfo.CurrentInfo.Default.CurrentSystemDate.AddMonths(1).AddDays(-1);
                    }

                    // If record(s) found then generating ADJ transaction
                    // Create ADJ Header
                    headerId = this.CreateAdjSubLedgerHeader(headerId, txDate, reader.GetGuid(0));

                    // Create ADJ Details
                    if (headerId != Guid.Empty)
                    {
                        this.CreatedAdjSubLedgerDetails(headerId, reader.GetGuid(1), reader.GetDecimal(2));

                        // Update total amount
                        this.UpdateHeader(headerId);
                    }

                    // Generating Ledger record(s)
                    // Create Ledger header
                    ledgerId = this.CreateLedgerHeader(ledgerId, headerId);

                    // Create ledger Details
                    if (ledgerId != Guid.Empty)
                    {
                        this.CreateLedgerDetails(ledgerId, headerId, txDate, reader.GetGuid(0));
                    }

                    // Reset All Service Item's CDQTY = 0
                    this.ResetCDQty(headerId);
                }
            }

            return true;
        }

        #region Sub Ledger

        /// <summary>
        /// Creates the adj sub ledger header.
        /// </summary>
        private Guid CreateAdjSubLedgerHeader(Guid srcHeaderId, DateTime txDate, Guid workplaceId)
        {
            Guid headerId = Guid.Empty;

            string sql = "HeaderId = '" + srcHeaderId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";

            InvtSubLedgerADJ_Header objHeader = InvtSubLedgerADJ_Header.LoadWhere(sql);
            if (objHeader == null)
            {
                objHeader = new InvtSubLedgerADJ_Header();
                objHeader.TxNumber = SystemInfo.Settings.QueuingTxNumber(RT2020.DAL.Common.Enums.TxType.ADJ);
                objHeader.TxType = RT2020.DAL.Common.Enums.TxType.ADJ.ToString();
                objHeader.TxDate = txDate;
                objHeader.WorkplaceId = workplaceId;
                objHeader.TotalAmount = 0;
                objHeader.Reference = string.Empty;
                objHeader.Remarks = "GENERATED FROM MONTH END.";
                objHeader.Status = (int)RT2020.DAL.Common.Enums.Status.Active;
                objHeader.StaffId = Common.Config.CurrentUserId;
                objHeader.PostedBy = Common.Config.CurrentUserId;
                objHeader.PostedOn = DateTime.Now;

                objHeader.CreatedBy = Common.Config.CurrentUserId;
                objHeader.CreatedOn = DateTime.Now;
                objHeader.ModifiedBy = Common.Config.CurrentUserId;
                objHeader.ModifiedOn = DateTime.Now;

                objHeader.Save();
            }

            headerId = objHeader.HeaderId;
            txNumber = objHeader.TxNumber;

            return headerId;
        }

        /// <summary>
        /// Createds the adj sub ledger details.
        /// </summary>
        private void CreatedAdjSubLedgerDetails(Guid headerId, Guid productId, decimal cdQty)
        {
            InvtSubLedgerADJ_Details objDetail = new InvtSubLedgerADJ_Details();
            objDetail.HeaderId = headerId;
            objDetail.TxNumber = txNumber;
            objDetail.LineNumber = 0;
            objDetail.TxType = RT2020.DAL.Common.Enums.TxType.ADJ.ToString();
            objDetail.ProductId = productId;
            objDetail.Qty = Math.Abs(cdQty) * (-1);
            objDetail.AverageCost = GetAverageCost(productId);
            objDetail.ReasonCode = string.Empty;
            objDetail.Remarks = string.Empty;

            objDetail.Save();
        }

        /// <summary>
        /// Updates the header.
        /// </summary>
        private void UpdateHeader(Guid headerId)
        {
            string sql = "HeaderId = '" + headerId.ToString() + "'";
            decimal totalAmt = 0;

            InvtSubLedgerADJ_DetailsCollection detailList = InvtSubLedgerADJ_Details.LoadCollection(sql);
            for (int i = 0; i < detailList.Count; i++)
            {
                totalAmt += detailList[i].Qty * detailList[i].AverageCost;
            }

            InvtSubLedgerADJ_Header objHeader = InvtSubLedgerADJ_Header.Load(headerId);
            if (objHeader != null)
            {
                objHeader.TotalAmount = totalAmt;
                objHeader.Save();
            }
        }

        #endregion

        #region Ledger

        /// <summary>
        /// Creates the ledger header.
        /// </summary>
        /// <param name="subLedgerHeaderId">The sub ledger header id.</param>
        private Guid CreateLedgerHeader(Guid srcHeaderId, Guid subLedgerHeaderId)
        {
            Guid headerId = Guid.Empty;

            InvtSubLedgerADJ_Header objSubHeader = InvtSubLedgerADJ_Header.Load(subLedgerHeaderId);
            if (objSubHeader != null)
            {
                string query = "HeaderId = '" + srcHeaderId.ToString() + "' AND SubLedgerHeaderId = '" + objSubHeader.HeaderId.ToString() + "'";
                InvtLedgerHeader objHeader = InvtLedgerHeader.LoadWhere(query);
                if (objHeader == null)
                {
                    objHeader = new InvtLedgerHeader();
                    objHeader.TxNumber = objSubHeader.TxNumber;
                    objHeader.TxDate = objSubHeader.TxDate;
                    objHeader.TxType = objSubHeader.TxType;
                    objHeader.SubLedgerHeaderId = objSubHeader.HeaderId;
                    objHeader.WorkplaceId = objSubHeader.WorkplaceId;
                    objHeader.TotalAmount = objSubHeader.TotalAmount;
                    objHeader.Reference = objSubHeader.Reference;
                    objHeader.Remarks = objSubHeader.Remarks;
                    objHeader.StaffId = objSubHeader.StaffId;
                    objHeader.Status = (int)RT2020.DAL.Common.Enums.Status.Active;

                    objHeader.CreatedBy = Common.Config.CurrentUserId;
                    objHeader.CreatedOn = DateTime.Now;
                    objHeader.ModifiedBy = Common.Config.CurrentUserId;
                    objHeader.ModifiedOn = DateTime.Now;

                    objHeader.Save();
                }
            }

            return headerId;
        }

        /// <summary>
        /// Creates the ledger details.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <param name="subLedgerHeaderId">The sub ledger header id.</param>
        private void CreateLedgerDetails(Guid headerId, Guid subLedgerHeaderId, DateTime txDate, Guid workplaceId)
        {
            string query = "HeaderId = '" + subLedgerHeaderId.ToString() + "'";
            InvtSubLedgerADJ_DetailsCollection detailList = InvtSubLedgerADJ_Details.LoadCollection(query);
            for (int i = 0; i < detailList.Count; i++)
            {
                InvtSubLedgerADJ_Details detail = detailList[i];
                if (detail != null)
                {
                    query = "HeaderId = '" + headerId.ToString() + "' AND ProductId = '" + detail.ProductId.ToString() + "'";
                    InvtLedgerDetails objDetail = InvtLedgerDetails.LoadWhere(query);
                    if (objDetail == null)
                    {
                        objDetail = new InvtLedgerDetails();

                        objDetail.HeaderId = headerId;
                        objDetail.TxType = detail.TxType;
                        objDetail.TxNumber = detail.TxNumber;
                        objDetail.LineNumber = 0;
                        objDetail.ProductId = detail.ProductId;
                        objDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(workplaceId);
                        objDetail.TxDate = txDate;
                        objDetail.OPERATOR = ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);
                        objDetail.Qty = detail.Qty;
                        objDetail.AverageCost = detail.AverageCost;
                        objDetail.UnitAmount = detail.AverageCost;
                        objDetail.Amount = detail.AverageCost * detail.Qty;

                        objDetail.Save();
                    }
                }
            }
        }

        #endregion

        #region Reset All Service Items's CDQty

        /// <summary>
        /// Resets the CD qty.
        /// </summary>
        /// <param name="headerId">The header id. (Invt SubLedger)</param>
        private void ResetCDQty(Guid headerId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var objHeader = ctx.InvtSubLedgerADJ_Header.Find(headerId);
                        if (objHeader != null)
                        {
                            string query = "HeaderId = '" + objHeader.HeaderId.ToString() + "'";
                            var detailList = ctx.InvtSubLedgerADJ_Details.Where(x => x.HeaderId == objHeader.HeaderId);
                            foreach (var detail in detailList)
                            //for (int i = 0; i < detailList.Count; i++)
                            {
                                // Reset CDQty in Current summary
                                //query = "ProductId = '" + detail.ProductId.ToString() + "'";
                                var currSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == detail.ProductId).FirstOrDefault();
                                if (currSummary != null)
                                {
                                    currSummary.CDQTY += detail.Qty.Value;
                                }

                                // Reset CDQty in Current Workplace summary
                                //query += " AND WorkplaceId = '" + objHeader.WorkplaceId.ToString() + "'";
                                var currWorkplace = ctx.ProductWorkplace.Where(x => x.ProductId == detail.ProductId && x.WorkplaceId == objHeader.WorkplaceId).FirstOrDefault();
                                if (currWorkplace != null)
                                {
                                    currWorkplace.CDQTY += detail.Qty.Value;
                                }
                            }
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

        #endregion

        /// <summary>
        /// Gets the average cost.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        private decimal GetAverageCost(Guid productId)
        {
            decimal result = 0;

            string sql = "ProductId = '" + productId.ToString() + "'";
            ProductCurrentSummary currSum = ProductCurrentSummary.LoadWhere(sql);
            if (currSum != null)
            {
                result = currSum.AverageCost;
            }

            return result;
        }
    }
}
