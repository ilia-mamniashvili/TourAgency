using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;
internal class HotelRepositoryTest : BaseRepositoryTests<Hotel>
{
    private IHotelRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.Hotel;
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        Hotel hotel = new()
        {
            Name = "Test Hotel",
            DailyPrice = 100.00m,
            IncludesMeal = true,
            City = _unitOfWork!.City.GetById(1)!,
            Status = new EntityStatus()
        };

        _repository?.Insert(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? insertedHotel = _unitOfWork!.Hotel.GetById(hotel.Id);
        Assert.IsNotNull(insertedHotel);
        Assert.That(insertedHotel.Name, Is.EqualTo(hotel.Name));
        Assert.That(insertedHotel.DailyPrice, Is.EqualTo(hotel.DailyPrice));
        Assert.That(insertedHotel.City, Is.EqualTo(hotel.City));
        Assert.That(insertedHotel.IncludesMeal, Is.EqualTo(hotel.IncludesMeal));
    }

    [Test]
    public void InsertTest_ShouldNotInsert()
    {
        Hotel hotel = new()
        {
            Name = string.Empty,
            DailyPrice = 10.00m,
            IncludesMeal = false,
            City = _unitOfWork!.City.GetById(0)!,
            Status = new EntityStatus()
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(hotel);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork.RevertChanges();
    }

    [Test]
    public void TestUpdate_ShouldUpdate()
    {
        Hotel? hotel = _repository!.GetById(Constants.UpdateTestID);
        Assert.IsNotNull(hotel);

        hotel.Name = "Updated Name";
        hotel.DailyPrice = 150.00m;
        hotel.IncludesMeal = false;
        hotel.City.Id = 1;

        _repository!.Update(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? updatedHotel = _unitOfWork!.Hotel.GetById(Constants.UpdateTestID);
        Assert.IsNotNull(updatedHotel);
        Assert.That(updatedHotel.Name, Is.EqualTo("Updated Name"));
        Assert.That(updatedHotel.Star, Is.EqualTo(hotel.Star));
        Assert.That(updatedHotel.DailyPrice, Is.EqualTo(150.00m));
        Assert.That(updatedHotel.IncludesMeal, Is.EqualTo(false));
        Assert.That(updatedHotel.City.Id, Is.EqualTo(1));
    }

    [Test]
    public void TestUpdate_ShouldNotUpdate()
    {
        Hotel? hotel = _repository!.GetById(Constants.UpdateTestID);
        Assert.IsNotNull(hotel);
        hotel.Name = string.Empty;
        hotel.DailyPrice = 250.00m;
        hotel.IncludesMeal = true;
        City city = _unitOfWork!.City.GetById(0)!;

        Assert.Throws<DbUpdateException>(() =>
        {
            hotel.City = city;
            _repository!.Update(hotel);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork.RevertChanges();
    }

    [Test]
    public void TestDelete_ShouldDelete()
    {
        Hotel? hotel = _repository!.GetById(Constants.DeleteTestID);
        Assert.IsNotNull(hotel, $"Record with Id {Constants.DeleteTestID} doesn't exist");

        _repository!.Delete(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? deletedHotel = _unitOfWork!.Hotel.GetById(Constants.DeleteTestID);
        Assert.IsNull(deletedHotel, $"Record with Id {Constants.DeleteTestID} should not be retrieved");
    }

    [Test]
    public void TestDelete_ShouldNotDelete()
    {
        Hotel? hotel = _repository!.GetById(Constants.DeleteTestID2);
        Assert.IsNotNull(hotel, $"Record with Id {Constants.DeleteTestID2} doesn't exist");

        _repository!.Delete(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? deletedHotel = _unitOfWork!.Hotel.GetById(Constants.DeleteTestID2);
        Assert.IsNotNull(deletedHotel, $"Record with Id {Constants.DeleteTestID2} should be retrieved, but it was deleted");
        Assert.Throws<DbUpdateConcurrencyException>(() =>
        {
            _repository!.Delete(deletedHotel);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork.RevertChanges();
    }
}

