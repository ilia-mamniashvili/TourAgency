CREATE PROCEDURE sp_DeleteCity
    @CityID INT
AS
BEGIN
    SET NOCOUNT ON;


    IF NOT EXISTS(SELECT 1 FROM City WHERE Id = @CityID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found', 16, 1);
        RETURN 1;
    END

    UPDATE City
    SET Status_IsActive = 0
    WHERE Id = @CityID;

    RETURN 0;
END;