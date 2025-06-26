using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class TourCity
    {
        public int CityId { get; set; }

        [Required]
        public int DaysInCity { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
