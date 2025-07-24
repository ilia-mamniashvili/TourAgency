using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interfaces;

namespace Tests;
public abstract class BaseRepositoryTests<T>
{
    protected IUnitOfWork? _unitOfWork;
    private TourAgencyDbContext _context;

    [SetUp]
    public virtual void SetUp()
    {
        _context = new TourAgencyDbContext();
        _unitOfWork = new UnitOfWork(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _unitOfWork?.Dispose();
        _context?.Dispose();
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var seeder = new Seeder(new TourAgencyDbContext());
        seeder.ClearDatabase();
        seeder.SeedDatabase();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        var seeder = new Seeder(new TourAgencyDbContext());
        seeder.ClearDatabase();
    }
}