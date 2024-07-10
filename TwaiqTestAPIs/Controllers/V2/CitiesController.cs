using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwaiqTestAPIs.Dtos;
using TwaiqTestAPIs.Models;
using TwaiqTestAPIs.Repositories;

namespace TwaiqTestAPIs.Controllers.V2;

[Route("cities")]
[ApiController]
[ApiVersion(2)]
public class CitiesController : ControllerBase
{
    private readonly ICityInfoRepository _infoRepository;
    private readonly IMapper _mapper;

    public CitiesController(ICityInfoRepository infoRepository, IMapper mapper)
    {
        _infoRepository = infoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> IndexAsync([FromQuery] string? cityName, [FromQuery] string? queryString, int pageSize = 1, int pageNumber = 1)
    {
        return Ok(_mapper.Map<IEnumerable<CityDto>>(await _infoRepository.GetCitiesAsync(cityName, queryString, pageSize, pageNumber)));
    }

    [HttpGet("{cityId}")]
    public async Task<IActionResult> GetCitiesAsync(int cityId)
    {
        City? city = await _infoRepository.GetCityAsync(cityId);
        return city != null ? Ok("Sucess") : NotFound();
    }
}
