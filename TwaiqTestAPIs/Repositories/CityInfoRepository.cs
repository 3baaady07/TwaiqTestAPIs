using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using TwaiqTestAPIs.Data;
using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Repositories;

public class CityInfoRepository : ICityInfoRepository
{
    private readonly AppDbContext _appDbContext;

    public CityInfoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<City>> GetCitiesAsync(int pageSize, int pageNumber) =>
        await _appDbContext
        .Cities
        .Skip(pageSize * (pageNumber - 1))
        .Take(pageSize)
        .Include(c => c.PointsOfAttraction)
        .ToListAsync();

    public async Task<IEnumerable<City>> GetCitiesAsync(string? cityName, string? searchQuery, int pageSize, int pageNumber)
    {
        if (string.IsNullOrEmpty(cityName) && string.IsNullOrEmpty(searchQuery)) return await GetCitiesAsync(pageSize, pageNumber);

        IQueryable<City> cities = _appDbContext.Cities.Include(c => c.PointsOfAttraction);

        if (!string.IsNullOrEmpty(cityName))
            cities = cities.Where(c => c.Name == cityName);

        if (!string.IsNullOrEmpty(searchQuery))
            cities = cities.Where(c => c.Name!.Contains(searchQuery) || (c.Description != null && c.Description.Contains(searchQuery)));

        return await cities
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<City?> GetCityAsync(int cityId) =>
        await _appDbContext.Cities.Include(c => c.PointsOfAttraction).FirstOrDefaultAsync(c => c.Id == cityId);

    public async Task<IEnumerable<PointOfAttraction>> GetPointsOfInterestForCityAsync(int cityId) =>
        await _appDbContext.Attractions.Where(c => c.CityId == cityId).ToListAsync();

    public async Task<PointOfAttraction?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId) =>
        await _appDbContext.Attractions.Where(c => c.CityId == cityId).FirstOrDefaultAsync(a => a.Id == pointOfInterestId);

    public async Task<bool> CheckCityExistAsync(int cityId) =>
        await _appDbContext.Cities.AnyAsync(c => c.Id == cityId);

    public async Task<PointOfAttraction> AddPointOfAttractionAsync(PointOfAttraction pointOfAttraction)
    {
        EntityEntry<PointOfAttraction> v = await _appDbContext.Attractions.AddAsync(pointOfAttraction);
        _appDbContext.SaveChanges();
        return v.Entity;
    }

    public async Task<bool> DeletePointOfAttractionAsync(int pointOfAttractionId)
    {
        PointOfAttraction? att = await _appDbContext.Attractions.FirstOrDefaultAsync(poi => poi.Id == pointOfAttractionId);

        if (att == null) return false;
        _appDbContext.Attractions.Remove(att);
        await _appDbContext.SaveChangesAsync();

        return true;
    }

    public Task<PointOfAttraction> UpdatePointOfAttractionAsync(PointOfAttraction pointOfAttraction)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
