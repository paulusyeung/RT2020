using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RT2020.Common.Helper
{
    public class LanguageHelper
    {
        /// <summary>
        /// RT2020 uses English as the default language
        /// RT2020 can take a max of 2 alternate language for each object (e.g. dbo.Staff.Name)
        /// </summary>
        /// <returns>default = 0, max = 2</returns>
        private static int _AlternateLanguagesUsed = 0;
        public static int AlternateLanguagesUsed
        {
            get
            {
                // 假設 we use 2 alternate languages
                _AlternateLanguagesUsed = 2;
                string p = WebConfigurationManager.AppSettings["AlternateLanguagesUsed"];
                if (!string.IsNullOrEmpty(p))
                {
                    int.TryParse(p, out _AlternateLanguagesUsed);
                }
                return _AlternateLanguagesUsed;
            }
        }

        /// <summary>
        /// 假設 Alt1 = zh-CN
        /// </summary>
        private static KeyValuePair<string, string> _AlternateLanguage1;
        public static KeyValuePair<string, string> AlternateLanguage1
        {
            get
            {
                string p = WebConfigurationManager.AppSettings["AlternateLanguage1"];
                if (!string.IsNullOrEmpty(p))
                {
                    _AlternateLanguage1 = WestwindHelper.GetLocale(p);
                }
                return _AlternateLanguage1;
            }
            set { _AlternateLanguage1 = value; }
        }

        /// <summary>
        /// 假設 Alt2 = zh-HK
        /// </summary>
        private static KeyValuePair<string, string> _AlternateLanguage2;
        public static KeyValuePair<string, string> AlternateLanguage2
        {
            get
            {
                string p = WebConfigurationManager.AppSettings["AlternateLanguage2"];
                if (!string.IsNullOrEmpty(p))
                {
                    _AlternateLanguage2 = WestwindHelper.GetLocale(p);
                }
                return _AlternateLanguage2;
            }
            set { _AlternateLanguage2 = value; }
        }

        private static KeyValuePair<string, string> _DefaultLanguage;
        public static KeyValuePair<string, string> DefaultLanguage
        {
            get
            {
                _DefaultLanguage = WestwindHelper.GetLocale("en");
                return _DefaultLanguage;
            }
        }

        public enum LanguageMode
        {
            Default,
            Alt1,
            Alt2
        }

        public static LanguageMode CurrentLanguageMode
        {
            get
            {
                var result = LanguageMode.Default;

                //result = CookieHelper.CurrentLocaleId == _AlternateLanguage1.Key ?
                //    result = LanguageMode.Alt1 :
                //    CookieHelper.CurrentLocaleId == _AlternateLanguage2.Key ?
                //    result = LanguageMode.Alt2 :
                //    result = LanguageMode.Default;
                result = CookieHelper.CurrentLocaleId == _AlternateLanguage1.Key ?
                    LanguageMode.Alt1 : CookieHelper.CurrentLocaleId == _AlternateLanguage2.Key ?
                    LanguageMode.Alt2 : LanguageMode.Default;

                return result;
            }
        }
    }
}