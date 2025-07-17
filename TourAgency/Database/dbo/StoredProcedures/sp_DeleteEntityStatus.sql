CREATE PROCEDURE sp_DeleteEntityStatus
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON; 
    IF NOT EXISTS(SELECT 1 FROM EntityStatus WHERE Id = @StatusID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE EntityStatus
    SET Status_IsActive = 0
    WHERE Id = @StatusID;

    RETURN 0;
END;
