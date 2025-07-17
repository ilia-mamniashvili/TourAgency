CREATE PROCEDURE sp_DeleteStarRating
    @RatingID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM StarRating WHERE Id = @RatingID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE StarRating
    SET Status_IsActive = 0
    WHERE Id = @RatingID;

    RETURN 0;
END;
