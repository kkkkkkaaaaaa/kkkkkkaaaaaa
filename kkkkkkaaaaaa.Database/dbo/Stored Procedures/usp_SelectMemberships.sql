CREATE PROCEDURE usp_SelectMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		VARCHAR(1024)
) AS
	-- 変数
	DECLARE
		@select		VARCHAR(MAX)
		, @from		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
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
			+ ' AND ID = ' + CONVERT(NVARCHAR, @id)

	END ELSE BEGIN
		SET @where = @where
			+ ' AND Name = ''' + @name + ''''
			+ ' AND [Password] = ''' + @password + ''''

	END

	-- 実行
	EXECUTE (@select + @from + @where)

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
