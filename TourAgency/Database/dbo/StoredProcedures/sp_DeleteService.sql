CREATE PROCEDURE sp_DeleteService
    @ServiceID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Service WHERE Id = @ServiceID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Service
    SET Status_IsActive = 0
    WHERE Id = @ServiceID;

    RETURN 0;
END;
