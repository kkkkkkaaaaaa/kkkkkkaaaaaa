CREATE TABLE [dbo].[Authorizations] (
    [ID]          BIGINT          NOT NULL,
    [PredicateID] INT             NULL,
    [Name]        NVARCHAR (1024) NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Ordinal]     INT             NOT NULL,
    [Enabled]     BIT             NOT NULL,
    CONSTRAINT [PK_Authorizations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

