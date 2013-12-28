CREATE PROCEDURE usp_InsertMembershipAuthorizations (
	@membershipId		BIGINT
	, @authorizationId	BIGINT
) AS

	DECLARE
		@count	INT

	INSERT
		INTO MembershipAuthorizations (
			MembershipID
			, AuthorizationID
		) VALUES (
			@membershipId
			, @authorizationId
		)

	SET @count = @@ROWCOUNT

	RETURN @count
