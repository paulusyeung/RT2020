using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RT2020.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.Controls;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Update Product Summary
    /// </summary>
    public class Step04 : IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 Processing ...", 1, 100));

            this.CreateTempTableForMonthEndSummary();
            this.CreateTempTableForMonthEnd();
            this.CreateTempTableForMonthEndWithQty();

            this.CopyCurrentSummary();
            this.UpdateMonthEndWithTempTables();
        }

        #endregion

        private void UpdateMonthEndWithTempTables()
        {
            this.SetLastPurchasedOn();
            this.SetLastSoldOn();
            this.SetLastPurchasedQty();
            this.SetLastSoldQty();
        }

        #region Create Temp Tables
        private void CreateTempTableForMonthEndSummary()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Check Temp table [MonthEndSummary]. If exists, drop it.", 3, 100));
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthEndSummary]') AND type in (N'U'))
DROP TABLE [dbo].[MonthEndSummary] ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - create new Temp table [MonthEndSummary].", 6, 100));
            // create new temp table
            query = @"
CREATE TABLE [dbo].[MonthEndSummary](
	[ProductId] [uniqueidentifier] NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[Period] [int] NOT NULL,
	[PeriodStartedOn] [datetime] NULL,
	[PeriodEndedOn] [datetime] NULL,
	[BFQTY] [decimal](18, 4) NOT NULL,
	[BFAMT] [money] NOT NULL,
	[CDQTY] [decimal](18, 4) NOT NULL,
	[AverageCost] [money] NOT NULL,
	[LastCost] [money] NOT NULL,
	[LastPurchasedOn] [datetime] NULL,
	[LastPurchasedQty] [decimal](18, 4) NOT NULL,
	[LastSoldOn] [datetime] NULL,
	[LastSoldQty] [decimal](18, 4) NOT NULL
) ON [PRIMARY]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void CreateTempTableForMonthEnd()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Check Temp table [TempTableForMonthEnd]. If exists, drop it.", 9, 100));
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempTableForMonthEnd]') AND type in (N'U'))
DROP TABLE [dbo].[TempTableForMonthEnd]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - create new Temp table [TempTableForMonthEnd].", 12, 100));
            // create new temp table
            query = @"
CREATE TABLE [dbo].[TempTableForMonthEnd](
	[ProductId] [uniqueidentifier] NOT NULL,
	[LastCost] [money] NOT NULL,
	[LastPurchasedOn] [datetime] NULL,
	[LastPurchasedQty] [decimal](18, 4) NOT NULL,
	[LastSoldOn] [datetime] NULL,
	[LastSoldQty] [decimal](18, 4) NOT NULL
) ON [PRIMARY] ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void CreateTempTableForMonthEndWithQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Check Temp table [TempTableForMonthEnd]. If exists, drop it.", 15, 100));
            // Drop the temp table if exists.
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempTableForMonthEndWithQty]') AND type in (N'U'))
DROP TABLE [dbo].[TempTableForMonthEndWithQty]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - create new Temp table [TempTableForMonthEnd].", 18, 100));
            // create new temp table
            query = @"
CREATE TABLE [dbo].[TempTableForMonthEndWithQty](
    [Type] [varchar](1) NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[LastCost] [money] NOT NULL,
	[LastPurchasedOn] [datetime] NULL,
	[LastPurchasedQty] [decimal](18, 4) NOT NULL,
	[LastSoldOn] [datetime] NULL,
	[LastSoldQty] [decimal](18, 4) NOT NULL
) ON [PRIMARY]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion

        private void CopyCurrentSummary()
        {
            DateTime currSystemMonth = SystemInfo.CurrentInfo.Default.CurrentSystemDate;

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Delete Data from [MonthEndSummary].", 21, 100));
            // Delete Data
            string query = @"DELETE FROM MonthEndSummary";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data to [MonthEndSummary].", 24, 100));
            // Copy Data
            query = @"
INSERT INTO MonthEndSummary(ProductId, FiscalYear, Period, PeriodStartedOn, PeriodEndedOn, BFQTY, BFAMT, CDQTY, AverageCost, LastCost,
             LastPurchasedOn, LastPurchasedQty, LastSoldOn, LastSoldQty) 
SELECT ProductId, " + currSystemMonth.Year.ToString() + @", " + currSystemMonth.Month.ToString() + @", " + currSystemMonth.ToString("yyyy-MM-dd") + @", " + currSystemMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + @", 
        BFQTY, BFAMT, CDQTY, AverageCost, LastCost, LastPurchasedOn, LastPurchasedQty, LastSoldOn, LastSoldQty
FROM ProductCurrentSummary";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data in [ProductCurrentSummary].", 27, 100));
            // Copy Data
            query = @"UPDATE ProductCurrentSummary SET BFQTY = CDQTY, BFAMT = CDQTY * AverageCost";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        #region Update LastPurchasedOn
        private void GetLastPurchasedDate()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Delete Data from [TempTableForMonthEnd].", 30, 100));
            // Delete Data
            string query = @"DELETE FROM [TempTableForMonthEnd]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data to [TempTableForMonthEnd].", 33, 100));
            // Copy Data
            query = @"
