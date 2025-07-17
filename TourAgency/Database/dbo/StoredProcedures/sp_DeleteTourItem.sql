CREATE PROCEDURE sp_DeleteTourItem
    @TourItemID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM TourItem WHERE Id = @TourItemID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is already inactive', 16, 1);
        RETURN 1;
    END

    UPDATE TouristItem
    SET Status_IsActive = 0
    WHERE Id = @TourItemID;

    RETURN 0;
END;
