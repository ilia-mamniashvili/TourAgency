using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class TourBookingRepository : RepositoryBase<TourBooking>, ITourBookingRepository
{
    public TourBookingRepository(TourAgencyDbContext context) : base(context) { }
}
