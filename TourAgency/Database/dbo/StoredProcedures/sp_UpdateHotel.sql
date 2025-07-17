CREATE PROCEDURE sp_UpdateHotel
    @HotelID INT,
    @HotelName NVARCHAR(255),
    @CityID INT,
    @StarRatingID INT,
    @Address NVARCHAR(500),
    @ContactNumber NVARCHAR(50),
    @Website NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Hotel WHERE HotelID = @HotelID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Hotel
    SET
        HotelName = @HotelName,
        CityID = @CityID,
        StarRatingID = @StarRatingID,
        Address = @Address,
        ContactNumber = @ContactNumber,
        Website = @Website
    WHERE
        HotelID = @HotelID;

    RETURN 0;
END;
