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
	SET @select = 'SELECT *'

	-- FROM
	SET @from = ' FROM Users'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF @id			IS NOT NULL		SET @where = @where + ' AND ID = ' + CAST(@id AS NVARCHAR)
	IF @enabled		IS NOT NULL		SET @where = @where + ' AND Enabled = ' + CAST(@enabled AS NVARCHAR)
	--IF @enabled		IS NOT NULL		SET @where = @where + ' AND Enabled = ' + CONVERT(NVARCHAR(1), @enabled, NULL)

	-- ORDER BY
	SET @orderby = ' ORDER BY UpdatedOn DESC'

	--クエリー
	SET @select = @select + @from + @where + @orderby
	
	-- 実行
	EXECUTE (@select)

	-- 戻り値
	RETURN @@ERROR
