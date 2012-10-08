CREATE PROCEDURE usp_InsertMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		NVARCHAR(128)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
) AS

	-- 変数
	DECLARE
		@insert		VARCHAR(MAX)
		, @into		VARCHAR(MAX)
		, @values	VARCHAR(MAX)
		, @count	INT

	-- INSERT
	SET @insert = 'INSERT'
	
	-- INTO
	SET @into = ' INTO Memberships ('
		+ 'Name'
		+ ', [Password]'
		+ ', [Enabled]'
		+ ', CreatedOn'
		+ ', UpdatedOn'

	IF (0 < @id)	SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '''' + @name + ''''
		+ ', ''' + @password + ''''
		+ ', ' + CONVERT(NVARCHAR, CONVERT(BIT, 'TRUE'))
		+ ', ''' + CONVERT(NVARCHAR, @createdOn, 121) + ''''
		+ ', ''' + CONVERT(NVARCHAR, @createdOn, 121) + ''''
		
	IF (0 < @id)	SET @values = @values + ', ' + CONVERT(NVARCHAR, @id)

	SET @values = @values + ')'

	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
