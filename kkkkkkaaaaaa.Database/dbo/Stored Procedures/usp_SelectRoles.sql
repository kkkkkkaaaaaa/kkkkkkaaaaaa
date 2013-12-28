CREATE PROCEDURE usp_SelectRoles (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024) = N''
	, @description	NVARCHAR(MAX) = N''
	--, @enabled		BIT
	, @createdOn	DATETIME2 = '0001-01-01 00:00:00.0000000'
	, @updatedOn	DATETIME2 = '0001-01-01 00:00:00.0000000'
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
		+ ' Roles'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF (0 < @id)	SET @where = @where + ' AND ID = ' + CAST(@id AS NVARCHAR(MAX))

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' UpdatedOn ASC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
