CREATE PROCEDURE [dbo].[usp_BasicInsertEntities] (
	@entityName		NVARCHAR(64)
	, @identity		NUMERIC(38, 0)	OUTPUT

) AS BEGIN

	DECLARE
		@stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @result	INT
		, @error	INT

	SET @stmt = N''
		+ N'INSERT INTO [Entities] ([EntityName]) VALUES (@entityName);' + dbo.NL()
		+ N'SET @identity = SCOPE_IDENTITY();'

	SET @params = N'@entityName NVARCHAR(64), @identity NUMERIC(38, 0) OUTPUT'

	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @entityName = @entityName, @identity = @identity OUTPUT
		
	SET @error = @@ERROR

	RETURN @error

END
