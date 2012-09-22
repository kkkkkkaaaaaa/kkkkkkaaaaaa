CREATE PROCEDURE usp_DeleteUsers (
	-- パラメーター
	@id		INT
) AS

	-- 変数
	DECLARE
		@error	INT

	-- DELETE
	DELETE FROM
		Users
	WHERE
		ID	= @id

	-- 戻り値
	SET @error	= @@ERROR

	RETURN @error
