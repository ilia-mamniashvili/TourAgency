using DTO;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public sealed class TourCity
    {
        public int CityId { get; set; }

        [Required]
        public int DaysInCity { get; set; }

        public EntityStatus Status { get; set; }
    }
}
