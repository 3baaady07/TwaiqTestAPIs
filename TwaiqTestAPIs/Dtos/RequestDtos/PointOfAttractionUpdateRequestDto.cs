namespace TwaiqTestAPIs.Dtos.RequestDtos;

public class PointOfAttractionUpdateRequestDto
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
