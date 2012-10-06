CREATE TABLE [dbo].[Subjects] (
    [ID]          BIGINT          NOT NULL,
    [Name]        NVARCHAR (1024) NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Ordinal]     INT             NOT NULL,
    [Enabled]     BIT             NOT NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([ID] ASC)
);

