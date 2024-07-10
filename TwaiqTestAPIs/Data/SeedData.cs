using Microsoft.EntityFrameworkCore;
using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Data;

public static class SeedDataExtension
{
    public static IHost SeedData(this IHost host)
    {
        using (IServiceScope scope = host.Services.CreateScope())
        {
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            try
            {
                if (!dbContext.Cities.Any())
                {

                    dbContext.Cities.AddRange(new[] 
                    {
                        new City("Riyadh")
                        {
                            Description = "Lorem Ipsum",
                        },
                        new City("Jeddah")
                        {
                            Description = "Lorem Ipsum",
                        },
                        new City("Dammam")
                        {
                            Description = "Lorem Ipsum",
                        }
                    });

                    dbContext.SaveChanges();

                    City ruh = dbContext.Cities.First(x => x.Name == "Riyadh");
                    City jed = dbContext.Cities.First(x => x.Name == "Jeddah");
                    City dmm = dbContext.Cities.First(x => x.Name == "Dammam");

                    ruh.PointsOfAttraction = new List<PointOfAttraction>()
                        {
                            new PointOfAttraction("Riyadh Park")
                            {
                                Description = "Beautiful park"
                            },
                            new PointOfAttraction("Riyadh Mall")
                            {
                                Description = "Beautiful mall"
                            },
                        };
                    dbContext.Update(ruh);

                    jed.PointsOfAttraction = new List<PointOfAttraction>()
                        {
                            new PointOfAttraction("Jeddah Park")
                            {
                                Description = "Beautiful park"
                            },
                            new PointOfAttraction("Jeddah Mall")
                            {
                                Description = "Beautiful mall"
                            },
                        };
                    dbContext.Update(jed);

                    dmm.PointsOfAttraction = new List<PointOfAttraction>()
                        {
                            new PointOfAttraction("Dammam Park")
                            {
                                Description = "Beautiful park"
                            },
                            new PointOfAttraction("Dammam Mall")
                            {
                                Description = "Beatiful mall"
                            },
                        };
                    dbContext.Update(dmm);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
        return host;
    }
}
