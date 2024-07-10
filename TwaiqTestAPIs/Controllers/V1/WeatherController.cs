using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwaiqTestAPIs.Data;
using TwaiqTestAPIs.Repositories;

namespace TwaiqTestAPIs.Controllers.V1;

[ApiController]
[Route("cities/{cityId}/weather")]
[ApiVersion(1)]
public class WeatherController : ControllerBase
{
    private readonly ICityInfoRepository _infoRepository;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AppDbContext _appDbContext;

    public WeatherController(ICityInfoRepository infoRepository, IMapper mapper, IHttpClientFactory httpClientFactory, AppDbContext appDbContext)
    {
        _infoRepository = infoRepository;
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeatherAsync([FromRoute] int cityId)
    {
        using (var client = _httpClientFactory.CreateClient())
        {

        }
        return Ok();
    }
}
