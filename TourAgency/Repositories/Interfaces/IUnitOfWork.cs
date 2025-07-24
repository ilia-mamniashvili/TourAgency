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
        void BeginTransaction();
        void Commit();
        void Rollback();

        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess);
        Task RollbackAsync();
        Task CommitAsync();

        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        IHotelRepository HotelRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ITourBookingRepository TourBookingRepository { get; }
        ITouristRepository TouristRepository { get; }
        ITourItemRepository TourItemRepository { get; }
        ITourRepository TourRepository { get; }

    }
}
