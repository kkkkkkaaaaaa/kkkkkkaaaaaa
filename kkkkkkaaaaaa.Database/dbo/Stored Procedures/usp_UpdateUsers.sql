﻿CREATE PROCEDURE usp_UpdateUsers (
	-- パラメーター
	@familyName		VARCHAR(1024)
	, @middleName	VARCHAR(1024)
	, @givenName	VARCHAR(1024)
	, @description	VARCHAR(MAX)
	, @enabled		BIT
	, @updatedOn	DateTime2(7)
	, @id			VARCHAR(MAX)
)
AS
	-- 変数
	DECLARE
		@update		VARCHAR(MAX)
		, @set		VARCHAR(MAX)
		, @where	VARCHAR(MAX)
		, @error	INT

	-- UPDATE
	SET @update	= 'UPDATE Users'

	-- SET
	SET @set = ' SET'
		+ ' FamilyName		= @familyName'
		+ ', MiddleName	= @middleName'
		+ ', GivenName		= @givenName'
		+ ', Description	= @description'
		+ ', Enabled		= @enabled'
		+ ', UpdateOn		= @updatedOn'

	-- WHERE
	SET @where = ' ID = ' + @id

	-- 実行
	EXECUTE (@update + @set + @where)

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error
