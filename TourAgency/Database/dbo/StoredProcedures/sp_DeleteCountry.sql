CREATE PROCEDURE sp_DeleteCountry
	@CountryID INT
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS(SELECT 1 FROM Country WHERE Id = @CountryID AND Status_IsActive = 1)
	BEGIN
		RAISERROR('Record was not found', 16, 1);
		RETURN 1;
	END

	UPDATE Countries
	SET Status_IsActive = 0
	WHERE Id = @CountryID;

	RETURN 0;
END