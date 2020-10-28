using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RT2020.Helper
{
    public class NetSqlAzManHelper
    {
        public static bool UseNetSqlAzMan
        {
            get
            {
                return String.IsNullOrEmpty(WebConfigurationManager.AppSettings["UseNetSqlAzMan"]) ?
                    false :
                    bool.Parse(WebConfigurationManager.AppSettings["UseNetSqlAzMan"].ToString());
            }
        }

        public static String ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["NetSqlAzMan"].ConnectionString;
            }
        }
    }
}