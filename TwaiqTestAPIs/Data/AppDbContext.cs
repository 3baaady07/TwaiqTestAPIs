using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwaiqTestAPIs.Models;

namespace TwaiqTestAPIs.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<City> Cities { get; set; }
    public DbSet<PointOfAttraction> Attractions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
