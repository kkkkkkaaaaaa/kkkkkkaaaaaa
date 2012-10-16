CREATE PROCEDURE usp_InsertRoles (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(MAX) = ''
	, @description	NVARCHAR(MAX) = ''
	, @enabled		BIT
	, @createdOn	DATETIME2 = '0001-01-01 00:00:00.0000000'
	, @updatedOn	DATETIME2 = '0001-01-01 00:00:00.0000000'
) AS
	-- 変数
	DECLARE
		@insert		NVARCHAR(MAX)
		, @into		NVARCHAR(MAX)
		, @values	NVARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'

	-- INTO
	SET @into = ' INTO Roles ('
		+ 'Name'
		+ ', [Description]'
		+ ', [Enabled]'
		+ ', CreatedOn'
		+ ', UpdatedOn'
	IF (0 < @id) SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '''' + @name + ''''
		+ ', ''' + @description + ''''
		+ ', ' + CAST(CAST('TRUE' AS BIT) AS NCHAR(1))
		+ ', ''' + CAST(@createdOn AS NVARCHAR) + ''''
		+ ', ''' + CAST(@createdOn AS NVARCHAR) + ''''
	IF (0 < @id) SET @values = @values + ', @id'

	SET @values	= @values + ')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
