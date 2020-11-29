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
            DateTime currMonth = SystemInfo.CurrentInfo.Default.CurrentSystemDate;
            string whereClause = "TxDate >= CAST('" + currMonth.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00") + "' AS DATETIME) AND TxDate < CAST('" + currMonth.ToString("yyyy-MM-dd 00:00:00") +"' AS DATETIME)";

            InvtLedgerHeaderCollection oHeaderList = InvtLedgerHeader.LoadCollection(whereClause);
            foreach (InvtLedgerHeader oHeader in oHeaderList)
            {
                whereClause = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                InvtLedgerDetailsCollection oDetailList = InvtLedgerDetails.LoadCollection(whereClause);
                for (int i = 0; i < oDetailList.Count; i++)
                {
                    InvtLedgerDetails oDetail = oDetailList[i];
                    if (oDetail != null)
                    {
                        oDetail.TxDate = oHeader.TxDate;
                        oDetail.SHOP = ModelEx.WorkplaceEx.GetWorkplaceCodeById(oHeader.WorkplaceId);

                        oDetail.Save();

                        this.AppendMissingProductWorkplace(oDetail.ProductId, oHeader.WorkplaceId);
                    }
                }
            }
        }

        private void AppendMissingProductWorkplace(Guid productId, Guid workplaceId)
        {
            string whereClause = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            ProductWorkplace oProdWp = ProductWorkplace.LoadWhere(whereClause);
            if (oProdWp == null)
            {
                oProdWp = new ProductWorkplace();
                oProdWp.ProductId = productId;
                oProdWp.WorkplaceId = workplaceId;
                oProdWp.Save();
            }

        }
    }
}
