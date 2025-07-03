using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public sealed class Tourist
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "char(11)")]
    public string PersonalNumber { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public EntityStatus Status { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    public ICollection<TourBooking>? TourHistory { get; set; }
}