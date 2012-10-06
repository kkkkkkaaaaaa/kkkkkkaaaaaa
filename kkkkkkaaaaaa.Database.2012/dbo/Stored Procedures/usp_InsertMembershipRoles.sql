CREATE PROCEDURE usp_InsertMembershipRoles
	-- パタメーター
	@id					BIGINT
	, @membershipId		BIGINT
	, @roleId			BIGINT
	, @enabled			BIT
AS
	-- 変数
	DECLARE
		@insert		VARCHAR(MAX)
		, @into		VARCHAR(MAX)
		, @values	VARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'

	-- INTO
	SET @into = ' INTO MembershipRoles ('
		+ 'MembershipID'
		+ ', RoleID'
		+ ', [Enabled]'

	IF (0 < @id) SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '' + CONVERT(NVARCHAR(MAX), @membershipId)
		+ ', ' + CONVERT(NVARCHAR(MAX), @roleId)
		+ ', ' + CONVERT(NVARCHAR(MAX), @enabled)
		
	IF (0 < @id) SET @values = @values + ', ' + CONVERT(NVARCHAR(MAX), @id)

	SET @values = @values + ')'

	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
