CREATE PROCEDURE usp_InsertUsers (
	-- パラメーター
	@id					BIGINT
	, @familyName		NVARCHAR(1024)
	, @givenName		NVARCHAR(1024)
	, @additionalName	NVARCHAR(1024)
	, @description		NVARCHAR(MAX)
	, @enabled			BIT
	, @createdOn		DATETIME2(7)
	, @updatedOn		DATETIME2(7)
) AS
	-- 変数
	DECLARE
		@insert		VARCHAR(MAX)
		, @into		VARCHAR(MAX)
		, @values	VARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'

	-- INTO
	SET @into = ' INTO Users ('
		+ 'FamilyName'
		+ ', GivenName'
		+ ', AdditionalName'
		+ ', Description'
		+ ', Enabled'
		+ ', CreatedOn'
		+ ', UpdatedOn'
	IF (0 < @id)	SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '''' + @familyName + ''''
		+ ', ''' + @givenName + ''''
		+ ', ''' + @additionalName + ''''
		+ ', ''' + @description + ''''
		+ ', ' + CONVERT(NVARCHAR, @enabled) + ''
		+ ', ''' + CONVERT(NVARCHAR, @createdOn) + ''''
		+ ', ''' + CONVERT(NVARCHAR, @createdOn) + ''''

	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR, @id)

	SET @values = @values + ')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 結果
	SET @count = @@ROWCOUNT

	RETURN @count
