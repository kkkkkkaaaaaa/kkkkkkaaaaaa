CREATE FUNCTION [dbo].[SelectMembershipsViewCount]
(
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
	--, @pageSize		INT	= 1
	--, @startPage	INT = 1
)
RETURNS INT AS BEGIN

	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @count	INT
		, @result	INT
		, @error	INT

	SET @select = N'SELECT'
		+ N' @count = COUNT(ID)'

	SET @from = N' FROM'
		+ N' MembershipsView'

	SET @where = N' WHERE (1 = 1)'
	-- ID
	IF (0 < @id)				SET @where = @where + N' AND (ID = @id)'
	-- Name
	IF (@name <> N'')			SET @where = @where + N' AND (Name like ''%' + @name + N'%'')'
	-- Enabled
	IF (@enabled IS NOT NULL)	SET @where = @where + N' AND ([Enabled] = @enabled)'
	-- CreatedOn
	IF (CAST('1900-01-01 00:00:00.0000000' AS DATETIME2) < @createdOn) SET @where = @where + N' AND (CreatedOn = @createdOn)'
	-- UpdatedOn
	IF (CAST('1900-01-01 00:00:00.0000000' AS DATETIME2) < @updatedOn) SET @where = @where + N' AND (UpdatedOn = @updatedOn)'

	SET @stmt = (@select + @from + @where)
	SET @params = N'@id INT, @name NVARCHAR(MAX), @enabled BIT, @createdOn DATETIME2, @updatedOn DATETIME2, @count INT OUTPUT'
	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @id = @id, @name = @name, @enabled = @enabled, @createdOn = @createdOn, @updatedOn = @updatedOn, @count = @count OUTPUT

	SET @error= @@ERROR
	
	RETURN @count

END
