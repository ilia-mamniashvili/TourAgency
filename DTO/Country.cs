using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string IsoCode { get; set; } = null!;

    [Required]
    public byte[] Flag { get; set; } = null!;

    // Move this to complex type, also add there create date, update date, etc.
    public bool IsActive { get; set; } = true;

    public ICollection<City>? Cities { get; set; }
}