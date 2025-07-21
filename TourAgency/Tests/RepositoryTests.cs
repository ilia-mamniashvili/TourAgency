using DTO;
using Repositories;
using Repositories.Interfaces;

namespace Tests;
//1. Create base class and move common logic there
//2. Create method for inserting default test data //seeding
//3. Create method for deleting test data
//4. Create update and delete test
//5. Create negative tests
public class CountryRepositoryTests
{
    private IUnitOfWork _unitOfWork;
       
    [SetUp]
    public void Setup()
    {
        // Initialize the UnitOfWork with a mock or real DbContext
        _unitOfWork = new UnitOfWork(new TourAgencyDbContext());
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        Country country = new Country()
        {
            Name = "Test Country",
            IsoCode = "TST",
            Flag = null, // Assuming no flag is provided for this test
            Status = new EntityStatus()
        };
        _unitOfWork.Country.Insert(country);
        _unitOfWork.SaveChanges();

        // Verify that the country was inserted
        var insertedCountry = _unitOfWork.Country.GetById(country.Id);
        Assert.IsNotNull(insertedCountry);
        Assert.That(insertedCountry.Name, Is.EqualTo("Test Country"));
        Assert.That(insertedCountry.IsoCode, Is.EqualTo("TST"));
    }

    [TearDown]
    public void TearDown()
    {
        _unitOfWork?.Dispose();
    }
}
