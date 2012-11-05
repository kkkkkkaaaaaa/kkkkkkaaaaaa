CREATE PROCEDURE usp_DeleteMembershipUsers
	-- パラメーター
	@membershipId	BIGINT
	, @userId		BIGINT
AS
	-- 事前条件
	IF ((@membershipId < 1) AND (@userId < 1))	RETURN -1

	-- 変数
	DECLARE
		@delete		NVARCHAR(MAX)
		, @from		NVARCHAR(MAX)
		, @where	NVARCHAR(MAX)
		, @count	INT

	-- DELETE
	SET @delete = 'DELETE'

	-- FROM
	SET @from = ' FROM MembershipUsers'

	-- WHERE
	SET @where = ' WHERE 1 = 1'
	IF (0 < @membershipId)	SET @where = @where + ' AND MembershipID = ' + CAST(@membershipId AS NVARCHAR(MAX))
	IF (0 < @userId)		SET @where = @where + ' AND UserID = ' + CAST(@userId AS NVARCHAR(MAX))

	-- 実行
	EXECUTE (@delete + @from + @where)

	-- 戻り値
	SET @count = @@ROWCOUNT

	RETURN @count
