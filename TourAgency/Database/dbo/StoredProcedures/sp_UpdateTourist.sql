CREATE PROCEDURE sp_UpdateTourist
    @TouristID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @DateOfBirth DATE,
    @PassportNumber NVARCHAR(50),
    @Email NVARCHAR(255),
    @ContactNumber NVARCHAR(50),
    @NationalityCountryID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Tourist WHERE TouristID = @TouristID AND Status_IsActive = 1)
    BEGIN
        RAISERROR('Record was not found or is inactive', 16, 1);
        RETURN 1;
    END

    UPDATE Tourist
    SET
        FirstName = @FirstName,
        LastName = @LastName,
        DateOfBirth = @DateOfBirth,
        PassportNumber = @PassportNumber,
        Email = @Email,
        ContactNumber = @ContactNumber,
        NationalityCountryID = @NationalityCountryID
    WHERE
        TouristID = @TouristID;

    RETURN 0;
END;
