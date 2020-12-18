using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using RT2020.DAL;
using RT2020.Controls;
using RT2020.Helper;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Backup Data
    /// </summary>
    public class Step06:IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step06 Processing ...", 1, 100));

            this.CopyMonthEndData();
        }

        #endregion

        private void CopyMonthEndData()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step06 - Copy data from [MonthEndWorkplaceSummary] to [ProductWorkplacePeriodicSummary].", 50, 100));
            // Copy Data
            string query = @"
INSERT INTO ProductWorkplacePeriodicSummary(ProductId, WorkplaceId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, CDQTY, FEPQTY, RECQTY, INVQTY, POQTY, SOQTY, REJQTY, EPQTY) 
SELECT ProductId, WorkplaceId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, CDQTY, FEPQTY, RECQTY, INVQTY, POQTY, SOQTY, REJQTY, EPQTY
FROM MonthEndWorkplaceSummary ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step06 - Copy data from [MonthEndSummary] to [ProductPeriodicSummary].", 90, 100));
            // Copy Data
            query = @"
INSERT INTO ProductPeriodicSummary(ProductId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, BFAMT, CDQTY, AverageCost, LastCost,
             LastPurchasedOn, LastPurchasedQty, LastSoldOn, LastSoldQty) 
SELECT ProductId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, BFAMT, CDQTY, AverageCost, LastCost,
             LastPurchasedOn, LastPurchasedQty, LastSoldOn, LastSoldQty
FROM MonthEndSummary ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
    }
}
