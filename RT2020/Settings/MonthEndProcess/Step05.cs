using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using RT2020.DAL;
using System.Data;
using System.Configuration;
using RT2020.Controls;
using RT2020.Helper;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Update Product Workplace
    /// </summary>
    public class Step05: IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 Processing ...", 1, 100));

            this.CreateTempTableForMonthEndWorkplaceSummary();

            this.CopyWorkplaceCurrentSummary();
        }

        #endregion

        private void CreateTempTableForMonthEndWorkplaceSummary()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 - Check Temp table [MonthEndSummary]. If exists, drop it.", 20, 100));
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthEndWorkplaceSummary]') AND type in (N'U'))
DROP TABLE [dbo].[MonthEndWorkplaceSummary] ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 - create new Temp table [MonthEndWorkplaceSummary].", 40, 100));
            // create new temp table
            query = @"
CREATE TABLE [dbo].[MonthEndWorkplaceSummary](
	[ProductId] [uniqueidentifier] NOT NULL,
	[WorkplaceId] [uniqueidentifier] NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[Period] [int] NOT NULL,
	[PeriodStartedOn] [datetime] NULL,
	[PeriodEndedOn] [datetime] NULL,
	[BFQTY] [decimal](18, 4) NOT NULL,
	[CDQTY] [decimal](18, 4) NOT NULL,
	[FEPQTY] [decimal](18, 4) NOT NULL,
	[RECQTY] [decimal](18, 4) NOT NULL,
	[INVQTY] [decimal](18, 4) NOT NULL,
	[POQTY] [decimal](18, 4) NOT NULL,
	[SOQTY] [decimal](18, 4) NOT NULL,
	[REJQTY] [decimal](18, 4) NOT NULL,
	[EPQTY] [decimal](18, 4) NOT NULL
) ON [PRIMARY]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void CopyWorkplaceCurrentSummary()
        {
            DateTime currSystemMonth = SystemInfo.CurrentInfo.Default.CurrentSystemDate;

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 - Delete from [MonthEndWorkplaceSummary].", 60, 100));
            // delete data
            string query = @"DELETE FROM MonthEndWorkplaceSummary ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 - Copy Data from [MonthEndWorkplaceSummary] to [ProductWorkplace].", 80, 100));
            // Copy Data
            query = @"
INSERT INTO MonthEndWorkplaceSummary(ProductId, WorkplaceId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, CDQTY, FEPQTY, RECQTY, INVQTY, POQTY, SOQTY, REJQTY, EPQTY) 
SELECT ProductId, WorkplaceId, " + currSystemMonth.Year.ToString() + @", " + currSystemMonth.Month.ToString() + @", " + currSystemMonth.ToString("yyyy-MM-dd") + @",
        " + currSystemMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + @", BFQTY, CDQTY, FEPQTY, RECQTY, INVQTY, POQTY, SOQTY, REJQTY, EPQTY
FROM ProductWorkplace ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step05 - Update Data in [ProductWorkplace].", 99, 100));
            // Update Data
            query = @"UPDATE ProductWorkplace SET BFQTY = CDQTY ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
    }
}
