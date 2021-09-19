using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using Thinktecture.IdentityModel.Http.Cors;
using Thinktecture.IdentityModel.Http.Cors.IIS;

namespace RT2020.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region When making calls to Rest services, deactivating the NagleAlgorithm can reduce latency when the data transferred over the network is small.
            // refer: https://alexandrebrisebois.wordpress.com/2013/03/24/why-are-webrequests-throttled-i-want-more-throughput/
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.DefaultConnectionLimit = 1000;
            #endregion

            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureCors(UrlBasedCorsConfiguration.Configuration);
        }

        /// <summary>
        /// 2020.04.06 paulus
        /// 處理　CORS　帶嚟嘅麻煩，參考：
        /// https://stackoverflow.com/questions/14248154/cors-support-in-webapi-mvc-and-iis-with-thinktecture-identitymodel
        /// https://brockallen.com/2012/06/28/cors-support-in-webapi-mvc-and-iis-with-thinktecture-identitymodel/
        /// </summary>
        /// <param name="corsConfig"></param>
        void ConfigureCors(CorsConfiguration corsConfig)
        {
            corsConfig
               .ForResources("~/Handler1.ashx")
               .ForOrigins("http://localhost:8080", "https://sb.directoutput.com.hk")
               .AllowAll();
        }
    }
}
