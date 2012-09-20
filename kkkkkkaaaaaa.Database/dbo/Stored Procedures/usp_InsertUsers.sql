CREATE PROCEDURE usp_InsertUsers (
	@id			BIGINT
	, @Enabled	BIT
) AS
	DECLARE
		@update		VARCHAR(MAX)
		, @set		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
		, @error	INT

	--
	EXECUTE (@update)

	-- 
	SET @error = @@ERROR

	RETURN @error
