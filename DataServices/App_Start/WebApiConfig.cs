using Data.Ef;
using Domain;
using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData.Batch;
using Microsoft.Restier.Publishers.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataServices
{
    public static class WebApiConfig
    {
        public async static void Register(HttpConfiguration config)
        {
            await config.MapRestierRoute<EntityFrameworkApi<RestierDbContext>>(
                "restier",
                "restier",
                new RestierBatchHandler(GlobalConfiguration.DefaultServer));
        }
    }
}
