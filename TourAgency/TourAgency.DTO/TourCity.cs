using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class TourCity
    {
        public int CityId { get; set; }

        [Required]
        public int DaysInCity { get; set; }
    }
}
