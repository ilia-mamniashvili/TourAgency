using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(TourAgencyDbContext context) : base(context) { }
}
