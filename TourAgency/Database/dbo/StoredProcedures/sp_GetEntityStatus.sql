CREATE PROCEDURE sp_GetEntityStatus
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        StatusID,
        StatusName,
        Description,
        Status_IsActive
    FROM
        EntityStatus
    WHERE
        StatusID = @StatusID
        AND Status_IsActive = 1;
END;