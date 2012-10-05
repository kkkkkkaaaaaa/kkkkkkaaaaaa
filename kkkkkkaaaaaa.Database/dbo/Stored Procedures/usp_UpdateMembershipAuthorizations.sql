CREATE PROCEDURE usp_UpdateMembershipAuthorizations (
	-- パラメーター
	@membershipId		BIGINT
	, @authorizationId	BIGINT
	, @enabled			BIT
	, @id				BIGINT
) AS
	-- 変数
	DECLARE
		@update		NVARCHAR(MAX)
		, @set		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- UPDATE
	UPDATE
		MembershipAuthorizations
	SET
		MembershipID = @membershipId
		, AuthorizationID = @authorizationId
	WHERE
		[ID] = @id

	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
