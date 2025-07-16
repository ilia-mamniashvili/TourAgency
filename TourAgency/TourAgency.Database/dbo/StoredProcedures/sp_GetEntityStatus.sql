CREATE PROCEDURE sp_GetEntityStatus
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        StatusID,
        StatusName,
        Description,
        IsActive
    FROM
        EntityStatus
    WHERE
        StatusID = @StatusID
        AND IsActive = 1;
END;