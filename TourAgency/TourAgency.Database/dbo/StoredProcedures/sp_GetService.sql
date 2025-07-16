CREATE PROCEDURE sp_GetService
    @ServiceID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServiceID,
        ServiceName,
        Description,
        Price,
        IsActive
    FROM
        Service
    WHERE
        ServiceID = @ServiceID
        AND IsActive = 1;
END;
