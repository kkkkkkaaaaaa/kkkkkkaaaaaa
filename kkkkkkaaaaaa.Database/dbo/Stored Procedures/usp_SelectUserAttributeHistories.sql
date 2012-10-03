CREATE PROCEDURE usp_SelectUserAttributeHistories
	-- パラメーター
	@userId			BIGINT
	, @revision		INT
AS
	-- 変数
	DECLARE
		@count	INT

	-- SELECT
	SELECT
		*

	FROM
		UserAttributeHistories

	WHERE 1 = 1
		AND UserID		= @userId
		AND Revision	= @revision

	-- 戻り値
	SET @count	= @@ERROR

	RETURN @count
