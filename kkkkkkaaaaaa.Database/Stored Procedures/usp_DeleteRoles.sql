CREATE PROCEDURE usp_DeleteRoles (
	-- パラメーター
	@id		BIGINT
) AS
	-- 変数
	DECLARE
		@count	INT

	-- DELETE
	DELETE
	
	FROM Roles
	
	WHERE
		ID = @id

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count

	
