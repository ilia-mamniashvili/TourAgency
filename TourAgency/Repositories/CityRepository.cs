using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(TourAgencyDbContext context) : base(context) { }
}
