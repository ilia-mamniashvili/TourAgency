using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class Tour
    {
        [Required]
        [StringLength(5)]
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        [Required]
        public int DurationDays { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalPrice { get; set; }

        public List<TourCity> Cities { get; set; } = new();
    }
}
