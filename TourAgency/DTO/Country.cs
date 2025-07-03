using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public string IsoCode { get; set; } = null!;

    [Required]
    public byte[] Flag { get; set; } = null!;

    public EntityStatus Status { get; set; } = null!;

    public ICollection<City>? Cities { get; set; }
}