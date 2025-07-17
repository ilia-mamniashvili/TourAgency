CREATE PROCEDURE sp_DeleteTourist
    @TouristID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Tourist WHERE Id = @TouristID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Tourist
    SET Status_IsActive = 0
    WHERE Id = @TouristID;

    RETURN 0;
END;
