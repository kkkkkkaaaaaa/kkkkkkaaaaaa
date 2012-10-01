CREATE PROCEDURE [dbo].[usp_SelectRoles]
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
AS
	-- 
	DECLARE
		@select		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @orderBy	NVARCHAR(MAX)
		, @error	INT

	-- SELECT
	SET @select = 'SELECT'
		+ ' *'

	-- FROM
	SET @from = ' FROM'
		+ ' Roles'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
		+ ' AND [Enabled] = ' + CONVERT(NVARCHAR(MAX), @enabled)

	IF (0 < @id) BEGIN
		SET @where = @where
			+ ' AND ID = ' + CONVERT(NVARCHAR(MAX), @id)

	END ELSE BEGIN
		SET @where = @where
	END

	-- ORDER BY
	SET @orderBy = ' ORDER BY'
		+ 'UpdatedOn ASC'

	EXECUTE (@select + @from + @where)

	SET @error = @@ERROR

	RETURN @error
