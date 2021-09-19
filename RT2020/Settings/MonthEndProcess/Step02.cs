using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

using RT2020.Controls;
using RT2020.Common.Helper;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Re-calc Product Workplace Summary
    /// </summary>
    public class Step02 : IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        /// <summary>
        /// Does the action.
        /// </summary>
        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step02 Processing ...", 1, 100));

            this.ResetCurrentSummary();
            this.RecalcSummary();
        }

        #endregion

        /// <summary>
        /// Recalcs the summary.
        /// </summary>
        private void RecalcSummary()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step02 - Re-calculate the current summary.", 20, 100));

            string query = @"
UPDATE ProductCurrentSummary SET CDQTY = pw.CDQty, BFQTY = pw.BFQty, BFAMT = pw.BFQty * pcs.AverageCost
FROM (SELECT ProductId, SUM(CDQTY) AS CDQty, SUM(BFQTY) AS BFQty
	FROM ProductWorkplace GROUP BY ProductId) pw 
  INNER JOIN ProductCurrentSummary pcs ON pw.ProductId = pcs.ProductId";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Reset the current summary.
        /// </summary>
        private void ResetCurrentSummary()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step02 - Reset the current summary.", 80, 100));

            string query = "UPDATE ProductCurrentSummary SET BFQty = 0, CDQty = 0";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
    }
}
