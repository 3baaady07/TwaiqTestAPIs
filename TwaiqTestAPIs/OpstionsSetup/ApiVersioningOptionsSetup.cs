using Asp.Versioning;
using Microsoft.Extensions.Options;

namespace TwaiqTestAPIs.OpstionsSetup;

public class ApiVersioningOptionsSetup : IConfigureOptions<ApiVersioningOptions>
{
    public void Configure(ApiVersioningOptions options)
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    }
}
