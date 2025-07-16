CREATE PROCEDURE sp_GetCity
    @CityID INT
AS
BEGIN
    SET NOCOUNT ON; 
    SELECT
        c.CityID,
        c.CityName,
        c.CountryID,
        co.CountryName, -- Include country name for context
        c.IsActive
    FROM
        City c
    INNER JOIN
        Country co ON c.CountryID = co.CountryID
    WHERE
        c.CityID = @CityID
        AND c.IsActive = 1;
END;
