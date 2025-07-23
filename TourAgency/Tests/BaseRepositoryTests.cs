using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interfaces;

namespace Tests;
public abstract class BaseRepositoryTests<T>
{
    protected IUnitOfWork? _unitOfWork;
    protected TourAgencyDbContext _context;
    private Seeder _seeder;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _context = new TourAgencyDbContext();
        _unitOfWork = new UnitOfWork(_context);
        _seeder = new Seeder(_context);
        SeedDatabase();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _seeder.ClearDatabase();
        _unitOfWork?.Dispose();
        _context?.Dispose();
    }

    private void SeedDatabase()
    {
        _seeder.SeedBuilder();
    }
}