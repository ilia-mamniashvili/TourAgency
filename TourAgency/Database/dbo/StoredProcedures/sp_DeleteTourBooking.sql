CREATE PROCEDURE sp_DeleteTourBooking
    @BookingID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM TourBooking WHERE Id = @BookingID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE TourBooking
    SET Status_IsActive = 0
    WHERE Id = @BookingID;

    RETURN 0;
END;
