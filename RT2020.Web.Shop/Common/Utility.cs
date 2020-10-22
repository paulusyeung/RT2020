using System;
using System.Collections.Generic;
using System.Web;
using RT2020.DAL;
using Gizmox.WebGUI.Forms;
using System.Reflection;

namespace RT2020.Web.Shop.Common
{
    public class Utility
    {
        /// <summary>
        /// Queuings the tx number.
        /// </summary>
        /// <param name="txType">Type of the transactions.</param>
        /// <returns></returns>
        public static string QueuingTxNumber(RT2020.DAL.Common.Enums.TxType txType)
        {
            string queuingNumber = DateTime.Today.Year.ToString() + txType.ToString("d").PadLeft(2, '0');
            long queuedTxNumber = long.Parse(queuingNumber.PadRight(12, '0'));

            string lblLastNumber = "LastTxNumber_" + txType.ToString();
            Workplace oWp = Workplace.Load(Common.Utility.CurrentWorkplaceId);
            if (oWp != null)
            {
                WorkplaceZone oZone = WorkplaceZone.Load(oWp.ZoneId);
                if (oZone != null)
                {
                    string lastNumber = oZone.GetMetadata(lblLastNumber);
                    if (lastNumber != null)
                    {
                        if (lastNumber.Length < 12 && lastNumber.Length > 6)
                        {
                            lastNumber = lastNumber.Insert(6, "00");
                        }

                        queuedTxNumber = long.Parse(lastNumber);
                    }

                    oZone.SetMetadata(lblLastNumber, (queuedTxNumber + 1).ToString());
                    oZone.Save();
                }
            }

            return queuedTxNumber.ToString();
        }

        /// <summary>
        /// Queuings the tx number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName">Name of the type. Enums: Common.Enums.TxType, Common.Enums.POType</param>
        /// <returns>TxNumber</returns>
        public static string QueuingTxNumber<T>(T typeName)
        {
            string queuingNumber = DateTime.Today.Year.ToString();
            string lblLastNumber = "LastTxNumber_";

            switch (typeName.GetType().Name)
            {
                case "TxType":
                    RT2020.DAL.Common.Enums.TxType txType = (RT2020.DAL.Common.Enums.TxType)Convert.ChangeType(typeName, typeof(RT2020.DAL.Common.Enums.TxType));
                    queuingNumber += txType.ToString("d").PadLeft(2, '0');
                    lblLastNumber += txType.ToString();
                    break;
                case "POType":
                    RT2020.DAL.Common.Enums.POType poType = (RT2020.DAL.Common.Enums.POType)Convert.ChangeType(typeName, typeof(RT2020.DAL.Common.Enums.POType));
                    queuingNumber += poType.ToString("d").PadLeft(2, '0');
                    lblLastNumber += poType.ToString();
                    break;
            }
            long queuedTxNumber = long.Parse(queuingNumber.PadRight(12, '0'));

            WorkplaceZone oZone = WorkplaceZone.Load(Common.Utility.CurrentWorkplaceId);
            if (oZone != null)
            {
                string lastNumber = oZone.GetMetadata(lblLastNumber);
                if (lastNumber != null)
                {
                    if (lastNumber.Length < 12 && lastNumber.Length > 6)
                    {
                        lastNumber = lastNumber.Insert(6, "00");
                    }

                    queuedTxNumber = long.Parse(lastNumber);
                }

                oZone.SetMetadata(lblLastNumber, (queuedTxNumber + 1).ToString());
                oZone.Save();
            }

            return queuedTxNumber.ToString();
        }

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

            return string.IsNullOrEmpty(result) ? key : result;
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

        /// <summary>
        /// Gets or sets the current user id.
        /// </summary>
        /// <value>The current user id.</value>
        public static Guid CurrentUserId
        {
            get
            {
                Guid cookieStaffId = Guid.Empty;
                if (HttpContext.Current.Request.Cookies["RT2K8_WebShop_LogonStaff"] != null)
                {
                    if (RT2020.DAL.Common.Utility.IsGUID(HttpContext.Current.Request.Cookies["RT2K8_WebShop_LogonStaff"].Value))
                    {
                        cookieStaffId = new Guid(HttpContext.Current.Request.Cookies["RT2K8_WebShop_LogonStaff"].Value);
                    }
                }
                return cookieStaffId;
            }
            set
            {
                System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2K8_WebShop_LogonStaff");
                DateTime now = DateTime.Now;

                oCookie.Value = value.ToString();

                if (value != Guid.Empty)
                {
                    oCookie.Expires = now.AddYears(1);
                }
                else
                {
                    oCookie.Expires = now;
                }

                System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
            }
        }

        /// <summary>
        /// Gets or sets the current workplace id.
        /// </summary>
        /// <value>The current workplace id.</value>
        public static Guid CurrentWorkplaceId
        {
            get
            {
                Guid cookieZoneId = Guid.Empty;
                if (HttpContext.Current.Request.Cookies["RT2K8_WebShop_WorkplaceId"] != null)
                {
                    if (RT2020.DAL.Common.Utility.IsGUID(HttpContext.Current.Request.Cookies["RT2K8_WebShop_WorkplaceId"].Value))
                    {
                        cookieZoneId = new Guid(HttpContext.Current.Request.Cookies["RT2K8_WebShop_WorkplaceId"].Value);
                    }
                }
                return cookieZoneId;
            }
            set
            {
                System.Web.HttpCookie oCookie = new System.Web.HttpCookie("RT2K8_WebShop_WorkplaceId");
                DateTime now = DateTime.Now;

                oCookie.Value = value.ToString();

                if (value != Guid.Empty)
                {
                    oCookie.Expires = now.AddYears(1);
                }
                else
                {
                    oCookie.Expires = now;
                }

                System.Web.HttpContext.Current.Response.Cookies.Add(oCookie);
            }
        }
    }
}
