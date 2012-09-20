CREATE TABLE [dbo].[Users] (
    [ID]          BIGINT          NOT NULL,
    [FamilyName]  NVARCHAR (1024) NOT NULL,
    [GivenName]   NVARCHAR (1024) NOT NULL,
    [MiddleName]  NVARCHAR (1024) NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Enabled]     BIT             NOT NULL,
    [CreatedOn]   DATETIME2 (7)   NOT NULL,
    [UpdatedOn]   DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

