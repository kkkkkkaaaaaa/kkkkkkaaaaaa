CREATE PROCEDURE usp_SelectUserAttributes (
	-- パラメーター
	@userId		BIGINT
	, @itemId	INT
) AS
	-- 変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @orderBy	NVARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT'
		+ ' *'

	-- FROM
	SET @from = ' FROM'
		+ ' UserAttributes'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))
	IF (0 < @itemId)	SET @where = @where + ' AND ItemID = ' + CAST(@itemId AS NVARCHAR(MAX))

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' ItemID ASC'

	-- 
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR
	
	RETURN @error

