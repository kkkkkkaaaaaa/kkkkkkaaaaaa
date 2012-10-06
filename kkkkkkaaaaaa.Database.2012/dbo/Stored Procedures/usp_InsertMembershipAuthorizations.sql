CREATE PROCEDURE usp_InsertMembershipAuthorizations
	@id					BIGINT
	, @membershipId		BIGINT
	, @authorizationId	BIGINT
	, @enabled			BIT
AS
	-- 変数
	DECLARE
		@insert		NVARCHAR(MAX)
		, @into		NVARCHAR(MAX)
		, @values	NVARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'

	SET @into = ' INTO MembershipAuthorizations ('
			+ 'MembershipID'
			+ ', AuthorizationID'
			+ ', [Enabled]'

	IF (0 < @id)	SET @into = @into + ', ID'

	SET @values = ') VALUES ('
		+ '' + CONVERT(NVARCHAR(MAX), @membershipId) + ''
		+ ', ' + CONVERT(NVARCHAR(MAX), @authorizationId) + ''
		+ ', ' + CONVERT(NVARCHAR(MAX), @enabled) + ''

	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR(MAX), @id) + ''

	SET @values = @values + ')'


	/*
	INSERT INTO
		MembershipAuthorizations (
			MembershipID
			, AuthorizationID
			, [Enabled]

			, ID
		) VALUES (
			@membershipId
			, @authorizationID
			, @enabled

			, @id
		)
	*/

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
