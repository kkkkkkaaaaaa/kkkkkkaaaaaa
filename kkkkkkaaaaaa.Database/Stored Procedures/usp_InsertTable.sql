CREATE PROCEDURE usp_InsertTable
	-- パラメーター
	@id				BIGINT
	, @datetime2	DATETIME2 = '2011/1/1 12:00:00.0000000'
	-- 出力パラメーター
	, @identity		NUMERIC(38, 0) = 0		OUTPUT
AS
	-- 変数
	DECLARE
		@insert			NVARCHAR(MAX)
		, @into			NVARCHAR(MAX)
		, @values		NVARCHAR(MAX)
		, @result		INT
		, @error		INT
		
	-- 実行
	IF (0 < @id)	SET IDENTITY_INSERT Memberships ON
	EXECUTE @result =  sp_executesql
		N'INSERT INTO [Table] ([DATETIME2]) VALUES (@datetime2); SET @identity = SCOPE_IDENTITY()'
		, N'@id BIGINT, @datetime2	DATETIME2, @identity_out NUMERIC(38, 0) = 0 OUTPUT'
		, @id = @id, @datetime2 = @datetime2, @identity = @identity OUTPUT
	IF (0 < @id)	SET IDENTITY_INSERT Memberships OFF
	
	-- 戻り値
	--ELSE			SET @identity = @id
	
	SET @error = @@ERROR

	RETURN @error