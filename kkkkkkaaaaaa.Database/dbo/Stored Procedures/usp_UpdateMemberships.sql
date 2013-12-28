CREATE PROCEDURE usp_UpdateMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			VARCHAR(1024)
	, @password		VARCHAR(128)
	, @enabled		BIT
	, @createdOn	DATETIME2
	, @updatedOn	DATETIME2

) AS BEGIN

	-- 変数
	DECLARE
		@update		NVARCHAR(MAX)
		, @set		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @stmt		NVARCHAR(MAX)
		, @params	NVARCHAR(MAX)
		, @result	INT
		, @error	INT

	-- UPDATE
	SET @update = N'UPDATE'
		+ N' Memberships'

	-- SET
	SET @set = N' SET'
		+ N' [Password] = @password'
		+ N', [Enabled] = @enabled'
		+ N', UpdatedOn = @updatedOn'

	-- WHERE
	SET @where = N' WHERE'
		+ N' ID = @id'

	-- 実行
	SET @stmt = (@update + @set + @where)
	SET @params = N'@id BIGINT'
	EXECUTE @result =  sp_executesql
		@stmt
		, @params
		, @id = @id

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
END
