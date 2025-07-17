using Repositories;

namespace TourAgency.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TourAgencyDbContext context = new TourAgencyDbContext();
            context.Database.EnsureCreated();
        }
    }
}
