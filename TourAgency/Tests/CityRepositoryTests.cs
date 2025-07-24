using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interfaces;

namespace Tests;

public class CityRepositoryTests : BaseRepositoryTests<City>
{
    private  ICityRepository? _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = _unitOfWork!.City;
    }

    [Test]
    public void TestInsert_ShouldInsert()
    {
        City city = new()
        {
            Name = "Test Name",
            IsoCode = "TST",
            Country = _unitOfWork!.Country.GetById(1)!,
            Status = new EntityStatus()
        };

        _repository!.Insert(city);
        _unitOfWork!.SaveChanges();

        City insertedCity = _repository.GetById(city.Id)!;
        Assert.IsNotNull(insertedCity);
        Assert.That(city.Name, Is.EqualTo(insertedCity.Name));
        Assert.That(city.IsoCode, Is.EqualTo(insertedCity.IsoCode));
    }

    [Test]
    public void TestInsert_ShouldNotInsert()
    {
        City city = new()
        {
            Name = null!,
            IsoCode = "TSTI",
            Country = _unitOfWork!.Country.GetById(0)!,
            Status = new EntityStatus()
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(city);
            _unitOfWork.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void TestUpdate_ShouldUpdate()
    {
        City city = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(city);

        city.Name = "Updated Name";
        city.IsoCode = "UPD";
        city.Country = _unitOfWork!.Country.GetById(1)!;
        _repository.Update(city);
        _unitOfWork!.SaveChanges();

        City updatedCity = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(updatedCity);
        Assert.That(city.Name, Is.EqualTo(updatedCity.Name));
        Assert.That(city.IsoCode, Is.EqualTo(updatedCity.IsoCode));
        Assert.That(city.Country.Id, Is.EqualTo(updatedCity.Country.Id));
    }

    [Test]
    public void TestUpdate_ShouldNotUpdate()
    {
        City city = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(city);
        city.Name = null!;
        city.IsoCode = "TUPD";
        Country country = _unitOfWork!.Country.GetById(0)!;

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Update(city);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void TestDelete_ShouldDelete()
    {
        City city = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(city, $"Record with Id {Constants.DeleteTestID} doesn't exist");

        _repository.Delete(city);
        _unitOfWork!.SaveChanges();

        City deletedCity = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNull(deletedCity, $"Record with Id {Constants.DeleteTestID} should not be retied");
    }

    [Test]
    public void TestDelete_ShouldNotDelete()
    {
        City city = _repository!.GetById(Constants.DeleteTestID2)!;
        Assert.IsNotNull(city, $"Record with Id {Constants.DeleteTestID2} doesn't exist");

        _repository.Delete(city);
        _unitOfWork!.SaveChanges();

        City deletedCity = _repository!.GetById(Constants.DeleteTestID2)!;
        Assert.IsNull(deletedCity, $"Record with Id {Constants.DeleteTestID2} should not be retied");
        Assert.Throws<DbUpdateConcurrencyException>(() =>
        {
            _repository.Delete(city);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }
}
