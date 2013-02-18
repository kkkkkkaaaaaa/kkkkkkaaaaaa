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
	-- 出力
	, @identity			NUMERIC(38, 0) = -1	OUTPUT
) AS
	-- 変数
	DECLARE
		@insert			VARCHAR(MAX)
		, @into			VARCHAR(MAX)
		, @values		VARCHAR(MAX)
		, @output		VARCHAR(MAX)
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
	SET @values = @values + N')'

	SET @output = N'; SELECT SCOPE_IDENTITY();'

	-- 実行
	IF (0 < @id)	SET IDENTITY_INSERT Users ON
	EXECUTE (@insert + @into + @values)
	SELECT SCOPE_IDENTITY()
	IF (0 < @id)	SET IDENTITY_INSERT Users OFF

	--IF (0 < @id)	SET @identity = @id
	--ELSE			SET @identity = SCOPE_IDENTITY()


	-- 結果
	SET @error = @@ERROR

	RETURN @error
