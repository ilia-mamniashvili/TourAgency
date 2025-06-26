using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        public decimal DailyPrice { get; set; }

        public bool IncludesMeal { get; set; }

        public string AdditionalServices { get; set; } = ""; // Comma-separated

        [Required]
        public int CityId { get; set; }
    }
}
