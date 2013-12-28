CREATE FUNCTION IdentCurrentTable (
	-- パラメーター
	@tableName	NVARCHAR(MAX)
) RETURNS NUMERIC(38, 0)
AS BEGIN
	-- 変数
	DECLARE
		@current	NUMERIC(38, 0)
	
	-- IDENT_CURRENT
	SET @current = IDENT_CURRENT(@tableName)

	-- 戻り値
	RETURN @current

END
