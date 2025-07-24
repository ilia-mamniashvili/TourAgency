using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;

public class HotelRepositoryTests : BaseRepositoryTests<Hotel>
{
    private IHotelRepository? _repository;

    public override void SetUp()
    {
        base.SetUp();
        _repository = _unitOfWork!.HotelRepository;
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        Hotel hotel = new Hotel()
        {
            Name = "Test Hotel",
            Star = StarRating.Four,
            DailyPrice = 150,
            IncludesMeal = true,
            Status = new EntityStatus(),
            City = _unitOfWork!.CityRepository.GetById(Constants.UpdateTestID)!
        };

        _repository!.Insert(hotel);
        _unitOfWork.SaveChanges();

        Hotel? insertedHotel = _repository.GetById(hotel.Id);
        Assert.IsNotNull(insertedHotel);
        Assert.That(insertedHotel!.Name, Is.EqualTo("Test Hotel"));
        Assert.That(insertedHotel.DailyPrice, Is.EqualTo(150));
        Assert.That(insertedHotel.IncludesMeal, Is.True);
    }

    [Test]
    public void InsertTest_ShouldNotInsert()
    {
        Hotel hotel = new Hotel()
        {
            Name = null!,
            Star = StarRating.Three,
            DailyPrice = 100,
            IncludesMeal = false,
            Status = new EntityStatus(),
            City = _unitOfWork!.CityRepository.GetById(Constants.UpdateTestID)!
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(hotel);
            _unitOfWork!.SaveChanges();
        });
    }

    [Test]
    public void UpdateTest_ShouldUpdate()
    {
        Hotel hotel = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(hotel);

        hotel.Name = "Updated Hotel";
        hotel.DailyPrice = 200;
        hotel.IncludesMeal = false;

        _repository.Update(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? updatedHotel = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(updatedHotel);
        Assert.That(updatedHotel!.Name, Is.EqualTo("Updated Hotel"));
        Assert.That(updatedHotel.DailyPrice, Is.EqualTo(200));
        Assert.That(updatedHotel.IncludesMeal, Is.False);
    }

    [Test]
    public void UpdateTest_ShouldNotUpdate()
    {
        Hotel hotel = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(hotel);

        hotel.Name = null!;

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Update(hotel);
            _unitOfWork!.SaveChanges();
        });
    }

    [Test]
    public void DeleteTest_ShouldDelete()
    {
        Hotel hotel = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(hotel, $"Hotel with Id {Constants.DeleteTestID} does not exist");

        _repository.Delete(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? deletedHotel = _repository!.GetById(Constants.DeleteTestID);
        Assert.IsNull(deletedHotel, $"Hotel with Id {Constants.DeleteTestID} should be deleted");
    }

    [Test]
    public void DeleteTest_ShouldNotDelete()
    {
        Hotel hotel = _repository!.GetById(Constants.DeleteTestID2)!;
        Assert.IsNotNull(hotel, $"Hotel with Id {Constants.DeleteTestID2} does not exist");

        _repository.Delete(hotel);
        _unitOfWork!.SaveChanges();

        Hotel? deletedHotel = _repository!.GetById(Constants.DeleteTestID2);
        Assert.IsNull(deletedHotel, $"Hotel with Id {Constants.DeleteTestID2} should be deleted");

        Assert.Throws<DbUpdateConcurrencyException>(() =>
        {
            _repository.Delete(hotel);
            _unitOfWork!.SaveChanges();
        });
    }
}