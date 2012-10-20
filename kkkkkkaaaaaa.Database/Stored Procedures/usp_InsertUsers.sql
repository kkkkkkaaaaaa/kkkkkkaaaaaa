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
		+ ', ' + CAST(CAST('TRUE' AS BIT) AS NCHAR(1))
		+ ', ''' + CAST(@createdOn AS NVARCHAR(27)) + ''''
		+ ', ''' + CAST(@createdOn AS NVARCHAR(27)) + ''''
	IF (0 < @id)	SET @values = @values + ', ' + CAST(@id AS NVARCHAR)

	SET @values = @values + ')'

	-- IDENTITY_INSERT
	IF (0 < @id)	SET IDENTITY_INSERT Users ON

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 結果
	SET @count = @@ROWCOUNT
	
	IF (0 < @id)	SET IDENTITY_INSERT Users OFF

	RETURN @count
