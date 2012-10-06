CREATE PROCEDURE usp_UpdateUsers (
	-- パラメーター
	@familyName			VARCHAR(1024)
	, @additionalName	VARCHAR(1024)
	, @givenName		VARCHAR(1024)
	, @description		VARCHAR(MAX)
	, @enabled			BIT
	, @createdOn		DateTime2(7)
	, @updatedOn		DateTime2(7)
	, @id				VARCHAR(MAX)
)
AS
	-- 変数
	DECLARE
		@update		VARCHAR(MAX)
		, @set		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
		, @count	INT

	-- UPDATE
	SET @update	= 'UPDATE Users'

	
	-- SET
	SET @set = ' SET'
	IF @id IS NOT NULL BEGIN
		SET @set = @set
			+ ' FamilyName			= ''' + CONVERT(NVARCHAR(MAX), @familyName) + ''''
			+ ', AdditionalName		= ''' + CONVERT(NVARCHAR(MAX), @additionalName) + ''''
			+ ', GivenName			= ''' + CONVERT(NVARCHAR(MAX), @givenName) + ''''
			+ ', Description		= ''' + CONVERT(NVARCHAR(MAX), @description) + ''''

	END ELSE IF @enabled IS NOT NULL BEGIN
		SET @set = @set
			+ ', Enabled			= ' + CONVERT(NVARCHAR(MAX), @enabled) + ''

	END

	SET @set = @set
		+ ', UpdatedOn				= ''' + CONVERT(NVARCHAR(MAX), @updatedOn) + ''''

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND ID = ' + CONVERT(NVARCHAR(MAX), @id) + ''

	-- 実行
	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
