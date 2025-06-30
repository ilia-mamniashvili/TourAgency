using DTO;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{

    public sealed class Tourist
    {
        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public EntityStatus Status { get; set; }
        public string PhoneNumber { get; set; } = null!;

        public List<TouristTour> TourHistory { get; set; } = new();

    }
}
