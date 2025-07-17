CREATE PROCEDURE sp_DeleteHotel
    @HotelID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Hotel WHERE Id = @HotelID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Hotel
    SET Status_IsActive = 0
    WHERE Id = @HotelID;

    RETURN 0;
END;
