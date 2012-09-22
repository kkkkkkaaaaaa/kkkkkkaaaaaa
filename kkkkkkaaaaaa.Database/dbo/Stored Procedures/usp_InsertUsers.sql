CREATE PROCEDURE usp_InsertUsers (
	-- パラメーター
	@id				BIGINT
	, @family_name	NVARCHAR(1024)
	, @middle_name	NVARCHAR(1024)
	, @given_name	NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @updated_on	DATETIME2(7)
	, @Created_on	DATETIME2(7)
) AS

	-- 変数
	DECLARE
		@insert		VARCHAR(MAX)
		, @into		VARCHAR(MAX)
		, @values	VARCHAR(MAX)
		, @error	INT

	-- INSERT
	SET @insert = N'INSERT'

	-- INTO
	SET @into = N' INTO Users ('
		+ N'ID'
		+ N', FamilyName'
		+ N', MiddleName'
		+ N', GivenName'
		+ N', Description'
		+ N', Enabled'
		+ N', UpdatedOn'
		+ N', CreatedOn'
		+ N')'

	-- VALUES
	SET @values = N' VALUES ('
		+ N'@id'
		+ N', @familyName'
		+ N', @middleName'
		+ N', @givenName'
		+ N', @description'
		+ N', @enabled'
		+ N', @updatedOn'
		+ N', @createdOn'
		+ N')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 結果
	SET @error = @@ERROR

	RETURN @error
