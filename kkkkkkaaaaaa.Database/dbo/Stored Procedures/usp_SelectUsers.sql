CREATE PROCEDURE usp_SelectUsers (
	-- パラメーター
	@id					BIGINT
	--, @familyName		NVARCHAR(1024)
	--, @givenName		NVARCHAR(1024)
	--, @additionalName	NVARCHAR(1024)
	--, @description		NVARCHAR(MAX)		
	, @enabled			BIT
	--, @createdOn		DATETIME2
	--, @updatedOn		DATETIME2
) AS

	-- ローカル変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @orderby	NVARCHAR(MAX)
		, @error	INT

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
