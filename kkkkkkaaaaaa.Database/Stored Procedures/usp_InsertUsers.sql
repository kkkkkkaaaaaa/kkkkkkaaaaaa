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
	, @identity			DECIMAL(38, 0)		OUTPUT
) AS
	-- 変数
	DECLARE
		@insert			NVARCHAR(MAX)
		, @into			NVARCHAR(MAX)
		, @values		NVARCHAR(MAX)
		, @stmt			NVARCHAR(MAX)
		, @params		NVARCHAR(MAX)
		, @result		INT
		, @error		INT

	-- INSERT
	SET @insert = N'INSERT'

	-- INTO
	SET @into = N' INTO Users ('
		+ N'FamilyName'
		+ N', GivenName'
		+ N', AdditionalName'
		+ N', [Description]'
		+ N', [Enabled]'
		+ N', CreatedOn'
		+ N', UpdatedOn'
	IF (0 < @id)	SET @into = @into + N', ID'
	SET @into = @into + N')'
	
	-- VALUES
	SET @values = N' VALUES ('
		+ N'@familyName'
		+ N', @givenName'
		+ N', @additionalName'
		+ N', @description'
		+ N', @enabled'
		+ N', @createdOn'
		+ N', @createdOn'
	IF (0 < @id)	SET @values = @values + N', @id'
	SET @values = @values + N');'
	
	-- 実行
	SET @stmt = (@insert + @into + @values)
	SET @stmt = N''
		+ N'IF (0 < @id)	SET IDENTITY_INSERT Users ON;' + dbo.NL()
		+ @stmt + dbo.NL()
		+ N'SET @identity = SCOPE_IDENTITY();' + dbo.NL()
		+ N'IF (0 < @id)	SET IDENTITY_INSERT Users OFF;' + dbo.NL()

	SET @params = N'@id BIGINT, @familyName NVARCHAR(1024), @givenName NVARCHAR(1024), @additionalName NVARCHAR(1024), @description NVARCHAR(MAX)'
		+ N', @enabled BIT, @createdOn DATETIME2(7), @updatedOn DATETIME2(7), @identity DECIMAL(38, 0) OUTPUT'

	-- 実行
	BEGIN TRY
		EXECUTE @result = sp_executesql
			@stmt
			, @params
			, @id = @id, @familyName = @familyName, @givenName = @givenName, @additionalName = @additionalName, @description = @description
				, @enabled = @enabled, @createdOn = @createdOn, @updatedOn = @createdOn, @identity = @identity OUTPUT

		-- 結果
		SET @error = @@ERROR

	END TRY BEGIN CATCH
		SELECT @error = ERROR_NUMBER()
		SET @identity = -1

	END CATCH

	RETURN @error
