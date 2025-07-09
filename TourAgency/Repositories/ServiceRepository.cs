using DTO;
using Repositories.Interfaces;

namespace Repositories.Implementations;

public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(TourAgencyDbContext context) : base(context) { }
}
