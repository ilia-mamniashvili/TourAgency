using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public StarRating Star { get; set; }

    [Required]
    public decimal DailyPrice { get; set; }

    public bool IncludesMeal { get; set; }

    public ICollection<Service> AdditionalServices { get; set; } = new List<Service>();

    public EntityStatus Status { get; set; }

    [Required]
    public City City { get; set; } = null!;
}