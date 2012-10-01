CREATE PROCEDURE usp_UpdateRoles (
	-- パラメーター
	@name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
	, @id			BIGINT
) AS
	-- 変数
	DECLARE
		@update		NVARCHAR(MAX)
		, @set		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- UPDATE
	SET @update = 'UPDATE Roles'

	-- SET
	SET @set = ' SET'
		+ ' Name			= ''' + CONVERT(VARCHAR(MAX), @name) + ''''
		+ ', [Description]	= ''' + CONVERT(VARCHAR(MAX), @description) + ''''
		+ ', [Enabled]		= ' + CONVERT(VARCHAR(MAX), @enabled) + ''
		+ ', UdpatedOn		= ''' + CONVERT(VARCHAR(MAX), @updatedOn) + ''''

	-- WHERE
	SET @where = ' WHERE'
		+ ' ID				= ' + CONVERT(VARCHAR(MAX), @id)

	-- 実行
	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
