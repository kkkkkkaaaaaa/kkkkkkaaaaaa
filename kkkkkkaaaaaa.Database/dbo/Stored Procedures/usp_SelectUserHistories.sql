CREATE PROCEDURE usp_SelectUserHistories (
	@userId			BIGINT
	, @revision 	INT
) AS
	-- 変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @orderBy	NVARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT '
		+ '*'

	-- FROM
	SET @from = ' FROM'
		+ ' UserHistories'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))
	IF (0 < @revision) SET @where = @where + ' AND Revision = ' + CAST(@revision AS NVARCHAR(MAX))

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' Revision DESC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
