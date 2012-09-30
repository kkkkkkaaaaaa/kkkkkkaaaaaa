CREATE PROCEDURE [dbo].[usp_SelectNextMembershipID]
	-- パラメーター
AS
	-- 変数
	DECLARE
		@next	BIGINT
		, @error	INT

	-- Memberships.ID + 1
	SELECT
		(ISNULL(MAX(ID), 0) + 1) AS [NEXT]
	FROM
		Memberships

	-- 戻り値
	SET @error = @@ERROR

	RETURN @error


