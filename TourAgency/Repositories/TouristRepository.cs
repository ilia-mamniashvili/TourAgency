using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class TouristRepository : RepositoryBase<Tourist>, ITouristRepository
{
    public TouristRepository(TourAgencyDbContext context) : base(context) { }
}
