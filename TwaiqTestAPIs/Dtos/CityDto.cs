using System.ComponentModel.DataAnnotations;
using TwaiqTestAPIs.Dtos.ResponseDtos;

namespace TwaiqTestAPIs.Dtos;

public class CityDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ICollection<PointOfAttractionCreationResponseDto> PointsOfAttraction { get; set; } = new List<PointOfAttractionCreationResponseDto>();
    public int NumberOfPointsOfAttraction => PointsOfAttraction.Count;


}
