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
		, @result	AS INT

	-- SELECT
	SET @select = N'SELECT *'

	-- FROM
	SET @from = N' FROM Users'

	-- WHERE
	SET @where = N'1 = 1'
	IF @id		IS NOT NULL		SET @where = @where + N' AND ID = ' + @id
	IF @id		IS NOT NULL		SET @where = @where + N' AND Enabled = ' + CONVERT(NVARCHAR, @enabled, NULL)

	-- ORDER BY
	SET @orderby = N' ORDER BY UpdatedOn DESC'

	--クエリー
	SET @select = @select + @from + @where + @orderby
	
	-- 実行
	EXECUTE (@select)

	-- 戻り値
	RETURN @@ERROR
