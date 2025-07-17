CREATE PROCEDURE sp_DeleteService
    @ServiceID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Service WHERE ServiceID = @ServiceID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Service
    SET IsActive = 0
    WHERE ServiceID = @ServiceID;

    RETURN 0;
END;
