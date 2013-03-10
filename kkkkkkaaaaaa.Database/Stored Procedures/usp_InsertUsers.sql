CREATE PROCEDURE usp_InsertUsers (
	-- 入力パラメーター
	@id					BIGINT
	, @familyName		NVARCHAR(1024)
	, @givenName		NVARCHAR(1024)
	, @additionalName	NVARCHAR(1024)
	, @description		NVARCHAR(MAX)
	, @enabled			BIT
	, @createdOn		DATETIME2(7)
	, @updatedOn		DATETIME2(7)
	-- 出力パラメーター
	, @identity			NUMERIC(38, 0) = -1	OUTPUT
) AS
	-- 変数
	DECLARE
		@insert			VARCHAR(MAX)
		, @into			VARCHAR(MAX)
		, @values		VARCHAR(MAX)
		, @stmt			VARCHAR(MAX)
		, @params		VARCHAR(MAX)
		, @result		VARCHAR(MAX)
		, @error		INT

	-- INSERT
	SET @insert = N'INSERT'

	-- INTO
	SET @into = N' INTO Users ('
		+ N'FamilyName'
		+ N', GivenName'
		+ N', AdditionalName'
		+ N', Description'
		+ N', Enabled'
		+ N', CreatedOn'
		+ N', UpdatedOn'
	IF (0 < @id)	SET @into = @into + ', ID'
	SET @into = @into + N')'

	-- VALUES
	SET @values = N' VALUES ('
		+ N'''' + @familyName + ''''
		+ N', ''' + @givenName + ''''
		+ N', ''' + @additionalName + ''''
		+ N', ''' + @description + ''''
		+ N', ' + CAST(@enabled AS NCHAR(1))
		+ N', ''' + CAST(@createdOn AS NVARCHAR(27)) + ''''
		+ N', ''' + CAST(@createdOn AS NVARCHAR(27)) + ''''
	IF (0 < @id)	SET @values = @values + ', ' + CAST(@id AS NVARCHAR)
	SET @values = @values + N');'
	
	-- 宣言
	SET @stmt = N' SET @identity = SCOPE_IDENTITY();'
	SET @stmt = (@insert + @into + @values) + @stmt

	-- パラメーター
	SET @params = N'@id BIGINT, @familyName NVARCHAR(1024), @givenName NVARCHAR(1024), @additionalName NVARCHAR(1024) , @description NVARCHAR(MAX), '
		+ N'@enabled BIT, @createdOn DATETIME2(7), @updatedOn DATETIME2(7) , @identity NUMERIC(38, 0) = -1 OUTPUT'
		
	-- 実行
	IF (0 < @id)	SET IDENTITY_INSERT Users ON

	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @id = @id, @familyName = @familyName, @givenName = @givenName, @additionalName = @additionalName, @description = @description
		, @enabled = @enabled, @createdOn = @createdOn, @updatedOn = @createdOn, @identity = @identity OUTPUT

	IF (0 < @id)	SET IDENTITY_INSERT Users OFF

	-- 結果
	SET @error = @@ERROR

	RETURN @error
