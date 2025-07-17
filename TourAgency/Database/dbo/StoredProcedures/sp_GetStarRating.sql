CREATE PROCEDURE sp_GetStarRating
    @RatingID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        RatingID,
        RatingValue,
        RatingDescription,
        IsActive
    FROM
        StarRating
    WHERE
        RatingID = @RatingID
        AND IsActive = 1;
END;
