using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;

namespace TwaiqTestAPIs.OpstionsSetup;

/// <summary>
/// 
/// </summary>
public class ApiExplorerOptionsSetup : IConfigureOptions<ApiExplorerOptions>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public void Configure(ApiExplorerOptions options)
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    }
}
