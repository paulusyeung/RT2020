using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RT2020.DAL;

namespace RT2020.SystemInfo
{
    /// <summary>
    /// Current System Information
    /// </summary>
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
        /// </summary>
        /// <value>The default of Current System Information.</value>
        public static CurrentInfo Default
        {
            get
            {
                return new CurrentInfo();
            }
        }

        #region Variables

        private string companyName = string.Empty;
        private string companyName_Chs = string.Empty;
        private string companyName_Cht = string.Empty;
        private string currentSystemYear = DateTime.Now.Year.ToString();
        private string currentSystemMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
        private string lastMonthEnd = DateTime.Now.ToString("yyyyMM");
        private string lastYearEnd = DateTime.Now.ToString("yyyyMM");
        private DateTime currentSystemDate = DateTime.Now;
        private RT2020.DAL.SystemInfo sysInfo;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
            }
        }

        /// <summary>
        /// Gets or sets the simp. chinese company name.
        /// </summary>
        /// <value>The simp. chinese company name.</value>
        public string CompanyName_Chs
        {
            get
            {
                return companyName_Chs;
            }
            set
            {
                companyName_Chs = value;
            }
        }

        /// <summary>
        /// Gets or sets the trac. chinese company name.
        /// </summary>
        /// <value>The trac. chinese company name.</value>
        public string CompanyName_Cht
        {
            get
            {
                return companyName_Cht;
            }
            set
            {
                companyName_Cht = value;
            }
        }

        /// <summary>
        /// Gets or sets the currenct system year.
        /// </summary>
        /// <value>The currenct system year.</value>
        public string CurrentSystemYear
        {
            get
            {
                return currentSystemYear;
            }
            set
            {
                currentSystemYear = value;
            }
        }

        /// <summary>
        /// Gets or sets the current system month.
        /// </summary>
        /// <value>The current system month.</value>
        public string CurrentSystemMonth
        {
            get
            {
                return currentSystemMonth;
            }
            set
            {
                currentSystemMonth = value;
            }
        }

        /// <summary>
        /// Gets or sets the last month end.
        /// </summary>
        /// <value>The last month end.</value>
        public string LastMonthEnd
        {
            get
            {
                return lastMonthEnd;
            }
            set
            {
                lastMonthEnd = value;
            }
        }

        /// <summary>
        /// Gets or sets the last year end.
        /// </summary>
        /// <value>The last year end.</value>
        public string LastYearEnd
        {
            get
            {
                return lastYearEnd;
            }
            set
            {
                lastYearEnd = value;
            }
        }

        /// <summary>
        /// Gets or sets the current system date.
        /// </summary>
        /// <value>The current system date.</value>
        public DateTime CurrentSystemDate
        {
            get
            {
                return currentSystemDate;
            }
            set
            {
                currentSystemDate = value;
            }
        }

        /// <summary>
        /// Gets the system info.
        /// </summary>
        /// <value>The system info.</value>
        public RT2020.DAL.SystemInfo SysInfo
        {
            get
            {
                return sysInfo;
            }
        }

        #endregion

        /// <summary>
        /// Gets the current system info.
        /// </summary>
        private void GetCurrentSystemInfo()
        {
            SystemInfoCollection oSysInfoList = RT2020.DAL.SystemInfo.LoadCollection();
            if (oSysInfoList.Count > 0)
            {
                RT2020.DAL.SystemInfo oSysInfo = oSysInfoList[0];
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

                    this.sysInfo = oSysInfo;
                }
            }

        }
    }
}
