CREATE PROCEDURE [dbo].[usp_InsertMembershipUsers]
	-- パラメーター
	@membershipId	BIGINT
	, @userId		BIGINT
AS
	-- 変数
	DECLARE
		@result		INT
		, @error	INT

	-- INSERT
	INSERT
		INTO MembershipUsers (
			MembershipID
			, UserID
		) VALUES (
			@membershipId
			, @userId
		)

	-- 結果
	SET @error = @@ERROR

	RETURN @error

