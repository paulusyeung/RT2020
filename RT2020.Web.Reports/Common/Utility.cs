using System;
using System.Collections.Generic;
using System.Web;
using RT2020.DAL;
using Gizmox.WebGUI.Forms;
using System.Reflection;

namespace RT2020.Web.Reports.Common
{
    public class Utility
    {
        /// <summary>
        /// Gets the system label by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetSystemLabelByKey(string key)
        {
            string result = key;
            string sql = "LanguageCode = '" + VWGContext.Current.CurrentUICulture.ToString() + "'";

            SystemLabel oLabel = SystemLabel.LoadWhere(sql);
            if (oLabel != null)
            {
                PropertyInfo pi = oLabel.GetType().GetProperty(key.Trim().ToUpper());
                try
                {
                    result = pi.GetValue(oLabel, null).ToString();
                }
                catch
                {
                }
            }

            // return string.IsNullOrEmpty(result) ? key : result;
            return result;
        }

        /// <summary>
        /// Convert the datetime value to string with time or without.
        /// If the value is equaled to 1900-01-01, it would return a emty value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="withTime"></param>
        /// <returns></returns>
        public static string DateTimeToString(DateTime value, bool withTime)
        {
            string formatString = GetDateFormat();
            if (withTime)
            {
                formatString = GetDateTimeFormat();
            }

            if (!value.Equals(new DateTime(1900, 1, 1)))
            {
                return value.ToString(formatString);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the date format.
        /// </summary>
        /// <returns></returns>
        public static string GetDateFormat()
        {
            string result = String.Empty;

            switch (VWGContext.Current.CurrentUICulture.ToString())
            {
                case "zh-CHS":
                    result = "yyyy-MM-dd";
                    break;
                case "zh-CHT":
                    result = "dd/MM/yyyy";
                    break;
                case "en-US":
                default:
                    result = "dd/MM/yyyy";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets the date time format.
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeFormat()
        {
            string result = String.Empty;

            switch (VWGContext.Current.CurrentUICulture.ToString())
            {
                case "zh-CHS":
                    result = "yyyy-MM-dd HH:mm";
                    break;
                case "zh-CHT":
                    result = "dd/MM/yyyy HH:mm";
                    break;
                case "en-US":
                default:
                    result = "dd/MM/yyyy HH:mm";
                    break;
            }

            return result;
        }

        #region Current System Info

        /// <summary>
        /// the <see cref="CurrentSystemMonth"/> class
        /// </summary>
        public class CurrentSystemInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CurrentSystemMonth"/> class.
            /// </summary>
            public CurrentSystemInfo()
            {
                this.GetSystemYearMonth();
            }

            /// <summary>
            /// Gets the default instance of the <see cref="CurrentSystemMonth"/> class.
            /// </summary>
            /// <value>The default instance of the <see cref="CurrentSystemMonth"/> class.</value>
            public static CurrentSystemInfo Default
            {
                get
                {
                    return new CurrentSystemInfo();
                }
            }

            #region Variables

            private string currentSystemYear = DateTime.Now.Year.ToString();
            private string currentSystemMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');

            #endregion

            #region Properties
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

            #endregion

            /// <summary>
            /// Gets the system year month.
            /// </summary>
            private void GetSystemYearMonth()
            {
                SystemInfoCollection oSysInfoList = SystemInfo.LoadCollection();
                if (oSysInfoList.Count > 0)
                {
                    SystemInfo oSysInfo = oSysInfoList[0];
                    if (oSysInfo != null)
                    {
                        string lastYear = oSysInfo.LastMonthEnd.ToString().Substring(0, 4);
                        string lastMonth = oSysInfo.LastMonthEnd.ToString().Substring(4, 2);

                        DateTime currentMonth = new DateTime(Convert.ToInt32(lastYear), Convert.ToInt32(lastMonth), 1);

                        this.CurrentSystemYear = currentMonth.Year.ToString();
                        this.CurrentSystemMonth = currentMonth.Month.ToString().PadLeft(2, '0');
                    }
                }

            }
        }

        #endregion
    }
}
