CREATE PROCEDURE usp_SelectMembershipAuthorizations (
	-- パラメーター
	@membershipId	BIGINT
	, @authorizationId		BIGINT
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
		+ ' MembershipAuthorizations'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	if (0 < @authorizationId)	SET @where = @where + ' AND AuthorizationID = ' + CAST(@authorizationId AS NVARCHAR(MAX))

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' MembershipID ASC'
		+ ', AuthorizationID ASC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
