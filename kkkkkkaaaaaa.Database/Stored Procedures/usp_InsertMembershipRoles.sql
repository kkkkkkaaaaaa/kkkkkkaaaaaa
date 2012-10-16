CREATE PROCEDURE usp_InsertMembershipRoles (
	-- パラメーター
	@membershipId	BIGINT
	, @roleId		BIGINT
) AS
	-- 変数
	DECLARE
		@count	INT

	-- INSERT
	INSERT
		INTO MembershipRoles (
			MembershipID
			, RoleID
		) VALUES (
			@membershipId
			, @roleId
		)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count

