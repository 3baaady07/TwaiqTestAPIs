using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwaiqTestAPIs.Dtos;
using TwaiqTestAPIs.Models;
using TwaiqTestAPIs.Repositories;

namespace TwaiqTestAPIs.Controllers.V1;

[Route("cities")]
[ApiController]
[ApiVersion(1, Deprecated = true)]
public class CitiesController : ControllerBase
{
    private readonly ICityInfoRepository _infoRepository;
    private readonly IMapper _mapper;

    public CitiesController(ICityInfoRepository infoRepository, IMapper mapper)
    {
        _infoRepository = infoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// City resource API
    /// </summary>
    /// <param name="cityName">A city name to get its info</param>
    /// <param name="queryString">A snippet description of the city to query</param>
    /// <param name="pageSize">Number of cities to retrieve</param>
    /// <param name="pageNumber">A page offset</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CityDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> IndexAsync([FromQuery] string? cityName, [FromQuery] string? queryString, int pageSize = 1, int pageNumber = 1)
    {
        return Ok(_mapper.Map<IEnumerable<CityDto>>(await _infoRepository.GetCitiesAsync(cityName, queryString, pageSize, pageNumber)));
    }

    /// <summary>
    /// Get a city by ID
    /// </summary>
    /// <param name="cityId">The Id of the city to retreive</param>
    /// <returns></returns>
    [HttpGet("{cityId}")]
    [ProducesResponseType(typeof(CityDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCitiesAsync(int cityId)
    {
        City? city = await _infoRepository.GetCityAsync(cityId);
        return city != null ? Ok(_mapper.Map<CityDto>(city)) : NotFound();
    }
}