CREATE PROCEDURE sp_UpdateTourItem
    @TourItemID INT,
    @TouristID INT,
    @ItemName NVARCHAR(255),
    @Quantity INT,
    @IssueDate DATE,
    @ExpiryDate DATE,
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM TourItem WHERE TourItemID = @TourItemID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE TouristItem
    SET
        TouristID = @TouristID,
        ItemName = @ItemName,
        Quantity = @Quantity,
        IssueDate = @IssueDate,
        ExpiryDate = @ExpiryDate,
        StatusID = @StatusID
    WHERE
        TourItemID = @TourItemID;

    RETURN 0;
END;
