CREATE PROCEDURE sp_DeleteHotel
    @HotelID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Hotel WHERE HotelID = @HotelID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Hotel
    SET IsActive = 0
    WHERE HotelID = @HotelID;

    RETURN 0;
END;
