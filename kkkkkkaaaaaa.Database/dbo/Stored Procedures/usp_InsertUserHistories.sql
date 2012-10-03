CREATE PROCEDURE usp_InsertUserHistories
	-- パラメーター
	@userId				BIGINT
	, @revision			INT
AS
	-- 変数
	DECLARE
		@count		INT

		
	-- INSERT
	INSERT INTO
		UserHistories (
			UserID
			, Revision
			, FamilyName
			, GivenName
			, AdditionalName
			, [Description]
			, [Enabled]
			, CreatedOn
			, UpdatedOn
		)
		SELECT
			ID AS UserID
			, @revision
			, FamilyName
			, GivenName
			, AdditionalName
			, [Description]
			, [Enabled]
			, CreatedOn
			, UpdatedOn
		FROM
			Users
		WHERE
			ID = @userId

	/*
	-- INSERT
	INSERT INTO
		UserHistories (
			UserID
			, Revision
			, FamilyName
			, GivenName
			, AdditionalName
			, [Description]
			, [Enabled]
			, CreatedOn
			, UpdatedOn
		) VALUES (
			@userID
			, @revision
			, @familyName
			, @givenName
			, @additionalName
			, @description
			, @enabled
			, @createdOn
			, @createdOn
		)
		*/

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count

