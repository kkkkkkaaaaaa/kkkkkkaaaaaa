CREATE PROCEDURE usp_DeleteMembershipAuthorizations (
	-- 
	@membershipId		BIGINT
	, @authorizationId	BIGINT
) AS
	-- 
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE'

	-- FROM
	SET @from = ' FROM MembershipAuthorizations'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	IF (0 < @authorizationId)	SET @where = @where + ' AND AuthorizationID = ' + CAST(@authorizationId AS NVARCHAR(MAX))

	-- 
	EXECUTE (@delete + @from + @where)

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
