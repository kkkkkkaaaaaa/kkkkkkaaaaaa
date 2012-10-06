CREATE PROCEDURE usp_InsertUserAttributeItems
	-- 
	@id				INT
	, @name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
AS
	-- 
	DECLARE
		@insert		NVARCHAR(MAX)
		, @into		NVARCHAR(MAX)
		, @values	NVARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'
	
	-- INTO
	SET @into = ' INTO UserAttributeItems ('
		+ 'Name'
		+ ', Description'
		+ ', [Enabled]'

	IF (0 < @id)	SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '''' + CONVERT(NVARCHAR(MAX), @name) + ''''
		+ ', ''' + CONVERT(NVARCHAR(MAX), @description) + ''''
		+ ', ' + CONVERT(NVARCHAR(MAX), @enabled) + ''

	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR(MAX), @id) + ''

	SET @values = @values + ')'

	-- 
	EXECUTE (@insert + @into + @values)

	-- 
	SET @count	= @@ROWCOUNT

	RETURN @count
