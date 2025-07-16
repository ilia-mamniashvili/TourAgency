CREATE PROCEDURE sp_UpdateTour
    @TourID INT,
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

    IF NOT EXISTS(SELECT 1 FROM Tour WHERE TourID = @TourID AND IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Tour
    SET
        TourName = @TourName,
        DestinationCityID = @DestinationCityID,
        DurationDays = @DurationDays,
        Price = @Price,
        Description = @Description,
        StartDate = @StartDate,
        EndDate = @EndDate,
        StatusID = @StatusID
    WHERE
        TourID = @TourID;

    RETURN 0;
END;
