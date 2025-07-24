using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace Tests;

internal class TourBookingRepositoryTests : BaseRepositoryTests<TourBooking>
{
    private ITourBookingRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = _unitOfWork!.TourBooking;
    }

    [Test]
    public void InsertTest_ShouldInsert()
    {
        TourBooking booking = new()
        {
            Tour = _unitOfWork!.Tour.GetById(1)!,
            Tourist = _unitOfWork!.Tourist.GetById(1)!,

            BookDate = DateTime.Now,
        };

        _repository?.Insert(booking);
        _unitOfWork!.SaveChanges();

        TourBooking? insertedBooking = _unitOfWork!.TourBooking.GetById((int)booking.Id);
        Assert.IsNotNull(insertedBooking);
        Assert.That(insertedBooking.Tour.Id, Is.EqualTo(booking.Tour.Id));
        Assert.That(insertedBooking.Tourist.Id, Is.EqualTo(booking.Tourist.Id));
    }

    [Test]
    public void UpdateTest_ShouldUpdate()
    {
        TourBooking booking = new()
        {
            Id = 1,
            Tour = _unitOfWork!.Tour.GetById(1)!,
            Tourist = _unitOfWork!.Tourist.GetById(1)!,
            BookDate = DateTime.Now
        };

        _repository?.Update(booking);

        _unitOfWork!.SaveChanges();

        TourBooking? updatedBooking = _unitOfWork!.TourBooking.GetById((int)booking.Id);
        Assert.IsNotNull(updatedBooking);
        Assert.That(updatedBooking.Tour.Id, Is.EqualTo(booking.Tour.Id));
        Assert.That(updatedBooking.Tourist.Id, Is.EqualTo(booking.Tourist.Id));
        Assert.That(updatedBooking.BookDate, Is.EqualTo(booking.BookDate));
    }

    [Test]
    public void UpdateTest_ShouldNotUpdate()
    {
        TourBooking booking = new()
        {
            Id = 0, 
            Tour = _unitOfWork!.Tour.GetById(Constants.UpdateTestID)!,
            Tourist = _unitOfWork!.Tourist.GetById(Constants.UpdateTestID)!,
            BookDate = DateTime.Now
        };

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository!.Update(booking);
            _unitOfWork!.SaveChanges();
        });

        _unitOfWork!.RevertChanges();
    }

    [Test]
    public void DeleteTest_ShouldDelete()
    {
        TourBooking booking = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(booking);

        _repository.Delete(booking);
        _unitOfWork!.SaveChanges();
        
        TourBooking? deletedBooking = _repository.GetById((int)Constants.DeleteTestID);
        Assert.IsNull(deletedBooking);
    }

    [Test]
    public void DeleteTest_ShouldNotDelete()
    {
        TourBooking booking = _repository!.GetById(Constants.DeleteTestID)!;
        Assert.IsNotNull(booking);
        booking.Tour = null!;
        booking.Tourist = null!;

        Assert.Throws<DbUpdateException>(() =>
        {
            _repository.Delete(booking);
            _unitOfWork!.SaveChanges();
        });
        
        _unitOfWork!.RevertChanges();
    }
}
