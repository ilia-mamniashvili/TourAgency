CREATE PROCEDURE sp_InsertTourItem
    @TouristID INT,
    @ItemName NVARCHAR(255),
    @Quantity INT,
    @IssueDate DATE,
    @ExpiryDate DATE,
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TourItem (TouristID, ItemName, Quantity, IssueDate, ExpiryDate, StatusID, IsActive)
    VALUES (@TouristID, @ItemName, @Quantity, @IssueDate, @ExpiryDate, @StatusID, 1); -- New items are active by default

    SELECT SCOPE_IDENTITY() AS NewTourItemID;

    RETURN 0;
END;
