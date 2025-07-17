CREATE PROCEDURE sp_GetStarRating
    @RatingID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        RatingID,
        RatingValue,
        RatingDescription,
        Status_IsActive
    FROM
        StarRating
    WHERE
        RatingID = @RatingID
        AND Status_IsActive = 1;
END;
