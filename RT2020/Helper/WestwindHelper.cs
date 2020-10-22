using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Westwind.Globalization;

namespace RT2020.Helper
{
    public class WestwindHelper
    {
        /// <summary>
        /// 2020.08.28 paulus:
        /// 預設 ResouceSet = "General", ResourceId = "logon"
        /// 找出 Invariant = en, plus other supported locales
        /// </summary>
        /// <returns>Dictionary = locale id, locale native name</locale></returns>
        public static Dictionary<string, string> GetLocaleList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var mgr = DbResourceDataManager.CreateDbResourceDataManager();
            var list = mgr.GetResourceStrings("logon", "General", true);
            foreach (var item in list)
            {
                var localeId = (item.Key == String.Empty) ? "en" : item.Key;
                var cultureInfo = new CultureInfo(localeId);
                result.Add(localeId, cultureInfo.NativeName);
            }

            return result;
        }

        public static String GetWord(String resourceId, String resource)
        {
            var result = "";

            result = DbRes.T(resourceId, resource, CookieHelper.CurrentLocaleId);

            return result;
        }

        public static String GetWordWithColon(String resourceId, String resource)
        {
            var result = "";

            result = DbRes.T(resourceId, resource, CookieHelper.CurrentLocaleId) +
                DbRes.T("punctuation.colon", "General", CookieHelper.CurrentLocaleId);

            return result;
        }
    }
}