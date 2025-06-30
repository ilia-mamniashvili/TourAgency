using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Range(1, 5)]
    public byte Stars { get; set; } // Move to enum if needed

    [Required]
    public decimal DailyPrice { get; set; }

    public bool IncludesMeal { get; set; }

    public string AdditionalServices { get; set; } // Move to a separate class and make many-to-many if needed

    public bool IsActive { get; set; } = true;

    [Required]
    public City City { get; set; } = null!;
}