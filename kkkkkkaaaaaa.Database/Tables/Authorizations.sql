CREATE TABLE [dbo].[Authorizations] (
    [ID]          BIGINT          NOT NULL IDENTITY(1, 1),
    [PredicateID] BIGINT NOT NULL, 
    [ObjectID] BIGINT NOT NULL, 
    [Name] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Enabled]     BIT             NOT NULL,
    [CreatedOn] DATETIME2 NOT NULL, 
    [UpdatedOn] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_Authorizations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

