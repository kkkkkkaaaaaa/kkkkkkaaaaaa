CREATE PROCEDURE [dbo].[usp_InsertMembershipUsers]
	-- 
	@membershipId	BIGINT
	, @userId		BIGINT
AS
	-- 
	DECLARE
		@count	INT

	-- INSERT
	INSERT
		INTO MembershipUsers (
			MembershipID
			, UserID
		) VALUES (
			@membershipId
			, @userId
		)

	--
	SET @count = @@ROWCOUNT

	RETURN @count

