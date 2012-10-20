CREATE PROCEDURE usp_InsertSelectUserHistoryAttributes (
	@userId			BIGINT
	, @revision		INT
	, @itemId		INT
	, @value		NVARCHAR
) AS

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
RETURN 0
