using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;
public class TouristRepositoryTest : BaseRepositoryTests<Tourist>
{
    private ITouristRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.Tourist;
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        Tourist tourist = new()
        {
            PersonalNumber = "12345678901",
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Status = new EntityStatus()
        };

        _repository?.Insert(tourist);
        _unitOfWork!.SaveChanges();

        Tourist? insertedTourist = _unitOfWork!.Tourist.GetById(tourist.Id);
        Assert.IsNotNull(insertedTourist);
        Assert.That(insertedTourist.PersonalNumber, Is.EqualTo(tourist.PersonalNumber));
        Assert.That(insertedTourist.FirstName, Is.EqualTo(tourist.FirstName));
        Assert.That(insertedTourist.LastName, Is.EqualTo(tourist.LastName));
        Assert.That(insertedTourist.BirthDate, Is.EqualTo(tourist.BirthDate));
        Assert.That(insertedTourist.PhoneNumber, Is.EqualTo(tourist.PhoneNumber));
    }

    [Test]
    public void InsertTest_ShouldNotInsert()
    {
        Tourist tourist = new()
        {
            PersonalNumber = string.Empty,
            FirstName = "Jane",
            LastName = "Doe",
            BirthDate = new DateTime(1995, 5, 5),
            PhoneNumber = "0987654321",
            Status = new EntityStatus()
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(tourist);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void TestUpdate_ShouldUpdate()
    {
        Tourist? tourist = _repository!.GetById(Constants.UpdateTestID);
        Assert.IsNotNull(tourist);

        tourist.PersonalNumber = "98765432101";
        tourist.FirstName = "Updated Name";
        tourist.LastName = "Updated Last Name";
        tourist.BirthDate = new DateTime(1992, 2, 2);
        tourist.PhoneNumber = "1112223333";
        tourist.Status = new EntityStatus();

        _repository!.Update(tourist);
        _unitOfWork!.SaveChanges();

        Tourist? updatedTourist = _repository.GetById(tourist.Id);
        Assert.IsNotNull(updatedTourist);
        Assert.That(updatedTourist.PersonalNumber, Is.EqualTo(tourist.PersonalNumber));
        Assert.That(updatedTourist.FirstName, Is.EqualTo(tourist.FirstName));
        Assert.That(updatedTourist.LastName, Is.EqualTo(tourist.LastName));
        Assert.That(updatedTourist.BirthDate, Is.EqualTo(tourist.BirthDate));
        Assert.That(updatedTourist.PhoneNumber, Is.EqualTo(tourist.PhoneNumber));
    }

    [Test]
    public void TestUpdate_ShouldNotUpdate()
    {
        Tourist? tourist = _repository!.GetById(Constants.UpdateTestID);
        Assert.IsNotNull(tourist);
        tourist.PersonalNumber = string.Empty;
        tourist.FirstName = "Invalid Name";
        tourist.LastName = "Invalid Last Name";
        tourist.BirthDate = new DateTime(1993, 3, 3);
        tourist.PhoneNumber = "2223334444";
        tourist.Status = new EntityStatus();

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Update(tourist);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void TestDelete_ShouldDelete()
    {
        Tourist? tourist = _repository!.GetById(Constants.DeleteTestID);
        Assert.IsNotNull(tourist, $"Record with Id {Constants.DeleteTestID} doesn't exist");

        _repository!.Delete(tourist);
        _unitOfWork!.SaveChanges();

        Tourist? deletedTourist = _repository.GetById(Constants.DeleteTestID);
        Assert.IsNull(deletedTourist, $"Record with Id {Constants.DeleteTestID} should not be retrieved");
    }

    [Test]
    public void TestDelete_ShouldNotDelete()
    {
        Tourist? tourist = _repository!.GetById(Constants.DeleteTestID);
        Assert.IsNotNull(tourist, $"Record with Id {Constants.DeleteTestID} doesn't exist");
        tourist.PersonalNumber = string.Empty;
        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Delete(tourist);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }
}