CREATE PROCEDURE usp_SelectMembershipUsers
	-- パラメーター
	@membershipId	BIGINT
	, @userId		BIGINT
AS
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
		+ ' MembershipUsers'
		
	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF (0 < @membershipId)	SET @where = @where + ' AND MembershipID	= ' + CAST(@membershipId AS NVARCHAR(MAX))
	IF (0 < @userId)		SET @where = @where + ' AND UserID			= ' + CAST(@userId AS NVARCHAR(MAX))
	
	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ ' MembershipID ASC'
		+ ', UserID ASC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
