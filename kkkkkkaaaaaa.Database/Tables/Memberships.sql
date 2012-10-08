CREATE TABLE [dbo].[Memberships] (
    [ID]   BIGINT          NOT NULL IDENTITY(1, 1),
    [Name]     NVARCHAR (1024) NOT NULL,
    [Password] NVARCHAR (128)  NOT NULL,
    [Enabled]  BIT             NOT NULL,
    [CreatedOn] DATETIME2 NOT NULL , 
    [UpdatedOn] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_Authentications] PRIMARY KEY CLUSTERED ([ID] ASC)
);

