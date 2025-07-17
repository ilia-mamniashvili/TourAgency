CREATE PROCEDURE sp_InsertTourBooking
    @TouristID INT,
    @TourID INT,
    @BookingDate DATETIME,
    @NumberOfAdults INT,
    @NumberOfChildren INT,
    @TotalPrice DECIMAL(18, 2),
    @PaymentStatus NVARCHAR(50),
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TourBooking (TouristID, TourID, BookingDate, NumberOfAdults, NumberOfChildren, TotalPrice, PaymentStatus, StatusID, IsActive)
    VALUES (@TouristID, @TourID, @BookingDate, @NumberOfAdults, @NumberOfChildren, @TotalPrice, @PaymentStatus, @StatusID, 1); -- New bookings are active by default

    SELECT SCOPE_IDENTITY() AS NewBookingID;

    RETURN 0;
END;
