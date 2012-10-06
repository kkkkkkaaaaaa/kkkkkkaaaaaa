CREATE PROCEDURE usp_InsertUserAttributeHistories
	-- パラメーター
	@userId			BIGINT
	, @revision		BIGINT
AS
	DECLARE
		@count	INT

	-- INSERT
	INSERT INTO
		UserAttributeHistories (
			UserID
			, ItemID
			, Revision
			, Value
		)
		SELECT
			UserID
			, ItemID
			, @revision
			, Value
		FROM
			UserAttributes
		WHERE
			UserID = @userId

	-- 戻り値
	SET @count	= @@ROWCOUNT

	RETURN @count
