using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT2020.ModelEx
{
    public class SystemInfoEx
    {
        public static EF6.SystemInfo Get(Guid id)
        {
            EF6.SystemInfo result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                result = ctx.SystemInfo.Find(id);
            }

            return result;
        }

        public static bool ClearLogoInfo(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var sys = ctx.SystemInfo.Find(id);
                if (sys != null)
                {
                    sys.LOGO = string.Empty;
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        public class CurrentInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CurrentInfo"/> class.
            /// </summary>
            public CurrentInfo()
            {
                this.GetCurrentSystemInfo();
            }

            /// <summary>
            /// Gets the default of Current System Information.
            /// var sysInfo = CurrentInfo.Default();
            /// </summary>
            /// <value>The default of Current System Information.</value>
            public static CurrentInfo Default
            {
                get { return new CurrentInfo(); }
            }

            #region public Properties

            public string CompanyName { get; set; }
            public string CompanyName_Chs { get; set; }
            public string CompanyName_Cht { get; set; }
            public string CurrentSystemYear { get; set; }
            public string CurrentSystemMonth { get; set; }
            public string LastMonthEnd { get; set; }
            public string LastYearEnd { get; set; }
            public DateTime CurrentSystemDate { get; set; }
            public EF6.SystemInfo SysInfo { get; set; }

            #endregion

            /// <summary>
            /// Gets the current system info.
            /// </summary>
            private void GetCurrentSystemInfo()
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var oSysInfo = ctx.SystemInfo.AsNoTracking().FirstOrDefault();
                    if (oSysInfo != null)
                    {
                        string lastYear = oSysInfo.LastMonthEnd.ToString().Substring(0, 4);
                        string lastMonth = oSysInfo.LastMonthEnd.ToString().Substring(4, 2);

                        DateTime currentMonth = new DateTime(Convert.ToInt32(lastYear), Convert.ToInt32(lastMonth), 1);
                        currentMonth = currentMonth.AddMonths(1);

                        this.CurrentSystemDate = currentMonth;
                        this.CurrentSystemYear = currentMonth.Year.ToString();
                        this.CurrentSystemMonth = currentMonth.Month.ToString().PadLeft(2, '0');
                        this.LastMonthEnd = oSysInfo.LastMonthEnd.ToString();
                        this.LastYearEnd = oSysInfo.LastYearEnd.ToString();

                        // Address Info.
                        this.CompanyName = oSysInfo.CompanyName;
                        this.CompanyName_Chs = oSysInfo.CompanyName_Chs;
                        this.CompanyName_Cht = oSysInfo.CompanyName_Cht;

                        this.SysInfo = oSysInfo;
                    }
                }
            }
        }
    }
}