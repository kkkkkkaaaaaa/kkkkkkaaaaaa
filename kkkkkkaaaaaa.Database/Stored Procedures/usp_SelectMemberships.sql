CREATE PROCEDURE usp_SelectMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		NVARCHAR(128)
	, @enabled		BIT
) AS
	-- 変数
	DECLARE
		@select		VARCHAR(MAX)
		, @from		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
		, @error	INT
		
	-- SELECT
	SET @select = 'SELECT'
		+ ' ID'
		+ ', Name'
		+ ', '''' AS [Password]' -- + ', [Password]'
		+ ', [Enabled]'
		+ ', CreatedOn'
		+ ', UpdatedOn'
		
	-- FROM
	SET @from = ' FROM'
		+ ' Memberships'

	-- WHERE
	SET @where = ' WHERE 1 = 1'

	IF (0 < @id) BEGIN
		SET @where = @where + ' AND ID = ' + CAST(@id AS NVARCHAR(MAX))

	END ELSE BEGIN
		SET @where = @where + ' AND Name = ''' + @name + ''''
		
		IF (@password IS NOT NULL)	SET @where = @where + ' AND [Password] = ''' + @password + ''''
		IF (@enabled IS NOT NULL)	SET @where = @where + ' AND [Enabled] = ' + CAST(@enabled AS NCHAR(1))

	END

	-- 実行
	EXECUTE (@select + @from + @where)

	-- 戻り値
	SET @error = @@ERROR
	
	RETURN @error
