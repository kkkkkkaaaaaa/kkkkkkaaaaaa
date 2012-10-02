CREATE PROCEDURE usp_SelectUsers (
	-- パラメーター
	@id			BIGINT
	, @enabled	BIT
) AS

	-- ローカル変数
	DECLARE
		@select		AS NVARCHAR(MAX)
		, @from		AS NVARCHAR(MAX)
		, @where	AS NVARCHAR(MAX)
		, @orderby	AS NVARCHAR(MAX)
		, @error	AS INT

	-- SELECT
	SET @select = 'SELECT *'

	-- FROM
	SET @from = ' FROM Users'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND [Enabled] = ' + CONVERT(VARCHAR(MAX), @enabled)

	IF (0 < @id) SET @where = @where + ' AND ID = ' + CONVERT(VARCHAR(MAX), @id)

	-- ORDER BY
	SET @orderby = ' ORDER BY UpdatedOn DESC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderby)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
