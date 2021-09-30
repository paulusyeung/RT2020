using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.OData.Extensions;
using System.Web.Http;

using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using RT2020.EF6;

namespace RT2020.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Web API configuration and services
            // 開啟 Authorization，暫時用 Basic Authentication
            config.Filters.Add(new AuthorizeAttribute());
            #endregion

            // Web API routes
            config.MapHttpAttributeRoutes();

            // oData Restier: 目前冇用 ref: https://github.com/OData/RESTier
            //config.EnableUnqualifiedNameCall(true);
            //RegisterRT2020Api(config, GlobalConfiguration.DefaultServer);

            // 使用 Microsoft.AspNet.WebApi.Cors, ref: https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterRT2020Api(HttpConfiguration config, HttpServer server)
        {
            config.MapRestierRoute<EntityFrameworkApi<RT2020Entities>>(
                "RT2020",
                "api/RT2020",
                new RestierBatchHandler(server));
        }
    }
}
