CREATE PROCEDURE usp_UpdateMembershipRoles (
	-- パラメーター
	@membershipId	BIGINT
	, @roleId		BIGINT
	, @enabled		BIT
	, @id			BIGINT
) AS
	-- 変数
	DECLARE
		@count	INT

	-- UPDATE
	UPDATE
		MembershipRoles
	SET
		MembershipID	= @membershipId
		, RoleID		= @roleId
		, [Enabled]		= @enabled
	WHERE
		ID				= @id

	-- 戻り値
	SET @count	= @@ROWCOUNT

	RETURN @count