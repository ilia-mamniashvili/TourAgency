using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class TourItemRepository : RepositoryBase<TourItem>, ITourItemRepository
{
    public TourItemRepository(TourAgencyDbContext context) : base(context) { }
}
