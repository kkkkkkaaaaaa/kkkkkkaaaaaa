CREATE PROCEDURE usp_UpdateRoleAuthorizations (
	-- パラメーター
	@roleId				BIGINT
	, @authorizationId	BIGINT
	, @enabled			BIT
) AS
	-- 変数
	DECLARE
		@update		NVARCHAR(MAX)
		, @set		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- UPDATE
	SET @update = 'UPDATE'
		+ ' RoleAuthorizations'

	-- SET
	SET @set = ' SET'
		+ ' [Enabled]				= ' + CONVERT(NVARCHAR(MAX), @enabled) + ''

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND RoleID				= ' + CONVERT(NVARCHAR(MAX), @roleId) + ''
		+ ' AND AuthorizationID		= ' + CONVERT(NVARCHAR(MAX), @authorizationId) + ''

	/*
	-- UPDATE
	UPDATE
		RoleAuthorizations
	SET
		RoleID				= @roleId
		, AuthorizationID	= @authorizationId
		, [Enabled]			= @enabled
	WHERE
		ID					= @id
	*/

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count