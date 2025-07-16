CREATE PROCEDURE sp_InsertTourist
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

    INSERT INTO Tourist (FirstName, LastName, DateOfBirth, PassportNumber, Email, ContactNumber, NationalityCountryID, IsActive)
    VALUES (@FirstName, @LastName, @DateOfBirth, @PassportNumber, @Email, @ContactNumber, @NationalityCountryID, 1); -- New tourists are active by default

    SELECT SCOPE_IDENTITY() AS NewTouristID;

    RETURN 0;
END;
