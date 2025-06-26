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

        [Required]
        public decimal TotalPrice { get; set; }

        public List<TourCity> Cities { get; set; } = new();
    }
}
