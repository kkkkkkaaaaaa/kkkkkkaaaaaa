CREATE PROCEDURE usp_UpdateMemberships
	-- パラメーター
	@password		VARCHAR(128)
	, @enabled		BIT
	, @updatedOn	DATETIME2
	, @id			BIGINT
AS
	-- 変数
	DECLARE
		@error		INT

	-- UPDATE
	UPDATE
		Memberships
	SET
		[Password]		= @password
		, [Enabled]		= @enabled
		, UpdatedOn		= @updatedOn
	WHERE
		ID				= @id

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
