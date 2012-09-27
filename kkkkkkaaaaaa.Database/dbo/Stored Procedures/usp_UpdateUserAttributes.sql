CREATE PROCEDURE usp_UpdateUserAttributes (
	-- パラメーター
	@itemId		INT
	, @value	NVARCHAR(MAX)
	, @userId	BIGINT
) AS
	-- 変数
	DECLARE
		@error	INT

	-- UPDATE
	UPDATE
		UserAttributes
	SET
		ItemID		= @itemId
		, Value		= @value
	WHERE
		UserID = @userId

	-- 戻り値
	SET @error = @@error

	RETURN @error
