using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Westwind.Utilities;

namespace VWGi18nTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Disable URL Localization.
            i18n.UrlLocalizer.UrlLocalizationScheme = i18n.UrlLocalizationScheme.Void;

            // Change from the default of 'en'.
            i18n.LocalizedApplication.Current.DefaultLanguage = "zh-CN";
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Automatically set the user's locale to what the browser returns
            // and optionally only allow certain locales/locale-prefixes
            WebUtils.SetUserLocale(allowedLocales: "en,zh-CN,zh-HK", currencySymbol: "$");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}