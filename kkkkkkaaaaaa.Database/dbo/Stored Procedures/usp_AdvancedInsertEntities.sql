CREATE PROCEDURE [dbo].[usp_AdvancedInsertEntities] (
	@entityId		INT
	, @entityName	NVARCHAR(64)
	, @identity		NUMERIC(38, 0)  OUTPUT

) AS BEGIN

	DECLARE
		@stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @result	INT
		, @error	INT

	SET @stmt = N''
		+ N'INSERT INTO [Entities] ('
		+ N'[EntityName]'
	IF (0 < @entityId) SET @stmt = @stmt + N', [EntityID]'

	SET @stmt = @stmt
		+ N') VALUES ('
		+ N'@entityName'
	IF (0 < @entityId) SET @stmt = @stmt + N', @entityId'
	SET @stmt = @stmt + N');'

	SET @stmt = N''
		+ N'IF (0 < @entityId) SET IDENTITY_INSERT [Entities] ON;' + dbo.NL()
		+ @stmt + dbo.NL()
		+ N'IF (0 < @entityId) SET IDENTITY_INSERT [Entities] OFF;' + dbo.NL()
		+ N'SET @identity = SCOPE_IDENTITY();' + dbo.NL()

	SET @params = N'@entityId INT, @entityName NVARCHAR(64), @identity NUMERIC(38, 0) OUTPUT'

	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @entityId = @entityId, @entityName = @entityName, @identity = @identity OUTPUT
		
	SET @error = @@ERROR

	RETURN @error

END
