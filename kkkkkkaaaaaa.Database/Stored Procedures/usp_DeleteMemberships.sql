﻿CREATE PROCEDURE usp_DeleteMemberships
	-- パラメーター
	@id		BIGINT
AS
	-- 変数
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = N'DELETE'

	-- FROM
	SET @from = N' FROM Memberships'

	-- WHERE
	SET @where = N''
	IF (0 < @id) BEGIN
		SET @where = @where + N' WHERE'
		SET @where = @where + N' ID = ' + CAST(@id AS NVARCHAR(MAX))

	END

	-- 実行
	EXECUTE (@delete + @from + @where)

	/*
	-- DELETE
	DELETE
		Memberships
	WHERE
		ID = @id
	*/

	-- 結果
	SET @count = @@ROWCOUNT

	RETURN @count
