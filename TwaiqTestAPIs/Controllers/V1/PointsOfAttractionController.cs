using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TwaiqTestAPIs.Dtos.RequestDtos;
using TwaiqTestAPIs.Dtos.ResponseDtos;
using TwaiqTestAPIs.Models;
using TwaiqTestAPIs.Repositories;

namespace TwaiqTestAPIs.Controllers.V1;

[Route("cities/{cityId}/points-of-attraction")]
[ApiController]
[ApiVersion(1)]
public class PointsOfAttractionController : ControllerBase
{
    private readonly ICityInfoRepository _infoRepository;
    private readonly IMapper _mapper;

    public PointsOfAttractionController(ICityInfoRepository infoRepository,
                                        IMapper mapper)
    {
        _infoRepository = infoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetLandmarksAsync([FromRoute] int cityId)
    {
        IEnumerable<PointOfAttraction> poi = await _infoRepository.GetPointsOfInterestForCityAsync(cityId);
        return poi == null ? NotFound() : Ok(_mapper.Map<IEnumerable<PointOfAttractionCreationResponseDto>>(poi));
    }

    [HttpGet("{poa}", Name = "point-of-attraction")]
    public async Task<IActionResult> GetLandmarkAsync([FromRoute] int cityId, [FromRoute] int poa)
    {
        PointOfAttraction? poi = await _infoRepository.GetPointOfInterestForCityAsync(cityId, poa);

        return poi != null ? Ok(_mapper.Map<PointOfAttractionCreationResponseDto>(poi)) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddPointOfAttractionAsync([FromRoute] int cityId, [FromBody] PointOfAttractionCreationRequestDto pointOfAttraction)
    {
        PointOfAttraction poi = _mapper.Map<PointOfAttraction>(pointOfAttraction);
        poi.CityId = cityId;

        PointOfAttraction v = await _infoRepository.AddPointOfAttractionAsync(poi);
        return CreatedAtRoute(
            "point-of-attraction",
            new { cityId, attractionId = v.Id },
            _mapper.Map<PointOfAttractionCreationResponseDto>(v));
    }

    [HttpDelete("{poa}")]
    public async Task<IActionResult> DeletePointOdAttraction(int cityId, int poa)
    {
        if (!await _infoRepository.CheckCityExistAsync(cityId)) return NotFound();
        if (!await _infoRepository.DeletePointOfAttractionAsync(poa)) return NotFound();

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePointOfAttraction([FromBody] PointOfAttractionUpdateRequestDto userValuePoi)
    {
        if (!await _infoRepository.CheckCityExistAsync(userValuePoi.CityId)) return NotFound();

        PointOfAttraction? EntityPoi = await _infoRepository.GetPointOfInterestForCityAsync(userValuePoi.CityId, userValuePoi.Id);
        if (EntityPoi == null) return NotFound();

        PointOfAttraction updatedPoi = _mapper.Map(userValuePoi, EntityPoi);
        await _infoRepository.SaveChangesAsync();

        return Ok(_mapper.Map<PointOfAttractionUpdateResponseDto>(updatedPoi));
    }

    [HttpPatch("{poa}")]
    public async Task<IActionResult> PartialUpdatePointOfAttraction([FromRoute] int cityId, [FromRoute] int poa,
        [FromBody] JsonPatchDocument<PointOfAttractionUpdateRequestDto> patchDocument)
    {
        if (!await _infoRepository.CheckCityExistAsync(cityId)) return NotFound();

        PointOfAttraction? entityPoi = await _infoRepository.GetPointOfInterestForCityAsync(cityId, poa);
        if (entityPoi == null) return NotFound();

        PointOfAttractionUpdateRequestDto patchedPoi = _mapper.Map<PointOfAttractionUpdateRequestDto>(entityPoi);
        patchDocument.ApplyTo(patchedPoi, ModelState);
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _mapper.Map(patchedPoi, entityPoi);
        await _infoRepository.SaveChangesAsync();
        return NoContent();
    }
}
