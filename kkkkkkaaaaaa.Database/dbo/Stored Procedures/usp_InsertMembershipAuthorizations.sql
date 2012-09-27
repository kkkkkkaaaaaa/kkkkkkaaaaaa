CREATE PROCEDURE usp_InsertMembershipAuthorizations
	@membershipId		BIGINT
	, @authorizationID	BIGINT
	, @enabled			BIT
AS
	-- 変数
	DECLARE
		@error			INT

	INSERT INTO
		MembershipAuthorizations (
			MembershipID
			, AuthorizationID
			, [Enabled]
		) VALUES (
			@membershipId
			, @authorizationID
			, @enabled
		)

	RETURN @error
