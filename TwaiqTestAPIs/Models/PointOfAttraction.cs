using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TwaiqTestAPIs.Models;

public class PointOfAttraction
{
    public PointOfAttraction(string name)
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

    [ForeignKey(nameof(CityId))]
    public City? City { get; set; }
    public int CityId { get; set; }
}
