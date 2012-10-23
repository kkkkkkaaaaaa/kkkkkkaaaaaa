CREATE PROCEDURE usp_InsertSelectUserHistories
	-- パラメーター
	@userId				BIGINT
	, @revision			INT OUTPUT
AS
	-- 
	DECLARE
		@count	INT

	-- UserHistories.Revision
	SELECT @revision = (ISNULL(MAX(Revision), 0) + 1) FROM UserHistories WHERE UserID = @userId

	-- INSERT
	INSERT
		INTO UserHistories (
			UserID
			, Revision
			, FamilyName
			, GivenName
			, AdditionalName
			, [Description]
			, [Enabled]
			, CreatedOn
		)
		SELECT
			ID
			, @revision
			, FamilyName
			, GivenName
			, AdditionalName
			, [Description]
			, [Enabled]
			, UpdatedOn
		FROM
			Users
		WHERE 1 = 1
			AND ID = @userId
	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
		


