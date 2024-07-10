using Microsoft.Extensions.Options;

namespace TwaiqTestAPIs.OpstionsSetup;

public class WeatherHttpClientOptionsSetup : IConfigureOptions<HttpClient>
{
    public void Configure(HttpClient options)
    {
        options.BaseAddress = new Uri("");
    }
}
