CREATE PROCEDURE usp_InsertUserAttributes (
	@userId		BIGINT
	, @itemId	INT
	, @value	NVARCHAR(MAX)
) AS
	-- 変数
	DECLARE
		@error	INT

	-- INSERT
	INSERT INTO
		UserAttributes (
			UserID
			, ItemID
			, Value
		) VALUES (
			@userId
			, @itemId
			, @value
		)

	-- 戻り値
	SET @error = @@error

	RETURN @error
