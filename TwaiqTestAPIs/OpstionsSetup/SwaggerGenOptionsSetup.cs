using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace TwaiqTestAPIs.OpstionsSetup;

/// <summary>
/// 
/// </summary>
public class SwaggerGenOptionsSetup : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IServiceProvider _serviceProvider;

    public SwaggerGenOptionsSetup(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        IApiVersionDescriptionProvider apiVersionDescriptionProvider = 
            _serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                $"{description.GroupName}",
                new()
                {
                    Title = "CityInfo API",
                    Version = description.ApiVersion.ToString(),
                    Description = "Through this API you can access cities and their points of interest."
                });
        }

        string xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

        options.IncludeXmlComments(xmlCommentsFullPath);
    }
}
