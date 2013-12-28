CREATE PROCEDURE usp_DeleteAuthorizations
	-- パラメーター
	@id		BIGINT	= -1
AS
	-- 変数
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @error	INT

	-- DELETE
	SET @delete = N'DELETE'

	-- FROM
	SET @from = N' FROM Authorizations'

	-- WHERE
	SET @where = N''
	IF (0 < @id) BEGIN
		SET @where = @where + N' WHERE'
		SET @where = @where + N' ID = ' + CAST(@id AS NVARCHAR(MAX))

	END

	-- 実行
	EXECUTE (@delete + @from + @where)

	-- エラー
	SET @error = @@ERROR

	RETURN @error
