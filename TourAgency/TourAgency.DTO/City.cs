using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }
    }
}
