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
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableUnqualifiedNameCall(true);
            RegisterRT2020Api(config, GlobalConfiguration.DefaultServer);

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
