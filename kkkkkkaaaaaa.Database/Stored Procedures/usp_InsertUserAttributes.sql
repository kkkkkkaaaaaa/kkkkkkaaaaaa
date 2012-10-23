CREATE PROCEDURE usp_InsertUserAttributes (
	@userId		BIGINT
	, @itemId	INT
	, @value	NVARCHAR(MAX)
) AS
	-- パラメーター
	DECLARE
		@count	INT


	-- INSERT
	INSERT
	
	INTO UserAttributes (
		UserID
		, ItemID
		, Value
	) VALUES (
		@userId
		, @itemId
		, @value
	)

	SET @count = @@ROWCOUNT

	RETURN @count
