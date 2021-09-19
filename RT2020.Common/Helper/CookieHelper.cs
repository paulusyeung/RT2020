using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace RT2020.Common.Helper
{
    public class CookieHelper
    {
        public static String CurrentLocaleId
        {
            get
            {
                // get browser default language
                var localeId = Thread.CurrentThread.CurrentUICulture.Name;

                // if cookie exist, use it
                if (HttpContext.Current.Request.Cookies["RT2020_CurrentLocaleId"] != null)
                {
                    localeId = (String)HttpContext.Current.Request.Cookies["RT2020_CurrentLocaleId"].Value;
                }
                return localeId;
            }
            set
            {
                HttpCookie oCookie = new HttpCookie("RT2020_CurrentLocaleId");

                if (value != null)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString() == String.Empty ? "en" : value.ToString();
                    oCookie.Expires = now.AddYears(1);

                    HttpContext.Current.Response.Cookies.Add(oCookie);
                }
                else
                {
                    // destory the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
                    oCookie.Expires = now.AddDays(-1);

                    HttpContext.Current.Response.Cookies.Add(oCookie);
                }
            }
        }
    }
}