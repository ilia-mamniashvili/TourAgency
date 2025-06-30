namespace TourAgency.DTO
{
    public sealed class TouristTour
    {
        public string TourCode { get; set; } = null!;

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
