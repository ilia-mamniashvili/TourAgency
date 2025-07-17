using DTO;
using Repositories.Interfaces;

namespace Repositories;

public class TourItemRepository : RepositoryBase<TourItem>, ITourItemRepository
{
    public TourItemRepository(TourAgencyDbContext context) : base(context) { }
}
