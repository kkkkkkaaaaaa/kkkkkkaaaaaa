CREATE PROCEDURE usp_DeleteMembershipRoles (
	-- 
	@membershipId	BIGINT
	, @roleId		BIGINT
) AS
	-- ID なし
	IF ((@membershipId <= 1) AND (@roleId <= 1))	RETURN -1

	-- 
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE'

	-- FROM
	SET @from = ' FROM MembershipRoles'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF (0 < @membershipId)	SET @where = @where + ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	IF (0 < @roleId)		SET @where = @where + ' AND RoleID = ' + CAST(@roleId AS NVARCHAR(MAX))

	-- 
	EXECUTE (@delete + @from + @where)

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
