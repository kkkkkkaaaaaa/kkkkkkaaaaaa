CREATE PROCEDURE usp_TruncateTable (
	-- パラメーター
	@tableName	NVARCHAR(128)
) AS
	-- 変数
	DECLARE
		@truncate	NVARCHAR(MAX)
		, @error	INT

	-- TRUNCATE
	SET @truncate = 'TRUNCATE TABLE'
		+ ' ' + CONVERT(NVARCHAR(128), @tableName)

	-- EXECUTE
	EXECUTE (@truncate)

	-- 戻り値
	SET @error = @@ERROR
		
	RETURN @error
