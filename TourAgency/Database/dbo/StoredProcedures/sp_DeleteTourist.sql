CREATE PROCEDURE sp_DeleteTourist
    @TouristID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Tourist WHERE TouristID = @TouristID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Tourist
    SET IsActive = 0
    WHERE TouristID = @TouristID;

    RETURN 0;
END;
