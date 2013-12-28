CREATE FUNCTION [dbo].[NL] (
	-- パラメーターなし
)
RETURNS NVARCHAR(2) AS BEGIN

	RETURN dbo.NewLine(1)

END
