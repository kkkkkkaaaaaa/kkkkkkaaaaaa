CREATE PROCEDURE usp_DeleteMembershipUsers
	-- 
	@membershipId	BIGINT
	, @userId		BIGINT
AS
	-- 
	DECLARE
		@delete		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- 
	SET @delete = 'DELETE'
		+ ' MembershipUsers'

	SET @where = ' WHERE 1 = 1'
		+ ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	IF (0 < @userId)		SET @where = @where + ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))

	-- 
	EXECUTE (@delete + @where)

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
