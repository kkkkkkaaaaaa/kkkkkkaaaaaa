CREATE PROCEDURE usp_InsertRoles(
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
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
		+ ' Name'
		+ ', [Description]'
		+ ', [Enabled]'
		+ ', CreatedOn'
		+ ', UpdatedOn'

	IF (0 < @id)	SET @into = @into + ', ID'

	-- WHERE
	SET @values = ') VALUES ('
		+ '''' + CONVERT(VARCHAR(MAX), @name) + ''''
		+ ', ''' + CONVERT(VARCHAR(MAX), @description) + ''''
		+ ', ' + CONVERT(VARCHAR(MAX), @enabled) + ''
		+ ', ''' + CONVERT(VARCHAR(MAX), @createdOn) + ''''
		+ ', ''' + CONVERT(VARCHAR(MAX), @createdOn) + ''''

	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR(MAX), @id)

	SET @values = @values + ')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
