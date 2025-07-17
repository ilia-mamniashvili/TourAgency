using DTO;
using Repositories.Interfaces;

namespace Repositories;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(TourAgencyDbContext context) : base(context) { }
}
