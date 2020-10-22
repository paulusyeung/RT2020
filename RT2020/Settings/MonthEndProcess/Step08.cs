using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RT2020.DAL;
using RT2020.Controls;

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
            SystemInfoCollection oSysInfoList = RT2020.DAL.SystemInfo.LoadCollection();
            if (oSysInfoList.Count > 0)
            {
                RT2020.DAL.SystemInfo oSysInfo = oSysInfoList[0];
                if (oSysInfo != null)
                {
                    oSysInfo.LastMonthEnd = Convert.ToInt32(SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyyMM"));
                    oSysInfo.Save();
                }
            }
        }
    }
}
