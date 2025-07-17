CREATE PROCEDURE sp_InsertTour
    @TourName NVARCHAR(255),
    @DestinationCityID INT,
    @DurationDays INT,
    @Price DECIMAL(18, 2),
    @Description NVARCHAR(MAX),
    @StartDate DATE,
    @EndDate DATE,
    @StatusID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Tour (TourName, DestinationCityID, DurationDays, Price, Description, StartDate, EndDate, StatusID, IsActive)
    VALUES (@TourName, @DestinationCityID, @DurationDays, @Price, @Description, @StartDate, @EndDate, @StatusID, 1); -- New tours are active by default

    SELECT SCOPE_IDENTITY() AS NewTourID;

    RETURN 0;
END;
