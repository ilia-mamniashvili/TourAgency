using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;
//1. Create base class and move common logic there
//2. Create method for inserting default test data //seeding
//3. Create method for deleting test data
//4. Create update and delete test
//5. Create negative tests
public class CountryRepositoryTests : BaseRepositoryTests<Country>
{
    private ICountryRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.Country;
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
        _repository?.Insert(country);
        _unitOfWork!.SaveChanges();

        // Verify that the country was inserted
        var insertedCountry = _unitOfWork.Country.GetById(country.Id);
        Assert.IsNotNull(insertedCountry);
        Assert.That(insertedCountry.Name, Is.EqualTo("Test Country"));
        Assert.That(insertedCountry.IsoCode, Is.EqualTo("TST"));
    }

    [Test]
    public void TestInsert_ShouldNotInsert()
    {
        Country country = new()
        {
            Name = null,
            IsoCode = "STSSS",
            Flag = null,
            Status = new EntityStatus()
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(country);
            _unitOfWork!.SaveChanges();
        });
    }

    [Test]
    public void TestUpdate_ShouldUpdate()
    {
        Country country = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(country);

        country.Name = "Updated Name";
        country.IsoCode = "UPD";
        _repository.Update(country);
        _unitOfWork!.SaveChanges();

        Country updatedCountry = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(updatedCountry);
        Assert.That(country.Name, Is.EqualTo(updatedCountry.Name));
        Assert.That(country.IsoCode, Is.EqualTo(updatedCountry.IsoCode));
    }

    [Test]
    public void TestUpdate_ShouldNotUpdate()
    {
        Country country = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(country);

        country.Name = null;
        country.IsoCode = "UPDT";

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Update(country);
            _unitOfWork!.SaveChanges();
        });
    }

    [Test]
    public void TestDelete_ShouldDelete()
    {
        Country country = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(country, $"Record with Id {Constants.DeleteTestID} doesn't exist");

        _repository.Delete(country);
        _unitOfWork!.SaveChanges();

        Country deletedCountry = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNull(deletedCountry, $"Record with Id {Constants.DeleteTestID} should not be retried");
    }

    [Test]
    public void TestDelete_ShouldNotDelete()
    {
        Country country = _repository!.GetById(Constants.DeleteTestID2)!;
        Assert.IsNotNull(country, $"Record with Id {Constants.DeleteTestID2} doesn't exist");

        _repository.Delete(country);
        _unitOfWork!.SaveChanges();

        Country deletedCountry = _repository!.GetById(Constants.DeleteTestID2)!;
        Assert.IsNull(deletedCountry, $"Record with Id {Constants.DeleteTestID2} should not be retried");
        Assert.Throws<DbUpdateConcurrencyException>(() =>
        {
            _repository.Delete(country);
            _unitOfWork!.SaveChanges();
        });
    }
}
