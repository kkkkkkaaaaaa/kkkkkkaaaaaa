CREATE PROCEDURE usp_UpdateUsers (
	-- パラメーター
	@id					BIGINT
	, @familyName		VARCHAR(1024)
	, @additionalName	VARCHAR(1024)
	, @givenName		VARCHAR(1024)
	, @description		VARCHAR(MAX)
	, @enabled			BIT
	, @createdOn		DateTime2(7)
	, @updatedOn		DateTime2(7)
) AS
	IF (@id < 1)	RETURN -1

	-- 変数
	DECLARE
		@update		VARCHAR(MAX)
		, @set		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
		, @count	INT

	-- UPDATE
	SET @update	= 'UPDATE'
		+ ' Users'
	
	-- SET
	SET @set = ' SET'
		+ ' FamilyName			= ''' + CAST(@familyName AS NVARCHAR(MAX)) + ''''
		+ ', AdditionalName		= ''' + CAST(@additionalName AS NVARCHAR(MAX)) + ''''
		+ ', GivenName			= ''' + CAST(@givenName AS NVARCHAR(MAX)) + ''''
		+ ', [Description]		= ''' + CAST(@description AS NVARCHAR(MAX)) + ''''
		+ ', [Enabled]			= ' + CAST(@enabled AS NCHAR(1))
		+ ', UpdatedOn			= ''' + CONVERT(NVARCHAR(MAX), @updatedOn) + ''''

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND ID = ' + CAST(@id AS NVARCHAR(MAX))

	-- 実行
	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
