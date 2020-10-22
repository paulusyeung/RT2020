using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Configuration;
using System.Web;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using System.IO;

namespace RT2020.DAL
{
    /// <summary>
    /// Common Utility
    /// </summary>
    public class Common
    {
        #region Enum
        /// <summary>
        /// 
        /// </summary>
        public class Enums
        {
            /// <summary>
            /// Status
            /// </summary>
            public enum Status
            {
                /// <summary>
                /// The item is changed its status to inactive, means the item was deleted and no longer be used in the system.
                /// </summary>
                Inactive = -2,
                /// <summary>
                /// Default status, mostly be used in Transaction.
                /// </summary>
                Draft = 0,
                /// <summary>
                /// The item is active, and can be used where it would be.
                /// </summary>
                Active = 1,
                /// <summary>
                /// The item is modified, after export, the status would be changed to [Active].Mostly be used in master code mantainance.
                /// </summary>
                Modified = 2,
                /// <summary>
                /// The item is deleted.
                /// </summary>
                Deleted = -1
            }

            /// <summary>
            /// Product Price Type
            /// </summary>
            public enum ProductPriceType
            {
                /// <summary>
                /// Original Retail Price
                /// </summary>
                ORIPRC,
                /// <summary>
                /// Retail Price /Basic Price
                /// </summary>
                BASPRC,
                /// <summary>
                /// WholeSale Price
                /// </summary>
                WHLPRC,
                /// <summary>
                /// Vendor Price
                /// </summary>
                VPRC
            }

            /// <summary>
            /// Transaction Type
            /// </summary>
            public enum TxType
            {
                /// <summary>
                /// Cash Sales
                /// </summary>
                CAS,

                /// <summary>
                /// Cash Sales Return 
                /// </summary>
                CRT,

                /// <summary>
                /// Cash Sales Void 
                /// </summary>
                VOD,

                /// <summary>
                /// Wholesales Sales
                /// </summary>
                SAL,

                /// <summary>
                /// Normal Invoice 
                /// </summary>
                NML,

                /// <summary>
                /// Balance Invoice
                /// </summary>
                BAL,

                /// <summary>
                /// Wholesales Sales Return
                /// </summary>
                SRT,

                /// <summary>
                /// Credit Note Invoice
                /// </summary>
                ICN,

                /// <summary>
                /// Receiving via CASH
                /// </summary>
                CAP,

                /// <summary>
                /// Receiving via PO
                /// </summary>
                REC,

                /// <summary>
                /// Reject To Supplier
                /// </summary>
                REJ,

                /// <summary>
                /// Transfer IN/OUT
                /// </summary>
                TXF,

                /// <summary>
                /// Transfer IN 
                /// </summary>
                TXI,

                /// <summary>
                /// Transfer OUT
                /// </summary>
                TXO,

                /// <summary>
                /// Transfer IN 
                /// </summary>
                TRI,

                /// <summary>
                /// Transfer OUT
                /// </summary>
                TRO,

                /// <summary>
                /// Picking Note
                /// </summary>
                PNQ,

                /// <summary>
                /// Adjustment
                /// </summary>
                ADJ,

                /// <summary>
                /// Deposit Sales
                /// </summary>
                DEP,

                /// <summary>
                /// Deposit Sales Return
                /// </summary>
                DRT,

                /// <summary>
                /// Suspend Sales
                /// </summary>
                SUP,

                /// <summary>
                /// Stock Take
                /// </summary>
                STK,

                /// <summary>
                /// Requisition
                /// </summary>
                REQ,

                /// <summary>
                /// Assembling 
                /// </summary>
                ASM,

                /// <summary>
                /// Disassembling
                /// </summary>
                DSM,

                /// <summary>
                /// Replenishment
                /// </summary>
                RPL,

                /// <summary>
                /// Price Management
                /// </summary>
                PMS,

                /// <summary>
                /// Price Change
                /// </summary>
                PMC
            }

            /// <summary>
            /// Purchase Order Transaction Type
            /// </summary>
            public enum POType
            {
                /// <summary>
                /// FPO - Foreign Purchase Order (外國購貨單)
                /// </summary>
                FPO,

                /// <summary>
                /// LPO - Local Purchase Order (本地購貨單)
                /// </summary>
                LPO,

                /// <summary>
                /// OPO - Other Purchase Order (其他購貨單)
                /// </summary>
                OPO
            }

            /// <summary>
            /// Layout for displaying list
            /// </summary>
            public enum Layout
            {
                /// <summary>
                /// Card View
                /// </summary>
                CardView,

                /// <summary>
                /// Thumbnails
                /// </summary>
                Thumbnails,

                /// <summary>
                /// List View
                /// </summary>
                ListView
            }