INSERT INTO [TempTableForMonthEnd](ProductId, LastPurchasedOn)
SELECT ProductId, MAX(TxDate) AS LASTPURDATE  FROM InvtLedgerDetails 
WHERE TxType IN ('CAP', 'REC') 
GROUP BY ProductId ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void SetLastPurchasedOn()
        {
            GetLastPurchasedDate();

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data from [TempTableForMonthEnd] to [TempTableForMonthEndWithQty].", 36, 100));
            // Copy Data
            string query = @"
INSERT INTO [TempTableForMonthEndWithQty]([Type], ProductId, LastPurchasedOn, LastPurchasedQty) 
SELECT 'P', me.ProductId, me.LastPurchasedOn, 0
FROM [TempTableForMonthEnd] me 
    INNER JOIN ProductCurrentSummary cs ON me.ProductId = cs.ProductId 
WHERE  cs.LastPurchasedOn IS NULL OR 
(cs.LastPurchasedOn IS NOT NULL AND cs.LastPurchasedOn < me.LastPurchasedOn)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data from [TempTableForMonthEnd] to [ProductCurrentSummary].", 39, 100));
            // Update Data
            query = @"
UPDATE [dbo].[ProductCurrentSummary]
SET [dbo].[ProductCurrentSummary].LastPurchasedOn = [dbo].[TempTableForMonthEnd].LastPurchasedOn, [dbo].[ProductCurrentSummary].LastPurchasedQty = 0
FROM [dbo].[ProductCurrentSummary]
    INNER JOIN [dbo].[TempTableForMonthEnd]
    ON ([dbo].[ProductCurrentSummary].ProductId = [dbo].[TempTableForMonthEnd].ProductId)
WHERE  [dbo].[ProductCurrentSummary].LastPurchasedOn IS NULL
		OR ([dbo].[ProductCurrentSummary].LastPurchasedOn IS NOT NULL AND [dbo].[ProductCurrentSummary].LastPurchasedOn < [dbo].[TempTableForMonthEnd].LastPurchasedOn)";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion

        #region Update LastSoldOn
        private void GetLastSoldDate()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Delete Data from [TempTableForMonthEnd].", 42, 100));
            // Delete Data
            string query = @"DELETE FROM [TempTableForMonthEnd]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data to [TempTableForMonthEnd].", 45, 100));
            // Copy Data
            query = @"
INSERT INTO [TempTableForMonthEnd](ProductId, LastSoldOn)
SELECT ProductId, MAX(TxDate) AS LASTSOLDDATE FROM PosLedgerDetails 
WHERE TxType IN ('CAS', 'SAL')
GROUP BY ProductId ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void SetLastSoldOn()
        {
            GetLastSoldDate();

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data from [TempTableForMonthEnd] to [TempTableForMonthEndWithQty].", 48, 100));
            // Copy Data
            string query = @"
INSERT INTO [TempTableForMonthEndWithQty]([Type], ProductId, LastSoldOn, LastSoldQty) 
SELECT 'S', me.ProductId, me.LastSoldOn, 0
FROM [TempTableForMonthEnd] me 
    INNER JOIN ProductCurrentSummary cs ON me.ProductId = cs.ProductId 
WHERE  cs.LastSoldOn IS NULL OR 
(cs.LastSoldOn IS NOT NULL AND cs.LastSoldOn < me.LastSoldOn)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data from [TempTableForMonthEnd] to [ProductCurrentSummary].", 51, 100));
            // Update Data
            query = @"
UPDATE [dbo].[ProductCurrentSummary]
SET [dbo].[ProductCurrentSummary].LastSoldOn = [dbo].[TempTableForMonthEnd].LastSoldOn, [dbo].[ProductCurrentSummary].LastSoldQty = 0
FROM [dbo].[ProductCurrentSummary]
    INNER JOIN [dbo].[TempTableForMonthEnd]
    ON ([dbo].[ProductCurrentSummary].ProductId = [dbo].[TempTableForMonthEnd].ProductId)
WHERE  [dbo].[ProductCurrentSummary].LastSoldOn IS NULL
		OR ([dbo].[ProductCurrentSummary].LastSoldOn IS NOT NULL AND [dbo].[ProductCurrentSummary].LastSoldOn < [dbo].[TempTableForMonthEnd].LastSoldOn)";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion

        #region Update Last Purchased/Sold Qty
        private void SetLastPurchasedQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Delete Data from [TempTableForMonthEnd].", 54, 100));
            // Delete Data
            string query = @"DELETE FROM [TempTableForMonthEnd]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data to [TempTableForMonthEnd].", 57, 100));
            // Copy Data
            query = @"
