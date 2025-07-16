CREATE PROCEDURE sp_UpdateService
    @ServiceID INT,
    @ServiceName NVARCHAR(100),
    @Description NVARCHAR(500),
    @Price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Service WHERE ServiceID = @ServiceID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Service
    SET
        ServiceName = @ServiceName,
        Description = @Description,
        Price = @Price
    WHERE
        ServiceID = @ServiceID;

    RETURN 0;
END;
