using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public sealed class TourItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderPosition { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public EntityStatus Status { get; set; } = null!;

        [Required]
        public City City { get; set; } = null!;

        [Required]
        public Tour Tour { get; set; } = null!;

        public Hotel? Hotel { get; set; }
    }
}
