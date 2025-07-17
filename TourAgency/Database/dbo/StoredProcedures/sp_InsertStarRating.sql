CREATE PROCEDURE sp_InsertStarRating
    @RatingValue INT,
    @RatingDescription NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM StarRating WHERE RatingValue = @RatingValue AND Status_IsActive = 1)
    BEGIN
        RAISERROR('A StarRating with this RatingValue already exists and is active.', 16, 1);
        RETURN 1;
    END

    INSERT INTO StarRating (RatingValue, RatingDescription, Status_IsActive)
    VALUES (@RatingValue, @RatingDescription, 1);

    SELECT SCOPE_IDENTITY() AS NewRatingID;

    RETURN 0;
END;
