using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;


namespace Westwind.Globalization.Tools
{
    /// <summary>
    /// Set of miscellaneous Web application related utility functions
    /// </summary>
    public class wwWebUtils
    {
        #region Utility Functions
        /// <summary>
        /// Finds a Control recursively. Note finds the first match and exits
        /// </summary>
        /// <param name="ContainerCtl"></param>
        /// <param name="IdToFind"></param>
        /// <returns></returns>
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }

            return null;
        }

        /// <summary>
        /// Restarts the Web Application
        /// Requires either Full Trust (HttpRuntime.UnloadAppDomain) 
        /// or Write access to web.config.
        /// </summary>
        public static bool RestartWebApplication()
        {
            bool Error = false;
            try
            {
                // *** This requires full trust so this will fail
                // *** in many scenarios
                HttpRuntime.UnloadAppDomain();
            }
            catch
            {
                Error = true;
            }

            if (!Error)
                return true;

            // *** Couldn't unload with Runtime - let's try modifying web.config
            string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "\\web.config";

            try
            {
                File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets a user's Locale based on the browser's Locale setting. If no setting
        /// is provided the default Locale is used.
        /// </summary>
        public static void SetUserLocale(string CurrencySymbol, bool SetUiCulture)
        {
            HttpRequest Request = HttpContext.Current.Request;
            if (Request.UserLanguages == null)
                return;

            string Lang = Request.UserLanguages[0];
            if (Lang != null)
            {
                // *** Problems with Turkish Locale and upper/lower case
                // *** DataRow/DataTable indexes
                if (Lang.StartsWith("tr"))
                    return;

                if (Lang.Length < 3)
                    Lang = Lang + "-" + Lang.ToUpper();
                try
                {
                    System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo(Lang);
                    System.Threading.Thread.CurrentThread.CurrentCulture = Culture;

                    if (!string.IsNullOrEmpty(CurrencySymbol))
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol =
                          CurrencySymbol;

                    if (SetUiCulture)
                        System.Threading.Thread.CurrentThread.CurrentUICulture = Culture;
                }
                catch
                { ;}
            }


        }

        /// <summary>
        /// Encodes a string to be represented as a string literal. The format
        /// is essentially a JSON string.
        /// 
        /// The string returned includes outer quotes 
        /// Example Output: "Hello \"Rick\"!\r\nRock on"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }
        #endregion

    }
}
