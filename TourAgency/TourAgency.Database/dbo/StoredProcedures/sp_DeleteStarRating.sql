CREATE PROCEDURE sp_DeleteStarRating
    @RatingID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM StarRating WHERE RatingID = @RatingID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE StarRating
    SET IsActive = 0
    WHERE RatingID = @RatingID;

    RETURN 0;
END;
