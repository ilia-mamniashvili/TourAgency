using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int DurationDays { get; set; }

        public EntityStatus Status { get; set; } = null!;

        [Required]
        public decimal TotalPrice { get; set; }

        public ICollection<TourItem>? Cities { get; set; }
    }
}
