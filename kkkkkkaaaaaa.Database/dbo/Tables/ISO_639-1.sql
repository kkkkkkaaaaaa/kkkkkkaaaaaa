CREATE TABLE [dbo].[ISO_639-1] (
    [ID]      INT       NOT NULL,
    [Code]    NCHAR (2) NOT NULL,
    [Ordinal] INT       NOT NULL,
    [Enabled] BIT       NOT NULL,
    CONSTRAINT [PK_ISO_369-1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

