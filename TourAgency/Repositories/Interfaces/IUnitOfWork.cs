using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess);
        Task RollbackAsync();
        Task CommitAsync();

        ICityRepository City { get; }
        ICountryRepository Country { get; }
        IEntityStatusRepository EntityStatus { get; }
        IHotelRepository Hotel { get; }
        IServiceRepository Service { get; }
        ITourBookingRepository TourBooking { get; }
        ITouristRepository Tourist { get; }
        ITourItemRepository TourItem { get; }
        ITourRepository Tour { get; }

    }
}
