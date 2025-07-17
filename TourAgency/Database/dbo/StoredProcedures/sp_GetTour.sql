CREATE PROCEDURE sp_GetTour
    @TourID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.TourID,
        t.TourName,
        t.DestinationCityID,
        c.CityName,
        t.DurationDays,
        t.Price,
        t.Description,
        t.StartDate,
        t.EndDate,
        t.StatusID,
        es.StatusName AS TourStatusName,
        t.Status_IsActive
    FROM
        Tour t
    INNER JOIN
        City c ON t.DestinationCityID = c.CityID
    INNER JOIN
        EntityStatus es ON t.StatusID = es.StatusID
    WHERE
        t.TourID = @TourID
        AND t.Status_IsActive = 1;
END;
