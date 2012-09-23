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
	SET @insert = 'INSERT'

	-- INTO
	SET @into = ' INTO Users ('
		+ 'ID'
		+ ', FamilyName'
		+ ', MiddleName'
		+ ', GivenName'
		+ ', Description'
		+ ', Enabled'
		+ ', UpdatedOn'
		+ ', CreatedOn'
		+ ')'

	-- VALUES
	SET @values = ' VALUES ('
		+ '@id'
		+ ', @familyName'
		+ ', @middleName'
		+ ', @givenName'
		+ ', @description'
		+ ', @enabled'
		+ ', @updatedOn'
		+ ', @createdOn'
		+ ')'

	-- 実行
	EXECUTE (@insert + @into + @values)

	-- 結果
	SET @error = @@ERROR

	RETURN @error
