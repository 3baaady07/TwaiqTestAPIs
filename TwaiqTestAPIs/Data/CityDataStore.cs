using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Data;

public class CityDataStore
{
    public IEnumerable<City> Cities { get; set; }

    public CityDataStore()
    {
        Cities = new List<City>()
        {
            new City("Riyadh")
            {
                Id = 1,
                Description = "Lorem Ipsum",
                PointsOfAttraction = new List<PointOfAttraction>()
                {
                    new PointOfAttraction("Riyadh Park")
                    {
                        Id = 1,
                        CityId = 1,
                        Description = "Beautiful park"
                    },
                    new PointOfAttraction("Riyadh Mall")
                    {
                        Id = 2,
                        CityId = 1,
                        Description = "Beautiful mall"
                    },
                }
            },
            new City("Jeddah")
            {
                Id = 2,
                Description = "Lorem Ipsum",
                PointsOfAttraction = new List<PointOfAttraction>()
                {
                    new PointOfAttraction("Jeddah Park")
                    {
                        Id = 1,
                        CityId = 2,
                        Description = "Beautiful park"
                    },
                    new PointOfAttraction("Jeddah Mall")
                    {
                        Id = 2,
                        CityId = 2,
                        Description = "Beautiful mall"
                    },
                }
            },
            new City("Dammam")
            {
                Id = 3,
                Description = "Lorem Ipsum",
                PointsOfAttraction = new List<PointOfAttraction>()
                {
                    new PointOfAttraction("Dammam Park")
                    {
                        Id = 1,
                        CityId = 3,
                        Description = "Beautiful park"
                    },
                    new PointOfAttraction("Dammam Mall")
                    {
                        Id = 2,
                        CityId = 3,
                        Description = "Beatiful mall"
                    },
                }
            },
        };
    }
}
