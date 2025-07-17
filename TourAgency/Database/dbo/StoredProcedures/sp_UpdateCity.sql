CREATE PROCEDURE sp_UpdateCity
    @CityID INT,
    @CityName NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    SET NOCOUNT ON; 
    IF NOT EXISTS(SELECT 1 FROM City WHERE CityID = @CityID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE City
    SET
        CityName = @CityName,
        CountryID = @CountryID
    WHERE
        CityID = @CityID;

    RETURN 0;
END;
