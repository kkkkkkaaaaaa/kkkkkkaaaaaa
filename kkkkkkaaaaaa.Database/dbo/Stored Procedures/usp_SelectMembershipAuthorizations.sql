CREATE PROCEDURE usp_SelectMembershipAuthorizations
	-- パラメーター
	@id						BIGINT
	, @membershipId			BIGINT
	, @authorizationId		BIGINT
	, @enabled				BIT
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

	SET @from = ' FROM'
		+ ' MembershipAuthorizations'

	SET @where = ' WHERE 1 = 1'
		+ ' AND MembershipID = ' + CONVERT(NVARCHAR(MAX), @id) + ''
		+ ' AND [Enabled] = ' + CONVERT(NVARCHAR(MAX), @enabled) + ''
		
	IF (0 < @membershipId)			SET @where = @where + ' AND MembershipID = ' + CONVERT(NVARCHAR(MAX), @membershipId) + ''
	IF (0 < @authorizationId)		SET @where = @where + ' AND AuthorizationID = ' + CONVERT(NVARCHAR(MAX), @authorizationId) + ''

	SET @orderBy = ' ORDER BY'
		+ ' ID ASC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
