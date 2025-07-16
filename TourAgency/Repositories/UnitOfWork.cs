using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using System.Data;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TourAgencyDbContext _context;
        private IDbContextTransaction? _transaction;
        private bool _disposed;

        //Lazy ლოგიკის იმპლემენტაცია
        private Lazy<ICityRepository> _city;
        private Lazy<ICountryRepository> _country;
        private Lazy<IEntityStatusRepository> _entityStatus;
        private Lazy<IHotelRepository> _hotel;
        private Lazy<IServiceRepository> _service;
        private Lazy<ITourBookingRepository> _tourBooking;
        private Lazy<ITouristRepository> _tourist;
        private Lazy<ITourItemRepository> _tourItem;
        private Lazy<ITourRepository> _tour;

        public ICityRepository City => _city.Value;
        public ICountryRepository Country => _country.Value;
        public IEntityStatusRepository EntityStatus => _entityStatus.Value;
        public IHotelRepository Hotel => _hotel.Value;
        public IServiceRepository Service => _service.Value;
        public ITourBookingRepository TourBooking => _tourBooking.Value;
        public ITouristRepository Tourist => _tourist.Value;
        public ITourItemRepository TourItem => _tourItem.Value;
        public ITourRepository Tour => _tour.Value;

        public UnitOfWork(TourAgencyDbContext context)
            
        {
            _context = context;
            
            _city = new Lazy<ICityRepository>(() => new CityRepository(_context));
            _country = new Lazy<ICountryRepository>(() => new CountryRepository(_context));
            _entityStatus = new Lazy<IEntityStatusRepository>(() => new EntityStatusRepository(_context));
            _hotel = new Lazy<IHotelRepository>(() => new HotelRepository(_context));
            _service = new Lazy<IServiceRepository>(() => new ServiceRepository(_context));
            _tourBooking = new Lazy<ITourBookingRepository>(() => new TourBookingRepository(_context));
            _tourist = new Lazy<ITouristRepository>(() => new TouristRepository(_context));
            _tourItem = new Lazy<ITourItemRepository>(() => new TourItemRepository(_context));
            _tour = new Lazy<ITourRepository>(() => new TourRepository(_context));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
        {
            return await _context.SaveChangesAsync(acceptAllChangesOnSuccess);
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                 await _transaction.RollbackAsync();
                 await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
