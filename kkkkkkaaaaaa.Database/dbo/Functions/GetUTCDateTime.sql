﻿CREATE FUNCTION GetUTCDateTime (
	-- パラメーターなし
) RETURNS DATETIME2(7)
AS BEGIN

	-- 変数
	DECLARE
		@version		VARCHAR(128)
		, @index		INT
		, @mejor		INT
		, @datetime		DATETIME2

	-- SERVERPROPERTY('ProductVersion')
	SET @version	= CAST(SERVERPROPERTY('ProductVersion') AS VARCHAR)
	--SELECT @version AS [Version]

	-- '.' のインデックス
	SET @index		= CAST(PATINDEX('%.%', @version) AS INT)
	--SELECT @index AS [Index]

	-- メジャーバージョン
	SET @mejor		= SUBSTRING(@version, 0, @index)
	--SELECT @mejor AS [MejorVersion]

	-- 現在時刻
	IF @mejor >= 11		SET @datetime = SYSUTCDATETIME()
	ELSE				SET @datetime = CONVERT(DATETIME2(7), GETUTCDATE(), NULL)
	
	-- 戻り値
	RETURN @datetime

END
