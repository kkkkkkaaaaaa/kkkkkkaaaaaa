CREATE FUNCTION GetIdentCurrent (
	@tableName	NVARCHAR(MAX)
) RETURNS NUMERIC(38, 0)
AS BEGIN

	DECLARE
		@current	NUMERIC(38, 0)
	
	--SET @current = IDENT_CURRENT(@tableName)
	SET @current = IDENT_CURRENT(@tableName)

	RETURN @current

END

