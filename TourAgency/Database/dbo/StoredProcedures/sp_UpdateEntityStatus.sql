CREATE PROCEDURE sp_UpdateEntityStatus
    @StatusID INT,
    @StatusName NVARCHAR(50),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM EntityStatus WHERE StatusID = @StatusID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END
    UPDATE EntityStatus
    SET
        StatusName = @StatusName,
        Description = @Description
    WHERE
        StatusID = @StatusID;

    RETURN 0;
END;