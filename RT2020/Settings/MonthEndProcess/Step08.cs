using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RT2020.Controls;
using RT2020.Common.ModelEx;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Update System Month
    /// </summary>
    public class Step08 : IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step08 Processing ...", 1, 100));

            this.CopyMonthEndData();
        }

        #endregion

        private void CopyMonthEndData()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step08 - Update Current System Month.", 90, 100));

            using (var ctx = new EF6.RT2020Entities())
            {
                var oSysInfo = ctx.SystemInfo.FirstOrDefault();
                if (oSysInfo != null)
                {
                    oSysInfo.LastMonthEnd = Convert.ToInt32(SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.ToString("yyyyMM"));
                    ctx.SaveChanges();
                }
            }
        }
    }
}
