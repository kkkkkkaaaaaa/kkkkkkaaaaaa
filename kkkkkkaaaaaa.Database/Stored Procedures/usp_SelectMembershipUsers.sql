CREATE PROCEDURE [dbo].[usp_SelectMembershipUsers]
	-- 
	@membershipId	BIGINT
AS
	-- 
	DECLARE
		@error	INT

	-- SELECT
	SELECT
		*

	FROM
		MembershipUsers

	WHERE
		MembershipID = @membershipId

	ORDER BY
		UserID ASC

	-- 
	SET @error = @@ERROR

	RETURN @error
