using DTO;
using Repositories.Interfaces;

namespace Repositories;

public class TourBookingRepository : RepositoryBase<TourBooking>, ITourBookingRepository
{
    public TourBookingRepository(TourAgencyDbContext context) : base(context) { }
}
