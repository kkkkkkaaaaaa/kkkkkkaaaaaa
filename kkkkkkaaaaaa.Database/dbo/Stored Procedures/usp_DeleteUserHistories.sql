CREATE PROCEDURE usp_DeleteUserHistories
	-- パラメーター
	@userId			BIGINT
	, @revision		INT
AS
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where 	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE '

	-- FROM
	SET @from = ' FROM'
		+ ' UserHistories'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))
	IF (0 < @revision)	SET @where = @where + ' AND Revision' + CAST(@revision AS NVARCHAR(MAX))

	-- 実行
	EXECUTE (@delete + @from + @where + @count)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
	