using RT2020.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RT2020.Helper
{
    public class WebConfigHelper
    {
        /// <summary>
        /// Get the number of alternate languages from Web.config
        /// </summary>
        /// <returns>default = 0, could be 1 or 2 (max)</returns>
        public static int AltLanguages()
        {
            var result = 0;

            var lang = WebConfigurationManager.AppSettings["AltLangauges"];
            if (lang != null) int.TryParse(lang, out result);

            return result;
        }
    }
}