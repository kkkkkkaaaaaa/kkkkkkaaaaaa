
DECLARE
	@identity	DECIMAL(38, 0)
	, @error	INT

	
EXECUTE @error = dbo.usp_InsertMemberships -1, N'duplicate', N'', 1, '2013-03-22', '2013-03-22', @identity OUTPUT;
SELECT @error;
EXECUTE @error = dbo.usp_InsertMemberships -1, N'duplicate', N'', 1, '2013-03-22', '2013-03-22', @identity OUTPUT;
SELECT @error;
