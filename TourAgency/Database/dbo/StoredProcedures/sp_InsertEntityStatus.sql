CREATE PROCEDURE sp_InsertEntityStatus
    @StatusName NVARCHAR(50),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON; -- Prevents the count of the number of rows affected from being returned.

    -- Insert the new status into the EntityStatus table
    INSERT INTO EntityStatus (StatusName, Description)
    VALUES (@StatusName, @Description);

    -- Return the ID of the newly inserted status.
    -- This is crucial for the calling application to know the ID of the new record.
    SELECT SCOPE_IDENTITY() AS NewStatusID;

    RETURN 0; -- Return 0 to indicate success
END;
