using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public sealed class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public StarRating Star { get; set; }

    [Required]
    [Column(TypeName = "smallmoney")]
    public decimal DailyPrice { get; set; }

    public bool IncludesMeal { get; set; }

    public EntityStatus Status { get; set; } = null!;

    [Required]
    public City City { get; set; } = null!;

    public ICollection<Service>? AdditionalServices { get; set; }
}