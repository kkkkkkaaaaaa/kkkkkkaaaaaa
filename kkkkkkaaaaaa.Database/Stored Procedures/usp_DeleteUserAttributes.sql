CREATE PROCEDURE usp_DeleteUserAttributes (
	-- 
	@userId		BIGINT
	, @itemId	INT
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
		+ ' UserAttributes'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))
	IF (0 < @itemId)	SET @where = @where + ' AND ItemID = ' + CAST(@itemId AS NCHAR(1))

	-- 
	EXECUTE (@delete + @from + @where)

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
