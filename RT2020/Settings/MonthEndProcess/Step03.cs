using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.Controls;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Preparation
    /// </summary>
    public class Step03 : IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step03 Processing ...", 1, 100));

            this.UpdateLedgerDetails();
        }

        #endregion

        private void UpdateLedgerDetails()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DateTime currMonth = SystemInfo.CurrentInfo.Default.CurrentSystemDate;
                        string whereClause = "TxDate >= CAST('" + currMonth.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00") + "' AS DATETIME) AND TxDate < CAST('" + currMonth.ToString("yyyy-MM-dd 00:00:00") + "' AS DATETIME)";

                        var oHeaderList = ctx.InvtLedgerHeader.SqlQuery(
                            string.Format("Select * from InvtLedgerHeader Where{0} ", whereClause)
                            );
                        foreach (var oHeader in oHeaderList)
                        {
                            var oDetailList = ctx.InvtLedgerDetails.Where(x => x.HeaderId == oHeader.HeaderId);
                            foreach (var oDetail in oDetailList)
                            {
                                if (oDetail != null)
                                {
                                    oDetail.TxDate = oHeader.TxDate;
                                    oDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oHeader.WorkplaceId);

                                    #region this.AppendMissingProductWorkplace(oDetail.ProductId, oHeader.WorkplaceId);
                                    var oProdWp = ctx.ProductWorkplace.Where(x => x.ProductId == oDetail.ProductId && x.WorkplaceId == oHeader.WorkplaceId).FirstOrDefault();
                                    if (oProdWp == null)
                                    {
                                        oProdWp = new EF6.ProductWorkplace();
                                        oProdWp.ProductWorkplaceId = Guid.NewGuid();
                                        oProdWp.ProductId = oDetail.ProductId.Value;
                                        oProdWp.WorkplaceId = oHeader.WorkplaceId;

                                        ctx.ProductWorkplace.Add(oProdWp);
                                    }
                                    #endregion
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
    }
}
