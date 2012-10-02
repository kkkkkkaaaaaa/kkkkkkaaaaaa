CREATE PROCEDURE usp_InsertUserAttributes (
	-- パラメーター
	@userId		BIGINT
	, @itemId	INT
	, @value	NVARCHAR(MAX)
) AS
	-- 変数
	DECLARE
		@count	INT
	
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
	SET @count = @@ROWCOUNT

	RETURN @count
