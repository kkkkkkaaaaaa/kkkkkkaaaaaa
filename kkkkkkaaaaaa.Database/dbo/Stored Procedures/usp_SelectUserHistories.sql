CREATE PROCEDURE usp_SelectUserHistories
	@userId			BIGINT
	, @revision		INT
AS
	-- 変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT'
		+ ' *'

	-- FROM
	SET @from = ' FROM'
		+ ' UserHistories'

	-- WHERE
	SET @where = ' WHERE'
		+ ' UserID = ' + CONVERT(NVARCHAR(MAX), @userId)

	IF (0 < @revision) SET @where = @where + ' AND Revision = ' + CONVERT(NVARCHAR(MAX), @revision)

	-- 実行
	EXECUTE (@select + @from + @where)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
