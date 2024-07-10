using AutoMapper;
using TwaiqTestAPIs.Dtos.RequestDtos;
using TwaiqTestAPIs.Dtos.ResponseDtos;
using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Profiles;

public class PointOfAttractionProfile : Profile
{
    public PointOfAttractionProfile()
    {
        CreateMap<PointOfAttraction, PointOfAttractionCreationResponseDto>();
        CreateMap<PointOfAttractionCreationRequestDto, PointOfAttraction>();
        CreateMap<PointOfAttractionUpdateRequestDto, PointOfAttraction>();
        CreateMap<PointOfAttraction, PointOfAttractionUpdateResponseDto>();
    }
}
