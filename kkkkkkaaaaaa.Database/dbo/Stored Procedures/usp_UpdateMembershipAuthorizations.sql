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
		, @error	INT

	-- UPDATE
	UPDATE
		MembershipAuthorizations
	SET
		MembershipID = @membershipId
		, AuthorizationID = @authorizationId
	WHERE
		[ID] = @id

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
