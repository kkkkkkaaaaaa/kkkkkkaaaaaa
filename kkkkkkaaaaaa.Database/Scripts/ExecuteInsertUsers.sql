DECLARE
	@result INT
	, @identity DECIMAL(38, 0)

EXECUTE @result = usp_InsertUsers
	-1
	, N''
	, N''
	, N''
	, N''
	, 1
	, '2008-01-01 15:00:25.0987654'
	, '2008-01-01 15:00:25.0987654'
	, @identity OUTPUT