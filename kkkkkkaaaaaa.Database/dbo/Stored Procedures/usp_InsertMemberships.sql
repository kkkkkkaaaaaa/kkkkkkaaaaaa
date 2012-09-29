CREATE PROCEDURE usp_InsertMemberships (
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @password		NVARCHAR(128)
	, @enabled		BIT
	, @createdOn	DATETIME2
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
	SET @into = ' INTO Memberships ('
		+ 'Name'
		+ ', Password'
		+ ', Enabled'
		+ ', CreatedOn'
		+ ', UpdatedOn'
	IF 0 < @id	SET @into = @into + ', ID'

	-- VALUES
	SET @values = ') VALUES ('
		+ '@name'
		+ ', @password'
		+ ', @enabled'
		+ ', @createdOn'
		+ ', @createdOn'
	IF (0 < @id) SET @values = @values + ', @id'
	SET @values = @values + ')'

	EXECUTE (@insert + @into + @values)

	/*
	INSERT
		Memberships (
			ID
			, Name
			, [Password]
			, [Enabled]
			, CreatedOn
			, UpdatedOn
		) VALUES (
			@id
			, @name
			, @password
			, @enabled
			, @createdOn
			, @createdOn
		)
	*/

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
