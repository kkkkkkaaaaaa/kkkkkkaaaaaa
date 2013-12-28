CREATE FUNCTION [dbo].[NewLine] (
	-- パラメーター
	@count	INT = 1
) RETURNS NVARCHAR(4000) AS BEGIN

	IF (@count = 1)		RETURN (NCHAR(13) + NCHAR(10))
	IF (@count < 1)		RETURN N''
	/*IF(1 < @count)*/	RETURN REPLICATE((NCHAR(13) + NCHAR(10)), @count)

END
