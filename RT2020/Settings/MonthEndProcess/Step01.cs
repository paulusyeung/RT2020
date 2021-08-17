using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

using RT2020.Controls;
using RT2020.Helper;
using RT2020.ModelEx;

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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    // Transaction Date
                    if (SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.Month == DateTime.Now.Month &&
                        SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.Year == DateTime.Now.Year)
                    {
                        txDate = DateTime.Now;
                    }
                    else
                    {
                        txDate = SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.AddMonths(1).AddDays(-1);
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

            using (var ctx = new EF6.RT2020Entities())
            {
                var objHeader = ctx.InvtSubLedgerADJ_Header.Where(x => x.HeaderId == srcHeaderId && x.WorkplaceId == workplaceId).FirstOrDefault();
                if (objHeader == null)
                {
                    objHeader = new EF6.InvtSubLedgerADJ_Header();
                    objHeader.HeaderId = Guid.NewGuid();
                    objHeader.TxNumber = SystemInfoHelper.Settings.QueuingTxNumber(EnumHelper.TxType.ADJ);
                    objHeader.TxType = EnumHelper.TxType.ADJ.ToString();
                    objHeader.TxDate = txDate;
                    objHeader.WorkplaceId = workplaceId;
                    objHeader.TotalAmount = 0;
                    objHeader.Reference = string.Empty;
                    objHeader.Remarks = "GENERATED FROM MONTH END.";
                    objHeader.Status = (int)EnumHelper.Status.Active;
                    objHeader.StaffId = ConfigHelper.CurrentUserId;
                    objHeader.PostedBy = ConfigHelper.CurrentUserId;
                    objHeader.PostedOn = DateTime.Now;

                    objHeader.CreatedBy = ConfigHelper.CurrentUserId;
                    objHeader.CreatedOn = DateTime.Now;
                    objHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                    objHeader.ModifiedOn = DateTime.Now;

                    ctx.InvtSubLedgerADJ_Header.Add(objHeader);
                    ctx.SaveChanges();
                }

                headerId = objHeader.HeaderId;
                txNumber = objHeader.TxNumber;
            }

            return headerId;
        }

        /// <summary>
        /// Createds the adj sub ledger details.
        /// </summary>
        private void CreatedAdjSubLedgerDetails(Guid headerId, Guid productId, decimal cdQty)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var objDetail = new EF6.InvtSubLedgerADJ_Details();
                objDetail.DetailsId = Guid.NewGuid();
                objDetail.HeaderId = headerId;
                objDetail.TxNumber = txNumber;
                objDetail.LineNumber = 0;
                objDetail.TxType = EnumHelper.TxType.ADJ.ToString();
                objDetail.ProductId = productId;
                objDetail.Qty = Math.Abs(cdQty) * (-1);
                objDetail.AverageCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(productId);
                objDetail.ReasonCode = string.Empty;
                objDetail.Remarks = string.Empty;

                ctx.InvtSubLedgerADJ_Details.Add(objDetail);
            }
        }

        /// <summary>
        /// Updates the header.
        /// </summary>
        private void UpdateHeader(Guid headerId)
        {
            string sql = "HeaderId = '" + headerId.ToString() + "'";
            decimal totalAmt = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                var detailList = ctx.InvtSubLedgerADJ_Details.Where(x => x.HeaderId == headerId);
                foreach (var detail in detailList)
                {
                    totalAmt += detail.Qty.Value * detail.AverageCost.Value;
                }

                var objHeader = ctx.InvtSubLedgerADJ_Header.Find(headerId);
                if (objHeader != null)
                {
                    objHeader.TotalAmount = totalAmt;
                    ctx.SaveChanges();
                }
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

            using (var ctx = new EF6.RT2020Entities())
            {
                var objSubHeader = ctx.InvtSubLedgerADJ_Header.Find(subLedgerHeaderId);
                if (objSubHeader != null)
                {
                    string query = "HeaderId = '" + srcHeaderId.ToString() + "' AND SubLedgerHeaderId = '" + objSubHeader.HeaderId.ToString() + "'";
                    var objHeader = ctx.InvtLedgerHeader.Where(x => x.HeaderId == srcHeaderId && x.SubLedgerHeaderId == objSubHeader.HeaderId).FirstOrDefault();
                    if (objHeader == null)
                    {
                        objHeader = new EF6.InvtLedgerHeader();
                        objHeader.HeaderId = Guid.NewGuid();
                        objHeader.TxNumber = objSubHeader.TxNumber;
                        objHeader.TxDate = objSubHeader.TxDate;
                        objHeader.TxType = objSubHeader.TxType;
                        objHeader.SubLedgerHeaderId = objSubHeader.HeaderId;
                        objHeader.WorkplaceId = objSubHeader.WorkplaceId;
                        objHeader.TotalAmount = objSubHeader.TotalAmount;
                        objHeader.Reference = objSubHeader.Reference;
                        objHeader.Remarks = objSubHeader.Remarks;
                        objHeader.StaffId = objSubHeader.StaffId;
                        objHeader.Status = (int)EnumHelper.Status.Active;

                        objHeader.CreatedBy = ConfigHelper.CurrentUserId;
                        objHeader.CreatedOn = DateTime.Now;
                        objHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                        objHeader.ModifiedOn = DateTime.Now;

                        ctx.InvtLedgerHeader.Add(objHeader);
                        ctx.SaveChanges();
                    }
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

            using (var ctx = new EF6.RT2020Entities())
            {
                var detailList = ctx.InvtSubLedgerADJ_Details.Where(x => x.HeaderId == subLedgerHeaderId);
                foreach (var detail in detailList)
                {
                    //InvtSubLedgerADJ_Details detail = detailList[i];
                    //if (detail != null)
                    //{
                        query = "HeaderId = '" + headerId.ToString() + "' AND ProductId = '" + detail.ProductId.ToString() + "'";
                        var objDetail = ctx.InvtLedgerDetails.Where(x => x.HeaderId == headerId && x.ProductId == detail.ProductId).FirstOrDefault();
                        if (objDetail == null)
                        {
                            objDetail = new EF6.InvtLedgerDetails();
                        objDetail.DetailsId = Guid.NewGuid();
                            objDetail.HeaderId = headerId;
                            objDetail.TxType = detail.TxType;
                            objDetail.TxNumber = detail.TxNumber;
                            objDetail.LineNumber = 0;
                            objDetail.ProductId = detail.ProductId;
                            objDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(workplaceId);
                            objDetail.TxDate = txDate;
                            objDetail.OPERATOR = ModelEx.StaffEx.GetStaffNumberById(ConfigHelper.CurrentUserId);
                            objDetail.Qty = detail.Qty;
                            objDetail.AverageCost = detail.AverageCost;
                            objDetail.UnitAmount = detail.AverageCost;
                            objDetail.Amount = detail.AverageCost * detail.Qty;

                            ctx.InvtLedgerDetails.Add(objDetail);
                        }
                    //}
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
    }
}
