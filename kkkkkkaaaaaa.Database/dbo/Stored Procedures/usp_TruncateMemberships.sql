CREATE PROCEDURE usp_TruncateMemberships
	-- パラメーターなし
AS
	-- 変数
	DECLARE
		@error	INT

	-- TRUNCATE
	TRUNCATE TABLE
		Memberships
	
	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
