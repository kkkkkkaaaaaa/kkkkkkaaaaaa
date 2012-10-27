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
		+ ', ' + CAST(@enabled AS NCHAR(1)) -- + ', ' + CAST(CAST('TRUE' AS BIT) AS NCHAR(1))
		+ ', ''' + CAST(@createdOn AS NVARCHAR(27)) + ''''
		+ ', ''' + CAST(@createdOn AS NVARCHAR(27)) + '''' -- + ', ''' + CAST(@updatedOn AS NVARCHAR(27)) + ''''
	IF (0 < @id)	SET @values = @values + ', ' + CAST(@id AS NVARCHAR(MAX))
	SET @values = @values + ')'

	-- SET IDENTITY_INSERT
	IF (0 < @id)	SET IDENTITY_INSERT Memberships ON

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 戻り値
	SET @count = @@ROWCOUNT

	IF (0 < @id) SET IDENTITY_INSERT Memberships OFF

	RETURN @count
