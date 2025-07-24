using DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Tests;

public class TourRepositoryTests : BaseRepositoryTests<Tour>
{
    private ITourRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.Tour;
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        Tour tour = new()
        {
            Name = "Test Tour",
            Description = "This is a test tour",
            TotalPrice = 500.00m,
            Cities = null,
            Status = new EntityStatus()
        };

        _repository?.Insert(tour);
        _unitOfWork!.SaveChanges();

        Tour? insertedTour = _unitOfWork!.Tour.GetById(tour.Id);
        Assert.IsNotNull(insertedTour);
        Assert.That(insertedTour.Name, Is.EqualTo(tour.Name));
        Assert.That(insertedTour.Description, Is.EqualTo(tour.Description));
        Assert.That(insertedTour.StartDate, Is.EqualTo(tour.StartDate));
        Assert.That(insertedTour.EndDate, Is.EqualTo(tour.EndDate));
        Assert.That(insertedTour.TotalPrice, Is.EqualTo(tour.TotalPrice));
    }

    [Test]
    public void InsertTest_ShouldNotInsert()
    {
        Tour tour = new()
        {
            Name = null!,
            Description = "This is a test tour",
            TotalPrice = 500.00m,
            Cities = null,
            Status = new EntityStatus()
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Insert(tour);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void UpdateTest_ShouldUpdate()
    {
        Tour tour = _unitOfWork!.Tour.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(tour);

        tour.Name = "Updated Tour Name";
        tour.Description = "Updated Description";
        tour.TotalPrice = 600.00m;

        _repository!.Update(tour);
        _unitOfWork.SaveChanges();

        Tour updatedTour = _repository.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(updatedTour);
        Assert.That(updatedTour.Name, Is.EqualTo("Updated Tour Name"));
        Assert.That(updatedTour.Description, Is.EqualTo("Updated Description"));
        Assert.That(updatedTour.TotalPrice, Is.EqualTo(600.00m));
    }

    [Test]
    public void UpdateTest_ShouldNotUpdate()
    {
        Tour tour = _repository!.GetById(Constants.UpdateTestID)!;
        Assert.IsNotNull(tour);
        tour.Name = null!; 
        tour.Description = "Updated Description";
        tour.TotalPrice = 600.00m;

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Update(tour);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void DeleteTest_ShouldDelete()
    {
        Tour tour = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(tour);
        
        _repository.Delete(tour);
        _unitOfWork!.SaveChanges();
        
        Tour? deletedTour = _repository.GetById(Constants.DeleteTestID);
        Assert.IsNull(deletedTour);
    }

    [Test]
    public void DeleteTest_ShouldNotDelete()
    {
        Tour tour = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(tour);
        tour.Name = null!; 
        
        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Delete(tour);
            _unitOfWork!.SaveChanges();
        });
        
        _unitOfWork!.RevertChanges();
    }
}
