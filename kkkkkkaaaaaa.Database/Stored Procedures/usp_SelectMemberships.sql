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
		, @orderBy	VARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT'
		+ ' *'

	-- FROM
	SET @from = ' FROM'
		+ ' Memberships'

	-- WHERE
	SET @where = ' WHERE 1 = 1'

	IF (@id > 0) BEGIN
		SET @where = @where
			+ ' AND ID = ' + CONVERT(NVARCHAR(MAX), @id)

	END ELSE BEGIN
		SET @where = @where
			+ ' AND Name = ''' + @name + ''''
			+ ' AND [Password] = ''' + @password + ''''

	END
	
	SET @where = @where + ' AND [Enabled] = ' + CONVERT(NVARCHAR(MAX), @enabled)

	SET @orderBy = ' ORDER BY UpdatedOn DESC'

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	/*
	SELECT
		*
	FROM
		Memberships
	WHERE
		1 = 1
		AND (Name		= @name OR Name = @name)
		AND [Password]	= @password
		AND [Enabled]	= CONVERT(BIT, 'True')
	*/

	-- 戻り値
	SET @error = @@ERROR
	
	RETURN @error
