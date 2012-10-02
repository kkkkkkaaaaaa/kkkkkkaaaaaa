CREATE PROCEDURE usp_SelectUserAttributes
	-- パラメーター
	@userId		BIGINT
AS
	-- 変数
	DECLARE	
		@error	INT

	SELECT
		*
	
	FROM
		UserAttributes
	
	WHERE
		UserID = @userId
	
	ORDER BY
		ItemID ASC

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
