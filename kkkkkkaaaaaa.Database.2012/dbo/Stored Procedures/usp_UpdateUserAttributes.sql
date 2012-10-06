CREATE PROCEDURE usp_UpdateUserAttributes (
	-- パラメーター
	@userId		BIGINT
	, @itemId	INT
	, @value	NVARCHAR(MAX)
) AS
	-- 変数
	DECLARE
		@count	INT

	-- UPDATE
	UPDATE
		UserAttributes
	SET
		Value		= @value
	WHERE
		1 = 1
		AND UserID	= @userId
		AND ItemID	= @itemId

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
