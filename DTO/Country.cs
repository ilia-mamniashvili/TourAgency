using System.ComponentModel.DataAnnotations;

namespace TourAgency.DTO
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = true;

    }
}
