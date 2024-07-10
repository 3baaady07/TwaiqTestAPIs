using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Repositories;

public interface ICityInfoRepository
{
    Task<IEnumerable<City>> GetCitiesAsync(int pageSize, int pageNumber);
    Task<IEnumerable<City>> GetCitiesAsync(string? cityName, string? searchQuery, int pageSize, int pageNumber);
    Task<City?> GetCityAsync(int cityId);
    Task<IEnumerable<PointOfAttraction>> GetPointsOfInterestForCityAsync(int cityId);
    Task<PointOfAttraction?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);
    Task<bool> CheckCityExistAsync(int cityId);
    Task<PointOfAttraction> AddPointOfAttractionAsync(PointOfAttraction pointOfAttraction);
    Task<bool> DeletePointOfAttractionAsync(int pointOfAttractionId);
    Task<PointOfAttraction> UpdatePointOfAttractionAsync(PointOfAttraction pointOfAttraction);
    Task SaveChangesAsync();
}
