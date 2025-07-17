CREATE PROCEDURE sp_InsertHotel
    @HotelName NVARCHAR(255),
    @CityID INT,
    @StarRatingID INT,
    @Address NVARCHAR(500),
    @ContactNumber NVARCHAR(50),
    @Website NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Hotel (HotelName, CityID, StarRatingID, Address, ContactNumber, Website, Status_IsActive)
    VALUES (@HotelName, @CityID, @StarRatingID, @Address, @ContactNumber, @Website, 1); -- New hotels are active by default

    SELECT SCOPE_IDENTITY() AS NewHotelID;

    RETURN 0;
END;
