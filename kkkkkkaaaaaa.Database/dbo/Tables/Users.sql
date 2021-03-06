﻿CREATE TABLE [dbo].[Users] (
    [ID]          BIGINT          NOT NULL IDENTITY(1, 1),
    [FamilyName]  NVARCHAR (1024) NOT NULL,
    [GivenName]   NVARCHAR (1024) NOT NULL,
    [AdditionalName]  NVARCHAR (1024) NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Enabled]     BIT             NOT NULL,
    [CreatedOn]   DATETIME2 (7)   NOT NULL,
    [UpdatedOn]   DATETIME2 (7)   NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([ID]), 
    CONSTRAINT [CK_Users_ID] CHECK (0 < [ID]) 
);
