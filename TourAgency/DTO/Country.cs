using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public sealed class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(3)")]
    public string IsoCode { get; set; } = null!;

    public byte[]? Flag { get; set; }

    public EntityStatus Status { get; set; } = null!;

    public ICollection<City>? Cities { get; set; }
}