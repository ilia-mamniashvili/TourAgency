CREATE PROCEDURE sp_GetTourItem
    @TourItemID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ti.TourItemID,
        ti.TouristID,
        t.FirstName AS TouristFirstName,
        t.LastName AS TouristLastName,
        ti.ItemName,
        ti.Quantity,
        ti.IssueDate,
        ti.ExpiryDate,
        ti.StatusID,
        es.StatusName AS ItemStatusName,
        ti.IsActive
    FROM
        TourItem ti
    INNER JOIN
        Tourist t ON ti.TouristID = t.TouristID
    INNER JOIN
        EntityStatus es ON ti.StatusID = es.StatusID
    WHERE
        ti.TourItemID = @TourItemID
        AND ti.IsActive = 1;
END;
