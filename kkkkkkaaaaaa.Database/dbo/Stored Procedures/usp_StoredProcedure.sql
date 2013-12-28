CREATE PROCEDURE usp_StoredProcedure
	-- パラメーターなし
AS

	-- 変数
	DECLARE
		@error	INT

	-- SELECT
	SELECT TOP 100 PERCENT
		*

	FROM
		[Table]

	WHERE 1 <> 1

	ORDER BY
		ID ASC

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
