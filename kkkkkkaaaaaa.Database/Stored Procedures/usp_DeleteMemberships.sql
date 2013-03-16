CREATE PROCEDURE usp_DeleteMemberships
	-- パラメーター
	@id		BIGINT
AS
	-- 変数
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @result	INT
		, @error	INT

	-- DELETE
	SET @delete = N'DELETE'

	-- FROM
	SET @from = N' FROM'
		+ N' Memberships'

	-- WHERE
	SET @where = N' WHERE'
		+ N' ID = @id'

	-- 実行
	SET @stmt = (@delete + @from + @where)
	SET @params = N'@id BIGINT'
	EXECUTE @result = sp_executesql
		@stmt
		, @params
		, @id = @id

	-- 結果
	SET @error = @@ERROR

	RETURN
