CREATE PROCEDURE usp_TruncateUsers
	-- パラメータなし
AS

	-- 変数
	DECLARE
		@error INT

	-- TRUNCATE
	TRUNCATE TABLE
		Users

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
