CREATE TABLE [dbo].[ISO_3166-1] (
    [ID]      INT       NOT NULL,
    [Alpha-2] NCHAR (2) NOT NULL,
    [Alpha-3] NCHAR (3) NOT NULL,
    [Numeric] INT       NOT NULL,
    [Ordinal] INT       NOT NULL,
    [Enabled] BIT       NOT NULL,
    CONSTRAINT [PK_ISO_3166-1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

