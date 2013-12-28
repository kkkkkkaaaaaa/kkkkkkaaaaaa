CREATE PROCEDURE usp_UpdateRoles (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2
) AS
	-- 変数
	DECLARE
		@update		NVARCHAR(MAX)
		, @set		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- UPDATE
	UPDATE
		Roles

	SET
		Name				= @name
		, [Description]		= @description
		, [Enabled]			= @enabled
		, UpdatedOn			= @updatedOn

	WHERE 1 = 1
		AND ID	= @id

	-- 実行
	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
