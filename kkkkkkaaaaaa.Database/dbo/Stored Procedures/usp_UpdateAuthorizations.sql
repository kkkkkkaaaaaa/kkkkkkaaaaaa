CREATE PROCEDURE usp_UpdateAuthorizations
	-- パラメーター
	@id				BIGINT
	, @objectId		INT
	, @predicateId	INT
	, @name			NVARCHAR(MAX)
	, @description	NVARCHAR(MAX)
	, @enabled		BIT
	, @createdOn	DATETIME2(7)
	, @updatedOn	DATETIME2(7)
AS
	-- 変数
	DECLARE
		@count	INT

	-- UPDATE
	UPDATE
		Authorizations
	
	SET
		ObjectID			= @objectId
		, PredicateID		= @predicateId
		, Name				= @name
		, [Description]		= @description
		, [Enabled]			= @enabled
		, UpdatedOn			= @updatedOn

	WHERE 1 = 1
		AND ID = @id

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
