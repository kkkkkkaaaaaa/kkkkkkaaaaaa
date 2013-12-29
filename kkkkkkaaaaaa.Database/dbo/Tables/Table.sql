﻿CREATE TABLE [dbo].[Table]
(
	[ID] BIGINT NOT NULL IDENTITY , 
    [BIGINT] BIGINT NULL, 
    [NVARCHAR] NVARCHAR(MAX) NULL, 
    [VARBINARY] VARBINARY(MAX) NULL, 
    [DATETIME2] DATETIME NULL, 
    [NUMERIC] NUMERIC(38) NULL, 
    [BIT] BIT NULL, 
    [XML] XML NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([ID])
)