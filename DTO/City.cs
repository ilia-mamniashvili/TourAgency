using System.ComponentModel.DataAnnotations;
using TourAgency.DTO;

namespace DTO;

public sealed class City
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public string IsoCode { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    [Required]
    public Country Country { get; set; } = null!;

    public ICollection<Hotel>? Hotels { get; set; }
}