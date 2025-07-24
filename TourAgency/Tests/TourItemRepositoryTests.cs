using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;

internal class TourItemRepositoryTests : BaseRepositoryTests<TourItem>
{
    private ITourItemRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.TourItem;
    }
    [Test]

    public void InsertTest_ShouldInsert()
    {
        TourItem item = new()
        {
            Tour = _unitOfWork!.Tour.GetById(1)!,
            City = _unitOfWork!.City.GetById(1)!,
            Hotel = _unitOfWork!.Hotel.GetById(1)!,
            Status = new EntityStatus(),
            OrderPosition = 1,
        };

        _repository?.Insert(item);
        _unitOfWork!.SaveChanges();

        TourItem? insertedItem = _unitOfWork!.TourItem.GetById(item.Id);
        Assert.IsNotNull(insertedItem);
        Assert.That(insertedItem.Tour.Id, Is.EqualTo(item.Tour.Id));
        Assert.That(insertedItem.City, Is.EqualTo(item.City));
        Assert.That(insertedItem.Hotel, Is.EqualTo(item.Hotel));
        Assert.That(insertedItem.OrderPosition, Is.EqualTo(item.OrderPosition));
    }

    [Test]
    public void UpdateTest_ShouldUpdate()
    {
        TourItem item = new()
        {
            Id = 1,
            Tour = _unitOfWork!.Tour.GetById(1)!,
            City = _unitOfWork!.City.GetById(1)!,
            Hotel = _unitOfWork!.Hotel.GetById(1)!,
            Status = new EntityStatus(),
            OrderPosition = 2,
        };

        _repository?.Update(item);
        _unitOfWork!.SaveChanges();

        TourItem? updatedItem = _unitOfWork!.TourItem.GetById((int)item.Id);
        Assert.IsNotNull(updatedItem);
        Assert.That(updatedItem.Tour.Id, Is.EqualTo(item.Tour.Id));
        Assert.That(updatedItem.City.Id, Is.EqualTo(item.City.Id));
        Assert.That(updatedItem.Hotel?.Id, Is.EqualTo(item.Hotel.Id));
        Assert.That(updatedItem.OrderPosition, Is.EqualTo(item.OrderPosition));
    }

    [Test]
    public void InsertTest_ShouldNotInsert()
    {
        TourItem item = new()
        {
            Tour = _unitOfWork!.Tour.GetById(0)!,
            City = _unitOfWork!.City.GetById(0)!,
            Hotel = _unitOfWork!.Hotel.GetById(0)!,
            Status = new EntityStatus(),
            OrderPosition = 1,
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(item);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }
}
