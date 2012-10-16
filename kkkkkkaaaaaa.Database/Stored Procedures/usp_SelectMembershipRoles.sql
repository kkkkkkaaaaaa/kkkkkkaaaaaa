CREATE PROCEDURE usp_SelectMembershipRoles (
	-- パラメーター
	@membershipId	BIGINT
	, @roleId		BIGINT
) AS
	-- 変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @orderBy	NVARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT'
		+ ' *'

	-- FROM
	SET @from = ' FROM'
		+ ' MembershipRoles'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	if (0 < @membershipId)	SET @where = @where + ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	if (0 < @roleId)		SET @where = @where + ' AND RoleID = ' + CAST(@roleId AS NVARCHAR(MAX))

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' MembershipID ASC'
		+ ', RoleID ASC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
