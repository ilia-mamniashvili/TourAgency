CREATE PROCEDURE sp_DeleteTourBooking
    @BookingID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM TourBooking WHERE BookingID = @BookingID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE TourBooking
    SET IsActive = 0
    WHERE BookingID = @BookingID;

    RETURN 0;
END;
