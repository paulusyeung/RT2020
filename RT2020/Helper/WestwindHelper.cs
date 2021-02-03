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
        ///      Invariant = en, plus other supported locales
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


        /// <summary>
        /// 根據 GetLocaleList，搵出啱 Key 嘅 locale
        /// </summary>
        /// <returns>KVP("zh-CN", "中文(中國)")，如果冇，return KVP(null, null)</returns>
        public static KeyValuePair<string, string> GetLocale(string key)
        {
            KeyValuePair<string, string> result = new KeyValuePair<string, string>(null, null);

            var list = GetLocaleList();
            result = list.Where(x => x.Key == key).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// 根據 GetLocaleList，攞第 2 隻 locale 做 Alt1
        /// </summary>
        /// <returns>KVP("zh-CN", "中文(中國)")，如果冇，return KVP(null, null)</returns>
        public static KeyValuePair<string, string> Get1Locale_Alt1()
        {
            KeyValuePair<string, string> result = new KeyValuePair<string, string>(null, null);

            var list = GetLocaleList();
            if (list.Count >= 2) result = list.ElementAt(1);
            
            return result;
        }

        /// <summary>
        /// 根據 GetLocaleList，攞第 3 隻 locale 做 Alt2
        /// </summary>
        /// <returns>KVP("zh-HK", "中文(香港特別行政區)")，如果冇，return KVP(null, null)</returns>
        public static KeyValuePair<string, string> Get1Locale_Alt2()
        {
            KeyValuePair<string, string> result = new KeyValuePair<string, string>(null, null);

            var list = GetLocaleList();
            if (list.Count >= 3) result = list.ElementAt(2);

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

        public static String GetWordWithQuestionMark(String resourceId, String resource)
        {
            var result = "";

            result = DbRes.T(resourceId, resource, CookieHelper.CurrentLocaleId) +
                DbRes.T("punctuation.questionMark", "General", CookieHelper.CurrentLocaleId);

            return result;
        }
    }
}