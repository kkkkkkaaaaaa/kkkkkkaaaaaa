CREATE PROCEDURE usp_DeleteMemberships
	-- パラメーター
	@id		BIGINT
AS
	-- 
	DECLARE
		@count	INT

	-- DELETE
	DELETE
		Memberships
	WHERE
		ID = @id

	-- 
	SET @count = @@ROWCOUNT

	RETURN @count
