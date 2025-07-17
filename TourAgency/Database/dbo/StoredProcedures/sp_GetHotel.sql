CREATE PROCEDURE sp_GetHotel
    @HotelID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.HotelID,
        h.HotelName,
        h.CityID,
        c.CityName,
        h.StarRatingID,
        sr.RatingValue,
        sr.RatingDescription,
        h.Address,
        h.ContactNumber,
        h.Website,
        h.IsActive
    FROM
        Hotel h
    INNER JOIN
        City c ON h.CityID = c.CityID
    INNER JOIN
        StarRating sr ON h.StarRatingID = sr.RatingID
    WHERE
        h.HotelID = @HotelID
        AND h.IsActive = 1;
END;
