CREATE PROCEDURE usp_InsertRoles(
	-- パラメーター
	@id				BIGINT
	, @name			NVARCHAR(1024)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2
) AS

	-- 変数
	DECLARE
		@error	INT

	-- UPDATE
	UPDATE
		Roles
	SET
		[ID]				= @id
		, Name				= @name
		, [Description]		= @description
		, [Enabled]			= @enabled
		, CreatedOn			= @createdOn
		, UpdatedOn			= @createdOn

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
