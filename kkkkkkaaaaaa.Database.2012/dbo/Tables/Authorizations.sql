CREATE TABLE [dbo].[Authorizations] (
    [ID]          BIGINT          NOT NULL,
    [SubjectID] INT             NULL,
    [PredicateID] INT NULL, 
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Ordinal]     INT             NOT NULL,
    [Enabled]     BIT             NOT NULL,
    CONSTRAINT [PK_Authorizations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

