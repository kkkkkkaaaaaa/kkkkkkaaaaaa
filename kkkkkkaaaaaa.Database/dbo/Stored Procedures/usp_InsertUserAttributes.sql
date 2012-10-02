CREATE PROCEDURE usp_InsertUserAttributes (
	@id			BIGINT
	, @userId	BIGINT
	, @itemId	INT
	, @value	NVARCHAR(MAX)
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
	SET @into = ' INTO UserAttributes ('
		+ 'UserID'
		+ ', ItemID'
		+ ', Value'

	IF (0 < @id)	SET @into = @into + ', ID'
	 
	-- VALUES
	SET @values = ') VALUES ('
		+ '' + CONVERT(NVARCHAR(MAX), @userId)
		+ ', ' + CONVERT(NVARCHAR(MAX), @itemId)
		+ ', ''' + @value + ''''

	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR(MAX), @id)
	
	SET @values = @values + ')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
