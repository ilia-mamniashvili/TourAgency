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
        Status_IsActive
    FROM
        Service
    WHERE
        ServiceID = @ServiceID
        AND Status_IsActive = 1;
END;
