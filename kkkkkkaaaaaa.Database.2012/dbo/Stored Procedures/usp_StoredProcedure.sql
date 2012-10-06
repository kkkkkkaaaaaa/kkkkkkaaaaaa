CREATE PROCEDURE usp_StoredProcedure
	-- パラメーターなし
AS
	DECLARE
		@error	INT

	-- SELECT
	SELECT
		N''														AS [NVARCHAR]
		, CONVERT(INT, 0)										AS [INT]
		, CONVERT(BIGINT, 0)									AS [BIGINT]
		, CONVERT(BIT, 0)										AS [BIT]
		, CONVERT(DATETIME, '1753/01/01 00:00:00.000')			AS [DATETIME]
		, CONVERT(DATETIME2, '0001/01/01 00:00:00.0000000')		AS [DATETIME2]

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
