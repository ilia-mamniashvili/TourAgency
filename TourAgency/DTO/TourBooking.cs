using System.ComponentModel.DataAnnotations;

namespace DTO;

public sealed class TourBooking
{
    [Key]
    public long Id { get; set; }

    public DateTime BookDate { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public Tour Tour { get; set; } = null!;

    [Required]
    public Tourist Tourist { get; set; } = null!;
}