CREATE PROCEDURE usp_InsertMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		NVARCHAR(128)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
	-- 出力パラメーター
	, @identity		DECIMAL(38, 0)		OUTPUT
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
	SET @into = N' INTO Memberships ('
		+ N'Name'
		+ N', [Password]'
		+ N', [Enabled]'
		+ N', CreatedOn'
		+ N', UpdatedOn'
	IF (0 < @id)	SET @into = @into + N', ID'
	SET @into = @into + N')'
	
	-- VALUES
	SET @values = ' VALUES ('
		+ N'@name'
		+ N', @password'
		+ N', @enabled'
		+ N', @createdOn'
		+ N', @createdOn'
	IF (0 < @id)	SET @values = @values + N', @id'
	SET @values = @values + N');'

	-- 宣言
	SET @stmt = N''
		+ N'IF (0 < @id)	SET IDENTITY_INSERT Memberships ON;' + dbo.NL()
		+ (@insert + @into + @values) + dbo.NL()
		+ N'SET @identity = SCOPE_IDENTITY();' + dbo.NL()
		+ N'IF (0 < @id)	SET IDENTITY_INSERT Memberships OFF;' + dbo.NL()

	-- パラメーター
	SET @params = N'@id BIGINT, @name NVARCHAR(1024), @password NVARCHAR(128), @enabled BIT, @createdOn	DATETIME2, @updatedOn DATETIME2, @identity DECIMAL(38, 0) OUTPUT'
	
	
	-- 実行
	/* BEGIN TRY */
		EXECUTE @result = sp_executesql
			@stmt
			, @params
			, @id = @id, @name = @name, @password = @password, @enabled = @enabled, @createdOn = @createdOn, @updatedOn = @createdOn, @identity = @identity OUTPUT
			
		SET @error = @@ERROR
	/*
	END TRY BEGIN CATCH
		SELECT @error = ERROR_NUMBER()
		SET @identity = -1

	END CATCH
	*/
	
	-- 戻り値
	RETURN @error
