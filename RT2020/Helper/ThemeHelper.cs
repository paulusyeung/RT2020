using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class ThemeHelper
    {
        public static Color TopPanel_BackgroundColor
        {
            get
            {
                Color color = Color.FromName("#ACC0E9");    // default color
                if (HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"] != null)
                {
                    color = HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"].Value == String.Empty ?
                        Color.FromName("#ACC0E9") :
                        Color.FromName(HttpContext.Current.Request.Cookies["RT2020_TopPanelBackgroundColor"].Value);
                }
                return color;
            }
            set
            {
                HttpCookie oCookie = new HttpCookie("RT2020_TopPanelBackgroundColor");

                if (value != null)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString();
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

        public static Color WspPanel_BackgroundColor
        {
            get
            {
                var light = Color.FromName("#ACC0E9");
                var dark = Color.FromName("#212121");

                return (CurrentTheme == "light") ? light : dark;
            }
        }

        /// <summary>
        /// 2020.08.28 paulus:
        /// Return theme names used by VWG, either: Vista = light theme or Graphite = dark theme
        /// </summary>
        public static String CurrentThemeVWGName
        {
            get
            {
                String theme = "", result = "";
                if (HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"] != null)
                {
                    theme = HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"].Value;
                }
                switch (theme.ToLower())
                {
                    case "dark":
                    case "graphite":
                        result = "Graphite";
                        break;
                    case "light":
                    case "vista":
                    default:
                        result = "Vista";
                        break;
                }
                return result;
            }
            set
            {
                HttpCookie oCookie = new HttpCookie("RT2020_CurrentTheme");

                if (value != null)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString() == String.Empty ? "light" : value.ToString();
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

        /// <summary>
        /// 2020.08.28 paulus:
        /// RT2020 supports light or dark themes, default is light
        /// </summary>
        public static String CurrentTheme
        {
            get
            {
                String theme = "light";
                if (HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"] != null)
                {
                    theme = HttpContext.Current.Request.Cookies["RT2020_CurrentTheme"].Value;
                }
                return theme;
            }
            set
            {
                HttpCookie oCookie = new HttpCookie("RT2020_CurrentTheme");

                if (value != null)
                {
                    // create the cookie
                    DateTime now = DateTime.Now;

                    oCookie.Value = value.ToString() == String.Empty ? "light" : value.ToString();
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

        /// <summary>
        /// 2020.08.28 paulus:
        /// Append the CurrentThem as prefix
        /// </summary>
        /// <param name="target">eg 16.power.png</param>
        /// <param name="neutral">default false, use Current Them</param>
        /// <returns>if dark theme, dark.16.power.png</returns>
        public static String GetIconThemed(String target, bool neutral = false)
        {
            var result = String.Format("{0}.{1}", neutral ? "neutral" : CurrentTheme, target);

            return result;
        }
    }
}