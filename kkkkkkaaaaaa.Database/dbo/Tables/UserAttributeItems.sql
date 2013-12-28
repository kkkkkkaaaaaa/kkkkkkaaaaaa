CREATE TABLE [dbo].[UserAttributeItems] (
    [ID]          INT           NOT NULL,
    [Name]        VARCHAR (64)  NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    [Ordinal] INT NOT NULL,
    [Enabled]     BIT           NOT NULL,
    CONSTRAINT [PK_UserAttributeItems] PRIMARY KEY ([ID])
);

