﻿CREATE PROCEDURE sp_DeleteCity
    @CityID INT
AS
BEGIN
    SET NOCOUNT ON;


    IF NOT EXISTS(SELECT 1 FROM City WHERE CityID = @CityID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found', 16, 1);
        RETURN 1;
    END

    UPDATE City
    SET IsActive = 0
    WHERE CityID = @CityID;

    RETURN 0;
END;