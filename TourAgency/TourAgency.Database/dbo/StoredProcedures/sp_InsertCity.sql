CREATE PROCEDURE sp_InsertCity
    @CityName NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    SET NOCOUNT ON; 
    INSERT INTO City (CityName, CountryID, IsActive)
    VALUES (@CityName, @CountryID, 1); 

    SELECT SCOPE_IDENTITY() AS NewCityID;

    RETURN 0;
END;