            /// <summary>
            /// Permission of accessing functions
            /// </summary>
            [Flags]
            public enum Permission
            {
                /// <summary>
                /// read permission
                /// </summary>
                Read = 0x001A,
                /// <summary>
                /// write permission
                /// </summary>
                Write = 0x002B,
                /// <summary>
                /// posting permission
                /// </summary>
                Posting = 0x003C,
                /// <summary>
                /// erase permission
                /// </summary>
                Delete = 0x004D,
                /// <summary>
                /// Modify permission (Read, Write, Posting)
                /// </summary>
                Modify = Permission.Read | Permission.Write | Permission.Posting,
                /// <summary>
                /// All permission (Read, Write, Posting, Delete)
                /// </summary>
                All = Permission.Modify | Permission.Delete
            }

            public enum UserType { Staff, Customer, Supplier, Member }
        }
        #endregion

        #region Config
        /// <summary>
        /// 
        /// </summary>
        public class Config
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
                    if (!string.IsNullOrEmpty(timeoutString) || Utility.IsNumeric(timeoutString))
                    {
                        result = Convert.ToInt32(timeoutString);
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
                            if (Common.Utility.IsGUID(HttpContext.Current.Request.Cookies["RT2K8_LogonStaff"].Value))
                            {
                                cookieStaffId = new Guid(HttpContext.Current.Request.Cookies["RT2K8_LogonStaff"].Value);
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
                    int cookieUserType = (int)Enums.UserType.Staff;
                    if (HttpContext.Current.Request.Cookies["RT2020_LogonUserType"] != null)
                    {
                        if (Common.Utility.IsNumeric(HttpContext.Current.Request.Cookies["RT2020_LogonUserType"].Value))
                        {
                            cookieUserType = Convert.ToInt32(HttpContext.Current.Request.Cookies["RT2020_LogonUserType"].Value);
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
                    int cookieSecurityLevel = (int)Enums.UserType.Staff;
                    if (HttpContext.Current.Request.Cookies["RT2020_LogonSecurityLevel"] != null)
                    {
                        if (Common.Utility.IsNumeric(HttpContext.Current.Request.Cookies["RT2020_LogonSecurityLevel"].Value))
                        {
                            cookieSecurityLevel = Convert.ToInt32(HttpContext.Current.Request.Cookies["RT2020_LogonSecurityLevel"].Value);
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
                        if (Common.Utility.IsGUID(HttpContext.Current.Request.Cookies["RT2K8_ZoneId"].Value))
                        {
                            cookieZoneId = new Guid(HttpContext.Current.Request.Cookies["RT2K8_ZoneId"].Value);
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
        #endregion

        #region Utility
        /// <summary>
        /// 
        /// </summary>
        public class Utility
        {
            /// <summary>
            /// Determines whether the specified expression is GUID.
            /// </summary>
            /// <param name="expression">The expression.</param>
            /// <returns>
            /// 	<c>true</c> if the specified expression is GUID; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsGUID(string expression)
            {
                if (expression != null)
                {
                    Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
                    return guidRegEx.IsMatch(expression);
                }
                return false;
            }

            /// <summary>
            /// Determines whether the specified expression is numeric.
            /// </summary>
            /// <param name="expression">The expression.</param>
            /// <returns>
            /// 	<c>true</c> if the specified expression is numeric; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsNumeric(string expression)
            {
                expression = expression.Replace(",", "");
                if (expression != null)
                {
                    Regex numericRegEx = new Regex(@"^-?\d+(\.\d+)?$");
                    return numericRegEx.IsMatch(expression);
                }
                return false;
            }
        }
        #endregion

        #region Combo Box Item

        public class ComboItem
        {
            private string _code = string.Empty;
            private Guid _id = Guid.Empty;

            public ComboItem(string code, Guid id)
            {
                _code = code;
                _id = id;
            }

            public string Code
            {
                get
                {
                    return _code;
                }
                set
                {
                    _code = value;
                }
            }

            public Guid Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
        }

        public class ComboList : BindingList<ComboItem>
        {
        }

        #endregion

        #region Date Time Helper
        public class DateTimeHelper
        {
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
            public static string DateTimeToString(string value, bool withTime)
            {
                string result = String.Empty;
                string formatString = GetDateFormat();
                if (withTime)
                {
                    formatString = GetDateTimeFormat();
                }
                try
                {
                    DateTime source = DateTime.Parse(value);
                    if (!source.Equals(new DateTime(1900, 1, 1)))
                    {
                        result = source.ToString(formatString);
                    }
                }
                catch { }
                return result;
            }

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
                result = "yyyy-MM-dd";

                return result;
            }

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
                result = "yyyy-MM-dd HH:mm";

                return result;
            }
        } 
        #endregion
    }
}
