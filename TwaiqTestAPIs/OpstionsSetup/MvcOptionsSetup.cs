using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using TwaiqTestAPIs.Conventions;

namespace TwaiqTestAPIs.OpstionsSetup;

public class MvcOptionsSetup : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        options.SuppressAsyncSuffixInActionNames = true;
        IRouteTemplateProvider routeAttribute = new RouteAttribute("/api/v{version:apiVersion}");
        options.Conventions.Add(new RoutePrefixConvention(routeAttribute));
    }
}
