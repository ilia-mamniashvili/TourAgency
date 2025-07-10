using DTO;
using Repositories.Interfaces;

namespace Repositories;

public class TouristRepository : RepositoryBase<Tourist>, ITouristRepository
{
    public TouristRepository(TourAgencyDbContext context) : base(context) { }
}
