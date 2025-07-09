using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class EntityStatusRepository : RepositoryBase<EntityStatus>, IEntityStatusRepository
{
    public EntityStatusRepository(TourAgencyDbContext context) : base(context) { }
}
