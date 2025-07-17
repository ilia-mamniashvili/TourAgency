CREATE PROCEDURE sp_UpdateTourBooking
    @BookingID INT,
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

    IF NOT EXISTS(SELECT 1 FROM TourBooking WHERE BookingID = @BookingID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE TourBooking
    SET
        TouristID = @TouristID,
        TourID = @TourID,
        BookingDate = @BookingDate,
        NumberOfAdults = @NumberOfAdults,
        NumberOfChildren = @NumberOfChildren,
        TotalPrice = @TotalPrice,
        PaymentStatus = @PaymentStatus,
        StatusID = @StatusID
    WHERE
        BookingID = @BookingID;

    RETURN 0;
END;
