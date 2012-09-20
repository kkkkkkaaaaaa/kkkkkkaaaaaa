CREATE PROCEDURE usp_SelectUsers
(
	@id			BIGINT
	, @enabled	BIT
) AS

	-- ローカル変数
	DECLARE
		@select		AS NVARCHAR(MAX) = 'SELECT * '
		, @from		AS NVARCHAR(MAX) = 'FROM Users '
		, @where	AS NVARCHAR(MAX) = 'WHERE 1 = 1 '
		, @orderby	AS NVARCHAR(MAX) = 'ORDER BY UpdatedOn DESC'
		, @result	AS INT

	-- WHERE
	IF @id		IS NOT NULL		SET @where = @where + ' AND ID = ' + @id
	IF @id		IS NOT NULL		SET @where = @where + ' AND Enabled = ' + CONVERT(NVARCHAR, @enabled, NULL)

	--クエリー
	SET @select = @select + @from + @where + @orderby
	
	-- 実行
	EXECUTE (@select)

	-- 戻り値
	RETURN @@ERROR
