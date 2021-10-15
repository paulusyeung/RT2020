using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace RT2020.Common.Helper
{
    public class ConfigHelper
    {
        /// <summary>
        /// Gets the connection string for excel 03.
        /// </summary>
        /// <value>The connection string for excel 03.</value>
        private static string ConnectionString4Excel03
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["OleConn4Excel03"].ConnectionString;
            }
        }

        /// <summary>
        /// Gets the connection string for excel 07.
        /// </summary>
        /// <value>The connection string for excel 07.</value>
        private static string ConnectionString4Excel07
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["OleConn4Excel07"].ConnectionString;
            }
        }

        /// <summary>
        /// Gets the OLE db connection.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <returns></returns>
        public static OleDbConnection GetOleDbConnection(string dataSource)
        {
            string connString = string.Empty;

            if (dataSource.Length > 0)
            {
                string ext = dataSource.Remove(0, dataSource.LastIndexOf('.') + 1);
                switch (ext.ToLower().Trim())
                {
                    case "xls":
                        connString = string.Format(ConnectionString4Excel03, dataSource);
                        break;
                    case "xlsx":
                        connString = string.Format(ConnectionString4Excel07, dataSource);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(connString))
            {
                OleDbConnection oConn = new OleDbConnection(connString);

                if (oConn.State == ConnectionState.Open)
                {
                    oConn.Close();
                }

                return oConn;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public static string ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["SysDb"].ConnectionString;
            }
        }

        /// <summary>
        /// Gets the command timeout. Default value: 600 seconds
        /// </summary>
        /// <value>The command timeout.</value>
        public static int CommandTimeout
        {
            get
            {
                int result = 600;

                string timeoutString = WebConfigurationManager.AppSettings["CommandTimeoutValue"];
                int timeout = 0;
                if (!string.IsNullOrEmpty(timeoutString) || int.TryParse(timeoutString, out timeout))
                {
                    result = timeout;
                }

                return result;
            }
        }

        //public static Guid CurrentUserId
        //{
        //    get
        //    {
        //        if (Utility.IsGUID(System.Web.HttpContext.Current.User.Identity.Name))
        //        {
        //            return new Guid(System.Web.HttpContext.Current.User.Identity.Name);
        //        }
        //        else
        //        {
        //            return Guid.Empty;
        //        }
        //    }
        //}

        /// <summary>
        /// Gets or sets the current user id.
        /// </summary>
        /// <value>The current user id.</value>
        public static Guid CurrentUserId
        {
            get
            {
                if (System.Web.HttpContext.Current != null)
                {
                    Guid cookieStaffId = Guid.Empty;
                    if (HttpContext.Current.Request.Cookies["RT2K8_LogonStaff"] != null)
                    {
                        Guid item = Guid.Empty;
                        if (Guid.TryParse(HttpContext.Current.Request.Cookies["RT2K8_LogonStaff"].Value, out item))
                        {
                            cookieStaffId = item;
                        }
                    }
                    return cookieStaffId;
                }
                else
                {
                    return _currentUserId;
                }
            }
            set
            {
                if (System.Web.HttpContext.Current != null)
                {
                    System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2K8_LogonStaff");

                    if (value != Guid.Empty)
                    {
                        // create the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString();
                        oCookie.Expires = now.AddYears(1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                    else
                    {
                        // destory the cookie
                        DateTime now = DateTime.Now;

                        oCookie.Value = value.ToString();
                        oCookie.Expires = now.AddDays(-1);

                        System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                    }
                }
                else
                {
                    _currentUserId = value;
                }
            }
        }
        private static Guid _currentUserId = Guid.Empty;

        public static int CurrentUserType
        {
            get
            {
                int cookieUserType = (int)EnumHelper.UserType.Staff;
                if (HttpContext.Current.Request.Cookies["RT2020_LogonUserType"] != null)
                {
                    int item = 0;
                    if (int.TryParse(HttpContext.Current.Request.Cookies["RT2020_LogonUserType"].Value, out item))
                    {
                        cookieUserType = item;
                    }
                }
                return cookieUserType;
            }
            set
            {
                System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2020_LogonUserType");

                if (value >= 0)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
                    oCookie.Expires = now.AddYears(1);

                    System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                }
                else
                {
                    // destory the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
                    oCookie.Expires = now.AddDays(-1);

                    System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                }
            }
        }

        public static int CurrentSecurityLevel
        {
            get
            {
                int cookieSecurityLevel = (int)EnumHelper.UserType.Staff;
                if (HttpContext.Current.Request.Cookies["RT2020_LogonSecurityLevel"] != null)
                {
                    int item = 0;
                    if (int.TryParse(HttpContext.Current.Request.Cookies["RT2020_LogonSecurityLevel"].Value, out item))
                    {
                        cookieSecurityLevel = item;
                    }
                }
                return cookieSecurityLevel;
            }
            set
            {
                System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2020_LogonSecurityLevel");

                if (value >= 0)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
                    oCookie.Expires = now.AddYears(1);

                    System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                }
                else
                {
                    // destory the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
                    oCookie.Expires = now.AddDays(-1);

                    System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
                }
            }
        }

        /// <summary>
        /// Gets or sets the current zone id.
        /// </summary>
        /// <value>The current zone id.</value>
        public static Guid CurrentZoneId
        {
            get
            {
                Guid cookieZoneId = Guid.Empty;
                if (HttpContext.Current.Request.Cookies["RT2K8_ZoneId"] != null)
                {
                    Guid item = Guid.Empty;
                    if (Guid.TryParse(HttpContext.Current.Request.Cookies["RT2K8_ZoneId"].Value, out item))
                    {
                        cookieZoneId = item;
                    }
                }
                return cookieZoneId;
            }
            set
            {
                System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2K8_ZoneId");
                DateTime now = DateTime.Now;

                oCookie.Value = value.ToString();
                oCookie.Expires = now.AddYears(1);

                System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
            }
        }

        /// <summary>
        /// Gets the current language id.
        /// </summary>
        /// <value>The current language id.</value>
        public static int CurrentLanguageId
        {
            get
            {
                int result = 1;
                string sLang = (string)System.Web.HttpContext.Current.Session["UserLanguage"];
                if (sLang == null) sLang = System.Web.HttpContext.Current.Request.UserLanguages[0];

                switch (sLang.ToLower())
                {
                    case "chs":
                    case "zh-chs":
                    case "zh-cn":
                    case "zh-hans":
                        result = 2;
                        break;
                    case "cht":
                    case "zh-cht":
                    case "zh-hk":
                    case "zh-tw":
                    case "zh-hant":
                        result = 3;
                        break;
                    case "en":
                    case "en-us":
                    default:
                        result = 1;
                        break;
                }

                return result;
            }
        }

        public static string CurrentWordDict
        {
            get
            {
                return Path.Combine(VWGContext.Current.Config.GetDirectory("UserData"), "WordDict.xml");
            }
        }

        /// <summary>
        /// Gets the current language code.
        /// </summary>
        /// <value>The current language code.</value>
        public static string CurrentLanguageCode
        {
            get
            {
                string result = "en-us";
                string sLang = (string)System.Web.HttpContext.Current.Session["UserLanguage"];
                if (sLang == null) sLang = System.Web.HttpContext.Current.Request.UserLanguages[0];

                switch (sLang.ToLower())
                {
                    case "chs":
                    case "zh-chs":
                    case "zh-cn":
                    case "zh-hans":
                        result = "zh-chs";
                        break;
                    case "cht":
                    case "zh-cht":
                    case "zh-hk":
                    case "zh-tw":
                    case "zh-hant":
                        result = "zh-cht";
                        break;
                    case "en":
                    case "en-us":
                    default:
                        result = "en-us";
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// Maximum records allowed in SQL Query
        /// Default = 500 records
        /// </summary>
        public static int SqlQueryLimit
        {
            get
            {
                string sqlQueryLimit = "500";
                if (ConfigurationSettings.AppSettings["SqlQueryLimit"] != null)
                {
                    sqlQueryLimit = ConfigurationSettings.AppSettings["SqlQueryLimit"];
                }
                return Convert.ToInt32(sqlQueryLimit);
            }
        }

        /// <summary>
        /// Gets the default culture info.
        /// </summary>
        /// <value>The default culture info.</value>
        public static IFormatProvider DefaultCultureInfo
        {
            get
            {
                CultureInfo defaultCultureInfo = new CultureInfo("en-US");
                return defaultCultureInfo;
            }
        }

        public static string ApiServerName
        {
            get
            {
                string result = @"https://api.rt2020.com";

                if (ConfigurationManager.AppSettings["ApiServerName"] != null)
                {
                    result = (string)ConfigurationManager.AppSettings["ApiServerName"];
                }

                return result;
            }
        }

        public static string Impersonate_UserName
        {
            get
            {
                string result = @"Administrator";

                if (ConfigurationManager.AppSettings["Impersonate_UserName"] != null)
                {
                    result = (string)ConfigurationManager.AppSettings["Impersonate_UserName"];
                }

                return result;
            }
        }

        public static string Impersonate_UserPassword
        {
            get
            {
                string result = @"nx-9602";

                if (ConfigurationManager.AppSettings["Impersonate_UserPassword"] != null)
                {
                    result = (string)ConfigurationManager.AppSettings["Impersonate_UserPassword"];
                }

                return result;
            }
        }

        public static string OutBox
        {
            get
            {
                string result = @"C:\Shared\RT2020\OutBox";

                if (ConfigurationManager.AppSettings["OutBox"] != null)
                {
                    result = (string)ConfigurationManager.AppSettings["OutBox"];
                    if (!(Directory.Exists(result)))
                    {
                        Directory.CreateDirectory(result);
                    }
                }

                return result;
            }
        }

        public static string ReportsBox
        {
            get
            {
                string result = @"C:\Shared\RT2020\ReportsBox";

                if (ConfigurationManager.AppSettings["ReportsBox"] != null)
                {
                    result = (string)ConfigurationManager.AppSettings["ReportsBox"];
                    if (!(Directory.Exists(result)))
                    {
                        Directory.CreateDirectory(result);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Sets the culture info.
        /// </summary>
        /// <param name="selectedLanguage">The selected language.</param>
        public static void SetCultureInfo(string selectedLanguage)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        }

        public static bool UseNetSqlAzMan
        {
            get
            {
                bool result = false;

                if (ConfigurationManager.AppSettings["UseNetSqlAzMan"] != null)
                {
                    bool.TryParse((String)ConfigurationManager.AppSettings["UseNetSqlAzMan"], out result);
                }

                return result;
            }
        }
    }
}