INSERT INTO [TempTableForMonthEnd](ProductId, LastPurchasedQty)
SELECT LDG.ProductId, SUM(LDG.QTY)
FROM InvtLedgerDetails LDG 
           INNER JOIN  TempTableForMonthEndWithQty me ON LDG.ProductId = me.ProductId 
WHERE LDG.TxType IN ('CAP', 'REC') AND LDG.TxDate = me.LastPurchasedOn
      AND me.LastPurchasedOn IS NOT NULL AND me.[Type] IN ('P') 
GROUP BY LDG.ProductId ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data to [TempTableForMonthEndWithQty].", 60, 100));
            // Update Data
            query = @"
UPDATE  [dbo].[TempTableForMonthEndWithQty]
SET [dbo].[TempTableForMonthEndWithQty].[LastPurchasedQty] = [dbo].[TempTableForMonthEndWithQty].[LastPurchasedQty] + [dbo].[TempTableForMonthEnd].[LastPurchasedQty]
FROM [dbo].[TempTableForMonthEnd]
           INNER JOIN  [dbo].[TempTableForMonthEndWithQty] ON [dbo].[TempTableForMonthEndWithQty].ProductId = [dbo].[TempTableForMonthEnd].ProductId
WHERE [dbo].[TempTableForMonthEndWithQty].[Type] IN ('P') ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data from [TempTableForMonthEndWithQty] to ProductCurrentSummary.", 63, 100));
            // Update Data
            query = @"
UPDATE [dbo].[ProductCurrentSummary]
SET [dbo].[ProductCurrentSummary].LastPurchasedQty = [dbo].[TempTableForMonthEndWithQty].LastPurchasedQty
FROM [dbo].[ProductCurrentSummary]
    INNER JOIN [dbo].[TempTableForMonthEndWithQty]
    ON ([dbo].[ProductCurrentSummary].ProductId = [dbo].[TempTableForMonthEndWithQty].ProductId)
WHERE [dbo].[TempTableForMonthEndWithQty].[Type] IN ('P') ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        private void SetLastSoldQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Delete Data from [TempTableForMonthEnd].", 65, 100));
            // Delete Data
            string query = @"DELETE FROM [TempTableForMonthEnd]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Copy Data to [TempTableForMonthEnd].", 68, 100));
            // Copy Data
            query = @"
INSERT INTO [TempTableForMonthEnd](ProductId, LastSoldQty)
SELECT LDG.ProductId, SUM(LDG.QTY)
FROM PosLedgerDetails LDG 
           INNER JOIN  TempTableForMonthEndWithQty me ON LDG.ProductId = me.ProductId 
WHERE LDG.TxType IN ('CAS', 'SAL') AND LDG.TxDate = me.LastSoldOn
      AND me.LastSoldOn IS NOT NULL AND me.[Type] IN ('S') 
GROUP BY LDG.ProductId ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data from [TempTableForMonthEnd] to [TempTableForMonthEndWithQty].", 71, 100));
            // Update Data
            query = @"
UPDATE  [dbo].[TempTableForMonthEndWithQty]
SET [dbo].[TempTableForMonthEndWithQty].[LastSoldQty] = [dbo].[TempTableForMonthEndWithQty].[LastSoldQty] + [dbo].[TempTableForMonthEnd].[LastSoldQty]
FROM [dbo].[TempTableForMonthEnd]
           INNER JOIN  [dbo].[TempTableForMonthEndWithQty] ON [dbo].[TempTableForMonthEndWithQty].ProductId = [dbo].[TempTableForMonthEnd].ProductId
WHERE [dbo].[TempTableForMonthEndWithQty].[Type] IN ('S') ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step04 - Update Data from [TempTableForMonthEndWithQty] to [ProductCurrentSummary].", 74, 100));
            // Update Data
            query = @"
UPDATE [dbo].[ProductCurrentSummary]
SET [dbo].[ProductCurrentSummary].LastSoldQty = [dbo].[TempTableForMonthEndWithQty].LastSoldQty
FROM [dbo].[ProductCurrentSummary]
    INNER JOIN [dbo].[TempTableForMonthEndWithQty]
    ON ([dbo].[ProductCurrentSummary].ProductId = [dbo].[TempTableForMonthEndWithQty].ProductId)
WHERE [dbo].[TempTableForMonthEndWithQty].[Type] IN ('S') ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion
    } 
}
