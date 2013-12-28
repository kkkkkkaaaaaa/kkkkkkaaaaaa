CREATE PROCEDURE [dbo].[usp_SelectMembershipsView]
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
	, @pageSize		INT	= 1
	, @startPage	INT = 1

AS BEGIN

	DECLARE
		@select			NVARCHAR(MAX)
		, @from			NVARCHAR(MAX)
		, @where		NVARCHAR(MAX)
		, @stmt			NVARCHAR(MAX)
		, @params		NVARCHAR(MAX)
		, @startRow		INT = 1
		, @result		INT
		, @count		INT
		, @error		INT
		
	-- SELECT
	SET @select = N'SELECT'
		+ N' RowNumber'
		+ N', ID'
		+ N', Name'
		+ N', [Enabled]'

	SET @from = N' FROM'
		+ ' (SELECT'
		+ N' ROW_NUMBER() OVER(ORDER BY UpdatedOn ASC) AS RowNumber'
		+ N', ID'
		+ N', Name'
		+ N', [Enabled]'
		+ N' FROM MembershipsView) V'

	SET @where = N''
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
	
	-- COUNT
	SET @stmt = N''
		+ N'SELECT @count = COUNT(ID) FROM MembershipsView WHERE (1 = 1)' + @where + N';'

	-- ページング
	IF (@startPage < 1) SET @startRow = 0 + 1
	ELSE SET @startRow = ((@startPage - 1) * @pageSize)
	
	-- WHERE
	SET @where = N' WHERE (1 = 1)'
		+ N' AND ((@startRow <= RowNumber) AND (RowNumber <= (@startRow + @pageSize)))'
		+ @where
		+ N';' + dbo.NL()

	-- 実行
	SET @stmt = (@select + @from + @where) + @stmt
	SET @params = N'@id INT, @name NVARCHAR(1024), @enabled BIT, @createdOn DATETIME2, @updatedOn DATETIME2, @startRow INT, @pageSize INT, @count INT OUTPUT'
	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @id = @id, @name = @name, @enabled = @enabled, @createdOn = @createdOn, @updatedOn = @updatedOn, @startRow = @startRow, @pageSize = @pageSize, @count = @count OUTPUT
		
	SET @error = @@ERROR

	RETURN @error

END
