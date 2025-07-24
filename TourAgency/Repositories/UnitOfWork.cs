using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TourAgencyDbContext _context;
        private IDbContextTransaction? _transaction;

        //Lazy ლოგიკის იმპლემენტაცია
        private readonly Lazy<ICityRepository> _city;
        private readonly Lazy<ICountryRepository> _country;
        private readonly Lazy<IHotelRepository> _hotel;
        private readonly Lazy<IServiceRepository> _service;
        private readonly Lazy<ITourBookingRepository> _tourBooking;
        private readonly Lazy<ITouristRepository> _tourist;
        private readonly Lazy<ITourItemRepository> _tourItem;
        private readonly Lazy<ITourRepository> _tour;

        public ICityRepository CityRepository => _city.Value;
        public ICountryRepository CountryRepository => _country.Value;
        public IHotelRepository HotelRepository => _hotel.Value;
        public IServiceRepository ServiceRepository => _service.Value;
        public ITourBookingRepository TourBookingRepository => _tourBooking.Value;
        public ITouristRepository TouristRepository => _tourist.Value;
        public ITourItemRepository TourItemRepository => _tourItem.Value;
        public ITourRepository TourRepository => _tour.Value;

        public UnitOfWork(TourAgencyDbContext context)

        {
            _context = context;

            _city = new Lazy<ICityRepository>(() => new CityRepository(_context));
            _country = new Lazy<ICountryRepository>(() => new CountryRepository(_context));
            _hotel = new Lazy<IHotelRepository>(() => new HotelRepository(_context));
            _service = new Lazy<IServiceRepository>(() => new ServiceRepository(_context));
            _tourBooking = new Lazy<ITourBookingRepository>(() => new TourBookingRepository(_context));
            _tourist = new Lazy<ITouristRepository>(() => new TouristRepository(_context));
            _tourItem = new Lazy<ITourItemRepository>(() => new TourItemRepository(_context));
            _tour = new Lazy<ITourRepository>(() => new TourRepository(_context));
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
        {
            return await _context.SaveChangesAsync(acceptAllChangesOnSuccess);
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
                throw new ArgumentException("Transaction is already started");

            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
                throw new ArgumentException("Transaction is already started");

            _transaction = await _context.Database.BeginTransactionAsync();

        }

        public void Commit()
        {
            if (_transaction == null)
                throw new ArgumentException("Transaction is not started");

            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new ArgumentException("Transaction is not started");

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;

        }

        public void Rollback()
        {
            if (_transaction == null)
                throw new ArgumentException("Transaction is not started");

            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new ArgumentException("Transaction is not started");

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;

        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
