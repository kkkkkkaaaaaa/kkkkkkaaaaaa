CREATE PROCEDURE usp_DeleteUsers (
	-- パラメーター
	@id		BIGINT
) AS
	IF (@id <= 0)	RETURN -1

	-- 変数
	DECLARE
		@count	INT

	-- DELETE
	DELETE
		Users

	-- WHERE
	WHERE
		ID	= @id

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
