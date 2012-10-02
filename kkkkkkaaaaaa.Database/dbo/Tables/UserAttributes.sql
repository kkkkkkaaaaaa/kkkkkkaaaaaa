CREATE TABLE [dbo].[UserAttributes] (
    [ID] BIGINT NOT NULL, 
    [UserID] BIGINT         NOT NULL,
    [ItemID] INT            NOT NULL,
    [Value]  NVARCHAR (MAX) NOT NULL, 
    CONSTRAINT [PK_UserAttributes] PRIMARY KEY ([ID])
);

