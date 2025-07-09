using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class TourRepository : RepositoryBase<Tour>, ITourRepository
{
    public TourRepository(TourAgencyDbContext context) : base(context) { }
}
