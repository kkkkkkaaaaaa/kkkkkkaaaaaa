CREATE TABLE [dbo].[UserAttributes] (
    [UserID] BIGINT         NOT NULL,
    [ItemID] INT            NOT NULL,
    [Value]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserAttributes] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

