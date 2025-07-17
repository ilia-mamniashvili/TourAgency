CREATE PROCEDURE sp_InsertService
    @ServiceName NVARCHAR(100),
    @Description NVARCHAR(500),
    @Price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Service (ServiceName, Description, Price, Status_IsActive)
    VALUES (@ServiceName, @Description, @Price, 1); -- New services are active by default

    SELECT SCOPE_IDENTITY() AS NewServiceID;

    RETURN 0;
END;
