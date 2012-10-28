CREATE PROCEDURE usp_UpdateMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			VARCHAR(1024)
	, @password		VARCHAR(128)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
) AS
	-- 変数
	DECLARE
		@count	INT

	-- UPDATE
	UPDATE
		Memberships

	SET
		[Password]		= @password
		, [Enabled]		= @enabled
		, UpdatedOn		= @updatedOn

	WHERE 1 = 1
		AND ID	= @id

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
