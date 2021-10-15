using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

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
        }
    }
}
