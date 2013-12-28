CREATE PROCEDURE usp_SelectMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		NVARCHAR(128)
	, @enabled		BIT
) AS
	-- 変数
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @error	INT
		
	-- SELECT
	SET @select = N'SELECT'
		+ N' ID'
		+ N', Name'
		+ N', NULL AS [Password]'
		+ N', [Enabled]'
		+ N', CreatedOn'
		+ N', UpdatedOn'
		
	-- FROM
	SET @from = ' FROM'
		+ ' Memberships'

	-- WHERE
	SET @where = ' WHERE 1 = 1'

	IF (0 < @id) BEGIN
		SET @where = @where + N' AND ID = @id'

	END ELSE BEGIN
		SET @where = @where + N' AND Name = @name'
		IF (@password IS NOT NULL)	SET @where = @where + N' AND [Password] = @password'
		IF (@enabled IS NOT NULL)	SET @where = @where + N' AND [Enabled] = @enabled'

	END

	-- 実行
	SET @stmt = (@select + @from + @where)

	SET @params = N'@id BIGINT, @name NVARCHAR(1024), @password NVARCHAR(128), @enabled BIT'

	EXECUTE sp_executesql
		@stmt
		, @params
		, @id = @id, @name = @name, @password = @password, @enabled = @enabled

	-- 戻り値
	SET @error = @@ERROR
	
	RETURN @error
