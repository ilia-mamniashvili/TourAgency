CREATE PROCEDURE sp_UpdateCountry
	@Id INT,
    @Name NVARCHAR(100),
    @ISOCode NVARCHAR(3)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM Countries WHERE Id = @Id AND Status_IsActive = 0)
	BEGIN
		RAISERROR('Record is not active', 16, 1);
		RETURN 1;
	END

	UPDATE Countries
	SET Name = @Name,
	    ISOCode = @ISOCode,
		Status_UpdateDate = GETDATE()
	WHERE 
		Id = @Id 
		AND (
			Name != @Name 
			OR ISOCode != @ISOCode
		);

	RETURN 0;
END