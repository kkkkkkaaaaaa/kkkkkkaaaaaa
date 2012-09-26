CREATE PROCEDURE usp_SelectMemberships (
	@name			NVARCHAR(1024)
	, @password		VARCHAR(1024)
) AS

	DECLARE
		@error	INT

	SELECT
		*
	FROM
		Memberships
	WHERE
		1 = 1
		AND (Name		= @name OR Name = @name)
		AND [Password]	= @password
		AND [Enabled]	= CAST('True' AS BIT)

	-- 戻り値
	SET @error = @@ERROR
	
	RETURN @error
