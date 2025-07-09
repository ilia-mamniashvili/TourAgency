using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(TourAgencyDbContext context) : base(context) { }
}
