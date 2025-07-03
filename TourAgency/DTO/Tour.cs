using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public sealed class Tour
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "char(5)")]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public EntityStatus Status { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }

    public ICollection<TourItem>? Cities { get; set; }
}