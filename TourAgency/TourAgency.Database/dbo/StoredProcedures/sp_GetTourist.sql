CREATE PROCEDURE sp_GetTourist
    @TouristID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.TouristID,
        t.FirstName,
        t.LastName,
        t.DateOfBirth,
        t.PassportNumber,
        t.Email,
        t.ContactNumber,
        t.NationalityCountryID,
        c.CountryName AS NationalityCountryName, -- Include Nationality Country Name
        t.IsActive
    FROM
        Tourist t
    INNER JOIN
        Country c ON t.NationalityCountryID = c.CountryID
    WHERE
        t.TouristID = @TouristID
        AND t.IsActive = 1;
END;
