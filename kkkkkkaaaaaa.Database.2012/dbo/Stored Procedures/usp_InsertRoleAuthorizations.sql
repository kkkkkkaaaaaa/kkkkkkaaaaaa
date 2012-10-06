CREATE PROCEDURE usp_InsertRoleAuthorizations
	@roleID				BIGINT
	, @authorizationId	BIGINT
	, @enabled			BIT
AS
	-- 変数
	DECLARE
		@count	INT

	-- INSERT
	INSERT INTO
		RoleAuthorizations (
			RoleID
			, AuthorizationID
			, [Enabled]
		) VALUES (
			@roleID
			, @authorizationId
			, @enabled
		)
	
	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
