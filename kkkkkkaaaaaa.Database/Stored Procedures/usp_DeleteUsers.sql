CREATE PROCEDURE usp_DeleteUsers
	@id		BIGINT
AS
	-- 
	DECLARE
		@count	INT

	-- DELETE
	DELETE
		Users
	WHERE
		ID = @id

	SET @count = @@ROWCOUNT

	RETURN @count
