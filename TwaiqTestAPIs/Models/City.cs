using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwaiqTestAPIs.Models;

public class City
{
    public City(string name)
    {
        Name = name;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? Name { get; private set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    public IEnumerable<PointOfAttraction>? PointsOfAttraction { get; set; }
}
