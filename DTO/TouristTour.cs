namespace TourAgency.DTO
{
    public class TouristTour
    {
        public string TourCode { get; set; } = null!;

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
