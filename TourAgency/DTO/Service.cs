using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class Service
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public EntityStatus Status { get; set; } = null!;

    public ICollection<Hotel>? Hotels { get; set; }
}