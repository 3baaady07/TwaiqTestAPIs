using AutoMapper;
using TwaiqTestAPIs.Dtos;
using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDto>();
    }
}
