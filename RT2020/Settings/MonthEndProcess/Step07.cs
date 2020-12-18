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
    /// Drop Temp Tables
    /// </summary>
    public class Step07:IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step07 Processing ...", 1, 100));

            this.DropTempTables();
        }

        #endregion

        private void DropTempTables()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step07 - Drop Temp Table [MonthEndSummary].", 20, 100));
            // Drop Temp Table
            string query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthEndSummary]') AND type in (N'U'))
DROP TABLE [dbo].[MonthEndSummary]";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step07 - Drop Temp Table [MonthEndWorkplaceSummary].", 40, 100));
            // Drop Temp Table
            query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthEndWorkplaceSummary]') AND type in (N'U'))
DROP TABLE [dbo].[MonthEndWorkplaceSummary]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step07 - Drop Temp Table [TempTableForMonthEnd].", 60, 100));
            // Drop Temp Table
            query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempTableForMonthEnd]') AND type in (N'U'))
DROP TABLE [dbo].[TempTableForMonthEnd]";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step07 - Drop Temp Table [TempTableForMonthEndWithQty].", 80, 100));
            // Drop Temp Table
            query = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempTableForMonthEndWithQty]') AND type in (N'U'))
DROP TABLE [dbo].[TempTableForMonthEndWithQty] ";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
    }
}
