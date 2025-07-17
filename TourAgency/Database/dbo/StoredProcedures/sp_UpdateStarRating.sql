CREATE PROCEDURE sp_UpdateStarRating
    @RatingID INT,
    @RatingValue INT,
    @RatingDescription NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM StarRating WHERE RatingID = @RatingID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    IF EXISTS(SELECT 1 FROM StarRating WHERE RatingValue = @RatingValue AND RatingID <> @RatingID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Another active StarRating with this RatingValue already exists.', 16, 1);
        RETURN 1;
    END

    UPDATE StarRating
    SET
        RatingValue = @RatingValue,
        RatingDescription = @RatingDescription
    WHERE
        RatingID = @RatingID;

    RETURN 0;
END;
