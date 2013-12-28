CREATE PROCEDURE usp_SelectRoleAuthorizations
	-- パラメーター
	@roleId				BIGINT
	, @authorizationId	BIGINT
AS
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

	--- FROM
	SET @from = ' FROM'
		+ ' RoleAuthorizations'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	
	IF (0 < @roleId)			SET @where = @where + ' AND RoleID = ' + CONVERT(NVARCHAR(MAX), @roleId)
	IF (0 < @authorizationId)	SET @where = @where + ' AND AuthorizationID = ' + CONVERT(NVARCHAR(MAX), @authorizationId)

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' RoleID ASC'
		+ ', AuthorizationID ASC'
		
	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
