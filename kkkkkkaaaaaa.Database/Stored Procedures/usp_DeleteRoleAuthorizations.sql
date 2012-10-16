CREATE PROCEDURE usp_DeleteRoleAuthorizations (
	-- パラメーター
	@roleId				BIGINT
	, @authorizationId	BIGINT
) AS
	-- 条件なし
	IF ((@roleId <= 0) AND (@authorizationId <= 0))		RETURN -1

	-- 変数
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE'

	-- FROM
	SET @from = ' FROM'
		+ ' RoleAuthorizations'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF (0 < @roleId)			SET @where = @where	+ ' AND RoleID = ' + CAST(@roleId AS NVARCHAR(MAX))
	IF (0 < @authorizationId)	SET @where = @where + ' AND AuthorizationID = ' + CAST(@authorizationId AS NVARCHAR(MAX))

	-- 実行
	EXECUTE (@delete + @from + @where)
	
	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
