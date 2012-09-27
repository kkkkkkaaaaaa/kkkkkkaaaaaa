CREATE PROCEDURE usp_InsertMembershipRoles
	@membershipId		BIGINT
	, @roleId			BIGINT
	, @enabled			BIT
AS
	-- 変数
	DECLARE
		@error			INT

	-- INSERT
	INSERT INTO
		MembershipRoles (
			MembershipID
			, RoleID
			, [Enabled]
		) VALUES (
			@membershipId
			, @roleId
			, @enabled
		)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
