CREATE PROCEDURE sp_DeleteTour
    @TourID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Tour WHERE TourID = @TourID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Tour
    SET IsActive = 0
    WHERE TourID = @TourID;

    RETURN 0;
END;
