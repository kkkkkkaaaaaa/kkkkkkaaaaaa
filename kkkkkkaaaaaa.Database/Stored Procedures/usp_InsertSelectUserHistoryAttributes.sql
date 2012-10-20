CREATE PROCEDURE usp_InsertSelectUserHistoryAttributes (
	-- パラメーター
	@userId			BIGINT
	, @revision		INT
) AS
	-- 変数
	DECLARE
		@count	INT

	-- INSERT
	INSERT
		INTO UserHistoryAttributes (
			UserID
			, Revision
			, ItemID
			, Value
		)
		SELECT
			UserID
			, @revision
			, ItemID
			, Value
		FROM
			UserAttributes
		WHERE 1 = 1
			AND UserID = @userId

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count

