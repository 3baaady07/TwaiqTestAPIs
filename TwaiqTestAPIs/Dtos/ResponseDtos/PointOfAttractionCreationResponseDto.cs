using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Dtos.ResponseDtos;

public class PointOfAttractionCreationResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CityId { get; set; }
}
