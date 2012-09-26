﻿CREATE TABLE [dbo].[Memberships] (
    [ID]   BIGINT          NOT NULL,
    [Name]     NVARCHAR (1024) NOT NULL,
    [Password] NVARCHAR (128)  NOT NULL,
    [Enabled]  BIT             NOT NULL,
    [CreatedOn] DATETIME2 NOT NULL, 
    [UpdatedOn] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Authentications] PRIMARY KEY CLUSTERED ([ID] ASC)
);

