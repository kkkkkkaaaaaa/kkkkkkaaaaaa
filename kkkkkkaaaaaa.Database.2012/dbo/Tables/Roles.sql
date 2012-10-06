CREATE TABLE [dbo].[Roles] (
    [ID]          BIGINT          NOT NULL,
    [Name]        NVARCHAR (1024) NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Enabled]     BIT             NOT NULL,
    [CreatedOn]   DATETIME2 (7)   NOT NULL,
    [UpdatedOn]   DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

