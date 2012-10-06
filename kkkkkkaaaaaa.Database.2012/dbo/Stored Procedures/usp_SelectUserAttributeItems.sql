CREATE PROCEDURE usp_SelectUserAttributeItems
	-- パラメーター
	@id				INT
	, @name			VARCHAR(1024)
	, @description	VARCHAR(MAX)
	, @enabled		BIT
AS
	-- 変数
	DECLARE
		@select			NVARCHAR(MAX)
		, @from			NVARCHAR(MAX)
		, @where		NVARCHAR(MAX)
		, @orderBy		NVARCHAR(MAX)
		, @error		INT
		
	-- SELECT
	SELECT
		*
	FROM
		UserAttributeItems
	WHERE 1 = 1

	ORDER BY
		Name ASC
	
	/*
	-- SELECT
	SET @select = 'SEELCT'
		+ ' *'

	SET @from = ' FROM'
		+ ' UserAttibuteItems'

	SET @where = ' WHERE 1 = 1'

	SET @orderBy = 'ORDER BY'
		+ 'Name ASC'
	*/

	-- 実行
	EXECUTE (@select + @from + @where + @orderBy)

	-- 戻り値
	SET @error = @@ERROR

	RETURN  @error
