CREATE PROCEDURE sp_GetTourBooking
    @BookingID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        tb.BookingID,
        tb.TouristID,
        t.FirstName AS TouristFirstName, -- Include Tourist First Name
        t.LastName AS TouristLastName,   -- Include Tourist Last Name
        tb.TourID,
        tr.TourName, -- Include Tour Name
        tb.BookingDate,
        tb.NumberOfAdults,
        tb.NumberOfChildren,
        tb.TotalPrice,
        tb.PaymentStatus,
        tb.StatusID,
        es.StatusName AS BookingStatusName, -- Include Booking Status Name
        tb.IsActive
    FROM
        TourBooking tb
    INNER JOIN
        Tourist t ON tb.TouristID = t.TouristID
    INNER JOIN
        Tour tr ON tb.TourID = tr.TourID
    INNER JOIN
        EntityStatus es ON tb.StatusID = es.StatusID
    WHERE
        tb.BookingID = @BookingID
        AND tb.IsActive = 1;
END;
