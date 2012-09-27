CREATE PROCEDURE usp_UpdateRoleAuthorizations (
	-- パラメーター
	@roleId				BIGINT
	, @authorizationId	BIGINT
	, @enabled			BIT
	, @id				BIGINT
) AS
	-- 変数
	DECLARE
		@error	INT

	-- UPDATE
	UPDATE
		RoleAuthorizations
	SET
		RoleID				= @roleId
		, AuthorizationID	= @authorizationId
		, [Enabled]			= @enabled
	WHERE
		ID					= @id

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error