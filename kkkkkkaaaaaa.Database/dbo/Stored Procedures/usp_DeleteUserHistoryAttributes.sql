CREATE PROCEDURE usp_DeleteUserHistoryAttributes (
	-- パラメーター
	@userId			BIGINT
	, @revision		INT
	, @itemId		INT
) AS
	-- 
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE'

	-- FROM
	SET @from = ' FROM'
		+ ' UserHistoryAttributes'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))
	IF (0 < @revision)	SET @where = @where + ' AND Revision = ' + CAST(@revision AS NVARCHAR(MAX))
	IF (0 < @itemId)	SET @where = @where + ' AND ItemID = ' + CAST(@itemId AS NVARCHAR(MAX))

	-- 
	EXECUTE (@delete + @from + @where)

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count