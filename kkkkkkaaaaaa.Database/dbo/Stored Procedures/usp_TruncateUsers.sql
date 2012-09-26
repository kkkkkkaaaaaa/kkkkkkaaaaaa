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
	
	-- EXECUTE usp_InsertMemberships 1, N'Developer',		N'Developer',		0,	SelectUTCDateTime
	-- EXECUTE usp_InsertMemberships 1, N'System',			N'System',			1,	SelectUTCDateTime
	-- EXECUTE usp_InsertMemberships 2, N'Administrator',	N'Administrator',	1,	SelectUTCDateTime
	-- EXECUTE usp_InsertMemberships 3, N'User',			N'User',			1,	SelectUTCDateTime
	-- EXECUTE usp_InsertMemberships 4, N'Tester',			N'Tester',			1,	SelectUTCDateTime

	RETURN @error
