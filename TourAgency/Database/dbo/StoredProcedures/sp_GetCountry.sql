CREATE PROCEDURE sp_GetCountry
    @CountryID INT
AS
BEGIN
    SELECT * 
    FROM Countries 
    WHERE Id = @CountryID AND Status_IsActive = 1;
END